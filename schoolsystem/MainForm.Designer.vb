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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.CreateCourseButton = New System.Windows.Forms.Button()
        Me.CoursesListBox = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.LoadDataButton = New System.Windows.Forms.Button()
        Me.SaveDataButton = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CreateCourseButton
        '
        resources.ApplyResources(Me.CreateCourseButton, "CreateCourseButton")
        Me.CreateCourseButton.Name = "CreateCourseButton"
        Me.CreateCourseButton.UseVisualStyleBackColor = True
        '
        'CoursesListBox
        '
        resources.ApplyResources(Me.CoursesListBox, "CoursesListBox")
        Me.CoursesListBox.FormattingEnabled = True
        Me.CoursesListBox.Name = "CoursesListBox"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
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
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'PhoneTextBox
        '
        resources.ApplyResources(Me.PhoneTextBox, "PhoneTextBox")
        Me.PhoneTextBox.Name = "PhoneTextBox"
        '
        'EditStudentButton
        '
        resources.ApplyResources(Me.EditStudentButton, "EditStudentButton")
        Me.EditStudentButton.Name = "EditStudentButton"
        Me.EditStudentButton.UseVisualStyleBackColor = True
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'StundentNoticeTextBox
        '
        resources.ApplyResources(Me.StundentNoticeTextBox, "StundentNoticeTextBox")
        Me.StundentNoticeTextBox.Name = "StundentNoticeTextBox"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'BirthdayDatePicker
        '
        resources.ApplyResources(Me.BirthdayDatePicker, "BirthdayDatePicker")
        Me.BirthdayDatePicker.Name = "BirthdayDatePicker"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'FirstnameTextBox
        '
        resources.ApplyResources(Me.FirstnameTextBox, "FirstnameTextBox")
        Me.FirstnameTextBox.Name = "FirstnameTextBox"
        '
        'LastnameTextBox
        '
        resources.ApplyResources(Me.LastnameTextBox, "LastnameTextBox")
        Me.LastnameTextBox.Name = "LastnameTextBox"
        '
        'StudentComboBox
        '
        resources.ApplyResources(Me.StudentComboBox, "StudentComboBox")
        Me.StudentComboBox.FormattingEnabled = True
        Me.StudentComboBox.Name = "StudentComboBox"
        '
        'LoadDataButton
        '
        resources.ApplyResources(Me.LoadDataButton, "LoadDataButton")
        Me.LoadDataButton.Name = "LoadDataButton"
        Me.LoadDataButton.UseVisualStyleBackColor = True
        '
        'SaveDataButton
        '
        resources.ApplyResources(Me.SaveDataButton, "SaveDataButton")
        Me.SaveDataButton.Name = "SaveDataButton"
        Me.SaveDataButton.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SaveDataButton)
        Me.Controls.Add(Me.LoadDataButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CoursesListBox)
        Me.Controls.Add(Me.CreateCourseButton)
        Me.Name = "MainForm"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CreateCourseButton As System.Windows.Forms.Button
    Friend WithEvents CoursesListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents StudentComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FirstnameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LastnameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BirthdayDatePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents StundentNoticeTextBox As System.Windows.Forms.RichTextBox
    Friend WithEvents EditStudentButton As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PhoneTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LoadDataButton As System.Windows.Forms.Button
    Friend WithEvents SaveDataButton As System.Windows.Forms.Button

End Class
