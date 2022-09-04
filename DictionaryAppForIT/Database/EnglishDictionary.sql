﻿create database EnglishDictionary
go
use EnglishDictionary
go
----------------------------------------- Tạo bảng
create table ChuyenNganh
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	TenChuyenNganh NVARCHAR(200) not null
)
go

create table TuLoai
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	TenLoai NVARCHAR(100) NOT NULL UNIQUE
)
go

create table Tu
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	TenTu VARCHAR(100) unique NOT NULL,
	PhienAm NVARCHAR(100) not null,
	ChuyenNganh INT references ChuyenNganh(ID),
	DongNghia  VARCHAR(1000),
	TraiNghia  VARCHAR(1000)
)
go
create table Nghia
(
	ID INT IDENTITY(1,1),
	IDTu INT references Tu(ID),
	IDTuLoai INT references TuLoai(ID),
	Nghia nvarchar(200) not null,
	MoTa NVARCHAR(1000),
	ViDu VARCHAR(500),
	primary key (IDTu, ID, IDTuLoai)
)
select * from  Nghia
go
create table TaiKhoan
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	TenDangNhap varchar(100) NOT NULL UNIQUE,
	MatKhau varchar(100) NOT NULL,
	Email varchar(100) NOT NULL UNIQUE,
	GioiTinh INT NOT NULL,
	Quyen INT NOT NULL DEFAULT 0
)
go
create table LichSuDich
(
	TiengAnh NVARCHAR(1000) primary key,
	TiengViet NVARCHAR(1000)
)
go
insert into LichSuDich values
(N'hello', N'Xin chào.'),
(N'variable', N'Biến số.'),
(N'constant', N'Hằng số.'),
(N'firewall', N'Tường lửa.')
go
-- xóa bản dịch đã lưu thông qua khóa chính là Tiếng anh
delete from LichSuDich where TiengAnh = 'Hello'
go
SELECT TiengAnh from LichSuDich Where TiengAnh = N'hi'-- or TiengViet =  N'Xin chào.'
-- xóa hết lịch sử
DELETE FROM LichSuDich
go
select * from LichSuDich
go
----------------------------------------- Thêm dữ liệu
-------- Chuyên ngành
create proc ThemChuyenNganh
	@TenChuyenNganh NVARCHAR(200)
as
	IF EXISTS (	SELECT * FROM ChuyenNganh WHERE TenChuyenNganh = @TenChuyenNganh)
		PRINT N'Đã có Từ Loại này trong CSDL'
	ELSE
		BEGIN
			INSERT INTO ChuyenNganh values (@TenChuyenNganh)
		END
go
-- drop proc ThemChuyenNganh

exec ThemChuyenNganh N'Mạng máy tính'
exec ThemChuyenNganh N'Kỹ thuật phần mềm'
exec ThemChuyenNganh N'Khoa học dữ liệu'
select * from ChuyenNganh
go
-------- Loại
create proc ThemTuLoai
	@TenTuLoai NVARCHAR(100)
as
	IF EXISTS (	SELECT * FROM TuLoai WHERE TenLoai = @TenTuLoai)
		PRINT N'Đã có Từ Loại này trong CSDL'
	ELSE
		BEGIN
			INSERT INTO TuLoai values (@TenTuLoai)
		END
go
-- drop proc ThemLoai
exec ThemTuLoai N'Danh từ'
exec ThemTuLoai N'Động từ'
exec ThemTuLoai N'Tính từ'
exec ThemTuLoai N'Trạng từ'
exec ThemTuLoai N'Giới từ'
exec ThemTuLoai N'Đại từ'
exec ThemTuLoai N'Liên từ'
exec ThemTuLoai N'Thán từ'
select * from TuLoai
go
-------- Từ
create proc ThemTu
	@idTu int out,
	@TenTu VARCHAR(100),
	@PhienAm NVARCHAR(100),
	@ChuyenNganh INT,
	@DongNghia  VARCHAR(1000),
	@TraiNghia  VARCHAR(1000)
as
	IF EXISTS (	SELECT * FROM Tu WHERE TenTu = @TenTu)
		PRINT N'Đã có Từ Loại này trong CSDL'
	ELSE
		BEGIN
			INSERT INTO Tu values (@TenTu, @PhienAm, @ChuyenNganh, @DongNghia, @TraiNghia) set @idTu = SCOPE_IDENTITY()
			return @idTu
		END
go
-- drop proc ThemTu

