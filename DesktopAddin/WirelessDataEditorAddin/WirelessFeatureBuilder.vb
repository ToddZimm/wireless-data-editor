Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Geodatabase

Public Class WirelessFeatureBuilder

    Public Function CreateSiteFeature(ByVal SitePoint As ESRI.ArcGIS.Geometry.IPoint, _
        ByVal LDTProvider As String, ByVal CellID As String, ByVal CommonName As String, ByVal Address As String, _
        ByVal Community As String, ByVal State As String, ByVal CountyID As String, ByVal Technology As String, _
        ByVal Source As String, ByVal Updated As DateTime) As Integer

        'Find the site featureclass
        Dim SiteFeatureClass As IFeatureClass = GetSiteFeatureclass()
        If SiteFeatureClass Is Nothing Then Throw New Exception("Cell Site layer not found in map.")

        'Reproject the point to match the featureclass
        Dim siteDataset As ESRI.ArcGIS.Geodatabase.IDataset = CType(SiteFeatureClass, IDataset)
        Dim geoDataset As IGeoDataset = CType(siteDataset, IGeoDataset)
        Try
            SitePoint.Project(geoDataset.SpatialReference)
        Catch ex As Exception
            Throw New Exception("Error reprojecting site point: " & ex.Message)
        End Try

        'Get workspace and start editing
        Dim siteWorkspace As IWorkspace = siteDataset.Workspace
        Dim siteWorkspEdit As IWorkspaceEdit = CType(siteWorkspace, IWorkspaceEdit)
        If Not siteWorkspEdit.IsBeingEdited Then
            Throw New Exception("Workspace must be in edit mode.")
        End If

        siteWorkspEdit.StartEditOperation()

        'Check if site already exists and delete it
        Dim queryFilter As IQueryFilter = New QueryFilterClass With {
            .WhereClause = "LDTProvider = '" & LDTProvider & "' AND CellSiteID = '" & CellID & "'"
        }
        Dim cursor As ESRI.ArcGIS.Geodatabase.IFeatureCursor = SiteFeatureClass.Update(queryFilter, False)
        Dim existingFeature As IFeature = cursor.NextFeature
        While Not (existingFeature Is Nothing)
            cursor.DeleteFeature()
            existingFeature = cursor.NextFeature
        End While
        cursor = Nothing
        GC.Collect()

        'Create the new site feature
        Dim siteFeature As IFeature = SiteFeatureClass.CreateFeature()
        siteFeature.Shape = SitePoint
        siteFeature.Value(siteFeature.Fields.FindField("LDTProvider")) = LDTProvider
        siteFeature.Value(siteFeature.Fields.FindField("CommonName")) = CommonName
        siteFeature.Value(siteFeature.Fields.FindField("CellSiteID")) = CellID
        siteFeature.Value(siteFeature.Fields.FindField("Address")) = Address
        siteFeature.Value(siteFeature.Fields.FindField("Community")) = Community
        siteFeature.Value(siteFeature.Fields.FindField("State")) = State
        siteFeature.Value(siteFeature.Fields.FindField("CountyID")) = CountyID
        siteFeature.Value(siteFeature.Fields.FindField("AirInterfaceTechnology")) = Technology
        siteFeature.Value(siteFeature.Fields.FindField("Source")) = Source
        siteFeature.Value(siteFeature.Fields.FindField("Updated")) = Updated
        siteFeature.Store()

        siteWorkspEdit.StopEditOperation()

        Return siteFeature.OID
    End Function

    Public Function CreateSectorFeature(ByVal SitePoint As ESRI.ArcGIS.Geometry.IPoint, _
        ByVal LDTProvider As String, ByVal CellID As String, ByVal SectorID As Short, ByVal Azimuth As Short, _
        ByVal BeamWidth As Short, ByVal RadiusInMiles As Double, ByVal Source As String, ByVal Updated As DateTime) As Integer

        'Find the sector featureclass
        Dim SectorFeatureClass As IFeatureClass = GetSectorFeatureclass()
        If SectorFeatureClass Is Nothing Then Throw New Exception("Cell Sector layer not found in map.")

        'Reproject the point to match the featureclass
        Dim sectorDataset As ESRI.ArcGIS.Geodatabase.IDataset = CType(SectorFeatureClass, IDataset)
        Dim geoDataset As IGeoDataset = CType(sectorDataset, IGeoDataset)
        Try
            SitePoint.Project(geoDataset.SpatialReference)
        Catch ex As Exception
            Throw New Exception("Error reprojecting site point: " & ex.Message)
        End Try

        'Get the shape of the sector
        Dim fromAngle As Double = Azimuth - (BeamWidth / 2)
        Dim toAngle As Double = Azimuth + (BeamWidth / 2)
        Dim radiusUnits As Double = ConvertMilesToDatasetUnits(CType(SectorFeatureClass, IGeoDataset), RadiusInMiles)
        Dim sectorShape As IPolygon = MakeSector(SitePoint, fromAngle, toAngle, 0, radiusUnits)

        'Calculate the compass direction
        Dim compassDirection As String = ""
        If BeamWidth = 360 Then
            compassDirection = "OMNI"
        Else
            compassDirection = GetCompassDirection(Azimuth)
        End If

        'Get workspace and start editing
        Dim sectorWorkspace As IWorkspace = sectorDataset.Workspace
        Dim sectorWorkspEdit As IWorkspaceEdit = CType(sectorWorkspace, IWorkspaceEdit)
        If Not sectorWorkspEdit.IsBeingEdited Then
            Throw New Exception("Workspace must be in edit mode.")
        End If

        sectorWorkspEdit.StartEditOperation()

        'Check if sector already exists and delete it
        Dim queryFilter As IQueryFilter = New QueryFilterClass()
        queryFilter.WhereClause = "LDTProvider = '" & LDTProvider & "' AND CellID = '" & CellID & "' AND SectorID = " & SectorID.ToString
        Dim cursor As ESRI.ArcGIS.Geodatabase.IFeatureCursor = SectorFeatureClass.Update(queryFilter, False)
        Dim existingFeature As IFeature = cursor.NextFeature
        While Not (existingFeature Is Nothing)
            cursor.DeleteFeature()
            existingFeature = cursor.NextFeature
        End While
        cursor = Nothing
        GC.Collect()

        'Create new sector feature
        Dim sectorFeature As IFeature = SectorFeatureClass.CreateFeature()
        sectorFeature.Shape = sectorShape
        sectorFeature.Value(sectorFeature.Fields.FindField("UniqueID")) = CellID & " " & SectorID.ToString & " " & LDTProvider
        sectorFeature.Value(sectorFeature.Fields.FindField("LDTProvider")) = LDTProvider
        sectorFeature.Value(sectorFeature.Fields.FindField("CellID")) = CellID
        sectorFeature.Value(sectorFeature.Fields.FindField("SectorID")) = SectorID
        sectorFeature.Value(sectorFeature.Fields.FindField("Azimuth")) = Azimuth
        sectorFeature.Value(sectorFeature.Fields.FindField("Compass")) = compassDirection
        sectorFeature.Value(sectorFeature.Fields.FindField("BeamWidth")) = BeamWidth
        sectorFeature.Value(sectorFeature.Fields.FindField("Radius")) = RadiusInMiles
        sectorFeature.Value(sectorFeature.Fields.FindField("Source")) = Source
        sectorFeature.Value(sectorFeature.Fields.FindField("Updated")) = Updated

        sectorFeature.Store()

        sectorWorkspEdit.StopEditOperation()

        Return sectorFeature.OID

    End Function

    Public Function GetSectorFeatureclass() As IFeatureClass

        Dim mxDocument As ESRI.ArcGIS.ArcMapUI.IMxDocument = CType(My.ArcMap.Document, ESRI.ArcGIS.ArcMapUI.IMxDocument) ' Explicit Cast
        Dim activeView As ESRI.ArcGIS.Carto.IActiveView = mxDocument.ActiveView
        Dim map As ESRI.ArcGIS.Carto.IMap = activeView.FocusMap

        Dim uid As ESRI.ArcGIS.esriSystem.IUID = New ESRI.ArcGIS.esriSystem.UIDClass
        uid.Value = "{40A9E885-5533-11D0-98BE-00805F7CED21}" ' = IFeatureLayer

        Dim enumLayer As ESRI.ArcGIS.Carto.IEnumLayer = map.Layers((CType(uid, ESRI.ArcGIS.esriSystem.UID)), True)
        enumLayer.Reset()
        Dim layer As ESRI.ArcGIS.Carto.ILayer = enumLayer.Next
        Do While Not (layer Is Nothing)
            If layer.Name.Contains("Cell Sector") Or layer.Name.Contains("Cell_Sector") Or layer.Name.Contains("CellSector") Then
                Exit Do
            End If
            layer = enumLayer.Next()
        Loop

        If Not layer Is Nothing Then
            Dim fLayer As ESRI.ArcGIS.Carto.IFeatureLayer = CType(layer, ESRI.ArcGIS.Carto.IFeatureLayer)
            Return fLayer.FeatureClass
        Else
            Return Nothing
        End If

    End Function

    Public Function GetSiteFeatureclass() As IFeatureClass

        Dim mxDocument As ESRI.ArcGIS.ArcMapUI.IMxDocument = CType(My.ArcMap.Document, ESRI.ArcGIS.ArcMapUI.IMxDocument) ' Explicit Cast
        Dim activeView As ESRI.ArcGIS.Carto.IActiveView = mxDocument.ActiveView
        Dim map As ESRI.ArcGIS.Carto.IMap = activeView.FocusMap

        Dim uid As ESRI.ArcGIS.esriSystem.IUID = New ESRI.ArcGIS.esriSystem.UIDClass
        uid.Value = "{40A9E885-5533-11D0-98BE-00805F7CED21}" ' = IFeatureLayer

        Dim enumLayer As ESRI.ArcGIS.Carto.IEnumLayer = map.Layers((CType(uid, ESRI.ArcGIS.esriSystem.UID)), True)
        enumLayer.Reset()
        Dim layer As ESRI.ArcGIS.Carto.ILayer = enumLayer.Next
        Do While Not (layer Is Nothing)
            If layer.Name.Contains("Cell Site") Or layer.Name.Contains("Cell_Site") Or layer.Name.Contains("CellSite") Then
                Exit Do
            End If
            layer = enumLayer.Next()
        Loop

        If Not layer Is Nothing Then
            Dim fLayer As ESRI.ArcGIS.Carto.IFeatureLayer = CType(layer, ESRI.ArcGIS.Carto.IFeatureLayer)
            Return fLayer.FeatureClass
        Else
            Return Nothing
        End If
        

    End Function

    Private Function ConvertMilesToDatasetUnits(ByVal geodataset As IGeoDataset, ByVal miles As Double) As Double
        'Get the linear units of the dataset
        Dim projCoordSys As IProjectedCoordinateSystem = CType(geodataset.SpatialReference, IProjectedCoordinateSystem)
        Dim linearUnits As ILinearUnit = projCoordSys.CoordinateUnit

        'Convert the input miles to meters
        Dim meters As Double = (miles * 1609.344)
        'Convert meters to dataset units using the ConversionFactor which is units per meter
        Dim datasetUnits As Double = meters / linearUnits.ConversionFactor

        Return datasetUnits

    End Function

    Private Function GetCompassDirection(ByVal Azimuth As Short) As String

        Dim direction As String = "UNK"
        Select Case Azimuth
            Case 0 To 22
                direction = "N"
            Case 23 To 67
                direction = "NE"
            Case 68 To 112
                direction = "E"
            Case 113 To 157
                direction = "SE"
            Case 158 To 202
                direction = "S"
            Case 203 To 247
                direction = "SW"
            Case 248 To 292
                direction = "W"
            Case 293 To 337
                direction = "NW"
            Case 338 To 360
                direction = "N"
        End Select

        Return direction

    End Function

    '###################################################################################
    'Functions below refactored from ESRI User Forum posting by Kirk Kuykendall
    'http://forums.esri.com/Thread.asp?c=93&f=992&t=93800&mc=4 (7/16/2009)
    '###################################################################################

    Private Function MakeSector(ByVal pOrigin As ESRI.ArcGIS.Geometry.IPoint, ByVal FromAngleDegrees As Double, ByVal ToAngleDegrees As Double, _
        ByVal dRadius1 As Double, ByVal dRadius2 As Double) As IPolygon
        'Input angles are assumed to be compass degrees from North

        'convert input angles to radians from horizontal
        Dim dfromangle As Double = ConvertCompassDegreeToGeometricRadian(ToAngleDegrees)
        Dim dtoangle As Double = ConvertCompassDegreeToGeometricRadian(FromAngleDegrees)

        Dim pArcSeg1 As ISegment = Nothing
        If dRadius1 > 0 Then
            pArcSeg1 = MakeArcSeg(pOrigin, dRadius1, True, dFromAngle, dToAngle)
        End If

        Dim pArcSeg2 As ISegment
        pArcSeg2 = MakeArcSeg(pOrigin, dRadius2, False, dToAngle, dFromAngle)

        Dim pLineSeg1 As ISegment
        If Not pArcSeg1 Is Nothing Then
            pLineSeg1 = MakeLineSeg(pArcSeg1.ToPoint, pArcSeg2.FromPoint)
        Else
            pLineSeg1 = MakeLineSeg(pOrigin, pArcSeg2.FromPoint)
        End If

        Dim pSegColl As ISegmentCollection = New RingClass

        If Not pArcSeg1 Is Nothing Then
            pSegColl.AddSegment(pArcSeg1)
        End If
        pSegColl.AddSegment(pLineSeg1)
        pSegColl.AddSegment(pArcSeg2)

        Dim pRing As IRing
        pRing = CType(pSegColl, IRing)
        pRing.Close()

        Dim pGeomColl As IGeometryCollection = New PolygonClass
        pGeomColl.AddGeometry(CType(pSegColl, IGeometry))

        Return CType(pGeomColl, IPolygon)

    End Function

    Private Function MakeLineSeg(ByVal pPoint1 As IPoint, ByVal pPoint2 As IPoint) As ISegment

        Dim newLineSeg As ILine = New ESRI.ArcGIS.Geometry.Line
        newLineSeg.PutCoords(pPoint1, pPoint2)
        Return CType(newLineSeg, ISegment)

    End Function

    Private Function MakeArcSeg(ByVal pOrigin As IPoint, ByVal dRadius As Double, ByVal bCCW As Boolean, _
        ByVal dFromAngle As Double, ByVal dToAngle As Double) As ISegment

        Dim pCCA As IConstructCircularArc2 = New CircularArcClass
        pCCA.ConstructArcDistance(pOrigin, MakePoint(pOrigin, dFromAngle, dRadius), bCCW, (dToAngle - dFromAngle) * dRadius)
        Return CType(pCCA, ISegment)

    End Function

    Private Function MakePoint(ByVal pOrigin As IPoint, ByVal dAngle As Double, _
        ByVal dRadius As Double) As IPoint

        Dim pCP As IConstructPoint = New PointClass
        pCP.ConstructAngleDistance(pOrigin, dAngle, dRadius)
        Return CType(pCP, IPoint)

    End Function

    Private Function ConvertCompassDegreeToGeometricRadian(ByVal CompassDegree As Double) As Double
        'Converts the input CompassDegree to radians from horizontal

        Dim horizontalDegree As Double = 90 - CompassDegree
        Dim outRadians As Double = horizontalDegree * (Math.PI / 180)
        Return outRadians

    End Function

End Class
