'Bingo Game Program
'Client:Shady Acres
'Spring 2025

Option Strict On
Option Explicit On

'TODO
'[ ] Display Bingo 
'[ ] Draw a random ball that has not already been drawn
'[ ] Update display to show all drawn balls
'[ ] Refresh tracking with "C" or when all balls have been drawn


Module BingoGame

    Sub Main()
        DisplayBoard()
    End Sub

    Sub DisplayBoard()
        Dim temp As String = "X |"
        Dim heading() As String = {"B", "I", "N", "G", "O"}
        For Each letter In heading
            Console.Write(letter.PadLeft(3).PadRight(5))
        Next
        Console.WriteLine()
        Console.WriteLine(StrDup(25, "_"))
        For i = 1 To 15
            For j = 1 To 5
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

End Module
