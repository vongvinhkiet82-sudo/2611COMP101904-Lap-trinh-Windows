using ShopManagerMini.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManagerMini
{
    public partial class FrmLogin : Form
    {
        public User LoggedInUser { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();

            btnDangNhap.DialogResult = DialogResult.None;
            txtPassword.UseSystemPasswordChar = true; // ẩn mật khẩu

            btnDangNhap.Click += btnDangNhap_Click;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (username.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập username.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            if (password.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập password.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            User user = Program.Users.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);

            if (user == null)
            {
                MessageBox.Show("Sai username hoặc password!", "Lỗi đăng nhập",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            LoggedInUser = user;
            DialogResult = DialogResult.OK;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
