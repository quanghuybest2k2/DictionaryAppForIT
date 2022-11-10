use master
-- drop database EnglishDictionary
create database EnglishDictionary
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
	TraiNghia  VARCHAR(1000),
	IDTK INT DEFAULT 0
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
go
create table TaiKhoan
(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	TenDangNhap varchar(100) NOT NULL,
	MatKhau varchar(100) NOT NULL,
	Email varchar(100) NOT NULL,
	GioiTinh INT NOT NULL,
	NgayTaoTK varchar(30) NOT NULL
)
go
select * from TaiKhoan
go
create table LichSuDich
(
	ID INT IDENTITY(1,1),
	TiengAnh VARCHAR(400),
	TiengViet NVARCHAR(400),
	NgayHienTai varchar(30),
	IDTK INT references TaiKhoan(ID),
	primary key (ID, IDTK, NgayHienTai)
)
go
create table LichSuTraTu
(
	ID INT IDENTITY(1,1),
	TiengAnh VARCHAR(400),
	PhienAm NVARCHAR(400),
	TiengViet NVARCHAR(400),
	NgayHienTai varchar(30),
	IDTK INT references TaiKhoan(ID),
	primary key (ID, IDTK, NgayHienTai)
)
go
create table YeuThichTuVung
(
	ID INT IDENTITY(1,1),
	TiengAnh VARCHAR(400),
	PhienAm NVARCHAR(400),
	TiengViet NVARCHAR(400),
	GhiChu NVARCHAR(400),
	IDTK INT references TaiKhoan(ID),
	primary key (ID, IDTK)
)
go
select * from YeuThichTuVung
create table YeuThichVanBan
(
	ID INT IDENTITY(1,1),
	TiengAnh VARCHAR(400),
	TiengViet NVARCHAR(400),
	GhiChu NVARCHAR(400),
	IDTK INT references TaiKhoan(ID),
	primary key (ID, IDTK)
)
go
SELECT * FROM YeuThichVanBan
go
SELECT * FROM LichSuTraTu
SELECT * FROM LichSuDich
-- Từ vựng phổ biến (khoảng 8 từ)
go

-- DROP PROC HienThiTuVungHot
CREATE PROC HienThiTuVungHot
AS
		SELECT TOP 8 TiengAnh, PhienAm, TiengViet,COUNT(ID) as soLanXuatHien
		FROM LichSuTraTu
		GROUP BY TiengAnh, TiengViet, PhienAm
		ORDER BY COUNT(ID) DESC
go
select  * from LichSuTraTu
EXEC HienThiTuVungHot
go
SELECT * FROM YeuThichVanBan
-- go
-- delete from LichSuTraTu where id = 56 or id = 60 and IDTK = 2
go
select * from LichSuDich
-- delete from LichSuTraTu where idtk = 1 delete from LichSuDich where idtk = 1
go
-- select COUNT(ID) from LichSuTraTu where IDTK = 1
select * from Tu
select * from Nghia
--go
-- delete from LichSuTraTu
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
-- drop proc ThemTu
create proc ThemTu
	@idTu int out,
	@TenTu VARCHAR(100),
	@PhienAm NVARCHAR(100),
	@ChuyenNganh INT,
	@DongNghia  VARCHAR(1000),
	@TraiNghia  VARCHAR(1000),
	@IDTK INT
as
	IF EXISTS (	SELECT * FROM Tu WHERE TenTu = @TenTu)
		PRINT N'Đã có Từ Loại này trong CSDL'
	ELSE
		BEGIN
			INSERT INTO Tu values (@TenTu, @PhienAm, @ChuyenNganh, @DongNghia, @TraiNghia, @IDTK) set @idTu = SCOPE_IDENTITY()
			return @idTu
		END
go
-- INSERT INTO Tu values ('Variable', N'/`veə.ri.ə.bəl/', 2, 'Varying', 'Constant', '')
select * from Tu
go
-------- Nghĩa
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
-- exec ThemNghia  1, 1, N'Biến', N'Biến là giá trị có thể thay đổi trong chương trình, nó thường được gắn liền với các địa điểm lưu trữ dữ liệu.', 'A variable is any letter or symbol that represents some unknown value.'
go
select TenTu from Tu where IDTK = 1 or IDTK = 0
go
select * from Tu
select * from Nghia
go
-- drop proc HienThiThongTin
create proc HienThiThongTin
@tentu varchar(100),
@idtk INT
as
	select TenTu, TenLoai, PhienAm, cn.TenChuyenNganh, Nghia, MoTa, ViDu, DongNghia, TraiNghia, IDTK
	from Tu t, TuLoai tl, ChuyenNganh cn, Nghia n 
	where n.IDTuLoai = tl.ID and t.ChuyenNganh = cn.ID and n.IDTu = t.ID
	group by TenTu, TenLoai, PhienAm, cn.TenChuyenNganh, Nghia, MoTa, ViDu, DongNghia, TraiNghia,  IDTK
	having t.TenTu = @tentu and IDTK = @idtk  or IDTK = 0 and t.TenTu = @tentu
go
exec HienThiThongTin 'back', 2
go
-- Kiểm tra xem từ có tồn tại hay không
SELECT TenTu FROM Tu where TenTu = 'back' and IDTK = 2 or IDTK = 0 and TenTu = 'back'
SELECT * FROM Tu
go
-------- Lịch sử tra từ
create proc ThemLSTraTu
	@IDLS INT out,
	@TiengAnh VARCHAR(400),
	@PhienAm NVARCHAR(400),
	@TiengViet NVARCHAR(400),
	@NgayHienTai varchar(30),
	@IDTK INT
as
	BEGIN
		INSERT INTO LichSuTraTu values (@TiengAnh, @PhienAm, @TiengViet, @NgayHienTai, @IDTK) set @IDLS = SCOPE_IDENTITY()
		return @IDLS
	END
go

--INSERT INTO LichSuTraTu values ('Variable', N'/´veə.ri.ə.bəl/', N'Biến',  GETDATE())
--EXEC ThemLSTraTu 6 output, 'Variable', N'/´veə.ri.ə.bəl/', N'Biến',  GETDATE()
select * from LichSuTraTu
go
-- them tu vung cho moi tai khoan

--			 TenTu		,PhienAm	  ,CN ,ĐN	, TraiNghia
-- EXEC ThemTu 'Test', N'/´test/', 2, 'dong nghia', 'trai nghia'
--			  IDTu,IDTuLoai,	Nghia	,		MoTa		,		ViDu
-- EXEC ThemNghia  5,   2, N'kiểm tra', N'kiểm tra cái gì đó', 'The test is the best.'
----
-- go
-- Lưu từ yêu thích
create proc LuuTuYeuThich
	@IDYT INT out,
	@TiengAnh VARCHAR(400),
	@PhienAm NVARCHAR(400),
	@TiengViet NVARCHAR(400),
	@GhiChu NVARCHAR(400),
	@IDTK INT
as
	IF NOT EXISTS (	SELECT * FROM YeuThichTuVung WHERE TiengAnh = @TiengAnh and TiengViet = @TiengViet and IDTK = @IDTK)
		BEGIN
			INSERT INTO YeuThichTuVung values (@TiengAnh, @PhienAm, @TiengViet, @GhiChu,@IDTK) set @IDYT = SCOPE_IDENTITY()
			return @IDYT
		END
go
-- EXEC LuuTuYeuThich output, 'tienganh', N'phienam',N'tiengviet', N'',10
select * from YeuThichTuVung
select COUNT(ID) from YeuThichTuVung where TiengAnh = 'Component' and IDTK = 10
-- sap xep yeu thich
select * from YeuThichTuVung where IDTK = 2
order by TiengAnh ASC
select * from YeuThichVanBan where IDTK = 2
order by TiengAnh ASC
---
select * from YeuThichTuVung where IDTK = 2 order by TiengAnh ASC
select * from YeuThichVanBan where IDTK = 2 order by TiengAnh ASC
select * from YeuThichTuVung where IDTK = 2 order by TiengAnh DESC
select * from YeuThichVanBan where IDTK = 2 order by TiengAnh DESC
-- DELETE FROM YeuThichTuVung
-- DELETE FROM YeuThichTuVung WHERE TiengAnh = 'Component' AND IDTK = 10
-- UPDATE YeuThichTuVung SET GhiChu = N'abc' WHERE ID = 4 and IDTK = 1
go
-- xoa lich su tra tu yeu thich
-- delete from YeuThichTuVung where id = 3 and IDTK = 2
-- Lưu từ văn bản yêu thích
create proc LuuVanBanYeuThich
	@IDYT INT out,
	@TiengAnh VARCHAR(400),
	@TiengViet NVARCHAR(400),
	@GhiChu NVARCHAR(400),
	@IDTK INT
