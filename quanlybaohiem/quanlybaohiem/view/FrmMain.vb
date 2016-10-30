Public Class FrmMain
    Protected Friend Const TAB_QUANLY_KH As Integer = 0
    Protected Friend Const TAB_QUANLY_BAOHIEM As Integer = 1


    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GroupBoxThemKH.Hide()
        GroupBoxTruyVanKhachHang.Hide()
        GroupBoxThemThongTinBaoHiem.Hide()
        GroupBoxTruyVanThongTinBaoHiem.Hide()
    End Sub


    'Them moikhach hang
    Private Sub btnThemKH_Click(sender As Object, e As EventArgs) Handles btnThemKH.Click
        GroupBoxThemKH.Show()
        GroupBoxTruyVanKhachHang.Hide()

        ClearTextBoxKH()

        ButtonDongYThemKH.Enabled = True
        btnTaoHopDongBaoHiem.Enabled = False
        btnCapNhatKhachHang.Enabled = False
        btnXoaKhachHang.Enabled = False
    End Sub

    'Truy van thong tin khach hang
    Private Sub btnTruyVanThongTinKH_Click(sender As Object, e As EventArgs) Handles btnTruyVanThongTinKH.Click
        GroupBoxThemKH.Show()
        GroupBoxTruyVanKhachHang.Show()
        Dim mKhachHangController As KhachHangController
        mKhachHangController = New KhachHangController()

        'Fill toan bo data len datagrid
        Dim ds As New DataSet
        ds = mKhachHangController.LoadAllKhachHang()
        DataGridViewKhachHang.DataSource = ds.Tables(0)
        ds.Dispose()
    End Sub

    'Ham kiem tra du lieu nhap vao da dung chua
    Private Sub CheckInput()
        'Check du lieu tren form
        If txtHoVaTen.Text.Length() = 0 Then
            MessageBox.Show("Họ tên đang để trống!")
            txtHoVaTen.Focus()
            Return
        End If
        'Must define
    End Sub

    'Xu ly them 1 khach hang
    Private Sub ButtonDongYThemKH_Click(sender As Object, e As EventArgs) Handles ButtonDongYThemKH.Click


        'Insert vao database
        Dim mKhachHangController As KhachHangController
        mKhachHangController = New KhachHangController()

        If txtHoVaTen.Text.Length() = 0 Then
            MessageBox.Show("Họ tên đang để trống!")
            txtHoVaTen.Focus()
            Return
        End If

        Dim makhachhang As Integer
        If Double.TryParse(txtMaKH.Text, makhachhang) Then

        End If
        Dim gioitinh As Integer
        gioitinh = cbGioiTinh.SelectedIndex

        Dim thunhap As Double
        If Double.TryParse(txtThuNhapHangNam.Text, thunhap) Then

        Else
            MessageBox.Show("Số tiền thu nhập không đúng")
            txtThuNhapHangNam.Focus()
            Return
        End If

        If mKhachHangController.ChinhSuaThongTinKhachHang(False, makhachhang, txtHoVaTen.Text, gioitinh, txtTinhTrang.Text,
                                                 dtNgaySinh.Text, txtNoiSinh.Text, txtQuocTich.Text,
                                                 txtCMND.Text, dtNgayCMND.Text, txtNoiCapCMND.Text,
                                                 txtDiaChiThuongTru.Text, txtNgheNghiep.Text, txtSDT.Text, txtTenCoQuan.Text,
                                                 txtDiaChiCoQuan.Text, thunhap, txtSoTKNganHang.Text) Then
            GroupBoxThemKH.Hide()
        End If
    End Sub

    Private Sub ButtonHuyboThemKH_Click(sender As Object, e As EventArgs) Handles ButtonHuyboThemKH.Click
        GroupBoxThemKH.Hide()
        GroupBoxTruyVanKhachHang.Hide()
    End Sub

    Private Sub btnThemHopDong_Click(sender As Object, e As EventArgs) Handles btnThemHopDong.Click
        GroupBoxThemThongTinBaoHiem.Show()
        GroupBoxTruyVanThongTinBaoHiem.Hide()
        btnThemMoiHopDongBH.Enabled = True
    End Sub

    Private Sub btnTruyVanHopDong_Click(sender As Object, e As EventArgs) Handles btnTruyVanHopDong.Click
        GroupBoxThemThongTinBaoHiem.Show()
        GroupBoxTruyVanThongTinBaoHiem.Show()
        Dim mTraCuuBaoHiemController As HopDongBaoHiemController
        mTraCuuBaoHiemController = New HopDongBaoHiemController()

        'Fill toan bo data len datagrid
        Dim ds As New DataSet
        ds = mTraCuuBaoHiemController.LoadAllBaoHiem()
        DataGridViewThongTinBaoHiem.DataSource = ds.Tables(0)
        ds.Dispose()
    End Sub

    'Check thong tin nhap dung chua tren form nhap ho so bao hiem
    Private Sub CheckInputBaoHiem()

    End Sub

    'Ham them moi bao hiem
    Private Sub btnThemMoiHopDongBH_Click(sender As Object, e As EventArgs) Handles btnThemMoiHopDongBH.Click
        CheckInputBaoHiem()
      

        'Insert vao database
        Dim mHopDongBaoHiemController As HopDongBaoHiemController
        mHopDongBaoHiemController = New HopDongBaoHiemController()

        Dim sotienBaohiem As Double
        If Double.TryParse(txtSoTienBaoHiem.Text, sotienBaohiem) Then

        Else
            MessageBox.Show("Số tiền bảo hiểm không đúng")
            txtSoTienBaoHiem.Focus()
            Return
        End If

        Dim maHopDong As Integer
        If Double.TryParse(txtMaHDBaoHiem.Text, maHopDong) Then

        Else
            'MessageBox.Show("Mã hợp đồng không đúng")
            'txtMaHDBaoHiem.Focus()
            'Return
        End If

        Dim maKhachHang As Integer
        If Double.TryParse(txtMaKhachHangBH.Text, maKhachHang) Then

        Else
            MessageBox.Show("Mã khách hàng không đúng")
            txtMaKhachHangBH.Focus()
            Return
        End If

        Dim phiBaoHiemDinhKy As Double
        If Double.TryParse(txtPhiBaoHiemDinhKy.Text, phiBaoHiemDinhKy) Then

        Else
            MessageBox.Show("Số tiền bảo hiểm định kỳ không đúng")
            txtPhiBaoHiemDinhKy.Focus()
            Return
        End If

        Dim soTienDaoHan As Double
        If Double.TryParse(txtSoTienDaoHanBH.Text, soTienDaoHan) Then

        Else
            MessageBox.Show("Số tiền đáo hạn không đúng")
            txtSoTienDaoHanBH.Focus()
            Return
        End If

        If mHopDongBaoHiemController.ChinhSuaThongTinBaoHiem(False, maHopDong, maKhachHang, txtSanPhamBHBoSung.Text, sotienBaohiem,
                                                             txtKyHanBaoHiem.Text, txtDinhKyDongBaoHiem.Text, phiBaoHiemDinhKy, soTienDaoHan,
                                                             dtNgayHieuLucHD.Text, txtSanPhamBHBoSung.Text, txtPhuongThucDongBH.Text,
                                                             txtNguonGocPhiBaoHiem.Text, txtBenhVienChiTra.Text) Then

        End If
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

    'Ham cap nhat thong tin khach hang
    Private Sub btnCapNhatKhachHang_Click(sender As Object, e As EventArgs) Handles btnCapNhatKhachHang.Click
        'CheckInput()
        'Insert vao database
        Dim mKhachHangController As KhachHangController
        mKhachHangController = New KhachHangController()

        Dim makhachHang As Integer
        If Double.TryParse(txtMaKH.Text, makhachHang) Then

        Else
            MessageBox.Show("Mã khách hàng nhập không đúng")
            txtMaKH.Focus()
            Return

        End If
        Dim gioitinh As Integer
        gioitinh = cbGioiTinh.SelectedIndex

        Dim thunhap As Double
        If Double.TryParse(txtThuNhapHangNam.Text, thunhap) Then

        Else
            MessageBox.Show("Số tiền thu nhập không đúng")
            txtThuNhapHangNam.Focus()
            Return
        End If

        If mKhachHangController.ChinhSuaThongTinKhachHang(True, makhachHang, txtHoVaTen.Text, gioitinh, txtTinhTrang.Text,
                                                 dtNgaySinh.Text, txtNoiSinh.Text, txtQuocTich.Text,
                                                 txtCMND.Text, dtNgayCMND.Text, txtNoiCapCMND.Text,
                                                 txtDiaChiThuongTru.Text, txtNgheNghiep.Text, txtSDT.Text, txtTenCoQuan.Text,
                                                 txtDiaChiCoQuan.Text, 100000, txtSoTKNganHang.Text) Then
            'GroupBoxThemKH.Hide()
            'Fill toan bo data len datagrid
            Dim ds As New DataSet
            ds = mKhachHangController.LoadAllKhachHang()
            DataGridViewKhachHang.DataSource = ds.Tables(0)
            ds.Dispose()
        End If
    End Sub

    'Clear KH form
    Private Sub ClearTextBoxKH()
        txtMaKH.DataBindings.Clear()
        txtMaKH.Text = ""
    End Sub

    'Add data len form
    Private Sub LoadTextBoxKH()
        txtMaKH.DataBindings.Clear()
        txtMaKH.DataBindings.Add("Text", DataGridViewKhachHang.DataSource, "IDKhachHang")

        txtHoVaTen.DataBindings.Clear()
        txtHoVaTen.DataBindings.Add("Text", DataGridViewKhachHang.DataSource, "hovaten")

        cbGioiTinh.DataBindings.Clear()
        cbGioiTinh.DataBindings.Add("Text", DataGridViewKhachHang.DataSource, "gioitinh")

        txtTinhTrang.DataBindings.Clear()
        txtTinhTrang.DataBindings.Add("Text", DataGridViewKhachHang.DataSource, "tinhtrang")

        dtNgaySinh.DataBindings.Clear()
        dtNgaySinh.DataBindings.Add("Text", DataGridViewKhachHang.DataSource, "ngaysinh")

        txtNoiSinh.DataBindings.Clear()
        txtNoiSinh.DataBindings.Add("Text", DataGridViewKhachHang.DataSource, "noisinh")

        txtQuocTich.DataBindings.Clear()
        txtQuocTich.DataBindings.Add("Text", DataGridViewKhachHang.DataSource, "quoctich")

        txtCMND.DataBindings.Clear()
        txtCMND.DataBindings.Add("Text", DataGridViewKhachHang.DataSource, "socmnd")

        dtNgayCMND.DataBindings.Clear()
        dtNgayCMND.DataBindings.Add("Text", DataGridViewKhachHang.DataSource, "ngaycap")

        txtNoiCapCMND.DataBindings.Clear()
        txtNoiCapCMND.DataBindings.Add("Text", DataGridViewKhachHang.DataSource, "noicap")

        txtDiaChiThuongTru.DataBindings.Clear()
        txtDiaChiThuongTru.DataBindings.Add("Text", DataGridViewKhachHang.DataSource, "diachithuongtru")

        txtNgheNghiep.DataBindings.Clear()
        txtNgheNghiep.DataBindings.Add("Text", DataGridViewKhachHang.DataSource, "nghenghiep")

        txtSDT.DataBindings.Clear()
        txtSDT.DataBindings.Add("Text", DataGridViewKhachHang.DataSource, "dienthoai")

        txtTenCoQuan.DataBindings.Clear()
        txtTenCoQuan.DataBindings.Add("Text", DataGridViewKhachHang.DataSource, "tencoquan")

        txtDiaChiCoQuan.DataBindings.Clear()
        txtDiaChiCoQuan.DataBindings.Add("Text", DataGridViewKhachHang.DataSource, "diachicoquan")

        txtThuNhapHangNam.DataBindings.Clear()
        txtThuNhapHangNam.DataBindings.Add("Text", DataGridViewKhachHang.DataSource, "thunhapmotnam")

        txtSoTKNganHang.DataBindings.Clear()
        txtSoTKNganHang.DataBindings.Add("Text", DataGridViewKhachHang.DataSource, "sotk")
    End Sub

    Private Sub DataGridViewKhachHang_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewKhachHang.CellContentClick
        LoadTextBoxKH()

        ButtonDongYThemKH.Enabled = False
        btnTaoHopDongBaoHiem.Enabled = True
        btnCapNhatKhachHang.Enabled = True
        btnXoaKhachHang.Enabled = True

    End Sub

    Private Sub btnXoaKhachHang_Click(sender As Object, e As EventArgs) Handles btnXoaKhachHang.Click
        Dim mKhachHangController As KhachHangController
        mKhachHangController = New KhachHangController()

        Dim makhachhang As Integer
        If Double.TryParse(txtMaKH.Text, makhachhang) Then
        End If

        If mKhachHangController.XoaThongTinKhachHang(makhachhang) Then
            MessageBox.Show("Xóa khách hàng thành công!")
            Dim ds As New DataSet
            ds = mKhachHangController.LoadAllKhachHang()
            DataGridViewKhachHang.DataSource = ds.Tables(0)
            ds.Dispose()
        Else
            MessageBox.Show("Xóa khách hàng thất bại. Có ràng buộc data với các bảng khác!")
        End If
    End Sub

    Private Sub btnTimKiemHopDong_Click(sender As Object, e As EventArgs) Handles btnTimKiemHopDong.Click
        Dim mHopDongBaoHiemController As HopDongBaoHiemController
        mHopDongBaoHiemController = New HopDongBaoHiemController()

        'Hien thi ket qua tim kiem tren datagrid
        Dim sTuKhoa As String
        sTuKhoa = txtTruyvanBaoHiem.Text
        Dim dt As DataTable = mHopDongBaoHiemController.TimKiemBaoHiem(sTuKhoa)
        DataGridViewThongTinBaoHiem.DataSource = dt

        'Neu nhu khong co data thi disable cac nut phia duoi
        If dt.Rows.Count > 0 Then
            btnThemMoiHopDongBH.Enabled = True
            btnCapNhatHoSoBaoHiem.Enabled = True
            btnXoaHoSoBaoHiem.Enabled = True
        Else
            btnThemMoiHopDongBH.Enabled = False
            btnCapNhatHoSoBaoHiem.Enabled = False
            btnXoaHoSoBaoHiem.Enabled = False
        End If
    End Sub

    Private Sub btnCapNhatHoSoBaoHiem_Click(sender As Object, e As EventArgs) Handles btnCapNhatHoSoBaoHiem.Click
        Dim mHopDongBaoHiemController As HopDongBaoHiemController
        mHopDongBaoHiemController = New HopDongBaoHiemController()

        Dim maHopDong As Integer
        If Double.TryParse(txtMaHDBaoHiem.Text, maHopDong) Then

        Else
            MessageBox.Show("Mã hợp đồng không đúng")
            txtMaHDBaoHiem.Focus()
            Return
        End If

        Dim makhachHang As Integer
        If Double.TryParse(txtMaKhachHangBH.Text, makhachHang) Then

        Else
            MessageBox.Show("Mã khách hàng nhập không đúng")
            txtMaKhachHangBH.Focus()
            Return
        End If

        Dim sotienbaohiem As Double
        If Double.TryParse(txtSoTienBaoHiem.Text, sotienbaohiem) Then

        Else
            MessageBox.Show("Số tiền bảo hiểm nhập không đúng")
            txtSoTienBaoHiem.Focus()
            Return
        End If

        Dim phibaohiemdinhky As Double
        If Double.TryParse(txtPhiBaoHiemDinhKy.Text, phibaohiemdinhky) Then

        Else
            MessageBox.Show("Phí bảo hiểm định kỳ nhập không đúng")
            txtPhiBaoHiemDinhKy.Focus()
            Return
        End If

        Dim sotiendaohan As Double
        If Double.TryParse(txtSoTienDaoHanBH.Text, sotiendaohan) Then

        Else
            MessageBox.Show("Số tiền đáo hạn nhập không đúng")
            txtSoTienDaoHanBH.Focus()
            Return
        End If

        If mHopDongBaoHiemController.ChinhSuaThongTinBaoHiem(True, maHopDong, makhachHang, txtSanPhamBaoHiem.Text,
                                                             sotienbaohiem, txtKyHanBaoHiem.Text, txtDinhKyDongBaoHiem.Text,
                                                             phibaohiemdinhky, sotiendaohan, dtNgayHieuLucHD.Text,
                                                             txtSanPhamBHBoSung.Text, txtPhuongThucDongBH.Text,
                                                             txtNguonGocPhiBaoHiem.Text, txtBenhVienChiTra.Text) Then
            'GroupBoxThemKH.Hide()
            'Fill toan bo data len datagrid
            Dim ds As New DataSet
            ds = mHopDongBaoHiemController.LoadAllBaoHiem()
            DataGridViewKhachHang.DataSource = ds.Tables(0)
            ds.Dispose()
        End If
    End Sub

    'Ham load thong tin bao hiem
    Private Sub LoadTextBoxBaoHiem()
        txtMaHDBaoHiem.DataBindings.Clear()
        txtMaHDBaoHiem.DataBindings.Add("Text", DataGridViewThongTinBaoHiem.DataSource, "maHD")

        txtMaKhachHangBH.DataBindings.Clear()
        txtMaKhachHangBH.DataBindings.Add("Text", DataGridViewThongTinBaoHiem.DataSource, "IdKhachHang")

        txtSanPhamBaoHiem.DataBindings.Clear()
        txtSanPhamBaoHiem.DataBindings.Add("Text", DataGridViewThongTinBaoHiem.DataSource, "spbaohiem")

        txtSoTienBaoHiem.DataBindings.Clear()
        txtSoTienBaoHiem.DataBindings.Add("Text", DataGridViewThongTinBaoHiem.DataSource, "sotienbaohiem")

        txtKyHanBaoHiem.DataBindings.Clear()
        txtKyHanBaoHiem.DataBindings.Add("Text", DataGridViewThongTinBaoHiem.DataSource, "kyhanbaohiem")

        txtDinhKyDongBaoHiem.DataBindings.Clear()
        txtDinhKyDongBaoHiem.DataBindings.Add("Text", DataGridViewThongTinBaoHiem.DataSource, "dinhkybaohiem")

        txtPhiBaoHiemDinhKy.DataBindings.Clear()
        txtPhiBaoHiemDinhKy.DataBindings.Add("Text", DataGridViewThongTinBaoHiem.DataSource, "phibaohiemdinhky")

        txtSoTienDaoHanBH.DataBindings.Clear()
        txtSoTienDaoHanBH.DataBindings.Add("Text", DataGridViewThongTinBaoHiem.DataSource, "sotiendaohan")

        dtNgayHieuLucHD.DataBindings.Clear()
        dtNgayHieuLucHD.DataBindings.Add("Text", DataGridViewThongTinBaoHiem.DataSource, "ngaycohieuluc")

        txtSanPhamBHBoSung.DataBindings.Clear()
        txtSanPhamBHBoSung.DataBindings.Add("Text", DataGridViewThongTinBaoHiem.DataSource, "sanphambaohiembosung")

        txtPhuongThucDongBH.DataBindings.Clear()
        txtPhuongThucDongBH.DataBindings.Add("Text", DataGridViewThongTinBaoHiem.DataSource, "phuongthuctra")

        txtNguonGocPhiBaoHiem.DataBindings.Clear()
        txtNguonGocPhiBaoHiem.DataBindings.Add("Text", DataGridViewThongTinBaoHiem.DataSource, "nguongocphibaohiem")

        txtBenhVienChiTra.DataBindings.Clear()
        txtBenhVienChiTra.DataBindings.Add("Text", DataGridViewThongTinBaoHiem.DataSource, "benhvienduocchitra")
    End Sub

    Private Sub DataGridViewThongTinBaoHiem_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewThongTinBaoHiem.CellContentClick
        LoadTextBoxBaoHiem()

        btnThemMoiHopDongBH.Enabled = False
        btnCapNhatHoSoBaoHiem.Enabled = True
        btnXoaHoSoBaoHiem.Enabled = True
        'btnXoaKhachHang.Enabled = True
    End Sub

    Private Sub btnXoaHoSoBaoHiem_Click(sender As Object, e As EventArgs) Handles btnXoaHoSoBaoHiem.Click
        Dim mHopDongBaoHiemController As HopDongBaoHiemController
        mHopDongBaoHiemController = New HopDongBaoHiemController()

        Dim maHopDong As Integer
        If Double.TryParse(txtMaHDBaoHiem.Text, maHopDong) Then
        End If

        If mHopDongBaoHiemController.XoaThongTinBaoHiem(maHopDong) Then
            MessageBox.Show("Xóa hợp đồng bảo hiểm thành công!")

            'Fill toan bo data len datagrid
            Dim ds As New DataSet
            ds = mHopDongBaoHiemController.LoadAllBaoHiem()
            DataGridViewThongTinBaoHiem.DataSource = ds.Tables(0)
            ds.Dispose()
        Else
            MessageBox.Show("Xóa hợp đồng bảo hiểm thất bại. Có ràng buộc data với các bảng khác!")
        End If
    End Sub

    Private Sub btnTimDanhSachNopPhi_Click(sender As Object, e As EventArgs) Handles btnTimDanhSachNopPhi.Click
        Dim mTraCuuBaoHiemController As TraCuuBaoHiemController
        mTraCuuBaoHiemController = New TraCuuBaoHiemController()

        Dim tgian As DateTime = dtThoiGianNopPhi.Value
        Dim ngay As Integer = tgian.Day
        Dim thang As Integer = tgian.Month
        Dim nam As Integer = tgian.Year

        'Hien thi ket qua tim kiem tren datagrid
        Dim sTuKhoa As String
        sTuKhoa = txtTruyvanBaoHiem.Text
        Dim dt As DataTable = mTraCuuBaoHiemController.TraCuuHopDongBaoHiemTheoNgay(ngay, thang, nam)
        DataGridViewDanhSachNopPhi.DataSource = dt
    End Sub

    Private Sub DataGridViewDanhSachNopPhi_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDanhSachNopPhi.CellContentClick

    End Sub

    'Clear toan bo text tren form
    Private Sub ClearTextBoxHoaDon()
        btnCapNhatHoaDon.Enabled = False
        btnXoaHoaDon.Enabled = False

        txtMaHoaDon.DataBindings.Clear()
        txtMaHoaDon.Text = ""

        txtMaHopDongHoaDon.DataBindings.Clear()
        txtMaHopDongHoaDon.Text = ""

        dtNgayThuHoaDon.DataBindings.Clear()
        dtNgayThuHoaDon.Text = ""

        txtCachThucNopTienHoaDon.DataBindings.Clear()
        txtCachThucNopTienHoaDon.Text = ""

        txtSoTienHoaDon.DataBindings.Clear()
        txtSoTienHoaDon.Text = ""
    End Sub

    Private Sub btnCapNhatHoaDon_Click(sender As Object, e As EventArgs) Handles btnCapNhatHoaDon.Click
        'Insert vao database
        Dim mTraCuuBaoHiemController As TraCuuBaoHiemController
        mTraCuuBaoHiemController = New TraCuuBaoHiemController()

        Dim sohoadon As Integer
        If Double.TryParse(txtMaHoaDon.Text, sohoadon) Then

        Else

        End If

        Dim mahopdong As Integer
        If Double.TryParse(txtMaHopDongHoaDon.Text, mahopdong) Then

        Else
            MessageBox.Show("Mã hợp đồng nhập không đúng")
            txtMaHopDongHoaDon.Focus()
            Return

        End If

        Dim sotien As Double
        If Double.TryParse(txtSoTienHoaDon.Text, sotien) Then

        Else
            MessageBox.Show("Số tiền hóa đơn nhập không đúng")
            txtSoTienHoaDon.Focus()
            Return

        End If
        If mTraCuuBaoHiemController.ChinhSuaThongTinHoaDon(True, sohoadon, mahopdong, dtNgayThuHoaDon.Text,
                                                           txtCachThucNopTienHoaDon.Text, sotien) Then
            Dim ds As New DataSet
            ds = mTraCuuBaoHiemController.LoadAllHoaDon()
            DataGridViewThongTinHoaDon.DataSource = ds.Tables(0)
            ds.Dispose()
            ClearTextBoxHoaDon()
        End If
    End Sub

    'Tao moi hoa don
    Private Sub btnTaoHoaDon_Click(sender As Object, e As EventArgs) Handles btnTaoHoaDon.Click
        'Insert vao database
        Dim mTraCuuBaoHiemController As TraCuuBaoHiemController
        mTraCuuBaoHiemController = New TraCuuBaoHiemController()

        'Dim makhachhang As Integer
        'If Double.TryParse(txtMaKH.Text, makhachhang) Then

        'End If
        'Dim gioitinh As Integer
        'gioitinh = cbGioiTinh.SelectedIndex

        Dim sohoadon As Integer
        If Double.TryParse(txtMaHoaDon.Text, sohoadon) Then

        Else
            'MessageBox.Show("Mã hóa đơn nhập không đúng")
            'txtMaHoaDon.Focus()
            'Return
        End If

        Dim mahopdong As Integer
        If Double.TryParse(txtMaHopDongHoaDon.Text, mahopdong) Then

        Else
            MessageBox.Show("Mã hợp đồng nhập không đúng")
            txtMaHopDongHoaDon.Focus()
            Return

        End If

        Dim sotien As Double
        If Double.TryParse(txtSoTienHoaDon.Text, sotien) Then

        Else
            MessageBox.Show("Số tiền hóa đơn nhập không đúng")
            txtSoTienHoaDon.Focus()
            Return

        End If
        If mTraCuuBaoHiemController.ChinhSuaThongTinHoaDon(False, sohoadon, mahopdong, dtNgayThuHoaDon.Text,
                                                           txtCachThucNopTienHoaDon.Text, sotien) Then
            ClearTextBoxHoaDon()
            'Fill toan bo data len datagrid
            Dim ds As New DataSet
            ds = mTraCuuBaoHiemController.LoadAllHoaDon()
            DataGridViewThongTinHoaDon.DataSource = ds.Tables(0)
            ds.Dispose()
        End If
    End Sub

    'Xoa hoa don
    Private Sub btnXoaHoaDon_Click(sender As Object, e As EventArgs) Handles btnXoaHoaDon.Click
        Dim mTraCuuBaoHiemController As TraCuuBaoHiemController
        mTraCuuBaoHiemController = New TraCuuBaoHiemController()

        Dim sohoadon As Integer
        If Double.TryParse(txtMaHoaDon.Text, sohoadon) Then

        Else

        End If

       
        If mTraCuuBaoHiemController.XoaThongTinHoaDon(sohoadon) Then
            ClearTextBoxHoaDon()
            Dim ds As New DataSet
            ds = mTraCuuBaoHiemController.LoadAllHoaDon()
            DataGridViewThongTinHoaDon.DataSource = ds.Tables(0)
            ds.Dispose()
        End If
    End Sub

    'Ham load thong tin hoa don
    Private Sub LoadTextBoxHoaDon()
        txtMaHoaDon.DataBindings.Clear()
        txtMaHoaDon.DataBindings.Add("Text", DataGridViewThongTinHoaDon.DataSource, "soHoadon")

        txtMaHopDongHoaDon.DataBindings.Clear()
        txtMaHopDongHoaDon.DataBindings.Add("Text", DataGridViewThongTinHoaDon.DataSource, "maHD")

        dtNgayThuHoaDon.DataBindings.Clear()
        dtNgayThuHoaDon.DataBindings.Add("Text", DataGridViewThongTinHoaDon.DataSource, "ngaythu")

        txtCachThucNopTienHoaDon.DataBindings.Clear()
        txtCachThucNopTienHoaDon.DataBindings.Add("Text", DataGridViewThongTinHoaDon.DataSource, "cachthuc")

        txtSoTienHoaDon.DataBindings.Clear()
        txtSoTienHoaDon.DataBindings.Add("Text", DataGridViewThongTinHoaDon.DataSource, "sotien")
    End Sub

    Private Sub DataGridViewThongTinHoaDon_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewThongTinHoaDon.CellContentClick
        LoadTextBoxHoaDon()

        btnCapNhatHoaDon.Enabled = True
        btnXoaHoaDon.Enabled = True
    End Sub

    'Ham tim kiem hoa don
    Private Sub btnTimKiemHoaDon_Click(sender As Object, e As EventArgs) Handles btnTimKiemHoaDon.Click
        Dim mTraCuuBaoHiemController As TraCuuBaoHiemController
        mTraCuuBaoHiemController = New TraCuuBaoHiemController()

        'Hien thi ket qua tim kiem tren datagrid
        Dim sTuKhoa As String
        sTuKhoa = txTimKiemHoaDon.Text
        Dim dt As DataTable = mTraCuuBaoHiemController.TimKiemHoaDon(sTuKhoa)
        DataGridViewThongTinHoaDon.DataSource = dt

        'Neu nhu khong co data thi disable cac nut phia duoi
        If dt.Rows.Count > 0 Then
            btnCapNhatHoaDon.Enabled = True
            btnXoaHoaDon.Enabled = True
        Else
            btnCapNhatHoaDon.Enabled = False
            btnXoaHoaDon.Enabled = False
        End If
    End Sub

    Private Sub TabControlMain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControlMain.SelectedIndexChanged
        Dim mTraCuuBaoHiemController As TraCuuBaoHiemController
        mTraCuuBaoHiemController = New TraCuuBaoHiemController()
        ClearTextBoxHoaDon()
        'Fill toan bo data len datagrid
        Dim ds As New DataSet
        ds = mTraCuuBaoHiemController.LoadAllHoaDon()
        DataGridViewThongTinHoaDon.DataSource = ds.Tables(0)
        ds.Dispose()
    End Sub

    'Tinh thuc thu
    Private Sub dtDoanhThuTrongNgay_ValueChanged(sender As Object, e As EventArgs) Handles dtDoanhThuTrongNgay.ValueChanged
        Dim mTraCuuBaoHiemController As TraCuuBaoHiemController
        mTraCuuBaoHiemController = New TraCuuBaoHiemController()

        Dim tgian As DateTime = dtDoanhThuTrongNgay.Value
        Dim ngay As Integer = tgian.Day
        Dim thang As Integer = tgian.Month
        Dim nam As Integer = tgian.Year

        Dim ds As DataTable = mTraCuuBaoHiemController.LoadData(ngay, thang, nam)
        Dim dt As DataTable = mTraCuuBaoHiemController.LoadData2(ngay, thang)

        Dim sum1, sum2 As Double
        If (ds.Rows.Count > 0) Then
            sum1 = Convert.ToDouble(ds.Compute("SUM(sotien)", String.Empty))
        Else : sum1 = 0
        End If
        If (dt.Rows.Count > 0) Then
            sum2 = Convert.ToDouble(dt.Compute("SUM(phibaohiemdinhky)", String.Empty))
        Else : sum2 = 0
        End If
        DataGridViewDanhSachTrongNgay.DataSource = ds
        txtThucThuTrongNgay.Text = sum1.ToString()
        txtDoanhThuTrongNgay.Text = sum2.ToString()
    End Sub

    Private Sub btnXuatBaoCaoTrongNgay_Click(sender As Object, e As EventArgs) Handles btnXuatBaoCaoTrongNgay.Click

    End Sub
End Class
