Imports ESRI.ArcGIS.esriSystem

Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geometry


Imports System.Reflection
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing
Imports System.Text.RegularExpressions
Imports Microsoft.Win32

''' <summary>
''' generic, self-contained About Box dialog
''' </summary>
''' <remarks>
''' Jeff Atwood
''' http://www.codinghorror.com
''' </remarks>
Public Class frmAbout
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents MoreRichTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents AppInfoListView As System.Windows.Forms.ListView
    Friend WithEvents colKey As System.Windows.Forms.ColumnHeader
    Friend WithEvents colValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents AssemblyInfoListView As System.Windows.Forms.ListView
    Friend WithEvents colAssemblyName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAssemblyVersion As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAssemblyBuilt As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAssemblyCodeBase As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPanelDetails As System.Windows.Forms.TabControl
    Friend WithEvents TabPageApplication As System.Windows.Forms.TabPage
    Friend WithEvents TabPageAssemblies As System.Windows.Forms.TabPage
    Friend WithEvents TabPageAssemblyDetails As System.Windows.Forms.TabPage
    Friend WithEvents AssemblyDetailsListView As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents AssemblyNamesComboBox As System.Windows.Forms.ComboBox
    Private WithEvents OKButton As System.Windows.Forms.Button
    Private WithEvents AppTitleLabel As System.Windows.Forms.Label
    Private WithEvents AppDescriptionLabel As System.Windows.Forms.Label
    Private WithEvents AppVersionLabel As System.Windows.Forms.Label
    Private WithEvents AppCopyrightLabel As System.Windows.Forms.Label
    Private WithEvents SysInfoButton As System.Windows.Forms.Button
    Private WithEvents AppDateLabel As System.Windows.Forms.Label
    Private WithEvents ImagePictureBox As System.Windows.Forms.PictureBox
    Private WithEvents DetailsButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.OKButton = New System.Windows.Forms.Button
        Me.AppTitleLabel = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.AppDescriptionLabel = New System.Windows.Forms.Label
        Me.AppVersionLabel = New System.Windows.Forms.Label
        Me.AppCopyrightLabel = New System.Windows.Forms.Label
        Me.SysInfoButton = New System.Windows.Forms.Button
        Me.AppDateLabel = New System.Windows.Forms.Label
        Me.ImagePictureBox = New System.Windows.Forms.PictureBox
        Me.DetailsButton = New System.Windows.Forms.Button
        Me.MoreRichTextBox = New System.Windows.Forms.RichTextBox
        Me.TabPanelDetails = New System.Windows.Forms.TabControl
        Me.TabPageApplication = New System.Windows.Forms.TabPage
        Me.AppInfoListView = New System.Windows.Forms.ListView
        Me.colKey = New System.Windows.Forms.ColumnHeader
        Me.colValue = New System.Windows.Forms.ColumnHeader
        Me.TabPageAssemblies = New System.Windows.Forms.TabPage
        Me.AssemblyInfoListView = New System.Windows.Forms.ListView
        Me.colAssemblyName = New System.Windows.Forms.ColumnHeader
        Me.colAssemblyVersion = New System.Windows.Forms.ColumnHeader
        Me.colAssemblyBuilt = New System.Windows.Forms.ColumnHeader
        Me.colAssemblyCodeBase = New System.Windows.Forms.ColumnHeader
        Me.TabPageAssemblyDetails = New System.Windows.Forms.TabPage
        Me.AssemblyDetailsListView = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.AssemblyNamesComboBox = New System.Windows.Forms.ComboBox
        CType(Me.ImagePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPanelDetails.SuspendLayout()
        Me.TabPageApplication.SuspendLayout()
        Me.TabPageAssemblies.SuspendLayout()
        Me.TabPageAssemblyDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Location = New System.Drawing.Point(312, 244)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(76, 23)
        Me.OKButton.TabIndex = 1
        Me.OKButton.Text = "OK"
        '
        'AppTitleLabel
        '
        Me.AppTitleLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AppTitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AppTitleLabel.Location = New System.Drawing.Point(60, 8)
        Me.AppTitleLabel.Name = "AppTitleLabel"
        Me.AppTitleLabel.Size = New System.Drawing.Size(326, 16)
        Me.AppTitleLabel.TabIndex = 2
        Me.AppTitleLabel.Text = "%title%"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(378, 2)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'AppDescriptionLabel
        '
        Me.AppDescriptionLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AppDescriptionLabel.Location = New System.Drawing.Point(60, 28)
        Me.AppDescriptionLabel.Name = "AppDescriptionLabel"
        Me.AppDescriptionLabel.Size = New System.Drawing.Size(326, 16)
        Me.AppDescriptionLabel.TabIndex = 4
        Me.AppDescriptionLabel.Text = "%description%"
        '
        'AppVersionLabel
        '
        Me.AppVersionLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AppVersionLabel.Location = New System.Drawing.Point(8, 60)
        Me.AppVersionLabel.Name = "AppVersionLabel"
        Me.AppVersionLabel.Size = New System.Drawing.Size(378, 16)
        Me.AppVersionLabel.TabIndex = 5
        Me.AppVersionLabel.Text = "Version %version%"
        '
        'AppCopyrightLabel
        '
        Me.AppCopyrightLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AppCopyrightLabel.Location = New System.Drawing.Point(8, 100)
        Me.AppCopyrightLabel.Name = "AppCopyrightLabel"
        Me.AppCopyrightLabel.Size = New System.Drawing.Size(378, 16)
        Me.AppCopyrightLabel.TabIndex = 6
        Me.AppCopyrightLabel.Text = "Author: Todd Zimmerman, Information Systems Specialist"
        '
        'SysInfoButton
        '
        Me.SysInfoButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SysInfoButton.Location = New System.Drawing.Point(212, 244)
        Me.SysInfoButton.Name = "SysInfoButton"
        Me.SysInfoButton.Size = New System.Drawing.Size(92, 23)
        Me.SysInfoButton.TabIndex = 7
        Me.SysInfoButton.Text = "&System Info..."
        Me.SysInfoButton.Visible = False
        '
        'AppDateLabel
        '
        Me.AppDateLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AppDateLabel.Location = New System.Drawing.Point(8, 80)
        Me.AppDateLabel.Name = "AppDateLabel"
        Me.AppDateLabel.Size = New System.Drawing.Size(378, 16)
        Me.AppDateLabel.TabIndex = 8
        Me.AppDateLabel.Text = "Built on %builddate%"
        '
        'ImagePictureBox
        '
        Me.ImagePictureBox.Location = New System.Drawing.Point(16, 8)
        Me.ImagePictureBox.Name = "ImagePictureBox"
        Me.ImagePictureBox.Size = New System.Drawing.Size(32, 32)
        Me.ImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImagePictureBox.TabIndex = 9
        Me.ImagePictureBox.TabStop = False
        '
        'DetailsButton
        '
        Me.DetailsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DetailsButton.Location = New System.Drawing.Point(228, 244)
        Me.DetailsButton.Name = "DetailsButton"
        Me.DetailsButton.Size = New System.Drawing.Size(76, 23)
        Me.DetailsButton.TabIndex = 10
        Me.DetailsButton.Text = "&Details >>"
        '
        'MoreRichTextBox
        '
        Me.MoreRichTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MoreRichTextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MoreRichTextBox.Location = New System.Drawing.Point(8, 124)
        Me.MoreRichTextBox.Name = "MoreRichTextBox"
        Me.MoreRichTextBox.ReadOnly = True
        Me.MoreRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.MoreRichTextBox.Size = New System.Drawing.Size(378, 112)
        Me.MoreRichTextBox.TabIndex = 13
        Me.MoreRichTextBox.Text = "%product% is %copyright%"
        '
        'TabPanelDetails
        '
        Me.TabPanelDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabPanelDetails.Controls.Add(Me.TabPageApplication)
        Me.TabPanelDetails.Controls.Add(Me.TabPageAssemblies)
        Me.TabPanelDetails.Controls.Add(Me.TabPageAssemblyDetails)
        Me.TabPanelDetails.Location = New System.Drawing.Point(8, 124)
        Me.TabPanelDetails.Name = "TabPanelDetails"
        Me.TabPanelDetails.SelectedIndex = 0
        Me.TabPanelDetails.Size = New System.Drawing.Size(376, 112)
        Me.TabPanelDetails.TabIndex = 15
        Me.TabPanelDetails.Visible = False
        '
        'TabPageApplication
        '
        Me.TabPageApplication.Controls.Add(Me.AppInfoListView)
        Me.TabPageApplication.Location = New System.Drawing.Point(4, 22)
        Me.TabPageApplication.Name = "TabPageApplication"
        Me.TabPageApplication.Size = New System.Drawing.Size(368, 86)
        Me.TabPageApplication.TabIndex = 0
        Me.TabPageApplication.Text = "Application"
        '
        'AppInfoListView
        '
        Me.AppInfoListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colKey, Me.colValue})
        Me.AppInfoListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AppInfoListView.FullRowSelect = True
        Me.AppInfoListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.AppInfoListView.Location = New System.Drawing.Point(0, 0)
        Me.AppInfoListView.Name = "AppInfoListView"
        Me.AppInfoListView.Size = New System.Drawing.Size(368, 86)
        Me.AppInfoListView.TabIndex = 16
        Me.AppInfoListView.UseCompatibleStateImageBehavior = False
        Me.AppInfoListView.View = System.Windows.Forms.View.Details
        '
        'colKey
        '
        Me.colKey.Text = "Application Key"
        Me.colKey.Width = 120
        '
        'colValue
        '
        Me.colValue.Text = "Value"
        Me.colValue.Width = 700
        '
        'TabPageAssemblies
        '
        Me.TabPageAssemblies.Controls.Add(Me.AssemblyInfoListView)
        Me.TabPageAssemblies.Location = New System.Drawing.Point(4, 22)
        Me.TabPageAssemblies.Name = "TabPageAssemblies"
        Me.TabPageAssemblies.Size = New System.Drawing.Size(368, 86)
        Me.TabPageAssemblies.TabIndex = 1
        Me.TabPageAssemblies.Text = "Assemblies"
        '
        'AssemblyInfoListView
        '
        Me.AssemblyInfoListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colAssemblyName, Me.colAssemblyVersion, Me.colAssemblyBuilt, Me.colAssemblyCodeBase})
        Me.AssemblyInfoListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AssemblyInfoListView.FullRowSelect = True
        Me.AssemblyInfoListView.Location = New System.Drawing.Point(0, 0)
        Me.AssemblyInfoListView.MultiSelect = False
        Me.AssemblyInfoListView.Name = "AssemblyInfoListView"
        Me.AssemblyInfoListView.Size = New System.Drawing.Size(368, 86)
        Me.AssemblyInfoListView.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.AssemblyInfoListView.TabIndex = 13
        Me.AssemblyInfoListView.UseCompatibleStateImageBehavior = False
        Me.AssemblyInfoListView.View = System.Windows.Forms.View.Details
        '
        'colAssemblyName
        '
        Me.colAssemblyName.Text = "Assembly"
        Me.colAssemblyName.Width = 123
        '
        'colAssemblyVersion
        '
        Me.colAssemblyVersion.Text = "Version"
        Me.colAssemblyVersion.Width = 100
        '
        'colAssemblyBuilt
        '
        Me.colAssemblyBuilt.Text = "Built"
        Me.colAssemblyBuilt.Width = 130
        '
        'colAssemblyCodeBase
        '
        Me.colAssemblyCodeBase.Text = "CodeBase"
        Me.colAssemblyCodeBase.Width = 750
        '
        'TabPageAssemblyDetails
        '
        Me.TabPageAssemblyDetails.Controls.Add(Me.AssemblyDetailsListView)
        Me.TabPageAssemblyDetails.Controls.Add(Me.AssemblyNamesComboBox)
        Me.TabPageAssemblyDetails.Location = New System.Drawing.Point(4, 22)
        Me.TabPageAssemblyDetails.Name = "TabPageAssemblyDetails"
        Me.TabPageAssemblyDetails.Size = New System.Drawing.Size(368, 86)
        Me.TabPageAssemblyDetails.TabIndex = 2
        Me.TabPageAssemblyDetails.Text = "Assembly Details"
        '
        'AssemblyDetailsListView
        '
        Me.AssemblyDetailsListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.AssemblyDetailsListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AssemblyDetailsListView.FullRowSelect = True
        Me.AssemblyDetailsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.AssemblyDetailsListView.Location = New System.Drawing.Point(0, 21)
        Me.AssemblyDetailsListView.Name = "AssemblyDetailsListView"
        Me.AssemblyDetailsListView.Size = New System.Drawing.Size(368, 65)
        Me.AssemblyDetailsListView.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.AssemblyDetailsListView.TabIndex = 19
        Me.AssemblyDetailsListView.UseCompatibleStateImageBehavior = False
        Me.AssemblyDetailsListView.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Assembly Key"
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Value"
        Me.ColumnHeader2.Width = 700
        '
        'AssemblyNamesComboBox
        '
        Me.AssemblyNamesComboBox.Dock = System.Windows.Forms.DockStyle.Top
        Me.AssemblyNamesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AssemblyNamesComboBox.Location = New System.Drawing.Point(0, 0)
        Me.AssemblyNamesComboBox.Name = "AssemblyNamesComboBox"
        Me.AssemblyNamesComboBox.Size = New System.Drawing.Size(368, 21)
        Me.AssemblyNamesComboBox.Sorted = True
        Me.AssemblyNamesComboBox.TabIndex = 18
        '
        'frmAbout
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.OKButton
        Me.ClientSize = New System.Drawing.Size(394, 275)
        Me.Controls.Add(Me.DetailsButton)
        Me.Controls.Add(Me.ImagePictureBox)
        Me.Controls.Add(Me.AppDateLabel)
        Me.Controls.Add(Me.SysInfoButton)
        Me.Controls.Add(Me.AppCopyrightLabel)
        Me.Controls.Add(Me.AppVersionLabel)
        Me.Controls.Add(Me.AppDescriptionLabel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.AppTitleLabel)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.MoreRichTextBox)
        Me.Controls.Add(Me.TabPanelDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "About %title%"
        CType(Me.ImagePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPanelDetails.ResumeLayout(False)
        Me.TabPageApplication.ResumeLayout(False)
        Me.TabPageAssemblies.ResumeLayout(False)
        Me.TabPageAssemblyDetails.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _IsPainted As Boolean = False
    Private _strEntryAssemblyName As String
    Private _strCallingAssemblyName As String
    Private _strExecutingAssemblyName As String
    Private _EntryAssembly As System.Reflection.Assembly
    Private _EntryAssemblyAttribCollection As Specialized.NameValueCollection
    Private _intMinWindowHeight As Integer

#Region "Properties"

    ''' <summary>
    ''' Returns the entry assembly for the current application domain
    ''' </summary>
    ''' <remarks>
    ''' This is usually read-only, but in some weird cases (Smart Client apps) 
    ''' you won't have an entry assembly, so you may want to set this manually.
    ''' </remarks>
    Public Property AppEntryAssembly() As System.Reflection.Assembly
        Get
            Return _EntryAssembly
        End Get
        Set(ByVal Value As System.Reflection.Assembly)
            _EntryAssembly = Value
        End Set
    End Property

    ''' <summary>
    ''' single line of text to show in the application title section of the about box dialog
    ''' </summary>
    ''' <remarks>
    ''' defaults to "%title%" 
    ''' %title% = Assembly: AssemblyTitle
    ''' </remarks>
    Public Property AppTitle() As String
        Get
            Return AppTitleLabel.Text
        End Get
        Set(ByVal Value As String)
            AppTitleLabel.Text = Value
        End Set
    End Property

    ''' <summary>
    ''' single line of text to show in the description section of the about box dialog
    ''' </summary>
    ''' <remarks>
    ''' defaults to "%description%"
    ''' %description% = Assembly: AssemblyDescription
    ''' </remarks>
    Public Property AppDescription() As String
        Get
            Return AppDescriptionLabel.Text
        End Get
        Set(ByVal Value As String)
            If Value = "" Then
                AppDescriptionLabel.Visible = False
            Else
                AppDescriptionLabel.Visible = True
                AppDescriptionLabel.Text = Value
            End If
        End Set
    End Property

    ''' <summary>
    ''' single line of text to show in the version section of the about dialog
    ''' </summary>
    ''' <remarks>
    ''' defaults to "Version %version%"
    ''' %version% = Assembly: AssemblyVersion
    ''' </remarks>
    Public Property AppVersion() As String
        Get
            Return AppVersionLabel.Text
        End Get
        Set(ByVal Value As String)
            If Value = "" Then
                AppVersionLabel.Visible = False
            Else
                AppVersionLabel.Visible = True
                AppVersionLabel.Text = Value
            End If
        End Set
    End Property

    ''' <summary>
    ''' single line of text to show in the copyright section of the about dialog
    ''' </summary>
    ''' <remarks>
    ''' defaults to "Copyright © %year%, %company%"
    ''' %company% = Assembly: AssemblyCompany
    ''' %year% = current 4-digit year
    ''' </remarks>
    Public Property AppCopyright() As String
        Get
            Return AppCopyrightLabel.Text
        End Get
        Set(ByVal Value As String)
            If Value = "" Then
                AppCopyrightLabel.Visible = False
            Else
                AppCopyrightLabel.Visible = True
                AppCopyrightLabel.Text = Value
            End If
        End Set
    End Property

    ''' <summary>
    ''' intended for the default 32x32 application icon to appear in the upper left of the about dialog
    ''' </summary>
    ''' <remarks>
    ''' if you open this form using .ShowDialog(Owner), the icon can be derived from the owning form
    ''' </remarks>
    Public Property AppImage() As Image
        Get
            Return ImagePictureBox.Image
        End Get
        Set(ByVal Value As Image)
            ImagePictureBox.Image = Value
        End Set
    End Property

    ''' <summary>
    ''' multiple lines of miscellaneous text to show in rich text box
    ''' </summary>
    ''' <remarks>
    ''' defaults to "%product% is %copyright%, %trademark%"
    ''' %product% = Assembly: AssemblyProduct
    ''' %copyright% = Assembly: AssemblyCopyright
    ''' %trademark% = Assembly: AssemblyTrademark
    ''' </remarks>
    Public Property AppMoreInfo() As String
        Get
            Return MoreRichTextBox.Text
        End Get
        Set(ByVal Value As String)
            If Value = "" Then
                MoreRichTextBox.Visible = False
            Else
                MoreRichTextBox.Visible = True
                MoreRichTextBox.Text = Value
            End If
        End Set
    End Property

    ''' <summary>
    ''' determines if the "Details" (advanced assembly details) button is shown
    ''' </summary>
    Public Property AppDetailsButton() As Boolean
        Get
            Return DetailsButton.Visible
        End Get
        Set(ByVal Value As Boolean)
            DetailsButton.Visible = Value
        End Set
    End Property

#End Region

    ''' <summary>
    ''' exception-safe retrieval of LastWriteTime for this assembly.
    ''' </summary>
    ''' <returns>File.GetLastWriteTime, or DateTime.MaxValue if exception was encountered.</returns>
    Private Shared Function AssemblyLastWriteTime(ByVal a As System.Reflection.Assembly) As DateTime
        Try
            Return File.GetLastWriteTime(a.Location)
        Catch ex As Exception
            Return DateTime.MaxValue
        End Try
    End Function

    ''' <summary>
    ''' Returns DateTime this Assembly was last built. Will attempt to calculate from build number, if possible. 
    ''' If not, the actual LastWriteTime on the assembly file will be returned.
    ''' </summary>
    ''' <param name="a">Assembly to get build date for</param>
    ''' <param name="ForceFileDate">Don't attempt to use the build number to calculate the date</param>
    ''' <returns>DateTime this assembly was last built</returns>
    Private Shared Function AssemblyBuildDate(ByVal a As System.Reflection.Assembly, _
    Optional ByVal ForceFileDate As Boolean = False) As DateTime

        Dim AssemblyVersion As System.Version = a.GetName.Version
        Dim dt As DateTime

        If ForceFileDate Then
            dt = AssemblyLastWriteTime(a)
        Else
            dt = CType("01/01/2000", DateTime). _
            AddDays(AssemblyVersion.Build). _
            AddSeconds(AssemblyVersion.Revision * 2)
            If TimeZone.IsDaylightSavingTime(dt, TimeZone.CurrentTimeZone.GetDaylightChanges(dt.Year)) Then
                dt = dt.AddHours(1)
            End If
            If dt > DateTime.Now Or AssemblyVersion.Build < 730 Or AssemblyVersion.Revision = 0 Then
                dt = AssemblyLastWriteTime(a)
            End If
        End If

        Return dt
    End Function

    ''' <summary>
    ''' returns string name / string value pair of all attribs
    ''' for specified assembly
    ''' </summary>
    ''' <remarks>
    ''' note that Assembly* values are pulled from AssemblyInfo file in project folder
    '''
    ''' Trademark       = AssemblyTrademark string
    ''' Debuggable      = True
    ''' GUID            = 7FDF68D5-8C6F-44C9-B391-117B5AFB5467
    ''' CLSCompliant    = True
    ''' Product         = AssemblyProduct string
    ''' Copyright       = AssemblyCopyright string
    ''' Company         = AssemblyCompany string
    ''' Description     = AssemblyDescription string
    ''' Title           = AssemblyTitle string
    ''' </remarks>
    Private Function AssemblyAttribs(ByVal a As System.Reflection.Assembly) As Specialized.NameValueCollection
        Dim TypeName As String
        Dim Name As String
        Dim Value As String
        Dim nvc As New Specialized.NameValueCollection
        Dim r As New Regex("(\.Assembly|\.)(?<Name>[^.]*)Attribute$", RegexOptions.IgnoreCase)

        For Each attrib As Object In a.GetCustomAttributes(False)
            TypeName = attrib.GetType().ToString
            Name = r.Match(TypeName).Groups("Name").ToString
            Value = ""
            Select Case TypeName
                Case "System.CLSCompliantAttribute"
                    Value = CType(attrib, CLSCompliantAttribute).IsCompliant.ToString
                Case "System.Diagnostics.DebuggableAttribute"
                    Value = CType(attrib, Diagnostics.DebuggableAttribute).IsJITTrackingEnabled.ToString
                Case "System.Reflection.AssemblyCompanyAttribute"
                    Value = CType(attrib, AssemblyCompanyAttribute).Company.ToString
                Case "System.Reflection.AssemblyConfigurationAttribute"
                    Value = CType(attrib, AssemblyConfigurationAttribute).Configuration.ToString
                Case "System.Reflection.AssemblyCopyrightAttribute"
                    Value = CType(attrib, AssemblyCopyrightAttribute).Copyright.ToString
                Case "System.Reflection.AssemblyDefaultAliasAttribute"
                    Value = CType(attrib, AssemblyDefaultAliasAttribute).DefaultAlias.ToString
                Case "System.Reflection.AssemblyDelaySignAttribute"
                    Value = CType(attrib, AssemblyDelaySignAttribute).DelaySign.ToString
                Case "System.Reflection.AssemblyDescriptionAttribute"
                    Value = CType(attrib, AssemblyDescriptionAttribute).Description.ToString
                Case "System.Reflection.AssemblyInformationalVersionAttribute"
                    Value = CType(attrib, AssemblyInformationalVersionAttribute).InformationalVersion.ToString
                Case "System.Reflection.AssemblyKeyFileAttribute"
                    Value = CType(attrib, AssemblyKeyFileAttribute).KeyFile.ToString
                Case "System.Reflection.AssemblyProductAttribute"
                    Value = CType(attrib, AssemblyProductAttribute).Product.ToString
                Case "System.Reflection.AssemblyTrademarkAttribute"
                    Value = CType(attrib, AssemblyTrademarkAttribute).Trademark.ToString
                Case "System.Reflection.AssemblyTitleAttribute"
                    Value = CType(attrib, AssemblyTitleAttribute).Title.ToString
                Case "System.Resources.NeutralResourcesLanguageAttribute"
                    Value = CType(attrib, Resources.NeutralResourcesLanguageAttribute).CultureName.ToString
                Case "System.Resources.SatelliteContractVersionAttribute"
                    Value = CType(attrib, Resources.SatelliteContractVersionAttribute).Version.ToString
                Case "System.Runtime.InteropServices.ComCompatibleVersionAttribute"
                    Dim x As Runtime.InteropServices.ComCompatibleVersionAttribute
                    x = CType(attrib, Runtime.InteropServices.ComCompatibleVersionAttribute)
                    Value = x.MajorVersion & "." & x.MinorVersion & "." & x.RevisionNumber & "." & x.BuildNumber
                Case "System.Runtime.InteropServices.ComVisibleAttribute"
                    Value = CType(attrib, Runtime.InteropServices.ComVisibleAttribute).Value.ToString
                Case "System.Runtime.InteropServices.GuidAttribute"
                    Value = CType(attrib, Runtime.InteropServices.GuidAttribute).Value.ToString
                Case "System.Runtime.InteropServices.TypeLibVersionAttribute"
                    Dim x As Runtime.InteropServices.TypeLibVersionAttribute
                    x = CType(attrib, Runtime.InteropServices.TypeLibVersionAttribute)
                    Value = x.MajorVersion & "." & x.MinorVersion
                Case "System.Security.AllowPartiallyTrustedCallersAttribute"
                    Value = "(Present)"
                Case Else
                    '-- debug.writeline("** unknown assembly attribute '" & TypeName & "'")
                    Value = TypeName
            End Select

            If nvc.Item(Name) = "" Then
                nvc.Add(Name, Value)
            End If
        Next

        '-- add some extra values that are not in the AssemblyInfo, but nice to have
        With nvc
            '-- codebase
            Try
                .Add("CodeBase", a.CodeBase.Replace("file:///", ""))
            Catch ex As System.NotSupportedException
                .Add("CodeBase", "(not supported)")
            End Try
            '-- build date
            Dim dt As DateTime = AssemblyBuildDate(a)
            If dt = DateTime.MaxValue Then
                .Add("BuildDate", "(unknown)")
            Else
                .Add("BuildDate", dt.ToString("yyyy-MM-dd hh:mm tt"))
            End If
            '-- location
            Try
                .Add("Location", a.Location)
            Catch ex As System.NotSupportedException
                .Add("Location", "(not supported)")
            End Try
            '-- version
            Try
                If a.GetName.Version.Major = 0 And a.GetName.Version.Minor = 0 Then
                    .Add("Version", "(unknown)")
                Else
                    .Add("Version", a.GetName.Version.ToString)
                End If
            Catch ex As Exception
                .Add("Version", "(unknown)")
            End Try

            .Add("FullName", a.FullName)
        End With

        Return nvc
    End Function

    ''' <summary>
    ''' reads an HKLM Windows Registry key value
    ''' </summary>
    Private Function RegistryHklmValue(ByVal KeyName As String, ByVal SubKeyRef As String) As String
        Dim rk As RegistryKey
        Try
            rk = Registry.LocalMachine.OpenSubKey(KeyName)
            Return CType(rk.GetValue(SubKeyRef, ""), String)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    ''' <summary>
    ''' launch the MSInfo "system information" application
    ''' </summary>
    Private Sub ShowSysInfo()
        Dim strSysInfoPath As String = ""

        strSysInfoPath = RegistryHklmValue("SOFTWARE\Microsoft\Shared Tools Location", "MSINFO")
        If strSysInfoPath = "" Then
            strSysInfoPath = RegistryHklmValue("SOFTWARE\Microsoft\Shared Tools\MSINFO", "PATH")
        End If

        If strSysInfoPath = "" Then
            MessageBox.Show("System Information is unavailable at this time." & _
            Environment.NewLine & _
            Environment.NewLine & _
            "(couldn't find path for Microsoft System Information Tool in the registry.)", _
            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Process.Start(strSysInfoPath)
        Catch ex As Exception
            MessageBox.Show("System Information is unavailable at this time." & _
            Environment.NewLine & _
            Environment.NewLine & _
            "(couldn't launch '" & strSysInfoPath & "')", _
            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ''' <summary>
    ''' populate a listview with the specified key and value strings
    ''' </summary>
    Private Sub Populate(ByVal lvw As ListView, ByVal Key As String, ByVal Value As String)
        If Value = "" Then Return
        Dim lvi As New Windows.Forms.ListViewItem
        lvi.Text = Key
        lvi.SubItems.Add(Value)
        lvw.Items.Add(lvi)
    End Sub

    ''' <summary>
    ''' populates the Application Information listview
    ''' </summary>
    Private Sub PopulateAppInfo()
        Dim d As System.AppDomain = System.AppDomain.CurrentDomain
        Populate(AppInfoListView, "Application Name", d.SetupInformation.ApplicationName)
        Populate(AppInfoListView, "Application Base", d.SetupInformation.ApplicationBase)
        Populate(AppInfoListView, "Cache Path", d.SetupInformation.CachePath)
        Populate(AppInfoListView, "Configuration File", d.SetupInformation.ConfigurationFile)
        Populate(AppInfoListView, "Dynamic Base", d.SetupInformation.DynamicBase)
        Populate(AppInfoListView, "Friendly Name", d.FriendlyName)
        Populate(AppInfoListView, "License File", d.SetupInformation.LicenseFile)
        Populate(AppInfoListView, "Private Bin Path", d.SetupInformation.PrivateBinPath)
        Populate(AppInfoListView, "Shadow Copy Directories", d.SetupInformation.ShadowCopyDirectories)
        Populate(AppInfoListView, " ", " ")
        Populate(AppInfoListView, "Entry Assembly", _strEntryAssemblyName)
        Populate(AppInfoListView, "Executing Assembly", _strExecutingAssemblyName)
        Populate(AppInfoListView, "Calling Assembly", _strCallingAssemblyName)
    End Sub

    ''' <summary>
    ''' populate Assembly Information listview with ALL assemblies
    ''' </summary>
    Private Sub PopulateAssemblies()
        For Each a As [Assembly] In AppDomain.CurrentDomain.GetAssemblies
            PopulateAssemblySummary(a)
        Next
        AssemblyNamesComboBox.SelectedIndex = AssemblyNamesComboBox.FindStringExact(_strEntryAssemblyName)
    End Sub

    ''' <summary>
    ''' populate Assembly Information listview with summary view for a specific assembly
    ''' </summary>
    Private Sub PopulateAssemblySummary(ByVal a As [Assembly])
        Dim nvc As Specialized.NameValueCollection = AssemblyAttribs(a)

        Dim strAssemblyName As String = a.GetName.Name

        Dim lvi As New Windows.Forms.ListViewItem
        With lvi
            .Text = strAssemblyName
            .Tag = strAssemblyName
            If strAssemblyName = _strCallingAssemblyName Then
                .Text &= " (calling)"
            End If
            If strAssemblyName = _strExecutingAssemblyName Then
                .Text &= " (executing)"
            End If
            If strAssemblyName = _strEntryAssemblyName Then
                .Text &= " (entry)"
            End If
            .SubItems.Add(nvc.Item("version"))
            .SubItems.Add(nvc.Item("builddate"))
            .SubItems.Add(nvc.Item("codebase"))
            '.SubItems.Add(AssemblyVersion(a))
            '.SubItems.Add(AssemblyBuildDateString(a, True))
            '.SubItems.Add(AssemblyCodeBase(a))
        End With
        AssemblyInfoListView.Items.Add(lvi)
        AssemblyNamesComboBox.Items.Add(strAssemblyName)
    End Sub

    ''' <summary>
    ''' retrieves a cached value from the entry assembly attribute lookup collection
    ''' </summary>
    Private Function EntryAssemblyAttrib(ByVal strName As String) As String
        If _EntryAssemblyAttribCollection(strName) = "" Then
            Return "<Assembly: Assembly" & strName & "("""")>"
        Else
            Return _EntryAssemblyAttribCollection(strName).ToString
        End If
    End Function

    ''' <summary>
    ''' Populate all the form labels with tokenized text
    ''' </summary>
    Private Sub PopulateLabels()
        '-- get entry assembly attribs
        _EntryAssemblyAttribCollection = AssemblyAttribs(_EntryAssembly)

        '-- set icon from parent, if present
        If Me.Owner Is Nothing Then
            ImagePictureBox.Visible = False
            AppTitleLabel.Left = AppCopyrightLabel.Left
            AppDescriptionLabel.Left = AppCopyrightLabel.Left
        Else
            Me.Icon = Me.Owner.Icon
            ImagePictureBox.Image = Me.Icon.ToBitmap
        End If

        '-- replace all labels and window title
        Me.Text = ReplaceTokens(Me.Text)
        AppTitleLabel.Text = ReplaceTokens(AppTitleLabel.Text)
        If AppDescriptionLabel.Visible Then
            AppDescriptionLabel.Text = ReplaceTokens(AppDescriptionLabel.Text)
        End If
        If AppCopyrightLabel.Visible Then
            AppCopyrightLabel.Text = ReplaceTokens(AppCopyrightLabel.Text)
        End If
        If AppVersionLabel.Visible Then
            AppVersionLabel.Text = ReplaceTokens(AppVersionLabel.Text)
        End If
        If AppDateLabel.Visible Then
            AppDateLabel.Text = ReplaceTokens(AppDateLabel.Text)
        End If
        If MoreRichTextBox.Visible Then
            MoreRichTextBox.Text = ReplaceTokens(MoreRichTextBox.Text)
        End If
    End Sub

    ''' <summary>
    ''' perform assemblyinfo to string replacements on labels
    ''' </summary>
    Private Function ReplaceTokens(ByVal s As String) As String
        s = s.Replace("%title%", EntryAssemblyAttrib("title"))
        s = s.Replace("%copyright%", EntryAssemblyAttrib("copyright"))
        s = s.Replace("%description%", EntryAssemblyAttrib("description"))
        s = s.Replace("%company%", EntryAssemblyAttrib("company"))
        s = s.Replace("%product%", EntryAssemblyAttrib("product"))
        s = s.Replace("%trademark%", EntryAssemblyAttrib("trademark"))
        s = s.Replace("%year%", DateTime.Now.Year.ToString)
        s = s.Replace("%version%", EntryAssemblyAttrib("version"))
        s = s.Replace("%builddate%", EntryAssemblyAttrib("builddate"))
        Return s
    End Function

    ''' <summary>
    ''' populate details for a single assembly
    ''' </summary>
    Private Function PopulateAssemblyDetails(ByVal a As System.Reflection.Assembly, ByVal lvw As ListView) As String
        lvw.Items.Clear()

        '-- this assembly property is only available in framework versions 1.1+
        Populate(lvw, "Image Runtime Version", a.ImageRuntimeVersion)
        Populate(lvw, "Loaded from GAC", a.GlobalAssemblyCache.ToString)

        Dim nvc As Specialized.NameValueCollection = AssemblyAttribs(a)
        For Each strKey As String In nvc
            Populate(lvw, strKey, nvc.Item(strKey))
        Next

        Return ""

    End Function

    ''' <summary>
    ''' matches assembly by Assembly.GetName.Name; returns nothing if no match
    ''' </summary>
    Private Function MatchAssemblyByName(ByVal AssemblyName As String) As [Assembly]
        For Each a As [Assembly] In AppDomain.CurrentDomain.GetAssemblies
            If a.GetName.Name = AssemblyName Then
                Return a
                Exit For
            End If
        Next

        Return Nothing

    End Function

    ''' <summary>
    ''' things to do when form is loaded
    ''' </summary>
    Private Sub AboutBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '-- if the user didn't provide an assembly, try to guess which one is 
        '-- the entry assembly
        If _EntryAssembly Is Nothing Then
            _EntryAssembly = [Assembly].GetEntryAssembly
        End If
        If _EntryAssembly Is Nothing Then
            _EntryAssembly = [Assembly].GetExecutingAssembly
        End If

        _strExecutingAssemblyName = [Assembly].GetExecutingAssembly.GetName.Name
        _strCallingAssemblyName = [Assembly].GetCallingAssembly.GetName.Name
        Try
            '-- for web hosted apps, GetEntryAssembly = nothing
            _strEntryAssemblyName = [Assembly].GetEntryAssembly.GetName.Name
        Catch ex As Exception
        End Try

        _intMinWindowHeight = AppCopyrightLabel.Top + AppCopyrightLabel.Height + OKButton.Height + 30

        Me.TabPanelDetails.Visible = False
        If Not MoreRichTextBox.Visible Then
            Me.Height = Me.Height - MoreRichTextBox.Height
        End If

    End Sub

    ''' <summary>
    ''' things to do when form is FIRST painted
    ''' </summary>
    Private Sub AboutBox_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If Not _IsPainted Then
            _IsPainted = True
            Application.DoEvents()
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            PopulateLabels()
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    ''' <summary>
    ''' expand about dialog to show additional advanced details
    ''' </summary>
    Private Sub DetailsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailsButton.Click
        Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        DetailsButton.Visible = False
        Me.SuspendLayout()
        Me.MaximizeBox = True
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        Me.SizeGripStyle = Windows.Forms.SizeGripStyle.Show
        Me.Size = New Size(580, Me.Size.Height + 200)
        MoreRichTextBox.Visible = False
        TabPanelDetails.Visible = True
        SysInfoButton.Visible = True
        PopulateAssemblies()
        PopulateAppInfo()
        Me.CenterToParent()
        Me.ResumeLayout()
        Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    ''' <summary>
    ''' for detailed system info, launch the external Microsoft system info app
    ''' </summary>
    Private Sub SysInfoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SysInfoButton.Click
        ShowSysInfo()
    End Sub

    ''' <summary>
    ''' if an assembly is double-clicked, go to the detail page for that assembly
    ''' </summary>
    Private Sub AssemblyInfoListView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles AssemblyInfoListView.DoubleClick
        Dim strAssemblyName As String
        If AssemblyInfoListView.SelectedItems.Count > 0 Then
            strAssemblyName = Convert.ToString(AssemblyInfoListView.SelectedItems(0).Tag)
            AssemblyNamesComboBox.SelectedIndex = AssemblyNamesComboBox.FindStringExact(strAssemblyName)
            Me.TabPanelDetails.SelectedTab = Me.TabPageAssemblyDetails
        End If
    End Sub

    ''' <summary>
    ''' if a new assembly is selected from the combo box, show details for that assembly
    ''' </summary>
    Private Sub AssemblyNamesComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AssemblyNamesComboBox.SelectedIndexChanged
        Dim strAssemblyName As String = Convert.ToString(AssemblyNamesComboBox.SelectedItem)
        PopulateAssemblyDetails(MatchAssemblyByName(strAssemblyName), AssemblyDetailsListView)
    End Sub

    ''' <summary>
    ''' sort the assembly list by column
    ''' </summary>
    Private Sub AssemblyInfoListView_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles AssemblyInfoListView.ColumnClick
        Dim intTargetCol As Integer = e.Column + 1

        If Not AssemblyInfoListView.Tag Is Nothing Then
            If Math.Abs(Convert.ToInt32(AssemblyInfoListView.Tag)) = intTargetCol Then
                intTargetCol = -Convert.ToInt32(AssemblyInfoListView.Tag)
            End If
        End If

        AssemblyInfoListView.Tag = intTargetCol
        AssemblyInfoListView.ListViewItemSorter = New ListViewItemComparer(intTargetCol)
    End Sub

    ''' <summary>
    ''' launch any http:// or mailto: links clicked in the body of the rich text box
    ''' </summary>
    Private Sub MoreRichTextBox_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles MoreRichTextBox.LinkClicked
        Try
            Process.Start(e.LinkText)
        Catch ex As Exception
        End Try
    End Sub

#Region "  ListViewItemComparer Class"

    Class ListViewItemComparer
        Implements IComparer

        Private _intCol As Integer
        Private _IsAscending As Boolean = True

        Public Sub New()
            _intCol = 0
            _IsAscending = True
        End Sub

        Public Sub New(ByVal column As Integer, Optional ByVal ascending As Boolean = True)
            If column < 0 Then
                _IsAscending = False
            Else
                _IsAscending = ascending
            End If
            _intCol = Math.Abs(column) - 1
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Dim intResult As Integer = _
            [String].Compare(CType(x, ListViewItem).SubItems(_intCol).Text, _
            CType(y, ListViewItem).SubItems(_intCol).Text)

            If _IsAscending Then
                Return intResult
            Else
                Return -intResult
            End If
        End Function
    End Class
#End Region

    ''' <summary>
    ''' things to do when the selected tab is changed
    ''' </summary>
    Private Sub TabPanelDetails_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPanelDetails.SelectedIndexChanged
        If TabPanelDetails.SelectedTab Is Me.TabPageAssemblyDetails Then
            AssemblyNamesComboBox.Focus()
        End If
    End Sub

End Class