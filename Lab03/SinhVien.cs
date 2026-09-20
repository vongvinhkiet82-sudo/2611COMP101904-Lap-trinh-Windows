using System;
using System;
 
namespace Lab03_QuanLySinhVienOOP
{
    class SinhVien : Nguoi
    {
        public string MaSinhVien;
        public string MaLop;

        private double diemTrungBinh;

        // property kiem tra diem tu 0 den 10
        public double DiemTrungBinh
        {
            get
            {
                return diemTrungBinh;
            }
            set
            {
                if (value < 0 || value > 10)
                {
                    // neu nhap sai thi cho ve 0 cho an toan
                    Console.WriteLine("Diem khong hop le (phai tu 0 den 10), tam thoi luu la 0.");
                    diemTrungBinh = 0;
                }
                else
                {
                    diemTrungBinh = value;
                }
            }
        }

        public SinhVien() : base()
        {
            MaSinhVien = "";
            MaLop = "";
            DiemTrungBinh = 0;
        }

        public SinhVien(string maSinhVien, string hoTen, DateTime ngaySinh, string maLop, double diem)
            : base(hoTen, ngaySinh)
        {
            MaSinhVien = maSinhVien;
            MaLop = maLop;
            DiemTrungBinh = diem;
        }

        // xep loai theo diem trung binh
        public string XepLoai()
        {
            if (DiemTrungBinh >= 8)
            {
                return "Gioi";
            }
            else if (DiemTrungBinh >= 6.5)
            {
                return "Kha";
            }
            else if (DiemTrungBinh >= 5)
            {
                return "Trung binh";
            }
            else
            {
                return "Yeu";
            }
        }

        public override string LayThongTin()
        {
            return MaSinhVien + " - " + HoTen + " - Lop: " + MaLop +
                   " - Diem: " + DiemTrungBinh + " - Xep loai: " + XepLoai();
        }
    }
}

