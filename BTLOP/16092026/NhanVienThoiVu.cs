using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyNhanVien
{
    public class NhanVienThoiVu : nhanVien
    {
        private double soGioLam;
        public double SoGioLam
        {
            get => soGioLam;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Số giờ làm phải >= 0.");
                soGioLam = value;
            }
        }

        private double luongTheoGio;
        public double LuongTheoGio
        {
            get => luongTheoGio;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Lương theo giờ phải > 0.");
                luongTheoGio = value;
            }
        }

        public NhanVienThoiVu(string maNV, string hoTen, double luongCoBan, double soGioLam, double luongTheoGio)
            : base(maNV, hoTen, luongCoBan)
        {
            SoGioLam = soGioLam;
            LuongTheoGio = luongTheoGio;
        }

        public override double TinhLuong()
        {
            return SoGioLam * LuongTheoGio;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine(
                $"[Thời vụ]    Mã NV: {MaNV,-8} | Họ tên: {HoTen,-20} | Số giờ làm: {SoGioLam,8:N1} | Lương/giờ: {LuongTheoGio,10:N0} | Lương thực nhận: {TinhLuong(),15:N0}");
        }
    }
}