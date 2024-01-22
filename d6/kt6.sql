CREATE DATABASE CC
GO

USE CC
GO

CREATE TABLE ChungChi
(
	MaChungChi INT IDENTITY(1, 1) PRIMARY KEY,
	TenChungChi NVARCHAR(30) NOT NULL UNIQUE,
	ThoiHan INT CHECK(ThoiHan > 0)
)
GO

CREATE TABLE NgoaiNgu
(
	MaNgoaiNgu INT IDENTITY(1, 1) PRIMARY KEY,
	TenNgoaiNgu NVARCHAR(30) NOT NULL UNIQUE,
)
GO

CREATE TABLE NhanVien
(
	MaNhanVien INT IDENTITY(1, 1) PRIMARY KEY,
	HoTen NVARCHAR(30) NOT NULL,
	DienThoai VARCHAR(10) NOT NULL
)
GO

CREATE TABLE NgoaiNguNhanVien
(
	MaNhanVien INT REFERENCES NhanVien(MaNhanVien),
	MaNgoaiNgu INT REFERENCES NgoaiNgu(MaNgoaiNgu),
	MaChungChi INT REFERENCES ChungChi(MaChungChi),
	PRIMARY KEY(MaNhanVien, MaNgoaiNgu, MaChungChi),
	NgayCap DATE NOT NULL
)
GO

-- CAU 2

CREATE VIEW vChiTietNgoaiNguNhanVien
AS
	SELECT NhanVien.MaNhanVien, NhanVien.HoTen, NgoaiNgu.TenNgoaiNgu, ChungChi.TenChungChi, NgoaiNguNhanVien.NgayCap
	FROM NhanVien 
	JOIN NgoaiNguNhanVien ON NhanVien.MaNhanVien = NgoaiNguNhanVien.MaNhanVien
	JOIN ChungChi ON NgoaiNguNhanVien.MaChungChi = ChungChi.MaChungChi
	JOIN NgoaiNgu ON NgoaiNguNhanVien.MaNgoaiNgu = NgoaiNgu.MaNgoaiNgu
GO

-- CAU 3

CREATE PROCEDURE spThemChungChi
@TenChungChi NVARCHAR(30), @ThoiHan INT
AS BEGIN
	DECLARE @Check INT
	SET @Check = (SELECT COUNT(*) FROM ChungChi WHERE TenChungChi = @TenChungChi)
	IF @Check = 1
	BEGIN
		PRINT 'Chứng chỉ bị trùng'
		RETURN
	END
	INSERT ChungChi(TenChungChi, ThoiHan) VALUES
	(@TenChungChi, @ThoiHan)
	PRINT 'Thêm thành công'
END
GO

-- CAU 4

CREATE FUNCTION TimKiemNhanVien(@MaNV INT, @HoTen NVARCHAR(30), @DienThoai INT)
RETURNS TABLE
AS RETURN
(
	SELECT * FROM NhanVien WHERE (@MaNV IS NULL OR MaNhanVien = @MaNV)
	AND (@HoTen IS NULL OR HoTen LIKE '%'+ @HoTen + '%')
	AND (@DienThoai IS NULL OR DienThoai = @DienThoai)
)
GO
