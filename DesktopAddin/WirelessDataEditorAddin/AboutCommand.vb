Public Class AboutCommand
  Inherits ESRI.ArcGIS.Desktop.AddIns.Button

  Protected Overrides Sub OnClick()

        Dim frm As New frmAbout
        frm.ShowDialog()
        frm = Nothing

    End Sub

    Protected Overrides Sub OnUpdate()
        Enabled = My.ArcMap.Application IsNot Nothing
    End Sub

End Class