exec ThemTu 'Variable' , N'/´veə.ri.ə.bəl/', 2, 'Varying', 'Constant'
exec ThemTu 'Constant', N'/´kɒn.stənt/', 1, 'InConstant', 'Variable'
exec ThemTu 'Component', N'/kəm´pəʊ.nənt/', 2, 'Element', 'Whole'
exec ThemTu 'Firewall', N'/´faiəwɔ:l/', 1, '', 'Cyber threat'
select * from Tu
go
-------- Nghĩa
--drop table Nghia
create table Nghia
(
	ID INT IDENTITY(1,1),
	IDTu INT references Tu(ID),
	IDTuLoai INT references TuLoai(ID),
	Nghia nvarchar(200) not null,
	MoTa NVARCHAR(1000),
	ViDu VARCHAR(500),
	primary key (IDTu, ID, IDTuLoai)
)
go
create proc ThemNghia
	@IDTu INT,
	@IDTuLoai INT,
	@Nghia nvarchar(200),
	@MoTa NVARCHAR(1000),
	@ViDu VARCHAR(500)
as
	IF EXISTS (	SELECT * FROM Tu t WHERE t.ID = @IDTu)and exists(SELECT * FROM TuLoai WHERE ID = @IDTuLoai)
		begin
			IF exists(select * from Nghia where Nghia = @Nghia)
				PRINT N'Đã có trong từ này trong cơ sở dữ liệu.'
			ELSE
				BEGIN
					INSERT INTO Nghia values (@IDTu, @IDTuLoai, @Nghia, @MoTa, @ViDu)
				END
		end
	ELSE
		PRINT N'Thêm nghĩa không thành công.'
go
exec ThemNghia  1, 1, N'Biến', N'Biến là giá trị có thể thay đổi trong chương trình, nó thường được gắn liền với các địa điểm lưu trữ dữ liệu.', 'A variable is any letter or symbol that represents some unknown value.'
exec ThemNghia  1, 3, N'Có thể thay đổi', N'Đây là mô tả của Variable.', 'Đây là ví dụ của Variable'
exec ThemNghia  2, 1, N'Hằng', N'Hằng số là giá trị không đổi xuyên suốt chương trình.', 'Constants can be marked as public, private, protected, internal, protected internal or private protected.'
exec ThemNghia  3, 1, N'Thành phần', N'Đây là hệ thống của một quá trình, chương trình, tiện ích, hoặc bất kỳ phần nào của hệ điều hành.', 'An example of a component is an ingredient in a recipe.'
exec ThemNghia  4, 1, N'Tường lửa', N'tường lửa làm màn chắn điều khiển luồng lưu thông giữa các mạng, thường là giữa mạng và Internet, và giữa các mạng con trong công ty.', 'The firewall traces back to an early period in the modern internet era when systems.'
select * from Nghia
go
create proc HienThiThongTin
@tentu varchar(100)
as
	select TenTu, TenLoai, PhienAm, cn.TenChuyenNganh, Nghia, MoTa, ViDu, DongNghia, TraiNghia
	from Tu t, TuLoai tl, ChuyenNganh cn, Nghia n 
	where n.IDTuLoai = tl.ID and t.ChuyenNganh = cn.ID and n.IDTu = t.ID and t.TenTu = @tentu
	group by TenTu, TenLoai, PhienAm, cn.TenChuyenNganh, Nghia, MoTa, ViDu, DongNghia, TraiNghia
go
exec HienThiThongTin 'Constant'
go
-- them tu vung cho moi tai khoan

--			 TenTu		,PhienAm	  ,CN ,ĐN	, TraiNghia
EXEC ThemTu 'Test', N'/´test/', 2, 'dong nghia', 'trai nghia'
--			  IDTu,IDTuLoai,	Nghia	,		MoTa		,		ViDu
EXEC ThemNghia  5,   2, N'kiểm tra', N'kiểm tra cái gì đó', 'The test is the best.'
----
go
--create proc ThemTuVung
	
--as
go
select * from tu
select * from TuLoai
select * from Nghia
select * from ChuyenNganh
go
-------------------- Thủ tục
---
select * from ChuyenNganh
select * from TuLoai
select * from Nghia
select * from Tu
select * from TaiKhoan
go
-- Xem tat ca nghia cua 1 tu
create proc XemTatCaNghiaCuaTu
@TenTu VARCHAR(100)
as
	Select TenTu, TenLoai, Nghia, MoTa, ViDu
	from TuLoai tl, Nghia n, Tu t
	where tl.ID = n.IDTuLoai and t.ID = n.IDTu and TenTu = @TenTu
go
exec XemTatCaNghiaCuaTu 'Variable'
EXEC HienThiThongTin 'Variable'
go
-------- Lay all tu loai
create proc LayTuLoai
as
	Select ID, TenLoai from TuLoai
