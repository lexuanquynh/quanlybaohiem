Imports System.Data.SqlClient
Public Class BaoCaoDoanhThu

    Dim con As New SqlConnection

    Protected Friend Const DE_MAHOADON_AS As String = "Mã hóa đơn"
    Protected Friend Const DE_MAHOPDONG_AS As String = "Mã hợp đồng"
    Protected Friend Const DE_NGAYTHU_AS As String = "ngày thu"
    Protected Friend Const DE_CACHTHUC_AS As String = "cách thức"
    Protected Friend Const DE_SOTIEN_AS As String = "số tiền"


    Protected Friend Const TABLE_KHACHHANG As String = "Khachhang"
    Protected Friend Const TABLE_HOPDONG As String = "hopdong"
    Protected Friend Const TABLE_HOADON As String = "hoadon"

    Protected Friend Const DE_HD_SOHOADON As String = "soHoadon"
    Protected Friend Const DE_HD_MAHOPDONG As String = "maHD"
    Protected Friend Const DE_HD_NGAYTHU As String = "ngaythu"
    Protected Friend Const DE_HD_CACHTHUC As String = "cachthuc"
    Protected Friend Const DE_HD_SOTIEN As String = "sotien"


    Protected Friend Const DE_PRODUCE_INSERT_HOADON As String = "insertdataintotableHoadon"
    Protected Friend Const DE_PRODUCE_UPDATE_HOADON As String = "updatedatainsidetableHoadon"
   
    Public Function ChinhSuaThongTinHoaDon(ByVal isUpdate As Boolean, ByVal maHD As Integer, ByVal ngaythu As String, cachthuc As String,
                                     ByVal sotien As Double) As Boolean
        Dim myDbConnecter As MyDBConnector
        myDbConnecter = New MyDBConnector()
        con = myDbConnecter.TaoKetNoi()

        Dim cmd As New SqlCommand

        cmd.Connection = con
        If isUpdate Then
            cmd.CommandText = DE_PRODUCE_UPDATE_HOADON
        Else
            cmd.CommandText = DE_PRODUCE_INSERT_HOADON
        End If

        cmd.CommandType = CommandType.StoredProcedure

        Try
            cmd.Parameters.AddWithValue(DE_HD_MAHOPDONG, maHD)
            cmd.Parameters.AddWithValue(DE_HD_NGAYTHU, ngaythu)
            cmd.Parameters.AddWithValue(DE_HD_CACHTHUC, cachthuc)
            cmd.Parameters.AddWithValue(DE_HD_SOTIEN, sotien)
            cmd.ExecuteNonQuery()
            myDbConnecter.DongKetNoi()
            cmd.Dispose()

            If isUpdate Then
                MessageBox.Show("Cập nhật thông tin hóa đơn thành công")
            Else
                MessageBox.Show("Thêm mới thông tin hóa đơn thành công")
            End If
            Return True
        Catch ex As Exception
            myDbConnecter.DongKetNoi()
            cmd.Dispose()
            If isUpdate Then
                MessageBox.Show("Cập nhật thông tin hóa đơn thất bại")
            Else
                MessageBox.Show("Thêm mới thông tin hóa đơn thất bại")
            End If
            Return False
        End Try
    End Function

    'Ham tim kiem thong tin hoadon
    Public Function TimKiemHoaDon(sTuKhoa As String) As DataTable
        Dim myDbConnecter As MyDBConnector
        myDbConnecter = New MyDBConnector()
        con = myDbConnecter.TaoKetNoi()

        Dim sTruyVan As String = "select * from Hoadon where soHoadon like N'%" + sTuKhoa + "%' or maHD like N'%" + sTuKhoa + "%' or ngaythu like N'%" + sTuKhoa + "%' or cachthuc like N'%" + sTuKhoa + "%' or sotien like N'%" + sTuKhoa + "%'"
        Dim da As SqlDataAdapter = New SqlDataAdapter(sTruyVan, con)
        Dim dt As DataTable = New DataTable
        da.Fill(dt)

        myDbConnecter.DongKetNoi()
        da.Dispose()
        Return dt
    End Function

    'Load toan bo danh sach khach hang
    Public Function LoadAllHoaDon() As DataSet
        Dim myDbConnecter As MyDBConnector
        myDbConnecter = New MyDBConnector()
        con = myDbConnecter.TaoKetNoi()

        Dim ds As New DataSet
        Dim sqlcmd As String

        'sqlcmd = "select " + DE_CUS_IDKHACHHANG + " as [" + DE_MAKH_AS + "], " +
        '                             DE_CUS_HOVATEN + " as [" + DE_HOVATEN_AS + "]," +
        '                             DE_CUS_GIOITINH + " as [" + DE_GIOITINH_AS + "], " +
        '                             DE_CUS_TINHTRANG + " as [" + DE_TINHTRANG_AS + "]," +
        '                             DE_CUS_NGAYSINH + " as [" + DE_NGAYSINH_AS + "], " +
        '                             DE_CUS_NOISINH + " as [" + DE_NOISINH_AS + "], " +
        '                             DE_CUS_QUOCTICH + " as [" + DE_QUOCTICH_AS + "], " +
        '                             DE_CUS_SOCMND + " as [" + DE_SOCMND_AS + "], " +
        '                             DE_CUS_NGAYCAP + " as [" + DE_NGAYCAP_AS + "], " +
        '                             DE_CUS_NOICAP + " as [" + DE_NOICAP_AS + "], " +
        '                             DE_CUS_DIACHITHUONGTRU + " as [" + DE_DIACHITHUONGTRU_AS + "], " +
        '                             DE_CUS_NGHENGHIEP + " as [" + DE_NGHENGHIEP_AS + "], " +
        '                             DE_CUS_DIENTHOAI + " as [" + DE_DIENTHOAI_AS + "], " +
        '                             DE_CUS_TENCOQUAN + " as [" + DE_TENCOQUAN_AS + "], " +
        '                             DE_CUS_DIACHICOQUAN + " as [" + DE_DIACHICOQUAN_AS + "], " +
        '                             DE_CUS_THUNHAPMOTNAM + " as [" + DE_THUNHAPMOTNAM_AS + "], " +
        '                             DE_CUS_SOTK + " as [" + DE_SOTK_AS + "]  from " +
        '                             TABLE_KHACHHANG

        sqlcmd = "select * from " + TABLE_HOADON
        Dim da As New SqlDataAdapter(sqlcmd, con)
        da.Fill(ds)
        myDbConnecter.DongKetNoi()
        da.Dispose()

        Return ds
    End Function
End Class
