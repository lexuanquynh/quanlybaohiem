Imports System.Data.SqlClient

Public Class MyDBConnector
    Protected Friend Const DE_CONNECT_SQL As String = "data source=hp-pc;initial catalog=qlhdbh;integrated security=true"
    Dim con As New SqlConnection
    'Ham tao ket noi toi database
    Public Function TaoKetNoi() As SqlConnection
        Try
            Dim strketnoi As String = DE_CONNECT_SQL
            con.ConnectionString = strketnoi
            con.Open()
            Return con
        Catch ex As Exception
            MessageBox.Show("Có lỗi xảy ra. Vui lòng kiểm tra lại kết nối tới Database của bạn!")
            Return con
        End Try
    End Function

    'Ham dong ket noi toi database
    Public Sub DongKetNoi()
        Try
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class