go
exec LayTuLoai
go
create proc LayTheoChuyenNganh
@chuyennganh INT
as
select t.ID, t.TenTu, tl.TenLoai, PhienAm, TenChuyenNganh, n.Nghia, n.MoTa, n.ViDu, DongNghia, TraiNghia
from Tu t, TuLoai tl, ChuyenNganh cn, Nghia n 
where t.ChuyenNganh = cn.ID and n.IDTu = t.ID and tl.ID = n.IDTuLoai and cn.ID = @chuyennganh
group by t.ID,t.TenTu, tl.TenLoai, PhienAm, TenChuyenNganh, n.Nghia, n.MoTa, n.ViDu, DongNghia, TraiNghia
go
exec LayTheoChuyenNganh 2
go
create proc TimTheoChuyenNganh
@tentu VARCHAR(100),
@chuyennganh INT
as
select t.ID, t.TenTu, tl.TenLoai, PhienAm, TenChuyenNganh, n.Nghia, n.MoTa, n.ViDu, DongNghia, TraiNghia
from Tu t, TuLoai tl, ChuyenNganh cn, Nghia n 
where t.ChuyenNganh = cn.ID and n.IDTu = t.ID and tl.ID = n.IDTuLoai and  t.TenTu = @tentu and cn.ID = @chuyennganh
group by t.ID,t.TenTu, tl.TenLoai, PhienAm, TenChuyenNganh, n.Nghia, n.MoTa, n.ViDu, DongNghia, TraiNghia
go
EXEC TimTheoChuyenNganh 'variable', 2
go
create proc KiemTraDangNhap
@tendangnhap varchar(100),
@matkhau varchar(100)
as
begin
    if exists (select * from TaiKhoan where TenDangNhap = @tendangnhap and MatKhau = @matkhau and [Quyen] = 1)
        select 1 as code
    else if exists (select * from TaiKhoan where TenDangNhap = @tendangnhap and MatKhau = @matkhau and [Quyen] = 0)
        select 0 as code
    else if exists(select * from TaiKhoan where TenDangNhap = @tendangnhap and MatKhau != @matkhau) 
        select 2 as code
    else select 3 as code
end
go
select * from TaiKhoan
go
-------- Tài khoản				
create proc DangKyTaiKhoan
	@TenDangNhap varchar(100),
	@MatKhau varchar(100),
	@Email varchar(100),
	@GioiTinh INT,
	@Quyen INT
as
	IF EXISTS (	SELECT * FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap or Email = @Email)
		PRINT N'Tài khoản đã tồn tại trong CSDL'
	ELSE
		BEGIN
			INSERT INTO TaiKhoan values (@TenDangNhap, @MatKhau, @Email, @GioiTinh, @Quyen)
		END
go
--  1: Nam, 2: Nữ, 3: Khác
-- Quyen = 1(admin)
--- Quyen = null thì mặc định bằng 0 (user)
EXEC DangKyTaiKhoan 'quanghuybest2k2', '123456', 'quanghuybest@gmail.com',1 , 1
EXEC DangKyTaiKhoan 'sangvlog', 'sangsos', 'sangvlog@gmail.com', 1,''
EXEC DangKyTaiKhoan 'bede', 'bede123', 'bede@gmail.com', 3, ''
EXEC DangKyTaiKhoan 'a','654321','test@gmail.com', 2,''
go
select * from TaiKhoan
go
--check email có tồn tại hay không
select * from TaiKhoan where Email = 'quanghuybest@gmail.com'

go
select * from TuLoai
select * from ChuyenNganh
select * from Nghia
select * from Tu
select * from TaiKhoan
go
-- Xóa tài khoản
Delete from TaiKhoan where ID = 9
-- lay theo chuyen nganh
SELECT TenTu FROM Tu, ChuyenNganh WHERE tu.ChuyenNganh = ChuyenNganh.ID and TenTu like 'c%' and ChuyenNganh.ID = 2
EXEC LayTheoChuyenNganh 2
go
-- lấy từ ngẫu nhiên(random)
create proc TuNgauNhien
@id INT
as
select TenTu, TenLoai, PhienAm, cn.TenChuyenNganh, Nghia, MoTa, ViDu, DongNghia, TraiNghia
	from Tu t, TuLoai tl, ChuyenNganh cn, Nghia n
	where n.IDTuLoai = tl.ID and t.ChuyenNganh = cn.ID and n.IDTu = t.ID and t.ID = @id
	group by TenTu, TenLoai, PhienAm, cn.TenChuyenNganh, Nghia, MoTa, ViDu, DongNghia, TraiNghia
go
EXEC TuNgauNhien 3
go
-- Lấy độ dài của từ
select count(TenTu) from Tu
select * from TaiKhoan
select count(Email) from TaiKhoan where Email = 'quanghuybest@gmail.com'
