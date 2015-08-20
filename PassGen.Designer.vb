<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PassGen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PassGen))
        Me.CheckBoxZero1 = New System.Windows.Forms.CheckBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxLength = New System.Windows.Forms.TextBox
        Me.CharRange = New System.Windows.Forms.Label
        Me.TextBoxPassGEN = New System.Windows.Forms.TextBox
        Me.CheckBoxSpecial = New System.Windows.Forms.CheckBox
        Me.CheckBoxAZ = New System.Windows.Forms.CheckBox
        Me.CheckBox09 = New System.Windows.Forms.CheckBox
        Me.ButtonGenPass = New System.Windows.Forms.Button
        Me.ButtonClose = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckBoxZero1
        '
        Me.CheckBoxZero1.AutoSize = True
        Me.CheckBoxZero1.Checked = True
        Me.CheckBoxZero1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxZero1.Location = New System.Drawing.Point(152, 168)
        Me.CheckBoxZero1.Name = "CheckBoxZero1"
        Me.CheckBoxZero1.Size = New System.Drawing.Size(145, 17)
        Me.CheckBoxZero1.TabIndex = 28
        Me.CheckBoxZero1.Text = "Remove  i,I,j,J,1,l,L,o,O,0"
        Me.CheckBoxZero1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(15, 178)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(58, 43)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 27
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(127, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Using Range:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(12, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Char Set to choose from"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Random Generated Pass"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Pass Length"
        '
        'TextBoxLength
        '
        Me.TextBoxLength.Location = New System.Drawing.Point(84, 58)
        Me.TextBoxLength.Name = "TextBoxLength"
        Me.TextBoxLength.Size = New System.Drawing.Size(24, 20)
        Me.TextBoxLength.TabIndex = 22
        Me.TextBoxLength.Text = "8"
        '
        'CharRange
        '
        Me.CharRange.AutoSize = True
        Me.CharRange.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CharRange.Location = New System.Drawing.Point(202, 61)
        Me.CharRange.Name = "CharRange"
        Me.CharRange.Size = New System.Drawing.Size(39, 13)
        Me.CharRange.TabIndex = 21
        Me.CharRange.Text = "Range"
        '
        'TextBoxPassGEN
        '
        Me.TextBoxPassGEN.Location = New System.Drawing.Point(15, 25)
        Me.TextBoxPassGEN.Name = "TextBoxPassGEN"
        Me.TextBoxPassGEN.Size = New System.Drawing.Size(310, 20)
        Me.TextBoxPassGEN.TabIndex = 20
        '
        'CheckBoxSpecial
        '
        Me.CheckBoxSpecial.AutoSize = True
        Me.CheckBoxSpecial.Location = New System.Drawing.Point(152, 145)
        Me.CheckBoxSpecial.Name = "CheckBoxSpecial"
        Me.CheckBoxSpecial.Size = New System.Drawing.Size(115, 17)
        Me.CheckBoxSpecial.TabIndex = 19
        Me.CheckBoxSpecial.Text = "Special Chars #$%"
        Me.CheckBoxSpecial.UseVisualStyleBackColor = True
        '
        'CheckBoxAZ
        '
        Me.CheckBoxAZ.AutoSize = True
        Me.CheckBoxAZ.Checked = True
        Me.CheckBoxAZ.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxAZ.Location = New System.Drawing.Point(216, 122)
        Me.CheckBoxAZ.Name = "CheckBoxAZ"
        Me.CheckBoxAZ.Size = New System.Drawing.Size(49, 17)
        Me.CheckBoxAZ.TabIndex = 18
        Me.CheckBoxAZ.Text = "A - Z"
        Me.CheckBoxAZ.UseVisualStyleBackColor = True
        '
        'CheckBox09
        '
        Me.CheckBox09.AutoSize = True
        Me.CheckBox09.Checked = True
        Me.CheckBox09.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox09.Location = New System.Drawing.Point(152, 122)
        Me.CheckBox09.Name = "CheckBox09"
        Me.CheckBox09.Size = New System.Drawing.Size(47, 17)
        Me.CheckBox09.TabIndex = 17
        Me.CheckBox09.Text = "0 - 9"
        Me.CheckBox09.UseVisualStyleBackColor = True
        '
        'ButtonGenPass
        '
        Me.ButtonGenPass.Location = New System.Drawing.Point(169, 198)
        Me.ButtonGenPass.Name = "ButtonGenPass"
        Me.ButtonGenPass.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGenPass.TabIndex = 16
        Me.ButtonGenPass.Text = "GenPASS"
        Me.ButtonGenPass.UseVisualStyleBackColor = True
        '
        'ButtonClose
        '
        Me.ButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonClose.Location = New System.Drawing.Point(250, 198)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClose.TabIndex = 15
        Me.ButtonClose.Text = "Exit"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'PassGen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(343, 233)
        Me.Controls.Add(Me.CheckBoxZero1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxLength)
        Me.Controls.Add(Me.CharRange)
        Me.Controls.Add(Me.TextBoxPassGEN)
        Me.Controls.Add(Me.CheckBoxSpecial)
        Me.Controls.Add(Me.CheckBoxAZ)
        Me.Controls.Add(Me.CheckBox09)
        Me.Controls.Add(Me.ButtonGenPass)
        Me.Controls.Add(Me.ButtonClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PassGen"
        Me.Text = "PassGen - SWIFT"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CheckBoxZero1 As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxLength As System.Windows.Forms.TextBox
    Friend WithEvents CharRange As System.Windows.Forms.Label
    Friend WithEvents TextBoxPassGEN As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxSpecial As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxAZ As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox09 As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonGenPass As System.Windows.Forms.Button
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
End Class
