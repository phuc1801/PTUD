CREATE DATABASE NN
GO

USE NN
GO

-- CAU 1
CREATE TABLE NgoaiNgu
(
	MaNgoaiNgu INT IDENTITY(1, 1) PRIMARY KEY,
	TenNgoaiNgu NVARCHAR(30) NOT NULL UNIQUE
)
GO

CREATE TABLE NhanVien
(
	MaNhanVien INT IDENTITY(1, 1) PRIMARY KEY,
	HoTen NVARCHAR(30) NOT NULL, 
	NgaySinh DATE CHECK(DATEDIFF(DAY, NgaySinh, GETDATE())>= 365*18)
)
GO

CREATE TABLE NgoaiNguNhanVien
(
	MaNhanVien INT REFERENCES NhanVien(MaNhanVien),
	MaNgoaiNgu INT REFERENCES NgoaiNgu(MaNgoaiNgu),
	PRIMARY KEY(MaNhanVien, MaNgoaiNgu),
	GhiChu NVARCHAR(100)
)
GO

-- CAU 2
CREATE VIEW vChiTietNgoaiNguNhanVien
AS
	SELECT NhanVien.MaNhanVien, NhanVien.HoTen, NgoaiNgu.TenNgoaiNgu, NgoaiNguNhanVien.GhiChu
	FROM NhanVien 
	JOIN NgoaiNguNhanVien ON NhanVien.MaNhanVien = NgoaiNguNhanVien.MaNhanVien
	JOIN NgoaiNgu ON NgoaiNguNhanVien.MaNgoaiNgu = NgoaiNgu.MaNgoaiNgu
GO

-- CAU 3

CREATE PROCEDURE spThemNgoaiNguNhanVien
@MaNV INT, @TenNN NVARCHAR(30), @GhiChu NVARCHAR(100)
AS BEGIN
	DECLARE @Check INT
	SET @Check = (SELECT COUNT(*) FROM NhanVien WHERE MaNhanVien = @MaNV)
	IF @Check = 0
	BEGIN
		PRINT 'Mã nhân viên không tồn tại'
		RETURN
	END

	SET @Check = (SELECT COUNT(*) FROM NgoaiNgu WHERE TenNgoaiNgu = @TenNN)
	IF @Check = 0
	BEGIN
		PRINT 'Tên ngoại ngữ không tồn tại'
		RETURN
	END

	SET @Check = (SELECT COUNT(*) FROM NgoaiNguNhanVien 
	WHERE MaNhanVien = @MaNV AND MaNgoaiNgu = (SELECT MaNgoaiNgu FROM NgoaiNgu WHERE TenNgoaiNgu = @TenNN))
	IF @Check = 1
	BEGIN
		PRINT 'Nhân Viên này và ngoại ngữ này đã được lưu trữ'
		RETURN
	END

	INSERT NgoaiNguNhanVien VALUES
	(@MaNV, (SELECT MaNgoaiNgu FROM NgoaiNgu WHERE TenNgoaiNgu = @TenNN), @GhiChu)
END;
GO

-- CAU 4

CREATE FUNCTION TimKiemNgoaiNgu(@MaNN INT, @TenNN NVARCHAR(30))
RETURNS TABLE
AS RETURN
(
	SELECT * FROM NgoaiNgu 
	WHERE (@MaNN IS NULL OR MaNgoaiNgu = @MaNN) AND (@TenNN IS NULL OR TenNgoaiNgu LIKE '%' + @TenNN + '%') 
);