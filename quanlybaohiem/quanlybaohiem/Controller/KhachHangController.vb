Imports System.Data.SqlClient

Public Class KhachHangController
    Dim con As New SqlConnection

    'define CONST for Custom
    'define as
    Protected Friend Const DE_MAKH_AS As String = "Mã khách hàng"
    Protected Friend Const DE_HOVATEN_AS As String = "họ và tên"
    Protected Friend Const DE_GIOITINH_AS As String = "giới tính (NAM)"
    Protected Friend Const DE_TINHTRANG_AS As String = "tình trạng"
    Protected Friend Const DE_NGAYSINH_AS As String = "ngày sinh"
    Protected Friend Const DE_NOISINH_AS As String = "nơi sinh"
    Protected Friend Const DE_QUOCTICH_AS As String = "quốc tịch"
    Protected Friend Const DE_SOCMND_AS As String = "số cmnd"
    Protected Friend Const DE_NGAYCAP_AS As String = "ngày cấp cmnd"
    Protected Friend Const DE_NOICAP_AS As String = "nơi cấp cmnd"
    Protected Friend Const DE_DIACHITHUONGTRU_AS As String = "địa chỉ thường trú"
    Protected Friend Const DE_NGHENGHIEP_AS As String = "nghề nghiệp"
    Protected Friend Const DE_DIENTHOAI_AS As String = "điện thoại"
    Protected Friend Const DE_TENCOQUAN_AS As String = "tên cơ quan"
    Protected Friend Const DE_DIACHICOQUAN_AS As String = "địa chỉ cơ quan"
    Protected Friend Const DE_THUNHAPMOTNAM_AS As String = "thu nhập một năm"
    Protected Friend Const DE_SOTK_AS As String = "số tk"

    'define column
    Protected Friend Const DE_CUS_IDKHACHHANG As String = "idkhachhang"
    Protected Friend Const DE_CUS_HOVATEN As String = "hovaten"
    Protected Friend Const DE_CUS_GIOITINH As String = "gioitinh"
    Protected Friend Const DE_CUS_TINHTRANG As String = "tinhtrang"
    Protected Friend Const DE_CUS_NGAYSINH As String = "ngaysinh"
    Protected Friend Const DE_CUS_NOISINH As String = "noisinh"
    Protected Friend Const DE_CUS_QUOCTICH As String = "quoctich"
    Protected Friend Const DE_CUS_SOCMND As String = "socmnd"
    Protected Friend Const DE_CUS_NGAYCAP As String = "ngaycap"
    Protected Friend Const DE_CUS_NOICAP As String = "noicap"
    Protected Friend Const DE_CUS_DIACHITHUONGTRU As String = "diachithuongtru"
    Protected Friend Const DE_CUS_NGHENGHIEP As String = "nghenghiep"
    Protected Friend Const DE_CUS_DIENTHOAI As String = "dienthoai"
    Protected Friend Const DE_CUS_TENCOQUAN As String = "tencoquan"
    Protected Friend Const DE_CUS_DIACHICOQUAN As String = "diachicoquan"
    Protected Friend Const DE_CUS_THUNHAPMOTNAM As String = "thunhapmotnam"
    Protected Friend Const DE_CUS_SOTK As String = "sotk"

    Protected Friend Const DE_PRODUCE_INSERT_CUSTOM As String = "insertdataintotableKH"
    Protected Friend Const DE_PRODUCE_UPDATE_CUSTOM As String = "updatedatainsidetableKH"

    'define table
    Protected Friend Const TABLE_TINHTRANGQUANHE As String = "tinhtrangquanhe"
    Protected Friend Const TABLE_KHACHHANG As String = "Khachhang"
    Protected Friend Const TABLE_HOPDONG As String = "hopdong"
    Protected Friend Const TABLE_HOADON As String = "hoadon"

    'Ham them moi khach hang hoac sua khach hang
    'bien xac dinh them moi hoac sua: isUpadte = true thi update, neu khong la them moi
    Public Function ChinhSuaThongTinKhachHang(ByVal isUpdate As Boolean, ByVal hovaten As String, ByVal gioitinh As Integer, tinhtrang As String,
                                     ByVal ngaysinh As String, ByVal noisinh As String, ByVal quoctich As String,
                                     ByVal socmnd As String, ByVal ngaycap As String, ByVal noicap As String,
                                     ByVal diachithuongtru As String, ByVal nghenghiep As String,
                                     ByVal dienthoai As String, ByVal tencoquan As String,
                                     ByVal diachicoquan As String, ByVal thunhapmotnam As Double,
                                     ByVal sotk As String) As Boolean
        Dim myDbConnecter As MyDBConnector
        myDbConnecter = New MyDBConnector()
        con = myDbConnecter.TaoKetNoi()

        Dim cmd As New SqlCommand

        cmd.Connection = con
        If isUpdate Then
            cmd.CommandText = DE_PRODUCE_UPDATE_CUSTOM
        Else
            cmd.CommandText = DE_PRODUCE_INSERT_CUSTOM
        End If

        cmd.CommandType = CommandType.StoredProcedure

        Try
            cmd.Parameters.AddWithValue(DE_CUS_HOVATEN, hovaten)
            cmd.Parameters.AddWithValue(DE_CUS_GIOITINH, gioitinh)
            cmd.Parameters.AddWithValue(DE_CUS_TINHTRANG, tinhtrang)
            cmd.Parameters.AddWithValue(DE_CUS_NGAYSINH, ngaysinh)
            cmd.Parameters.AddWithValue(DE_CUS_NOISINH, noisinh)
            cmd.Parameters.AddWithValue(DE_CUS_QUOCTICH, quoctich)
            cmd.Parameters.AddWithValue(DE_CUS_SOCMND, socmnd)
            cmd.Parameters.AddWithValue(DE_CUS_NGAYCAP, ngaycap)
            cmd.Parameters.AddWithValue(DE_CUS_NOICAP, noicap)
            cmd.Parameters.AddWithValue(DE_CUS_DIACHITHUONGTRU, diachithuongtru)
            cmd.Parameters.AddWithValue(DE_CUS_NGHENGHIEP, nghenghiep)
            cmd.Parameters.AddWithValue(DE_CUS_DIENTHOAI, dienthoai)
            cmd.Parameters.AddWithValue(DE_CUS_TENCOQUAN, tencoquan)
            cmd.Parameters.AddWithValue(DE_CUS_DIACHICOQUAN, diachicoquan)
            cmd.Parameters.AddWithValue(DE_CUS_THUNHAPMOTNAM, thunhapmotnam)
            cmd.Parameters.AddWithValue(DE_CUS_SOTK, sotk)
            cmd.ExecuteNonQuery()
            myDbConnecter.DongKetNoi()
            cmd.Dispose()

            If isUpdate Then
                MessageBox.Show("Cập nhật thông tin khách hàng thành công")
            Else
                MessageBox.Show("Thêm mới thông tin khách hàng thành công")
            End If
            Return True
        Catch ex As Exception
            myDbConnecter.DongKetNoi()
            cmd.Dispose()
            If isUpdate Then
                MessageBox.Show("Cập nhật thông tin khách hàng thất bại")
            Else
                MessageBox.Show("Thêm mới thông tin khách hàng thất bại")
            End If
            Return False
        End Try
    End Function

    'Ham tim kiem thong tin khach hang
    Public Function TimKiemKhachHang(sTuKhoa As String) As DataTable
        Dim myDbConnecter As MyDBConnector
        myDbConnecter = New MyDBConnector()
        con = myDbConnecter.TaoKetNoi()

        Dim sTruyVan As String = "select * from Khachhang where IDKhachhang like N'%" + sTuKhoa + "%' or Hovaten like N'%" + sTuKhoa + "%' or Gioitinh like N'%" + sTuKhoa + "%' or Tinhtrang like N'%" + sTuKhoa + "%' or Ngaysinh like N'%" + sTuKhoa + "%'"
        Dim da As SqlDataAdapter = New SqlDataAdapter(sTruyVan, con)
        Dim dt As DataTable = New DataTable
        da.Fill(dt)

        myDbConnecter.DongKetNoi()
        da.Dispose()
        Return dt
    End Function

    'Load toan bo danh sach khach hang
    Public Function LoadAllKhachHang() As DataSet
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

        sqlcmd = "select * from " + TABLE_KHACHHANG
        Dim da As New SqlDataAdapter(sqlcmd, con)
        da.Fill(ds)
        myDbConnecter.DongKetNoi()
        da.Dispose()

        Return ds
    End Function
End Class
