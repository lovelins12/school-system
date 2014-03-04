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
            Dim newCourse As New Course(CreateCourseDialog.TextBox1.Text, CreateCourseDialog.TextBox2.Text)
            Dim found As Boolean = False
            For i = 0 To courseList.Count - 1
                If courseList.Item(i).getID Is newCourse.getID Then found = True
            Next
            If Not found Then
                courseList.Add(newCourse)
            End If
            refreshKurse()
        End If
    End Sub

    Private Sub StudentComboBox_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles StudentComboBox.SelectedIndexChanged
        If studentList.Count > 0 And StudentComboBox.SelectedIndex > 0 Then
            Dim i As Integer = 0
            While Not StudentComboBox.SelectedIndex = studentList(i).tmpID
                i += 1
            End While
            LastnameTextBox.Text = CStr(studentList(i).lastname)
            FirstnameTextBox.Text = CStr(studentList(i).firstname)
            PhoneTextBox.Text = CStr(studentList(i).tel)
            StundentNoticeTextBox.Text = CStr(studentList(i).notice)
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
            Dim newStudent As New Student(LastnameTextBox.Text, FirstnameTextBox.Text, BirthdayDatePicker.Value, PhoneTextBox.Text )
            newStudent.notice = StundentNoticeTextBox.Text
            For j = 0 To CoursesListBox.Items.Count - 1
                If CoursesListBox.GetItemChecked(j) Then
                    Dim k As Integer = 0
                    While Not j = courseList(k).tmpID
                        k += 1
                    End While
                    newStudent.addCourse(courseList(k).getID.ToString)
                End If
            Next
            studentList.Add(newStudent)
        Else
            Dim i As Integer = 0
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
                    While Not j = courseList(k).tmpID
                        k += 1
                    End While
                    studentList(i).addCourse(courseList(k).getID.ToString)
                End If
                If CoursesListBox.GetItemChecked(j) = False Then
                    Dim k As Integer = 0
                    While Not j = courseList(k).tmpID
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
        If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\files") Then
            Try : IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\files")
            Catch ex As Exception : ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "Can't create the directory" + My.Application.Info.DirectoryPath + " files/!", ex.Message.ToString, ex.ToString, True, "OK") : End Try
        End If
        If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\files\students") Then
            Try : IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\files\students")
            Catch ex As Exception : ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "Can't create the directory" + My.Application.Info.DirectoryPath + " files/stundents/!", ex.Message.ToString, ex.ToString, True, "OK") : End Try
        End If
        File.Delete(My.Application.Info.DirectoryPath & "\files\students.dat")
        If studentList.Count > 0 Then
            For Each item As Student In studentList
                File.Delete(My.Application.Info.DirectoryPath & "\files\students\" + item.getID.ToString)
                text = item.getID.ToString & vbCrLf
                My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\files\students.dat", text, True)
                text = item.lastname.ToString & vbCrLf & item.firstname.ToString & vbCrLf & item.bday.ToString & vbCrLf & item.tel.ToString & vbCrLf & item.notice.ToString & vbCrLf
                My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\files\students\" + item.getID.ToString + ".student", text, True)
                For Each courseid As String In item.courses
                    My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\files\students\" + item.getID.ToString + ".coursesList", courseid & vbCrLf, True)
                Next
            Next
        Else : ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "No Studnents", "You must create Student", Nothing, True, "OK") : Exit Sub
        End If
        If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\files\courses") Then
            Try : IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\files\courses")
            Catch ex As Exception : ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "Can't create the directory" + My.Application.Info.DirectoryPath + " files/courses/!", ex.Message.ToString, ex.ToString, True, "OK") : End Try
        End If
        If courseList.Count > 0 Then
            For Each item As Course In courseList
                File.Delete(My.Application.Info.DirectoryPath & "\files\courses\" + item.getID.ToString)
                text = item.getID & vbCrLf
                My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\files\courses.dat", text, True)
                text = item.desc.ToString & vbCrLf & item.name.ToString & vbCrLf
                My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath & "\files\courses\" + item.getID.ToString + ".course", text, True)
            Next
        Else : ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "No Studnents" + My.Application.Info.DirectoryPath + " files/stundents/!", "You must create Student", Nothing, True, "OK") : Exit Sub
        End If
    End Sub

    Private Sub LoadDataButton_Click(sender As System.Object, e As System.EventArgs) Handles LoadDataButton.Click
        studentList.Clear()
        courseList.Clear()
        If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\files") Then ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "The integrity of the data is not given", "", "Directory " & My.Application.Info.DirectoryPath & "\files\ not found !", True, "OK") : Exit Sub
        If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\files\students") Then ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "The integrity of the data is not given", "", "Directory " & My.Application.Info.DirectoryPath & "\files\students\ not found !", True, "OK") : Exit Sub
        If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\files\courses") Then ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "The integrity of the data is not given", "", "Directory " & My.Application.Info.DirectoryPath & "\files\courses\ not found !", True, "OK") : Exit Sub
        If Not File.Exists(My.Application.Info.DirectoryPath & "\files\students.dat") Then ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "The integrity of the data is not given", "", "Directory " & My.Application.Info.DirectoryPath & "\files\students.dat not found !", True, "OK") : Exit Sub
        If Not File.Exists(My.Application.Info.DirectoryPath & "\files\courses.dat") Then ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "The integrity of the data is not given", "", "Directory " & My.Application.Info.DirectoryPath & "\files\courses.dat not found !", True, "OK") : Exit Sub
        Dim coursesListFile() As String = System.IO.File.ReadAllLines(My.Application.Info.DirectoryPath & "\files\courses.dat")
        For i = 0 To coursesListFile.Length - 1
            If Not File.Exists(My.Application.Info.DirectoryPath & "\files\courses\" & coursesListFile(i) & ".course") Then ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "The integrity of the data is not given", "", "Directory " & My.Application.Info.DirectoryPath & "\files\courses\" & coursesListFile(i) & ".course not found !", True, "OK") : Exit Sub
            Dim courseFile() As String = System.IO.File.ReadAllLines(My.Application.Info.DirectoryPath & "\files\courses\" & coursesListFile(i) & ".course")
            Try
                Dim newCourse As New Course(courseFile(0), courseFile(1))
                courseList.Add(newCourse)
            Catch ex As Exception
                ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "The integrity of the data is not given", "", "File " & My.Application.Info.DirectoryPath & "\files\courses\" & coursesListFile(i) & ".course is destroyed !" & vbCrLf & ex.Message, True, "OK") : Exit Sub
            End Try
        Next
        Dim studentListFile() As String = System.IO.File.ReadAllLines(My.Application.Info.DirectoryPath & "\files\students.dat")
        For i = 0 To studentListFile.Length - 1
            If Not File.Exists(My.Application.Info.DirectoryPath & "\files\students\" & studentListFile(i) & ".student") Then ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "The integrity of the data is not given", "", "Directory " & My.Application.Info.DirectoryPath & "\files\students\" & studentListFile(i) & ".student not found !", True, "OK") : Exit Sub
            Dim studentFile() As String = System.IO.File.ReadAllLines(My.Application.Info.DirectoryPath & "\files\students\" & studentListFile(i) & ".student")
            Try
                Dim newStudent As New Student(studentFile(0), studentFile(1), Date.Parse(studentFile(2)), studentFile(3))
                For j = 4 To studentFile.Length - 1
                    newStudent.notice = newStudent.notice & studentFile(j) & vbCrLf
                Next
                Dim studentCourseFile() As String = System.IO.File.ReadAllLines(My.Application.Info.DirectoryPath & "\files\students\" & studentListFile(i) & ".coursesList")
                For j = 0 To studentCourseFile.Length - 1
                    newStudent.addCourse(studentCourseFile(j))
                Next
                studentList.Add(newStudent)
            Catch ex As Exception
                ErrorDialog.Show() : ErrorDialog.SetVariables(My.Resources.Error48, "The integrity of the data is not given", "", "File " & My.Application.Info.DirectoryPath & "\files\students\" & studentListFile(i) & ".student is destroyed !" & vbCrLf & ex.Message, True, "OK") : Exit Sub
            End Try
        Next
        refreshSchueler()
        refreshKurse()
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
