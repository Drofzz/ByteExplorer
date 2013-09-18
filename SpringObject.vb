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

    Public Shared Function getULong(ByVal b1, ByVal b2, ByVal b3, ByVal b4, ByVal b5, ByVal b6, ByVal b7, ByVal b8) As ULong
        Dim vulong As ULong = CType(b1, ULong) << 56 Or CType(b2, ULong) << 48 Or CType(b3, ULong) << 40 Or CType(b4, ULong) << 32 Or CType(b5, ULong) << 24 Or CType(b6, ULong) << 16 Or CType(b7, ULong) << 8 Or CType(b8, ULong) << 0
        Return vulong
    End Function

    Public Shared Function getUInteger(ByVal b1, ByVal b2, ByVal b3, ByVal b4) As UInteger
        Dim vuint As UInt32 = CType(b1, UInteger) << 24 _
                              Or CType(b2, UInteger) << 16 _
                              Or CType(b3, UInteger) << 8 _
                              Or CType(b4, UInteger) << 0

        Return vuint
    End Function

    Public Shared Function getUShort(ByVal b1, ByVal b2) As UShort
        Dim vshort As UInt32 = CType(b1, UShort) << 8 Or CType(b2, UShort) << 0
        Return vshort
    End Function
End Class
