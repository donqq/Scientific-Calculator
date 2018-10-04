'Developed by Badde Liyanage Don Dilanga. bld@dilanga.com. 

Public Class calculation

    Dim first_value, second_value, answer_value, symbol As Double

    Public Function calculate(ByVal first_value, ByVal second_value, ByVal symbol)
        '/sub or set can't be return specific value

        Select Case symbol
            Case 1 '/ add
                answer_value = (Val(first_value)) + (Val(second_value))

            Case 2 '/subtract
                answer_value = (Val(first_value)) - (Val(second_value))

            Case 3 '/multiply
                answer_value = (Val(first_value)) * (Val(second_value))

            Case 4 '/divide
                answer_value = (Val(first_value)) / (Val(second_value))

        End Select

        Return answer_value

    End Function

End Class
