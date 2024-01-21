CREATE DATABASE QLPHIM
GO

USE QLPHIM
GO
-- CAU 1
CREATE TABLE PhimDienAnh
(
	MaPDA INT IDENTITY(1, 1) PRIMARY KEY,
	TenPDA NVARCHAR(30) NOT NULL UNIQUE
)
GO

CREATE TABLE DienVien
(
	MaDV INT IDENTITY(1, 1) PRIMARY KEY,
	HoTen NVARCHAR(30) NOT NULL,
	NgaySinh DATE CHECK (DATEDIFF(DAY, NgaySinh, GETDATE()) >= 365*18) 
)
GO

CREATE TABLE PhimDienAnhDienVien
(
	MaDV INT REFERENCES DienVien(MaDV),
	MaPDA INT REFERENCES PhimDienAnh(MaPDA),
	PRIMARY KEY(MaDV, MaPDA),
	ThuLao INT CHECK(ThuLao>=0),
	GhiChu NVARCHAR(100)
)
GO

-- CAU 2

CREATE VIEW vChiTietPhimDienAnh
AS
	SELECT DienVien.MaDV, DienVien.HoTen, PhimDienAnh.TenPDA, PhimDienAnhDienVien.ThuLao, PhimDienAnhDienVien.GhiChu
	FROM DienVien 
	JOIN PhimDienAnhDienVien ON DienVien.MaDV = PhimDienAnhDienVien.MaDV
	JOIN PhimDienAnh ON PhimDienAnhDienVien.MaPDA = PhimDienAnh.MaPDA;

--CAU 3

CREATE PROCEDURE spThemPhimDienAnh
@MaDV INT, @TenPDA NVARCHAR(30), @ThuLao INT, @GhiChu NVARCHAR(100)
AS BEGIN
	DECLARE @Check INT 
	SET @Check = (SELECT COUNT(*) FROM DienVien WHERE MaDV = @MaDV)
	IF @Check = 0
	BEGIN
		PRINT 'Mã diễn viên không tôn tại'
		RETURN
	END
	SET @Check = (SELECT COUNT(*) FROM PhimDienAnh WHERE TenPDA = @TenPDA)
	IF @Check = 0
	BEGIN
		PRINT 'Tên phim điện ảnh không tồn tại'
		RETURN
	END

	IF @ThuLao < 0
	BEGIN
		PRINT 'Thu lao không hợp lệ'
		RETURN
	END
	SET @Check = (SELECT COUNT(*) FROM PhimDienAnhDienVien WHERE MaDV = @MaDV AND MaPDA = (SELECT MaPDA FROM PhimDienAnh WHERE TenPDA = @TenPDA))
	IF @Check = 1
	BEGIN
		PRINT 'Diễn viên này và phim này đã được lưu trữ'
		RETURN
	END

	INSERT PhimDienAnhDienVien(MaDV, MaPDA, ThuLao, GhiChu) VALUES
	(@MaDV, (SELECT MaPDA FROM PhimDienAnh WHERE TenPDA = @TenPDA), @ThuLao, @GhiChu)
	PRINT 'Thêm thành công'
END;

-- CAU 4

CREATE FUNCTION TimKiemPhimDienAnh(@MaPDA INT, @TenPDA NVARCHAR(30))
RETURNS TABLE
AS RETURN 
(
	SELECT * FROM PhimDienAnh
	WHERE (@MaPDA IS NULL OR MaPDA = @MaPDA) AND
	(@TenPDA IS NULL OR TenPDA LIKE '%' + @TenPDA + '%')
);