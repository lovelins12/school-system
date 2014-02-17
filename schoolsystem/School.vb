Imports School.Utilities

Namespace School

    Public Class People

        Private id As String
        Private lname As String
        Private fname As String
        Private birthday As Date
        Private number As String
        Public tmpID As Integer

        ReadOnly Property getID As String
            Get
                Return id
            End Get
        End Property

        Property lastname As String
            Get
                Return lname
            End Get
            Set(value As String)
                lname = value
            End Set
        End Property

        Property firstname As String
            Get
                Return fname
            End Get
            Set(value As String)
                fname = value
            End Set
        End Property

        Property bday As Date
            Get
                Return birthday
            End Get
            Set(value As Date)
                birthday = value
            End Set
        End Property

        Property tel As String
            Get
                Return number
            End Get
            Set(value As String)
                number = value
            End Set
        End Property

        Sub New(lastname As String, firstname As String, bday As Date, tel As String)
            lname = lastname
            fname = firstname
            birthday = bday
            number = tel
            Dim hasher As New HashFunc
            id = hasher.MD5(lname + fname + bday.ToString + number)
        End Sub

    End Class

    Public Class Student : Inherits People

        Private notes As String
        Public courses As New List(Of String)

        Property notice As String
            Get
                Return notes
            End Get
            Set(value As String)
                notes = value
            End Set
        End Property

        Sub New(lastname As String, firstname As String, bday As Date, tel As String)
            MyBase.New(lastname, firstname, bday, tel)
        End Sub

        Public Sub addCourse(id As String)
            If Not courses.Contains(id) Then
                courses.Add(id)
            End If
        End Sub

        Public Sub delCourse(id As String)
            If courses.Contains(id) Then
                courses.Remove(id)
            End If
        End Sub

        Public Function isInCourse(id As String) As Boolean
            Return courses.Contains(id)
        End Function

    End Class

    Public Class Course

        Private coursename As String
        Private desciption As String
        Private id As String
        Public tmpID As Integer

        Property name As String
            Get
                Return coursename
            End Get
            Set(value As String)
                coursename = value
            End Set
        End Property

        Property desc As String
            Get
                Return desciption
            End Get
            Set(value As String)
                desciption = value
            End Set
        End Property

        ReadOnly Property getID As String
            Get
                Return id
            End Get
        End Property

        Sub New(name As String, desc As String)
            coursename = name
            desciption = desc
            Dim hasher As New HashFunc
            id = hasher.MD5(coursename + desciption)
        End Sub

    End Class

End Namespace