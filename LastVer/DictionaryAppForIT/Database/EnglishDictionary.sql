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
-- Thêm từ và nghĩa
-- INSERT INTO Tu values ('TenTu', N'PhienAm', 'ChuyenNganh', 'DongNghia', 'TraiNghia', '')-- idtk = 0
-- INSERT INTO Nghia values ('IDTu', 'IDTuLoai', N'Nghia', N'MoTa', 'ViDu')
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

--INSERT INTO Tu values ('TenTu', N'PhienAm', 'ChuyenNganh', 'DongNghia', 'TraiNghia', '')-- idtk = 0
--INSERT INTO Nghia values ('IDTu', 'IDTuLoai', N'Nghia', N'MoTa', 'ViDu')