Public Class Form1
    Private hoverColor_number As Color = Color.Red
    Private hoverColot_operator As Color = Color.Blue
    Private operatorIndexList As List(Of Integer) = New List(Of Integer) From {0, 1, 2, 3, 4, 5, 9, 10, 14, 15, 19, 20, 21, 23, 24}
    Private nunberIndexList As List(Of Integer) = New List(Of Integer) From {6, 7, 8, 11, 12, 13, 16, 17, 18, 22}
    Private leaveColor_number As Color = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
    Private leaveColot_operator As Color = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
    '是否是重新输入的数字
    Private needRefresh As Boolean
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim texts As String() = {"%", "CE", "C", "X", "/", "", "7", "8", "9", "*", "", "4", "5", "6", "-", "", "1", "2", "3", "+", "", "", "0", ".", "="}
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

    Private Sub Number_Click(sender As Object, e As EventArgs)
        '如果重新输入则先清空result的值
        If needRefresh Then
            Me.resultText.Text = ""
            needRefresh = False
        End If
        Me.resultText.Text += sender.Text + " "
    End Sub

    Private Sub Operator_Click(sender As Object, e As EventArgs)
        needRefresh = True
        'Me.inputText.Text += "hello" + sender.Text
        Me.inputText.Text += " " + Me.resultText.Text + " " + sender.Text
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) 
        Me.resultText.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) 
        Me.inputText.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) 
        Dim text = Me.resultText.Text
        Me.resultText.Text = text.Substring(0, text.Length - 1)
    End Sub
End Class
