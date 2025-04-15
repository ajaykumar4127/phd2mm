<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3_InstallMods
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        ProgressBar1 = New ProgressBar()
        AmountOfModsFinishedIntalling_Label = New Label()
        Label3 = New Label()
        TotalAmountOfModsToBeInstalled_Label = New Label()
        Finish_Button = New Button()
        CurrentlyInstalledProfileName_Label = New Label()
        Label1 = New Label()
        InstallationStatus_TextBox = New TextBox()
        Label2 = New Label()
        SuspendLayout()
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(12, 70)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(866, 23)
        ProgressBar1.TabIndex = 1
        ' 
        ' AmountOfModsFinishedIntalling_Label
        ' 
        AmountOfModsFinishedIntalling_Label.Font = New Font("Segoe UI", 12F)
        AmountOfModsFinishedIntalling_Label.Location = New Point(750, 44)
        AmountOfModsFinishedIntalling_Label.Name = "AmountOfModsFinishedIntalling_Label"
        AmountOfModsFinishedIntalling_Label.Size = New Size(50, 23)
        AmountOfModsFinishedIntalling_Label.TabIndex = 2
        AmountOfModsFinishedIntalling_Label.Text = "1000"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F)
        Label3.Location = New Point(806, 44)
        Label3.Name = "Label3"
        Label3.Size = New Size(16, 21)
        Label3.TabIndex = 3
        Label3.Text = "/"
        ' 
        ' TotalAmountOfModsToBeInstalled_Label
        ' 
        TotalAmountOfModsToBeInstalled_Label.Font = New Font("Segoe UI", 12F)
        TotalAmountOfModsToBeInstalled_Label.Location = New Point(828, 44)
        TotalAmountOfModsToBeInstalled_Label.Name = "TotalAmountOfModsToBeInstalled_Label"
        TotalAmountOfModsToBeInstalled_Label.Size = New Size(50, 23)
        TotalAmountOfModsToBeInstalled_Label.TabIndex = 4
        TotalAmountOfModsToBeInstalled_Label.Text = "2000"
        ' 
        ' Finish_Button
        ' 
        Finish_Button.Font = New Font("Segoe UI", 12F)
        Finish_Button.Location = New Point(802, 487)
        Finish_Button.Name = "Finish_Button"
        Finish_Button.Size = New Size(76, 38)
        Finish_Button.TabIndex = 6
        Finish_Button.Text = "Finish"
        Finish_Button.UseVisualStyleBackColor = True
        ' 
        ' CurrentlyInstalledProfileName_Label
        ' 
        CurrentlyInstalledProfileName_Label.Font = New Font("Segoe UI", 12F)
        CurrentlyInstalledProfileName_Label.Location = New Point(310, 20)
        CurrentlyInstalledProfileName_Label.Name = "CurrentlyInstalledProfileName_Label"
        CurrentlyInstalledProfileName_Label.Size = New Size(498, 24)
        CurrentlyInstalledProfileName_Label.TabIndex = 7
        CurrentlyInstalledProfileName_Label.Text = "profile"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(12, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(292, 21)
        Label1.TabIndex = 8
        Label1.Text = "Installing Helldivers 2 Mods from profile:"
        ' 
        ' InstallationStatus_TextBox
        ' 
        InstallationStatus_TextBox.Location = New Point(12, 99)
        InstallationStatus_TextBox.Multiline = True
        InstallationStatus_TextBox.Name = "InstallationStatus_TextBox"
        InstallationStatus_TextBox.ReadOnly = True
        InstallationStatus_TextBox.ScrollBars = ScrollBars.Both
        InstallationStatus_TextBox.Size = New Size(866, 382)
        InstallationStatus_TextBox.TabIndex = 9
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.Location = New Point(630, 44)
        Label2.Name = "Label2"
        Label2.Size = New Size(114, 21)
        Label2.TabIndex = 10
        Label2.Text = "Installed Mods:"
        ' 
        ' Form3_InstallMods
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(890, 537)
        Controls.Add(Label2)
        Controls.Add(InstallationStatus_TextBox)
        Controls.Add(Label1)
        Controls.Add(CurrentlyInstalledProfileName_Label)
        Controls.Add(Finish_Button)
        Controls.Add(TotalAmountOfModsToBeInstalled_Label)
        Controls.Add(Label3)
        Controls.Add(AmountOfModsFinishedIntalling_Label)
        Controls.Add(ProgressBar1)
        Name = "Form3_InstallMods"
        Text = "Installing Helldivers 2 Mods"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents AmountOfModsFinishedIntalling_Label As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TotalAmountOfModsToBeInstalled_Label As Label
    Friend WithEvents Finish_Button As Button
    Friend WithEvents CurrentlyInstalledProfileName_Label As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents InstallationStatus_TextBox As TextBox
    Friend WithEvents Label2 As Label
End Class