as
	IF NOT EXISTS (	SELECT * FROM YeuThichVanBan WHERE TiengAnh = @TiengAnh and IDTK = @IDTK)
		BEGIN
			INSERT INTO YeuThichVanBan values (@TiengAnh, @TiengViet, @GhiChu, @IDTK) set @IDYT = SCOPE_IDENTITY()
			return @IDYT
		END
go
-- EXEC LuuVanBanYeuThich '', N'', N'', 10
SELECT * FROM YeuThichVanBan
SELECT * FROM YeuThichTuVung
-- xoa van ban yeu thich
--delete from YeuThichVanBan where id = 1 and IDTK = 2
-- UPDATE YeuThichVanBan SET GhiChu = N'abc' WHERE ID = 10 and IDTK = 1
-------------------- Thủ tục ---------------------------
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
go
-------- Lay all tu loai
create proc LayTuLoai
as
	Select ID, TenLoai from TuLoai
go
exec LayTuLoai
go

--drop proc LayTheoChuyenNganh
create proc LayTheoChuyenNganh
@chuyennganh INT,
@idtk INT
as
select t.ID, t.TenTu, tl.TenLoai, PhienAm, TenChuyenNganh, n.Nghia, n.MoTa, n.ViDu, DongNghia, TraiNghia, IDTK
from Tu t, TuLoai tl, ChuyenNganh cn, Nghia n 
where t.ChuyenNganh = cn.ID and n.IDTu = t.ID and tl.ID = n.IDTuLoai and cn.ID = @chuyennganh
group by t.ID,t.TenTu, tl.TenLoai, PhienAm, TenChuyenNganh, n.Nghia, n.MoTa, n.ViDu, DongNghia, TraiNghia, IDTK
having IDTK = @idtk or IDTK = 0
go
exec LayTheoChuyenNganh 1, 1
go
-- tim theo chuyen nganh
-- drop proc TimTheoChuyenNganh
create proc TimTheoChuyenNganh
@tentu VARCHAR(100),
@chuyennganh INT,
@idtk INT
as
select t.ID, t.TenTu, tl.TenLoai, PhienAm, TenChuyenNganh, n.Nghia, n.MoTa, n.ViDu, DongNghia, TraiNghia, IDTK
from Tu t, TuLoai tl, ChuyenNganh cn, Nghia n 
where t.ChuyenNganh = cn.ID and n.IDTu = t.ID and tl.ID = n.IDTuLoai and  t.TenTu = @tentu and cn.ID = @chuyennganh
group by t.ID,t.TenTu, tl.TenLoai, PhienAm, TenChuyenNganh, n.Nghia, n.MoTa, n.ViDu, DongNghia, TraiNghia, IDTK
having IDTK = @idtk or IDTK = 0
go
EXEC TimTheoChuyenNganh 'variable', 2, 1
go
--
SELECT * FROM Tu

SELECT TenTu 
FROM Tu, ChuyenNganh 
WHERE tu.ChuyenNganh = ChuyenNganh.ID and ChuyenNganh.ID = 2 and IDTK = 2 and TenTu like 'c%' or tu.ChuyenNganh = ChuyenNganh.ID and IDTK = 0 and TenTu like 'c%' and ChuyenNganh.ID = 2
go
-- Tìm kiếm lịch sử
create proc HienThiTimKiemLSTT
@tentu varchar(100),
@IDTK int
as
	select ID, TiengAnh, TiengViet, PhienAm, NgayHienTai, IDTK
	from LichSuTraTu
	where TiengAnh = @tentu and IDTK = @IDTK
go
EXEC HienThiTimKiemLSTT 'component', 2
go
-- tim lich su dich
create proc HienThiTimKiemLSD
@tentu varchar(100),
@IDTK int
as
	select ID, TiengAnh, TiengViet, NgayHienTai, IDTK
	from LichSuDich
	where TiengAnh like concat('%',@tentu,'%') and IDTK = @IDTK
go
EXEC HienThiTimKiemLSD 'e', 10
go
-- Select DISTINCT * from LichSuTraTu lstt where lstt.IDTK = 10 and lstt.TiengAnh = 'Variable'
Select * from LichSuTraTu
Select * from LichSuDich
go
-- Tìm kiếm yêu thích từ vựng
create proc HienThiTimKiemYTTraTu
@tentu varchar(100),
@IDTK int
as
	select ID, TiengAnh, PhienAm, TiengViet, GhiChu, IDTK
	from YeuThichTuVung
	where TiengAnh = @tentu and IDTK = @IDTK
go
EXEC HienThiTimKiemYTTraTu 'component', 1
go
-- Tìm kiếm yêu thích văn bản
create proc HienThiTimKiemYTVanBan
@tentu varchar(100),
@IDTK int
as
	select ID, TiengAnh, TiengViet, GhiChu,IDTK
	from YeuThichVanBan
	where TiengAnh like concat('%',@tentu,'%') and IDTK = @IDTK
go
EXEC HienThiTimKiemYTVanBan 'sang', 1
go
create proc KiemTraDangNhap
@tendangnhap varchar(100),
@matkhau varchar(100)
as
begin
    if exists (select * from TaiKhoan where TenDangNhap = @tendangnhap and MatKhau = @matkhau)
        select 1 as code -- đúng tài khoản và mật khẩu
    else if exists(select * from TaiKhoan where TenDangNhap = @tendangnhap and MatKhau != @matkhau) 
        select 2 as code -- không khớp tài khoản và mật khẩu
    else select 3 as code -- tài khoản đã tồn tại
end
go
-- exec KiemTraDangNhap 'quanghuybest2k2', '123456'
select * from TaiKhoan
go
-- lấy id của tài khoản hiện tại
-- SELECT ID FROM TaiKhoan WHERE TenDangNhap = 'quanghuybest2k2'
go
-------- Tài khoản				
create proc DangKyTaiKhoan
	@TenDangNhap varchar(100),
	@MatKhau varchar(100),
	@Email varchar(100),
	@GioiTinh INT,
	@NgayTaoTK varchar(30)
as
	IF EXISTS (	SELECT * FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap or Email = @Email)
		PRINT N'Tài khoản đã tồn tại trong CSDL'
	ELSE
		BEGIN
			INSERT INTO TaiKhoan values (@TenDangNhap, @MatKhau, @Email, @GioiTinh, @NgayTaoTK)
		END
go
--  1: Nam, 2: Nữ, 3: Khác
EXEC DangKyTaiKhoan 'quanghuybest2k2', '123456', 'quanghuybest@gmail.com',1, '27/09/2022'
EXEC DangKyTaiKhoan 'sangvlog', 'sangsos', 'sangvlog@gmail.com', 1, '25/09/2022'
EXEC DangKyTaiKhoan 'bocute', 'bocute123', 'bocute@gmail.com', 3, '25/09/2022'
EXEC DangKyTaiKhoan 'virusday','123456','test@gmail.com', 2, '26/09/2022'
go
select * from TaiKhoan
go
--check email có tồn tại hay không
select * from TaiKhoan where Email = 'quanghuybest@gmail.com'
go
-- Hiển thị thông tin tài khoản trong phần quản lý tài khoản
create proc HienThiThongTinTaiKhoan
@Id int
as
begin
	select * from TaiKhoan where ID = @Id
end
go
EXEC HienThiThongTinTaiKhoan 1
go
-- cập nhật thông tin tài khoản
create proc CapNhatThongTinTaiKhoan
@Id INT,
@TenDangNhap varchar(100),
@MatKhau varchar(100),
@Email VARCHAR(100),
@GioiTinh INT
as
begin
	UPDATE TaiKhoan
	SET TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, Email = @Email,GioiTinh = @GioiTinh
	WHERE ID = @Id
