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
        CheckInput()

        'Insert vao database
        Dim mKhachHangController As KhachHangController
        mKhachHangController = New KhachHangController()

        Dim gioitinh As Integer
        gioitinh = cbGioiTinh.SelectedIndex

        Dim thunhap As Double
        If Double.TryParse(txtThuNhapHangNam.Text, thunhap) Then

        Else
            MessageBox.Show("Số tiền thu nhập không đúng")
            txtThuNhapHangNam.Focus()
            Return
        End If

        If mKhachHangController.ChinhSuaThongTinKhachHang(False, txtHoVaTen.Text, gioitinh, txtTinhTrang.Text,
                                                 dtNgaySinh.Text, txtNoiSinh.Text, txtQuocTich.Text,
                                                 txtCMND.Text, dtNgayCMND.Text, txtNoiCapCMND.Text,
                                                 txtDiaChiThuongTru.Text, txtNgheNghiep.Text, txtSDT.Text, txtTenCoQuan.Text,
                                                 txtDiaChiCoQuan.Text, 100000, txtSoTKNganHang.Text) Then
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

    'Ham cap nhat thong tin khach hang
    Private Sub btnCapNhatKhachHang_Click(sender As Object, e As EventArgs) Handles btnCapNhatKhachHang.Click
        'CheckInput()
        'Insert vao database
        Dim mKhachHangController As KhachHangController
        mKhachHangController = New KhachHangController()

        Dim gioitinh As Integer
        gioitinh = cbGioiTinh.SelectedIndex

        Dim thunhap As Double
        If Double.TryParse(txtThuNhapHangNam.Text, thunhap) Then

        Else
            MessageBox.Show("Số tiền thu nhập không đúng")
            txtThuNhapHangNam.Focus()
            Return
        End If

        If mKhachHangController.ChinhSuaThongTinKhachHang(True, txtHoVaTen.Text, gioitinh, txtTinhTrang.Text,
                                                 dtNgaySinh.Text, txtNoiSinh.Text, txtQuocTich.Text,
                                                 txtCMND.Text, dtNgayCMND.Text, txtNoiCapCMND.Text,
                                                 txtDiaChiThuongTru.Text, txtNgheNghiep.Text, txtSDT.Text, txtTenCoQuan.Text,
                                                 txtDiaChiCoQuan.Text, 100000, txtSoTKNganHang.Text) Then
            GroupBoxThemKH.Hide()
        End If
    End Sub

    Private Sub DataGridViewKhachHang_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewKhachHang.CellContentClick
        txtMaKH.Text = e.RowIndex.ToString

        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = Me.DataGridViewKhachHang.Rows(e.RowIndex)
            'txtMaKH.Text = row.Cells(0).Value.ToString
            txtHoVaTen.Text = row.Cells(1).Value.ToString
        End If
        'Day toan bo data tu grid len form
        '       [hovaten] [nvarchar](50) NULL,
        '[gioitinh] [bit] NULL,
        '[tinhtrang] nvarchar(10)NULL,
        '[ngaysinh] SMALLDATETIME  NULL,
        '[noisinh] [nvarchar](50) NULL,
        '[quoctich] [nvarchar](50) NULL,
        '[socmnd] [varchar] (15) NULL,
        '[ngaycap] SMALLDATETIME NULL,
        '[noicap] [nvarchar](150) NULL,
        '[diachithuongtru] [nvarchar](150) NULL,
        '[nghenghiep] [nvarchar](150) NULL,
        '[dienthoai] [varchar] (15) NULL,
        '[tencoquan] [nvarchar](150) NULL,
        '[diachicoquan] [nvarchar](150) NULL,
        '[thunhapmotnam] [float] NULL,
        '[sotk] [varchar] (20)NULL)
        'txtMaKH.Text = DataGridViewKhachHang.Rows(e.RowIndex).Cells(0).Value()
        'txtHoVaTen.Text = DataGridViewKhachHang.Rows(e.RowIndex).Cells(1).Value()
        ''  cbGioiTinh.SelectedIndex = 1
        'txtTinhTrang.Text = DataGridViewKhachHang.Rows(e.RowIndex).Cells(3).Value()
        ''txtTinhTrang.Text = DataGridViewKhachHang.Rows(e.RowIndex).Cells(4).Value()
        'txtNoiSinh.Text = DataGridViewKhachHang.Rows(e.RowIndex).Cells(5).Value()
        'txtQuocTich.Text = DataGridViewKhachHang.Rows(e.RowIndex).Cells(6).Value()
        'txtCMND.Text = DataGridViewKhachHang.Rows(e.RowIndex).Cells(7).Value()
        ''txtCMND.Text = DataGridViewKhachHang.Rows(e.RowIndex).Cells(8).Value()
        'txtNoiCapCMND.Text = DataGridViewKhachHang.Rows(e.RowIndex).Cells(9).Value()
        'txtDiaChiThuongTru.Text = DataGridViewKhachHang.Rows(e.RowIndex).Cells(10).Value()
        'txtNgheNghiep.Text = DataGridViewKhachHang.Rows(e.RowIndex).Cells(11).Value()
        'txtSDT.Text = DataGridViewKhachHang.Rows(e.RowIndex).Cells(12).Value()
        'txtTenCoQuan.Text = DataGridViewKhachHang.Rows(e.RowIndex).Cells(13).Value()
        'txtDiaChiCoQuan.Text = DataGridViewKhachHang.Rows(e.RowIndex).Cells(14).Value()
        'txtThuNhapHangNam.Text = DataGridViewKhachHang.Rows(e.RowIndex).Cells(15).Value()
        'txtSoTKNganHang.Text = DataGridViewKhachHang.Rows(e.RowIndex).Cells(16).Value()
    End Sub
End Class
