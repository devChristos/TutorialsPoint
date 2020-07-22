Imports System.Text.RegularExpressions
Public Class Form2
    Public Property StringPass As String
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'Database1DataSet.tblGender' table. You can move, or remove it, as needed.
        Me.TblGenderTableAdapter.Fill(Me.Database1DataSet.tblGender)
        Label1.Text = "Is " + StringPass + " a male? Or female?"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        StringPass = (Regex.Matches(StringPass, "(\w+)")).Item(0).Groups(1).Value
        TblGenderTableAdapter.Insert(StringPass, "M", 1)
        TblGenderTableAdapter.Update(Database1DataSet.tblGender)
        TblGenderTableAdapter.Fill(Database1DataSet.tblGender)
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        StringPass = (Regex.Matches(StringPass, "(\w+)")).Item(0).Groups(1).Value
        TblGenderTableAdapter.Insert(StringPass, "F", 1)
        TblGenderTableAdapter.Update(Database1DataSet.tblGender)
        TblGenderTableAdapter.Fill(Database1DataSet.tblGender)
        Me.Close()
    End Sub

End Class