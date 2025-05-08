' Copyright:	Public domain.
' Filename:	AGS_INITIALIZATION.agc
' Purpose: 	Part Of the source code For Luminary 1A build 099.
'		It Is part Of the source code For the Lunar Module's (LM)
'		Apollo Guidance Computer (AGC), For Apollo 11.
' Assembler:	yaYUL
' Contact:	Peter Strazan <peter.strazan@gmail.com>.
' Website:	www.ibiblio.org/apollo.
' Pages:	206-210
' Mod history:	2009-05-19 HG	Transcribed from page images.
'
' This source code has been transcribed Or otherwise adapted from
' digitized images Of a hardcopy from the MIT Museum.  The digitization
' was performed by Paul Fjeld, And arranged For by Deborah Douglas Of
' the Museum.  Many thanks To both.  The images (With suitable reduction
' In storage size And consequent reduction In image quality As well) are
' available online at www.ibiblio.org/apollo.  If For some reason you
' find that the images are illegible, contact Me at info@sandroid.org
' about getting access To the (much) higher-quality images which Paul
' actually created.
'
' Notations On the hardcopy document read, In part:
'
'	Assemble revision 001 Of AGC program LMY99 by NASA 2021112-061
'	16:27 JULY 14, 1969

Imports System.IO
Imports System.Text.RegularExpressions
Public Class Form1

    ' Declare the dictionary as a global variable
    ' Used for storing sdcq.properties
    Private properties As New Dictionary(Of String, String)
    ' save text For simple 1 level undo feature
    Private undo As String = ""
    Private toolTip As New ToolTip()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        toolTip.SetToolTip(BtnCIASubstitute, "Create SQL for CIA, the result is in clipboard.")
        toolTip.SetToolTip(BtnDEVSubstitute, "Create SQL for DEV System, the result is in clipboard.")
        toolTip.SetToolTip(BtnUndo, "Save the first SQL entry with placeholders and retrieve it when needed.")
        toolTip.SetToolTip(BtnExit, "Replace the content of the main fuel Apollo 11 tank with Bacardi.")
        toolTip.SetToolTip(CBToUpperCase, "If selected the text is converted to Upper Case.")
        toolTip.SetToolTip(CbSortingASC, "Add a sort ASC or DESC.")
        toolTip.SetToolTip(TextArea, "Text area for input like '*select id form []table' and the result.")
    End Sub


    Private Sub ReadSqlProperties(filePath As String)
        ' Check if the file exists
        If File.Exists(filePath) Then
            ' Clear the dictionary to avoid duplicate entries
            properties.Clear()

            ' Read all lines from the file
            Dim lines As String() = File.ReadAllLines(filePath)

            ' Parse each line into key-value pairs
            For Each line As String In lines
                ' Skip empty lines or lines without '='
                If Not String.IsNullOrWhiteSpace(line) AndAlso line.Contains("=") Then
                    Dim parts As String() = line.Split("="c)
                    If parts.Length = 2 Then
                        Dim key As String = parts(0).Trim()
                        Dim value As String = parts(1).Trim()
                        If key.StartsWith("SDC_") Then
                            properties(key) = value
                        End If

                    End If
                End If
            Next

            ' Display the parsed properties (for demonstration purposes)
            For Each kvp As KeyValuePair(Of String, String) In properties
                '   MessageBox.Show($"Key: {kvp.Key}, Value: {kvp.Value}")
            Next
        Else
            MessageBox.Show($"The file '{filePath}' was not found.")
        End If
    End Sub


    Private Sub SubstituteSQLByDictionary()
        ' Check if the dictionary has entries
        If properties.Count > 0 Then
            ' Create a StringBuilder to store the entries
            Dim result As New Text.StringBuilder()

            ' Iterate through the dictionary and format the entries
            For Each kvp As KeyValuePair(Of String, String) In properties
                'result.AppendLine($"Key: {kvp.Key}, Value: {kvp.Value}")
                result.AppendLine(GetCIASubstitution(kvp.Key, kvp.Value, TextArea.Text))

            Next
            TextArea.Text = result.ToString()
        Else
            MessageBox.Show("The dictionary is empty.", "Dictionary Entries")
        End If
    End Sub

    Private Sub ButtonSubstitute_Click(sender As Object, e As EventArgs) Handles BtnCIASubstitute.Click
        ReadSqlProperties("sdcq.properties")
        If (undo.Length = 0) Then
            undo = TextArea.Text
        End If
        If CbSortingASC.Checked Then
            ' Sort the dictionary by key
            properties = properties.OrderBy(Function(kvp) kvp.Key).ToDictionary(Function(kvp) kvp.Key, Function(kvp) kvp.Value)
        Else
            properties = properties.OrderByDescending(Function(kvp) kvp.Key).ToDictionary(Function(kvp) kvp.Key, Function(kvp) kvp.Value)
        End If

        ' Check if the dictionary has entries
        If properties.Count > 0 Then
            ' Create a StringBuilder to store the entries
            Dim result As New Text.StringBuilder()

            ' Iterate through the dictionary and format the entries
            For Each kvp As KeyValuePair(Of String, String) In properties
                'result.AppendLine($"Key: {kvp.Key}, Value: {kvp.Value}")
                result.AppendLine(GetCIASubstitution(kvp.Key, kvp.Value, TextArea.Text))

            Next
            TextArea.Text = result.ToString()
        Else
            MessageBox.Show("The dictionary is empty.", "Dictionary Entries")
        End If

        If CbSortingASC.Checked Then
            TextArea.AppendText("ORDER BY SDC ASC")
        Else
            TextArea.AppendText("ORDER BY SDC DESC")
        End If
        Clipboard.SetText(TextArea.Text)
        ShowTemporaryMessage("Clipboard.")

    End Sub

    Public Function GetCIASubstitution(SDCNAME As String, SDCDATABASE As String, template As String) As String
        ' Check if case sensitivity is disabled (assuming cbCaseSens is a CheckBox)
        If CBToUpperCase.Checked Then
            template = template.ToUpper()
        End If

        ' Replace "*select" with "*SELECT"
        template = template.Replace("*select", "*SELECT")

        ' Split the template into lines
        Dim lines As String() = template.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
        Dim sb As New Text.StringBuilder()
        Dim substituent As String = SDCDATABASE

        ' Process each line
        For Each line As String In lines
            Console.WriteLine(line)
            '            Dim selectLine As String = line.Replace(" ", "").Replace(vbTab, "")
            Dim selectLine As String = Regex.Replace(line, "\s+", "")


            ' Replace "*SELECT" with the desired substitution
            line = line.Replace("*SELECT", $"SELECT '{SDCNAME}' 'SDC', ")

            ' Replace "[]" with the substituent
            line = line.Replace("[]", substituent)

            ' Append the processed line to the StringBuilder
            sb.AppendLine(line)
        Next

        ' Combine the processed lines into the template
        template = sb.ToString()


        If properties.Keys.Last() <> SDCNAME Then
            template &= " UNION ALL" ' Environment.NewLine
        End If

        ' Replace ".." with "." and return the result
        Return template.Replace("..", ".")
    End Function





    Private Sub BtnDEV_Click_1(sender As Object, e As EventArgs) Handles BtnDEVSubstitute.Click
        ReadSqlProperties("sdcq.properties")
        If (undo.Length = 0) Then
            undo = TextArea.Text
        End If

        If CbSortingASC.Checked Then
            ' Sort the dictionary by key
            properties = properties.OrderBy(Function(kvp) kvp.Key).ToDictionary(Function(kvp) kvp.Key, Function(kvp) kvp.Value)
        Else
            properties = properties.OrderByDescending(Function(kvp) kvp.Key).ToDictionary(Function(kvp) kvp.Key, Function(kvp) kvp.Value)
        End If

        ' Check if the dictionary has entries
        If properties.Count > 0 Then
            ' Create a StringBuilder to store the entries
            Dim result As New Text.StringBuilder()

            ' Iterate through the dictionary and format the entries
            For Each kvp As KeyValuePair(Of String, String) In properties
                'result.AppendLine($"Key: {kvp.Key}, Value: {kvp.Value}")
                result.AppendLine(GetDEVSubstitution1(kvp.Key, kvp.Value, TextArea.Text))

            Next
            TextArea.Text = result.ToString()
        Else
            MessageBox.Show("The dictionary is empty.", "Dictionary Entries")
        End If

        If CbSortingASC.Checked Then
            TextArea.AppendText("ORDER BY SDC ASC")
        Else
            TextArea.AppendText("ORDER BY SDC DESC")
        End If
        Clipboard.SetText(TextArea.Text)
        ShowTemporaryMessage("Clipboard.")
    End Sub


    Public Function GetDEVSubstitution1(SDCNAME As String, SDCDATABASE As String, template As String) As String
        ' Check if case sensitivity is disabled (assuming CBCaseSens is a CheckBox)
        If CBToUpperCase.Checked Then
            template = template.ToUpper()
        End If

        ' Replace "*select" with "*SELECT"
        template = template.Replace("*select", "*SELECT")

        ' Split the template into lines
        Dim lines As String() = template.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
        Dim sb As New Text.StringBuilder()
        Dim subValue As String = SDCDATABASE

        ' Extract the substring after the first "]" and before the first "."
        subValue = subValue.Substring(subValue.IndexOf("]") + 2)
        subValue = subValue.Substring(0, subValue.IndexOf("."))

        ' Process each line
        For Each line As String In lines
            Console.WriteLine(line)
            Dim selectLine As String = Regex.Replace(line, "\s+", "")

            ' Replace "*SELECT" with the desired substitution
            line = line.Replace("*SELECT", $"SELECT '{SDCNAME}' 'SDC', ")

            ' Replace "[]" with the formatted substitution
            line = line.Replace("[]", $"{subValue}.dbo.")

            ' Append the processed line to the StringBuilder
            sb.AppendLine(line)
        Next

        ' Combine the processed lines into the template
        template = sb.ToString()

        ' Add " UNION ALL" at the end
        If properties.Keys.Last() <> SDCNAME Then
            template &= " UNION ALL" ' Environment.NewLine
        End If

        ' Replace ".." with "." and return the result
        Return template.Replace("..", ".")
    End Function

    Public Function GetDEVSubstitution(SDCNAME As String, SDCDATABASE As String, template As String) As String
        ' Check if case sensitivity is disabled (assuming cbCaseSens is a CheckBox)
        If Not CBToUpperCase.Checked Then
            template = template.ToUpper()
        End If

        ' Replace "*select" with "*SELECT"
        template = template.Replace("*select", "*SELECT")

        ' Split the template into lines
        Dim lines As String() = template.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
        Dim sb As New Text.StringBuilder()
        Dim substituent As String = SDCDATABASE

        ' Process each line
        For Each line As String In lines
            Console.WriteLine(line)

            Dim selectLine As String = Regex.Replace(line, "\s+", "")


            ' Replace "*SELECT" with the desired substitution
            line = line.Replace("*SELECT", $"SELECT '{SDCNAME}' 'SDC', ")

            ' Replace "[]" with the substituent
            line = line.Replace("[]", substituent)

            ' Append the processed line to the StringBuilder
            sb.AppendLine(line)
        Next

        ' Combine the processed lines into the template
        template = sb.ToString()


        If properties.Keys.Last() <> SDCNAME Then
            template &= " UNION ALL" ' Environment.NewLine
        End If

        ' Replace ".." with "." and return the result
        Return template.Replace("..", ".")
    End Function


    Private Sub BtnUndo_Click(sender As Object, e As EventArgs) Handles BtnUndo.Click
        TextArea.Text = undo
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Application.Exit()
    End Sub

    Private Sub ShowTemporaryMessage(message As String)
        Dim messageForm As New MessageForm(message)
        messageForm.ShowDialog() ' Show the message form as a dialog
    End Sub

End Class
