USE EduManagerDB;
GO

-- 1. Liệt kê toàn bộ sinh viên
SELECT MaSV, HoTen, NgaySinh, GioiTinh, MaLop
FROM SINHVIEN;

-- 2. Sinh viên kèm tên lớp và tên khoa (JOIN 3 bảng)
SELECT sv.MaSV, sv.HoTen, l.TenLop, k.TenKhoa
FROM SINHVIEN sv
INNER JOIN LOP  l ON sv.MaLop = l.MaLop
INNER JOIN KHOA k ON l.MaKhoa = k.MaKhoa;

-- 3. Tìm sinh viên theo một phần họ tên (LIKE)
SELECT MaSV, HoTen, MaLop
FROM SINHVIEN
WHERE HoTen LIKE N'%An%'
ORDER BY HoTen;

-- 4. Liệt kê sinh viên theo mã lớp
SELECT MaSV, HoTen, GioiTinh
FROM SINHVIEN
WHERE MaLop = 'CNTT01';

-- 5. Cập nhật họ tên (luôn có WHERE)
UPDATE SINHVIEN
SET HoTen = N'Nguyễn Văn An (đã sửa)'
WHERE MaSV = 'SV001';
-- Cập nhật lớp (tùy chọn):
-- UPDATE SINHVIEN SET MaLop = 'CNTT02' WHERE MaSV = 'SV001';
SELECT MaSV, HoTen, MaLop FROM SINHVIEN WHERE MaSV = 'SV001';   -- xem lại kết quả

-- 6. Xóa sinh viên chưa có điểm (SV007)
DELETE FROM SINHVIEN
WHERE MaSV = 'SV007'
  AND NOT EXISTS (SELECT 1 FROM KETQUA WHERE MaSV = 'SV007');
SELECT MaSV, HoTen FROM SINHVIEN;                               -- SV007 phải biến mất

-- 7. Điểm của từng sinh viên theo từng môn
SELECT sv.MaSV, sv.HoTen, mh.TenMH, kq.Diem
FROM KETQUA kq
INNER JOIN SINHVIEN sv ON kq.MaSV = sv.MaSV
INNER JOIN MONHOC   mh ON kq.MaMH = mh.MaMH
ORDER BY sv.MaSV, mh.TenMH;

-- 8. Điểm trung bình của từng sinh viên
SELECT sv.MaSV, sv.HoTen, AVG(kq.Diem) AS DiemTrungBinh
FROM SINHVIEN sv
INNER JOIN KETQUA kq ON sv.MaSV = kq.MaSV
GROUP BY sv.MaSV, sv.HoTen;

-- 9. Số sinh viên theo từng lớp
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop;

-- 10. Các lớp có từ 2 sinh viên trở lên
SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
FROM LOP l
LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
GROUP BY l.MaLop, l.TenLop
HAVING COUNT(sv.MaSV) >= 2;

-- 11. TEST LỖI: thêm sinh viên vào lớp không tồn tại
-- Kết quả đúng: báo lỗi FOREIGN KEY (FK_SINHVIEN_LOP)
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
VALUES ('SV999', N'Sinh viên lỗi', '2005-01-01', N'Nam', 'CNTT99');

-- 12. TEST LỖI: nhập điểm ngoài khoảng 0-10
-- Kết quả đúng: báo lỗi CHECK (CK_KETQUA_Diem)
INSERT INTO KETQUA (MaSV, MaMH, Diem)
VALUES ('SV003', 'COMP1020', 12);