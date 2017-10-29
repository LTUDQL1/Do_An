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
	Loai nvarchar(50),
	MaCN char(10),
	MaDMMA char(10),
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
	Ngay char(10),

	Constraint PK_BAO_CAO
	Primary Key(MaBC),
)
Create table DANH_MUC_MON_AN
(
	MaDMMA char(10) not null,
	TenDMMA nvarchar(50),
	constraint PK_DANH_MUC_MON_AN
	primary key(MaDMMA),
)
create table DON_HANG
(
	MaDonHang char(10) not null,
	MaDatHang char(10),
	TenMonAn nvarchar(50),
	SoLuong int,
	DonGia int,
	ThanhTien float
	constraint pf_CT_DON_HANG
	primary key(MaDonHang)
)
--Khóa Ngoại:
--DAT_HANG - KHACH_HANG
Alter table DAT_HANG
ADD
	Constraint FK_DATHANG_KHACHHANG
	Foreign Key (SoDTKhachHang)
	References KHACH_HANG(SoDienT)

--DAT_HANG - NHAN_VIEN
Alter table DAT_HANG
ADD
	Constraint FK_DATHANG_NHANVIEN
	Foreign Key (MaNV)
	References NHAN_VIEN(MaNV)

--DAT_HANG - CHI_NHANH
Alter table DAT_HANG
ADD
	Constraint FK_DATHANG_CHINHANH
	Foreign Key (MaCN)
	References CHI_NHANH(MaCN)

--CHI_TIET_DAT_HANG - DAT_HANG
Alter table CHI_TIET_DAT_HANG
ADD
	Constraint FK_CTDATHANG_DATHANG
	Foreign Key (MaDH)
	References DAT_HANG(MaDH)

--CHI_TIET_DAT_HANG - MON_AN
Alter table CHI_TIET_DAT_HANG
ADD
	Constraint FK_CTDATHANG_MONAN
	Foreign Key (MaMA)
	References MON_AN(MaMA)

--GIAO_HANG - DAT_HANG
Alter table GIAO_HANG
ADD
	Constraint FK_GIAOHANG_DATHANG
	Foreign Key (MaDH)
	References DAT_HANG(MaDH)

--CHI_TIET_GIAO_HANG - GIAO_HANG
Alter table CHI_TIET_GIAO_HANG
ADD
	Constraint FK_CTGIAOHANG_GIAOHANG
	Foreign Key (MaGH)
	References GIAO_HANG(MaGH)

--CHI_TIET_GIAO_HANG - MON_AN
Alter table CHI_TIET_GIAO_HANG
ADD
	Constraint FK_CTGIAOHANG_MONAN
	Foreign Key (MaMA)
	References MON_AN(MaMA)

--BAO_CAO - NHAN_VIEN
Alter table BAO_CAO
ADD
	Constraint FK_BAOCAO_NHANVIEN
	Foreign Key (MaNV)
	References NHAN_VIEN(MaNV)

--BAO_CAO_TONG - NHAN_VIEN
Alter table BAO_CAO_TONG
ADD
	Constraint FK_BAOCAOTONG_NHANVIEN
	Foreign Key (MaNV)
	References NHAN_VIEN(MaNV)

--BAO_CAO_TONG - BAO_CAO
Alter table BAO_CAO_TONG
ADD
	Constraint FK_BAOCAOTONG_BAOCAO
	FOREIGN KEY (MaBC)
	References BAO_CAO(MaBC)

--BAO_CAO - CHI_NHANH
Alter table BAO_CAO
ADD
	Constraint FK_BAOCAO_CHINHANH
	Foreign Key (MaCN)
	References CHI_NHANH(MaCN)

--DANH_MUC_MON_AN - MON_AN
alter table MON_AN
add
	constraint FK_MONAN_DANMUC_CHINHANH
	foreign key(MaDMMA)
	references DANH_MUC_MON_AN(MaDMMA)

--MON_AN - CHI_NHANH
alter table MON_AN
add
	constraint FK_MONAN_CHINHANH
	foreign key(MaCN)
	references CHI_NHANH(MaCN)

--DAT_HANG - DON_HANG
alter table DON_HANG
add
	constraint FK_DATHANG_DONHANG
	foreign key (MaDatHang)
	references DAT_HANG(MaDH)

--INSERT

INSERT INTO CHI_NHANH VALUES ('CN01',N'Chi nhánh 1',25,N'TP HCM','07712345678');
INSERT INTO CHI_NHANH VALUES ('CN02',N'Chi nhánh 2',20,N'TP Cần Thơ','06698765432');
INSERT INTO CHI_NHANH VALUES ('CN03',N'Chi nhánh 3',23,N'Hà Nội','00012332123');

