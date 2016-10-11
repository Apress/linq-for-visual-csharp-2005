Imports System
Imports System.Collections.Generic

Namespace StandardQueryOperatorsDemo
    Public Class MyComparer
        Implements IEqualityComparer(Of String)

        ' Methods
        Public Function Equals(ByVal x As String, ByVal y As String) As Boolean
            Return (x.Substring(0, 2) Is y.Substring(0, 2))
        End Function

        Public Function GetHashCode(ByVal obj As String) As Integer
            Return obj.Substring(0, 2).GetHashCode
        End Function

    End Class
End Namespace


