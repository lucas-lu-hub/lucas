Public Class Form1
    Private hoverColor_number As Color = Color.Red
    Private hoverColot_operator As Color = Color.Blue
    Private operatorIndexList As List(Of Integer) = New List(Of Integer) From {0, 1, 2, 3, 4, 5, 9, 10, 14, 15, 19, 20, 21, 23, 24}
    Private nunberIndexList As List(Of Integer) = New List(Of Integer) From {6, 7, 8, 11, 12, 13, 16, 17, 18, 22}
    Private leaveColor_number As Color = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
    Private leaveColot_operator As Color = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
    '是否刚点击过一目运算
    Private needRefresh As Boolean = True
    '是否刚点击过二目运算
    Private reOperator As Boolean = False
    '是否刚发生了异常
    Private exception As Boolean = False
    Private opResult As Double
    Private operate As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Focus()
        Dim texts As String() = {"%", "CE", "C", "X", "÷", "√", "7", "8", "9", "×", "x²", "4", "5", "6", "-", "x³", "1", "2", "3", "+", "1/x", "±", "0", ".", "="}
        Dim controls = Me.TableLayoutPanel1.Controls
        For j As Int32 = controls.Count - 1 To 0 Step -1
            If TypeOf controls(j) Is Button Then
                Dim bu As Button = CType(controls(j), Button)
                bu.Margin = New System.Windows.Forms.Padding(1)
                bu.FlatStyle = FlatStyle.Flat
                bu.FlatAppearance.BorderSize = 0
                bu.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                bu.Text = texts(controls.Count - j - 1)
                If j Mod 5 = 0 Then
                    AddHandler bu.MouseHover, AddressOf button_hover_operator
                Else
                    'AddHandler bu.MouseHover, AddressOf button_hover_number
                End If

                If operatorIndexList.Contains(controls.Count - j - 1) Then
                    bu.BackColor = leaveColot_operator
                    AddHandler bu.MouseLeave, AddressOf button_leave_operation
                Else
                    bu.BackColor = leaveColor_number
                    AddHandler bu.MouseLeave, AddressOf button_leave_number
                    AddHandler bu.Click, AddressOf Number_Click
                End If
                If j Mod 5 = 0 And j <> 0 Then
                    AddHandler bu.Click, AddressOf Operator_Click
                End If
            End If
        Next

    End Sub

    Private Sub button_hover_number(sender As Object, e As EventArgs)
        'sender.BackColor = hoverColor_number
    End Sub
    Private Sub button_hover_operator(sender As Object, e As EventArgs)
        sender.BackColor = hoverColot_operator
    End Sub
    Private Sub button_leave_number(sender As Object, e As EventArgs)
        sender.BackColor = leaveColor_number
    End Sub
    Private Sub button_leave_operation(sender As Object, e As EventArgs)
        sender.BackColor = leaveColot_operator
    End Sub
    '数字
    Private Sub Number_Click(sender As Object, e As EventArgs)
        '如果重新输入则先清空result的值
        If needRefresh Then
            Me.resultText.Text = ""
            needRefresh = False
        End If
        If reOperator Then
            Dim index = Me.inputText.Text.LastIndexOf(" ")
            Me.inputText.Text = Me.inputText.Text.Substring(0, index)
            Me.resultText.Text = ""
            reOperator = False
            'to do history
        End If
        Me.resultText.Text += sender.Text
    End Sub
    '运算符
    Private Sub Operator_Click(sender As Object, e As EventArgs)
        If needRefresh Then
            Dim index As Int16 = Me.inputText.Text.LastIndexOf(" ")
            If index > 0 Then
                Me.inputText.Text = Me.inputText.Text.Substring(0, index) + " " + sender.Text
                operate = sender.Text
                Return
            End If
        End If
        needRefresh = True
        If reOperator Then
            Me.inputText.Text += " " + sender.Text
            reOperator = False
        Else
            Me.inputText.Text += " " + Me.resultText.Text + " " + sender.Text
        End If
        Dim re As Double
        If String.IsNullOrEmpty(operate) Then
            If Double.TryParse(Me.resultText.Text, re) Then
                opResult = re
                operate = sender.Text
            End If
            Return
        End If
        If Double.TryParse(Me.resultText.Text, re) Then
            opResult = operation(opResult, re, operate)
            Me.resultText.Text = opResult.ToString()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.resultText.Text = "0"
        If reOperator Then
            Dim index = Me.inputText.Text.LastIndexOf(" ")
            Me.inputText.Text = Me.inputText.Text.Substring(0, index)
            Me.resultText.Text = ""
            reOperator = False
        End If
        needRefresh = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.inputText.Text = ""
        Me.resultText.Text = ""
        opResult = 0
        operate = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) 
        Dim text = Me.resultText.Text
        Me.resultText.Text = text.Substring(0, text.Length - 1)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Me.TabControl1.TabPages(TabControl1.SelectedIndex).Focus()
    End Sub
    '根号
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim resultString As String = Me.resultText.Text
        Dim resultNumber As Double
        If Double.TryParse(resultString, resultNumber) Then
            Dim re = Math.Sqrt(resultNumber)
            If Double.IsNaN(re) Then
                ExceptionHandle()
                Return
            End If
            Me.resultText.Text = Math.Sqrt(resultNumber).ToString
            If reOperator Then
                Dim spaceIndex As Int16 = Me.inputText.Text.LastIndexOf(" ")
                resultString = Me.inputText.Text.Substring(spaceIndex + 1)
                Me.inputText.Text = Me.inputText.Text.Substring(0, spaceIndex)
            End If
            Me.inputText.Text += " " + sender.Text + "(" + resultString + ")"
        End If
        needRefresh = False
        reOperator = True
    End Sub

    Private Sub ExceptionHandle()
        Me.resultText.Text = "Invalid input"
        Dim invaildButtonList As Int16() = {0, 4, 5, 9, 10, 14, 15, 19, 20, 21, 23}
        Dim controls = Me.TableLayoutPanel1.Controls
        For i As Int16 = 0 To controls.Count - 1
            If TypeOf controls(i) Is Button And invaildButtonList.Contains(controls.Count - i - 1) Then
                controls(i).ForeColor = System.Drawing.SystemColors.ControlLight
                controls(i).Enabled = False
            End If
        Next
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        If needRefresh Or Me.resultText.Text = "0" Then
            Me.resultText.Text = "0" + sender.Text
            needRefresh = False
        Else
            If Me.resultText.Text.Contains(sender.Text) Then
                Return
            End If
            Me.resultText.Text += sender.Text
        End If
    End Sub
    '平方
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim resultString As String = Me.resultText.Text
        Dim resultNumber As Double
        If Double.TryParse(resultString, resultNumber) Then
            Me.resultText.Text = Math.Pow(resultNumber, 2).ToString
            If reOperator Then
                Dim spaceIndex As Int16 = Me.inputText.Text.LastIndexOf(" ")
                resultString = Me.inputText.Text.Substring(spaceIndex + 1)
                Me.inputText.Text = Me.inputText.Text.Substring(0, spaceIndex)
            End If
            Me.inputText.Text += " sqr(" + resultString + ")"
        End If
        needRefresh = False
        reOperator = True
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Dim resultString As String = Me.resultText.Text
        Dim resultNumber As Double
        If Double.TryParse(resultString, resultNumber) Then
            Me.resultText.Text = Math.Pow(resultNumber, 3).ToString
            If reOperator Then
                Dim spaceIndex As Int16 = Me.inputText.Text.LastIndexOf(" ")
                resultString = Me.inputText.Text.Substring(spaceIndex + 1)
                Me.inputText.Text = Me.inputText.Text.Substring(0, spaceIndex)
            End If
            Me.inputText.Text += " cube(" + resultString + ")"
        End If
        needRefresh = False
        reOperator = True
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        Dim resultString As String = Me.resultText.Text
        Dim resultNumber As Double
        If Double.TryParse(resultString, resultNumber) Then
            Me.resultText.Text = (1 / resultNumber).ToString()
            If reOperator Then
                Dim spaceIndex As Int16 = Me.inputText.Text.LastIndexOf(" ")
                resultString = Me.inputText.Text.Substring(spaceIndex + 1)
                Me.inputText.Text = Me.inputText.Text.Substring(0, spaceIndex)
            End If
            Me.inputText.Text += " 1/(" + resultString + ")"
        End If
        needRefresh = False
        reOperator = True
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        If Me.resultText.Text.StartsWith("-") Then
            Me.resultText.Text = Me.resultText.Text.Substring(1)
            Return
        End If
        Me.resultText.Text = "-" + Me.resultText.Text
    End Sub
    Private Function operation(ByVal a As Double, ByVal b As Double, op As Char) As Double
        Dim result As Double
        Select Case op
            Case "+"
                result = a + b
            Case "-"
                result = a - b
            Case "×"
                result = a * b
            Case "÷"
                result = a / b
            Case Else
                result = 0
        End Select
        Return result
    End Function
End Class
