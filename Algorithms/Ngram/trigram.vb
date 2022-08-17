Imports System
Imports System.Text
Imports System.Collections.Generic
Imports System.Linq

'converted from the C# version via https://converter.telerik.com/, it was tested but still, review it before production

Public Class trgm
    Private Shared Function Clamp(ByVal val As Integer, ByVal min As Integer, ByVal max As Integer) As Integer
        If val < min Then
            Return min
        ElseIf val > max Then
            Return max
        End If

        Return val
    End Function

    Private Shared Function genTrigrams(ByVal word As String, ByVal Optional unique As Boolean = False) As String()
        Dim trigrams As List(Of String) = New List(Of String)()
        word = word.Replace(" ", "")
        word = " " & word.Trim().ToLower() & " "

        For i As Integer = 0 To word.Length - 1
            Dim trgm = word.Substring(i, Clamp(3, 0, word.Length - i))

            If Not (unique AndAlso trigrams.Contains(trgm)) Then
                If trgm <> "" AndAlso trgm <> " " Then trigrams.Add(trgm)
            End If
        Next

        Return trigrams.ToArray()
    End Function

    Public Shared Function trgmRatio(ByVal query As String, ByVal word As String) As Single
        Dim querytrgm = genTrigrams(query, unique:=True)
        Dim wordtrgm = genTrigrams(word)
        Dim matches As Integer = 0

        For Each item In querytrgm
            matches += wordtrgm.Count(Function(x) x = item)
        Next

        Return (matches / CSng(wordtrgm.Length))
    End Function
End Class
