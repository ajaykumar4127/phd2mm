Imports System.IO
Imports System.Text.Json

Public Class Class3
    Public Class FormResizer
        Private ReadOnly form As Form
        Private ReadOnly originalWidth As Integer
        Private ReadOnly originalHeight As Integer

        Private originalSizes As New Dictionary(Of Control, Size)
        Private originalPositions As New Dictionary(Of Control, Point)
        Private originalFonts As New Dictionary(Of Control, Font)

        Public Sub New(targetForm As Form)
            form = targetForm
            originalWidth = form.Width
            originalHeight = form.Height

            ' Save all original control info recursively
            SaveOriginalControlMetrics(form)

            AddHandler form.Resize, AddressOf OnFormResize
        End Sub

        Private Sub SaveOriginalControlMetrics(container As Control)
            For Each ctrl As Control In container.Controls
                originalSizes(ctrl) = ctrl.Size
                originalPositions(ctrl) = ctrl.Location
                originalFonts(ctrl) = ctrl.Font

                If ctrl.HasChildren Then
                    SaveOriginalControlMetrics(ctrl)
                End If
            Next
        End Sub

        Private Sub OnFormResize(sender As Object, e As EventArgs)
            Dim scaleX As Double = form.Width / originalWidth
            Dim scaleY As Double = form.Height / originalHeight

            If form.Width > originalWidth AndAlso form.Height > originalHeight Then
                ResizeAllControls(form, scaleX, scaleY)
            Else
                ResetAllControls(form)
            End If
        End Sub

        Private Sub ResizeAllControls(container As Control, scaleX As Double, scaleY As Double)
            For Each ctrl As Control In container.Controls
                If originalSizes.ContainsKey(ctrl) Then
                    ctrl.Width = CInt(originalSizes(ctrl).Width * scaleX)
                    ctrl.Height = CInt(originalSizes(ctrl).Height * scaleY)
                    ctrl.Left = CInt(originalPositions(ctrl).X * scaleX)
                    ctrl.Top = CInt(originalPositions(ctrl).Y * scaleY)

                    ' Do NOT scale font anymore
                    ' Dim originalFont = originalFonts(ctrl)
                    ' ctrl.Font = New Font(originalFont.FontFamily, originalFont.Size * CSng(Math.Min(scaleX, scaleY)), originalFont.Style)
                End If

                If ctrl.HasChildren Then
                    ResizeAllControls(ctrl, scaleX, scaleY)
                End If
            Next
        End Sub


        Private Sub ResetAllControls(container As Control)
            For Each ctrl As Control In container.Controls
                If originalSizes.ContainsKey(ctrl) Then
                    ctrl.Size = originalSizes(ctrl)
                    ctrl.Location = originalPositions(ctrl)
                    ctrl.Font = originalFonts(ctrl)
                End If

                If ctrl.HasChildren Then
                    ResetAllControls(ctrl)
                End If
            Next
        End Sub
    End Class

    Public Class ThemeInfo
        Public Property ThemeName As String
        Public Property ThemeImagePath As String
        Public Property Form_BackColor As String
        Public Property Form_ForeColor As String
        Public Property TabControl_BackColor As String
        Public Property TabControl_ForeColor As String
        Public Property TabPage_BackColor As String
        Public Property TabPage_ForeColor As String
        Public Property Label_BackColor As String
        Public Property Label_ForeColor As String
        Public Property TextBox_BackColor As String
        Public Property TextBox_ForeColor As String
        Public Property ComboBox_BackColor As String
        Public Property ComboBox_ForeColor As String
        Public Property Button_BackColor As String
        Public Property Button_ForeColor As String
        Public Property ListBox_BackColor As String
        Public Property ListBox_ForeColor As String
        Public Property GroupBox_BackColor As String
        Public Property GroupBox_ForeColor As String
        Public Property DataGridView_BackColor As String
        Public Property DataGridView_ForeColor As String
        Public Property DGVGrid_Color As String
        Public Property DGVColumnHeader_BackColor As String
        Public Property DGVColumnHeader_ForeColor As String
        Public Property DGVRowHeader_BackColor As String
        Public Property DGVRowHeader_ForeColor As String
        Public Property DGVDefaultCell_BackColor As String
        Public Property DGVDefaultCell_ForeColor As String
        Public Property DGVAlternatingRows_BackColor As String
        Public Property DGVAlternatingRows_ForeColor As String
        Public Sub New(col1 As String, col2 As String, col3 As String, col4 As String,
                       col5 As String, col6 As String, col7 As String, col8 As String,
                       col9 As String, col10 As String, col11 As String, col12 As String,
                       col13 As String, col14 As String, col15 As String, col16 As String,
                       col17 As String, col18 As String, col19 As String, col20 As String,
                       col21 As String, col22 As String, col23 As String, col24 As String,
                       col25 As String, col26 As String, col27 As String, col28 As String,
                       col29 As String, col30 As String, col31 As String)
            ThemeName = col1
            ThemeImagePath = col2
            Form_BackColor = col3
            Form_ForeColor = col4
            TabControl_BackColor = col5
            TabControl_ForeColor = col6
            TabPage_BackColor = col7
            TabPage_ForeColor = col8
            Label_BackColor = col9
            Label_ForeColor = col10
            TextBox_BackColor = col11
            TextBox_ForeColor = col12
            ComboBox_BackColor = col13
            ComboBox_ForeColor = col14
            Button_BackColor = col15
            Button_ForeColor = col16
            ListBox_BackColor = col17
            ListBox_ForeColor = col18
            GroupBox_BackColor = col19
            GroupBox_ForeColor = col20
            DataGridView_BackColor = col21
            DataGridView_ForeColor = col22
            DGVGrid_Color = col23
            DGVColumnHeader_BackColor = col24
            DGVColumnHeader_ForeColor = col25
            DGVRowHeader_BackColor = col26
            DGVRowHeader_ForeColor = col27
            DGVDefaultCell_BackColor = col28
            DGVDefaultCell_ForeColor = col29
            DGVAlternatingRows_BackColor = col30
            DGVAlternatingRows_ForeColor = col31
        End Sub
        Public Function Clone() As ThemeInfo
            Return New ThemeInfo(Me.ThemeName, Me.ThemeImagePath, Me.Form_BackColor, Me.Form_ForeColor,
                                 Me.TabControl_BackColor, Me.TabControl_ForeColor, Me.TabPage_BackColor,
                                 Me.TabPage_ForeColor, Me.Label_BackColor, Me.Label_ForeColor,
                                 Me.TextBox_BackColor, Me.TextBox_ForeColor, Me.ComboBox_BackColor,
                                 Me.ComboBox_ForeColor, Me.Button_BackColor, Me.Button_ForeColor,
                                 Me.ListBox_BackColor, Me.ListBox_ForeColor,
                                 Me.GroupBox_BackColor, Me.GroupBox_ForeColor,
                                 Me.DataGridView_BackColor,
                                 Me.DataGridView_ForeColor, Me.DGVGrid_Color, Me.DGVColumnHeader_BackColor,
                                 Me.DGVColumnHeader_ForeColor, Me.DGVRowHeader_BackColor, Me.DGVRowHeader_ForeColor,
                                 Me.DGVDefaultCell_BackColor, Me.DGVDefaultCell_ForeColor,
                                 Me.DGVAlternatingRows_BackColor, Me.DGVAlternatingRows_ForeColor)
        End Function
    End Class

    Public Class ProfileSpecificTheme
        Public Property ProfileName As String
        Public Property ThemeName As String
        Public Sub New(col1 As String, col2 As String)
            ProfileName = col1
            ThemeName = col2
        End Sub
    End Class

    Public Class ThemeManager
        Public Shared Sub InitializeDefaultThemes(themesDictionary As Dictionary(Of String, Class3.ThemeInfo))  ' BackColor then ForeColor
            themesDictionary.Add("phd2mm_light", New ThemeInfo("phd2mm_light", "", "#F0F0F0", "#000000", "#FFFFFF", "#000000", ' Theme Name, ImagePath, Form Colors, TabControl colors
                                    "#F0F0F0", "#000000", "#F0F0F0", "#000000", "#FFFFFF", "#000000", ' TabPage colors, Label colors, TextBox colors
                                    "#FFFFFF", "#000000", "#E6E6E6", "#000000", "#FFFFFF", "#000000", ' ComboBox colors, Button colors, ListBox colors
                                    "#F0F0F0", "#000000",                                               ' GroupBox colors
                                    "#FFFFFF", "#FFFFFF", "#C8C8C8", "#E6E6E6", "#000000",  ' DataGridView colors, DGVGrid color, DGVColumnHeader colors
                                    "#F0F0F0", "#000000", "#FFFFFF", "#000000", "#F0F0F0", "#000000") ' DGVRowHeader colors, DGVDefaultCell colors, DGVAlternatingRows colors
                                    )
            themesDictionary.Add("phd2mm_dark", New ThemeInfo("phd2mm_dark", "", "#2A2A2A", "#FFFFFF", "#2A2A2A", "#FFFFFF",
                                   "#2A2A2A", "#FFFFFF", "#2A2A2A", "#FFFFFF", "#2A2A2A", "#FFFFFF",
                                   "#2A2A2A", "#FFFFFF", "#3C3C3C", "#FFFFFF", "#333333", "#FFFFFF",
                                   "#2A2A2A", "#FFFFFF",
                                    "#2A2A2A", "#333333", "#3C3C3C", "#3C3C3C", "#FFFFFF",
                                   "#3C3C3C", "#FFFFFF", "#333333", "#FFFFFF", "#2D2D2D", "#FFFFFF")
                                   )
        End Sub

        Public Shared Sub ReadThemes(themesDictionary As Dictionary(Of String, Class3.ThemeInfo), themesDirectoryPath As String)
            ' Get all the theme JSON files in the specified directory
            Dim themeFiles As String() = Directory.GetFiles(themesDirectoryPath, "*.json")

            For Each themeFile In themeFiles
                ' Read the content of the JSON file
                Dim json As String = File.ReadAllText(themeFile)

                ' Deserialize the JSON content into a dictionary that matches the structure of your theme
                Dim themeJson As Dictionary(Of String, String) = JsonSerializer.Deserialize(Of Dictionary(Of String, String))(json)

                If themeJson IsNot Nothing Then
                    ' Extract the ThemeName from the file name (without extension)
                    Dim themeName As String = Path.GetFileNameWithoutExtension(themeFile)

                    ' Create a new ThemeInfo object from the deserialized JSON data
                    Dim theme As New Class3.ThemeInfo(
                themeName,
                themeJson.GetValueOrDefault("ThemeImagePath", String.Empty),
                themeJson.GetValueOrDefault("Form_BackColor", String.Empty),
                themeJson.GetValueOrDefault("Form_ForeColor", String.Empty),
                themeJson.GetValueOrDefault("TabControl_BackColor", String.Empty),
                themeJson.GetValueOrDefault("TabControl_ForeColor", String.Empty),
                themeJson.GetValueOrDefault("TabPage_BackColor", String.Empty),
                themeJson.GetValueOrDefault("TabPage_ForeColor", String.Empty),
                themeJson.GetValueOrDefault("Label_BackColor", String.Empty),
                themeJson.GetValueOrDefault("Label_ForeColor", String.Empty),
                themeJson.GetValueOrDefault("TextBox_BackColor", String.Empty),
                themeJson.GetValueOrDefault("TextBox_ForeColor", String.Empty),
                themeJson.GetValueOrDefault("ComboBox_BackColor", String.Empty),
                themeJson.GetValueOrDefault("ComboBox_ForeColor", String.Empty),
                themeJson.GetValueOrDefault("Button_BackColor", String.Empty),
                themeJson.GetValueOrDefault("Button_ForeColor", String.Empty),
                themeJson.GetValueOrDefault("ListBox_BackColor", String.Empty),
                themeJson.GetValueOrDefault("ListBox_ForeColor", String.Empty),
                themeJson.GetValueOrDefault("GroupBox_BackColor", String.Empty),
                themeJson.GetValueOrDefault("GroupBox_ForeColor", String.Empty),
                themeJson.GetValueOrDefault("DataGridView_BackColor", String.Empty),
                themeJson.GetValueOrDefault("DataGridView_ForeColor", String.Empty),
                themeJson.GetValueOrDefault("DGVGrid_Color", String.Empty),
                themeJson.GetValueOrDefault("DGVColumnHeader_BackColor", String.Empty),
                themeJson.GetValueOrDefault("DGVColumnHeader_ForeColor", String.Empty),
                themeJson.GetValueOrDefault("DGVRowHeader_BackColor", String.Empty),
                themeJson.GetValueOrDefault("DGVRowHeader_ForeColor", String.Empty),
                themeJson.GetValueOrDefault("DGVDefaultCell_BackColor", String.Empty),
                themeJson.GetValueOrDefault("DGVDefaultCell_ForeColor", String.Empty),
                themeJson.GetValueOrDefault("DGVAlternatingRows_BackColor", String.Empty),
                themeJson.GetValueOrDefault("DGVAlternatingRows_ForeColor", String.Empty)
            )

                    ' Check if the theme already exists in the dictionary
                    If Not themesDictionary.ContainsKey(theme.ThemeName) Then
                        ' Add the theme to the dictionary using the theme name as the key
                        themesDictionary.Add(theme.ThemeName, theme)
                    Else
                        ' Optionally, you can update the existing theme if needed
                        ' themesDictionary(theme.ThemeName) = theme
                    End If
                End If
            Next
        End Sub

        Public Shared Sub OverwriteThemes(themesDictionary As Dictionary(Of String, Class3.ThemeInfo), themesDirectoryPath As String)
            themesDictionary.Remove("phd2mm_light")
            themesDictionary.Remove("phd2mm_dark")
            If themesDictionary IsNot Nothing AndAlso themesDictionary.Count > 0 Then

                Dim options As New JsonSerializerOptions()
                options.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                options.WriteIndented = True ' Ensure the JSON is indented for readability

                For Each themeEntry As KeyValuePair(Of String, ThemeInfo) In themesDictionary
                    Dim theme As Class3.ThemeInfo = themeEntry.Value
                    Dim tempThemeImagePath = theme.ThemeImagePath.Replace("\", "/")
                    ' Create a new anonymous object representing the theme info
                    Dim themeJson = New With {
                Key .ThemeName = theme.ThemeName,
                Key .ThemeImagePath = If(String.IsNullOrEmpty(tempThemeImagePath), "", tempThemeImagePath),
                Key .Form_BackColor = theme.Form_BackColor,
                Key .Form_ForeColor = theme.Form_ForeColor,
                Key .TabControl_BackColor = theme.TabControl_BackColor,
                Key .TabControl_ForeColor = theme.TabControl_ForeColor,
                Key .TabPage_BackColor = theme.TabPage_BackColor,
                Key .TabPage_ForeColor = theme.TabPage_ForeColor,
                Key .Label_BackColor = theme.Label_BackColor,
                Key .Label_ForeColor = theme.Label_ForeColor,
                Key .TextBox_BackColor = theme.TextBox_BackColor,
                Key .TextBox_ForeColor = theme.TextBox_ForeColor,
                Key .ComboBox_BackColor = theme.ComboBox_BackColor,
                Key .ComboBox_ForeColor = theme.ComboBox_ForeColor,
                Key .Button_BackColor = theme.Button_BackColor,
                Key .Button_ForeColor = theme.Button_ForeColor,
                Key .ListBox_BackColor = theme.ListBox_BackColor,
                Key .ListBox_ForeColor = theme.ListBox_ForeColor,
                Key .GroupBox_BackColor = theme.GroupBox_BackColor,
                Key .GroupBox_ForeColor = theme.GroupBox_ForeColor,
                Key .DataGridView_BackColor = theme.DataGridView_BackColor,
                Key .DataGridView_ForeColor = theme.DataGridView_ForeColor,
                Key .DGVGrid_Color = theme.DGVGrid_Color,
                Key .DGVColumnHeader_BackColor = theme.DGVColumnHeader_BackColor,
                Key .DGVColumnHeader_ForeColor = theme.DGVColumnHeader_ForeColor,
                Key .DGVRowHeader_BackColor = theme.DGVRowHeader_BackColor,
                Key .DGVRowHeader_ForeColor = theme.DGVRowHeader_ForeColor,
                Key .DGVDefaultCell_BackColor = theme.DGVDefaultCell_BackColor,
                Key .DGVDefaultCell_ForeColor = theme.DGVDefaultCell_ForeColor,
                Key .DGVAlternatingRows_BackColor = theme.DGVAlternatingRows_BackColor,
                Key .DGVAlternatingRows_ForeColor = theme.DGVAlternatingRows_ForeColor
            }

                    ' Serialize the theme info to JSON format (with indentation)
                    Dim json As String = JsonSerializer.Serialize(themeJson, options)

                    ' Write the theme to a separate file using the theme name (sanitized for file system)
                    Dim sanitizedThemeName As String = Path.Combine(themesDirectoryPath, theme.ThemeName & ".json")

                    Dim stopCommas As Boolean = False
                    Using writer As New StreamWriter(sanitizedThemeName)
                        ' Write each property on its own line
                        writer.WriteLine("{")
                        For Each propertyItem In themeJson.GetType().GetProperties()
                            If propertyItem.Name = "DGVAlternatingRows_ForeColor" Or stopCommas = True Then
                                stopCommas = True
                                writer.WriteLine("    """ & propertyItem.Name & """: """ & propertyItem.GetValue(themeJson)?.ToString() & """")
                            Else
                                writer.WriteLine("    """ & propertyItem.Name & """: """ & propertyItem.GetValue(themeJson)?.ToString() & """,")
                            End If
                        Next
                        writer.WriteLine("}")
                    End Using
                Next
            End If
        End Sub

        Public Shared Sub OverwriteSingleThemeFile(theme As Class3.ThemeInfo, themesDirectoryPath As String)
            If theme Is Nothing Then Exit Sub

            Dim options As New JsonSerializerOptions()
            options.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            options.WriteIndented = True

            Dim tempThemeImagePath = theme.ThemeImagePath.Replace("\", "/")

            Dim themeJson = New With {
        Key .ThemeName = theme.ThemeName,
        Key .ThemeImagePath = If(String.IsNullOrEmpty(tempThemeImagePath), "", tempThemeImagePath),
        Key .Form_BackColor = theme.Form_BackColor,
        Key .Form_ForeColor = theme.Form_ForeColor,
        Key .TabControl_BackColor = theme.TabControl_BackColor,
        Key .TabControl_ForeColor = theme.TabControl_ForeColor,
        Key .TabPage_BackColor = theme.TabPage_BackColor,
        Key .TabPage_ForeColor = theme.TabPage_ForeColor,
        Key .Label_BackColor = theme.Label_BackColor,
        Key .Label_ForeColor = theme.Label_ForeColor,
        Key .TextBox_BackColor = theme.TextBox_BackColor,
        Key .TextBox_ForeColor = theme.TextBox_ForeColor,
        Key .ComboBox_BackColor = theme.ComboBox_BackColor,
        Key .ComboBox_ForeColor = theme.ComboBox_ForeColor,
        Key .Button_BackColor = theme.Button_BackColor,
        Key .Button_ForeColor = theme.Button_ForeColor,
        Key .ListBox_BackColor = theme.ListBox_BackColor,
        Key .ListBox_ForeColor = theme.ListBox_ForeColor,
        Key .GroupBox_BackColor = theme.GroupBox_BackColor,
        Key .GroupBox_ForeColor = theme.GroupBox_ForeColor,
        Key .DataGridView_BackColor = theme.DataGridView_BackColor,
        Key .DataGridView_ForeColor = theme.DataGridView_ForeColor,
        Key .DGVGrid_Color = theme.DGVGrid_Color,
        Key .DGVColumnHeader_BackColor = theme.DGVColumnHeader_BackColor,
        Key .DGVColumnHeader_ForeColor = theme.DGVColumnHeader_ForeColor,
        Key .DGVRowHeader_BackColor = theme.DGVRowHeader_BackColor,
        Key .DGVRowHeader_ForeColor = theme.DGVRowHeader_ForeColor,
        Key .DGVDefaultCell_BackColor = theme.DGVDefaultCell_BackColor,
        Key .DGVDefaultCell_ForeColor = theme.DGVDefaultCell_ForeColor,
        Key .DGVAlternatingRows_BackColor = theme.DGVAlternatingRows_BackColor,
        Key .DGVAlternatingRows_ForeColor = theme.DGVAlternatingRows_ForeColor
    }

            Dim filePath As String = Path.Combine(themesDirectoryPath, theme.ThemeName & ".json")

            Using writer As New StreamWriter(filePath)
                writer.WriteLine("{")
                Dim properties = themeJson.GetType().GetProperties()
                For i = 0 To properties.Length - 1
                    Dim prop = properties(i)
                    Dim comma = If(i < properties.Length - 1, ",", "")
                    writer.WriteLine($"    ""{prop.Name}"": ""{prop.GetValue(themeJson)?.ToString() }""{comma}")
                Next
                writer.WriteLine("}")
            End Using
        End Sub

        Public Shared Sub PutThemesInThemes_ListboxAndComboBox(themesDictionary As Dictionary(Of String, Class3.ThemeInfo), Themes_Listbox As ListBox,
                                                               Themes_GlobalTheme_ComboBox As ComboBox)
            For Each themeEntry As KeyValuePair(Of String, Class3.ThemeInfo) In themesDictionary
                Themes_Listbox.Items.Add(themeEntry.Value.ThemeName)
                Themes_GlobalTheme_ComboBox.Items.Add(themeEntry.Value.ThemeName)
            Next
        End Sub

        Public Shared Sub CreateTheme(newThemeName As String, createOrDuplicateOption As String, themeToDuplicate As String,
                                      themesDictionary As Dictionary(Of String, Class3.ThemeInfo), Themes_Listbox As ListBox,
                                      Themes_GlobalTheme_ComboBox As ComboBox, Themes_ProfileSpecificThemes_DataGridView As DataGridView)
            If createOrDuplicateOption = "createTheme" Then
                themesDictionary.Add(newThemeName, New ThemeInfo(newThemeName, "", "#F0F0F0", "#000000", "#FFFFFF", "#000000", ' Theme Name, ImagePath, Form Colors, TabControl colors
                        "#F0F0F0", "#000000", "#F0F0F0", "#000000", "#FFFFFF", "#000000", ' TabPage colors, Label colors, TextBox colors
                        "#FFFFFF", "#000000", "#E6E6E6", "#000000", "#FFFFFF", "#000000", ' ComboBox colors, Button colors, ListBox colors
                        "#F0F0F0", "#000000",                                               ' GroupBox colors
                        "#FFFFFF", "#FFFFFF", "#C8C8C8", "#E6E6E6", "#000000",  ' DataGridView colors, DGVGrid color, DGVColumnHeader colors
                        "#F0F0F0", "#000000", "#FFFFFF", "#000000", "#F0F0F0", "#000000") ' DGVRowHeader colors, DGVDefaultCell colors, DGVAlternatingRows colors
                        )
            ElseIf createOrDuplicateOption = "duplicateTheme" Then
                Dim tempTheme As Class3.ThemeInfo = themesDictionary(themeToDuplicate)
                Dim clonedTheme As Class3.ThemeInfo = tempTheme.Clone()
                clonedTheme.ThemeName = newThemeName
                themesDictionary.Add(newThemeName, clonedTheme)
            End If
            Themes_Listbox.Items.Add(newThemeName)
            Themes_GlobalTheme_ComboBox.Items.Add(newThemeName)
            Dim themeDataGridViewComboBoxColumn As DataGridViewComboBoxColumn = Themes_ProfileSpecificThemes_DataGridView.Columns("Themes_ProfileSpecificThemes_DataGridView_Theme_Column")
            themeDataGridViewComboBoxColumn.Items.Add(newThemeName)
        End Sub

        ' This method applies the theme to all controls, including nested ones, in the provided form.
        Public Shared Sub ApplyThemeToForm(form As Form, theme As Class3.ThemeInfo)
            ' Loop through all controls in the form, including nested controls
            ApplyControlTheme(form, theme.Form_BackColor, theme.Form_ForeColor)
            For Each ctrl As Control In GetAllControls(form)

                ' Apply theme based on control type
                'If TypeOf ctrl Is Form Then
                'ApplyControlTheme(ctrl, theme.Form_BackColor, theme.Form_ForeColor)
                'ElseIf TypeOf ctrl Is TabControl Then
                If TypeOf ctrl Is TabControl Then
                    ApplyControlTheme(ctrl, theme.TabControl_BackColor, theme.TabControl_ForeColor)
                ElseIf TypeOf ctrl Is TabPage Then
                    ApplyControlTheme(ctrl, theme.TabPage_BackColor, theme.TabPage_ForeColor)
                ElseIf TypeOf ctrl Is Label Then
                    ApplyControlTheme(ctrl, theme.Label_BackColor, theme.Label_ForeColor)
                ElseIf TypeOf ctrl Is TextBox Then
                    ApplyControlTheme(ctrl, theme.TextBox_BackColor, theme.TextBox_ForeColor)
                ElseIf TypeOf ctrl Is ComboBox Then
                    ApplyControlTheme(ctrl, theme.ComboBox_BackColor, theme.ComboBox_ForeColor)
                ElseIf TypeOf ctrl Is Button Then
                    ApplyControlTheme(ctrl, theme.Button_BackColor, theme.Button_ForeColor)
                ElseIf TypeOf ctrl Is ListBox Then
                    ApplyControlTheme(ctrl, theme.ListBox_BackColor, theme.ListBox_ForeColor)
                ElseIf TypeOf ctrl Is GroupBox Then
                    ApplyControlTheme(ctrl, theme.GroupBox_BackColor, theme.GroupBox_ForeColor)
                    CType(ctrl, GroupBox).FlatStyle = FlatStyle.Flat
                ElseIf TypeOf ctrl Is DataGridView Then
                    ApplyDataGridViewTheme(CType(ctrl, DataGridView), theme)
                End If
            Next
        End Sub

        ' Function to get all controls, including nested controls (inside containers like TabPage, GroupBox)
        Private Shared Function GetAllControls(parent As Control) As IEnumerable(Of Control)
            Dim controlsList As New List(Of Control)()
            For Each ctrl As Control In parent.Controls
                controlsList.Add(ctrl)
                If ctrl.Controls.Count > 0 Then
                    controlsList.AddRange(GetAllControls(ctrl)) ' Recursively add child controls
                End If
            Next
            Return controlsList
        End Function

        ' Generic method to apply background and foreground color for controls
        Private Shared Sub ApplyControlTheme(ctrl As Control, backColor As String, foreColor As String)
            ctrl.BackColor = ColorTranslator.FromHtml(backColor)
            ctrl.ForeColor = ColorTranslator.FromHtml(foreColor)
        End Sub

        ' Special method to apply theme for DataGridView controls (because they have more properties)
        Private Shared Sub ApplyDataGridViewTheme(dgv As DataGridView, theme As Class3.ThemeInfo)
            dgv.BackgroundColor = ColorTranslator.FromHtml(theme.DataGridView_BackColor)
            dgv.ForeColor = ColorTranslator.FromHtml(theme.DataGridView_ForeColor)
            dgv.GridColor = ColorTranslator.FromHtml(theme.DGVGrid_Color)

            ' Column header styles
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml(theme.DGVColumnHeader_BackColor)
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(theme.DGVColumnHeader_ForeColor)

            ' Row header styles
            dgv.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml(theme.DGVRowHeader_BackColor)
            dgv.RowHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(theme.DGVRowHeader_ForeColor)

            ' Default cell styles
            dgv.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(theme.DGVDefaultCell_BackColor)
            dgv.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml(theme.DGVDefaultCell_ForeColor)

            ' Alternating row styles
            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml(theme.DGVAlternatingRows_BackColor)
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = ColorTranslator.FromHtml(theme.DGVAlternatingRows_ForeColor)
        End Sub

        Public Shared Sub ApplyImageToPictureBox(ProfileImage_PictureBox As PictureBox, theme As Class3.ThemeInfo)
            ' Attempt to set the image
            Dim imagePath As String = theme.ThemeImagePath

            If Not String.IsNullOrEmpty(imagePath) AndAlso File.Exists(imagePath) Then
                ' Try to load the image from the path if it exists
                ProfileImage_PictureBox.Image = Image.FromFile(imagePath)
            Else
                ' Optionally, set a default image if the theme image path is invalid or the file doesn't exist
                ProfileImage_PictureBox.Image = Nothing
            End If

        End Sub

    End Class

End Class