end
go
-- EXEC CapNhatThongTinTaiKhoan '1', 'quanghuybest2k2', '123456', 'quanghuybest@gmail.com', '1'
go
select * from TuLoai
select * from ChuyenNganh
select * from Nghia
select * from Tu
select * from TaiKhoan
go
-- Xóa tài khoản
-- Delete from TaiKhoan where ID = 9
-- lay theo chuyen nganh
SELECT TenTu FROM Tu, ChuyenNganh WHERE tu.ChuyenNganh = ChuyenNganh.ID and TenTu like 'c%' and ChuyenNganh.ID = 2
-- EXEC LayTheoChuyenNganh 2
go
-- lấy từ ngẫu nhiên(random)
-- drop proc TuNgauNhien
create proc TuNgauNhien
@id INT,
@idtk INT
as
select TenTu, TenLoai, PhienAm, cn.TenChuyenNganh, Nghia, MoTa, ViDu, DongNghia, TraiNghia, IDTK
	from Tu t, TuLoai tl, ChuyenNganh cn, Nghia n
	where n.IDTuLoai = tl.ID and t.ChuyenNganh = cn.ID and n.IDTu = t.ID and t.ID = @id
	group by TenTu, TenLoai, PhienAm, cn.TenChuyenNganh, Nghia, MoTa, ViDu, DongNghia, TraiNghia, IDTK
	HAVING IDTK = @idtk or IDTK = 0
go
EXEC TuNgauNhien 3, 2
go
-- goi y tim kiem
select TenTu from Tu where IDTK = 2 or IDTK = 0
-- Lấy độ dài của từ
select count(TenTu) from Tu
select * from TaiKhoan
select count(Email) from TaiKhoan where Email = 'quanghuybest@gmail.com'
select COUNT(ID) from LichSuTraTu
select TiengAnh, TiengViet from LichSuDich
-- xoa tat ca 2 bang
--delete from LichSuTraTu delete from LichSuDich
--delete from LichSuTraTu where id = 16
select TiengAnh from LichSuTraTu where id = 27
-- Đếm số mục yêu thích
select sum(AllCount) AS Tong_SoMucYeuThich
from((select count(*) AS AllCount
	  from YeuThichTuVung) union all (select count(*) AS AllCount from YeuThichVanBan))t

	  select * from Tu where IDTK = 2 or IDTK = 0
SELECT TOP 1 ID FROM Tu where IDTK = 1 or IDTK = 0 ORDER  BY NEWID()
-- Mini game
Select distinct(TiengAnh) from LichSuTraTu
Select * from LichSuTraTu where IDTK = 1 or IDTK = 0
-- n, adj
-- random tu_vung
select top 1 TiengAnh from LichSuTraTu where IDTK = 1 ORDER  BY NEWID()
go
-- lay nghia tu_vung
select top 1 TiengViet from LichSuTraTu where TiengAnh = 'Component'and IDTK = 1 ORDER  BY NEWID()
go
-- drop proc RandomDapAn
Create proc RandomDapAn
@nghia VARCHAR(400)
AS
		select top 3 TiengViet
		from (select distinct TiengViet from LichSuTraTu) as TiengViet
		where TiengViet NOT IN (SELECT TiengViet FROM LichSuTraTu WHERE TiengAnh = @nghia)
		ORDER  BY NEWID()
go
select distinct TiengViet from LichSuTraTu
EXEC RandomDapAn 'component'
----
go
select * from LichSuTraTu where IDTK = 1  and NgayHienTai like '%29/10/2022%'
go
select * from LichSuDich where IDTK = 1  and NgayHienTai like '%29/10/2022%'
go
--update LichSuTraTu set NgayHienTai = '28/10/2022 03:58 PM' where ID = 1 and IDTK = 1
--update LichSuTraTu set NgayHienTai = '28/09/2022 03:58 PM' where ID = 3 and IDTK = 1
--update LichSuTraTu set NgayHienTai = '28/08/2022 03:58 PM' where ID = 4 and IDTK = 1
--update LichSuTraTu set NgayHienTai = '31/10/2022 03:58 PM' where ID = 6 and IDTK = 1
--update LichSuTraTu set NgayHienTai = '05/11/2022 03:58 PM' where ID = 7 and IDTK = 1
--update LichSuTraTu set NgayHienTai = '22/10/2022 03:58 PM' where ID = 8 and IDTK = 1
--update LichSuDich set NgayHienTai = '28/10/2022 03:58 PM' where ID = 4 and IDTK = 1
--update LichSuDich set NgayHienTai = '28/09/2022 03:58 PM' where ID = 5 and IDTK = 1
--update LichSuDich set NgayHienTai = '28/08/2022 03:58 PM' where ID = 6 and IDTK = 1
--update LichSuDich set NgayHienTai = '22/10/2022 03:58 PM' where ID = 7 and IDTK = 1
go
SELECT * FROM LichSuTraTu where IDTK = 5
go
CREATE PROC RandomMiniGame
@idtk int
AS
select top 10 TiengAnh, TenLoai,TiengViet
	from
	(
		select distinct lstt.TiengAnh, tl.TenLoai,TiengViet from LichSuTraTu lstt, TuLoai tl, Tu t, Nghia n where lstt.IDTK = @idtk and lstt.TiengAnh = t.TenTu and t.ID = n.IDTu and n.IDTuLoai = tl.ID and lstt.TiengViet = n.Nghia
	) as random
	order by newid()
go
EXEC RandomMiniGame 5
go
-- Random bổ sung nếu chưa đủ 10 từ
CREATE PROC RandomNeuChuaDu
@soTu INT
AS
	select top (@soTu) TenTu, TenLoai, Nghia
	from
	(
		select distinct t.TenTu, tl.TenLoai, n.Nghia from TuLoai tl, Tu t, Nghia n where t.IDTK = 0 and t.ID = n.IDTu and n.IDTuLoai = tl.ID
	)  as random
	order by newid()
go
EXEC RandomNeuChuaDu 3
select * from LichSuTraTu
select * from Tu where IDTK = 0
-------------------------------------- Thêm từ vựng mặc định ------------------------------------
----------------------- Chuyên ngành mạng máy tính
INSERT INTO Tu values ('Variable', N'/ˈver.i.ə.bəl/', '2', 'Varying', 'Invariable', '')-- idtk = 0
INSERT INTO Nghia values ('1', '1', N'Biến', N'Biến (variable) là một vùng chứa (container) chứa một giá trị (value), chẳng hạn như một đoạn văn bản (text ) hoặc một số (number). Giá trị của nó có thể thay đổi đó là lý do tại sao nó được gọi là biến (variable)', 'int number = 20; // C#')
INSERT INTO Nghia values ('1', '3', N'Thay đổi', N'Variable khi sử dụng như tính từ mang nghĩa thay đổi (không cố định), nó thường nằm trước danh từ. Ví dụ trong SQL kiểu dữ liệu varchar có độ dài chuỗi ký tự thay đổi (variable length) nghĩa là kích thước không cố định như kiểu dữ liệu char.', 'city VARCHAR(50) -- SQL')

INSERT INTO Tu values ('Constant', N'/ˈkɑːn.stənt/', '2', 'Invariable', 'Inconstant', '')-- idtk = 0
INSERT INTO Nghia values ('2', '1', N'Hằng số', N'Hằng số (constant) là một số (number), chuỗi văn bản (text string) hoặc ký hiệu (symbol ) không bao giờ thay đổi giá trị trong khi chương trình đang chạy. Các biến (variable) có thể tăng hoặc giảm giá trị nhưng một hằng số (constant) vẫn giữ nguyên giá trị.', 'const int a = 2020; // C#')

