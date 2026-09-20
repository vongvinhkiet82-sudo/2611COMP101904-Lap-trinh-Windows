using System;
using System.Collections.Generic;

namespace Lab03_QuanLySinhVienOOP
{
    class Program
    {
        static QuanLySinhVien quanLy = new QuanLySinhVien();

        static void Main(string[] args)
        {
            // them sinh vien cho co du lieu san
            quanLy.Them(new SinhVien("SV001", "Nguyen Van A", new DateTime(2005, 3, 12), "24DTH01", 8.2));
            quanLy.Them(new SinhVien("SV002", "Tran Thi B", new DateTime(2005, 7, 25), "24DTH01", 6.8));
            quanLy.Them(new SinhVien("SV003", "Nguyen Minh C", new DateTime(2004, 11, 2), "24DTH02", 4.5));

            int chon = -1;

            while (chon != 0)
            {
                Console.WriteLine();
                Console.WriteLine("===== QUAN LY SINH VIEN =====");
                Console.WriteLine("1. Them sinh vien");
                Console.WriteLine("2. Xuat danh sach");
                Console.WriteLine("3. Tim sinh vien theo ma");
                Console.WriteLine("4. Tim sinh vien theo ten");
                Console.WriteLine("5. Sua diem trung binh");
                Console.WriteLine("6. Xoa sinh vien");
                Console.WriteLine("7. Sap xep theo diem giam dan");
                Console.WriteLine("8. Loc sinh vien dat");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon chuc nang: ");

                string input = Console.ReadLine();

                try
                {
                    chon = int.Parse(input);
                }
                catch
                {
                    Console.WriteLine("Ban nhap sai roi, phai nhap so tu 0 den 8 thoi.");
                    chon = -1;
                    continue;
                }

                switch (chon)
                {
                    case 1:
                        ThemSinhVien();
                        break;
                    case 2:
                        XuatDanhSach();
                        break;
                    case 3:
                        TimTheoMa();
                        break;
                    case 4:
                        TimTheoTen();
                        break;
                    case 5:
                        SuaDiem();
                        break;
                    case 6:
                        XoaSinhVien();
                        break;
                    case 7:
                        SapXepTheoDiem();
                        break;
                    case 8:
                        LocSinhVienDat();
                        break;
                    case 0:
                        Console.WriteLine("Thoat chuong trinh, hen gap lai!");
                        break;
                    default:
                        Console.WriteLine("Khong co chuc nang nay dau, chon lai nha.");
                        break;
                }
            }
        }

        static void ThemSinhVien()
        {
            Console.WriteLine("--- THEM SINH VIEN ---");

            Console.Write("Nhap ma sinh vien: ");
            string ma = Console.ReadLine();

            // ktra trung ma truoc
            if (quanLy.KiemTraTrungMa(ma))
            {
                Console.WriteLine("Ma nay co roi, khong them duoc.");
                return;
            }

            Console.Write("Nhap ho ten: ");
            string ten = Console.ReadLine();

            Console.Write("Nhap ngay sinh (dd/mm/yyyy): ");
            string ngayNhap = Console.ReadLine();
            DateTime ngaySinh;
            try
            {
                ngaySinh = DateTime.Parse(ngayNhap);
            }
            catch
            {
                Console.WriteLine("Ngay sinh sai dinh dang, tam thoi lay ngay hom nay.");
                ngaySinh = DateTime.Now;
            }

            Console.Write("Nhap ma lop: ");
            string lop = Console.ReadLine();

            Console.Write("Nhap diem trung binh: ");
            string diemNhap = Console.ReadLine();
            double diem;
            try
            {
                diem = double.Parse(diemNhap);
            }
            catch
            {
                Console.WriteLine("Diem nhap sai, tam thoi cho ve 0.");
                diem = 0;
            }

            SinhVien sv = new SinhVien(ma, ten, ngaySinh, lop, diem);
            quanLy.Them(sv);
            Console.WriteLine("Them sinh vien thanh cong!");
        }

        static void XuatDanhSach()
        {
            Console.WriteLine("--- DANH SACH SINH VIEN ---");
            List<SinhVien> ds = quanLy.LayDanhSach();

            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sach dang trong.");
                return;
            }

            foreach (SinhVien sv in ds)
            {
                Console.WriteLine(sv.LayThongTin());
            }
        }

        static void TimTheoMa()
        {
            Console.Write("Nhap ma sinh vien can tim: ");
            string ma = Console.ReadLine();

            SinhVien sv = quanLy.TimTheoMa(ma);
            if (sv == null)
            {
                Console.WriteLine("Khong tim thay sinh vien nao co ma nay.");
            }
            else
            {
                Console.WriteLine(sv.LayThongTin());
            }
        }

        static void TimTheoTen()
        {
            Console.Write("Nhap tu khoa ten can tim: ");
            string tuKhoa = Console.ReadLine();

            List<SinhVien> ketQua = quanLy.TimTheoTen(tuKhoa);
            if (ketQua.Count == 0)
            {
                Console.WriteLine("Khong tim thay ai ten nhu vay.");
            }
            else
            {
                foreach (SinhVien sv in ketQua)
                {
                    Console.WriteLine(sv.LayThongTin());
                }
            }
        }

        static void SuaDiem()
        {
            Console.Write("Nhap ma sinh vien can sua diem: ");
            string ma = Console.ReadLine();

            SinhVien sv = quanLy.TimTheoMa(ma);
            if (sv == null)
            {
                Console.WriteLine("Khong tim thay sinh vien nay.");
                return;
            }

            Console.Write("Nhap diem moi: ");
            string diemNhap = Console.ReadLine();
            double diemMoi;
            try
            {
                diemMoi = double.Parse(diemNhap);
            }
            catch
            {
                Console.WriteLine("Diem nhap sai roi, khong sua duoc.");
                return;
            }

            quanLy.SuaDiem(ma, diemMoi);
            Console.WriteLine("Sua diem xong roi!");
        }

        static void XoaSinhVien()
        {
            Console.Write("Nhap ma sinh vien can xoa: ");
            string ma = Console.ReadLine();

            bool ketQua = quanLy.Xoa(ma);
            if (ketQua)
            {
                Console.WriteLine("Xoa thanh cong.");
            }
            else
            {
                Console.WriteLine("Khong tim thay ma nay de xoa.");
            }
        }

        static void SapXepTheoDiem()
        {
            Console.WriteLine("--- DANH SACH SAU KHI SAP XEP (GIAM DAN) ---");
            List<SinhVien> ds = quanLy.SapXepTheoDiem();

            foreach (SinhVien sv in ds)
            {
                Console.WriteLine(sv.LayThongTin());
            }
        }

        static void LocSinhVienDat()
        {
            Console.WriteLine("--- SINH VIEN DAT (DIEM TU 5 TRO LEN) ---");
            List<SinhVien> ds = quanLy.LocSinhVienDat();

            if (ds.Count == 0)
            {
                Console.WriteLine("Khong co ai dat het.");
                return;
            }

            foreach (SinhVien sv in ds)
            {
                Console.WriteLine(sv.LayThongTin());
            }
        }
    }
}