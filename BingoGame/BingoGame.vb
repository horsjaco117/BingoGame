'Bingo Game Program
'Client:Shady Acres
'Spring 2025

Option Strict On
Option Explicit On

'TODO
'[ ] Display Bingo 
'[ ] Draw a random ball that has not already been drawn
'[ ] Update display to show all drawn balls
'[ ] Update display to show actual ball number
'[ ] Refresh tracking with "C" or when all balls have been drawn


Module BingoGame

    Sub Main()
        DisplayBoard()
        For i = 1 To 10

            DrawBall()
            DisplayBoard()
            Console.Read()
            Console.Clear()

        Next

    End Sub

    Sub DrawBall()
        Dim temp(,) As Boolean = BingoTracker(0, 0) 'Create a local copy of ball tracker array
        Dim currentBallNumber As Integer
        Dim currentBallLetter As Integer

        ''Get the row
        'currentBallNumber = randomNumberBetween(0, 14) 'rows compare to BingoTracker

        ''Get the column
        'currentBallLetter = randomNumberBetween(0, 4)

        ' Loop until the current random ball has not already been marked as drawn
        Do
            'Get the row
            currentBallNumber = randomNumberBetween(0, 14)
            'Get the column
            currentBallLetter = randomNumberBetween(0, 4)
        Loop Until temp(currentBallNumber, currentBallLetter) = False
        'Mark current ball as being drawn, updates the display

        BingoTracker(currentBallNumber, currentBallLetter)

        ' For debug write valid ball draws to console  
        Console.WriteLine($"The current row is {currentBallNumber} and the column is {currentBallLetter}")

    End Sub

    Sub DisplayBoard()
        Dim temp As String = " |"
        Dim heading() As String = {"B", "I", "N", "G", "O"}
        Dim tracker(,) As Boolean = BingoTracker(0, 0)
        For Each letter In heading
            Console.Write(letter.PadLeft(3).PadRight(5))
        Next
        Console.WriteLine()
        Console.WriteLine(StrDup(25, "_"))
        For currentNumber = 0 To 14 'Fix, loop through the array
            For currentLetter = 0 To 4 'Fix 

                If tracker(currentNumber, currentLetter) Then
                    temp = "X |" 'Displary for drawn balls

                Else
                    temp = " |" 'Display for not drawn balls
                End If

                temp = temp.PadLeft(5)
                Console.Write(temp)

            Next
            Console.WriteLine()
        Next

    End Sub

    Function randomNumberBetween(max As Integer, min As Integer) As Integer 'We need to declare return type
        Dim temp As Single 'The single type helps work with the randomize stuff
        Randomize()
        temp = Rnd()
        temp *= (max + 1) - min  'supposedly adding the one increase the max by 1. to fix inclusivity of max/min

        temp += min - 1 'This is supposed to shift the min down by 1

        Return CInt(Math.Floor(temp)) 'min isn't included
        '
    End Function

    Function BingoTracker(ballNumber As Integer, ballLetter As Integer, Optional clear As Boolean = False) As Boolean(,)
        Static _bingoTracker(14, 4) As Boolean
        'actual code here
        _bingoTracker(ballNumber, ballLetter) = True
        Return _bingoTracker
    End Function

End Module
