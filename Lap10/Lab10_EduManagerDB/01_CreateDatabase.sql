USE master;
GO
IF DB_ID('EduManagerDB') IS NOT NULL
    ALTER DATABASE EduManagerDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE; -- đóng mọi kết nối cũ
GO
DROP DATABASE IF EXISTS EduManagerDB;
GO
CREATE DATABASE EduManagerDB;
GO
USE EduManagerDB;
GO

-- Bảng KHOA
CREATE TABLE KHOA (
    MaKhoa    VARCHAR(20)   PRIMARY KEY,          -- khóa chính
    TenKhoa   NVARCHAR(100) NOT NULL,
    DienThoai VARCHAR(15)   NULL
);
GO

-- Bảng LOP: mỗi lớp thuộc một khoa
CREATE TABLE LOP (
    MaLop  VARCHAR(20)   PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL,
    MaKhoa VARCHAR(20)   NOT NULL,
    CONSTRAINT FK_LOP_KHOA FOREIGN KEY (MaKhoa) REFERENCES KHOA(MaKhoa)
);
GO

-- Bảng SINHVIEN: mỗi sinh viên thuộc một lớp
CREATE TABLE SINHVIEN (
    MaSV     VARCHAR(20)   PRIMARY KEY,
    HoTen    NVARCHAR(100) NOT NULL,
    NgaySinh DATE          NULL,
    GioiTinh NVARCHAR(10)  NOT NULL,
    MaLop    VARCHAR(20)   NOT NULL,
    CONSTRAINT CK_SINHVIEN_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ')),   -- chỉ nhận Nam/Nữ
    CONSTRAINT FK_SINHVIEN_LOP FOREIGN KEY (MaLop) REFERENCES LOP(MaLop)
);
GO

-- Bảng MONHOC
CREATE TABLE MONHOC (
    MaMH     VARCHAR(20)   PRIMARY KEY,
    TenMH    NVARCHAR(100) NOT NULL,
    SoTinChi INT           NOT NULL,
    CONSTRAINT CK_MONHOC_SoTinChi CHECK (SoTinChi > 0)                    -- tín chỉ > 0
);
GO

-- Bảng KETQUA: khóa chính ghép (MaSV, MaMH) -> 1 SV chỉ có 1 điểm/môn
CREATE TABLE KETQUA (
    MaSV VARCHAR(20)  NOT NULL,
    MaMH VARCHAR(20)  NOT NULL,
    Diem DECIMAL(4,2) NOT NULL,
    CONSTRAINT PK_KETQUA PRIMARY KEY (MaSV, MaMH),
    CONSTRAINT CK_KETQUA_Diem CHECK (Diem BETWEEN 0 AND 10),              -- điểm 0..10
    CONSTRAINT FK_KETQUA_SINHVIEN FOREIGN KEY (MaSV) REFERENCES SINHVIEN(MaSV),
    CONSTRAINT FK_KETQUA_MONHOC   FOREIGN KEY (MaMH) REFERENCES MONHOC(MaMH)
);
GO

-- Bảng TAIKHOAN: tài khoản đăng nhập demo
CREATE TABLE TAIKHOAN (
    TenDangNhap VARCHAR(50)   PRIMARY KEY,
    MatKhau     VARCHAR(100)  NOT NULL,
    HoTen       NVARCHAR(100) NOT NULL,
    VaiTro      VARCHAR(20)   NOT NULL DEFAULT 'User',
    TrangThai   BIT           NOT NULL DEFAULT 1
);
GO

-- Kiểm tra: liệt kê các bảng vừa tạo (phải có 6 bảng)
SELECT name AS TenBang FROM sys.tables ORDER BY name;
GO
