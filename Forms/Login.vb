
Imports System.Data.SqlClient
Public Class Login
    'BD Conn 
    Public SQLCONN As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB\LibraDB.mdf;Integrated Security=True")
    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click
        End
        'exit Button
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Make Password crypted 
        PasswordTextBox.UseSystemPasswordChar = True

        'Fill Username ComboBox from DB
        Try
            Dim SQLCMD As New SqlCommand($"select Username from Users_TBL", SQLCONN)
            Dim adapter As New SqlDataAdapter(SQLCMD)
            Dim table As New DataTable()
            adapter.Fill(table)
            UsernameComboBox.DataSource = table
            UsernameComboBox.DisplayMember = "Username"
            UsernameComboBox.ValueMember = "Username"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Guna2ToggleSwitch1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2ToggleSwitch1.CheckedChanged
        'Textbox password  (Show/hide Password)
        If Guna2ToggleSwitch1.Checked = True Then
            PasswordTextBox.UseSystemPasswordChar = False
        Else
            PasswordTextBox.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub LoginB_Click(sender As Object, e As EventArgs) Handles LoginB.Click
        'Chack for Password of username Selected 
        If PasswordTextBox.Text = String.Empty Then
            MsgBox("Please entry the password!", MsgBoxStyle.Exclamation)

        ElseIf UsernameComboBox.Text = String.Empty Then
            MsgBox("Please select the User!", MsgBoxStyle.Exclamation)
        Else
            Try
                Dim SQLCMD As New SqlCommand($"select Username,Password from Users_TBL where username='{UsernameComboBox.Text}' and Password='{PasswordTextBox.Text}'", SQLCONN)
                Dim adapter As New SqlDataAdapter(SQLCMD)
                Dim table As New DataTable()
                adapter.Fill(table)
                If table.Rows.Count = 0 Then
                    MsgBox("Wrong Password!", MsgBoxStyle.Exclamation)
                Else
                    'Me.Hide() 
                    MsgBox("Correct password")

                    'Rest password
                    PasswordTextBox.Text = ""
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        MsgBox("Ohh we sorry for that! Please contact your IT ADMIN", MsgBoxStyle.Information)

    End Sub
End Class