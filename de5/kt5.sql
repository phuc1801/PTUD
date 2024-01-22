CREATE DATABASE K
GO

USE K
GO

CREATE TABLE Kho
(
	MaKho INT IDENTITY(1, 1) PRIMARY KEY,
	TenKho NVARCHAR(30) NOT NULL UNIQUE
)
GO

CREATE TABLE DonViTinh
(
	MaDonViTinh INT IDENTITY(1, 1) PRIMARY KEY,
	TenDonViTinh NVARCHAR(30) NOT NULL UNIQUE,
)
GO

CREATE TABLE HangHoa
(
	MaHangHoa INT IDENTITY(1, 1) PRIMARY KEY,
	TenHangHoa NVARCHAR(30) NOT NULL UNIQUE,
	MaDonViTinh INT REFERENCES DonViTinh(MaDonViTinh),
	GhiChu NVARCHAR(100) NOT NULL
)
GO

CREATE TABLE LuuKho
(
	MaHangHoa INT REFERENCES HangHoa(MaHangHoa),
	MaKho INT REFERENCES Kho(MaKho),
	PRIMARY KEY(MaHangHoa, MaKho),
	SoLuong FLOAT CHECK(SoLuong >= 0)
)
GO
-- CAU 2

CREATE VIEW vChiTietLuuKho
AS
	SELECT HangHoa.MaHangHoa, HangHoa.TenHangHoa, DonViTinh.TenDonViTinh, Kho.TenKho, LuuKho.SoLuong
	FROM HangHoa 
	JOIN LuuKho ON HangHoa.MaHangHoa = LuuKho.MaHangHoa
	JOIN Kho ON LuuKho.MaKho = Kho.MaKho
	JOIN DonViTinh ON HangHoa.MaDonViTinh = DonViTinh.MaDonViTinh
GO

-- CAU 3

CREATE PROCEDURE spThemHangHoa
@TenHH NVARCHAR(30), @TenKho NVARCHAR(30), @SoLuong FLOAT
AS BEGIN
	DECLARE @Check INT
	SET @Check = (SELECT COUNT(*) FROM HangHoa WHERE TenHangHoa = @TenHH)
	IF @Check = 1
	BEGIN
		PRINT 'Hàng hoá đã bị trùng!'
		RETURN
	END

	SET @Check = (SELECT COUNT(*) FROM DonViTinh 
	WHERE TenDonViTinh = (SELECT DonViTinh.TenDonViTinh FROM LuuKho
	JOIN HangHoa ON LuuKho.MaHangHoa = HangHoa.MaHangHoa
	JOIN DonViTinh ON HangHoa.MaDonViTinh = DonViTinh.MaDonViTinh))
	IF @Check = 0
	BEGIN
		PRINT 'Đơn vị tính không tồn tại!'
		RETURN
	END

	INSERT HangHoa(TenHangHoa, MaDonViTinh, GhiChu) VALUES
	(
	 @TenHH, 
	 (SELECT DonViTinh.MaDonViTinh FROM LuuKho
	 JOIN HangHoa ON LuuKho.MaHangHoa = HangHoa.MaHangHoa
	 JOIN DonViTinh ON HangHoa.MaDonViTinh = DonViTinh.MaDonViTinh),
	 (Select HangHoa.GhiChu FROM HangHoa WHERE TenHangHoa = @TenHH)
	)
END
GO

-- CAU 4
CREATE FUNCTION TimKiemLuuKho(@TenHH NVARCHAR(30), @TenKho NVARCHAR(30), @SoLuong FLOAT)
RETURNS TABLE
AS RETURN
(
	SELECT HangHoa.TenHangHoa, Kho.TenKho, LuuKho.SoLuong 
	FROM HangHoa
	JOIN LuuKho ON HangHoa.MaHangHoa = LuuKho.MaHangHoa
	JOIN Kho ON LuuKho.MaKho = Kho.MaKho
	WHERE (@TenHH IS NULL OR HangHoa.TenHangHoa = @TenHH) 
	AND (@TenKho IS NULL OR Kho.TenKho = @TenKho)
	AND (@SoLuong IS NULL OR LuuKho.SoLuong = @SoLuong)
)