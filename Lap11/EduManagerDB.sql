-- Lab 11 - ADO.NET va CRUD voi SQL Server
-- Database rieng cho Lab 11, khong lien quan Lab 10
-- (Neu may chua co EduManagerDB cua Lab 10, co the doi ten thanh EduManagerDB
--  o 4 cho: CREATE DATABASE, DB_ID, USE, va connection string trong FrmLop.cs)

IF DB_ID('EduManagerDB_Lab11') IS NULL
    CREATE DATABASE EduManagerDB_Lab11;
GO
USE EduManagerDB_Lab11;
GO

IF OBJECT_ID('SINHVIEN', 'U') IS NOT NULL DROP TABLE SINHVIEN;
IF OBJECT_ID('LOP', 'U') IS NOT NULL DROP TABLE LOP;
GO

CREATE TABLE LOP (
    MaLop VARCHAR(20) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL
);

CREATE TABLE SINHVIEN (
    MaSV VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    MaLop VARCHAR(20) NOT NULL,
    CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);
GO

INSERT INTO LOP(MaLop, TenLop) VALUES
('CNTT01', N'Công nghệ thông tin 01'),
('CNTT02', N'Công nghệ thông tin 02'),
('SPTIN01', N'Sư phạm Tin học 01');

INSERT INTO SINHVIEN(MaSV, HoTen, MaLop) VALUES
('SV001', N'Nguyễn Văn An', 'CNTT01'),
('SV002', N'Trần Thị Bình', 'CNTT01');
GO

SELECT * FROM LOP;
SELECT * FROM SINHVIEN;
GO