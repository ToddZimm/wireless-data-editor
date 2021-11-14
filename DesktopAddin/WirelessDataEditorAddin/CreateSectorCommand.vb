Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geometry

Public Class CreateSectorCommand
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Protected Overrides Sub OnClick()

        Dim featureBuilder As New WirelessDataEditor.WirelessFeatureBuilder

        'Find the cell sites and cell sectors layers in the map
        Dim cellSiteLayer As IFeatureClass = featureBuilder.GetSiteFeatureclass()
        Dim cellSectorLayer As IFeatureClass = featureBuilder.GetSectorFeatureclass()
        If cellSectorLayer Is Nothing Or cellSiteLayer Is Nothing Then
            Windows.Forms.MessageBox.Show("Cell Sites and/or Cell Sectors layer not found.")
            Exit Sub
        End If

        Dim frm As SectorForm = New SectorForm
        If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then

            'Make the site point
            Dim sitePoint As ESRI.ArcGIS.Geometry.IPoint = New ESRI.ArcGIS.Geometry.Point()
            Try
                sitePoint.PutCoords(CDbl(frm.txtLongitude.Text), CDbl(frm.txtLatitude.Text))
            Catch ex As Exception
                Windows.Forms.MessageBox.Show("Error creating site point:" & vbNewLine & ex.Message)
                Exit Sub
            End Try

            Dim factoryType As Type = Type.GetTypeFromProgID("esriGeometry.SpatialReferenceEnvironment")
            Dim spRefFac As ISpatialReferenceFactory3 = CType(Activator.CreateInstance(factoryType), ISpatialReferenceFactory3)

            sitePoint.SpatialReference = spRefFac.CreateGeographicCoordinateSystem(esriSRGeoCSType.esriSRGeoCS_WGS1984)

            'Edit the workspace
            Dim siteDataset As ESRI.ArcGIS.Geodatabase.IDataset = CType(cellSectorLayer, ESRI.ArcGIS.Geodatabase.IDataset)
            Dim siteWorkspace As IWorkspace = siteDataset.Workspace
            Dim siteWorkspEdit As IWorkspaceEdit = CType(siteWorkspace, IWorkspaceEdit)
            Dim stopEditOnComplete As Boolean = False
            If Not siteWorkspEdit.IsBeingEdited Then
                Try
                    siteWorkspEdit.StartEditing(False)
                    stopEditOnComplete = True
                Catch ex As Exception
                    Windows.Forms.MessageBox.Show("Unable to edit the workspace:" & vbNewLine & ex.Message)
                    Exit Sub
                End Try
            End If

            'Create Sector feature
            Try
                featureBuilder.CreateSectorFeature(sitePoint, frm.txtLDTProvider.Text, frm.txtCellID.Text, CShort(frm.txtSectorID.Text), CShort(frm.txtAzimuth.Text), CShort(frm.txtBeamWidth.Text), CDbl(frm.txtRadius.Text), frm.txtSource.Text, CDate(frm.txtUpdated.Text))
            Catch ex As Exception
                Windows.Forms.MessageBox.Show("Error creating the sector feature:" & vbNewLine & ex.Message)
            End Try
            If frm.chkUpdateSite.Checked Then
                'Create Site feature
                Try
                    featureBuilder.CreateSiteFeature(sitePoint, frm.txtLDTProvider.Text, frm.txtCellID.Text, frm.txtSiteName.Text, frm.txtSiteAddress.Text, frm.txtSiteCommunity.Text, frm.txtState.Text, frm.txtCountyID.Text, frm.txtTechnology.Text, frm.txtSource.Text, CDate(frm.txtUpdated.Text))
                Catch ex As Exception
                    Windows.Forms.MessageBox.Show("Error creating the site feature:" & vbNewLine & ex.Message)
                End Try
            End If

            'Stop editing if this command started it
            If stopEditOnComplete = True Then
                siteWorkspEdit.StopEditing(True)
            End If
            'Refresh the view to see the changes
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
