<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindSoftware
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindSoftware))
        Me.ComboBoxSoftList = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridViewSoftwareinv = New System.Windows.Forms.DataGridView()
        Me.PCName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScanDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.RadioButtonPositive = New System.Windows.Forms.RadioButton()
        Me.RadioButtonNegative = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabelPCCount = New System.Windows.Forms.Label()
        Me.LabelSoftCount = New System.Windows.Forms.Label()
        CType(Me.DataGridViewSoftwareinv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBoxSoftList
        '
        Me.ComboBoxSoftList.FormattingEnabled = True
        Me.ComboBoxSoftList.Location = New System.Drawing.Point(158, 12)
        Me.ComboBoxSoftList.MaxDropDownItems = 15
        Me.ComboBoxSoftList.Name = "ComboBoxSoftList"
        Me.ComboBoxSoftList.Size = New System.Drawing.Size(333, 21)
        Me.ComboBoxSoftList.Sorted = True
        Me.ComboBoxSoftList.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "List Of All installed Software: "
        '
        'DataGridViewSoftwareinv
        '
        Me.DataGridViewSoftwareinv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewSoftwareinv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PCName, Me.LastUser, Me.ScanDate})
        Me.DataGridViewSoftwareinv.Location = New System.Drawing.Point(12, 39)
        Me.DataGridViewSoftwareinv.Name = "DataGridViewSoftwareinv"
        Me.DataGridViewSoftwareinv.Size = New System.Drawing.Size(621, 320)
        Me.DataGridViewSoftwareinv.TabIndex = 2
        '
        'PCName
        '
        Me.PCName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.PCName.HeaderText = "PCName"
        Me.PCName.Name = "PCName"
        '
        'LastUser
        '
        Me.LastUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LastUser.HeaderText = "LastUser"
        Me.LastUser.Name = "LastUser"
        '
        'ScanDate
        '
        Me.ScanDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ScanDate.HeaderText = "Scandate"
        Me.ScanDate.Name = "ScanDate"
        '
        'ButtonClose
        '
        Me.ButtonClose.Location = New System.Drawing.Point(558, 365)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClose.TabIndex = 3
        Me.ButtonClose.Text = "Close"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'RadioButtonPositive
        '
        Me.RadioButtonPositive.AutoSize = True
        Me.RadioButtonPositive.Checked = True
        Me.RadioButtonPositive.Location = New System.Drawing.Point(137, 371)
        Me.RadioButtonPositive.Name = "RadioButtonPositive"
        Me.RadioButtonPositive.Size = New System.Drawing.Size(90, 17)
        Me.RadioButtonPositive.TabIndex = 4
        Me.RadioButtonPositive.TabStop = True
        Me.RadioButtonPositive.Text = "PositiveQuery"
        Me.RadioButtonPositive.UseVisualStyleBackColor = True
        '
        'RadioButtonNegative
        '
        Me.RadioButtonNegative.AutoSize = True
        Me.RadioButtonNegative.Location = New System.Drawing.Point(233, 371)
        Me.RadioButtonNegative.Name = "RadioButtonNegative"
        Me.RadioButtonNegative.Size = New System.Drawing.Size(96, 17)
        Me.RadioButtonNegative.TabIndex = 5
        Me.RadioButtonNegative.Text = "NegativeQuery"
        Me.RadioButtonNegative.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 373)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Count:"
        '
        'LabelPCCount
        '
        Me.LabelPCCount.AutoSize = True
        Me.LabelPCCount.Location = New System.Drawing.Point(53, 373)
        Me.LabelPCCount.Name = "LabelPCCount"
        Me.LabelPCCount.Size = New System.Drawing.Size(39, 13)
        Me.LabelPCCount.TabIndex = 7
        Me.LabelPCCount.Text = "Label3"
        '
        'LabelSoftCount
        '
        Me.LabelSoftCount.AutoSize = True
        Me.LabelSoftCount.Location = New System.Drawing.Point(507, 15)
        Me.LabelSoftCount.Name = "LabelSoftCount"
        Me.LabelSoftCount.Size = New System.Drawing.Size(35, 13)
        Me.LabelSoftCount.TabIndex = 8
        Me.LabelSoftCount.Text = "Count"
        '
        'FindSoftware
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 406)
        Me.Controls.Add(Me.LabelSoftCount)
        Me.Controls.Add(Me.LabelPCCount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RadioButtonNegative)
        Me.Controls.Add(Me.RadioButtonPositive)
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.DataGridViewSoftwareinv)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBoxSoftList)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FindSoftware"
        Me.Text = "FindSoftware - SWIFT"
        CType(Me.DataGridViewSoftwareinv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBoxSoftList As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewSoftwareinv As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents RadioButtonPositive As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonNegative As System.Windows.Forms.RadioButton
    Friend WithEvents PCName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScanDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LabelPCCount As System.Windows.Forms.Label
    Friend WithEvents LabelSoftCount As System.Windows.Forms.Label
End Class
