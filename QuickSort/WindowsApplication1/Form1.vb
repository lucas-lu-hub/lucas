Public Class Form1
    Private stopColor As Color = Color.Red
    Private leaveColor As Color = Color.Green
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim texts As String() = {"%", "CE", "C", "X", "/", "", "7", "8", "9", "*", "", "4", "5", "6", "-", "", "1", "2", "3", "+", "", "", "0", ".", "="}
        Dim controls = Me.TableLayoutPanel1.Controls
        For j As Int32 = controls.Count - 1 To 0 Step -1
            If TypeOf controls(j) Is Button Then
                controls(j).Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                controls(j).Text = texts(controls.Count - j - 1)
                If
            End If
        Next

    End Sub

    Private Sub Button1_MouseHover(sender As Object, e As EventArgs) Handles Button1.MouseHover
        button_hover(sender)
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        button_leave(sender)
    End Sub
    Private Sub button_hover(ByRef bu As Button)
        bu.BackColor = stopColor
    End Sub
    Private Sub button_leave(ByRef bu As Button)
        bu.BackColor = leaveColor
    End Sub

    Private Sub Button2_MouseHover(sender As Object, e As EventArgs) Handles Button2.MouseHover

    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave

    End Sub

    Private Sub Button3_MouseHover(sender As Object, e As EventArgs) Handles Button3.MouseHover

    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave

    End Sub

    Private Sub Button4_MouseHover(sender As Object, e As EventArgs) Handles Button4.MouseHover

    End Sub

    Private Sub Button4_MouseLeave(sender As Object, e As EventArgs) Handles Button4.MouseLeave

    End Sub
End Class
