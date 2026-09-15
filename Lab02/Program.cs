using System;
namespace Lab02_QuanLyMang
{
    class Program
    {
        static int[] mang = null;
        static bool daNhapMang = false;
        static void Main(string[] args)
        {
            int luaChon;
            do
            {
                HienThiMenu();
                luaChon = NhapSoNguyen("Chon chuc nang: ");
                switch (luaChon)
                {
                    case 1:
                        mang = NhapMang();
                        daNhapMang = true;
                        break;
                    case 2:
                        if (KiemTraDaNhapMang())
                            XuatMang(mang);
                        break;
                    case 3:
                        if (KiemTraDaNhapMang())
                            Console.WriteLine("Tong cac phan tu = " + TinhTong(mang));
                        break;
                    case 4:
                        if (KiemTraDaNhapMang())
                        {
                            Console.WriteLine("Gia tri lon nhat = " + TimMax(mang));
                            Console.WriteLine("Gia tri nho nhat = " + TimMin(mang));
                        }
                        break;
                    case 5:
                        if (KiemTraDaNhapMang())
                        {
                            Console.WriteLine("So luong so chan = " + DemChan(mang));
                            Console.WriteLine("So luong so le = " + DemLe(mang));
                        }
                        break;
                    case 6:
                        if (KiemTraDaNhapMang())
                        {
                            SapXepTangDan(mang);
                            Console.WriteLine("Mang sau khi sap xep tang dan:");
                            XuatMang(mang);
                        }
                        break;
                    case 7:
                        if (KiemTraDaNhapMang())
                        {
                            int x = NhapSoNguyen("Nhap gia tri x can tim: ");
                            int viTri = TimKiem(mang, x);
                            if (viTri == -1)
                                Console.WriteLine("Khong tim thay " + x + " trong mang.");
                            else
                                Console.WriteLine("Tim thay " + x + " tai vi tri " + viTri);
                        }
                        break;
                    case 0:
                        Console.WriteLine("Tam biet!");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                        break;
                }

                if (luaChon != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nhap phim bat ky de tiep tuc.....");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (luaChon != 0);
        }

        static void HienThiMenu()
        {
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1. Nhap mang");
            Console.WriteLine("2. Xuat mang");
            Console.WriteLine("3. Tinh tong");
            Console.WriteLine("4. Tim max/min");
            Console.WriteLine("5. Dem chan/le");
            Console.WriteLine("6. Sap xep tang dan");
            Console.WriteLine("7. Tim kiem");
            Console.WriteLine("0. Thoat");
        }

        // ktra da nhap mang chua, chua thi bao loi
        static bool KiemTraDaNhapMang()
        {
            if (!daNhapMang)
            {
                Console.WriteLine("Ban chua nhap mang! Vui long chon chuc nang 1 truoc.");
                return false;
            }
            return true;
        }

        // ktra dinh dang so nguyen
        static int NhapSoNguyen(string message)
        {
            int soNguyen;
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (int.TryParse(input, out soNguyen))
                {
                    return soNguyen;
                }
                Console.WriteLine("Du lieu khong hop le. Vui long nhap lai mot so nguyen.");
            }
        }

        // nhap sluong ptu
        static int NhapSoNguyenDuong(string message)
        {
            int soNguyen;
            while (true)
            {
                soNguyen = NhapSoNguyen(message);
                if (soNguyen > 0)
                {
                    return soNguyen;
                }
                Console.WriteLine("So phai la so nguyen duong. Vui long nhap lai.");
            }
        }

        // nhap mang
        static int[] NhapMang()
        {
            int n = NhapSoNguyenDuong("Nhap so luong phan tu n: ");
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = NhapSoNguyen("Nhap phan tu a[" + i + "]: ");
            }
            Console.WriteLine("Nhap mang thanh cong!");
            return a;
        }

        // xuat mang
        static void XuatMang(int[] a)
        {
            Console.Write("Mang: ");
            foreach (int x in a)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }

        // tinh tong
        static int TinhTong(int[] a)
        {
            int tong = 0;
            foreach ( int x in a)
            {
                tong += x;
            }
            return tong;
        }

        // tim max
        static int TimMax(int[] a)
        {
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max)
                    max = a[i];
            }
            return max;
        }

        // tim min
        static int TimMin(int[] a)
        {
            int min = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min)
                    min = a[i];
            }
            return min;
        }

        // dem sluong so chan
        static int DemChan(int[] a)
        {
            int dem = 0;
            foreach (int x in a)
            {
                if (x % 2 == 0)
                    dem++;
            }
            return dem;
        }

        //dem sluong so le
        static int DemLe(int[] a)
        {
            int dem = 0;
            foreach (int x in a)
            {
                if (x % 2 != 0)
                    dem++;
            }
            return dem;
        }

        //sap xep tang dan
        static void SapXepTangDan(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = 0; j < a.Length - 1 - i; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int tam = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = tam;
                    }
                }
            }
        }

        // tim kiem trong mang
                static int TimKiem(int[] a, int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == x)
                    return i;
            }
            return -1;
        }
    }
}