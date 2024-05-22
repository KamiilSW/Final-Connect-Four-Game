Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim gridSize As Integer = 7 'Amount of rows and colums!
        Dim buttonSize As Integer = 70 ' Size of buttons!

        For i As Integer = 0 To gridSize - 1

            For j As Integer = 0 To gridSize - 1
                Dim button As New Button()
                button.Size = New Size(buttonSize, buttonSize)
                button.Location = New Point(j * buttonSize, i * buttonSize)
                button.Text = ""
                AddHandler button.Click, AddressOf Button_Click
                Panel1.Controls.Add(button)

            Next

        Next
    End Sub
    Private Sub Button_Click(sender As Object, e As EventArgs)
        Dim clickedButton As Button = CType(sender, Button)

        If clickedButton Then
            If TextBox1.Text = "Red" Then
            clickedButton.BackColor = Color.Red

        Else
            clickedButton.BackColor = Color.Blue

        End If

        If TextBox1.Text = "Red" Then
            TextBox1.Text = "Blue"
            TextBox1.ForeColor = Color.Blue

        Else
            TextBox1.Text = "Red"
            TextBox1.ForeColor = Color.Red

        End If
    End Sub

End Class
