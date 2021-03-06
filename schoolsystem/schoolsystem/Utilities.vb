﻿Imports System.Security.Cryptography
Imports System.Text

Namespace Utilities

    Public Class HashFunc

        Public Function MD5(ByVal strString As String) As String
            Dim MD5g As New MD5CryptoServiceProvider
            Dim Data As Byte()
            Dim Result As Byte()
            Dim Res As String = ""
            Dim Tmp As String = ""

            Data = Encoding.ASCII.GetBytes(strString)
            Result = MD5g.ComputeHash(Data)
            For i As Integer = 0 To Result.Length - 1
                Tmp = Hex(Result(i))
                If Len(Tmp) = 1 Then Tmp = "0" & Tmp
                Res += Tmp
            Next
            Return Res
        End Function

    End Class

End Namespace
