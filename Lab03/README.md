# Lab 03 - Quản lý sinh viên bằng Console (COMP1019)

Chương trình Console C# quản lý sinh viên theo hướng đối tượng, lưu dữ liệu trong `List<SinhVien>`.

## Cấu trúc

```
Lab03_QuanLySinhVienOOP
|-- Nguoi.cs              // class cha: HoTen, NgaySinh, LayThongTin() virtual
|-- SinhVien.cs           // kế thừa Nguoi: MaSinhVien, MaLop, DiemTrungBinh (0-10), XepLoai()
|-- QuanLySinhVien.cs     // service: Them, Sua, Xoa, TimTheoMa, TimTheoTen, SapXepTheoDiem, LayDanhSach
|-- Program.cs            // menu + các hàm nhập liệu an toàn
```

## Công nghệ sử dụng

- - C# Windows Forms
- .NET 

## Đối chiếu yêu cầu

| Yêu cầu | Nơi thể hiện |
|---|---|
| Class, property, constructor | `Nguoi`, `SinhVien` đều có constructor mặc định và đầy đủ |
| Kế thừa + override | `SinhVien : Nguoi`, override `LayThongTin()` |
| Property kiểm tra dữ liệu | Setter của `DiemTrungBinh` chỉ nhận 0–10, ném `ArgumentOutOfRangeException` |
| `List<SinhVien>` | Field `_danhSach` trong `QuanLySinhVien`, `private readonly`, Main không đụng trực tiếp |
| LINQ | `Any`, `FirstOrDefault`, `Where`, `OrderByDescending`, `Average` trong `QuanLySinhVien` |
| Không crash khi nhập sai | `NhapChuoi`, `NhapDiem`, `NhapNgay` dùng `TryParse` và lặp lại đến khi hợp lệ |
| Tách hàm | Mỗi chức năng menu là một method riêng trong `Program` |

## Quy ước xếp loại

| Điểm | Xếp loại |
|---|---|
| >= 9 | Xuất sắc |
| >= 8 | Giỏi |
| >= 6.5 | Khá |
| >= 5 | Trung bình |
| < 5 | Yếu |

Sinh viên "đạt" = điểm trung bình >= 5.

## Hình ảnh kết quả

### Menu 

![Menu](images/menu.png)
![Danh sách ban đầu](images/danh-sach-ban-dau.png)

### Thêm sinh viên

![Thêm sinh viên](images/them-sinh-vien.png)

#### Lỗi trùng mã
![Lỗi trùng mã](images/loi-trung-ma.png)

#### Lỗi sai định dạng (dd/mm/yyyy)
![Lỗi sai định dạng](images/loi-sai-dinh-dang.png)

#### Lỗi điểm ngoài 0–10
![Lỗi điểm ngoài 0–10](images/loi-diem.png)

### Xuất danh sách
![Xuất danh sách](images/xuat-danh-sach.png)

### Tìm sinh viên theo mã
![Tìm sinh viên theo mã](images/tim-theo-ma1.png)
![Tìm sinh viên theo mã](images/tim-theo-ma2.png)

### Tìm sinh viên theo tên
![Tìm sinh viên theo tên](images/tim-theo-ten1.png)
![Tìm sinh viên theo tên](images/tim-theo-ten2.png)

### Sửa điểm 
![Sửa điểm](images/sua-diem1.png)
![Sửa điểm](images/sua-diem2.png)

### Xóa sinh viên
![Xóa sinh viên](images/xoa-sinh-vien.png)

### Sắp xếp theo điểm giảm dần
![Sắp xếp theo điểm giảm dần](images/sap-xep.png)

### Lọc sinh viên đạt
![Lọc sinh viên đạt](images/loc-sinh-vien-dat.png)

### Thoát chương trình
![Thoát chương trình](images/thoat-chuong-trinh.png)
