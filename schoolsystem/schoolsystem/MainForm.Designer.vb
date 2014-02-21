<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SaveDataButton = New System.Windows.Forms.Button()
        Me.LoadDataButton = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PhoneTextBox = New System.Windows.Forms.TextBox()
        Me.EditStudentButton = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.StundentNoticeTextBox = New System.Windows.Forms.RichTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BirthdayDatePicker = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FirstnameTextBox = New System.Windows.Forms.TextBox()
        Me.LastnameTextBox = New System.Windows.Forms.TextBox()
        Me.StudentComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CoursesListBox = New System.Windows.Forms.CheckedListBox()
        Me.CreateCourseButton = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SaveDataButton
        '
        Me.SaveDataButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.SaveDataButton.Location = New System.Drawing.Point(400, 403)
        Me.SaveDataButton.Name = "SaveDataButton"
        Me.SaveDataButton.Size = New System.Drawing.Size(292, 23)
        Me.SaveDataButton.TabIndex = 12
        Me.SaveDataButton.Text = "Save Data"
        Me.SaveDataButton.UseVisualStyleBackColor = True
        '
        'LoadDataButton
        '
        Me.LoadDataButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LoadDataButton.Location = New System.Drawing.Point(400, 373)
        Me.LoadDataButton.Name = "LoadDataButton"
        Me.LoadDataButton.Size = New System.Drawing.Size(292, 23)
        Me.LoadDataButton.TabIndex = 11
        Me.LoadDataButton.Text = "Load Data"
        Me.LoadDataButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.PhoneTextBox)
        Me.GroupBox1.Controls.Add(Me.EditStudentButton)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.StundentNoticeTextBox)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.BirthdayDatePicker)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.FirstnameTextBox)
        Me.GroupBox1.Controls.Add(Me.LastnameTextBox)
        Me.GroupBox1.Controls.Add(Me.StudentComboBox)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(382, 423)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Information of Student"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(220, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Phonenumber"
        '
        'PhoneTextBox
        '
        Me.PhoneTextBox.Location = New System.Drawing.Point(220, 140)
        Me.PhoneTextBox.Name = "PhoneTextBox"
        Me.PhoneTextBox.Size = New System.Drawing.Size(156, 20)
        Me.PhoneTextBox.TabIndex = 10
        '
        'EditStudentButton
        '
        Me.EditStudentButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.EditStudentButton.Location = New System.Drawing.Point(301, 391)
        Me.EditStudentButton.Name = "EditStudentButton"
        Me.EditStudentButton.Size = New System.Drawing.Size(75, 23)
        Me.EditStudentButton.TabIndex = 9
        Me.EditStudentButton.Text = "Save"
        Me.EditStudentButton.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(6, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Notice"
        '
        'StundentNoticeTextBox
        '
        Me.StundentNoticeTextBox.Location = New System.Drawing.Point(9, 178)
        Me.StundentNoticeTextBox.Name = "StundentNoticeTextBox"
        Me.StundentNoticeTextBox.Size = New System.Drawing.Size(367, 206)
        Me.StundentNoticeTextBox.TabIndex = 7
        Me.StundentNoticeTextBox.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(6, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Birthday"
        '
        'BirthdayDatePicker
        '
        Me.BirthdayDatePicker.Location = New System.Drawing.Point(9, 137)
        Me.BirthdayDatePicker.Name = "BirthdayDatePicker"
        Me.BirthdayDatePicker.Size = New System.Drawing.Size(200, 20)
        Me.BirthdayDatePicker.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(220, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Firstname"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(6, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Lastname"
        '
        'FirstnameTextBox
        '
        Me.FirstnameTextBox.Location = New System.Drawing.Point(220, 89)
        Me.FirstnameTextBox.Name = "FirstnameTextBox"
        Me.FirstnameTextBox.Size = New System.Drawing.Size(156, 20)
        Me.FirstnameTextBox.TabIndex = 2
        '
        'LastnameTextBox
        '
        Me.LastnameTextBox.Location = New System.Drawing.Point(6, 89)
        Me.LastnameTextBox.Name = "LastnameTextBox"
        Me.LastnameTextBox.Size = New System.Drawing.Size(203, 20)
        Me.LastnameTextBox.TabIndex = 1
        '
        'StudentComboBox
        '
        Me.StudentComboBox.FormattingEnabled = True
        Me.StudentComboBox.Location = New System.Drawing.Point(6, 25)
        Me.StudentComboBox.Name = "StudentComboBox"
        Me.StudentComboBox.Size = New System.Drawing.Size(370, 21)
        Me.StudentComboBox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(397, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Courses"
        '
        'CoursesListBox
        '
        Me.CoursesListBox.FormattingEnabled = True
        Me.CoursesListBox.Location = New System.Drawing.Point(400, 37)
        Me.CoursesListBox.Name = "CoursesListBox"
        Me.CoursesListBox.Size = New System.Drawing.Size(292, 274)
        Me.CoursesListBox.TabIndex = 8
        '
        'CreateCourseButton
        '
        Me.CreateCourseButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CreateCourseButton.Location = New System.Drawing.Point(400, 320)
        Me.CreateCourseButton.Name = "CreateCourseButton"
        Me.CreateCourseButton.Size = New System.Drawing.Size(292, 23)
        Me.CreateCourseButton.TabIndex = 7
        Me.CreateCourseButton.Text = "Create Course"
        Me.CreateCourseButton.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 440)
        Me.Controls.Add(Me.SaveDataButton)
        Me.Controls.Add(Me.LoadDataButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CoursesListBox)
        Me.Controls.Add(Me.CreateCourseButton)
        Me.Name = "MainForm"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveDataButton As System.Windows.Forms.Button
    Friend WithEvents LoadDataButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PhoneTextBox As System.Windows.Forms.TextBox
    Friend WithEvents EditStudentButton As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents StundentNoticeTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BirthdayDatePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FirstnameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LastnameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StudentComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CoursesListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents CreateCourseButton As System.Windows.Forms.Button

End Class
