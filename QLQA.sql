Use master
GO
If DB_ID('QLQA') IS NOT NULL
Begin;
	Drop Database QLQA;
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
	Loai nvarchar(50), -- 'Food' || 'Drink' || 'Dessert' || '...'

	Constraint PK_MON_AN
	primary key(MaMA),
)
Create table CHI_NHANH
(
	MaCN char(10) NOT NULL,
	TenCN nvarchar(50),
	SoLuongBan int,
	ThongTinBan char(10), -- 'Trống' || 'Có Khách'
	DiaChi nvarchar(100),
	TinhThanh nvarchar(50),
	SoDienT char(15),

	Constraint PK_CHI_NHANH
	primary key(MaCN),
)
Create table KHACH_HANG
(
	SoDienT char(15) NOT NULL,
	HoTen nvarchar(50),
	DiaChi nvarchar(50),

	Constraint PK_KHACH_HANG
	primary key(SoDienT),
)
Create table DAT_HANG
(
	MaDH char(10) NOT NULL,
	MaCN char(10),
	MaNV char(10),
	SoDTKhachHang char(15),
	NgayDH datetime,
	ThanhTien int,
	GhiChu nvarchar(100),

	Constraint PK_DAT_HANG
	primary key(MaDH),
)
Create table CHI_TIET_DAT_HANG
(
	MaDH char(10),
	MaMA char(10),
	SoLuong int,
	DonGia int,

	Constraint PK_CT_DAT_HANG
	primary key(MaDH, MaMA),
)
Create table GIAO_HANG
(
	MaGH char(10) NOT NULL,
	NgayGH datetime,
	MaDH char(10),

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
	MaNV char(10) NOT NULL,
	MaCN char(10),
	HoTen nvarchar(50),
	GioiTinh char(5),
	DienThoai int,
	DiaChi nvarchar(100),
	NgaySinh datetime,
	TaiKhoan char(10),
	MatKhau char(10),

	Constraint PK_NHAN_VIEN
	Primary Key(MaNV),
)
Create table BAO_CAO_TONG
(
	MaBC char(10) NOT NULL,
	MaNV char(10),
	TongDT int,
	Ngay datetime,

	Constraint PK_BAO_CAO_TONG
	Primary Key(MaBC),
)
Create table BAO_CAO
(
	MaBC char(10) NOT NULL,
	MaNV char(10),
	MaCN char(10),
	SoLuongDH int,
	TongDT int,
	Ngay char(10),--'NGAY'||'TUAN'||'THANG'||'QUY'||'NAM'

	Constraint PK_BAO_CAO
	Primary Key(MaBC),
)

Alter table DAT_HANG
ADD
	Constraint FK_DATHANG_KHACHHANG
	Foreign Key (SoDTKhachHang)
	References KHACH_HANG(SoDienT)

Alter table DAT_HANG
ADD
	Constraint FK_DATHANG_NHANVIEN
	Foreign Key (MaNV)
	References NHAN_VIEN(MaNV)

Alter table DAT_HANG
ADD
	Constraint FK_DATHANG_CHINHANH
	Foreign Key (MaCN)
	References CHI_NHANH(MaCN)

Alter table CHI_TIET_DAT_HANG
ADD
	Constraint FK_CTDATHANG_DATHANG
	Foreign Key (MaDH)
	References DAT_HANG(MaDH)

Alter table CHI_TIET_DAT_HANG
ADD
	Constraint FK_CTDATHANG_MONAN
	Foreign Key (MaMA)
	References MON_AN(MaMA)

Alter table GIAO_HANG
ADD
	Constraint FK_GIAOHANG_DATHANG
	Foreign Key (MaDH)
	References DAT_HANG(MaDH)

Alter table CHI_TIET_GIAO_HANG
ADD
	Constraint FK_CTGIAOHANG_GIAOHANG
	Foreign Key (MaGH)
	References GIAO_HANG(MaGH)

Alter table CHI_TIET_GIAO_HANG
ADD
	Constraint FK_CTGIAOHANG_MONAN
	Foreign Key (MaMA)
	References MON_AN(MaMA)

Alter table BAO_CAO
ADD
	Constraint FK_BAOCAO_NHANVIEN
	Foreign Key (MaNV)
	References NHAN_VIEN(MaNV)

Alter table BAO_CAO_TONG
ADD
	Constraint FK_BAOCAOTONG_NHANVIEN
	Foreign Key (MaNV)
	References NHAN_VIEN(MaNV)

Alter table BAO_CAO
ADD
	Constraint FK_BAOCAO_CHINHANH
	Foreign Key (MaCN)
	References CHI_NHANH(MaCN)