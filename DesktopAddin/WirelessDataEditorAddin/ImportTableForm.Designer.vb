<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportTableForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cboTableSelection = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.chkUpdateSites = New System.Windows.Forms.CheckBox
        Me.chkUpdateSectors = New System.Windows.Forms.CheckBox
        Me.pbarImportProgress = New System.Windows.Forms.ProgressBar
        Me.lblImporting = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cboTableSelection
        '
        Me.cboTableSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTableSelection.FormattingEnabled = True
        Me.cboTableSelection.Location = New System.Drawing.Point(12, 28)
        Me.cboTableSelection.Name = "cboTableSelection"
        Me.cboTableSelection.Size = New System.Drawing.Size(268, 21)
        Me.cboTableSelection.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select table to import:"
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(112, 101)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'chkUpdateSites
        '
        Me.chkUpdateSites.AutoSize = True
        Me.chkUpdateSites.Checked = True
        Me.chkUpdateSites.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUpdateSites.Location = New System.Drawing.Point(12, 55)
        Me.chkUpdateSites.Name = "chkUpdateSites"
        Me.chkUpdateSites.Size = New System.Drawing.Size(107, 17)
        Me.chkUpdateSites.TabIndex = 3
        Me.chkUpdateSites.Text = "Update Cell Sites"
        Me.chkUpdateSites.UseVisualStyleBackColor = True
        '
        'chkUpdateSectors
        '
        Me.chkUpdateSectors.AutoSize = True
        Me.chkUpdateSectors.Checked = True
        Me.chkUpdateSectors.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUpdateSectors.Location = New System.Drawing.Point(12, 78)
        Me.chkUpdateSectors.Name = "chkUpdateSectors"
        Me.chkUpdateSectors.Size = New System.Drawing.Size(120, 17)
        Me.chkUpdateSectors.TabIndex = 4
        Me.chkUpdateSectors.Text = "Update Cell Sectors"
        Me.chkUpdateSectors.UseVisualStyleBackColor = True
        '
        'pbarImportProgress
        '
        Me.pbarImportProgress.Location = New System.Drawing.Point(12, 144)
        Me.pbarImportProgress.Name = "pbarImportProgress"
        Me.pbarImportProgress.Size = New System.Drawing.Size(268, 23)
        Me.pbarImportProgress.TabIndex = 5
        Me.pbarImportProgress.Visible = False
        '
        'lblImporting
        '
        Me.lblImporting.AutoSize = True
        Me.lblImporting.Location = New System.Drawing.Point(12, 127)
        Me.lblImporting.Name = "lblImporting"
        Me.lblImporting.Size = New System.Drawing.Size(97, 13)
        Me.lblImporting.TabIndex = 6
        Me.lblImporting.Text = "Importing records..."
        Me.lblImporting.Visible = False
        '
        'ImportTableForm
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 177)
        Me.Controls.Add(Me.lblImporting)
        Me.Controls.Add(Me.pbarImportProgress)
        Me.Controls.Add(Me.chkUpdateSectors)
        Me.Controls.Add(Me.chkUpdateSites)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboTableSelection)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ImportTableForm"
        Me.ShowIcon = False
        Me.Text = "Import Sector Table"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboTableSelection As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents chkUpdateSites As System.Windows.Forms.CheckBox
    Friend WithEvents chkUpdateSectors As System.Windows.Forms.CheckBox
    Friend WithEvents pbarImportProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents lblImporting As System.Windows.Forms.Label
End Class
