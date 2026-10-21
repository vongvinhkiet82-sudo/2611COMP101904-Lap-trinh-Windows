# Lab 10 - Thiết kế và cài đặt CSDL EduManagerDB (SQL Server)

## 1. Giới thiệu
CSDL `EduManagerDB` phục vụ ứng dụng quản lý sinh viên, gồm: khoa, lớp, sinh viên, môn học, kết quả học tập và tài khoản đăng nhập.

## 2. Các bảng và quan hệ
| Bảng | Khóa chính | Khóa ngoại | Ghi chú |
|---|---|---|---|
| KHOA | MaKhoa | - | Thông tin khoa |
| LOP | MaLop | MaKhoa -> KHOA | Mỗi lớp thuộc một khoa |
| SINHVIEN | MaSV | MaLop -> LOP | Mỗi sinh viên thuộc một lớp |
| MONHOC | MaMH | - | Thông tin môn học |
| KETQUA | (MaSV, MaMH) | MaSV -> SINHVIEN, MaMH -> MONHOC | Điểm theo môn |
| TAIKHOAN | TenDangNhap | - | Tài khoản demo |

## 3. Ràng buộc đã cài đặt
- `KETQUA.Diem` thuộc [0, 10] (CHECK).
- `SINHVIEN.GioiTinh` chỉ nhận `Nam` hoặc `Nữ` (CHECK).
- `MONHOC.SoTinChi` > 0 (CHECK).
- Khóa ngoại LOP->KHOA, SINHVIEN->LOP, KETQUA->SINHVIEN/MONHOC.
- Khóa chính ghép (MaSV, MaMH) ở KETQUA: không nhập trùng điểm.

## 4. Cách chạy
1. Chạy `01_CreateDatabase.sql` (tạo database và bảng).
2. Chạy `02_InsertSampleData.sql` (nhập dữ liệu mẫu).
3. Chạy `03_Queries.sql` (bôi đen và chạy từng câu).

## 5. Dữ liệu mẫu
2 khoa, 3 lớp, 7 sinh viên, 4 môn học, 8 kết quả, 2 tài khoản.

## 6. Kết quả kiểm thử
- Thêm sinh viên vào lớp `CNTT99` (không tồn tại): bị chặn bởi FOREIGN KEY.
- Nhập điểm 12: bị chặn bởi CHECK.

## 7. Ảnh chụp kết quả

### 6 bảng trong Object Explorer

![Bảng trong OE](images/Bang.png)

### Số dòng từng bảng

![Số dòng](images/So-dong.png)

### 1. Toàn bộ sinh viên

![Toàn bộ sinh viên](images/Toan-bo-sinh-vien.png)

### 2. Liệt kê sinh viên kèm tên lớp và tên khoa

![Liệt kê sinh viên-lớp-khoa](images/Sinh-vien-lop-khoa.png)

### 3. Tìm sinh viên theo một phần họ tên bằng LIKE

![Tìm sinh viên](images/Tim-sinh-vien-like.png)

### 4. Liệt kê sinh viên theo mã lớp

![Liệt kê sinh viên theo mã lớp](images/Sinh-vien-theo-ma-lop.png)

### 5. Cập nhật họ tên hoặc lớp của một sinh viên

![Cập nhật sinh viên](images/Cap-nhat-sinh-vien.png)

### 6. Xóa một sinh viên chưa có dữ liệu điểm

![Xóa sinh viên](images/Xoa-sinh-vien-chua-co-diem.png)

### 7. Liệt kê điểm của từng sinh viên theo từng môn

![Liệt kê điểm](images/Diem-sinh-vien-theo-mon.png)

### 8. Tính điểm trung bình của từng sinh viên

![Tính điểm trung bình](images/Diem-trung-binh.png)

### 9. Thống kê số sinh viên theo từng lớp

![Thống kê số sinh viên](images/Thong-ke-sv-theo-lop.png)

### 10. Liệt kê các lớp có từ 2 sinh viên trở lên

![Liệt kê các lớp](images/Lop-tu-2-sv-tro-len.png)

### 11. Test lỗi khi thêm sinh viên vào lớp không tồn tại

![Test lỗi khi thêm sinh viên vào lớp không tồn tại](images/Test-loi-khoa-ngoai.png)

### 12. Test lỗi khi nhập điểm ngoài khoảng 0 đến 10

![Test lỗi khi nhập điểm ngoài khoảng 0 đến 10](images/Test-loi-check-diem.png)
