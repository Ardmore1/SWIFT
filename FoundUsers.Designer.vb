<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FoundUsers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FoundUsers))
        Me.lbxFoundUsers = New System.Windows.Forms.ListBox()
        Me.ButtonGetUser = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelSearching = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbxFoundUsers
        '
        Me.lbxFoundUsers.FormattingEnabled = True
        Me.lbxFoundUsers.Location = New System.Drawing.Point(12, 33)
        Me.lbxFoundUsers.Name = "lbxFoundUsers"
        Me.lbxFoundUsers.Size = New System.Drawing.Size(280, 225)
        Me.lbxFoundUsers.Sorted = True
        Me.lbxFoundUsers.TabIndex = 0
        '
        'ButtonGetUser
        '
        Me.ButtonGetUser.Location = New System.Drawing.Point(117, 293)
        Me.ButtonGetUser.Name = "ButtonGetUser"
        Me.ButtonGetUser.Size = New System.Drawing.Size(94, 23)
        Me.ButtonGetUser.TabIndex = 1
        Me.ButtonGetUser.Text = "Get The User"
        Me.ButtonGetUser.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(217, 293)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 2
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 264)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(280, 23)
        Me.ProgressBar1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Account --> DisplayName"
        '
        'LabelSearching
        '
        Me.LabelSearching.AutoSize = True
        Me.LabelSearching.Location = New System.Drawing.Point(13, 298)
        Me.LabelSearching.Name = "LabelSearching"
        Me.LabelSearching.Size = New System.Drawing.Size(64, 13)
        Me.LabelSearching.TabIndex = 5
        Me.LabelSearching.Text = "Searching..."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(184, -1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "TIP: Double click to select"
        '
        'FoundUsers
        '
        Me.AcceptButton = Me.ButtonGetUser
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(316, 334)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LabelSearching)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonGetUser)
        Me.Controls.Add(Me.lbxFoundUsers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FoundUsers"
        Me.Text = "FoundUsers"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbxFoundUsers As System.Windows.Forms.ListBox
    Friend WithEvents ButtonGetUser As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelSearching As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
