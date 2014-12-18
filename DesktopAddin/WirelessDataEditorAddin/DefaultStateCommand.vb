Imports System.Windows.Forms

Public Class DefaultStateCommand
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button

    Protected Overrides Sub OnClick()

        Try
            Dim newValue As String = InputBox("Enter default state:", "Change Default State", My.Settings.DefaultState)
            If newValue <> "" Then
                My.Settings.DefaultState = newValue.Substring(0, 2)
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
