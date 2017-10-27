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
alter table MON_AN
add MaCN char(10)
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
alter table DAT_HANG
add MaDonHang char(10)
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
Create table DANH_MUC_MON_AN
(
	MaDMMA char(10) not null,
	TenDMMA nvarchar(50),
	MaMA char(10),
	constraint PK_DANH_MUC_MON_AN
	primary key(MaDMMA),
)
create table DANH_MUC_CHI_NHANH
(
	MaDMCN char(10) not null,
	TenDMCN nvarchar(50),
	MaCN char(10),
	constraint PK_DANH_MUC_CHI_NHANH
	PRIMARY KEY(MaDMCN)
)

alter table DANH_MUC_MON_AN
add
	constraint FK_DANHMUC_MONAN_CHINHANH
	foreign key(MaMA)
	references MON_AN(MaMA)
alter table DANH_MUC_CHI_NHANH
add
	constraint FK_DANHMUC_CHINHANH
	foreign key(MaCN)
	references CHI_NHANH(MaCN)
alter table MON_AN
add
	constraint FK_MONAN_CHINHANH
	foreign key(MaCN)
	references CHI_NHANH(MaCN)

create table DON_HANG
(
	MaDonHang char(10) not null,
	TenDH nvarchar(50),
	MaCN char(10),
	MaMA char(10),
	constraint PK_DON_HANG
	primary key(MaDonHang),
)
alter table DON_HANG
add MaNV char(10)
alter table DAT_HANG
add
	constraint FK_DATHANG_DONHANG
	foreign key (MaDonHang)
	references DON_HANG(MaDonHang)
alter table DON_HANG
add 
	constraint FK_DONHANG_MONAN
	foreign key(MaMA)
	references MON_AN(MaMA)
alter table DON_HANG
add 
	constraint FK_DONHANG_CHINHANH
	foreign key(MaCN)
	references CHI_NHANH(MaCN)
create table CHI_TIET_DON_HANG
(
	MaDonHang char(10),
	TenMonAn nvarchar(50),
	SoLuong int,
	DonGia int,
	TenNhanVien nvarchar(50)
	constraint pf_CT_DON_HANG
	primary key(MaDonHang)
)
alter table CHI_TIET_DON_HANG
add
	constraint FK_CT_DONHANG
	foreign key(MaDonHang)
	references DON_HANG(MaDonHang)


--INSERT INTO dbo.NHAN_VIEN
--        ( MaNV ,
--          MaCN ,
--          HoTen ,
--          GioiTinh ,
--          DienThoai ,
--          DiaChi ,
--          NgaySinh ,
--          TaiKhoan ,
--          MatKhau
--        )
--VALUES  ( '001' , -- MaNV - char(10)
--          'CN1' , -- MaCN - char(10)
--          N'Lê Sỹ Hoàng' , -- HoTen - nvarchar(50)
--          'Nam' , -- GioiTinh - char(5)
--          01212121 , -- DienThoai - int
--          N'77/7 đường Số 7' , -- DiaChi - nvarchar(100)
--          '1994/09/04' , -- NgaySinh - datetime
--          'shle001' , -- TaiKhoan - char(10)
--          '1'  -- MatKhau - char(10)
--        ),
--		( '002' , -- MaNV - char(10)
--          'CN1' , -- MaCN - char(10)
--          N'Nguyễn Lê Huy Hoàng' , -- HoTen - nvarchar(50)
--          'Nam' , -- GioiTinh - char(5)
--          01212222 , -- DienThoai - int
--          N'6/9 đường Số 69' , -- DiaChi - nvarchar(100)
--          '1969/06/09' , -- NgaySinh - datetime
--          'hhnguyen002' , -- TaiKhoan - char(10)
--          '1'  -- MatKhau - char(10)
--        )
--GO

--INSERT INTO dbo.CHI_NHANH
--        ( MaCN ,
--          TenCN ,
--          SoLuongBan ,
--          ThongTinBan ,
--          DiaChi ,
--          TinhThanh ,
--          SoDienT
--        )
--VALUES  ( 'CN1' , -- MaCN - char(10)
--          N'Chi nhánh 1' , -- TenCN - nvarchar(50)
--          20 , -- SoLuongBan - int
--          'Không có' , -- ThongTinBan - char(10)
--          N'1 đường số 1' , -- DiaChi - nvarchar(100)
--          N'Sài Gòn' , -- TinhThanh - nvarchar(50)
--          '0232323232'  -- SoDienT - char(15)
--        )
--GO

--INSERT INTO dbo.DANH_MUC_CHI_NHANH
--        ( MaDMCN, TenDMCN, MaCN )
--VALUES  ( '1', -- MaDMCN - char(10)
--          N'Khu vực Sài Gòn', -- TenDMCN - nvarchar(50)
--          'CN1'  -- MaCN - char(10)
--          )
--GO




--INSERT INTO dbo.MON_AN
--        ( MaMA ,
--          TenMA ,
--          DonGia ,
--          ThongTin ,
--          Loai ,
--          MaCN
--        )
--VALUES  ( 'BX' , -- MaMA - char(10)
--          N'Bò Xào' , -- TenMA - nvarchar(50)
--          100000 , -- DonGia - int
--          N'không có' , -- ThongTin - nvarchar(100)
--          N'Đồ ăn' , -- Loai - nvarchar(50)
--          'CN1'  -- MaCN - char(10)
--        ),
--		( 'BN' , -- MaMA - char(10)
--          N'Bò Né' , -- TenMA - nvarchar(50)
--          150000 , -- DonGia - int
--          N'không có' , -- ThongTin - nvarchar(100)
--          N'Đồ ăn' , -- Loai - nvarchar(50)
--          'CN1'  -- MaCN - char(10)
--        ),
--		( 'GN' , -- MaMA - char(10)
--          N'Gà nướng' , -- TenMA - nvarchar(50)
--          250000 , -- DonGia - int
--          N'không có' , -- ThongTin - nvarchar(100)
--          N'Đồ ăn' , -- Loai - nvarchar(50)
--          'CN1'  -- MaCN - char(10)
--        ),
--		( 'CK' , -- MaMA - char(10)
--          N'Coke' , -- TenMA - nvarchar(50)
--          150000 , -- DonGia - int
--          N'không có' , -- ThongTin - nvarchar(100)
--          N'Giải khát' , -- Loai - nvarchar(50)
--          'CN1'  -- MaCN - char(10)
--        )
--GO

--INSERT INTO dbo.DANH_MUC_MON_AN
--        ( MaDMMA, TenDMMA, MaMA )
--VALUES  ( 'B01', -- MaDMMA - char(10)
--          N'Bò', -- TenDMMA - nvarchar(50)
--          'BX'  -- MaMA - char(10)
--          ),
--		  ( 'B01', -- MaDMMA - char(10)
--          N'Bò', -- TenDMMA - nvarchar(50)
--          'BN'  -- MaMA - char(10)
--          )
