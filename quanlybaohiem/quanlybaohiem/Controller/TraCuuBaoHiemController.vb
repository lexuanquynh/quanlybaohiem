Imports System.Data.SqlClient


Public Class TraCuuBaoHiemController
    Dim con As New SqlConnection

    Protected Friend Const DE_MAHD_AS As String = "mã hợp đồng"
    Protected Friend Const DE_IDKH_AS As String = "ID Khách Hàng"
    Protected Friend Const DE_SPBAOHIEM_AS As String = "Sản phẩm bảo hiểm"
    Protected Friend Const DE_SOTIENBAOHIEM_AS As String = "Số tiền bảo hiểm"
    Protected Friend Const DE_KYHANBAOHIEM_AS As String = "Kỳ hạn bảo hiểm"
    Protected Friend Const DE_DINHKYBAOHIEM_AS As String = "Định kỳ bảo hiểm"
    Protected Friend Const DE_PHI_AS As String = "Phí bảo hiểm định kỳ"
    Protected Friend Const DE_SOTIENDAOHAN_AS As String = "Số tiền đáo hạn"
    Protected Friend Const DE_NGAYHD_AS As String = "Ngày có hiệu lực"
    Protected Friend Const DE_PHUONGTHUC_AS As String = "Phương thức trả"
    Protected Friend Const DE_NGUONGOCBAOHIEM_AS As String = "Nguồn gôc phí bảo hiểm"
    Protected Friend Const DE_BENHVIENCHITRA_AS As String = "Bệnh viện được chi trả"

    Protected Friend Const de_hop_mahd As String = "maHD"
    Protected Friend Const de_hop_makhachhang As String = "IDKhachHang"
    Protected Friend Const de_hop_sanphambaohiem As String = "spbaohiem"
    Protected Friend Const de_hop_sotienbaohiem As String = "sotienbaohiem"
    Protected Friend Const de_hop_kyhanbaohiem As String = "kyhanbaohiem"
    Protected Friend Const de_hop_dinhkydongbaohiem As String = "dinhkybaohiem"
    Protected Friend Const de_hop_phi As String = "phibaohiemdinhky"
    Protected Friend Const de_hop_sotiendaohan As String = "sotiendaohan"
    Protected Friend Const de_hop_ngayhd As String = "ngaycohieuluc"
    Protected Friend Const de_hop_bosung As String = "sanphambaohiembosung"
    Protected Friend Const de_hop_phuongthuc As String = "phuongthuctra"
    Protected Friend Const de_hop_nguongoc As String = "nguongocphibaohiem"
    Protected Friend Const de_hop_benhvien As String = "benhvienduocchitra"


    Protected Friend Const TABLE_KHACHHANG As String = "Khachhang"
    Protected Friend Const TABLE_HOPDONG As String = "hopdong"
    Protected Friend Const TABLE_HOADON As String = "hoadon"


    Protected Friend Const DE_PRODUCE_INSERT_HOPDONG As String = "insertdataintotableHD"
    Protected Friend Const DE_PRODUCE_UPDATE_HOPDONG As String = "updatedatainsidetableHD"


    Protected Friend Const DE_HOADON_SOHOADON As String = "soHoadon"
    Protected Friend Const DE_HOADON_MAHD As String = "maHD"
    Protected Friend Const DE_HOADON_NGAYTHU As String = "ngaythu"
    Protected Friend Const DE_HOADON_CACHTHUC As String = "cachthuc"
    Protected Friend Const DE_HOADON_SOTIEN As String = "sotien"


    Protected Friend Const DE_PRODUCE_INSERT_HOADON As String = "InsertDataIntoTableHoadon"
    Protected Friend Const DE_PRODUCE_UPDATE_HOADON As String = "UpdateDataInsideTableHoadon"
    Protected Friend Const DE_PRODUCE_DELETE_HOADON As String = "DeleteDataFromTableHoadon"
 
    Public Function ChinhSuaThongTinBaoHiem(ByVal isUpdate As Boolean, ByVal IDKhachHang As Integer, ByVal spbaohiem As String, sotienbaohiem As Double,
                                   ByVal kyhanbaohiem As String, ByVal dinhkybaohiem As String, ByVal phibaohiemdinhky As Double,
                                   ByVal sotiendaohan As Double, ByVal ngaycohieuluc As String, ByVal sanphambaohiembosung As String,
                                   ByVal phuongthuctra As String, ByVal nguongocphibaohiem As String,
                                   ByVal benhvienduocchitra As String) As Boolean
        Dim myDbConnecter As MyDBConnector
        myDbConnecter = New MyDBConnector()
        con = myDbConnecter.TaoKetNoi()

        Dim cmd As New SqlCommand

        cmd.Connection = con
        If isUpdate Then
            cmd.CommandText = DE_PRODUCE_UPDATE_HOPDONG
        Else
            cmd.CommandText = DE_PRODUCE_INSERT_HOPDONG
        End If

        cmd.CommandType = CommandType.StoredProcedure

        Try


            cmd.Parameters.AddWithValue(de_hop_makhachhang, IDKhachHang)
            cmd.Parameters.AddWithValue(de_hop_sanphambaohiem, spbaohiem)
            cmd.Parameters.AddWithValue(de_hop_sotienbaohiem, sotienbaohiem)
            cmd.Parameters.AddWithValue(de_hop_kyhanbaohiem, kyhanbaohiem)
            cmd.Parameters.AddWithValue(de_hop_dinhkydongbaohiem, dinhkybaohiem)
            cmd.Parameters.AddWithValue(de_hop_phi, phibaohiemdinhky)
            cmd.Parameters.AddWithValue(de_hop_sotiendaohan, sotiendaohan)
            cmd.Parameters.AddWithValue(de_hop_ngayhd, ngaycohieuluc)
            cmd.Parameters.AddWithValue(de_hop_bosung, sanphambaohiembosung)
            cmd.Parameters.AddWithValue(de_hop_phuongthuc, phuongthuctra)
            cmd.Parameters.AddWithValue(de_hop_nguongoc, nguongocphibaohiem)
            cmd.Parameters.AddWithValue(de_hop_benhvien, benhvienduocchitra)
            cmd.ExecuteNonQuery()
            myDbConnecter.DongKetNoi()
            cmd.Dispose()
            If isUpdate Then
                MessageBox.Show("Cập nhật thông tin bảo hiểm thành công")
            Else
                MessageBox.Show("Thêm mới thông tin bảo hiểm thành công")
            End If
            Return True
        Catch ex As Exception
            myDbConnecter.DongKetNoi()
            cmd.Dispose()
            If isUpdate Then
                MessageBox.Show("Cập nhật thông tin bảo hiểm thất bại")
            Else
                MessageBox.Show("Thêm mới thông tin bảo hiểmg thất bại")
            End If
            Return False
        End Try
    End Function

    'Ham tim kiem thong tin bảo hiểm
    Public Function TraCuuHopDongBaoHiemTheoNgay(ByVal ngay As String, ByVal thang As String, ByVal nam As String) As DataTable
        Dim myDbConnecter As MyDBConnector
        myDbConnecter = New MyDBConnector()
        con = myDbConnecter.TaoKetNoi()

        Dim sTruyVan As String = String.Format("select * from Hopdong where day(ngaycohieuluc) = {0} and month(ngaycohieuluc) = {1}", ngay, thang)
        Dim da As SqlDataAdapter = New SqlDataAdapter(sTruyVan, con)
        Dim dt As DataTable = New DataTable
        da.Fill(dt)

        myDbConnecter.DongKetNoi()
        Return dt
    End Function

    '    @soHoadon int,
    '@maHD int,
    '@ngaythu smalldatetime,
    '@cachthuc nvarchar (50),
    '@sotien float
    'Chinh sua thong tin hoa don
    Public Function ChinhSuaThongTinHoaDon(ByVal isUpdate As Boolean, ByVal soHoadon As Integer, ByVal maHD As Integer, ByVal ngaythu As String,
                                           cachthuc As String, ByVal sotien As Double) As Boolean
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
            If isUpdate Then
                cmd.Parameters.AddWithValue(DE_HOADON_SOHOADON, soHoadon)
            End If
            cmd.Parameters.AddWithValue(DE_HOADON_MAHD, maHD)
            cmd.Parameters.AddWithValue(DE_HOADON_NGAYTHU, DateTime.Parse(ngaythu))
            cmd.Parameters.AddWithValue(DE_HOADON_CACHTHUC, cachthuc)
            cmd.Parameters.AddWithValue(DE_HOADON_SOTIEN, sotien)
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

    'Load toan bo danh sach khach hang
    Public Function LoadAllHoaDon() As DataSet
        Dim myDbConnecter As MyDBConnector
        myDbConnecter = New MyDBConnector()
        con = myDbConnecter.TaoKetNoi()

        Dim ds As New DataSet
        Dim sqlcmd As String
        sqlcmd = "select * from " + TABLE_HOADON
        Dim da As New SqlDataAdapter(sqlcmd, con)
        da.Fill(ds)
        myDbConnecter.DongKetNoi()
        da.Dispose()

        Return ds
    End Function

    'Ham xoa hoa don
    Public Function XoaThongTinHoaDon(soHoadon As Integer) As Boolean
        Dim myDbConnecter As MyDBConnector
        myDbConnecter = New MyDBConnector()
        con = myDbConnecter.TaoKetNoi()

        Dim cmd As New SqlCommand
        cmd.Connection = con
        cmd.CommandText = DE_PRODUCE_DELETE_HOADON
        cmd.CommandType = CommandType.StoredProcedure
        Try
            cmd.Parameters.AddWithValue(DE_HOADON_SOHOADON, soHoadon)
            cmd.ExecuteNonQuery()
            myDbConnecter.DongKetNoi()
            cmd.Dispose()
            MessageBox.Show("Xóa hóa đơn thành công")
            Return True
        Catch ex As Exception
            myDbConnecter.DongKetNoi()
            cmd.Dispose()
            MessageBox.Show("Xóa hóa đơn thất bại")
            Return False
        End Try
    End Function

    'Tim kiem hoa don
    Public Function TimKiemHoaDon(sTuKhoa As String) As DataTable
        Dim myDbConnecter As MyDBConnector
        myDbConnecter = New MyDBConnector()
        con = myDbConnecter.TaoKetNoi()

        Dim sTruyVan As String = "select * from HoaDon where maHD like N'%" + sTuKhoa + "%' or ngaythu like N'%" + sTuKhoa + "%' or cachthuc like N'%" + sTuKhoa + "%' or sotien like N'%" + sTuKhoa + "%'"
        Dim da As SqlDataAdapter = New SqlDataAdapter(sTruyVan, con)
        Dim dt As DataTable = New DataTable
        da.Fill(dt)

        myDbConnecter.DongKetNoi()
        da.Dispose()
        Return dt
    End Function

    Public Function LoadData(ngay As Integer, thang As Integer, nam As Integer) As DataTable
        Dim myDbConnecter As MyDBConnector
        myDbConnecter = New MyDBConnector()
        con = myDbConnecter.TaoKetNoi()

        Dim sTruyVan As String = String.Format("select * from Hoadon where day(ngaythu) ={0} and month(ngaythu) = {1} and year(ngaythu) = {2}", ngay, thang, nam)
        Dim da As SqlDataAdapter = New SqlDataAdapter(sTruyVan, con)
        Dim dt As DataTable = New DataTable
        da.Fill(dt)
        myDbConnecter.DongKetNoi()
        Return dt
    End Function
    Public Function LoadData2(ngay As Integer, thang As Integer) As DataTable
        Dim myDbConnecter As MyDBConnector
        myDbConnecter = New MyDBConnector()
        con = myDbConnecter.TaoKetNoi()

        Dim sTruyVan As String = String.Format("select * from Hopdong where day(ngaycohieuluc) = {0} and month(ngaycohieuluc) = {1}", ngay, thang)
        Dim da As SqlDataAdapter = New SqlDataAdapter(sTruyVan, con)
        Dim dt As DataTable = New DataTable
        da.Fill(dt)
        myDbConnecter.DongKetNoi()
        Return dt
    End Function
End Class
