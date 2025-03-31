Imports System.Text.RegularExpressions
Imports phd2mm.Form1_phd2mm
Public Class Form2_CreateNewProfile

    Public lightDarkMode As String
    Public newProfileName As String
    Public invalidCharsPattern As String = "[\\/:*?""<>|]"
    Public reservedNames As String() = {"CON", "PRN", "AUX", "NUL", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"}

    Private Sub Form2_CreateNewProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Class1.ThemeManager.ApplyTheme(Me)
    End Sub

    Private Sub CancelCreateProfile_button_Click(sender As Object, e As EventArgs) Handles CancelCreateProfile_button.Click
        Close()
    End Sub

    Private Sub CreateNewProfile_button_Click(sender As Object, e As EventArgs) Handles CreateNewProfile_button.Click
        Dim profileName As String = ProfileName_TextBox.Text
        If String.IsNullOrEmpty(profileName) Or String.IsNullOrWhiteSpace(profileName) Then
            MessageBox.Show("Profile name cannot be empty!" & vbCrLf & "Please enter a valid profile name.")
        ElseIf Regex.IsMatch(profileName, invalidCharsPattern) Then
            MessageBox.Show("Profile name cannot include the following characters: \/:*?""<>|" & vbCrLf & "Please enter a valid profile name.")
        ElseIf reservedNames.Contains(profileName.ToUpper()) Then
            MessageBox.Show("Profile name cannot be Windows reserved file names!" & vbCrLf &
                            "These include: CON, PRN, AUX, NUL, COM1, COM2, COM3, COM4, COM5, COM6, COM7, COM8, COM9, LPT1, LPT2, LPT3, LPT4, LPT5, LPT6, LPT7, LPT8, LPT9" & vbCrLf &
                            "Please enter a valid profile name.")
        Else
            newProfileName = ProfileName_TextBox.Text
            Close()
        End If
    End Sub


End Class