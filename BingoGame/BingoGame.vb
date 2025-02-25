'Bingo Game Program
'Client:Shady Acres
'Spring 2025

Option Strict On
Option Explicit On

'TODO
'[x] Display Bingo 
'[x] Draw a random ball that has not already been drawn
'[x] Update display to show all drawn balls
'[ ] Update display to show actual ball number
'[ ] Refresh tracking with "C" or when all balls have been drawn


Module BingoGame

    Sub Main()
        'DisplayBoard()
        'For i = 1 To 10

        '    Console.Clear()
        '    DrawBall()
        '    DisplayBoard()

        'Next
        'Console.Read()
        'BingoTracker(0, 0,, True) 'test that clear works 
        'DisplayBoard()

        Dim userInput As String

        Do
            Console.Clear()
            DisplayBoard()
            Console.WriteLine()
            'prompt
            userInput = Console.ReadLine()
            Select Case userInput
                Case "d"
                    DrawBall()
                Case "c"
                    BingoTracker(0, 0,, True)
                    DrawBall(True)
                Case Else
                    'pass

            End Select


        Loop Until userInput = "q"
        Console.Clear()
        Console.WriteLine("Have a nice day!")

    End Sub

    Sub DrawBall(Optional clearCount As Boolean = False)
        Dim temp(,) As Boolean = BingoTracker(0, 0) 'Create a local copy of ball tracker array
        Dim currentBallNumber As Integer
        Dim currentBallLetter As Integer
        Static ballCounter As Integer

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
        Loop Until temp(currentBallNumber, currentBallLetter) = False Or ballCounter >= 75
        'Mark current ball as being drawn, updates the display

        BingoTracker(currentBallNumber, currentBallLetter, True)
        ballCounter += 1

        ' For debug write valid ball draws to console  
        Console.WriteLine($"The current row is {currentBallNumber} and the column is {currentBallLetter}")

    End Sub


    ''' <summary>
    ''' Iterates Through the tracker array and displays bingo board to the console
    ''' </summary>

    Sub DisplayBoard()
        Dim temp As String = " |"
        Dim heading() As String = {"B", "I", "N", "G", "O"}
        Dim tracker(,) As Boolean = BingoTracker(0, 0) '
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

    ''' <summary>
    ''' Contains a persistent array that tracks all possible bingo balls
    ''' and whether they have been drawn during the current game.
    ''' </summary>
    ''' <param name="ballNumber"></param>
    ''' <param name="ballLetter"></param>
    ''' <param name="clear"></param>
    ''' <returns>Current Tracking Array</returns>

    Function BingoTracker(ballNumber As Integer, ballLetter As Integer, Optional update As Boolean = False, Optional clear As Boolean = False) As Boolean(,)
        Static _bingoTracker(14, 4) As Boolean


        If update Then
            _bingoTracker(ballNumber, ballLetter) = True
        End If

        If clear Then
            ReDim _bingoTracker(14, 4) 'clears the array. Could also loop through array and set all elements 
        End If
        'actual code here
        _bingoTracker(ballNumber, ballLetter) = True
        Return _bingoTracker
    End Function

End Module
