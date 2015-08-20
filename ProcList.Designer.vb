<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProcList
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProcList))
        Me.dgvProcList = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnKill = New System.Windows.Forms.Button
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.tbxRefresh = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Process = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PercentUage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MemUsage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProcPath = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvProcList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvProcList
        '
        Me.dgvProcList.AllowUserToOrderColumns = True
        Me.dgvProcList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProcList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProcList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Process, Me.PID, Me.PercentUage, Me.MemUsage, Me.ProcPath})
        Me.dgvProcList.Location = New System.Drawing.Point(12, 12)
        Me.dgvProcList.Name = "dgvProcList"
        Me.dgvProcList.Size = New System.Drawing.Size(685, 325)
        Me.dgvProcList.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(627, 344)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnKill
        '
        Me.btnKill.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKill.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnKill.Location = New System.Drawing.Point(501, 344)
        Me.btnKill.Name = "btnKill"
        Me.btnKill.Size = New System.Drawing.Size(120, 23)
        Me.btnKill.TabIndex = 2
        Me.btnKill.Text = "Kill That Process"
        Me.btnKill.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnRefresh.Location = New System.Drawing.Point(420, 344)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 3
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'tbxRefresh
        '
        Me.tbxRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxRefresh.Location = New System.Drawing.Point(294, 346)
        Me.tbxRefresh.Name = "tbxRefresh"
        Me.tbxRefresh.Size = New System.Drawing.Size(120, 20)
        Me.tbxRefresh.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(209, 350)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "MachineName:"
        '
        'Process
        '
        Me.Process.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Process.DefaultCellStyle = DataGridViewCellStyle1
        Me.Process.HeaderText = "Process"
        Me.Process.Name = "Process"
        Me.Process.ReadOnly = True
        Me.Process.Width = 70
        '
        'PID
        '
        Me.PID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PID.DefaultCellStyle = DataGridViewCellStyle2
        Me.PID.HeaderText = "Process ID (PID)"
        Me.PID.Name = "PID"
        Me.PID.ReadOnly = True
        Me.PID.Width = 80
        '
        'PercentUage
        '
        Me.PercentUage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red
        Me.PercentUage.DefaultCellStyle = DataGridViewCellStyle3
        Me.PercentUage.HeaderText = "% Usage"
        Me.PercentUage.Name = "PercentUage"
        Me.PercentUage.Width = 69
        '
        'MemUsage
        '
        Me.MemUsage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        Me.MemUsage.DefaultCellStyle = DataGridViewCellStyle4
        Me.MemUsage.HeaderText = "MemUsage"
        Me.MemUsage.Name = "MemUsage"
        Me.MemUsage.ReadOnly = True
        Me.MemUsage.Width = 86
        '
        'ProcPath
        '
        Me.ProcPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Lime
        Me.ProcPath.DefaultCellStyle = DataGridViewCellStyle5
        Me.ProcPath.HeaderText = "ProcPath"
        Me.ProcPath.Name = "ProcPath"
        '
        'ProcList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 385)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbxRefresh)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnKill)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvProcList)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ProcList"
        Me.Text = "ProcList"
        CType(Me.dgvProcList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvProcList As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnKill As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents tbxRefresh As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Process As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PercentUage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MemUsage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcPath As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
