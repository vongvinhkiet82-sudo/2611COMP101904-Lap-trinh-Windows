using System;

namespace Lab03_QuanLySinhVienOOP
{
    class Nguoi
    {
        public string HoTen;
        public DateTime NgaySinh;

        public Nguoi()
        {
            HoTen = "";
            NgaySinh = DateTime.Now;
        }

        public Nguoi(string hoTen, DateTime ngaySinh)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
        }

        public virtual string LayThongTin()
        {
            return HoTen + " - " + NgaySinh.ToString("dd/MM/yyyy");
        }
    }
}