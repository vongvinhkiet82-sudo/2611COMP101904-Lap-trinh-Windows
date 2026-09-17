using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyNhanVien
{
    public class NhanVienKinhDoanh : nhanVien
    {
        public const double TiLeHoaHong = 0.05;

        private double doanhSo;
        public double DoanhSo
        {
            get => doanhSo;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Doanh số phải >= 0.");
                doanhSo = value;
            }
        }

        public NhanVienKinhDoanh(string maNV, string hoTen, double luongCoBan, double doanhSo)
            : base(maNV, hoTen, luongCoBan)
        {
            DoanhSo = doanhSo;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + TiLeHoaHong * DoanhSo;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine(
                $"[Kinh doanh] Mã NV: {MaNV,-8} | Họ tên: {HoTen,-20} | Lương CB: {LuongCoBan,12:N0} | Doanh số: {DoanhSo,12:N0} | Lương thực nhận: {TinhLuong(),15:N0}");
        }
    }
}
