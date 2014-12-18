Imports System.Windows.Forms

Public Class DefaultCountyCommand
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Protected Overrides Sub OnClick()
        Try
            Dim newValue As String = InputBox("Enter default County FIPS:", "Change Default County", My.Settings.DefaultCountyID)
            If newValue <> "" Then
                My.Settings.DefaultCountyID = newValue.Substring(0, 5)
                My.Settings.Save()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Changing Value")
        End Try
    End Sub

    Protected Overrides Sub OnUpdate()
        Enabled = My.ArcMap.Application IsNot Nothing
    End Sub

End Class