INSERT INTO Tu values ('Component', N'/kəmˈpoʊ.nənt/', '2', 'Constituent', 'Whole', '')-- idtk = 0
INSERT INTO Nghia values ('3', '1', N'Thành phần', N'Đối với phần mềm, là một đoạn mã được thiết kế để thực thi như một phần của chương trình lớn hơn.', 'In programming design, a system is divided into components that in turn are made up of modules.')
INSERT INTO Nghia values ('3', '1', N'Bộ phận', N'Đối với phần cứng, hay còn gọi là part là một đơn vị phần cứng được thiết kế để kết nối và hoạt động như một phần của hệ thống lớn hơn.', 'An integrated circuit can be thought of as a component of the motherboard and a video card can be thought of as a component of a computer.')

INSERT INTO Tu values ('Firewall', N'/ˈfaɪə.wɔːl/', '1', 'Barricade', 'Firing', '')-- idtk = 0
INSERT INTO Nghia values ('4', '1', N'Tường lửa', N'Tường lửa là một phần mềm tiện ích (software utility) hoặc thiết bị phần cứng (hardware device) hoạt động như một bộ lọc dữ liệu vào hoặc ra khỏi mạng hoặc máy tính', 'Without a firewall, all your files could be instantly accessible to any competent hacker from anywhere in the world.')

INSERT INTO Tu values ('ISP', N'/ˌaɪ.esˈpiː/', '1', '', '', '')-- idtk = 0
INSERT INTO Nghia values ('5', '1', N'Nhà phân phối dịch vụ internet', N'Viết tắt của Internet service provider, ngoài ra còn được gọi là access provider hoặc network provider.', 'Some ISPs are free and give you as many email addresses as you want.')

INSERT INTO Tu values ('Download', N'/ˈdaʊn.loʊd/', '1', 'Transfer', 'Upload', '')-- idtk = 0
INSERT INTO Nghia values ('6', '2', N'Tải xuống', N'Trên các mạng máy tính, download ( tải xuống ) có nghĩa là nhận dữ liệu từ một hệ thống từ xa', 'All of our products are available for download on our website.')

INSERT INTO Tu values ('Web hosting', N'/ˈweb ˌhoʊ.stɪŋ/', '1', 'Hosting services', 'Storage', '')-- idtk = 0
INSERT INTO Nghia values ('7', '1', N'Dịch vụ lưu trữ website', N'Dịch vụ lưu giữ và quản lý các trang web trên một máy chủ', 'The group supplies web-hosting services to blue-chip firms.')

INSERT INTO Tu values ('Website', N'/ˈweb.saɪt/', '1', 'Internet site', 'Software', '')-- idtk = 0
INSERT INTO Nghia values ('8', '1', N'Trang web', N'Trang web được xác định bằng một tên miền chung và được xuất bản trên ít nhất một máy chủ web.', 'His fans created a website, giving every detail of his private life.')

INSERT INTO Tu values ('Wi-fi', N'/ˈwaɪ.faɪ/', '1', 'Cellular', 'Wired', '')-- idtk = 0
INSERT INTO Nghia values ('9', '1', N'Không dây', N'Wifi là viết tắt của Wireless Fidelity được hiểu là sử dụng sóng vô tuyến để truyền tín hiệu.', 'The coffee shop now offers free wi-fi.')

INSERT INTO Tu values ('Network', N'/ˈnet.wɝːk/', '1', 'System', 'Fill', '')-- idtk = 0
INSERT INTO Nghia values ('10', '1', N'Mạng lưới', N'Là một tập hợp các máy tính, máy chủ (server), máy tính lớn (mainframes), thiết bị mạng, thiết bị ngoại vi,...', 'The stock exchanges have proven to be resourceful in networking these deals')

INSERT INTO Tu values ('Protocol', N'/ˈproʊ.t̬ə.kɑːl/', '1', 'Convention', 'Misconception', '')-- idtk = 0
INSERT INTO Nghia values ('11', '1', N'Giao thức', N'Giao thức là các quy tắc để trao đổi dữ liệu giữa các máy tính.', 'Protocol is a standardized set of rules for formatting and processing data.')

INSERT INTO Tu values ('Command', N'/kəˈmænd/', '1', 'Enjoin', 'Request', '')-- idtk = 0
INSERT INTO Nghia values ('12', '2', N'Ra lệnh, lệnh', N'Là một lệnh (command) máy tính phải thực hiện.', 'Commands can have several formats.')

INSERT INTO Tu values ('Application', N'/ˌæp.ləˈkeɪ.ʃən/', '1', 'Function', 'Misuse', '')-- idtk = 0
INSERT INTO Nghia values ('13', '1', N'Phần mềm ứng dụng, ứng dụng', N'Một chương trình máy tính được thiết kế để giúp con người thực hiện một kiểu công việc nào đó', 'Spreadsheet applications.')

INSERT INTO Tu values ('Circuit', N'/‘sə:kit/', '1', 'Route', '', '')-- idtk = 0
INSERT INTO Nghia values ('14', '1', N'Mạch', N'Trong điện tử, mạch điện (circuit) là một đường dẫn kín cho phép dòng điện chạy từ điểm này sang điểm khác.', 'Big electronic circuits can carry huge amounts of data.')

INSERT INTO Tu values ('Convert', N'/kən’və:t/', '1', 'Change', 'Remain', '')-- idtk = 0
INSERT INTO Nghia values ('15', '2', N'Chuyển đổi', N'Chuyển đổi (convert) có nghĩa thay đổi một thứ này thành thứ khác.', 'Best way to convert your PNG to ICO file in seconds.')

INSERT INTO Tu values ('Bandwidth', N'/ˈbænd.wɪtθ/', '1', 'Radio bandwidth', 'Handful of', '')-- idtk = 0
INSERT INTO Nghia values ('16', '1', N'Băng thông', N'Băng thông hay còn gọi là băng thông mạng, băng thông dữ liệu, hoặc băng thông kỹ thuật số là tốc độ truyền dữ liệu tối đa trên một đường dẫn nhất định.', 'Was he referring to the auction of digital bandwidths?')

INSERT INTO Tu values ('Packet', N'/ˈpæk.ɪt/', '1', 'Bundle', 'Separate', '')-- idtk = 0
INSERT INTO Nghia values ('17', '1', N'Gói tin', N'Trong mạng, một gói tin là một đoạn nhỏ của một bản tin lớn hơn.', 'Every Web page that you receive comes as a series of packets')

INSERT INTO Tu values ('Password', N'/ˈpæs.wɝːd/', '1', 'Countersign', 'Request', '')-- idtk = 0
INSERT INTO Nghia values ('18', '1', N'Mật khẩu', N'Mật khẩu thường là một xâu, chuỗi, loạt các ký tự mà dịch vụ internet phần mềm hệ thống máy tính.', 'Setting a password for the database file is optional.')

INSERT INTO Tu values ('Update', N'/ʌpˈdeɪt/', '1', 'Upgrade', 'Break', '')-- idtk = 0
INSERT INTO Nghia values ('19', '1', N'Sự cập nhật', N'Chúng ta có thể hiểu đơn giản nghĩa của nó là cập nhật một cái gì đó mới, hoặc sửa lỗi một phần mềm, phiên bản game…', 'The latest version is a much improved update of the original program.')
INSERT INTO Nghia values ('19', '2', N'Làm cho cập nhật', N'Động từ update là hành động khiến thứ gì đó hiện đại hoặc dễ dàng sử dụng hơn.', 'I just updated the specialized English dictionary.')

INSERT INTO Tu values ('LAN', N'/læn/', '1', '', '', '')-- idtk = 0
INSERT INTO Nghia values ('20', '1', N'Mạng cục bộ', N'LAN (Local Area Network) tạm dịch là mạng máy tính nội bộ, giao tiếp này cho phép các máy tính kết nối với nhau để cùng làm việc và chia sẻ dữ liệu.', 'The computers keep everything talking to everything else over the wireless LAN network.')

INSERT INTO Tu values ('WAN', N'/wɑːn/', '1', 'DongNghia', 'TraiNghia', '')-- idtk = 0
INSERT INTO Nghia values ('21', '1', N'Mạng diện rộng', N'Mạng diện rộng (WAN) là công nghệ kết nối các văn phòng, trung tâm dữ liệu, ứng dụng đám mây và bộ nhớ đám mây của bạn với nhau.', 'High speed broadband has made real-time WAN communications possible.')

