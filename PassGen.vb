Public Class PassGen
    'This form is a basic password generator that creates random sample passwords that the user can easily copy/paste
    'when they need to reset someones password. 
    'It allows the user to select different password strength options
    Dim SomeRandomClass As New Random()
    Dim CAps As Boolean = False
    Dim Special As Boolean = False
    Dim Numbers As Boolean = False
    Public Function CharSet()
        Dim CharSetString As String = "a - z"
        If CheckBox09.Checked Then CharSetString += ", 0 - 9"
        If CheckBoxAZ.Checked Then CharSetString += ", A - Z"
        If CheckBoxSpecial.Checked Then CharSetString += ", #$%&?@"
        Return CharSetString
    End Function
    Public Function validateLength()
        Dim sumNumba As Integer
        Try
            sumNumba = Integer.Parse(TextBoxLength.Text)
            If sumNumba > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function Randomonizer(ByVal numba As Integer)
        Dim NumbaReturn As Integer
        Select Case numba
            Case 5 To 9 And CheckBox09.Checked = True
                Numbers = True
                If CheckBoxZero1.Checked = True Then
                    NumbaReturn = SomeRandomClass.Next(50, 57) 'chars 0-9
                Else
                    NumbaReturn = SomeRandomClass.Next(48, 57) 'chars 0-9
                End If
            Case 10 To 12 And CheckBoxAZ.Checked = True
                If CheckBoxZero1.Checked Then
                    Dim TempRandom1 As Integer = SomeRandomClass.Next(1, 11)
                    Select Case TempRandom1
                        Case 1 To 4
                            NumbaReturn = SomeRandomClass.Next(65, 72) 'chars A-Z(65 to 90) -L(76) -I(73) _J(74) -O(79) = (65,72)(75)(77,78)(80,90)
                        Case 5
                            NumbaReturn = 75
                        Case 6
                            NumbaReturn = SomeRandomClass.Next(77, 78)
                        Case 7 To 11
                            NumbaReturn = SomeRandomClass.Next(80, 90)
                    End Select
                Else
                    NumbaReturn = SomeRandomClass.Next(65, 90)
                End If
                CAps = True
            Case 14 To 15 And CheckBoxSpecial.Checked = True
                Dim TempRandom3 As Integer = SomeRandomClass.Next(1, 10)
                Select Case TempRandom3
                    Case 1 To 6
                        NumbaReturn = SomeRandomClass.Next(35, 38) 'chars #,$,%,&
                    Case 7
                        NumbaReturn = 63 '?
                    Case 8 To 10
                        NumbaReturn = 64 '@
                End Select
                Special = True
            Case 0 To 15
                If CheckBoxZero1.Checked Then
                    Dim TempRandom2 As Integer = SomeRandomClass.Next(1, 11)
                    Select Case TempRandom2
                        Case 1 To 4
                            NumbaReturn = SomeRandomClass.Next(97, 104) 'chars a-z, -i(105) -j(106) -l(108) -0(111) = (97,104)(107)(109,110)(112,122)
                        Case 5
                            NumbaReturn = 107
                        Case 6
                            NumbaReturn = SomeRandomClass.Next(109, 110)
                        Case 7 To 11
                            NumbaReturn = SomeRandomClass.Next(112, 122)
                    End Select
                Else
                    NumbaReturn = SomeRandomClass.Next(97, 122)
                End If
        End Select
        Return NumbaReturn
    End Function
    Sub GenPass()
        CAps = False
        Special = False
        Numbers = False
        If Not validateLength() Then
            MessageBox.Show("Please enter a number greater than zero.")
            TextBoxLength.Text = "8"
            Exit Sub
        End If
        Dim ThePassGen As String = ""
        If (CheckBox09.Checked And CheckBoxAZ.Checked And CheckBoxSpecial.Checked) Then
            Do Until CAps = True And Numbers = True And Special = True
                CAps = False
                Special = False
                Numbers = False
                ThePassGen = ""
                Dim RandNumba As Integer = 1
                For i As Integer = 1 To Integer.Parse(TextBoxLength.Text)
                    RandNumba = Randomonizer(SomeRandomClass.Next(0, 15))
                    ThePassGen += Chr(RandNumba)
                Next
            Loop
        ElseIf (CheckBox09.Checked And CheckBoxAZ.Checked) Then
            Do Until CAps = True And Numbers = True
                CAps = False
                Special = False
                Numbers = False
                ThePassGen = ""
                Dim RandNumba As Integer = 1
                For i As Integer = 1 To Integer.Parse(TextBoxLength.Text)
                    RandNumba = Randomonizer(SomeRandomClass.Next(0, 15))
                    ThePassGen += Chr(RandNumba)
                Next
            Loop
        ElseIf (CheckBoxSpecial.Checked And CheckBox09.Checked) Then
            Do Until Special = True And Numbers = True
                CAps = False
                Special = False
                Numbers = False
                ThePassGen = ""
                Dim RandNumba As Integer = 1
                For i As Integer = 1 To Integer.Parse(TextBoxLength.Text)
                    RandNumba = Randomonizer(SomeRandomClass.Next(0, 15))
                    ThePassGen += Chr(RandNumba)
                Next
            Loop
        ElseIf (CheckBoxSpecial.Checked And CheckBoxAZ.Checked) Then
            Do Until Special = True And CAps = True
                CAps = False
                Special = False
                Numbers = False
                ThePassGen = ""
                Dim RandNumba As Integer = 1
                For i As Integer = 1 To Integer.Parse(TextBoxLength.Text)
                    RandNumba = Randomonizer(SomeRandomClass.Next(0, 15))
                    ThePassGen += Chr(RandNumba)
                Next
            Loop
        Else
            ThePassGen = ""
            Dim RandNumba As Integer = 1
            For i As Integer = 1 To Integer.Parse(TextBoxLength.Text)
                RandNumba = Randomonizer(SomeRandomClass.Next(0, 15))
                ThePassGen += Chr(RandNumba)
            Next
        End If
        TextBoxPassGEN.Text = ThePassGen
        TextBoxPassGEN.Focus()
        TextBoxPassGEN.SelectionStart = 0
        TextBoxPassGEN.SelectionLength = Len(TextBoxPassGEN.Text)
    End Sub
    Private Sub ButtonGenPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenPass.Click
        GenPass()
        resetchk.txtNewPass.Text = TextBoxPassGEN.Text
    End Sub
    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub
    Private Sub PassGen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim WindowX As Integer = resetchk.Location.X
        Dim Windowy As Integer = resetchk.Location.Y
        Dim NewWindowPoint As New Point(WindowX + resetchk.Width, Windowy)
        Me.Location = NewWindowPoint
        CharRange.Text = CharSet()
        GenPass()
        resetchk.txtNewPass.Text = TextBoxPassGEN.Text
        resetchk.Select()
    End Sub
End Class