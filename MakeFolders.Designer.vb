<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MakeFolders
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MakeFolders))
        Me.Button1 = New System.Windows.Forms.Button
        Me.lstServerList = New System.Windows.Forms.ListBox
        Me.lstCreateIn = New System.Windows.Forms.ListBox
        Me.lblName = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBoxFoldersCreated = New System.Windows.Forms.PictureBox
        Me.LabelFoldersCreated = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LabelDirFailReason = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.txtUName = New System.Windows.Forms.TextBox
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxFoldersCreated, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(333, 329)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Done"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lstServerList
        '
        Me.lstServerList.FormattingEnabled = True
        Me.lstServerList.Location = New System.Drawing.Point(11, 32)
        Me.lstServerList.Name = "lstServerList"
        Me.lstServerList.Size = New System.Drawing.Size(149, 199)
        Me.lstServerList.Sorted = True
        Me.lstServerList.TabIndex = 11
        '
        'lstCreateIn
        '
        Me.lstCreateIn.FormattingEnabled = True
        Me.lstCreateIn.HorizontalScrollbar = True
        Me.lstCreateIn.Location = New System.Drawing.Point(190, 32)
        Me.lstCreateIn.Name = "lstCreateIn"
        Me.lstCreateIn.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstCreateIn.Size = New System.Drawing.Size(218, 199)
        Me.lstCreateIn.TabIndex = 12
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(12, 9)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(60, 13)
        Me.lblName.TabIndex = 14
        Me.lblName.Text = "UserName:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(8, 319)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(163, 16)
        Me.Label29.TabIndex = 59
        Me.Label29.Text = "Super Fast Directories"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(11, 266)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(61, 50)
        Me.PictureBox2.TabIndex = 58
        Me.PictureBox2.TabStop = False
        '
        'PictureBoxFoldersCreated
        '
        Me.PictureBoxFoldersCreated.BackColor = System.Drawing.Color.Lime
        Me.PictureBoxFoldersCreated.Location = New System.Drawing.Point(104, 18)
        Me.PictureBoxFoldersCreated.Name = "PictureBoxFoldersCreated"
        Me.PictureBoxFoldersCreated.Size = New System.Drawing.Size(10, 11)
        Me.PictureBoxFoldersCreated.TabIndex = 61
        Me.PictureBoxFoldersCreated.TabStop = False
        '
        'LabelFoldersCreated
        '
        Me.LabelFoldersCreated.AutoSize = True
        Me.LabelFoldersCreated.Location = New System.Drawing.Point(6, 16)
        Me.LabelFoldersCreated.Name = "LabelFoldersCreated"
        Me.LabelFoldersCreated.Size = New System.Drawing.Size(81, 13)
        Me.LabelFoldersCreated.TabIndex = 2
        Me.LabelFoldersCreated.Text = "Folders Created"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelDirFailReason)
        Me.GroupBox1.Controls.Add(Me.PictureBoxFoldersCreated)
        Me.GroupBox1.Controls.Add(Me.LabelFoldersCreated)
        Me.GroupBox1.Location = New System.Drawing.Point(190, 237)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(218, 86)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status"
        '
        'LabelDirFailReason
        '
        Me.LabelDirFailReason.Location = New System.Drawing.Point(6, 41)
        Me.LabelDirFailReason.Name = "LabelDirFailReason"
        Me.LabelDirFailReason.Size = New System.Drawing.Size(206, 38)
        Me.LabelDirFailReason.TabIndex = 62
        Me.LabelDirFailReason.Text = "Label1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(252, 329)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 61
        Me.Button2.Text = "Create"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtUName
        '
        Me.txtUName.Location = New System.Drawing.Point(78, 6)
        Me.txtUName.Name = "txtUName"
        Me.txtUName.Size = New System.Drawing.Size(121, 20)
        Me.txtUName.TabIndex = 62
        '
        'MakeFolders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 367)
        Me.Controls.Add(Me.txtUName)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lstCreateIn)
        Me.Controls.Add(Me.lstServerList)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "MakeFolders"
        Me.Text = "MakeFolders"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxFoldersCreated, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lstServerList As System.Windows.Forms.ListBox
    Friend WithEvents lstCreateIn As System.Windows.Forms.ListBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxFoldersCreated As System.Windows.Forms.PictureBox
    Friend WithEvents LabelFoldersCreated As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelDirFailReason As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtUName As System.Windows.Forms.TextBox
End Class
