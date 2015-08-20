<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Shadow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Shadow))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tbxShadow = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CheckBoxDisableWallPaper = New System.Windows.Forms.CheckBox()
        Me.CheckBoxFullNotepad = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter Computername Or IP"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(164, 123)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(46, 123)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Shadow"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'tbxShadow
        '
        Me.tbxShadow.Location = New System.Drawing.Point(38, 64)
        Me.tbxShadow.Name = "tbxShadow"
        Me.tbxShadow.Size = New System.Drawing.Size(163, 20)
        Me.tbxShadow.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(206, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Note: You must be logged onto a Terminal"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(48, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Server for this to work"
        '
        'CheckBoxDisableWallPaper
        '
        Me.CheckBoxDisableWallPaper.AutoSize = True
        Me.CheckBoxDisableWallPaper.Location = New System.Drawing.Point(12, 90)
        Me.CheckBoxDisableWallPaper.Name = "CheckBoxDisableWallPaper"
        Me.CheckBoxDisableWallPaper.Size = New System.Drawing.Size(109, 17)
        Me.CheckBoxDisableWallPaper.TabIndex = 6
        Me.CheckBoxDisableWallPaper.Text = "DisableWallpaper"
        Me.CheckBoxDisableWallPaper.UseVisualStyleBackColor = True
        '
        'CheckBoxFullNotepad
        '
        Me.CheckBoxFullNotepad.AutoSize = True
        Me.CheckBoxFullNotepad.Location = New System.Drawing.Point(140, 90)
        Me.CheckBoxFullNotepad.Name = "CheckBoxFullNotepad"
        Me.CheckBoxFullNotepad.Size = New System.Drawing.Size(117, 17)
        Me.CheckBoxFullNotepad.TabIndex = 7
        Me.CheckBoxFullNotepad.Text = "NotepadFullScreen"
        Me.CheckBoxFullNotepad.UseVisualStyleBackColor = True
        '
        'Shadow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(263, 157)
        Me.Controls.Add(Me.CheckBoxFullNotepad)
        Me.Controls.Add(Me.CheckBoxDisableWallPaper)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbxShadow)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Shadow"
        Me.Text = "Shadow"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tbxShadow As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxDisableWallPaper As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxFullNotepad As System.Windows.Forms.CheckBox
End Class