INSERT INTO Tu values ('VPN', N'/ˌviː.piːˈen/', '1', '', '', '')-- idtk = 0
INSERT INTO Nghia values ('22', '1', N'Mạng riêng ảo', N'VPN là (Virtual Private Network) là một công nghệ mạng giúp tạo kết nối mạng an toàn khi tham gia vào mạng công cộng như Internet.', 'Traditional VPN setups can act as a conduit for worms and viruses.')

INSERT INTO Tu values ('DNS', N'/ˌdiː.enˈes/', '1', '', '', '')-- idtk = 0
INSERT INTO Nghia values ('23', '1', N'Hệ thống phân giải tên miền', N'Hệ thống phân giải tên miền là một hệ thống cho phép thiết lập tương ứng giữa địa chỉ IP và tên miền trên Internet.', 'The router does a DNS lookup, and stores the IP address in the configuration.')

INSERT INTO Tu values ('Server', N' /ˈsɝː.vɚ/', '1', 'Host', '', '')-- idtk = 0
INSERT INTO Nghia values ('24', '1', N'Máy chủ, máy phục vụ', N'Máy chủ (Server) là một máy tính được kết nối với mạng máy tính hoặc Internet, có IP tĩnh, có năng lực xử lý cao.', 'All your e-mails are saved on the internet provider`s server.')
----------------------- Chuyên ngành kỹ thuật lập trình
INSERT INTO Tu values ('Access',N'/ˈæk.ses/','2','connection','expulsion','')
INSERT INTO Nghia values ('25','1',N'Truy cập',N'Truy cập (access) chỉ đơn giản là có thể lấy những gì bạn cần.','Most people use their phones to access the internet.')

INSERT INTO Tu values ('Binary',N' /ˈbaɪ.ner.i/','2','double','single','')
INSERT INTO Nghia values ('26','3',N'Nhị phân, thuộc về nhị phân',N'Hệ nhị phân là một hệ đếm dùng hai ký tự để biểu đạt một giá trị số, bằng tổng số các lũy thừa của 2','The data is stored in binary, which is then decoded and played back.')

INSERT INTO Tu values ('Calculation',N' /ˈkæl.kjə.leɪt/','2','computation','','')
INSERT INTO Nghia values ('27','2',N'Tính toán',N'Phép tính là một quá trình toán học có chủ ý biến một hoặc nhiều đầu vào thành một hoặc nhiều đầu ra hoặc kết quả.','The computer will calculate your position with pinpoint accuracy.')

INSERT INTO Tu values ('Computerized',N'/kəmˈpjuː.t̬ə.raɪzd/','2','automated','nonautomatic','')
INSERT INTO Nghia values ('28','3',N'Tin học hóa',N'Tin học hóa được hiểu là các hoạt động đều được hệ thống tin học hỗ trợ kiểm soát, lưu trữ và theo dõi','People could use the information stations to access the computerized database.')

INSERT INTO Tu values ('Data',N'/ˈdeɪ.t̬ə/','2','information','','')
INSERT INTO Nghia values ('29','1',N'Dữ liệu',N'Dữ liệu là một tập hợp các dữ kiện, thông tin mô tả về sự vật','Magnetic-tape data storage is a system for storing digital information on magnetic tape using digital recording')

INSERT INTO Tu values ('Digital',N'/ˈdɪdʒ.ə.t̬əl/','2','numeric','','')
INSERT INTO Nghia values ('30','3',N'Kỹ thuật số',N'Kỹ thuật số là việc ghi lại hoặc lưu trữ thông tin dưới dạng một chuỗi nhị phân','The analogue signal from the instrument was converted to digital and recorded on a laptop computer.')

INSERT INTO Tu values ('Function',N'/ˈfʌŋk.ʃən/','2','task','','')
INSERT INTO Nghia values ('31','1',N'Hàm, chức năng',N'Hàm là một nhóm các câu lệnh cùng xử lý một nhiệm vụ cụ thể nào đó.','The website benefits from a highly-efficient search function.')

INSERT INTO Tu values ('Horizontal ',N' /ˌhɔːr.ɪˈzɑːn.t̬əl/','2','','Vertical','')
INSERT INTO Nghia values ('32','3',N'Ngang, đường ngang',N'Phương nằm ngang song song với mặt đất và vuông góc với phương thẳng đứng','The horizontal top and bottom bars indicate the lowest and highest values, excluding outliers.')

INSERT INTO Tu values ('Integrate',N'/ˈɪn.t̬ə.ɡreɪt/','2','combine','divide','')
INSERT INTO Nghia values ('33','2',N'Tích hợp',N'Tích hợp là kết hợp 2 hay nhiều thứ để chúng làm việc cùng nhau.','This step-by-step maths tutorial takes you through integrating a function.')

INSERT INTO Tu values ('Layer',N'/ˈleɪ.ɚ/','2','level','','')
INSERT INTO Nghia values ('34','1',N'Tầng, lớp',N'Lớp là các thành phần của một đối tượng nào đó','The architecture consists of input and output layers separated by two "hidden" layers.')

INSERT INTO Tu values ('Multiplication',N'/ˌmʌl.tə.pləˈkeɪ.ʃən/','2','icrease','decrease','')
INSERT INTO Nghia values ('35','1',N'phép nhân',N'Phép nhân là một phép toán tìm kết quả của hai hoặc nhiều số bằng các phép cộng lặp lại các số.','Many useful functions can be recognised as representation changers; examples include compilers and arithmetic functions such as addition and multiplication.')

INSERT INTO Tu values ('Numeric',N'/nuˈmerɪk/','2','mathematical','alphabetic','')
INSERT INTO Nghia values ('36','3',N'Số học, thuộc về số học',N'Một số là một đối tượng toán học được sử dụng để đếm, đo lường và dán nhãn','The developer meant to say simply that the design could be varied by changing numeric parameters.')

INSERT INTO Tu values ('Operation ',N'/ˌɑː.pəˈreɪ.ʃən/','2','process','inactivity','')
INSERT INTO Nghia values ('37','1',N'Thao tác',N'Thao tác là việc thực hiện những động tác kĩ thuật để hoàn thành một công việc gì đó.','The search tasks, in which participants are assumed to perform operations in parallel on a single visual display are also used for the same purpose.')

INSERT INTO Tu values ('Output ',N' /ˈaʊt.pʊt/','2','product','input','')
INSERT INTO Nghia values ('38','1',N'Đầu ra (thông tin do máy tính đưa ra)',N'output mang hàm ý thông tin do máy tính đưa ra, đề xuất, đầu ra dữ liệu','Performance on object naming was tested by giving the visual attributes as input and seeing whether the correct name was generated as output.')

INSERT INTO Tu values ('Perform',N'/pɚˈfɔːrm/','2','execute','cancel','')
INSERT INTO Nghia values ('39','2',N'Tiến hành, thi hành',N'Thực thi trong kỹ thuật máy tính và phần mềm là quá trình máy tính hoặc máy ảo thực hiện tập lệnh của chương trình máy tính','Computers can perform a variety of tasks.')

INSERT INTO Tu values ('Position ',N' /pəˈzɪʃ.ən/','2','place','','')
INSERT INTO Nghia values ('40','1',N'Vị trí',N'Vị trí (position) dùng để xác định một đối tượng cụ thể nào đó','This makes it easier to calculate the position of each element by simply adding an offset to a base value,')

INSERT INTO Tu values ('Process',N'/ˈprɑː.ses/','2','action','inaction','')
INSERT INTO Nghia values ('41','1',N'Tiến trình',N'Trong khoa học máy tính, tiến trình là một thực thể của một chương trình máy tính đang được thực thi bởi một hoặc nhiều luồng','if a computer processes data, it uses a set of instructions to organize it and produce a particular result:')

INSERT INTO Tu values ('Quantity ',N' /ˈkwɑːn.t̬ə.t̬i/','2','volume','','')
INSERT INTO Nghia values ('42','1',N'Số lượng',N'Số lượng (quantity) là một giá trị số học có được sau khi thực hiện đếm các đối tượng','In many applications, including image processing and computer vision, we need to track quantities that are defined on the surfaces.')

