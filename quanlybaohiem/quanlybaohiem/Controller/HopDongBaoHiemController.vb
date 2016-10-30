﻿Imports System.Data.SqlClient

Public Class HopDongBaoHiemController
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
    Protected Friend Const DE_BOSUNG_AS As String = "Sản phẩm bảo hiểm bổ sung"
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

    Protected Friend Const TABLE_TINHTRANGHONNHAN As String = "tinhtranghonnhan"
    Protected Friend Const TABLE_KHACHHANG As String = "Khachhang"
    Protected Friend Const TABLE_HOPDONG As String = "hopdong"
    Protected Friend Const TABLE_HOADON As String = "hoadon"

    Protected Friend Const DE_PRODUCE_INSERT_HOPDONG As String = "insertdataintotableHD"
    Protected Friend Const DE_PRODUCE_UPDATE_HOPDONG As String = "UpdateDataInsideTableHD"
    ' @IdKhachHang int,
    '@spbaohiem nvarchar(150),
    '@sotienbaohiem float,
    '@kyhanbaohiem nvarchar(50),
    '@dinhkybaohiem nvarchar(50) ,
    '@phibaohiemdinhky float,
    '@sotiendaohan float,
    '@ngaycohieuluc SMALLDATETIME,
    '@sanphambaohiembosung nvarchar(150) ,
    '@phuongthuctra nvarchar(50),
    '@nguongocphibaohiem nvarchar(50),
    '@benhvienduocchitra nvarchar(50)

    'Ham insert hoac update thong tin bao hiem
    'Neu isUpdate = true: update
    '= False = tao moi
    Public Function ChinhSuaThongTinBaoHiem(ByVal isUpdate As Boolean,
                                            ByVal IdKhachHang As Integer, ByVal spbaohiem As String,
                                            ByVal sotienbaohiem As Double, ByVal kyhanbaohiem As String,
                                            ByVal dinhkybaohiem As String, ByVal phibaohiemdinhky As Double,
                                            ByVal sotiendaohan As Double, ByVal ngaycohieuluc As String,
                                            ByVal sanphambaohiembosung As String, phuongthuctra As String,
                                            ByVal nguongocphibaohiem As String, ByVal benhvienduocchitra As String) As Boolean

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
            cmd.Parameters.AddWithValue(de_hop_makhachhang, IdKhachHang)
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
            If isUpdate Then
                MessageBox.Show("Cập nhật thông tin hợp đồng thành công")
            Else
                MessageBox.Show("Thêm mới thông tin hợp đồng thành công")
            End If
            Return True
        Catch ex As Exception
            myDbConnecter.DongKetNoi()
            If isUpdate Then
                MessageBox.Show("Cập nhật thông tin hợp đồng thất bại")
            Else
                MessageBox.Show("Thêm mới thông tin hợp đồng thất bại")
            End If
            Return False
        End Try
    End Function

End Class