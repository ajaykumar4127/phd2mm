Imports phd2mm.Form1_phd2mm

Public Class Form4_MoreInfo
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles CloseForm4Button.Click
        MyBase.Close()
    End Sub

    Private Sub Form4_MoreInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ThemeManager.ApplyTheme(Me)
    End Sub
End Class