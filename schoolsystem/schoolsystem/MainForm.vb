Imports schoolsystem.SchoolClass
Imports System.IO

Public Class MainForm
    Dim courseList As New List(Of Course)
    Dim studentList As New List(Of Student)

    Private Sub CreateCourseButton_Click(sender As System.Object, e As System.EventArgs) Handles CreateCourseButton.Click
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

    Private Sub StudentComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles StudentComboBox.SelectedIndexChanged
        If studentList.Count > 0 Then
            Dim i As Integer = 0
            While Not StudentComboBox.SelectedIndex = studentList(i).tmpID
                i += 1
            End While
            LastnameTextBox.Text = CStr(studentList(i).lastname)
            FirstnameTextBox.Text = CStr(studentList(i).firstname)
            PhoneTextBox.Text = CStr(studentList(i).tel)
            StundentNoticeTextBox.Text = CStr(studentList(i).tel)
            BirthdayDatePicker.Value = CDate(studentList(i).bday)
            For j = 0 To CoursesListBox.Items.Count - 1
                Dim k As Integer = 0
                Dim l As Integer = 0
                While Not j = courseList(k).tmpID
                    k += 1
                End While
                If studentList(i).isInCourse(courseList(k).getID.ToString) Then CoursesListBox.SetItemChecked(j, True) Else CoursesListBox.SetItemChecked(j, False)
            Next
        End If
    End Sub

    Private Sub MainForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en")
        'System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture
        StudentComboBox.Items.Add("New Student")
    End Sub

    Private Sub EditStudentButton_Click(sender As System.Object, e As System.EventArgs) Handles EditStudentButton.Click
        If StudentComboBox.SelectedIndex < 0 Then Exit Sub
        If StudentComboBox.SelectedIndex = 0 Then
            Dim newSchueler As New Student(LastnameTextBox.Text,
                                            FirstnameTextBox.Text,
                                            BirthdayDatePicker.Value,
                                            PhoneTextBox.Text
                                            )
            newSchueler.notice = StundentNoticeTextBox.Text
            For j = 0 To CoursesListBox.Items.Count - 1
                If CoursesListBox.GetItemChecked(j) Then
                    Dim k As Integer = 0
                    While Not CoursesListBox.SelectedIndex = courseList(k).tmpID
                        k += 1
                    End While
                    newSchueler.addCourse(courseList(k).getID.ToString)
                End If
            Next
            studentList.Add(newSchueler)
        Else
            Dim i As Integer = 1
            While Not StudentComboBox.SelectedIndex = studentList(i).tmpID
                i += 1
            End While
            studentList(i).lastname = LastnameTextBox.Text
            studentList(i).firstname = FirstnameTextBox.Text
            studentList(i).bday = BirthdayDatePicker.Value
            studentList(i).notice = StundentNoticeTextBox.Text
            studentList(i).tel = PhoneTextBox.Text
            For j = 0 To CoursesListBox.Items.Count - 1
                If CoursesListBox.GetItemChecked(j) = True Then
                    Dim k As Integer = 0
                    While Not CoursesListBox.SelectedIndex = courseList(k).tmpID
                        k += 1
                    End While
                    studentList(i).addCourse(courseList(k).getID.ToString)
                End If
                If CoursesListBox.GetItemChecked(j) = False Then
                    Dim k As Integer = 0
                    While Not CoursesListBox.SelectedIndex = courseList(k).tmpID
                        k += 1
                    End While
                    studentList(i).delCourse(courseList(k).getID.ToString)
                End If
            Next
        End If
        refreshSchueler()
    End Sub

    Private Sub SaveDataButton_Click(sender As System.Object, e As System.EventArgs) Handles SaveDataButton.Click
        Dim text As String
        Try
            My.Computer.FileSystem.DeleteDirectory(My.Application.Info.DirectoryPath & "\files", FileIO.DeleteDirectoryOption.DeleteAllContents)
        Catch ex As Exception
            ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "Create the directory " + My.Application.Info.DirectoryPath + " files/? ", ex.Message.ToString, ex.ToString)
            If ErrorDialog.DialogResult = Windows.Forms.DialogResult.Cancel Then Exit Sub
        End Try
        If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\files") Then
            Try
                IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\files")
            Catch ex As Exception
                ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "Can't create the directory" + My.Application.Info.DirectoryPath + " files/!", ex.Message.ToString, ex.ToString, True, "OK")
            End Try
        End If
        If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\files\students") Then
            Try
                IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\files\students")
            Catch ex As Exception
                ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "Can't create the directory" + My.Application.Info.DirectoryPath + " files/stundents/!", ex.Message.ToString, ex.ToString, True, "OK")
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
        Else : ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "No Studnents" + My.Application.Info.DirectoryPath + " files/stundents/!", "You must create Student", Nothing, True, "OK") : Exit Sub
        End If
        If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\files\courses") Then
            Try
                IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\files\courses")
            Catch ex As Exception
                ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "Can't create the directory" + My.Application.Info.DirectoryPath + " files/courses/!", ex.Message.ToString, ex.ToString, True, "OK")
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
        Else : ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "No Studnents" + My.Application.Info.DirectoryPath + " files/stundents/!", "You must create Student", Nothing, True, "OK") : Exit Sub
        End If
    End Sub

    Private Sub LoadDataButton_Click(sender As System.Object, e As System.EventArgs) Handles LoadDataButton.Click
        If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\files") Then ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "The integrity of the data is not given", "", "Directory " & My.Application.Info.DirectoryPath & "\files\ not found !", True, "OK") : Exit Sub
        If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\files\students") Then ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "The integrity of the data is not given", "", "Directory " & My.Application.Info.DirectoryPath & "\files\students\ not found !", True, "OK") : Exit Sub
        If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\files\courses") Then ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "The integrity of the data is not given", "", "Directory " & My.Application.Info.DirectoryPath & "\files\courses\ not found !", True, "OK") : Exit Sub
        If Not File.Exists(My.Application.Info.DirectoryPath & "\files\students.dat") Then ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "The integrity of the data is not given", "", "Directory " & My.Application.Info.DirectoryPath & "\files\students.dat not found !", True, "OK") : Exit Sub
        If Not File.Exists(My.Application.Info.DirectoryPath & "\files\courses.dat") Then ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "The integrity of the data is not given", "", "Directory " & My.Application.Info.DirectoryPath & "\files\courses.dat not found !", True, "OK") : Exit Sub

    End Sub

    'Functions

    Private Sub refreshKurse()
        CoursesListBox.Items.Clear()
        For i = 0 To courseList.Count - 1
            CoursesListBox.Items.Add(courseList(i).name.ToString + " " + courseList(i).desc.ToString)
            courseList(i).tmpID = i
        Next
    End Sub

    Private Sub refreshSchueler()
        StudentComboBox.Items.Clear()
        StudentComboBox.Items.Add("New Student")
        For i = 0 To studentList.Count - 1
            StudentComboBox.Items.Add(studentList(i).firstname.ToString + " " + studentList(i).lastname.ToString + " " + studentList(i).bday.ToString)
            studentList(i).tmpID = i + 1
        Next
    End Sub

End Class
