using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyNhanVien
{
    public class NhanVienVanPhong : nhanVien
    {
        public const double DonGiaTheoNgay = 200000;

        private int soNgayLamViec;
        public int SoNgayLamViec
        {
            get => soNgayLamViec;
            set
            {
                if (value < 0 || value > 31)
                    throw new ArgumentException("Số ngày làm việc phải trong khoảng 0-31.");
                soNgayLamViec = value;
            }
        }

        public NhanVienVanPhong(string maNV, string hoTen, double luongCoBan, int soNgayLamViec)
            : base(maNV, hoTen, luongCoBan)
        {
            SoNgayLamViec = soNgayLamViec;
        }

        public override double TinhLuong()
        {
            return LuongCoBan + SoNgayLamViec * DonGiaTheoNgay;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine(
                $"[Văn phòng]   Mã NV: {MaNV,-8} | Họ tên: {HoTen,-20} | Lương CB: {LuongCoBan,12:N0} | Số ngày làm: {SoNgayLamViec,3} | Lương thực nhận: {TinhLuong(),15:N0}");
        }
    }
}
