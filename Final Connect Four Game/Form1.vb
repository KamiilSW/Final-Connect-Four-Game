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
                button.BackColor = Color.White
                AddHandler button.Click, AddressOf Button_Click
                Panel1.Controls.Add(button)

            Next

        Next
    End Sub
    Private Sub Button_Click(sender As Object, e As EventArgs)
        PlaceCounter(sender)
    End Sub

    Sub PlaceCounter(sender As Object)
        Dim clickedButton As Button = CType(sender, Button)
        If clickedButton.BackColor = Color.White Then
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
        Else
            Exit Sub

        End If
    End Sub

    'Function PlaceCounter(ByRef gridsize As Integer, ByRef buttonSize As Integer, ByRef clickedButton As CType(sender, Button)) As Boolean
    '    For i = 1 To gridsize - 1
    '        If clickedButton.Location.Y = buttonSize * (gridsize - i) And i = 1 Then
    '            If clickedButton.BackColor = Color.White Then
    '                If TextBox1.Text = "Red" Then
    '                    clickedButton.BackColor = Color.Red

    '                Else
    '                    clickedButton.BackColor = Color.Blue

    '                End If

    '            End If

    '        ElseIf clickedButton.Location.Y = buttonSize * (gridsize - i) And i = 2 Then
    '            If clickedButton.BackColor = Color.White Then

    '            End If

    '        End If

    '    Next
    'End Function
End Class
