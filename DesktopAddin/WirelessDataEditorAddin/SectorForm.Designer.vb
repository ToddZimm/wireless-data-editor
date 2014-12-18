<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SectorForm
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLDTProvider = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSectorID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCellID = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTechnology = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCountyID = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSiteCommunity = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSiteAddress = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSiteName = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtRadius = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtBeamWidth = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtAzimuth = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtUpdated = New System.Windows.Forms.MaskedTextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtLatitude = New System.Windows.Forms.TextBox()
        Me.txtLongitude = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkUpdateSite = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 17)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "LDT Provider*"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtLDTProvider
        '
        Me.txtLDTProvider.Location = New System.Drawing.Point(127, 18)
        Me.txtLDTProvider.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLDTProvider.MaxLength = 8
        Me.txtLDTProvider.Name = "txtLDTProvider"
        Me.txtLDTProvider.Size = New System.Drawing.Size(105, 22)
        Me.txtLDTProvider.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(59, 54)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Latitude*"
        '
        'txtSectorID
        '
        Me.txtSectorID.Location = New System.Drawing.Point(467, 18)
        Me.txtSectorID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSectorID.MaxLength = 2
        Me.txtSectorID.Name = "txtSectorID"
        Me.txtSectorID.Size = New System.Drawing.Size(41, 22)
        Me.txtSectorID.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(389, 22)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 17)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Sector ID*"
        '
        'txtCellID
        '
        Me.txtCellID.Location = New System.Drawing.Point(309, 18)
        Me.txtCellID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCellID.MaxLength = 6
        Me.txtCellID.Name = "txtCellID"
        Me.txtCellID.Size = New System.Drawing.Size(71, 22)
        Me.txtCellID.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(251, 22)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 17)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Cell ID*"
        '
        'txtTechnology
        '
        Me.txtTechnology.Location = New System.Drawing.Point(127, 271)
        Me.txtTechnology.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTechnology.MaxLength = 25
        Me.txtTechnology.Name = "txtTechnology"
        Me.txtTechnology.Size = New System.Drawing.Size(193, 22)
        Me.txtTechnology.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 274)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 17)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Technology"
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(127, 303)
        Me.txtSource.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSource.MaxLength = 15
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(159, 22)
        Me.txtSource.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(67, 306)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 17)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Source"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(309, 306)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 17)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Date Updated*"
        '
        'txtCountyID
        '
        Me.txtCountyID.Location = New System.Drawing.Point(281, 239)
        Me.txtCountyID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCountyID.MaxLength = 8
        Me.txtCountyID.Name = "txtCountyID"
        Me.txtCountyID.Size = New System.Drawing.Size(65, 22)
        Me.txtCountyID.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(185, 242)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 17)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "County FIPS"
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(127, 239)
        Me.txtState.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtState.MaxLength = 2
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(39, 22)
        Me.txtState.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(76, 242)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 17)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "State"
        '
        'txtSiteCommunity
        '
        Me.txtSiteCommunity.Location = New System.Drawing.Point(127, 207)
        Me.txtSiteCommunity.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSiteCommunity.MaxLength = 32
        Me.txtSiteCommunity.Name = "txtSiteCommunity"
        Me.txtSiteCommunity.Size = New System.Drawing.Size(315, 22)
        Me.txtSiteCommunity.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 210)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 17)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Site Community"
        '
        'txtSiteAddress
        '
        Me.txtSiteAddress.Location = New System.Drawing.Point(127, 175)
        Me.txtSiteAddress.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSiteAddress.MaxLength = 72
        Me.txtSiteAddress.Name = "txtSiteAddress"
        Me.txtSiteAddress.Size = New System.Drawing.Size(315, 22)
        Me.txtSiteAddress.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(31, 178)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 17)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Site Address"
        '
        'txtSiteName
        '
        Me.txtSiteName.Location = New System.Drawing.Point(127, 143)
        Me.txtSiteName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSiteName.MaxLength = 25
        Me.txtSiteName.Name = "txtSiteName"
        Me.txtSiteName.Size = New System.Drawing.Size(315, 22)
        Me.txtSiteName.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(44, 146)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 17)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Site Name"
        '
        'txtRadius
        '
        Me.txtRadius.Location = New System.Drawing.Point(433, 82)
        Me.txtRadius.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRadius.MaxLength = 4
        Me.txtRadius.Name = "txtRadius"
        Me.txtRadius.Size = New System.Drawing.Size(39, 22)
        Me.txtRadius.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(372, 86)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 17)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Radius*"
        '
        'txtBeamWidth
        '
        Me.txtBeamWidth.Location = New System.Drawing.Point(295, 82)
        Me.txtBeamWidth.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBeamWidth.MaxLength = 3
        Me.txtBeamWidth.Name = "txtBeamWidth"
        Me.txtBeamWidth.Size = New System.Drawing.Size(39, 22)
        Me.txtBeamWidth.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(200, 86)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 17)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Beam Width*"
        '
        'txtAzimuth
        '
        Me.txtAzimuth.Location = New System.Drawing.Point(127, 82)
        Me.txtAzimuth.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtAzimuth.MaxLength = 3
        Me.txtAzimuth.Name = "txtAzimuth"
        Me.txtAzimuth.Size = New System.Drawing.Size(39, 22)
        Me.txtAzimuth.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(60, 86)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 17)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Azimuth*"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(296, 54)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 17)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Longitude*"
        '
        'txtUpdated
        '
        Me.txtUpdated.Location = New System.Drawing.Point(416, 303)
        Me.txtUpdated.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtUpdated.Mask = "00/00/0000"
        Me.txtUpdated.Name = "txtUpdated"
        Me.txtUpdated.Size = New System.Drawing.Size(92, 22)
        Me.txtUpdated.TabIndex = 16
        Me.txtUpdated.ValidatingType = GetType(Date)
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(223, 354)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(100, 28)
        Me.btnOK.TabIndex = 17
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtLatitude
        '
        Me.txtLatitude.Location = New System.Drawing.Point(127, 52)
        Me.txtLatitude.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLatitude.MaxLength = 13
        Me.txtLatitude.Name = "txtLatitude"
        Me.txtLatitude.Size = New System.Drawing.Size(132, 22)
        Me.txtLatitude.TabIndex = 3
        '
        'txtLongitude
        '
        Me.txtLongitude.Location = New System.Drawing.Point(376, 50)
        Me.txtLongitude.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLongitude.MaxLength = 13
        Me.txtLongitude.Name = "txtLongitude"
        Me.txtLongitude.Size = New System.Drawing.Size(132, 22)
        Me.txtLongitude.TabIndex = 4
        '
        'chkUpdateSite
        '
        Me.chkUpdateSite.AutoSize = True
        Me.chkUpdateSite.Checked = True
        Me.chkUpdateSite.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUpdateSite.Location = New System.Drawing.Point(127, 114)
        Me.chkUpdateSite.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkUpdateSite.Name = "chkUpdateSite"
        Me.chkUpdateSite.Size = New System.Drawing.Size(167, 21)
        Me.chkUpdateSite.TabIndex = 8
        Me.chkUpdateSite.Text = "Update Cell Site Point"
        Me.chkUpdateSite.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(473, 91)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 16)
        Me.Label17.TabIndex = 34
        Me.Label17.Text = "miles"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(335, 91)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(35, 16)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "deg."
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(167, 91)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(35, 16)
        Me.Label19.TabIndex = 36
        Me.Label19.Text = "deg."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(123, 335)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(121, 17)
        Me.Label20.TabIndex = 37
        Me.Label20.Text = "* = Required Field"
        '
        'SectorForm
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 406)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.chkUpdateSite)
        Me.Controls.Add(Me.txtLongitude)
        Me.Controls.Add(Me.txtLatitude)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtUpdated)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtAzimuth)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtBeamWidth)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtRadius)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtSiteName)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtSiteAddress)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtSiteCommunity)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtState)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCountyID)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTechnology)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCellID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSectorID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLDTProvider)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SectorForm"
        Me.Text = "Cell Sector"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLDTProvider As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSectorID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCellID As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTechnology As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCountyID As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSiteCommunity As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSiteAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSiteName As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtRadius As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtBeamWidth As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtAzimuth As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtUpdated As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtLatitude As System.Windows.Forms.TextBox
    Friend WithEvents txtLongitude As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents chkUpdateSite As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
End Class
