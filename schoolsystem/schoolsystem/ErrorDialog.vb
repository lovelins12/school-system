Imports System.Windows.Forms

Public Class ErrorDialog

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub SetVariables(ByVal image As Image, ByVal question As String, ByVal errorText As String, ByVal errorFullText As String, Optional ByVal noResult As Boolean = False, Optional ByVal button1Text As String = "OK", Optional ByVal button2Text As String = "Cancel")
        PictureBox1.Image = image
        RichTextBox2.Text = errorText
        RichTextBox3.Text = question
        If Not errorFullText Is Nothing Then
            RichTextBox1.Text = errorFullText
        Else
            ShowMoreButton.Visible = False
        End If

        If noResult = False Then
            OK_Button.Visible = False
            Cancel_Button.Text = button1Text
        Else
            OK_Button.Visible = True
            OK_Button.Text = button1Text
            Cancel_Button.Text = button2Text
        End If

    End Sub

    Private Sub ShowMoreButton_Click(sender As System.Object, e As System.EventArgs) Handles ShowMoreButton.Click
        Me.Height = 385
        ShowMoreButton.Visible = False
        RichTextBox1.Visible = True
        OK_Button.Top = 324
        Cancel_Button.Top = 324
    End Sub

    Private Sub ErrorDialog_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Height = 165
        ShowMoreButton.Visible = True
        RichTextBox1.Visible = False
        OK_Button.Top = 92
        Cancel_Button.Top = 92
    End Sub
End Class
