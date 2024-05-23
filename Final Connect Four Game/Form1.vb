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
        MoveAndPlaceCounter(button, gridSize)

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
        'WinConditions(button, gridsize)
    End Sub

    Sub AiPlay(button As Button, gridsize As Integer)
        Dim AiDrop As Integer = CInt(Math.Ceiling(Rnd() * gridsize)) + 1

    End Sub
    Function CheckIfButtonEmpty(button)
        If button.BackColor = Color.White Then
            Return True
        Else
            Return False
        End If
    End Function
    Sub MoveAndPlaceCounter(activeButton As Button, gridsize As Integer)
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
                PlaceCounter(activeButton, gridsize)

            Else
                MoveAndPlaceCounter(buttonBelow, gridsize)

            End If
        Else
            PlaceCounter(activeButton, gridsize)

        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBox1.Hide()
        Button1.Hide()
        Button2.Hide()
        Dim friendButton As Boolean = True
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PictureBox1.Hide()
        Button1.Hide()
        Button2.Hide()
        AiButton = True
    End Sub
    Dim AiButton As Boolean = False
    'Sub WinConditions(button As Button, gridsize As Integer)
    '    Dim redCountersInARow As Integer = 0
    '    Dim blueCountersInARow As Integer = 0
    '    Dim redRowStarted As Boolean = False
    '    Dim blueRowStarted As Boolean = False
    '    Dim upperLimit As Integer = (gridsize * gridsize)
    '    Dim iteration As Integer = 0

    '    For i = 1 To upperLimit
    '        For Each ctrl As Control In Panel1.Controls
    '            If TypeOf ctrl Is Button Then
    '                If ctrl.BackColor = Color.Red Then
    '                    redCountersInARow += 1
    '                    redRowStarted = True
    '                    iteration += 1

    '                ElseIf ctrl.BackColor <> Color.Red And redRowStarted = False Then
    '                    redCountersInARow = 0
    '                    iteration += 1

    '                ElseIf ctrl.BackColor <> Color.Red And redRowStarted = True Then
    '                    redCountersInARow = 0
    '                    iteration += 1

    '                End If

    '                If ctrl.BackColor = Color.Blue Then
    '                    blueCountersInARow += 1
    '                    blueRowStarted = True
    '                    iteration += 1

    '                ElseIf ctrl.BackColor <> Color.Blue And blueRowStarted = False Then
    '                    blueCountersInARow = 0
    '                    iteration += 1

    '                ElseIf ctrl.BackColor <> Color.Blue And blueRowStarted = True Then
    '                    blueCountersInARow = 0
    '                    iteration += 1

    '                End If

    '                If iteration > gridsize Then
    '                    redCountersInARow = 0
    '                    blueCountersInARow = 0
    '                    iteration = 1
    '                End If

    '                If redCountersInARow >= 4 Then
    '                    MessageBox.Show("Red wins!")
    '                    Exit Sub
    '                ElseIf blueCountersInARow >= 4 Then
    '                    MessageBox.Show("Blue wins!")
    '                    Exit Sub
    '                End If

    '            End If

    '        Next
    '    Next
    'End Sub

End Class
