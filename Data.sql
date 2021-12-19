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
)
go
insert into ThanhVien (MSSV, MatKhau, Ho, Ten, Khoa, NgaySinh, GioiTinh, SDT)
values ('SV001', 'abc123', N'Nhật', N'Minh', N'CNTT', '02/11/1995', N'Nam', '0123456789');
insert into ThanhVien (MSSV, MatKhau, Ho, Ten, Khoa, NgaySinh, GioiTinh, SDT)
values ('SV002', 'abc123', N'Thanh', N'Thái', N'Ô Tô', '02/11/1992', N'Nam', '0236548754');
go
create table ChuNhiem
(
	MaSCN varchar(10) primary key,
	MatKhau varchar(50) not null,
	Ho nvarchar(50) not null,
	Ten nvarchar(50) not null,
	Khoa varchar(10) not null,
	NgaySinh Date not null,
	GioiTinh nvarchar(10) not null,
	SDT varchar(10) null,
)
go
insert into ChuNhiem (MaSCN, MatKhau, Ho, Ten, Khoa, NgaySinh, GioiTinh, SDT) 
values ('CN001', 'abc123', N'Tuấn', N'Nghĩa', N'CNTT', '02/02/1999', N'Nam', '0123456789');
insert into ChuNhiem (MaSCN, MatKhau, Ho, Ten, Khoa, NgaySinh, GioiTinh, SDT) 
values ('CN002', 'abc123', N'Nhật', N'Minh', N'Hóa', '02/12/1995', N'Nam', '0236525451');
insert into ChuNhiem (MaSCN, MatKhau, Ho, Ten, Khoa, NgaySinh, GioiTinh, SDT) 
values ('CN003', 'abc123', N'Trần', N'Mới', N'Xây Dựng', '12/07/1992', N'Nam', '0654525452');
go
create table CLB
(
	MaCLB varchar(10) primary key,
	MSBT varchar(10) not null,
	MaSCN varchar(10) not null,
	TenCLB nvarchar(100) not null,
	LienKetFB nvarchar(200) null,

	Foreign key(MSBT)references BiThu(MSBT),
	Foreign key(MaSCN)references ChuNhiem(MaSCN),
)
go
insert into CLB(MaCLB, MSBT, MaSCN, TenCLB, LienKetFB) values ('CLB01', 'BT01', 'CN001', N'CLB Gitar', N'fb.com');
insert into CLB(MaCLB, MSBT, MaSCN, TenCLB, LienKetFB) values ('CLB02', 'BT02', 'CN002', N'CLB English', N'fb2.com');
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
-----
select TV.MaSCN, TV.MatKhau, TV.Ho, TV.Ten, TV.Khoa, TV.NgaySinh, TV.GioiTinh, TV.SDT, G.TenCLB
from ChuNhiem TV
join CLB G ON TV.MaSCN = G.MaSCN
order by TV.Ten

select TV.MSSV, TV.MatKhau, TV.Ho, TV.Ten, TV.Khoa, TV.NgaySinh, TV.GioiTinh, TV.SDT, C.TenCLB
from ThanhVien TV 
join GiaNhap G ON TV.MSSV = G.MSSV 
join CLB C ON C.MaCLB = G.MaCLB order by TV.Ten





update GiaNhap set MaCLB = 'CLB02' where MSSV = 'SV001'

select * from ThanhVien
select * from ChuNhiem
select * from BiThu

select * 
from ChuNhiem C1
where NOT EXISTS(
Select * 
from ChuNhiem C2
join CLB C
on C2.MaSCN = C.MaSCN AND
C2.MaSCN = C1.MaSCN)


update ChuNhiem set MatKhau = 'abc123', Ho=N'Phan', Ten =N'Định', Khoa = N'CNTT', NgaySinh = '02/02/1999', GioiTinh = N'Nữ', SDT = '123' where MaSCN ='1'
select * 
from CLB CN
join CLB C ON C.MaSCN = CN.MaSCN
order by CN.Ten



