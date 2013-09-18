Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Length > 0 Then
            Dim b As List(Of Byte) = New SpringObject(TextBox1.Text).Bytes
            Dim i As Integer = 0
            ListView1.Items.Clear()
            For Each bs As Byte In b
                Dim lvitem As New ListViewItem(bs)
                lvitem.Name = "Position"
                lvitem.Text = i
                lvitem.Tag = i
                lvitem.BackColor = Color.Black
                lvitem.ForeColor = Color.Gold
                Dim data As New ListViewItem.ListViewSubItem()
                data.Name = "ByteData"
                data.Text = bs
                data.Tag = bs
                Dim used As New ListViewItem.ListViewSubItem()
                used.Name = "Used"
                used.Text = "0"
                Dim type As New ListViewItem.ListViewSubItem()
                type.Name = "Type"
                type.Text = "Undefined"
                Dim value As New ListViewItem.ListViewSubItem()
                value.Name = "Value"
                value.Text = ""
                lvitem.SubItems.Add(data)
                lvitem.SubItems.Add(used)
                lvitem.SubItems.Add(type)
                lvitem.SubItems.Add(value)
                ListView1.Items.Add(lvitem)
                i = i + 1
            Next
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim items As ListView.SelectedListViewItemCollection = ListView1.SelectedItems
        If items.Count = 2 Or items.Count = 4 Or items.Count = 8 Then
            Dim nums As String = ""
            Dim startpos As Integer = items.Item(0).Tag
            Dim endpos As Integer = items.Item(items.Count - 1).Tag
            Dim r As New Random()
            Dim c As Color = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))
            If endpos - startpos = items.Count - 1 Then
                nums = startpos & "-" & endpos

                For Each lwi As ListViewItem In items
                    lwi.BackColor = c
                    lwi.ForeColor = ContrastColor(c)
                    lwi.SubItems("Used").Text = ""
                    lwi.SubItems("Type").Text = ""
                    lwi.SubItems("Value").Text = ""
                Next

                Select Case items.Count
                    Case 2
                        items.Item(0).SubItems("Used").Text = nums
                        items.Item(0).SubItems("Type").Text = "Unsigned Short"
                        items.Item(0).SubItems("Value").Text = SpringObject.getUShort(items.Item(0).SubItems("ByteData").Tag, _
                                                                                      items.Item(1).SubItems("ByteData").Tag)
                    Case 4
                        items.Item(0).SubItems("Used").Text = nums
                        items.Item(0).SubItems("Type").Text = "Unsigned Integer"
                        items.Item(0).SubItems("Value").Text = SpringObject.getUInteger(items.Item(0).SubItems("ByteData").Tag, _
                                                              items.Item(1).SubItems("ByteData").Tag, _
                                                              items.Item(2).SubItems("ByteData").Tag, _
                                                              items.Item(3).SubItems("ByteData").Tag)
                    Case 8
                        items.Item(0).SubItems("Used").Text = nums
                        items.Item(0).SubItems("Type").Text = "Unsigned Long"
                        items.Item(0).SubItems("Value").Text = SpringObject.getULong(items.Item(0).SubItems("ByteData").Tag, _
                                                              items.Item(1).SubItems("ByteData").Tag, _
                                                              items.Item(2).SubItems("ByteData").Tag, _
                                                              items.Item(3).SubItems("ByteData").Tag, _
                                                              items.Item(4).SubItems("ByteData").Tag, _
                                                              items.Item(5).SubItems("ByteData").Tag, _
                                                              items.Item(6).SubItems("ByteData").Tag, _
                                                              items.Item(7).SubItems("ByteData").Tag)
                End Select
            Else
                MessageBox.Show("The Bytes need to be adjecent to each other", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("And Unsigned Integer needs to be 2, 4 or 8 bytes long", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        For Each lwi As ListViewItem In ListView1.SelectedItems
            lwi.BackColor = Color.Black
            lwi.ForeColor = Color.Gold
            lwi.SubItems("Used").Text = "0"
            lwi.SubItems("Type").Text = "Undefined"
            lwi.SubItems("Value").Text = ""
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim items As ListView.SelectedListViewItemCollection = ListView1.SelectedItems
        If items.Count = 1 Then
            Dim r As New Random()
            Dim c As Color = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))
            Dim lwi As ListViewItem = items.Item(0)
            lwi.BackColor = c
            lwi.ForeColor = ContrastColor(c)
            lwi.SubItems("Used").Text = "1"
            lwi.SubItems("Type").Text = "Single Byte"
            lwi.SubItems("Value").Text = lwi.SubItems("ByteData").Tag
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim items As ListView.SelectedListViewItemCollection = ListView1.SelectedItems
        Dim startpos As Integer = items.Item(0).Tag
        Dim endpos As Integer = items.Item(items.Count - 1).Tag
        Dim nums As String = ""
        Dim r As New Random()
        Dim c As Color = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))

        If items.Count > 0 Then
            Dim bytearray As New List(Of Byte)
            nums = startpos & "-" & endpos
            For Each lwi As ListViewItem In items
                lwi.BackColor = c
                lwi.ForeColor = ContrastColor(c)
                lwi.SubItems("Used").Text = ""
                lwi.SubItems("Type").Text = ""
                lwi.SubItems("Value").Text = ""
                If lwi.SubItems("ByteData").Tag <> 0 Then
                    bytearray.Add(lwi.SubItems("ByteData").Tag)
                End If
            Next

            items.Item(0).SubItems("Used").Text = nums
            items.Item(0).SubItems("Type").Text = "String(UTF-8)"

            Dim Text As String = System.Text.Encoding.UTF8.GetString(bytearray.ToArray)
            Dim lines As String() = Text.Split(Environment.NewLine)

            For i As Integer = 0 To lines.Length - 1
                items.Item(i).SubItems("Value").Text = lines(i)
            Next
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim items As ListView.SelectedListViewItemCollection = ListView1.SelectedItems
        Dim startpos As Integer = items.Item(0).Tag
        Dim endpos As Integer = items.Item(items.Count - 1).Tag
        Dim nums As String = ""
        Dim r As New Random()
        Dim c As Color = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))

        If items.Count > 0 Then
            Dim bytearray As New List(Of Byte)
            nums = startpos & "-" & endpos
            For Each lwi As ListViewItem In items
                lwi.BackColor = c
                lwi.ForeColor = ContrastColor(c)
                lwi.SubItems("Used").Text = ""
                lwi.SubItems("Type").Text = ""
                lwi.SubItems("Value").Text = ""
                bytearray.Add(lwi.SubItems("ByteData").Tag)
            Next

            items.Item(0).SubItems("Used").Text = nums
            items.Item(0).SubItems("Type").Text = "String(UTF-16)"

            Dim Text As String = System.Text.Encoding.BigEndianUnicode.GetString(bytearray.ToArray)
            Dim lines As String() = Text.Split(Environment.NewLine)

            For i As Integer = 0 To lines.Length - 1
                items.Item(i).SubItems("Value").Text = lines(i)
            Next
        End If
    End Sub

    Private Function ContrastColor(color As Color) As Color
        Dim d = 0

        Dim a = 1 - (0.299 * Color.R + 0.587 * Color.G + 0.114 * Color.B) / 255

        If (a < 0.5) Then
            d = 0
        Else
            d = 255
        End If

        Return color.FromArgb(d, d, d)
    End Function
End Class
