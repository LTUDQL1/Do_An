Use master
GO
If DB_ID('QLQA') IS NOT NULL
Begin;
	Drop Database QLQA
End;
GO
Create Database QLQA
Go
Use QLQA
Go
Create table MON_AN
(
	MaMA char(10) NOT NULL,
	TenMA nvarchar(50),
	DonGia int,
	ThongTin nvarchar(100),
	Loai nvarchar(50),
	MaCN char(10),
	Constraint PK_MON_AN
	primary key(MaMA),
) 
Create table CHI_NHANH
(
	MaCN char(10) NOT NULL,
	TenCN nvarchar(50),
	SoLuongBan int,
	DiaChi nvarchar(100),
	SoDienT char(15),
	QuanLy int

	Constraint PK_CHI_NHANH
	primary key(MaCN),
)
Create table KHACH_HANG
(
	MaKH int Identity(1,1) not null,
	SoDienT char(15),
	HoTen nvarchar(50),
	DiaChi nvarchar(50),

	Constraint PK_KHACH_HANG
	primary key(MaKH),
)
Create table HOA_DON
(
	MaHD int Identity(1,1) not null,
	MaDH int,
	ThanhTien float,

	Constraint PK_HOA_DON
	Primary Key(MaHD)
)
Create Table BAN
(
	MaBan int Identity(1,1) not null,
	TenBan nvarchar(20),
	MaCN char(10),
	TrangThai bit,-- 0: ko co nguoi || 1: co nguoi

	Constraint PK_BAN
	Primary Key(MaBan)
)
Create table GIAO_HANG
(
	MaGH int Identity(1,1) NOT NULL,
	NgayGH datetime,
	MaDH int,

	Constraint PK_GIAO_HANG
	primary key(MaGH),
)
Create table CHI_TIET_GIAO_HANG
(
	MaGH char(10),
	MaMA char(10),
	SoLuongGiao int,

	Constraint PK_CT_GIAO_HANG
	primary key(MaGH, MaMA),
)
Create table NHAN_VIEN
(
	MaNV int Identity(1,1) NOT NULL,
	MaCN char(10),
	HoTen nvarchar(50),
	GioiTinh char(3),
	DienThoai int,
	DiaChi nvarchar(100),
	NgaySinh datetime,
	TaiKhoan char(10),
	MatKhau char(10),

	Constraint PK_NHAN_VIEN
	Primary Key(MaNV),
)
Create table BAO_CAO
(
	MaBC char(10) NOT NULL,
	MaNV int,
	MaCN char(10),
	SoLuongDH int,
	TongDT int,
	Ngay char(10),

	Constraint PK_BAO_CAO
	Primary Key(MaBC),
)
Create Table DAT_HANG
(
	MaDH int Identity(1,1) not null,
	MaNV int,
	MaKH int,
	MaCN char(10),
	MaBan int,
	NgayDH datetime,
	GhiChu nvarchar(200)

	Constraint PK_DAT_HANG
	Primary Key(MaDH)
)
create table DON_HANG
(
	MaDonHang int Identity(1,1) not null,
	MaDH int,
	MaMA char(10),
	SoLuong int,
	constraint PK_CT_DON_HANG
	primary key(MaDonHang)
)

--Foregn Key
Alter Table DON_HANG
Add Constraint FK_DONHANG_MONAN
Foreign key(MaMA)
References MON_AN(MaMA)

Alter Table DON_HANG
Add Constraint FK_DONHANG_DATHANG
Foreign Key(MaDH)
References DAT_HANG(MaDH)
ON DELETE CASCADE

Alter Table DAT_HANG
Add Constraint FK_DATHANG_NHANVIEN
Foreign Key(MaNV)
References NHAN_VIEN(MaNV)

Alter Table DAT_HANG
Add Constraint FK_DATHANG_KHACHHANG
Foreign Key(MaKH)
References KHACH_HANG(MaKH)

Alter Table DAT_HANG
Add Constraint FK_DATHANG_CHINHANH
Foreign Key(MaCN)
References CHI_NHANH(MaCN)

Alter Table DAT_HANG
Add Constraint FK_DATHANG_BAN
Foreign Key(MaBan)
References BAN(MaBan)
ON DELETE CASCADE

Alter Table BAO_CAO
Add Constraint FK_BAOCAO_NHANVIEN
Foreign Key(MaNV)
References NHAN_VIEN(MaNV)

Alter Table BAO_CAO
Add Constraint FK_BAOCAO_CHINHANH
Foreign Key(MaCN)
References CHI_NHANH(MaCN)

Alter Table NHAN_VIEN
Add Constraint FK_NHANVIEN_CHINHANH
Foreign Key(MaCN)
References CHI_NHANH(MaCN)

