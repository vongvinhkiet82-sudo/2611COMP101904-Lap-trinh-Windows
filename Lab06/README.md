# ProductManager - Lab 05

## 1. Giới thiệu

Ứng dụng Windows Forms quản lý danh sách sản phẩm của một cửa hàng.
Dữ liệu lưu trong bộ nhớ (`BindingList` + `BindingSource`), chưa kết nối SQL Server.

Công nghệ / control sử dụng: MenuStrip, ToolStrip, StatusStrip, ContextMenuStrip,
DataGridView, BindingSource, ErrorProvider, OpenFileDialog.

## 2. Cách chạy

1. Mở file `.sln` bằng Visual Studio.
2. Nhấn **F5** để chạy.

## 3. Giao diện chính

![Giao diện chính](images/giao-dien-chinh.png)

Các thành phần: MenuStrip (File, Quản lý, Trợ giúp), ToolStrip (Thêm, Sửa, Xóa, Làm mới, Tìm kiếm),
GroupBox "Thông tin sản phẩm", DataGridView, PictureBox + nút Chọn ảnh, StatusStrip.

## 4. Các chức năng

### 4.1 Thêm sản phẩm
Nhập thông tin vào GroupBox rồi bấm **Thêm**. Chương trình kiểm tra dữ liệu và không cho trùng mã.

![Thêm sản phẩm](images/them-san-pham1.png)

Lỗi khi chưa có dữ liệu mà bấm thêm.

![Thêm sản phẩm](images/them-san-pham2.png)

### 4.2 Sửa sản phẩm
Click vào một dòng trên DataGridView, dữ liệu hiện lên form. Chỉnh sửa rồi bấm **Sửa**.

![Sửa sản phẩm](images/sua-san-pham1.png)
![Sửa sản phẩm](images/sua-san-pham.png)

Đã sửa giá của sản phẩm SP001.

![Sửa sản phẩm](images/sua-san-pham2.png)

### 4.3 Xóa sản phẩm
Chọn một dòng rồi bấm **Xóa**. Có MessageBox xác nhận trước khi xóa.
Nếu chưa chọn dòng, chương trình hiện thông báo và không bị lỗi.

![Xóa sản phẩm](images/xoa-san-pham1.png)
![Xóa sản phẩm](images/xoa-san-pham2.png)

### 4.4 Tìm kiếm
Gõ mã hoặc tên sản phẩm vào ô **Mã SP** (hoặc **Tên SP**) rồi bấm **Tìm kiếm**.
Tìm không phân biệt chữ hoa/thường.

![Tìm kiếm](images/tim-kiem1.png)
![Tìm kiếm](images/tim-kiem2.png)

### 4.5 Làm mới
Xóa nội dung nhập, bỏ lỗi ErrorProvider và hiển thị lại toàn bộ danh sách.

### 4.6 Chọn ảnh
Bấm **Chọn ảnh**, chọn file ảnh bằng OpenFileDialog, ảnh hiển thị trong PictureBox.
Đường dẫn ảnh được lưu vào trường `DuongDanAnh` của sản phẩm.


![Chọn ảnh](images/chon-anh.png)

## 5. Phím tắt

| Phím | Chức năng |
|---|---|
| Ctrl + N | Thêm |
| F2 | Sửa |
| Ctrl + D | Xóa |
| F5 | Làm mới |

![Phím tắt](images/phim-tat.png)

## 6. Cấu trúc source code

- `Product.cs`: class lưu dữ liệu sản phẩm.
- `Form1.cs`: xử lý của form `FrmProduct`.
  - `ValidateInput`: kiểm tra dữ liệu nhập.
  - `ClearInput`: xóa trắng các ô nhập.
  - `LoadProductToForm`: đưa dữ liệu sản phẩm lên form.
  - `UpdateStatus`: cập nhật thanh trạng thái.

## 8. Ghi chú

- Ảnh minh họa đặt trong thư mục `images/` cùng cấp với file README này.
