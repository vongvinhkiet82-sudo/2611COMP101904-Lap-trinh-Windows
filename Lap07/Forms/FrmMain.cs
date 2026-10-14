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
    public partial class FrmMain : Form
    {
        private readonly User _currentUser;
        private bool _isLogout;

        public bool IsLogout
        {
            get { return _isLogout; }
        }

        public FrmMain(User user)
        {
            InitializeComponent();
            _currentUser = user;

            // Nối sự kiện
            Load += FrmMain_Load;
            FormClosing += FrmMain_FormClosing;
            timer1.Tick += timer1_Tick;
            mnuDangXuat.Click += mnuDangXuat_Click;
            mnuThoat.Click += mnuThoat_Click;
            mnuQuanLySanPham.Click += mnuQuanLySanPham_Click;
            mnuQuanLyKhachHang.Click += mnuQuanLyKhachHang_Click;
            mnuGioiThieu.Click += mnuGioiThieu_Click;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            tsslUser.Text = "Người dùng: " + _currentUser.FullName;
            tsslRole.Text = "Vai trò: " + _currentUser.Role;
            tsslTime.Text = "Thời gian: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tsslTime.Text = "Thời gian: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void OpenChildForm<T>() where T : Form, new()
        {
            foreach (Form child in MdiChildren)
            {
                if (child is T)
                {
                    if (child.WindowState == FormWindowState.Minimized)
                        child.WindowState = FormWindowState.Normal;
                    child.Activate();
                    return;
                }
            }

            T form = new T();
            form.MdiParent = this;
            form.Show();
        }

        private void mnuQuanLySanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm<FrmProduct>();
        }

        private void mnuQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm<FrmCustomer>();
        }

        private void mnuGioiThieu_Click(object sender, EventArgs e)
        {
            OpenChildForm<FrmAbout>();
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _isLogout = true;
                Close();
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Close(); // FormClosing sẽ hỏi xác nhận
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isLogout || e.CloseReason != CloseReason.UserClosing)
                return;

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                e.Cancel = true;
        }
    }
}