INSERT INTO Tu values ('Solution',N' /səˈluː.ʃən/','2','explanation','problem','')
INSERT INTO Nghia values ('43','1',N'Giải pháp, lời giải',N'Giải pháp là một tập hợp các chương trình phần mềm và / hoặc dịch vụ liên quan được bán dưới dạng một gói duy nhất.','To obtain numerical solutions, it is necessary to chose a model for the slow-wave structure.')

INSERT INTO Tu values ('Subtraction',N'/səbˈtræk.ʃən/','2','decrease','increase','')
INSERT INTO Nghia values ('44','1',N'Phép trừ',N'Phép trừ là việc thực hiện tính toán giữa hai hoặc nhiều phần tử trong đó kết quả cuối cùng là phần tử gốc bị giảm bởi phần tử bị trừ','Thus, it is the digital handling of the image rather than the subtraction that is its main advantage.')

INSERT INTO Tu values ('Unique ',N' /juːˈniːk/','2','exclusive','common','')
INSERT INTO Nghia values ('45','3',N'Duy nhất',N'Duy nhất (unique) là chỉ có một, độc nhất, đơn nhất, vô song','If a value has a unique type, then there can be only one reference to it.')

INSERT INTO Tu values ('Vertical',N' /ˈvɝː.t̬ə.kəl/','2','','Horizontal ','')
INSERT INTO Nghia values ('46','3',N'Dọc, đường dọc',N'Phương thẳng đứng hướng lên ở góc 90 ° so với bề mặt hoặc đường nằm ngang','A table may be formed comparing vertical and horizontal dimensions as ratios.')

