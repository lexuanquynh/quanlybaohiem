
USE master
go
IF EXISTS(select * from sys.databases where name='QLHDBH')
DROP DATABASE QLHDBH
go
CREATE DATABASE QLHDBH
go

--tao bang KhachHang
USE QLHDBH
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[KhachHang](
	[IDKhachhang] [int] IDENTITY(1,1) primary key,
	[hovaten] [nvarchar](50) NULL,
	[gioitinh] [bit] NULL,
	[tinhtrang] nvarchar(10)NULL,
	[ngaysinh] SMALLDATETIME  NULL,
	[noisinh] [nvarchar](50) NULL,
	[quoctich] [nvarchar](50) NULL,
	[socmnd] [varchar] (15) NULL,
	[ngaycap] SMALLDATETIME NULL,
	[noicap] [nvarchar](150) NULL,
	[diachithuongtru] [nvarchar](150) NULL,
	[nghenghiep] [nvarchar](150) NULL,
	[dienthoai] [varchar] (15) NULL,
	[tencoquan] [nvarchar](150) NULL,
	[diachicoquan] [nvarchar](150) NULL,
	[thunhapmotnam] [float] NULL,
	[sotk] [varchar] (20)NULL)
GO

--bang Hop dong
CREATE TABLE [dbo].[Hopdong](
	[maHD] [int] IDENTITY(1,1) Primary key,
	[IDKhachHang] [int]  NULL,
	[spbaohiem] [nvarchar](150) NULL,
	[sotienbaohiem] FLOAT NULL,
	[kyhanbaohiem] [nvarchar](50) NULL,
	[dinhkybaohiem] [nvarchar](50) NULL,
	[phibaohiemdinhky] FLOAT NULL,
	[sotiendaohan] FLOAT NULL,
	[ngaycohieuluc] SMALLDATETIME NULL,
	[sanphambaohiembosung] [nvarchar](150) NULL,
	[phuongthuctra] [nvarchar](50) NULL,
	[nguongocphibaohiem] [nvarchar](50) NULL,
	[benhvienduocchitra] [nvarchar](50) NULL,
	
	FOREIGN KEY (IDKhachHang) REFERENCES KhachHang(IDKhachHang)
)
GO

--bang bien lai
CREATE TABLE [dbo].[Hoadon](
	[soHoadon] [int] IDENTITY(1,1) primary key,
	[maHD] [int]  NULL,
	[ngaythu] [smalldatetime] NULL,
	[cachthuc] [nvarchar](50) NULL,
	[sotien] [float] NULL,
	FOREIGN KEY (maHD) REFERENCES HopDong(maHD)
)
GO
--Them du lieu tinh trang hon nhan

--------------------------------------------------------------------------------------------
--Them du lieu khach hang
INSERT dbo.KhachHang  
    VALUES (N'Nguyễn Văn An', 0, N'Độc thân', '1991-08-30', N'Hà Tĩnh', N'Việt Nam', '023231234','1996-8-21', N'Hà Tĩnh', N'Hà Nội Việt Nam',N'Buôn bán', '0989786778', N'clingme', N'Hoàng Quốc Việt', 233434423.78, '23212434')  
GO  
INSERT dbo.KhachHang  
    VALUES (N'Lê Thị Linh', 0, N'Độc thân', '1984-08-23', N'Hà Nội', N'Việt Nam', '0243234534','1996-8-21', N'Hà Nội', N'Hà Nội Việt Nam',N'Công nhân', '0989786778', N'Samsung', N'Bắc Ninh', 1000000000, '23212545434')  
GO
INSERT dbo.KhachHang  
    VALUES (N'Phạm Văn Mách', 1, N'Độc thân', '1975-02-20', N'Hà Nam', N'Việt Nam', '02324531234','1996-8-21', N'Hà Nam', N'Hà Nội Việt Nam',N'Lực sĩ', '0989786778', N'Thế thao khu liên hiệp', N'Liên Hiệp', 2334656534423.78, '23212544434')  
GO


--insert for dbo.hopdong
INSERT dbo.Hopdong  
    VALUES (1, N'Thân Thể', 50000000, N'10 năm', N'1 năm', 10000000, 0,'2015-8-21', N'Giáo Dục', N'tien mat',N'thu nhap', N'Viet duc')
Go
INSERT dbo.Hopdong  
    VALUES (2, N'Nhân thọ', 100000000, N'10 năm', N'1 năm', 100000000, 0,'2015-8-21', N'Thân thể', N'tien mat',N'thu nhap', N'Viet duc')
