Public Class Form1
    Private number As Int16() = {7, 8, 9}
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim bus As List(Of Button) = New List(Of Button)
        Dim texts As String() = {"%", "CE", "C", "X", "/", "", "7", "8", "9", "*", "", "4", "5", "6", "-", "", "1", "2", "3", "+", "", "", "0", ".", "="}
        Dim panel As TableLayoutPanel = Me.TableLayoutPanel1
        For i As Int16 = 0 To texts.Length - 1
            Dim bu As Button = New Button()
            bu.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            bu.Dock = DockStyle.Fill
            bu.Text = texts(i)
            bu.Margin = New System.Windows.Forms.Padding(0)
            panel.Controls.Add(bu)
            bus.Add(bu)
        Next
        'For i As Int16 = 0 To bus.Count - 1
        '    If i Mod 5 = 4 Then
        '        bus(i)
        '    End If
        'Next

    End Sub
End Class