INSERT INTO Tu values ('Value',N'/ˈvæl.juː/','2','amount','disvalue','')
INSERT INTO Nghia values ('47','1',N'Giá trị',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','The symbolic evaluator implements a purely functional language which supports symbolic values.')
INSERT INTO Nghia values ('47','2',N'Đánh giá',N'Đánh giá là quá trình hình thành những nhận định, phân đoán về kết quả của công việc, dựa vào sự phân tích những thông tin thu được','He valued the painting at $2,000.')

INSERT INTO Tu values ('Project',N'/ˈprɑː.dʒekt/','2','program','','')
INSERT INTO Nghia values ('48','1',N'Đề án, dự án; kế hoạch',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','The work reported in this paper represents the first part of a two part research project.')
INSERT INTO Nghia values ('48','2',N'Dự kiến, đặt kế hoạch',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','They project (that) 31 billion people will watch the World Cup.')

INSERT INTO Tu values ('Develop',N'/dɪˈvel.əp/','2','grow','decline','')
INSERT INTO Nghia values ('49','2',N'Phát triển',N'Phát triển là quá trình vận động tiến lên từ thấp đến cao, từ chưa tốt đến hoàn hảo về mọi mặt.','He develops a constructive framework for proving equalities about programs')

INSERT INTO Tu values ('Sofware',N'/ˈsɑːft.wer/','2','program','','')
INSERT INTO Nghia values ('50','1',N'Phần mềm',N'Phần mềm là tập hợp các tập tin có mối liên hệ chặt chẽ với nhau, đảm bảo thực hiện các nhiệm vụ, chức năng trên thiết bị điện tử.','The development of various chess-playing software enabled the robot to play chess with people')

INSERT INTO Tu values ('Install',N'/ɪnˈstɑːl/','2','setup','uninstall','')
INSERT INTO Nghia values ('51','2',N'Thiết lập, cài đặt',N'Cài đặt một chương trình là việc đặt một chương trình vào một hệ thống máy tính sao cho nó có thể được thực thi.','How to install programs from online sources on Windows 10 ')

INSERT INTO Tu values ('Task',N'/tæsk/','2','job','','')
INSERT INTO Nghia values ('52','1',N'Tác vụ',N'Tác vụ là một công việc được thực hiện bên trong máy tính','Memory was included in the model because the four tasks all involved memory learning.')

INSERT INTO Tu values ('Problem',N'/ˈprɑː.bləm/','2','issue','solution','')
INSERT INTO Nghia values ('53','1',N'Vấn đề',N'Vấn đề là những điều cần được xem xét, nghiên cứu, giải quyết','These plans serve to identify possible problems and recognize ineffective designs.')

INSERT INTO Tu values ('Response',N'/rɪˈspɑːns/','2','reaction','','')
INSERT INTO Nghia values ('54','1',N'Phản hồi',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','She’s applied for admission and is still waiting for a response from the school.')

INSERT INTO Tu values ('Launch',N'/lɑːntʃ/','2','start','finish','')
INSERT INTO Nghia values ('55','1',N'Khởi chạy',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','This makes it possible to launch inference engines dynamically (on need) to avoid memory overload.')

INSERT INTO Tu values ('System',N'/ˈsɪs.təm/','2','','','')
INSERT INTO Nghia values ('56','1',N'Hệ thống',N'Hệ thống máy tính là một máy tính cơ bản, đầy đủ và có chức năng, bao gồm tất cả các phần cứng và phần mềm cần thiết để làm cho nó hoạt động','One is the difficulty with debugging different parts of multi-agent systems.')

INSERT INTO Tu values ('Information',N'/ˌɪn.fɚˈmeɪ.ʃən/','2','data','','')
INSERT INTO Nghia values ('57','1',N'Thông tin',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','Space is left above the stack for responses to requests for information such as types.')

INSERT INTO Tu values ('Issue',N'/ˈɪʃ.uː/','2','problem','solution','')
INSERT INTO Nghia values ('58','1',N'Vấn đề',N'Vấn đề là những điều cần được xem xét, nghiên cứu, giải quyết','Of course I''ll help you, there''s no need to make an issue of it.')

INSERT INTO Tu values ('Note',N'/noʊt/','2','comment','','')
INSERT INTO Nghia values ('59','1',N'Chú thích ',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','There''s a note on the door saying when the shop will open again.')
INSERT INTO Nghia values ('59','2',N'Ghi nhớ, ghi chú',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','Note also that the players hold correct beliefs about their own choices throughout.')

INSERT INTO Tu values ('Sum',N'/sʌm/','2','total','subtract','')
INSERT INTO Nghia values ('60','1',N'Tổng',N'Tổng là kết quả nhận được sau khi thực hiện phép cộng một dãy số','I worked for three whole weeks for which I received the princely sum of $100.')
INSERT INTO Nghia values ('60','2',N'Cộng',N'Cộng là một trong bốn phép tính cơ bản','A formula can be included at the end of a row to sum the numbers in that row.')

INSERT INTO Tu values ('Format',N'/ˈfɔːr.mæt/','2','','','')
INSERT INTO Nghia values ('61','1',N'Kiểu',N'Kiểu là những đặc trưng riêng, dễ nhận biết của một đối tượng, sự vật nào đó ','In order to have comparable formats, the results of that period are collapsed in one bar.')
INSERT INTO Nghia values ('61','2',N'Định dạng',N'Định dạng (văn bản) là thay đổi kiểu dáng, bố trí của các thành phần trong văn bản.','Here are some tips on how to format the document.')

INSERT INTO Tu values ('Order',N'/ˈɔːr.dɚ/','2','sequence','disorder','')
INSERT INTO Nghia values ('62','1',N'Mệnh lệnh',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','The company has received an order to stop releasing pollution into the air.')
INSERT INTO Nghia values ('62','2',N'Sắp xếp',N'Sắp xếp (dữ liệu) là hoán đổi vị trí các giá trị để chúng được xếp theo thứ tự tăng dần hoặc giảm dần','The documents have been ordered alphabetically.')

INSERT INTO Tu values ('Graphic',N'/ˈɡræf.ɪk/','2','illustration','','')
INSERT INTO Nghia values ('63','1',N'Hình ảnh',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','A graphic can also be printing shown on television')
INSERT INTO Nghia values ('63','3',N'(Thuộc) đồ thị, minh hoạ bằng đồ thị',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','Figure 6.2 provides a graphic representation of the key processes in the management of change.')

INSERT INTO Tu values ('Code',N'/koʊd/','2','','','')
INSERT INTO Nghia values ('64','1',N'Mã',N'Code được hiểu là những ngôn ngữ lập trình cơ bản mà những người lập trình sẽ sử dụng nó để đưa vào máy tính.','The problem was fixed with about 150 lines of computer code.')
INSERT INTO Nghia values ('64','2',N'Viết mã (chương trình)',N'Viết code là việc hướng dẫn cho máy tính biết các thao tác cần để thực hiện.','My third grade daughter loves learning to code with MIT''s amazing software.')

INSERT INTO Tu values ('Report',N'/rɪˈpɔːrt/','2','record','','')
INSERT INTO Nghia values ('65','1',N'Bản báo cáo',N'Bản báo cáo là một loại văn bản dùng để trình bày một sự việc hoặc các kết quả hoạt động','I gave/made/submitted a report of the theft to the insurance company.')
INSERT INTO Nghia values ('65','2',N'Báo cáo, tường trình',N'Báo cáo là việc trình bày một sự việc hoặc các kết quả hoạt động','I report for work at 8 a.m. every morning.')

INSERT INTO Tu values ('Base',N'/beɪs/','2','','','')
INSERT INTO Nghia values ('66','1',N'Cơ sở, nền tảng',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','The company, which has its base in California, plans to set up an office in Beijing.')
INSERT INTO Nghia values ('66','1',N'Hệ đếm',N'Hệ đếm là một tập các ký hiệu (chữ số, chữ cái) để biểu diễn các số và xác định giá trị của các biểu diễn số','A binary number is a number written in base 2, using the two numbers 0 and 1.')
INSERT INTO Nghia values ('66','2',N'Dựa vào, căn cứ vào',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','Where is your company based?')

INSERT INTO Tu values ('Work',N'/wɝːk/','2','task','','')
INSERT INTO Nghia values ('67','1',N'Công việc',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','What time do you start/finish work?')
INSERT INTO Nghia values ('67','2',N'Làm việc, hoạt động',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','The tablets will start to work in a few minutes.')
go
----------------------- Chuyên ngành khoa học dữ liệu
INSERT INTO Tu values ('Block',N'/blɑːk/','3','group','unit','')
INSERT INTO Nghia values ('68','1',N'Khối',N'Khối là tập hợp các mã nguồn được nhóm lại với nhau','In coding theory, block codes are a large and important family of error-correcting codes that encode data in blocks.')
INSERT INTO Nghia values ('68','2',N'Chặn',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','The new phone allows users to block messages from particular senders.')

INSERT INTO Tu values ('Migration',N'/maɪˈɡreɪ.ʃən/','3','relocation','immigration','')
INSERT INTO Nghia values ('69','1',N'Quá trình chuyển đổi',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','The processes must include accurate data migration.')

INSERT INTO Tu values ('Model',N'/ˈmɑː.dəl/','3','figure','','')
INSERT INTO Nghia values ('70','1',N'Mô hình',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','The architect showed us a model of the planned company.')

INSERT INTO Tu values ('Field',N'/fiːld/','3','area','','')
INSERT INTO Nghia values ('71','1',N'Trường',N'Trong khoa học máy tính, dữ liệu có nhiều phần, còn được gọi là một bản ghi, có thể được chia thành các trường','Field is a division of a database that contains a particular type of information.')

INSERT INTO Tu values ('Administration',N'/ədˌmɪn.əˈstreɪ.ʃən/','3','management','','')
INSERT INTO Nghia values ('72','1',N'Sự quản trị',N'Quản trị là quá trình tổ chức, điều khiển và kiểm soát công việc','Administration of the scheme is costly in terms of time.')

INSERT INTO Tu values ('Traffic',N'/ˈtræf.ɪk/','3','','','')
INSERT INTO Nghia values ('73','1',N'Lưu lượng',N'Lưu lượng là tốc độ truyền tải dữ liệu trong một giây','We can give you advice on how to improve your site traffic and generate sales.')

INSERT INTO Tu values ('Metadata',N'/ˈmet̬.əˌdeɪ.t̬ə/','3','','','')
INSERT INTO Nghia values ('74','1',N'Siêu dữ liệu',N'Siêu dữ liệu là những tóm tắt đặc tính cơ bản của dữ liệu. Từ đó hỗ trợ sử dụng và tái sử dụng dữ liệu một cách thuận lợi hơn.','Digital cameras can tag images with useful metadata.')

INSERT INTO Tu values ('Persistence',N'/pɚˈsɪs.təns/','3','','','')
INSERT INTO Nghia values ('75','1',N'Sự lưu, độ lưu',N'Tính chất của một đối tượng được lưu trữ vẫn tồn tại sau khi chương trình kết thúc','Persistence refers to the characteristic of state of a system that outlives the process that created it.')

INSERT INTO Tu values ('Queue',N'/kjuː/','3','','','')
INSERT INTO Nghia values ('76','1',N'Hàng đợi',N' Hàng đợi (queue) là một cấu trúc dữ liệu hoạt động theo cơ chế FIFO (First In First Out), tạm dịch là “vào trước ra trước”.','The speed of the total process requires a large number of parts to be queued between stages.')

INSERT INTO Tu values ('Random',N'/ˈræn.dəm/','3','arbitrary','orderly','')
INSERT INTO Nghia values ('77','3',N'Ngẫu nhiên',N'Ngẫu nhiên là việc chọn một cách ngẫu nhiên một trong số các đối tượng,  trong đó mỗi đối tượng đều có cơ hội được lựa chọn','The winning entry will be the first correct answer drawn at random.')

INSERT INTO Tu values ('Recovery',N'/rɪˈkʌv.ɚ.i/','3','rehabilitation','loss','')
INSERT INTO Nghia values ('78','1',N'Khôi phục',N'Khôi phục dữ liệu là quá trình sử dụng các thiết bị, phần mềm lấy lại các dữ liệu bị hư hỏng ','Use a recovery drive to restore or recover your PC')

INSERT INTO Tu values ('Relation',N'/rɪˈleɪ.ʃən/','3','relationship','','')
INSERT INTO Nghia values ('79','1',N'Quan hệ',N'Quan hệ tạo ra mối liên kết giữa hai bảng nhằm xác định mối liên quan giữa các trường dữ liệu của hai bảng','A relational database is a type of database that stores and provides access to data points that are related to one another.')

INSERT INTO Tu values ('Reverse',N'/rɪˈvɝːs/','3','invert','','')
INSERT INTO Nghia values ('80','2',N'Đảo ngược',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','There is no built-in reverse function in Python''s str object.')

INSERT INTO Tu values ('Secure',N'/səˈkjʊr/','3','protect','','')
INSERT INTO Nghia values ('81','3',N'Bảo vệ',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','Brave is arguably the most secure browser with simple, out-of-the-box privacy.')

INSERT INTO Tu values ('Snapshot',N'/ˈsnæp.ʃɑːt/','3','','','')
INSERT INTO Nghia values ('82','1',N'Trạng thái hệ thống ở một thời điểm nào đó',N'Snapshot cơ sở dữ liệu là một ảnh chụp nhanh dạng tĩnh, chỉ đọc (read-only) của một cơ sở dữ liệu SQL Server (cơ sở dữ liệu nguồn).','A snapshot preserves the state and data of a virtual machine at a specific point in time.')

INSERT INTO Tu values ('Stack',N'/stæk/','3','','','')
INSERT INTO Nghia values ('83','1',N'Ngăn xếp',N'Ngăn xếp là 1 dạng đặc biệt của danh sách liên kết mà việc bổ sung hay loại bỏ 1 phần tử đều thực hiện ở 1 đầu của danh sách gọi là đỉnh.','Stack is a container of objects that are inserted and removed according to the last-in first-out (LIFO) principle.')

INSERT INTO Tu values ('Trigger',N'/ˈtrɪɡ.ɚ/','3','activate','deactivate','')
INSERT INTO Nghia values ('84','1',N'Kích hoạt',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','A trigger is a special type of stored procedure that automatically runs when an event occurs.')

INSERT INTO Tu values ('Vulnerability',N'/ˌvʌl.nɚ.əˈbɪl.ə.t̬i/','3','weakness','invulnerability','')
INSERT INTO Nghia values ('85','1',N'Lỗ hổng bảo mật',N'Lỗ hổng bảo mật là khuyết điểm trong quá trình lập trình hoặc việc cấu hình sai hệ thống mà qua đó tạo ra sơ hở cho các kẻ tấn công mạng','Old approaches to vulnerability assessment no longer work.')

INSERT INTO Tu values ('Signal',N'/ˈsɪɡ.nəl/','3','','','')
INSERT INTO Nghia values ('86','1',N'Dấu hiệu',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','Signal processing is involved in picking up sounds in the environment, and processing them to enhance and amplify.')

INSERT INTO Tu values ('Chain',N'/tʃeɪn/','3','sequence','','')
INSERT INTO Nghia values ('87','1',N'Chuỗi',N'Chuỗi là một tập hợp các ký tự (char) được lưu trữ trên các ô nhớ liên tiếp và luôn luôn có 1 ký tự null là \0 báo hiệu kết thúc','A chain code is a lossless compression based image segmentation method for binary images.')

INSERT INTO Tu values ('Dimension',N'/ˌdaɪˈmen.ʃən/','3','','','')
INSERT INTO Nghia values ('88','1',N'Hướng',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','Dimensions describe data qualitatively, meaning they use words and characters.')

INSERT INTO Tu values ('Guarantee',N'/ˌɡer.ənˈtiː/','3','ensure','undermine','')
INSERT INTO Nghia values ('89','1',N'Bảo đảm',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','A guarantee is the promise included in the formal (and legal) warranty.')

INSERT INTO Tu values ('Individual ',N'/ˌɪn.dəˈvɪdʒ.u.əl/','3','personal','general','')
INSERT INTO Nghia values ('90','1',N'Cá nhân, cá thể',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','Individual means relating to one person or thing, rather than to a large group.')

INSERT INTO Tu values ('Establish ',N'/ɪˈstæb.lɪʃ/','3','found','terminate','')
INSERT INTO Nghia values ('91','2',N'Thiết lập',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','Learn what it means to establish data excellence and how it affects everyone in an organization')

INSERT INTO Tu values ('Permanent ',N'/ˈpɝː.mə.nənt/','3','eternal','Temporary','')
INSERT INTO Nghia values ('92','3',N'Vĩnh viễn',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','Permanent is computer data storage device that retains its data when the device is unpowered')

INSERT INTO Tu values ('Temporary',N'/ˈtem.pə.rer.i/','3','interim','Permanent ','')
INSERT INTO Nghia values ('93','3',N'Tạm thời',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','The term temporary storage area in a computer typically refers to a computer''s RAM.')

INSERT INTO Tu values ('Diverse',N'/dɪˈvɝːs/','3','varied','identical','')
INSERT INTO Nghia values ('94','3',N'Nhiều, đa dạng',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','Since identity itself is fluid and diverse, so too must be the range of support options on offer.')

INSERT INTO Tu values ('Sophisticated',N'/səˈfɪs.tə.keɪ.t̬ɪd/','3','Complex','simple','')
INSERT INTO Nghia values ('95','3',N'Phức tạp',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','I don''t think I have any books that would suit your sophisticated tastes.')

INSERT INTO Tu values ('Virtual',N'/ˈvɝː.tʃu.əl/','3','','real','')
INSERT INTO Nghia values ('96','3',N'Ảo',N'Ảo là không có thực, một tượng trưng máy tính của một thực thể nào đó.','In the game players simulate real life in a virtual world.')

INSERT INTO Tu values ('Compatible',N'/kəmˈpæt̬.ə.bəl/','3','cooperative','incompatible','')
INSERT INTO Nghia values ('97','3',N'Tương thích',N'Khả năng tương thích là khả năng để hai hệ thống làm việc cùng nhau mà không cần phải thay đổi.','Cross-browser compatibility is a commonly overlooked step when creating a new website.')

INSERT INTO Tu values ('Multiuser',N'/ˈmʌltiˌjuːzər/','3','','','')
INSERT INTO Nghia values ('98','1',N'Đa người dùng',N'Trong một hệ thống đa nhiệm người dùng, một người dùng có thể thực hiện nhiều tác vụ cùng một lúc.','Android supports multiuser on a single Android device.')

INSERT INTO Tu values ('Node',N'/noʊd/','3','','','')
INSERT INTO Nghia values ('99','1',N'Nút',N' Node là các nút giúp lưu trữ, truyền tải dữ liệu trong hệ thống các nút được liên kết với nhau.','A Node stores a value that can be of any data type and has a pointer to another node.')

INSERT INTO Tu values ('Research',N'/rɪˈsɝːtʃ/','3','investigation','','')
INSERT INTO Nghia values ('100','1',N'Nghiên cứu',N'Nghiên cứu là một quá trình thử nghiệm và trí tuệ bao gồm một tập hợp các phương pháp được áp dụng một cách có hệ thống.','The US government has funded some research on high-speed trains.')

INSERT INTO Tu values ('Irregularity',N'/ɪˌreɡ.jəˈler.ə.t̬i/','3','imperfection','','')
INSERT INTO Nghia values ('101','1',N'Bất thường, không theo quy tắc',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','The irregularity of English spelling means that it is easy to make mistakes')

INSERT INTO Tu values ('Algorithm',N'/ˈæl.ɡə.rɪ.ðəm/','3','','','')
INSERT INTO Nghia values ('102','1',N'Thuật toán',N'Thuật toán bao gồm các vấn đề về quy tắc, các chỉ thị, phương thức nhằm hoàn thành những tiêu chí, trạng thái ban đầu.','Music apps use algorithms to predict the probability that fans of one particular band will like another.')

INSERT INTO Tu values ('AI',N'/ˌeɪˈaɪ/','3','','','')
INSERT INTO Nghia values ('103','1',N'Trí tuệ được tăng cường',N'AI (Artificial intelligence) là trí thông minh được thể hiện bằng máy móc, trái ngược với trí thông minh tự nhiên của con người','The techniques of AI are becoming more important, both in industry and in pure research')

INSERT INTO Tu values ('Cloud computing',N'/ˌklaʊd kəmˈpjuː.t̬ɪŋ/','3','','','')
INSERT INTO Nghia values ('104','1',N'Điện toán đám mây',N'Điện toán đám mây cung cấp các công nghệ, tài nguyên máy tính liên kết với mạng Internet.','Google offers free word-processing and spreadsheet software over a browser.')

INSERT INTO Tu values ('Architecture',N'/ˈɑːr.kə.tek.tʃɚ/','3','structure','','')
INSERT INTO Nghia values ('105','1',N'Kiến trúc',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','Their software architecture is good and they continue to show good growth.')

INSERT INTO Tu values ('Data science',N'/ˈdeɪ.t̬ə ˌsaɪ.əns/','3','','','')
INSERT INTO Nghia values ('106','1',N'Khoa học dữ liệu',N'Khoa học dữ liệu là ngành khoa học về việc khai phá, quản trị và phân tích dữ liệu để dự đoán các xu hướng trong tương lai.','Political parties have started showing an interest in data science.')

INSERT INTO Tu values ('Analyse',N'/ˈæn.əl.aɪz/','3','investigate','','')
INSERT INTO Nghia values ('107','2',N'Phân tích',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','We are trying to analyse what went wrong in this program.')

INSERT INTO Tu values ('Database',N'/ˈdeɪ.t̬ə.beɪs/','3','','','')
INSERT INTO Nghia values ('108','1',N'Cơ sở dữ liệu',N'Cơ sở dữ liệu là một tập hợp các dữ liệu có tổ chức liên quan đến nhau, thường được lưu trữ và truy cập từ hệ thống máy tính.','It was his job to enter the information into the database.')

INSERT INTO Tu values ('Complex',N'/kɑːmˈpleks/','3','Sophisticated','simple','')
INSERT INTO Nghia values ('109','3',N'Phức tạp',N'(Hiện tại phần mềm từ điển tiếng Anh chuyên ngành của SHTeam chưa có mô tả về từ này)','A complex process is a system of separate series of events or relationships.')
-------------------------------------------------------------------------------------------------