Public Class FrmMain
    Protected Friend Const TAB_QUANLY_KH As Integer = 0
    Protected Friend Const TAB_QUANLY_BAOHIEM As Integer = 1


    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBoxThemKH.Hide()
        GroupBoxTruyVanKhachHang.Hide()
        GroupBoxThemThongTinBaoHiem.Hide()
        GroupBoxTruyVanThongTinBaoHiem.Hide()
    End Sub

    Private Sub btnThemKH_Click(sender As Object, e As EventArgs) Handles btnThemKH.Click
        GroupBoxThemKH.Show()
        GroupBoxTruyVanKhachHang.Hide()


    End Sub

    Private Sub btnTruyVanThongTinKH_Click(sender As Object, e As EventArgs) Handles btnTruyVanThongTinKH.Click
        GroupBoxThemKH.Hide()
        GroupBoxTruyVanKhachHang.Show()
        Dim mKhachHangController As KhachHangController
        mKhachHangController = New KhachHangController()

        'Fill toan bo data len datagrid
        Dim ds As New DataSet
        ds = mKhachHangController.LoadAllKhachHang()
        DataGridViewKhachHang.DataSource = ds.Tables(0)

        'Neu nhu khong co data thi disable cac nut phia duoi
        If ds.Tables(0).Rows.Count > 0 Then
            btnTaoHopDongBaoHiem.Enabled = True
            btnCapNhatKhachHang.Enabled = True
            btnXoaKhachHang.Enabled = True
        Else
            btnTaoHopDongBaoHiem.Enabled = False
            btnCapNhatKhachHang.Enabled = False
            btnXoaKhachHang.Enabled = False
        End If
    End Sub


    'Xu ly them 1 khach hang
    Private Sub ButtonDongYThemKH_Click(sender As Object, e As EventArgs) Handles ButtonDongYThemKH.Click
        'Check du lieu tren form
        If txtHoVaTen.Text.Length() = 0 Then
            MessageBox.Show("Họ tên đang để trống!")
            txtHoVaTen.Focus()
            Return
        End If
        'Must define

        'Insert vao database
        Dim mKhachHangController As KhachHangController
        mKhachHangController = New KhachHangController()

        Dim gioitinh As Integer
        gioitinh = cbGioiTinh.SelectedIndex

        Dim thunhap As Double
        If Double.TryParse(txtThuNhap.Text, thunhap) Then

        Else
            MessageBox.Show("Số tiền thu nhập không đúng")
            txtThuNhap.Focus()
            Return
        End If

        If mKhachHangController.ThemMoiKhachHang(txtHoVaTen.Text, gioitinh, txtTinhTrang.Text,
                                                 dtNgaySinh.Text, txtNoiSinh.Text, txtQuocTich.Text,
                                                 txtCMND.Text, dtNgayCMND.Text, txtNoiCapCMND.Text,
                                                 txtDiaChiThuongTru.Text, txtNgheNghiep.Text, txtSDT.Text, txtTenCoQuan.Text,
                                                 txtDiaChiCoQuan.Text, 100000, txtSoTKNganHang.Text) Then
            MessageBox.Show("Thêm mới khách hàng thành công")
            GroupBoxThemKH.Hide()
        Else
            MessageBox.Show("Thêm mới khách hàng thất bại!")
        End If
    End Sub

    Private Sub ButtonHuyboThemKH_Click(sender As Object, e As EventArgs) Handles ButtonHuyboThemKH.Click
        GroupBoxThemKH.Hide()
        GroupBoxTruyVanKhachHang.Hide()
    End Sub

    Private Sub btnThemHopDong_Click(sender As Object, e As EventArgs) Handles btnThemHopDong.Click
        GroupBoxThemThongTinBaoHiem.Show()
        GroupBoxTruyVanThongTinBaoHiem.Hide()

    End Sub

    Private Sub btnTruyVanHopDong_Click(sender As Object, e As EventArgs) Handles btnTruyVanHopDong.Click
        GroupBoxThemThongTinBaoHiem.Hide()
        GroupBoxTruyVanThongTinBaoHiem.Show()
    End Sub

    Private Sub btnThemMoiHopDongBH_Click(sender As Object, e As EventArgs) Handles btnThemMoiHopDongBH.Click

    End Sub

    Private Sub btnHuyBoHopDongBH_Click(sender As Object, e As EventArgs) Handles btnHuyBoHopDongBH.Click
        GroupBoxThemThongTinBaoHiem.Hide()
        GroupBoxTruyVanThongTinBaoHiem.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnTaoHopDongBaoHiem_Click(sender As Object, e As EventArgs) Handles btnTaoHopDongBaoHiem.Click
        TabControlMain.SelectedIndex = TAB_QUANLY_BAOHIEM
        txtMaKhachHangBH.Text = "1"
        GroupBoxThemThongTinBaoHiem.Show()
        GroupBoxTruyVanKhachHang.Hide()
    End Sub

    'Tim kiem thong tin khach hang va show len bang
    Private Sub btnTimKiemKhachHang_Click(sender As Object, e As EventArgs) Handles btnTimKiemKhachHang.Click
        Dim mKhachHangController As KhachHangController
        mKhachHangController = New KhachHangController()

        'Hien thi ket qua tim kiem tren datagrid
        Dim sTuKhoa As String
        sTuKhoa = txtTimKiemKhachHang.Text
        Dim dt As DataTable = mKhachHangController.TimKiemKhachHang(sTuKhoa)
        DataGridViewKhachHang.DataSource = dt

        'Neu nhu khong co data thi disable cac nut phia duoi
        If dt.Rows.Count > 0 Then
            btnTaoHopDongBaoHiem.Enabled = True
            btnCapNhatKhachHang.Enabled = True
            btnXoaKhachHang.Enabled = True
        Else
            btnTaoHopDongBaoHiem.Enabled = False
            btnCapNhatKhachHang.Enabled = False
            btnXoaKhachHang.Enabled = False
        End If
    End Sub
End Class
