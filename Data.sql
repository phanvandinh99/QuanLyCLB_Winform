create database DataCLB
go 
use DataCLB
go
create table BiThu
(
	MSBT varchar(10) primary key,
	MatKhau varchar(50) not null,
	Ho	nvarchar(50) not null,
	Ten nvarchar(50) not null,
	GioiTinh varchar(10),
	SDT varchar(10) null,
)
go
insert into BiThu(MSBT, MatKhau, Ho, Ten, GioiTinh, SDT) values ('BT01', 'abc123', N'Phan', N'A', 'Nam', '0123456789');
insert into BiThu(MSBT, MatKhau, Ho, Ten, GioiTinh, SDT) values ('BT02', 'abc123', N'Thị', N'Nhi', 'Nu', '0256254524');
go
create table DiaDiem
(
	MaDD varchar(10) primary key,
	TenDD nvarchar(100) not null,
	GhiChu nvarchar(200) null,
)
go
insert into DiaDiem(MaDD, TenDD, GhiChu) values ('MADD01', N'Trưng Nữ Vương', N'Tầng 3 Hội trường lớn');
insert into DiaDiem(MaDD, TenDD, GhiChu) values ('MADD02', N'Phú Gia', N'Công Viên Nước');
go
create table CLB
(
	MaCLB varchar(10) primary key,
	MSBT varchar(10) not null,
	TenCLB nvarchar(100) not null,
	LienKetFB nvarchar(200) null,

	Foreign key(MSBT)references BiThu(MSBT),
)
go
insert into CLB(MaCLB, MSBT, TenCLB, LienKetFB) values ('CLB01', 'BT01', N'CLB Gitar', N'fb.com');
insert into CLB(MaCLB, MSBT, TenCLB, LienKetFB) values ('CLB02', 'BT02', N'CLB English', N'fb2.com');

go
create table ChiaDiaDiem
(
	TT int identity(1,1) primary key,
	MaCLB varchar(10) not null,
	MADD varchar(10) not null,
	NgayBatDau datetime not null,
	NgayKetThuc datetime not null,
	constraint KiemTraNgay check (NgayKetThuc>= NgayBatDau), -- Kiểm tra ngày kết thúc phải lớn hơn hoặc = ngày bắt đầu

	Foreign key(MaCLB)references CLB(MaCLB),
	Foreign key(MADD)references DiaDiem(MADD),
)
go
insert into ChiaDiaDiem (MaCLB, MADD, NgayBatDau, NgayKetThuc) values ('CLB01', 'MADD01', '02/02/2020', '02/04/2021');
insert into ChiaDiaDiem (MaCLB, MADD, NgayBatDau, NgayKetThuc) values ('CLB02', 'MADD02', '01/02/2020', '01/02/2021');

go
create table ThanhVien
(
	MSSV varchar(10) primary key,
	MatKhau varchar(50) not null,
	Ho	nvarchar(50) not null,
	Ten nvarchar(50) not null,
	Khoa varchar(10) not null,
	NgaySinh Date not null,
	GioiTinh nvarchar(10) not null,
	SDT varchar(10) null,
	ChucVu Nvarchar(10) not null, -- quyền quản lý clb : ThanhVien & ChuNhiem
)
go
insert into ThanhVien (MSSV, MatKhau, Ho, Ten, Khoa, NgaySinh, GioiTinh, SDT, ChucVu)
values ('SV001', 'abc123', N'Nhật', N'Minh', N'CNTT', '02/11/1995', N'Nam', '0123456789', 'ThanhVien');
insert into ThanhVien (MSSV, MatKhau, Ho, Ten, Khoa, NgaySinh, GioiTinh, SDT, ChucVu)
values ('SV002', 'abc123', N'Thanh', N'Thái', N'Ô Tô', '02/11/1992', N'Nam', '0236548754', 'ChuNhiem');
go
create table GiaNhap 
(
	MSSV varchar(10) not null,
	MaCLB varchar(10) not null,
	primary key (MSSV, MaCLB),
	NgayGiaNhap date not null,

	Foreign key(MSSV)references ThanhVien(MSSV),
	Foreign key(MaCLB)references CLB(MaCLB),
)
go
insert into GiaNhap(MSSV, MaCLB, NgayGiaNhap) values ('SV001', 'CLB01', '02/5/2020');
insert into GiaNhap(MSSV, MaCLB, NgayGiaNhap) values ('SV001', 'CLB02', '06/5/2020');
insert into GiaNhap(MSSV, MaCLB, NgayGiaNhap) values ('SV002', 'CLB01', '06/11/2021');
insert into GiaNhap(MSSV, MaCLB, NgayGiaNhap) values ('SV002', 'CLB02', '11/12/2021');