<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogonHistory
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LogonHistory))
        Me.dgvUserHistory = New System.Windows.Forms.DataGridView()
        Me.UserName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserEvent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComputerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.logTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IPAddresses = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lastrebooted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RAM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComputerManufacturer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComputerModel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CPU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FreeSpace = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ServiceTag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnGetUser = New System.Windows.Forms.Button()
        Me.btnShadow = New System.Windows.Forms.Button()
        Me.btnRcontrol = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsrCount = New System.Windows.Forms.Label()
        Me.tbxFindString = New System.Windows.Forms.TextBox()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.OpenFileDialogExport = New System.Windows.Forms.OpenFileDialog()
        Me.TextBoxExportFilename = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBoxnukeWallpaper = New System.Windows.Forms.CheckBox()
        Me.CheckBoxNpad = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBoxStatus = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ButtonFilter = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckBoxTodayOnly = New System.Windows.Forms.CheckBox()
        Me.CheckBoxColorCode = New System.Windows.Forms.CheckBox()
        CType(Me.dgvUserHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvUserHistory
        '
        Me.dgvUserHistory.AllowUserToAddRows = False
        Me.dgvUserHistory.AllowUserToDeleteRows = False
        Me.dgvUserHistory.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvUserHistory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvUserHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUserHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvUserHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUserHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UserName, Me.UserEvent, Me.ComputerName, Me.logTime, Me.IPAddresses, Me.Lastrebooted, Me.RAM, Me.ComputerManufacturer, Me.ComputerModel, Me.CPU, Me.FreeSpace, Me.ServiceTag, Me.OS, Me.DC})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvUserHistory.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvUserHistory.Location = New System.Drawing.Point(4, 30)
        Me.dgvUserHistory.MultiSelect = False
        Me.dgvUserHistory.Name = "dgvUserHistory"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUserHistory.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvUserHistory.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUserHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUserHistory.Size = New System.Drawing.Size(1278, 650)
        Me.dgvUserHistory.TabIndex = 0
        '
        'UserName
        '
        Me.UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.UserName.HeaderText = "User Name"
        Me.UserName.MinimumWidth = 100
        Me.UserName.Name = "UserName"
        Me.UserName.ReadOnly = True
        '
        'UserEvent
        '
        Me.UserEvent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.UserEvent.HeaderText = "User Event"
        Me.UserEvent.MinimumWidth = 80
        Me.UserEvent.Name = "UserEvent"
        Me.UserEvent.ReadOnly = True
        '
        'ComputerName
        '
        Me.ComputerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ComputerName.HeaderText = "Computer Name"
        Me.ComputerName.MinimumWidth = 133
        Me.ComputerName.Name = "ComputerName"
        '
        'logTime
        '
        Me.logTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.logTime.HeaderText = "Time Of Log Off/On"
        Me.logTime.MinimumWidth = 133
        Me.logTime.Name = "logTime"
        Me.logTime.ReadOnly = True
        '
        'IPAddresses
        '
        Me.IPAddresses.HeaderText = "IP Addresses"
        Me.IPAddresses.MinimumWidth = 133
        Me.IPAddresses.Name = "IPAddresses"
        Me.IPAddresses.Width = 133
        '
        'Lastrebooted
        '
        Me.Lastrebooted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Lastrebooted.HeaderText = "Computer Last Rebooted on"
        Me.Lastrebooted.MinimumWidth = 133
        Me.Lastrebooted.Name = "Lastrebooted"
        Me.Lastrebooted.ReadOnly = True
        '
        'RAM
        '
        Me.RAM.HeaderText = "RAM"
        Me.RAM.MinimumWidth = 80
        Me.RAM.Name = "RAM"
        Me.RAM.Width = 80
        '
        'ComputerManufacturer
        '
        Me.ComputerManufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ComputerManufacturer.HeaderText = "Computer Manufacturer"
        Me.ComputerManufacturer.MinimumWidth = 133
        Me.ComputerManufacturer.Name = "ComputerManufacturer"
        '
        'ComputerModel
        '
        Me.ComputerModel.HeaderText = "Computer Model"
        Me.ComputerModel.MinimumWidth = 80
        Me.ComputerModel.Name = "ComputerModel"
        Me.ComputerModel.Width = 102
        '
        'CPU
        '
        Me.CPU.HeaderText = "CPU"
        Me.CPU.MinimumWidth = 100
        Me.CPU.Name = "CPU"
        '
        'FreeSpace
        '
        Me.FreeSpace.HeaderText = "C: FreeSpace in GB"
        Me.FreeSpace.MinimumWidth = 50
        Me.FreeSpace.Name = "FreeSpace"
        '
        'ServiceTag
        '
        Me.ServiceTag.HeaderText = "ServiceTag"
        Me.ServiceTag.MinimumWidth = 70
        Me.ServiceTag.Name = "ServiceTag"
        '
        'OS
        '
        Me.OS.HeaderText = "OS"
        Me.OS.Name = "OS"
        '
        'DC
        '
        Me.DC.HeaderText = "DC"
        Me.DC.Name = "DC"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(1199, 709)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRefresh.Location = New System.Drawing.Point(1199, 685)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 3
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnGetUser
        '
        Me.btnGetUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGetUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnGetUser.Location = New System.Drawing.Point(1106, 685)
        Me.btnGetUser.Name = "btnGetUser"
        Me.btnGetUser.Size = New System.Drawing.Size(87, 23)
        Me.btnGetUser.TabIndex = 4
        Me.btnGetUser.Text = "Display User"
        Me.btnGetUser.UseVisualStyleBackColor = False
        '
        'btnShadow
        '
        Me.btnShadow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShadow.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnShadow.Location = New System.Drawing.Point(725, 686)
        Me.btnShadow.Name = "btnShadow"
        Me.btnShadow.Size = New System.Drawing.Size(75, 23)
        Me.btnShadow.TabIndex = 5
        Me.btnShadow.Text = "Shadow"
        Me.btnShadow.UseVisualStyleBackColor = False
        '
        'btnRcontrol
        '
        Me.btnRcontrol.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRcontrol.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnRcontrol.Location = New System.Drawing.Point(873, 701)
        Me.btnRcontrol.Name = "btnRcontrol"
        Me.btnRcontrol.Size = New System.Drawing.Size(95, 23)
        Me.btnRcontrol.TabIndex = 6
        Me.btnRcontrol.Text = "RemoteControl"
        Me.btnRcontrol.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 690)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Entry Count"
        '
        'txtUsrCount
        '
        Me.txtUsrCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtUsrCount.AutoSize = True
        Me.txtUsrCount.Location = New System.Drawing.Point(12, 709)
        Me.txtUsrCount.Name = "txtUsrCount"
        Me.txtUsrCount.Size = New System.Drawing.Size(10, 13)
        Me.txtUsrCount.TabIndex = 11
        Me.txtUsrCount.Text = "-"
        '
        'tbxFindString
        '
        Me.tbxFindString.Location = New System.Drawing.Point(93, 4)
        Me.tbxFindString.Name = "tbxFindString"
        Me.tbxFindString.Size = New System.Drawing.Size(100, 20)
        Me.tbxFindString.TabIndex = 1
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(12, 2)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(75, 23)
        Me.btnFind.TabIndex = 2
        Me.btnFind.Text = "Find"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(914, 2)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.TabIndex = 12
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'OpenFileDialogExport
        '
        Me.OpenFileDialogExport.FileName = "OpenFileDialog1"
        '
        'TextBoxExportFilename
        '
        Me.TextBoxExportFilename.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxExportFilename.Location = New System.Drawing.Point(1084, 5)
        Me.TextBoxExportFilename.Name = "TextBoxExportFilename"
        Me.TextBoxExportFilename.Size = New System.Drawing.Size(188, 20)
        Me.TextBoxExportFilename.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(995, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "To File name -->"
        '
        'CheckBoxnukeWallpaper
        '
        Me.CheckBoxnukeWallpaper.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxnukeWallpaper.AutoSize = True
        Me.CheckBoxnukeWallpaper.Location = New System.Drawing.Point(974, 697)
        Me.CheckBoxnukeWallpaper.Name = "CheckBoxnukeWallpaper"
        Me.CheckBoxnukeWallpaper.Size = New System.Drawing.Size(115, 17)
        Me.CheckBoxnukeWallpaper.TabIndex = 15
        Me.CheckBoxnukeWallpaper.Text = "RemoveWallPaper"
        Me.CheckBoxnukeWallpaper.UseVisualStyleBackColor = True
        '
        'CheckBoxNpad
        '
        Me.CheckBoxNpad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxNpad.AutoSize = True
        Me.CheckBoxNpad.Location = New System.Drawing.Point(974, 715)
        Me.CheckBoxNpad.Name = "CheckBoxNpad"
        Me.CheckBoxNpad.Size = New System.Drawing.Size(117, 17)
        Me.CheckBoxNpad.TabIndex = 16
        Me.CheckBoxNpad.Text = "NotepadFullScreen"
        Me.CheckBoxNpad.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(806, 710)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 23)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Ping"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(806, 686)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(61, 23)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "c$"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(725, 711)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Manage"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TextBoxStatus
        '
        Me.TextBoxStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBoxStatus.Location = New System.Drawing.Point(255, 4)
        Me.TextBoxStatus.Name = "TextBoxStatus"
        Me.TextBoxStatus.Size = New System.Drawing.Size(653, 20)
        Me.TextBoxStatus.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(200, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Status ->"
        '
        'ButtonFilter
        '
        Me.ButtonFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFilter.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonFilter.Location = New System.Drawing.Point(1106, 709)
        Me.ButtonFilter.Name = "ButtonFilter"
        Me.ButtonFilter.Size = New System.Drawing.Size(87, 23)
        Me.ButtonFilter.TabIndex = 22
        Me.ButtonFilter.Text = "Filter"
        Me.ButtonFilter.UseVisualStyleBackColor = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(96, 26)
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(95, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'CheckBoxTodayOnly
        '
        Me.CheckBoxTodayOnly.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxTodayOnly.AutoSize = True
        Me.CheckBoxTodayOnly.Location = New System.Drawing.Point(77, 689)
        Me.CheckBoxTodayOnly.Name = "CheckBoxTodayOnly"
        Me.CheckBoxTodayOnly.Size = New System.Drawing.Size(172, 17)
        Me.CheckBoxTodayOnly.TabIndex = 23
        Me.CheckBoxTodayOnly.Text = "Show Events From Today Only"
        Me.CheckBoxTodayOnly.UseVisualStyleBackColor = True
        '
        'CheckBoxColorCode
        '
        Me.CheckBoxColorCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxColorCode.AutoSize = True
        Me.CheckBoxColorCode.Location = New System.Drawing.Point(255, 689)
        Me.CheckBoxColorCode.Name = "CheckBoxColorCode"
        Me.CheckBoxColorCode.Size = New System.Drawing.Size(84, 17)
        Me.CheckBoxColorCode.TabIndex = 24
        Me.CheckBoxColorCode.Text = "Color Code?"
        Me.CheckBoxColorCode.UseVisualStyleBackColor = True
        '
        'LogonHistory
        '
        Me.AcceptButton = Me.btnFind
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1284, 736)
        Me.Controls.Add(Me.ButtonFilter)
        Me.Controls.Add(Me.CheckBoxColorCode)
        Me.Controls.Add(Me.CheckBoxTodayOnly)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxStatus)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CheckBoxNpad)
        Me.Controls.Add(Me.CheckBoxnukeWallpaper)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxExportFilename)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.tbxFindString)
        Me.Controls.Add(Me.txtUsrCount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnRcontrol)
        Me.Controls.Add(Me.btnShadow)
        Me.Controls.Add(Me.btnGetUser)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dgvUserHistory)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LogonHistory"
        Me.Text = "LogonHistory - SWIFT"
        CType(Me.dgvUserHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvUserHistory As System.Windows.Forms.DataGridView
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnGetUser As System.Windows.Forms.Button
    Friend WithEvents btnShadow As System.Windows.Forms.Button
    Friend WithEvents btnRcontrol As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUsrCount As System.Windows.Forms.Label
    Friend WithEvents tbxFindString As System.Windows.Forms.TextBox
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialogExport As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TextBoxExportFilename As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxnukeWallpaper As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxNpad As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TextBoxStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents UserName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserEvent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComputerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents logTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IPAddresses As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lastrebooted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RAM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComputerManufacturer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComputerModel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CPU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreeSpace As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServiceTag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ButtonFilter As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckBoxTodayOnly As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxColorCode As System.Windows.Forms.CheckBox
End Class
