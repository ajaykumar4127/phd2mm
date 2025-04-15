Public Class Form5_ModRandomizationOptions

    Public randomizationMode As String
    Public categoryOfModsToRandomize As String
    Public confirm As Boolean = False

    Private Sub Form5_ModRandomizationOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Class1.ThemeManager.ApplyTheme(Me)
        Select Case randomizationMode
            Case "OnlyAddNoGuarantee"
                RadioButton1.Checked = True
            Case "OnlyAddGuaranteeOne"
                RadioButton2.Checked = True
            Case "AddRemoveNoGuarantee"
                RadioButton3.Checked = True
            Case "AddRemoveGuaranteeOne"
                RadioButton4.Checked = True
        End Select
    End Sub

    Private Sub Form5_CancelButton_Click(sender As Object, e As EventArgs) Handles Form5_CancelButton.Click
        Close()
    End Sub
    Private Sub Form5_ConfirmButton_Click(sender As Object, e As EventArgs) Handles Form5_ConfirmButton.Click
        confirm = True
        Close()
    End Sub

    Private Sub MR_RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged, RadioButton2.CheckedChanged,
        RadioButton3.CheckedChanged, RadioButton4.CheckedChanged
        If RadioButton1.Checked Then
            randomizationMode = "OnlyAddNoGuarantee"
        ElseIf RadioButton2.Checked Then
            randomizationMode = "OnlyAddGuaranteeOne"
        ElseIf RadioButton3.Checked Then
            randomizationMode = "AddRemoveNoGuarantee"
        ElseIf RadioButton4.Checked Then
            randomizationMode = "AddRemoveGuaranteeOne"
        End If
    End Sub

End Class