Alter Table GIAO_HANG
Add Constraint FK_GIAOHANG_DATHANG
Foreign Key(MaDH)
References DAT_HANG(MaDH)

Alter Table BAN
Add Constraint FK_BAN_CHINHANH
Foreign Key(MaCN)
References CHI_NHANH(MaCN)
ON DELETE CASCADE

Alter Table HOA_DON
Add Constraint FK_HOADON_DATHANG
Foreign Key(MaDH)
References DAT_HANG(MaDH)

Alter Table CHI_NHANH
Add Constraint FK_CHINHANH_NHANVIEN
Foreign Key(QuanLy)
References NHAN_VIEN(MaNV)

Alter Table MON_AN
Add Constraint FK_MONAN_CHINHANH
Foreign Key(MaCN)
References CHI_NHANH(MaCN)
--INSERT

INSERT INTO CHI_NHANH VALUES ('CN01',N'Chi nhánh 1',25,N'TP HCM','07712345678',NULL)
INSERT INTO CHI_NHANH VALUES ('CN02',N'Chi nhánh 2',20,N'TP Cần Thơ','06698765432',NULL)
INSERT INTO CHI_NHANH VALUES ('CN03',N'Chi nhánh 3',23,N'Hà Nội','00012332123',NULL)

INSERT INTO MON_AN VALUES ('MA01',N'Bún Bò Huế','1000000',NULL,'MonMan','CN01')
INSERT INTO MON_AN VALUES ('MA02',N'Bún Bò Xào','1000000',NULL,'MonMan','CN02')
INSERT INTO MON_AN VALUES ('MA03',N'Bò Lá Lốt','1000000',NULL,'MonMan','CN01')
INSERT INTO MON_AN VALUES ('MA04',N'Cơm Bò Xào','1000000',NULL,'MonMan','CN03')
INSERT INTO MON_AN VALUES ('MA05',N'Mì Xào Bò','1000000',NULL,'MonMan','CN02')
INSERT INTO MON_AN VALUES ('MA06',N'Sườn Xào Chua Ngọt','1000000',NULL,'MonMan','CN01')
INSERT INTO MON_AN VALUES ('MA07',N'Thịt Kho Củ Cải','1000000',NULL,'MonMan','CN01')
INSERT INTO MON_AN VALUES ('MA08',N'Thịt Kho Tàu','1000000',NULL,'MonMan','CN02')
INSERT INTO MON_AN VALUES ('MA09',N'Thịt Heo Chiên Giòn','1000000',NULL,'MonMan','CN03')
INSERT INTO MON_AN VALUES ('MA10',N'Thịt Heo Nướng Xá Xíu','1000000',NULL,'MonMan','CN03')
INSERT INTO MON_AN VALUES ('MA11',N'Gà Chiên Giòn','1000000',NULL,'MonMan','CN01')
INSERT INTO MON_AN VALUES ('MA12',N'Cơm Gà Xối Mỡ','1000000',NULL,'MonMan','CN02')
INSERT INTO MON_AN VALUES ('MA13',N'Miến Gà','1000000',NULL,'MonMan','CN01')
INSERT INTO MON_AN VALUES ('MA14',N'Gà Hấp Bia','1000000',NULL,'MonMan','CN03')
INSERT INTO MON_AN VALUES ('MA15',N'Kim Chi','1000000',NULL,'MonChay','CN01')
INSERT INTO MON_AN VALUES ('MA16',N'Miến Xào Rau','1000000',NULL,'MonChay','CN02')
INSERT INTO MON_AN VALUES ('MA17',N'Gỏi Quấn Chay','1000000',NULL,'MonChay','CN03')
INSERT INTO MON_AN VALUES ('MA18',N'Đậu Hủ Xả Ớt','1000000',NULL,'MonChay','CN01')
INSERT INTO MON_AN VALUES ('MA19',N'Nước Hạt Chia','1000000',NULL,'Nuoc','CN01')
INSERT INTO MON_AN VALUES ('MA20',N'Chanh Xả','1000000',NULL,'Nuoc','CN01')
INSERT INTO MON_AN VALUES ('MA21',N'Tắc Mật Ong','1000000',NULL,'Nuoc','CN01')
INSERT INTO MON_AN VALUES ('MA22',N'Nước Ép','1000000',NULL,'Nuoc','CN01')
INSERT INTO MON_AN VALUES ('MA23',N'Nước Ngọt','1000000',NULL,'Nuoc','CN01')
INSERT INTO MON_AN VALUES ('MA24',N'Bánh Flan','1000000',NULL,'Dessert','CN01')
INSERT INTO MON_AN VALUES ('MA25',N'Chè','1000000',NULL,'Dessert','CN01')
INSERT INTO MON_AN VALUES ('MA26',N'Sữa Chua','1000000',NULL,'Dessert','CN01')
INSERT INTO MON_AN VALUES ('MA27',N'Trái Cây Tô','1000000',NULL,'Dessert','CN01')

