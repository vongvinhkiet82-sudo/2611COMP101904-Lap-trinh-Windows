using System;
using System.Collections.Generic;
using System.Linq;
 
namespace Lab03_QuanLySinhVienOOP
{
    class QuanLySinhVien
    {
        private List<SinhVien> danhSach = new List<SinhVien>();

        public List<SinhVien> LayDanhSach()
        {
            return danhSach;
        }

        public bool KiemTraTrungMa(string ma)
        {
            foreach (SinhVien sv in danhSach)
            {
                if (sv.MaSinhVien.ToUpper() == ma.ToUpper())
                {
                    return true;
                }
            }
            return false;
        }

        // them sinh vien moi, ktra trung ma
        public bool Them(SinhVien sv)
        {
            if (KiemTraTrungMa(sv.MaSinhVien))
            {
                return false;
            }
            danhSach.Add(sv);
            return true;
        }

        // tim theo ma
        public SinhVien TimTheoMa(string ma)
        {
            foreach (SinhVien sv in danhSach)
            {
                if (sv.MaSinhVien.ToUpper() == ma.ToUpper())
                {
                    return sv;
                }
            }
            return null;
        }

        // tim theo ten, tra danh sach cac ban trung ten
        public List<SinhVien> TimTheoTen(string tuKhoa)
        {
            List<SinhVien> ketQua = new List<SinhVien>();
            foreach (SinhVien sv in danhSach)
            {
                if (sv.HoTen.ToLower().Contains(tuKhoa.ToLower()))
                {
                    ketQua.Add(sv);
                }
            }
            return ketQua;
        }

        // sua diem theo ma
        public bool SuaDiem(string ma, double diemMoi)
        {
            SinhVien sv = TimTheoMa(ma);
            if (sv == null)
            {
                return false;
            }
            sv.DiemTrungBinh = diemMoi;
            return true;
        }

        // xoa sinh vien
        public bool Xoa(string ma)
        {
            SinhVien sv = TimTheoMa(ma);
            if (sv == null)
            {
                return false;
            }
            danhSach.Remove(sv);
            return true;
        }

        // sap xep theo diem giam dan
        public List<SinhVien> SapXepTheoDiem()
        {
            List<SinhVien> ketQua = danhSach.OrderByDescending(sv => sv.DiemTrungBinh).ToList();
            return ketQua;
        }

        // loc sinh vien dat (diem >= 5)
        public List<SinhVien> LocSinhVienDat()
        {
            List<SinhVien> ketQua = danhSach.Where(sv => sv.DiemTrungBinh >= 5).ToList();
            return ketQua;
        }
    }
}

