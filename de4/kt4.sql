CREATE DATABASE HH
GO

USE HH
GO
-- CAU 1
CREATE TABLE LoaiHang
(
	MaLoaiHang INT IDENTITY(1, 1) PRIMARY KEY,
	TenLoaiHang NVARCHAR(30) NOT NULL UNIQUE
)
GO

CREATE TABLE HangHoa
(
	MaHangHoa INT IDENTITY(1, 1) PRIMARY KEY,
	TenHangHoa NVARCHAR(30) NOT NULL UNIQUE,
	MaLoaiHang INT REFERENCES LoaiHang(MaLoaiHang)
)
GO

CREATE TABLE NhaCungCap
(
	MaNhaCungCap INT IDENTITY(1, 1) PRIMARY KEY,
	HoTen NVARCHAR(30) NOT NULL,
	DiaChi NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE HangHoaNhaCungCap
(
	MaNhaCungCap INT REFERENCES NhaCungCap(MaNhaCungCap),
	MaHangHoa INT REFERENCES HangHoa(MaHangHoa),
	PRIMARY KEY(MaNhaCungCap, MaHangHoa),
	GhiChu NVARCHAR(100)
)
GO

-- CAU 2

CREATE VIEW vChiTietHangHoaNhaCungCap
AS 
	SELECT NhaCungCap.MaNhaCungCap, NhaCungCap.HoTen, HangHoa.TenHangHoa, LoaiHang.TenLoaiHang
	FROM NhaCungCap
	JOIN HangHoaNhaCungCap ON NhaCungCap.MaNhaCungCap = HangHoaNhaCungCap.MaNhaCungCap
	JOIN HangHoa ON HangHoaNhaCungCap.MaHangHoa = HangHoa.MaHangHoa
	JOIN LoaiHang ON HangHoa.MaLoaiHang = LoaiHang.MaLoaiHang
GO

-- CAU 3
CREATE PROCEDURE spThemHangHoaNhaCungCap
@MaNCC INT, @MaHH INT, @GhiChu NVARCHAR(100)
AS BEGIN
	DECLARE @Check INT
	SET @Check = (SELECT COUNT(*) FROM NhaCungCap WHERE MaNhaCungCap = @MaNCC)
	IF @Check = 0
	BEGIN
		PRINT 'Mã nhà cung cấp không tồn tại'
		RETURN
	END

	SET @Check = (SELECT COUNT(*) FROM HangHoa WHERE MaHangHoa = @MaHH)
	IF @Check = 0
	BEGIN
		PRINT 'Mã hàng hoá cấp không tồn tại'
		RETURN
	END

	SET @Check = (SELECT COUNT(*) FROM HangHoaNhaCungCap  WHERE MaNhaCungCap = @MaNCC AND MaHangHoa = @MaHH)
	IF @Check = 1
	BEGIN
		PRINT 'Nhà cung cấp và mã hàng hoá đã được lưu trữ'
		RETURN
	END
	INSERT HangHoaNhaCungCap VALUES
	(@MaNCC, @MaHH, @GhiChu)
	PRINT 'Thêm thành công'
END;
GO

-- CAU 4

CREATE FUNCTION TimKiemHangHoa(@MaHH INT, @TenHangHoa NVARCHAR(30), @TenLoaiHang NVARCHAR(30))
RETURNS TABLE
AS RETURN 
(
    SELECT HangHoa.MaHangHoa, HangHoa.TenHangHoa, LoaiHang.MaLoaiHang, LoaiHang.TenLoaiHang
	FROM HangHoa JOIN LoaiHang ON HangHoa.MaLoaiHang = LoaiHang.MaLoaiHang
    WHERE (@MaHH IS NULL OR HangHoa.MaHangHoa = @MaHH) 
    AND (@TenHangHoa IS NULL OR HangHoa.TenHangHoa LIKE '%' + @TenHangHoa + '%')
    AND (@TenLoaiHang IS NULL OR LoaiHang.TenLoaiHang LIKE '%' + @TenLoaiHang + '%')
)
GO
