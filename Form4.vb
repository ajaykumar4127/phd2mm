Imports System.DirectoryServices
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports phd2mm.Class3

Public Class Form4_CreateOrDuplicateTheme

    Public currentGlobalTheme As ThemeInfo
    Public createOrDuplicateOption As String
    Public themeToDuplicate As String
    Public newThemeName As String
    Public invalidCharsPattern As String = "[\\/:*?""<>|]"
    Public reservedNames As String() = {"CON", "PRN", "AUX", "NUL", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"}

    Private Sub Form4_CreateOrDuplicateTheme_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If createOrDuplicateOption = "createTheme" Then
            Me.Text = "Create Theme"
            Label1.Text = "Creating a new theme:"
            Label3.Text = ""
            Label3.Visible = False
        ElseIf createOrDuplicateOption = "duplicateTheme" Then
            Me.Text = "Duplicate Theme"
            Label1.Text = "Duplicating theme:"
            Label3.Text = themeToDuplicate
            Label3.Visible = True
        End If
        Class3.ThemeManager.ApplyThemeToForm(Me, currentGlobalTheme)
    End Sub

    Private Sub Form4_Cancel_Button_Click(sender As Object, e As EventArgs) Handles Form4_Cancel_Button.Click
        Close()
    End Sub

    Private Sub Form4_CreateNewTheme_Button_Click(sender As Object, e As EventArgs) Handles Form4_CreateNewTheme_Button.Click
        If String.IsNullOrEmpty(NewThemeName_TextBox.Text) Or String.IsNullOrWhiteSpace(NewThemeName_TextBox.Text) Then
            MessageBox.Show("Theme name cannot be empty!" & vbCrLf & "Please enter a valid theme name.")
        ElseIf Regex.IsMatch(NewThemeName_TextBox.Text, invalidCharsPattern) Then
            MessageBox.Show("Theme name cannot include the following characters: \/:*?""<>|" & vbCrLf & "Please enter a valid theme name.")
        ElseIf reservedNames.Contains(NewThemeName_TextBox.Text.ToUpper()) Then
            MessageBox.Show("Theme name cannot be Windows reserved file names!" & vbCrLf &
                            "These include: CON, PRN, AUX, NUL, COM1, COM2, COM3, COM4, COM5, COM6, COM7, COM8, COM9, LPT1, LPT2, LPT3, LPT4, LPT5, LPT6, LPT7, LPT8, LPT9" & vbCrLf &
                            "Please enter a valid theme name.")
        Else
            newThemeName = NewThemeName_TextBox.Text
            Close()
        End If
    End Sub

End Class