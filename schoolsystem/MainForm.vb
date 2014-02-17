Imports School.School
Imports System.IO

Public Class MainForm
    Dim courseList As New List(Of Course)
    Dim studentList As New List(Of Student)

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        CreateCourseDialog.TextBox1.Text = ""
        CreateCourseDialog.TextBox2.Text = ""
        Dim dr As DialogResult = CreateCourseDialog.ShowDialog()
        If dr = System.Windows.Forms.DialogResult.OK Then
            Dim newKurs As New Course(CreateCourseDialog.TextBox1.Text,
                                    CreateCourseDialog.TextBox2.Text
                                    )
            Dim found As Boolean = False
            For i = 0 To courseList.Count - 1
                If courseList.Item(i).getID Is newKurs.getID Then found = True
            Next
            If Not found Then
                courseList.Add(newKurs)
            End If
            refreshKurse()
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub refreshKurse()
        CheckedListBox1.Items.Clear()
        For i = 0 To courseList.Count - 1
            CheckedListBox1.Items.Add(courseList(i).name.ToString + " " + courseList(i).desc.ToString)
            courseList(i).tmpID = i
        Next
    End Sub

    Private Sub refreshSchueler()
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("New Student")
        For i = 0 To studentList.Count - 1
            ComboBox1.Items.Add(studentList(i).firstname.ToString + " " + studentList(i).lastname.ToString + " " + studentList(i).bday.ToString)
            studentList(i).tmpID = i + 1
        Next
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If studentList.Count > 0 Then
            Dim i As Integer = 0
            While Not ComboBox1.SelectedIndex = studentList(i).tmpID
                i += 1
            End While
            TextBox1.Text = CStr(studentList(i).lastname)
            TextBox2.Text = CStr(studentList(i).firstname)
            TextBox3.Text = CStr(studentList(i).tel)
            RichTextBox1.Text = CStr(studentList(i).tel)
            DateTimePicker1.Value = CDate(studentList(i).bday)
            For j = 0 To CheckedListBox1.Items.Count - 1
                Dim k As Integer = 0
                Dim l As Integer = 0
                While Not j = courseList(k).tmpID
                    k += 1
                End While
                If studentList(i).isInCourse(courseList(k).getID.ToString) Then CheckedListBox1.SetItemChecked(j, True) Else CheckedListBox1.SetItemChecked(j, False)
            Next
        End If
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en")
        System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture
        ComboBox1.Items.Add("New Student")
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If ComboBox1.SelectedIndex < 0 Then Exit Sub
        If ComboBox1.SelectedIndex = 0 Then
            Dim newSchueler As New Student(TextBox1.Text,
                                            TextBox2.Text,
                                            DateTimePicker1.Value,
                                            TextBox3.Text
                                            )
            newSchueler.notice = RichTextBox1.Text
            For j = 0 To CheckedListBox1.Items.Count - 1
                If CheckedListBox1.GetItemChecked(j) Then
                    Dim k As Integer = 0
                    While Not CheckedListBox1.SelectedIndex = courseList(k).tmpID
                        k += 1
                    End While
                    newSchueler.addCourse(courseList(k).getID.ToString)
                End If
            Next
            studentList.Add(newSchueler)
        Else
            Dim i As Integer = 1
            While Not ComboBox1.SelectedIndex = studentList(i).tmpID
                i += 1
            End While
            studentList(i).lastname = TextBox1.Text
            studentList(i).firstname = TextBox2.Text
            studentList(i).bday = DateTimePicker1.Value
            studentList(i).notice = RichTextBox1.Text
            studentList(i).tel = TextBox3.Text
            For j = 0 To CheckedListBox1.Items.Count - 1
                If CheckedListBox1.GetItemChecked(j) = True Then
                    Dim k As Integer = 0
                    While Not CheckedListBox1.SelectedIndex = courseList(k).tmpID
                        k += 1
                    End While
                    studentList(i).addCourse(courseList(k).getID.ToString)
                End If
                If CheckedListBox1.GetItemChecked(j) = False Then
                    Dim k As Integer = 0
                    While Not CheckedListBox1.SelectedIndex = courseList(k).tmpID
                        k += 1
                    End While
                    studentList(i).delCourse(courseList(k).getID.ToString)
                End If
            Next
        End If
        refreshSchueler()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        If ComboBox1.SelectedIndex < 1 Then Exit Sub
        Dim i As Integer = 1
        While Not ComboBox1.SelectedIndex = studentList(i).tmpID
            i += 1
        End While
    End Sub

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim text As String
        Try
            My.Computer.FileSystem.DeleteDirectory(My.Application.Info.DirectoryPath & "\files", FileIO.DeleteDirectoryOption.DeleteAllContents)
        Catch ex As Exception
            ErrorDialog.Show()
            ErrorDialog.SetVariables(My.Resources.error42, "Create the directory " + My.Application.Info.DirectoryPath + " files/? ", ex.Message.ToString, ex.ToString)
        End Try
        If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\files") Then
            Try
                IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\files")
            Catch ex As Exception
                ErrorDialog.Show()
                ErrorDialog.SetVariables(My.Resources.error42, "Can't create the directory" + My.Application.Info.DirectoryPath + " files/!", ex.Message.ToString, ex.ToString, True, "OK")
            End Try
        End If
        If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\files\students") Then
            Try
                IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\files\students")
            Catch ex As Exception
                ErrorDialog.Show()
                ErrorDialog.SetVariables(My.Resources.error42, "Can't create the directory" + My.Application.Info.DirectoryPath + " files/stundents/!", ex.Message.ToString, ex.ToString, True, "OK")
            End Try
        End If
        File.Delete(My.Application.Info.DirectoryPath & "\files\students.dat")
        If studentList.Count > 0 Then
            For Each item As Student In studentList
                File.Delete(My.Application.Info.DirectoryPath & "\files\students\" + item.getID.ToString)
                text = item.getID.ToString & vbCrLf
                My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\files\students.dat", text, True)
                text = item.lastname.ToString & vbCrLf & item.firstname.ToString & vbCrLf & item.bday.ToString & vbCrLf & item.tel.ToString & vbCrLf & item.notice.ToString & vbCrLf
                My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\files\students\" + item.getID.ToString + ".student", text, True)
                For Each kursid As String In item.courses
                    My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\files\students\" + item.getID.ToString + ".coursesList", kursid, True)
                Next
            Next
        Else
            ErrorDialog.Show()
            ErrorDialog.SetVariables(My.Resources.error42, "No Studnents" + My.Application.Info.DirectoryPath + " files/stundents/!", "You must create Student", Nothing, True, "OK")
            Exit Sub
        End If
        If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\files\courses") Then
            Try
                IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\files\courses")
            Catch ex As Exception
                ErrorDialog.Show()
                ErrorDialog.SetVariables(My.Resources.error42, "Can't create the directory" + My.Application.Info.DirectoryPath + " files/courses/!", ex.Message.ToString, ex.ToString, True, "OK")
            End Try
        End If
        If courseList.Count > 0 Then
            For Each item As Course In courseList
                File.Delete(My.Application.Info.DirectoryPath & "\files\courses\" + item.getID.ToString)
                text = item.getID.ToString & vbCrLf
                My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\files\courses.dat", text, True)
                text = item.desc.ToString & vbCrLf & item.name.ToString & vbCrLf
                My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\files\courses\" + item.getID.ToString + ".course", text, True)
            Next
        Else
            ErrorDialog.Show()
            ErrorDialog.SetVariables(My.Resources.error42, "No Studnents" + My.Application.Info.DirectoryPath + " files/stundents/!", "You must create Student", Nothing, True, "OK")
            Exit Sub
        End If
    End Sub
End Class