INSERT INTO DANH_MUC_MON_AN VALUES ('DMMA01',N'Bò')
INSERT INTO DANH_MUC_MON_AN VALUES ('DMMA02','Heo')
INSERT INTO DANH_MUC_MON_AN VALUES ('DMMA03',N'Gà')
INSERT INTO DANH_MUC_MON_AN VALUES ('DMMA04',N'Hải sản')
INSERT INTO DANH_MUC_MON_AN VALUES ('DMMA05','Chay')
INSERT INTO DANH_MUC_MON_AN VALUES ('DMMA06',N'Tráng miệng')
INSERT INTO DANH_MUC_MON_AN VALUES ('DMMA07',N'Thức uống')
INSERT INTO DANH_MUC_MON_AN VALUES ('DMMA08',N'Món thêm')

INSERT INTO MON_AN VALUES ('MA01',N'Bún Bò Huế','1000000',NULL,'MonMan','CN01','DMMA01')
INSERT INTO MON_AN VALUES ('MA02',N'Bún Bò Xào','1000000',NULL,'MonMan','CN02','DMMA01')
INSERT INTO MON_AN VALUES ('MA03',N'Bò Lá Lốt','1000000',NULL,'MonMan','CN01','DMMA01')
INSERT INTO MON_AN VALUES ('MA04',N'Cơm Bò Xào','1000000',NULL,'MonMan','CN03','DMMA01')
INSERT INTO MON_AN VALUES ('MA05',N'Mì Xào Bò','1000000',NULL,'MonMan','CN02','DMMA01')
INSERT INTO MON_AN VALUES ('MA06',N'Sườn Xào Chua Ngọt','1000000',NULL,'MonMan','CN01','DMMA02')
INSERT INTO MON_AN VALUES ('MA07',N'Thịt Kho Củ Cải','1000000',NULL,'MonMan','CN01','DMMA02')
INSERT INTO MON_AN VALUES ('MA08',N'Thịt Kho Tàu','1000000',NULL,'MonMan','CN02','DMMA02')
INSERT INTO MON_AN VALUES ('MA09',N'Thịt Heo Chiên Giòn','1000000',NULL,'MonMan','CN03','DMMA02')
INSERT INTO MON_AN VALUES ('MA10',N'Thịt Heo Nướng Xá Xíu','1000000',NULL,'MonMan','CN03','DMMA02')
INSERT INTO MON_AN VALUES ('MA11',N'Gà Chiên Giòn','1000000',NULL,'MonMan','CN01','DMMA03')
INSERT INTO MON_AN VALUES ('MA12',N'Cơm Gà Xối Mỡ','1000000',NULL,'MonMan','CN02','DMMA03')
INSERT INTO MON_AN VALUES ('MA13',N'Miến Gà','1000000',NULL,'MonMan','CN01','DMMA03')
INSERT INTO MON_AN VALUES ('MA14',N'Gà Hấp Bia','1000000',NULL,'MonMan','CN03','DMMA03')
INSERT INTO MON_AN VALUES ('MA15',N'Kim Chi','1000000',NULL,'MonChay','CN01','DMMA05')
INSERT INTO MON_AN VALUES ('MA16',N'Miến Xào Rau','1000000',NULL,'MonChay','CN02','DMMA05')
INSERT INTO MON_AN VALUES ('MA17',N'Gỏi Quấn Chay','1000000',NULL,'MonChay','CN03','DMMA05')
INSERT INTO MON_AN VALUES ('MA18',N'Đậu Hủ Xả Ớt','1000000',NULL,'MonChay','CN01','DMMA05')
INSERT INTO MON_AN VALUES ('MA19',N'Nước Hạt Chia','1000000',NULL,'Nuoc','CN01','DMMA07')
INSERT INTO MON_AN VALUES ('MA20',N'Chanh Xả','1000000',NULL,'Nuoc','CN01','DMMA07')
INSERT INTO MON_AN VALUES ('MA21',N'Tắc Mật Ong','1000000',NULL,'Nuoc','CN01','DMMA07')
INSERT INTO MON_AN VALUES ('MA22',N'Nước Ép','1000000',NULL,'Nuoc','CN01','DMMA07')
INSERT INTO MON_AN VALUES ('MA23',N'Nước Ngọt','1000000',NULL,'Nuoc','CN01','DMMA07')
INSERT INTO MON_AN VALUES ('MA24',N'Bánh Flan','1000000',NULL,'Dessert','CN01','DMMA06')
INSERT INTO MON_AN VALUES ('MA25',N'Chè','1000000',NULL,'Dessert','CN01','DMMA06')
INSERT INTO MON_AN VALUES ('MA26',N'Sữa Chua','1000000',NULL,'Dessert','CN01','DMMA06')
INSERT INTO MON_AN VALUES ('MA27',N'Trái Cây Tô','1000000',NULL,'Dessert','CN01','DMMA06')

