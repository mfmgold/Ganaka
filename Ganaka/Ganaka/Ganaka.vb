Public Class frmGanaka
    'Code by Murtuza Fakhruddin, 12/10/2012
    'Ganaka in Hindi means Calculator
    Dim x As Double = 0
    Dim c As String = " "
    Dim NewNumber As Byte = 0

    Private Sub ButtonPad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles L_0.Click, L_1.Click, L_2.Click, L_3.Click, L_4.Click, L_5.Click, L_6.Click, L_7.Click, L_8.Click, L_9.Click, L_BS.Click, L_Display.Click, L_Divide.Click, L_Dot.Click, L_Equals.Click, L_Minus.Click, L_Multiply.Click, L_Plus.Click
        c = " "
        If sender.Name = "L_Display" Then Calculate("Display") Else Calculate(Trim(sender.text))
    End Sub

    Private Sub frm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If c = "Display" And Asc(e.KeyChar) = Keys.Escape Then End
        c = e.KeyChar
        If Asc(c) = Keys.Enter Then
            c = "="
        ElseIf Asc(c) = Keys.Back Then
            c = "BS"
        ElseIf Asc(c) = Keys.Escape Then
            c = "Display"
        End If
        Calculate(c)
    End Sub

    Private Sub Calculate(ByVal y As String)
        If L_Op.Text = "=" Or L_Op.Text = "MAXED" Then L_Op.Text = ""
        If L_Display.Text.Length > 36 And y <> "BS" And y <> "Display" Then Beep() : L_Op.Text = "MAXED" : Exit Sub
        Select Case y
            Case 0 To 9
                If NewNumber = 0 Or L_Display.Text = "0" Then L_Display.Text = y Else L_Display.Text += y
                NewNumber = 1
                If CDbl(L_Display.Text) = 0 And Not L_Display.Text.Contains(".") Then L_Display.Text = "0"
            Case "."
                If NewNumber = 0 Then L_Display.Text = "0" + y
                If Not L_Display.Text.Contains(".") Then L_Display.Text += y
                NewNumber = 1
            Case "Display"
                L_Display.Text = "0"
                NewNumber = 0
                L_Op.Text = ""
            Case "BS"
                L_Display.Text = Mid(L_Display.Text, 1, L_Display.Text.Length - 1)
                If L_Display.Text = "" Then L_Display.Text = "0" : NewNumber = 0
            Case "="
                Select Case L_Op.Text
                    Case "+"
                        L_Display.Text = CStr(x + CDbl(L_Display.Text))
                    Case "-"
                        L_Display.Text = CStr(x - CDbl(L_Display.Text))
                    Case "*"
                        L_Display.Text = CStr(x * CDbl(L_Display.Text))
                    Case "/"
                        L_Display.Text = CStr(x / CDbl(L_Display.Text))
                End Select
                x = 0
                NewNumber = 0
                L_Op.Text = "="
            Case Else
                If Not IsNumeric(L_Display.Text) Then
                    L_Display.Text = "Duuuuh!"
                Else
                    x = CDbl(L_Display.Text)
                    L_Op.Text = y
                    NewNumber = 0
                End If
        End Select
    End Sub

    
End Class
