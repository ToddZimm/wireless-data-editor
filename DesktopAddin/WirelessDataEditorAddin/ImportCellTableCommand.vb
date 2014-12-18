Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Carto

Public Class ImportCellTableCommand
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Public Sub New()

    End Sub

    Protected Overrides Sub OnClick()

        Dim featureBuilder As New WirelessDataEditor.WirelessFeatureBuilder

        'Find the cell sites and cell sectors layers in the map
        Dim cellSiteLayer As IFeatureClass = featureBuilder.GetSiteFeatureclass()
        Dim cellSectorLayer As IFeatureClass = featureBuilder.GetSectorFeatureclass()
        If cellSectorLayer Is Nothing Or cellSiteLayer Is Nothing Then
            Windows.Forms.MessageBox.Show("Cell Sites and/or Cell Sectors layer not found.")
            Exit Sub
        End If

        'Set up the form to allow the user to select the table to import and options
        Dim frm As New ImportTableForm

        'Fill the form's combo box with the list of tables in the map
        Dim tableCollection As IStandaloneTableCollection = CType(My.ArcMap.Document.ActiveView.FocusMap, IStandaloneTableCollection)
        If tableCollection.StandaloneTableCount < 1 Then
            Windows.Forms.MessageBox.Show("No tables found in map to import.")
            Exit Sub
        End If
        For idx As Integer = 0 To tableCollection.StandaloneTableCount - 1
            frm.cboTableSelection.Items.Add(tableCollection.StandaloneTable(idx).Name)
        Next
        frm.cboTableSelection.SelectedIndex = 0

        If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            'Get the iTable from the selected table
            Dim importTable As ESRI.ArcGIS.Geodatabase.ITable = tableCollection.StandaloneTable(frm.cboTableSelection.SelectedIndex).Table
            Dim queryFilter As ESRI.ArcGIS.Geodatabase.IQueryFilter = New ESRI.ArcGIS.Geodatabase.QueryFilter
            queryFilter.WhereClause = "1=1"

            'Set up the form and progress bar to show import status
            With frm.pbarImportProgress
                .Minimum = 0
                .Maximum = importTable.RowCount(queryFilter)
                .Value = 0
                .Visible = True
            End With
            With frm
                .cboTableSelection.Enabled = False
                .chkUpdateSectors.Enabled = False
                .chkUpdateSites.Enabled = False
                .btnOK.Enabled = False
                .lblImporting.Visible = True
                .Visible = True
            End With
            System.Windows.Forms.Application.DoEvents()

            'Edit the workspace
            Dim siteDataset As ESRI.ArcGIS.Geodatabase.IDataset = CType(cellSiteLayer, IDataset)
            Dim siteWorkspace As IWorkspace = siteDataset.Workspace
            Dim siteWorkspEdit As IWorkspaceEdit = CType(siteWorkspace, IWorkspaceEdit)
            Dim stopEditOnComplete As Boolean = False
            If Not siteWorkspEdit.IsBeingEdited Then
                Try
                    siteWorkspEdit.StartEditing(False)
                    stopEditOnComplete = True
                Catch ex As Exception
                    Windows.Forms.MessageBox.Show("Unable to edit the workspace." & vbNewLine & ex.Message)
                    Exit Sub
                End Try
            End If

            'Get all the rows in the table and loop through them
            Dim tableCursor As ESRI.ArcGIS.Geodatabase.ICursor = importTable.Search(queryFilter, False)
            Dim tableRow As ESRI.ArcGIS.Geodatabase.IRow = tableCursor.NextRow

            'Check field names for required fields
            Dim msg As String = String.Empty
            If tableRow.Fields.FindField("LDTProvider") = -1 Then msg = msg & "Missing Field: LDTProvider" & vbNewLine
            If tableRow.Fields.FindField("CellID") = -1 Then msg = msg & "Missing Field: CellID" & vbNewLine
            If tableRow.Fields.FindField("SectorID") = -1 Then msg = msg & "Missing Field: SectorID" & vbNewLine
            If tableRow.Fields.FindField("Longitude") = -1 Then msg = msg & "Missing Field: Longitude" & vbNewLine
            If tableRow.Fields.FindField("Latitude") = -1 Then msg = msg & "Missing Field: Latitude" & vbNewLine
            If tableRow.Fields.FindField("Azimuth") = -1 Then msg = msg & "Missing Field: Azimuth" & vbNewLine
            If tableRow.Fields.FindField("BeamWidth") = -1 Then msg = msg & "Missing Field: BeamWidth" & vbNewLine
            If tableRow.Fields.FindField("Radius") = -1 Then msg = msg & "Missing Field: Radius" & vbNewLine
            If tableRow.Fields.FindField("SiteCommonName") = -1 Then msg = msg & "Missing Field: SiteCommonName" & vbNewLine
            If tableRow.Fields.FindField("SiteAddress") = -1 Then msg = msg & "Missing Field: SiteAddress" & vbNewLine
            If tableRow.Fields.FindField("SiteCommunity") = -1 Then msg = msg & "Missing Field: SiteCommunity" & vbNewLine
            If tableRow.Fields.FindField("SiteState") = -1 Then msg = msg & "Missing Field: SiteState" & vbNewLine
            If tableRow.Fields.FindField("CountyID") = -1 Then msg = msg & "Missing Field: CountyID" & vbNewLine
            If tableRow.Fields.FindField("Technology") = -1 Then msg = msg & "Missing Field: Technology" & vbNewLine
            If tableRow.Fields.FindField("Source") = -1 Then msg = msg & "Missing Field: Source" & vbNewLine
            If tableRow.Fields.FindField("Updated") = -1 Then msg = msg & "Missing Field: Updated" & vbNewLine
            If msg <> String.Empty Then
                Windows.Forms.MessageBox.Show("Required fields are missing from the table:" & vbNewLine & msg)
            Else
                My.ArcMap.Document.ActiveView.FocusMap.DelayDrawing(True)
                While Not (tableRow Is Nothing)
                    Try
                        'Make the site point
                        Dim sitePoint As ESRI.ArcGIS.Geometry.IPoint = New ESRI.ArcGIS.Geometry.Point()
                        sitePoint.PutCoords(CDbl(tableRow.Value(tableRow.Fields.FindField("Longitude"))), CDbl(tableRow.Value(tableRow.Fields.FindField("Latitude"))))
                        Dim spRefFac As ISpatialReferenceFactory3 = New SpatialReferenceEnvironment
                        sitePoint.SpatialReference = spRefFac.CreateGeographicCoordinateSystem(ESRI.ArcGIS.Geometry.esriSRGeoCSType.esriSRGeoCS_WGS1984)

                        'Update cell sector dataset
                        If frm.chkUpdateSectors.Checked Then
                            featureBuilder.CreateSectorFeature(sitePoint, _
                                tableRow.Value(tableRow.Fields.FindField("LDTProvider")).ToString, _
                                tableRow.Value(tableRow.Fields.FindField("CellID")).ToString, _
                                CShort(tableRow.Value(tableRow.Fields.FindField("SectorID"))), _
                                CShort(tableRow.Value(tableRow.Fields.FindField("Azimuth"))), _
                                CShort(tableRow.Value(tableRow.Fields.FindField("BeamWidth"))), _
                                CDbl(tableRow.Value(tableRow.Fields.FindField("Radius"))), _
                                tableRow.Value(tableRow.Fields.FindField("Source")).ToString, _
                                CDate(tableRow.Value(tableRow.Fields.FindField("Updated"))))
                        End If

                        'Update cell site dataset
                        If frm.chkUpdateSites.Checked Then
                            featureBuilder.CreateSiteFeature(sitePoint, _
                                tableRow.Value(tableRow.Fields.FindField("LDTProvider")).ToString, _
                                tableRow.Value(tableRow.Fields.FindField("CellID")).ToString, _
                                tableRow.Value(tableRow.Fields.FindField("SiteCommonName")).ToString, _
                                tableRow.Value(tableRow.Fields.FindField("SiteAddress")).ToString, _
                                tableRow.Value(tableRow.Fields.FindField("SiteCommunity")).ToString, _
                                tableRow.Value(tableRow.Fields.FindField("SiteState")).ToString, _
                                tableRow.Value(tableRow.Fields.FindField("CountyID")).ToString, _
                                tableRow.Value(tableRow.Fields.FindField("Technology")).ToString, _
                                tableRow.Value(tableRow.Fields.FindField("Source")).ToString, _
                                CDate(tableRow.Value(tableRow.Fields.FindField("Updated"))))
                        End If

                    Catch ex As Exception
                        Windows.Forms.MessageBox.Show("Error creating feature on row " & CStr(frm.pbarImportProgress.Value + 1) & vbNewLine & ex.Message, "Import Cell Table")
                    End Try

                    tableRow = tableCursor.NextRow
                    frm.pbarImportProgress.Value = frm.pbarImportProgress.Value + 1
                    frm.Focus()
                    System.Windows.Forms.Application.DoEvents()
                End While
            End If

            'Dispose of the cursor
            tableCursor = Nothing
            GC.Collect()

            'Stop editing if this command started it
            If stopEditOnComplete Then
                siteWorkspEdit.StopEditing(True)
            End If
            'Refresh the view to see the changes
            My.ArcMap.Document.ActiveView.FocusMap.DelayDrawing(False)
            My.ArcMap.Document.ActiveView.Refresh()

        End If

        'Dispose of the form
        frm.Close()
        frm.Dispose()

    End Sub

    Protected Overrides Sub OnUpdate()
        Enabled = My.ArcMap.Application IsNot Nothing
    End Sub
End Class
