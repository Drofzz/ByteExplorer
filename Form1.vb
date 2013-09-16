Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Length > 0 Then
            Dim b As List(Of Byte) = New SpringObject(TextBox1.Text).Bytes
            Dim i As Integer = 0
            ListView1.Items.Clear()
            For Each bs As Byte In b
                i = i + 1
                Dim lvitem As New ListViewItem(bs)
                lvitem.Name = "Position"
                lvitem.Text = i
                lvitem.BackColor = Color.Black
                lvitem.ForeColor = Color.Gold
                Dim data As New ListViewItem.ListViewSubItem()
                data.Name = "ByteData"
                data.Text = bs
                Dim used As New ListViewItem.ListViewSubItem()
                used.Name = "Used"
                used.Text = "0"
                lvitem.SubItems.Add(data)
                lvitem.SubItems.Add(used)
                ListView1.Items.Add(lvitem)
            Next
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim items As ListView.SelectedListViewItemCollection = ListView1.SelectedItems
        Dim nums As String = ""
        For Each lwi As ListViewItem In items
            nums &= lwi.SubItems("Position").Text & ","
        Next
        For Each lwi As ListViewItem In items
            lwi.BackColor = Color.DarkCyan
            lwi.ForeColor = Color.AliceBlue
            lwi.SubItems("Used").Text = nums
        Next
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        For Each lwi As ListViewItem In ListView1.SelectedItems
            lwi.BackColor = Color.Black
            lwi.ForeColor = Color.Gold
            lwi.SubItems("Used").Text = "0"
        Next
    End Sub
End Class
