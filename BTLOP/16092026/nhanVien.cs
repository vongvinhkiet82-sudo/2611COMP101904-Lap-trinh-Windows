using QuanLyNhanVien;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyNhanVien
{
    public class nhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }

        private double luongCoBan;
        public double LuongCoBan
        {
            get => luongCoBan;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Lương cơ bản phải lớn hơn 0.");
                luongCoBan = value;
            }
        }
        public nhanVien(string maNV, string hoTen, double luongCoBan)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
        }
        public virtual double TinhLuong()
        {
            return LuongCoBan;
        }

        public virtual void HienThiThongTin()
        {
            Console.WriteLine(
                $"Mã NV: {MaNV,-8} | Họ tên: {HoTen,-20} | Lương cơ bản: {LuongCoBan,15:N0} | Lương thực nhận: {TinhLuong(),15:N0}");
        }
    }
}


