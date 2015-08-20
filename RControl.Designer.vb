<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RControl))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbxIP = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CheckBoxDisableWallpaper = New System.Windows.Forms.CheckBox()
        Me.CheckBoxFullNotepad = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(15, 65)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Take Control"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tbxIP
        '
        Me.tbxIP.Location = New System.Drawing.Point(15, 16)
        Me.tbxIP.Name = "tbxIP"
        Me.tbxIP.Size = New System.Drawing.Size(275, 20)
        Me.tbxIP.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(278, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Enter the Name or IP of the Computer you want to Control"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(171, 65)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(119, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CheckBoxDisableWallpaper
        '
        Me.CheckBoxDisableWallpaper.AutoSize = True
        Me.CheckBoxDisableWallpaper.Location = New System.Drawing.Point(15, 42)
        Me.CheckBoxDisableWallpaper.Name = "CheckBoxDisableWallpaper"
        Me.CheckBoxDisableWallpaper.Size = New System.Drawing.Size(112, 17)
        Me.CheckBoxDisableWallpaper.TabIndex = 8
        Me.CheckBoxDisableWallpaper.Text = "Disable Wallpaper"
        Me.CheckBoxDisableWallpaper.UseVisualStyleBackColor = True
        '
        'CheckBoxFullNotepad
        '
        Me.CheckBoxFullNotepad.AutoSize = True
        Me.CheckBoxFullNotepad.Location = New System.Drawing.Point(173, 42)
        Me.CheckBoxFullNotepad.Name = "CheckBoxFullNotepad"
        Me.CheckBoxFullNotepad.Size = New System.Drawing.Size(117, 17)
        Me.CheckBoxFullNotepad.TabIndex = 9
        Me.CheckBoxFullNotepad.Text = "NotepadFullScreen"
        Me.CheckBoxFullNotepad.UseVisualStyleBackColor = True
        '
        'RControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 101)
        Me.Controls.Add(Me.CheckBoxFullNotepad)
        Me.Controls.Add(Me.CheckBoxDisableWallpaper)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbxIP)
        Me.Controls.Add(Me.Button1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "RControl"
        Me.Text = "RC - SWIFT"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tbxIP As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CheckBoxDisableWallpaper As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxFullNotepad As System.Windows.Forms.CheckBox
End Class
