Public Class Form1
    Dim gridSize As Integer = 7 'Amount of rows and colums!
    Dim buttonSize As Integer = 70 ' Size of buttons!
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        If AiButton = True Then

        End If
        MoveAndPlaceCounter(button, gridSize)

    End Sub
    Sub MoveAndPlaceCounter(activeButton As Button, gridsize As Integer)
        Dim buttonSize As Size = activeButton.Size
        Dim desiredLocation As Point = New Point(activeButton.Location.X, activeButton.Location.Y + buttonSize.Height)
        Dim buttonBelow As Button = Nothing

        For Each button As Control In Panel1.Controls
            If TypeOf button Is Button AndAlso button.Location = desiredLocation Then
                buttonBelow = CType(button, Button)
                Exit For

            End If

        Next

        If buttonBelow IsNot Nothing Then
            If buttonBelow.BackColor <> Color.White Then
                PlaceCounter(activeButton, gridsize)

            Else
                MoveAndPlaceCounter(buttonBelow, gridsize)

            End If
        Else
            PlaceCounter(activeButton, gridsize)

        End If
        WinConditons(activeButton, gridsize)
    End Sub
    Sub PlaceCounter(button As Button, gridsize As Integer)
        If CheckIfButtonEmpty(button) = True Then
            If TextBox1.Text = "Red" Then
                button.BackColor = Color.Red
            Else
                If AiButton = True Then
                    AiPlay(button, gridsize)
                Else
                    button.BackColor = Color.Blue
                End If
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
    Sub AiPlay(button As Button, gridsize As Integer)
        Dim AiDrop As Integer = CInt(Math.Ceiling(Rnd() * gridsize)) + 1

        For Each drop As Control In Panel1.Controls
            If drop.Location.X * buttonSize = drop.Location.X * AiDrop Then
                MoveAndPlaceCounter(drop, gridsize)
            End If
        Next
    End Sub
    Sub WinConditons(button As Button, gridsize As Integer)
        Dim upperLimit As Integer = gridsize ^ 2
        Dim redCountersInARow As Integer = 0
        Dim blueCountersInARow As Integer = 0
        Dim redIteration As Integer = 0
        Dim blueIteration As Integer = 0

        CheckHorizontal(upperLimit, redCountersInARow, blueCountersInARow, redIteration, blueIteration)

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBox1.Hide()
        Button1.Hide()
        Button2.Hide()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PictureBox1.Hide()
        Button1.Hide()
        Button2.Hide()
        AiButton = True

        AiPlay(sender, gridSize)
    End Sub
    Dim AiButton As Boolean = False


    Sub CheckHorizontal(upperLimit, redCountersInARow, blueCountersInARow, redIteration, blueIteration)
        For i = 1 To upperLimit
            For Each button As Control In Panel1.Controls
                If TypeOf button Is Button Then
                    If button.BackColor = Color.Red Then
                        redCountersInARow += 1
                        redIteration += 1
                        If redIteration > gridSize Then
                            redIteration = 1
                            redCountersInARow = 0
                        End If
                    ElseIf button.BackColor <> Color.Red Then
                        redCountersInARow = 0
                        redIteration += 1
                        If redIteration > gridSize Then
                            redIteration = 1
                            redCountersInARow = 0
                        End If
                    End If

                    If button.BackColor = Color.Blue Then
                        blueCountersInARow += 1
                        redIteration += 1
                        If blueIteration > gridSize Then
                            blueIteration = 1
                            blueCountersInARow = 0
                        End If
                    ElseIf button.BackColor <> Color.Blue Then
                        blueCountersInARow = 0
                        blueIteration += 1
                        If blueIteration > gridSize Then
                            blueIteration = 1
                            blueCountersInARow = 0
                        End If
                    End If

                    If redCountersInARow >= 4 Then
                        MessageBox.Show("Red won!")
                        Exit Sub
                    ElseIf blueCountersInARow >= 4 Then
                        MessageBox.Show("Blue won!")
                        Exit Sub
                    End If

                End If
            Next
        Next
    End Sub

End Class