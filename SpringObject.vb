Public Class SpringObject

    Private _chunks As New List(Of Object)
    Private _bytes As New List(Of Byte)

    Public Sub New(ByVal decimals As String)
        _bytes = Conv2Byte(decimals)
    End Sub

    Private Shared Function Conv2Byte(decimals As String) As List(Of Byte)
        Dim bytes As New List(Of Byte)
        Dim decs As New List(Of String)(decimals.Split(" "))

        For Each dec As String In decs
            bytes.Add(Byte.Parse(dec))
        Next
        Return bytes
    End Function

    Public ReadOnly Property Bytes As List(Of Byte)
        Get
            Return _bytes
        End Get
    End Property
End Class
