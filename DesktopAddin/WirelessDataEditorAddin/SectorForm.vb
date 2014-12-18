Public Class SectorForm

    Private Sub txtSectorID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSectorID.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = CChar("")
            e.Handled = True
        End If
    End Sub

    Private Sub txtLatitude_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLatitude.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) _
          And Not e.KeyChar = "." And Not e.KeyChar = "-" Then
            e.KeyChar = CChar("")
            e.Handled = True
        End If

        Select Case e.KeyChar.ToString
            Case "-"    'Only allow negative sign at the beginning of the number
                If Me.txtLatitude.Text <> "" Then
                    e.Handled = True
                End If
            Case "."    'Only allow one "."
                If Me.txtLatitude.Text.Contains(".") Then
                    e.Handled = True
                End If
        End Select

    End Sub

    Private Sub txtLongitude_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLongitude.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) _
          And Not e.KeyChar = "." And Not e.KeyChar = "-" Then
            e.KeyChar = CChar("")
            e.Handled = True
        End If

        Select Case e.KeyChar.ToString
            Case "-"    'Only allow negative sign at the beginning of the number
                If Me.txtLongitude.Text <> "" Then
                    e.Handled = True
                End If
            Case "."    'Only allow one "."
                If Me.txtLongitude.Text.Contains(".") Then
                    e.Handled = True
                End If
        End Select
    End Sub

    Private Sub txtAzimuth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAzimuth.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = CChar("")
            e.Handled = True
        End If
    End Sub

    Private Sub txtBeamWidth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBeamWidth.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = CChar("")
            e.Handled = True
        End If
    End Sub

    Private Sub txtRadius_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRadius.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) _
          And Not e.KeyChar = "." Then
            e.KeyChar = CChar("")
            e.Handled = True
        End If

        Select Case e.KeyChar.ToString
            Case "."    'Only allow one "."
                If Me.txtRadius.Text.Contains(".") Then
                    e.Handled = True
                End If
        End Select
    End Sub

    Private Sub txtCountyID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCountyID.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = CChar("")
            e.Handled = True
        End If
    End Sub

    Private Sub SectorForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txtState.Text = My.Settings.DefaultState
        Me.txtCountyID.Text = My.Settings.DefaultCountyID
        Me.txtUpdated.ValidatingType = GetType(System.DateTime)
        Me.txtUpdated.Text = Format(DateTime.Now(), "MM/dd/yyyy")
    End Sub

    Private Sub txtUpdated_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUpdated.KeyDown
        Me.ToolTip1.Hide(Me.txtUpdated)
    End Sub

    Private Sub txtUpdated_TypeValidationCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.TypeValidationEventArgs) Handles txtUpdated.TypeValidationCompleted
        If Not e.IsValidInput Then
            Me.ToolTip1.ToolTipTitle = ""
            Me.ToolTip1.Show("Update Date is not a valid date.", Me.txtUpdated, -20, -20, 5000)
            e.Cancel = True
        End If
    End Sub

    Private Sub chkUpdateSite_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUpdateSite.CheckedChanged
        If Me.chkUpdateSite.Checked Then
            Me.txtSiteName.Enabled = True
            Me.txtSiteAddress.Enabled = True
            Me.txtSiteCommunity.Enabled = True
            Me.txtState.Enabled = True
            Me.txtCountyID.Enabled = True
            Me.txtTechnology.Enabled = True
        Else
            Me.txtSiteName.Enabled = False
            Me.txtSiteAddress.Enabled = False
            Me.txtSiteCommunity.Enabled = False
            Me.txtState.Enabled = False
            Me.txtCountyID.Enabled = False
            Me.txtTechnology.Enabled = False
        End If
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class