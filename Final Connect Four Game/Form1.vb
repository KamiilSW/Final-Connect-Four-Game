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
    Private Sub Button_Click(control As Object, e As EventArgs)
        Dim button As Button = CType(control, Button)
        MoveAndPlaceCounter(button)

    End Sub

    Sub PlaceCounter(button As Button)
        If CheckIfButtonEmpty(button) = True Then
            If TextBox1.Text = "Red" Then
                button.BackColor = Color.Red

            Else
                button.BackColor = Color.Blue

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

    Function CheckIfButtonEmpty(button)
        If button.BackColor = Color.White Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub MoveAndPlaceCounter(activeButton As Button)
        Dim buttonSize As Size = activeButton.Size
        Dim desiredLocation As Point = New Point(activeButton.Location.X, activeButton.Location.Y + buttonSize.Height)

        Dim buttonBelow As Button = Nothing

        For Each ctrl As Control In Panel1.Controls
            If TypeOf ctrl Is Button AndAlso ctrl.Location = desiredLocation Then
                buttonBelow = CType(ctrl, Button)
                Exit For
            End If
        Next

        If buttonBelow IsNot Nothing Then
            If buttonBelow.BackColor <> Color.White Then
                PlaceCounter(activeButton)
            Else
                MoveAndPlaceCounter(buttonBelow)
            End If
        Else
            PlaceCounter(activeButton)
        End If

    End Sub

End Class