INSERT INTO NHAN_VIEN VALUES ('CN01',N'Nguyễn Công Hiệp','Nam',0909010203,N'Bình Thuận','02/15/1997','123456','123123')
INSERT INTO NHAN_VIEN VALUES ('CN02',N'Nguyễn Đức Hoàng','Nam',0987654321,N'Cần Thơ','10/01/1997','hoang123','quick')
INSERT INTO NHAN_VIEN VALUES ('CN02',N'Nguyễn Lê Huy Hoàng','Nam',01626389324,N'Bình Thuận','09/23/1993','sieunhan','yeuquai')
INSERT INTO NHAN_VIEN VALUES ('CN03',N'Lê Sỹ Hoàng','Nam',0985274694,'TPHCM','11/15/1995','naruto','sasuke')
INSERT INTO NHAN_VIEN VALUES ('CN03',N'Trương Thái Huy','Nam',01626181876,N'Bến Tre','08/12/1996','Huy123','huy123')

INSERT INTO KHACH_HANG VALUES ('01639871234',N'Trần Hoàng Văn','Quận 1')
INSERT INTO KHACH_HANG VALUES ('0987654300',N'Nguyễn Đình Yên','Quận 8')
INSERT INTO KHACH_HANG VALUES ('0987678987',N'Lý Hoàng Yến','Quận 3')
INSERT INTO KHACH_HANG VALUES ('0990876567',N'Trương Vô Kỵ','Quận 5')
INSERT INTO KHACH_HANG VALUES ('0987987001',N'Lê Lợi','Quận 4')

INSERT INTO BAO_CAO VALUES ('BC01',1,'CN01',20,3,N'Ngày')
INSERT INTO BAO_CAO VALUES ('BC02',2,'CN02',25,4,N'Tháng')
INSERT INTO BAO_CAO VALUES ('BC03',3,'CN02',19,3,N'Ngày')
INSERT INTO BAO_CAO VALUES ('BC04',4,'CN03',24,4,N'Tháng')
INSERT INTO BAO_CAO VALUES ('BC05',5,'CN03',28,4,N'Năm')

INSERT INTO BAN VALUES ('Ban1','CN01', 0)
INSERT INTO BAN VALUES ('Ban2','CN01', 0)
INSERT INTO BAN VALUES ('Ban3','CN01', 0)
INSERT INTO BAN VALUES ('Ban1','CN02', 0)
INSERT INTO BAN VALUES ('Ban1','CN03', 0)

INSERT INTO DAT_HANG VALUES (1, 1,'CN01',1,GETDATE(), null)
INSERT INTO DAT_HANG VALUES (2, 2,'CN01',2,GETDATE(), null)	
INSERT INTO DAT_HANG VALUES (3, 3,'CN01',3,GETDATE(), null)	
INSERT INTO DAT_HANG VALUES (4, 4,'CN02',1,GETDATE(), null)	
INSERT INTO DAT_HANG VALUES (5, 5,'CN03',1,GETDATE(), null)	

INSERT INTO DON_HANG VALUES (1,'MA01', 3)
INSERT INTO DON_HANG VALUES (1,'MA03', 2)
INSERT INTO DON_HANG VALUES (4,'MA02', 5)
INSERT INTO DON_HANG VALUES (5,'MA17', 3)

INSERT INTO GIAO_HANG VALUES (GETDATE(),2)
INSERT INTO GIAO_HANG VALUES (GETDATE(),3)
INSERT INTO GIAO_HANG VALUES (GETDATE(),3)

GO
--Đăng Nhập
CREATE PROCEDURE DangNhap
	@TaiKhoan char(10),
	@MatKhau char(10)
AS
BEGIN
	IF(EXISTS(SELECT * FROM NHAN_VIEN WHERE @TaiKhoan = TaiKhoan AND @MatKhau = MatKhau))
	BEGIN
		RETURN 1
	END
	ELSE
	BEGIN
		RETURN 0
	END
END

GO
--Đăng Ký
CREATE PROCEDURE DangKy
	@MaCN char(10),
	@HoTen nvarchar(50),
	@GioiTinh char(3),
	@DienThoai int,
	@DiaChi nvarchar(100),
	@NgaySinh datetime,
	@TaiKhoan char(10),
	@MatKhau char(10)
