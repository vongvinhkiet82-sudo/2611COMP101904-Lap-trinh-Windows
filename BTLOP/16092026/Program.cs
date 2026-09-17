using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyNhanVien
{
    class Program
    {
        static List<nhanVien> danhSach = new List<nhanVien>();
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            NhapDanhSachBanDau();

            bool thoat = false;
            while (!thoat)
            {
                HienThiMenu();
                string luaChon = Console.ReadLine();

                switch (luaChon)
                {
                    case "1": XuatDanhSach(); break;
                    case "2": TimTheoMa(); break;
                    case "3": TimLuongCaoNhat(); break;
                    case "4": TinhTongLuong(); break;
                    case "0":
                        thoat = true;
                        Console.WriteLine("Tạm Biệt!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại!");
                        break;
                }
                Console.WriteLine();
            }

        }

        static void HienThiMenu()
        {
            Console.WriteLine("======== MENU ========");
            Console.WriteLine("1. Xuất danh sách nhân viên");
            Console.WriteLine("2. Tìm nhân viên theo mã");
            Console.WriteLine("3. Tìm nhân viên có lương cao nhất");
            Console.WriteLine("4. Tính tổng lương công ty phải trả");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn chức năng: ");
        }

        static void NhapDanhSachBanDau()
        {
            Console.WriteLine("=== Nhập Danh Sách Nhân Viên Ban Đầu (tối thiểu 5 nhân viên) ===");
            int soLuong = NhapSoNguyen("Nhập số lượng nhân viên cần nhập (>=5): ", 5, int.MaxValue);
            for (int i = 1; i <= soLuong; i++)
            {
                Console.WriteLine($"=== Nhập Thông Tin Nhân Viên Thứ {i} ===");
                ThemNhanVien();
            }
        }

        static void ThemNhanVien()
        {
            Console.WriteLine("Chọn loại nhân viên:");
            Console.WriteLine("  1. Nhân viên văn phòng");
            Console.WriteLine("  2. Nhân viên kinh doanh");
            Console.WriteLine("  3. Nhân viên thời vụ");

            int loai = NhapSoNguyen("Nhập lựa chọn: ", 1, 3);

            Console.Write("Mã nhân viên: ");
            string maNV = Console.ReadLine();
            Console.Write("Họ tên: ");
            string hoTen = Console.ReadLine();

            try
            {
                nhanVien nv = null;
                switch (loai)
                {
                    case 1:
                        {
                            double luongCoBan = NhapSoThuc("Lương cơ bản (>0): ", 0.01, double.MaxValue);
                            int soNgay = NhapSoNguyen("Số ngày làm việc (0-31): ", 0, 31);
                            nv = new NhanVienVanPhong(maNV, hoTen, luongCoBan, soNgay);
                            break;
                        }
                    case 2:
                        {
                            double luongCoBan = NhapSoThuc("Lương cơ bản (>0): ", 0.01, double.MaxValue);
                            double doanhSo = NhapSoThuc("Doanh số (>=0): ", 0, double.MaxValue);
                            nv = new NhanVienKinhDoanh(maNV, hoTen, luongCoBan, doanhSo);
                            break;
                        }
                    case 3:
                        {
                            double luongCoBan = NhapSoThuc("Lương cơ bản (>0, mang tính hình thức): ", 0.01, double.MaxValue);
                            double soGio = NhapSoThuc("Số giờ làm (>=0): ", 0, double.MaxValue);
                            double luongGio = NhapSoThuc("Lương theo giờ (>0): ", 0.01, double.MaxValue);
                            nv = new NhanVienThoiVu(maNV, hoTen, luongCoBan, soGio, luongGio);
                            break;
                        }
                }
                danhSach.Add(nv);
                Console.WriteLine("=> Thêm nhân viên thành công!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message + " Nhân viên không được thêm vào danh sách.");
            }
        }

        // xuất danh sách
        static void XuatDanhSach()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách trống!");
                return;
            }
            Console.WriteLine("=== Danh Sách Nhân Viên ===");
            foreach (var nv in danhSach)
            {
                nv.HienThiThongTin();
            }
        }

        // tìm theo mã
        static void TimTheoMa()
        {
            Console.WriteLine("Nhập mã nhân viên cần tìm: ");
            string ma = Console.ReadLine();
            var nv = danhSach.FirstOrDefault(x => x.MaNV.Equals(ma, StringComparison.OrdinalIgnoreCase));
            if (nv == null)
                Console.WriteLine("Không tìm thấy nhân viên có mã: " + ma);
            else
                nv.HienThiThongTin();
        }

        // tìm nhân viên lương cao nhất
        static void TimLuongCaoNhat()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách trống!");
                return;
            }
            var nvCaoNhat = danhSach.OrderByDescending(x => x.TinhLuong()).First();
            Console.WriteLine("Nhân viên có lương cao nhất:");
            nvCaoNhat.HienThiThongTin();
        }

        // tính tổng lương công ty phải trả
        static void TinhTongLuong()
        {
            double tong = danhSach.Sum(x => x.TinhLuong());
            Console.WriteLine($"Tổng lương công ty phải trả: {tong:N0} VNĐ");
        }

        static int NhapSoNguyen(string thongBao, int min, int max)
        {
            int gt;
            while (true)
            {
                Console.Write(thongBao);
                if (int.TryParse(Console.ReadLine(), out gt) && gt >= min && gt <= max)
                    return gt;
                Console.WriteLine($"Giá trị không hợp lệ! Vui lòng nhập số nguyên trong khoảng [{min},{max}].");
            }
        }

        static double NhapSoThuc(string thongBao, double min, double max)
        {
            double gt;
            while (true)
            {
                Console.Write(thongBao);
                if (double.TryParse(Console.ReadLine(), out gt) && gt >= min && gt <= max)
                    return gt;
                Console.WriteLine($"Giá trị không hợp lệ! Vui lòng nhập số trong khoảng [{min},{max}].");
            }
        }
    }
}