Go
INSERT dbo.Hopdong  
    VALUES (3, N'Thân Thể', 40000000, N'10 năm', N'1 năm', 10000000, 0,'2015-8-21', N'Không có', N'tien mat',N'thu nhap', N'Viet duc')
Go

--insert for dbo.Hoadon
INSERT dbo.Hoadon 
    VALUES (1,'2015-02-20', N'Tiền mặt',10000000)
Go
INSERT dbo.Hoadon 
    VALUES (2,'2015-04-30', N'Thẻ NH',1000000)
Go
INSERT dbo.Hoadon 
    VALUES (3,'2015-07-28', N'Tiền mặt',100000)
Go

--------------------------------------------------------------------------------------------
--tao produce khach hang

--Them Du lieu--
CREATE PROCEDURE InsertDataIntoTableKH
@hovaten nvarchar(50),
@gioitinh bit,
@tinhtrang nvarchar(10),
@ngaysinh SMALLDATETIME ,
@noisinh nvarchar(50),
@quoctich nvarchar(50),
@socmnd varchar(15),
@ngaycap SMALLDATETIME ,
@noicap nvarchar(150),
@diachithuongtru nvarchar(150),
@nghenghiep nvarchar(150),
@dienthoai varchar(15),
@tencoquan nvarchar(150),
@diachicoquan nvarchar(150),
@thunhapmotnam float,
@sotk varchar
AS
BEGIN
INSERT INTO KhachHang(hovaten, gioitinh, tinhtrang, ngaysinh, noisinh, quoctich, socmnd, ngaycap, noicap, diachithuongtru, nghenghiep, dienthoai, tencoquan, diachicoquan, thunhapmotnam, sotk)
VALUES (@hovaten, @gioitinh, @tinhtrang, @ngaysinh, @noisinh, @quoctich, @socmnd, @ngaycap, @noicap, @diachithuongtru, @nghenghiep, @dienthoai, @tencoquan, @diachicoquan, @thunhapmotnam, @sotk)
END
go


--Cap nhat du lieu--
CREATE PROCEDURE UpdateDataInsideTableKH
@IDKhachHang int,
@hovaten nvarchar(50),
@gioitinh bit,
@tinhtrang nvarchar(10),
@ngaysinh SMALLDATETIME ,
@noisinh nvarchar(50),
@quoctich nvarchar(50),
@socmnd varchar(15),
@ngaycap SMALLDATETIME ,
@noicap nvarchar(150),
@diachithuongtru nvarchar(150),
@nghenghiep nvarchar(150),
@dienthoai varchar(15),
@tencoquan nvarchar(150),
@diachicoquan nvarchar(150),
@thunhapmotnam float,
@sotk varchar

AS
BEGIN
UPDATE KhachHang 
SET hovaten = @hovaten, gioitinh = @gioitinh, tinhtrang = @tinhtrang, ngaysinh = @ngaysinh, noisinh = @noisinh,quoctich = @quoctich, socmnd = @socmnd, ngaycap = @ngaycap, noicap = @noicap,diachithuongtru = @diachithuongtru,nghenghiep = @nghenghiep, dienthoai = @dienthoai, tencoquan = @tencoquan, diachicoquan = @diachicoquan, thunhapmotnam = @thunhapmotnam, sotk = @sotk
WHERE idKhachhang = @idKhachhang
END
go
--Xoa Du Lieu--
CREATE PROCEDURE DeleteDataFromTableKH
@idKhachhang int
AS
BEGIN
DELETE FROM KhachHang
WHERE idKhachhang = @idKhachhang
END
go
--tao produce hop dong
--Them Du lieu--
CREATE PROCEDURE InsertDataIntoTableHD
@IdKhachHang int,
@spbaohiem nvarchar(150),
@sotienbaohiem float,
@kyhanbaohiem nvarchar(50),
@dinhkybaohiem nvarchar(50) ,
@phibaohiemdinhky float,
@sotiendaohan float,
@ngaycohieuluc SMALLDATETIME,
@sanphambaohiembosung nvarchar(150) ,
@phuongthuctra nvarchar(50),
@nguongocphibaohiem nvarchar(50),
@benhvienduocchitra nvarchar(50)
AS
BEGIN
INSERT INTO Hopdong(spbaohiem, sotienbaohiem,kyhanbaohiem,dinhkybaohiem, phibaohiemdinhky,sotiendaohan,ngaycohieuluc,sanphambaohiembosung,phuongthuctra,nguongocphibaohiem,benhvienduocchitra)
VALUES (@spbaohiem,@sotienbaohiem,@kyhanbaohiem,@dinhkybaohiem,@phibaohiemdinhky,@sotiendaohan,@ngaycohieuluc,@sanphambaohiembosung,@phuongthuctra,@nguongocphibaohiem,@benhvienduocchitra)
END
go