AS
BEGIN
	IF(NOT EXISTS(SELECT * FROM NHAN_VIEN WHERE @TaiKhoan = TaiKhoan))
	BEGIN
		INSERT INTO NHAN_VIEN VALUES (@MaCN,@HoTen,@GioiTinh,@DienThoai,@DiaChi,@NgaySinh,@TaiKhoan,@MatKhau)
		RETURN 1
	END
	ELSE
	BEGIN
		RETURN 0
	END
END

GO
--Đổi Mật Khẩu
CREATE PROCEDURE DoiMatKhau
	@TaiKhoan char(10),
	@MatKhau char(10),
	@MatKhauMoi char(10)
AS
BEGIN
	IF(EXISTS(SELECT * FROM NHAN_VIEN WHERE @TaiKhoan = TaiKhoan AND @MatKhau = MatKhau))
	BEGIN
		UPDATE NHAN_VIEN
		SET MatKhau = @MatKhauMoi
		WHERE TaiKhoan = @TaiKhoan
		RETURN 1
	END
	ELSE
	BEGIN
		RETURN 0
	END
END

GO
--Thay đổi thông tin
CREATE PROCEDURE Info
	@TaiKhoan char(10),
	@DiaChi nvarchar(100),
	@DienThoai int
AS
BEGIN
	UPDATE NHAN_VIEN SET DiaChi = @DiaChi WHERE TaiKhoan = @TaiKhoan
	UPDATE NHAN_VIEN SET DienThoai = @DienThoai WHERE TaiKhoan = @TaiKhoan
END
Go
-- Cập nhật DAT_HANG
Create Procedure proc_DATHANG
	@MaDH int,
	@MaKH int,
	@GhiChu nvarchar(200)
As
Begin
	If Exists(Select * From DAT_HANG Where MaDH = @MaDH)
	Begin
		Update DAT_HANG Set MaKH = @MaKH, GhiChu = @GhiChu Where MaDH = @MaDH
	End
End
Go
Create Procedure proc_DATHANGBAN
	@MaBanC int,
	@MaBan int
As
Begin
	Update DAT_HANG Set MaBan = @MaBan Where MaBan = @MaBanC
End
Go
-- Xóa DON_HANG
Create Procedure proc_XoaDonHang
	@MaDH int
As
Begin
	If Exists(Select * From DON_HANG Where MaDonHang = @MaDH)
	Begin
		Delete DON_HANG Where MaDonHang = @MaDH
	End	
End
Go
-- Thêm DAT_HANG
Create Procedure proc_IDAT_HANG
	@MaNV int,
	@MaKH int,
	@MaCN char(10),
	@MaBan int,
	@NgayDH datetime,
	@GhiChu nvarchar(200)
As
Begin
	If Not Exists(Select * From DAT_HANG Where MaKH = @MaKH)
	Begin
		Insert Into DAT_HANG Values(@MaNV, @MaKH, @MaCN, @MaBan, @NgayDH, @GhiChu)
	End
End
Go
-- Xóa KHACH_HANG
Create Procedure proc_DKHACH_HANG
	@MaKH int
As
Begin
	Declare @MaDH int
	Select @MaDH = MaDH From DAT_HANG Where MaKH = @MaKH
	Delete DON_HANG Where MaDH = @MaDH
	Delete GIAO_HANG Where MaDH = @MaDH
	Delete DAT_HANG Where MaKH = @MaKH
	Delete KHACH_HANG Where MaKH = @MaKH
End
--**Store CN
--Sửa CN
--Xóa CN
GO
CREATE PROC proc_XoaCN
	@maCN CHAR(10)
AS
BEGIN
	
	IF EXISTS(SELECT TOP 1 1 FROM dbo.NHAN_VIEN nv, dbo.BAO_CAO bc, dbo.BAN b, dbo.DAT_HANG datH, dbo.DON_HANG donH,
							 dbo.GIAO_HANG gh, dbo.MON_AN ma 
			WHERE nv.MaCN = bc.MaCN AND bc.MaCN = b.MaCN AND b.MaCN = datH.MaCN AND datH.MaDH = donH.MaDH
				AND donH.MaDH = gh.MaDH AND donH.MaMA = ma.MaMA AND ma.MaCN = @maCN)
		BEGIN
			DELETE dbo.NHAN_VIEN WHERE MaCN = @maCN
			DELETE dbo.BAO_CAO WHERE MaCN = @maCN
			DELETE dbo.BAN WHERE MaCN = @maCN
			DELETE dbo.DAT_HANG WHERE MaCN = @maCN
			DELETE dbo.MON_AN WHERE MaCN = @maCN
		END 
	DELETE dbo.CHI_NHANH WHERE MaCN = @maCN
END
GO

--Xóa Bàn
GO
CREATE PROC proc_XoaBan
	@
AS
BEGIN

END