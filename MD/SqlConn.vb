
Imports System.Data.SqlClient

Module SqlConn
    Public SQLCONN As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DB\LibraDB.mdf;Integrated Security=True")
End Module