--Cap nhat du lieu--
CREATE PROCEDURE UpdateDataInsideTableHD
@maHD int,
@IdKhachHang int,
@spbaohiem nvarchar(150),
@sotienbaohiem float,
@kyhanbaohiem nvarchar(50),
@dinhkybaohiem nvarchar(50) ,
@phibaohiemdinhky float,
@sotiendaohan float,
@ngaycohieuluc SMALLDATETIME,
@sanphambaohiembosung nvarchar(150) ,
@phuongthuctra nvarchar(50),
@nguongocphibaohiem nvarchar(50),
@benhvienduocchitra nvarchar(50)
AS
BEGIN
UPDATE Hopdong
SET spbaohiem=@spbaohiem, sotienbaohiem=@sotienbaohiem, kyhanbaohiem=@kyhanbaohiem, dinhkybaohiem=@dinhkybaohiem, phibaohiemdinhky=@phibaohiemdinhky, sotiendaohan=@sotiendaohan, ngaycohieuluc=@ngaycohieuluc, sanphambaohiembosung=@sanphambaohiembosung,phuongthuctra=@phuongthuctra,nguongocphibaohiem=@nguongocphibaohiem,benhvienduocchitra=@benhvienduocchitra 
WHERE maHD=@maHD and IDKhachhang=@idkhachhang
END
go
--Xoa Du Lieu--
CREATE PROCEDURE DeleteDataFromTableHD
@maHD int
AS
BEGIN
DELETE FROM Hopdong
WHERE maHD=@maHD
END
go	
----------------------------------------------------------------

CREATE PROCEDURE InsertDataIntoTableHoadon
@maHD int,
@ngaythu smalldatetime,
@cachthuc nvarchar (50),
@sotien float
AS
BEGIN
INSERT INTO Hoadon(maHD,ngaythu,cachthuc,sotien)
VALUES (@maHD,@ngaythu,@cachthuc,@sotien)
END
go

CREATE PROCEDURE UpdateDataInsideTableHoadon
@soHoadon int,
@maHD int,
@ngaythu smalldatetime,
@cachthuc nvarchar (50),
@sotien float
AS
BEGIN
UPDATE Hoadon
SET ngaythu=@ngaythu, cachthuc=@cachthuc, sotien=@sotien
WHERE maHD=@maHD and soHoadon=@soHoadon
END
go

CREATE PROCEDURE DeleteDataFromTableHoadon
@soHoadon int
AS
BEGIN
DELETE FROM Hoadon
WHERE soHoadon=@soHoadon
END
go	

--CREATE PROCEDURE Tinhtrang
--as
--begin 
--select*from TinhTrangQuanHe
--end
--go

-------------------------------------------------------------------------------
--tao 1 so view can dung --

--CREATE VIEW view_thongtinkhachhangcoban AS
--select
--kh.hovaten AS N'Họ và tên',
--CASE kh.gioitinh  WHEN 1 THEN N'Nam' WHEN 0 THEN N'Nữ'END AS N'Giới tính',
--kh.ngaysinh  AS N'Ngày sinh',
--kh.dienthoai AS N'Số điện thoại',
--tt.ThongTin as N'Tình trạng quan hệ',
--kh.noisinh AS N'Nơi sinh'
--from dbo.KhachHang kh
--LEFT JOIN  dbo.tinhtrangquanhe tt on tt.IDtinhtrang = kh.IDtinhtrang
--go
--demo

--select *from view_thongtinkhachhangcoban
--go
declare @a as bit 
set @a = 1

if ( case when @a = 1 then 'true' else 'false' end ) = 'true'
print 'Nam' else print 'Nu'

--[IDKhachhang] [int] IDENTITY(1,1) primary key,
--	[hovaten] [nvarchar](50) NULL,
--	[gioitinh] [bit] NULL,
--	[IDtinhtrang] int NULL,
--	[ngaysinh] SMALLDATETIME  NULL,
--	[noisinh] [nvarchar](50) NULL,
--	[quoctich] [nvarchar](50) NULL,
--	[socmnd] [varchar] (15) NULL,
--	[ngaycap] SMALLDATETIME NULL,
--	[noicap] [nvarchar](150) NULL,
--	[diachithuongtru] [nvarchar](150) NULL,
--	[nghenghiep] [nvarchar](150) NULL,
--	[dienthoai] [varchar] (15) NULL,
--	[tencoquan] [nvarchar](150) NULL,
--	[diachicoquan] [nvarchar](150) NULL,
--	[thunhapmotnam] [float] NULL,
--	[sotk] [varchar] (20)NULL,
