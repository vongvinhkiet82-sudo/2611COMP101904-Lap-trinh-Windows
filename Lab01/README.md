# Lab 01 - Ứng dụng Thông tin cá nhân
## 1. Mô tả
Ứng dụng Windows Forms cho phép nhập thông tin cá nhân sinh viên (họ tên, năm sinh,
email, giới tính, khoa/lớp), kiểm tra tính hợp lệ của dữ liệu, tính tuổi và hiển thị
kết quả tổng hợp. Có chức năng Xóa dữ liệu và Thoát chương trình (có xác nhận).

## 2. Công nghệ sử dụng
- C# Windows Forms
- .NET 8

## 3. Danh sách control chính

| Control      | Tên biến    | Chức năng                |
|--------------|-------------|--------------------------|
| TextBox      | txtHoTen    | Nhập họ tên              |
| TextBox      | txtNamSinh  | Nhập năm sinh            |
| TextBox      | txtEmail    | Nhập email               |
| RadioButton  | radNam/radNu| Chọn giới tính           |
| ComboBox     | cboKhoa     | Chọn khoa/lớp            |
| Button       | btnHienThi  | Hiển thị kết quả         |
| Button       | btnXoa      | Xóa dữ liệu đã nhập      |
| Button       | btnThoat    | Thoát chương trình       |
| TextBox      | txtKetQua   | Hiển thị kết quả tổng hợp|

## 4. Kiểm tra dữ liệu đầu vào
- Họ tên không được rỗng.
- Năm sinh không được rỗng, phải là số nguyên, trong khoảng 1900 - năm hiện tại.
- Email không được rỗng, phải đúng định dạng email.
- Phải chọn giới tính.
- Phải chọn khoa/lớp.

## 5. Hình ảnh kết quả

### 5.1 Giao diện khi mở chương trình

![Giao diện ban đầu](images/giao-dien-khi-mo.png)

### 5.2 Kết quả khi nhập dữ liệu hợp lệ

![Kết quả hợp lệ](images/giao-dien-hop-le.png)

### 5.3 Thông báo khi thiếu tên

![Thiếu tên](images/Ktra-hoten.png)

### 5.4 Thông báo khi thiếu tuổi và sai tuổi

![Thiếu tuổi](images/Ktra-namsinh.png)
![Sai tuổi](images/Ktra-namsinh2.png)

### 5.5 Thông báo khi thiếu email và sai email

![Thiếu email](images/ktra-email.png)
![Sai email](images/ktra-email2.png)

### 5.6 Thông báo khi thiếu giới tính

![Thiếu giới tính](images/ktra-gioitinh.png)

### 5.7 Thông báo khi thiếu khoa/lớp

![Thiếu khoa/lớp](images/ktra-khoa.png)
### 5.8 Xác nhận Thoát

![Xác nhận thoát](images/giao-dien-thoat.png)

## 6. Ghi chú
- Chương trình đã được kiểm tra và chạy đúng theo yêu cầu đề bài.
