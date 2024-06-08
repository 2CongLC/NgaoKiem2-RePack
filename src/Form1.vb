Imports System.IO
Imports System.Net.Http.Headers
Imports System.Text

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "(*.swf)|*.swf"
        SaveFileDialog1.Filter = "(*.bin)|*.bin"
        If OpenFileDialog1.ShowDialog = DialogResult.OK AndAlso SaveFileDialog1.ShowDialog = DialogResult.OK Then
            encryptSwf(OpenFileDialog1.FileName, SaveFileDialog1.FileName)
            MessageBox.Show("Đã xong !")
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        OpenFileDialog1.Filter = "(*.bin)|*.bin"
        SaveFileDialog1.Filter = "(*.swf)|*.swf"
        If OpenFileDialog1.ShowDialog = DialogResult.OK AndAlso SaveFileDialog1.ShowDialog = DialogResult.OK Then
            decryptSwf(OpenFileDialog1.FileName, SaveFileDialog1.FileName)
            MessageBox.Show("Đã xong !")
        End If
    End Sub
    Private Sub encryptSwf(inFile As String, outFile As String, Optional key As String = "123")
        Dim param1 As ByteArray = New ByteArray(File.ReadAllBytes(inFile))
        Dim param2 As ByteArray = New ByteArray()
        param2.WriteUTFBytes(key)
        Dim count As Integer = 10 'Khu vực mã hóa 10 byte đầu tiên
        If param1.Length < count Then
            count = param1.Length
        End If
        Dim i As Integer = 0
        While i < count
            Dim bytes1 As Byte() = param1.ToArray()
            Dim bytes2 As Byte() = param2.ToArray()
            bytes1(i) = bytes1(i) Xor bytes2(i Mod param2.Length) 'Tiến hành mã hóa
            param1.WriteByte(bytes1(i))
            i += 1
        End While
        File.WriteAllBytes(outFile, param1.ToArray())
    End Sub
    Private Sub decryptSwf(inFile As String, outFile As String, Optional key As String = "123")
        Dim param1 As ByteArray = New ByteArray(File.ReadAllBytes(inFile))
        Dim param2 As ByteArray = New ByteArray()
        param2.WriteUTFBytes(key)
        Dim count As Integer = 10 'Khu vực mã hóa 10 byte đầu tiên
        If param1.Length < count Then
            count = param1.Length
        End If
        Dim i As Integer = 0
        While i < count
            Dim bytes1 As Byte() = param1.ToArray()
            Dim bytes2 As Byte() = param2.ToArray()
            bytes1(i) = bytes1(i) Xor bytes2(i Mod param2.Length) 'Tiến hành giải mã
            param1.WriteByte(bytes1(i))
            i += 1
        End While
        File.WriteAllBytes(outFile, param1.ToArray())
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://2conglc-vn.blogspot.com/")
    End Sub
End Class
