<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CCMPopUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CCMPopUp))
        Me.TextBoxTheMessage = New System.Windows.Forms.TextBox()
        Me.ButtonSend = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxTitle = New System.Windows.Forms.TextBox()
        Me.ButtonPrevue = New System.Windows.Forms.Button()
        Me.ButtonExit = New System.Windows.Forms.Button()
        Me.ComboBoxType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvComputerList = New System.Windows.Forms.DataGridView()
        Me.msg = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Computer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Online = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtCount = New System.Windows.Forms.Label()
        Me.ButtonFind = New System.Windows.Forms.Button()
        Me.ButtonCheckAll = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LabelComputers = New System.Windows.Forms.Label()
        Me.deleteOfflineComputers = New System.Windows.Forms.Button()
        Me.pingTimeout = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.dgvComputerList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pingTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBoxTheMessage
        '
        Me.TextBoxTheMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxTheMessage.Location = New System.Drawing.Point(60, 29)
        Me.TextBoxTheMessage.Multiline = True
        Me.TextBoxTheMessage.Name = "TextBoxTheMessage"
        Me.TextBoxTheMessage.Size = New System.Drawing.Size(507, 144)
        Me.TextBoxTheMessage.TabIndex = 2
        '
        'ButtonSend
        '
        Me.ButtonSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonSend.Location = New System.Drawing.Point(576, 30)
        Me.ButtonSend.Name = "ButtonSend"
        Me.ButtonSend.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSend.TabIndex = 7
        Me.ButtonSend.Text = "Send"
        Me.ButtonSend.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Title"
        '
        'TextBoxTitle
        '
        Me.TextBoxTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxTitle.Location = New System.Drawing.Point(60, 3)
        Me.TextBoxTitle.Name = "TextBoxTitle"
        Me.TextBoxTitle.Size = New System.Drawing.Size(340, 20)
        Me.TextBoxTitle.TabIndex = 1
        '
        'ButtonPrevue
        '
        Me.ButtonPrevue.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonPrevue.Location = New System.Drawing.Point(576, 1)
        Me.ButtonPrevue.Name = "ButtonPrevue"
        Me.ButtonPrevue.Size = New System.Drawing.Size(75, 23)
        Me.ButtonPrevue.TabIndex = 4
        Me.ButtonPrevue.Text = "PreVue"
        Me.ButtonPrevue.UseVisualStyleBackColor = True
        '
        'ButtonExit
        '
        Me.ButtonExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonExit.Location = New System.Drawing.Point(576, 496)
        Me.ButtonExit.Name = "ButtonExit"
        Me.ButtonExit.Size = New System.Drawing.Size(75, 23)
        Me.ButtonExit.TabIndex = 5
        Me.ButtonExit.TabStop = False
        Me.ButtonExit.Text = "Exit"
        Me.ButtonExit.UseVisualStyleBackColor = True
        '
        'ComboBoxType
        '
        Me.ComboBoxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxType.FormattingEnabled = True
        Me.ComboBoxType.Items.AddRange(New Object() {"Information", "Exclaimation", "Error", "Question"})
        Me.ComboBoxType.Location = New System.Drawing.Point(446, 3)
        Me.ComboBoxType.Name = "ComboBoxType"
        Me.ComboBoxType.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxType.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(406, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Type:"
        '
        'dgvComputerList
        '
        Me.dgvComputerList.AllowUserToAddRows = False
        Me.dgvComputerList.AllowUserToDeleteRows = False
        Me.dgvComputerList.AllowUserToResizeRows = False
        Me.dgvComputerList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvComputerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvComputerList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.msg, Me.Computer, Me.Online, Me.ADLocation, Me.Sent})
        Me.dgvComputerList.Location = New System.Drawing.Point(60, 188)
        Me.dgvComputerList.Name = "dgvComputerList"
        Me.dgvComputerList.Size = New System.Drawing.Size(591, 302)
        Me.dgvComputerList.TabIndex = 9
        '
        'msg
        '
        Me.msg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.msg.HeaderText = "msg"
        Me.msg.Name = "msg"
        Me.msg.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.msg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.msg.Width = 51
        '
        'Computer
        '
        Me.Computer.HeaderText = "Computer"
        Me.Computer.Name = "Computer"
        '
        'Online
        '
        Me.Online.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Online.HeaderText = "Online"
        Me.Online.Name = "Online"
        Me.Online.Width = 62
        '
        'ADLocation
        '
        Me.ADLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ADLocation.HeaderText = "ADLocation"
        Me.ADLocation.Name = "ADLocation"
        '
        'Sent
        '
        Me.Sent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Sent.HeaderText = "Sent"
        Me.Sent.Name = "Sent"
        Me.Sent.Width = 54
        '
        'txtCount
        '
        Me.txtCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCount.AutoSize = True
        Me.txtCount.Location = New System.Drawing.Point(57, 493)
        Me.txtCount.Name = "txtCount"
        Me.txtCount.Size = New System.Drawing.Size(60, 13)
        Me.txtCount.TabIndex = 10
        Me.txtCount.Text = "Computers:"
        '
        'ButtonFind
        '
        Me.ButtonFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonFind.Location = New System.Drawing.Point(576, 159)
        Me.ButtonFind.Name = "ButtonFind"
        Me.ButtonFind.Size = New System.Drawing.Size(75, 23)
        Me.ButtonFind.TabIndex = 5
        Me.ButtonFind.Text = "Find"
        Me.ButtonFind.UseVisualStyleBackColor = True
        '
        'ButtonCheckAll
        '
        Me.ButtonCheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCheckAll.Location = New System.Drawing.Point(495, 496)
        Me.ButtonCheckAll.Name = "ButtonCheckAll"
        Me.ButtonCheckAll.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCheckAll.TabIndex = 6
        Me.ButtonCheckAll.Text = "Check All"
        Me.ButtonCheckAll.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Message"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(-3, 188)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Computers"
        '
        'LabelComputers
        '
        Me.LabelComputers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelComputers.AutoSize = True
        Me.LabelComputers.Location = New System.Drawing.Point(123, 493)
        Me.LabelComputers.Name = "LabelComputers"
        Me.LabelComputers.Size = New System.Drawing.Size(10, 13)
        Me.LabelComputers.TabIndex = 15
        Me.LabelComputers.Text = "-"
        '
        'deleteOfflineComputers
        '
        Me.deleteOfflineComputers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.deleteOfflineComputers.BackColor = System.Drawing.Color.Fuchsia
        Me.deleteOfflineComputers.Location = New System.Drawing.Point(347, 496)
        Me.deleteOfflineComputers.Name = "deleteOfflineComputers"
        Me.deleteOfflineComputers.Size = New System.Drawing.Size(142, 23)
        Me.deleteOfflineComputers.TabIndex = 17
        Me.deleteOfflineComputers.Text = "Remove Offline Computers"
        Me.deleteOfflineComputers.UseVisualStyleBackColor = False
        Me.deleteOfflineComputers.Visible = False
        '
        'pingTimeout
        '
        Me.pingTimeout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pingTimeout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pingTimeout.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.pingTimeout.Location = New System.Drawing.Point(576, 133)
        Me.pingTimeout.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.pingTimeout.Minimum = New Decimal(New Integer() {250, 0, 0, 0})
        Me.pingTimeout.Name = "pingTimeout"
        Me.pingTimeout.Size = New System.Drawing.Size(75, 20)
        Me.pingTimeout.TabIndex = 18
        Me.pingTimeout.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(573, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Timeout (ms):"
        '
        'CCMPopUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonExit
        Me.ClientSize = New System.Drawing.Size(667, 520)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.pingTimeout)
        Me.Controls.Add(Me.deleteOfflineComputers)
        Me.Controls.Add(Me.LabelComputers)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ButtonCheckAll)
        Me.Controls.Add(Me.ButtonFind)
        Me.Controls.Add(Me.txtCount)
        Me.Controls.Add(Me.dgvComputerList)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBoxType)
        Me.Controls.Add(Me.ButtonExit)
        Me.Controls.Add(Me.ButtonPrevue)
        Me.Controls.Add(Me.TextBoxTitle)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ButtonSend)
        Me.Controls.Add(Me.TextBoxTheMessage)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(500, 400)
        Me.Name = "CCMPopUp"
        Me.Text = "Super Popups"
        CType(Me.dgvComputerList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pingTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxTheMessage As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSend As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTitle As System.Windows.Forms.TextBox
    Friend WithEvents ButtonPrevue As System.Windows.Forms.Button
    Friend WithEvents ButtonExit As System.Windows.Forms.Button
    Friend WithEvents ComboBoxType As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvComputerList As System.Windows.Forms.DataGridView
    Friend WithEvents txtCount As System.Windows.Forms.Label
    Friend WithEvents ButtonFind As System.Windows.Forms.Button
    Friend WithEvents ButtonCheckAll As System.Windows.Forms.Button
    Friend WithEvents msg As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Computer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Online As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ADLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LabelComputers As System.Windows.Forms.Label
    Friend WithEvents deleteOfflineComputers As System.Windows.Forms.Button
    Friend WithEvents pingTimeout As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
