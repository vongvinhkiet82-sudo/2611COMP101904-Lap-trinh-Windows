using ShopManagerMini.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManagerMini
{
    internal class Program
    {
        public static readonly BindingList<User> Users = new BindingList<User>
        {
            new User("admin", "123", "Quản trị viên", "Admin"),
            new User("user", "123", "Nhân viên bán hàng", "User")
        };

        public static readonly BindingList<Product> Products = new BindingList<Product>
        {
            new Product("SP001", "Nước suối 500ml", "Đồ uống", 5000, 100),
            new Product("SP002", "Mì gói", "Thực phẩm", 4500, 200),
            new Product("SP003", "Bánh quy bơ", "Bánh kẹo", 25000, 50)
        };

        public static readonly BindingList<Customer> Customers = new BindingList<Customer>
        {
            new Customer("KH001", "Nguyễn Văn An", "0901234567", "Thường"),
            new Customer("KH002", "Trần Thị Bình", "0912345678", "VIP")
        };

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool logout;
            do
            {
                User user;
                using (FrmLogin login = new FrmLogin())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                        return;
                    user = login.LoggedInUser;
                }

                FrmMain main = new FrmMain(user);
                Application.Run(main);
                logout = main.IsLogout;
            } while (logout);
        }

    }
}