INSERT INTO NHAN_VIEN VALUES ('NV01','CN01',N'Nguyễn Công Hiệp','Nam',0909010203,N'Bình Thuận','02/15/1997','123456','123123')
INSERT INTO NHAN_VIEN VALUES ('NV02','CN02',N'Nguyễn Đức Hoàng','Nam',0987654321,N'Cần Thơ','10/01/1997','hoang123','quick')
INSERT INTO NHAN_VIEN VALUES ('NV03','CN02',N'Nguyễn Lê Huy Hoàng','Nam',01626389324,N'Bình Thuận','09/23/1993','sieunhan','yeuquai')
INSERT INTO NHAN_VIEN VALUES ('NV04','CN03',N'Lê Sỹ Hoàng','Nam',0985274694,'TPHCM','11/15/1995','naruto','sasuke')
INSERT INTO NHAN_VIEN VALUES ('NV05','CN03',N'Trương Thái Huy','Nam',01626181876,N'Bến Tre','08/12/1996','Huy123','huy123')

INSERT INTO KHACH_HANG VALUES ('01639871234',N'Trần Hoàng Văn','Quận 1')
INSERT INTO KHACH_HANG VALUES ('0987654300',N'Nguyễn Đình Yên','Quận 8')
INSERT INTO KHACH_HANG VALUES ('0987678987',N'Lý Hoàng Yến','Quận 3')
INSERT INTO KHACH_HANG VALUES ('0990876567',N'Trương Vô Kỵ','Quận 5')
INSERT INTO KHACH_HANG VALUES ('0987987001',N'Lê Lợi','Quận 4')

INSERT INTO BAO_CAO VALUES ('BC01','NV01','CN01',20,3,N'Ngày')
INSERT INTO BAO_CAO VALUES ('BC02','NV02','CN02',25,4,N'Tháng')
INSERT INTO BAO_CAO VALUES ('BC03','NV03','CN02',19,3,N'Ngày')
INSERT INTO BAO_CAO VALUES ('BC04','NV04','CN03',24,4,N'Tháng')
INSERT INTO BAO_CAO VALUES ('BC05','NV05','CN03',28,4,N'Năm')

INSERT INTO BAO_CAO_TONG VALUES ('BC01','NV01',3,'3/20/2015')
INSERT INTO BAO_CAO_TONG VALUES ('BC02','NV02',3,'3/20/2015')
INSERT INTO BAO_CAO_TONG VALUES ('BC03','NV03',3,'3/20/2015')
INSERT INTO BAO_CAO_TONG VALUES ('BC04','NV04',3,'3/20/2015')
INSERT INTO BAO_CAO_TONG VALUES ('BC05','NV05',3,'3/20/2015')

INSERT INTO DAT_HANG VALUES ('DH01','CN01','NV01','01639871234','12/26/2015',200000,N'Không')	
INSERT INTO DAT_HANG VALUES ('DH02','CN01','NV01','0987987001','08/23/2015',300000,N'Không')	
INSERT INTO DAT_HANG VALUES ('DH03','CN02','NV02','0990876567','05/25/2015',250000,N'Không')	
INSERT INTO DAT_HANG VALUES ('DH04','CN03','NV04','0987678987','10/11/2015',200000,N'Không')	
INSERT INTO DAT_HANG VALUES ('DH05','CN03','NV05','0987654300','04/08/2015',150000,N'Không')	

INSERT INTO DON_HANG VALUES ('DonH01','DH01',N'Bò xào tơ',2,80000,160000)
INSERT INTO DON_HANG VALUES ('DonH02','DH02',N'Gà kho xả',1,60000,60000)
INSERT INTO DON_HANG VALUES ('DonH03','DH03',N'Bò xào tơ',3,80000,240000)
INSERT INTO DON_HANG VALUES ('DonH04','DH04',N'Thịt heo chiền giòn',2,50000,100000)
INSERT INTO DON_HANG VALUES ('DonH05','DH05',N'Hải sản chiên giòn',2,70000,140000)

INSERT INTO CHI_TIET_DAT_HANG VALUES ('DH01','MA01',2,70000)
INSERT INTO CHI_TIET_DAT_HANG VALUES ('DH02','MA02',2,70000)
INSERT INTO CHI_TIET_DAT_HANG VALUES ('DH03','MA03',2,70000)
INSERT INTO CHI_TIET_DAT_HANG VALUES ('DH04','MA04',2,70000)
INSERT INTO CHI_TIET_DAT_HANG VALUES ('DH05','MA05',2,70000)

INSERT INTO GIAO_HANG VALUES ('GH01','12/26/2015','DH01')
INSERT INTO GIAO_HANG VALUES ('GH02','08/23/2015','DH02')
INSERT INTO GIAO_HANG VALUES ('GH03','05/25/2015','DH03')
INSERT INTO GIAO_HANG VALUES ('GH04','10/11/2015','DH04')
INSERT INTO GIAO_HANG VALUES ('GH05','04/08/2015','DH05')

INSERT INTO CHI_TIET_GIAO_HANG VALUES ('GH01','MA01',2)
INSERT INTO CHI_TIET_GIAO_HANG VALUES ('GH02','MA02',2)
INSERT INTO CHI_TIET_GIAO_HANG VALUES ('GH03','MA03',2)
INSERT INTO CHI_TIET_GIAO_HANG VALUES ('GH04','MA04',2)
INSERT INTO CHI_TIET_GIAO_HANG VALUES ('GH05','MA05',2)