using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab05_Đăng_ký_khóa_học
{
    public partial class Dangkykhoahoc : Form
    {
        private decimal LayHocPhiCoBan()
        {
            string KhoaHoc = cboKhoaHoc.SelectedItem.ToString();

            if (KhoaHoc == "C# WinForms cơ bản")
            {
                return 800000m;
            }
            if (KhoaHoc == "SQL Server cơ bản")
            {
                return 700000m;
            }
            if (KhoaHoc == "Web Frontend cơ bản")
            {
                return 750000m;
            }
            if (KhoaHoc == "Lập trình Python cơ bản")
            {
                return 650000m;
            }
            return 0m;
        }

        private decimal TinhTongTien()
        {
            return LayHocPhiCoBan() * numSoThang.Value + LayPhuPhiHinhThuc();
        }

        private decimal LayPhuPhiHinhThuc()
        {
            if (radTrucTiep.Checked)
            {
                return 100000m;
            }
            return 0m;
        }

        private void CapNhatHocPhi()
        {
            CultureInfo vi = new CultureInfo("vi-VN");

            decimal hocPhiThang = LayHocPhiCoBan();
            decimal tong = TinhTongTien();

            lblHocPhi.Text = hocPhiThang.ToString("N0", vi) + " VND";
            lblTien.Text = tong.ToString("N0", vi) + " VND";
        }

        public Dangkykhoahoc()
        {
            InitializeComponent();
        }

        private void Dangkykhoahoc_Load(object sender, EventArgs e)
        {
            cboKhoaHoc.Items.Clear();
            cboKhoaHoc.Items.Add("C# WinForms cơ bản");
            cboKhoaHoc.Items.Add("SQL Server cơ bản");
            cboKhoaHoc.Items.Add("Web Frontend cơ bản");
            cboKhoaHoc.Items.Add("Lập trình Python cơ bản");
            cboKhoaHoc.SelectedIndex = 0;

            radOnline.Checked = true;

            numSoThang.Minimum = 1;
            numSoThang.Maximum = 12;
            numSoThang.Value = 1;

            lblDemKyTu.Text = "0/50";
            DateTime today = DateTime.Today;
            dtpNgaySinh.MaxDate = today;

            chkNhanEmail.Checked = false;
            lblNhanemail.Text = "Chưa đăng ký nhận email";

            CapNhatHocPhi();
            txtHoTen.Focus();
        }

        private void chkNhanEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNhanEmail.Checked)
            {
                lblNhanemail.Text = "Đã đăng ký nhận email";
            }
            else
            {
                lblNhanemail.Text = "Chưa đăng ký nhận email";
            }
        }

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatHocPhi();
        }

        private void radOnline_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatHocPhi();
        }

        private void radTrucTiep_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatHocPhi();
        }

        private void numSoThang_ValueChanged(object sender, EventArgs e)
        {
            CapNhatHocPhi();
        }

        private void lblDemKyTu_Click(object sender, EventArgs e)
        {

        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            lblDemKyTu.Text = txtHoTen.Text.Length + "/50";
        }

        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {}

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            string sdt = txtSoDienThoai.Text.Trim();
            bool chiLaSo = sdt.All(char.IsDigit);
            if (!chiLaSo || sdt.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải gồm đúng 10 chữ số!", "Sai định dạng",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            if (cboKhoaHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn khóa học.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoaHoc.Focus();
                return;
            }

            CultureInfo vi = new CultureInfo("vi-VN");
            string hinhThuc = radOnline.Checked ? "Online" : "Trực tiếp";
            string nhanEmail = chkNhanEmail.Checked ? "Có" : "Không";
            string tongTien = TinhTongTien().ToString("N0", vi) + " VND";

            string phieu =
                "Họ tên: " + txtHoTen.Text.Trim() + "\n" +
                "Số điện thoại: " + txtSoDienThoai.Text.Trim() + "\n" +
                "Ngày sinh: " + dtpNgaySinh.Value.ToString("dd/MM/yyyy") + "\n" +
                "Khóa học: " + cboKhoaHoc.Text + "\n" +
                "Hình thức học: " + hinhThuc + "\n" +
                "Số tháng: " + numSoThang.Value + "\n" +
                "Tổng tiền: " + tongTien + "\n" +
                "Nhận email thông báo: " + nhanEmail;

            MessageBox.Show(phieu, "Phiếu đăng ký", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            cboKhoaHoc.SelectedIndex = 0;
            radOnline.Checked = true;
            numSoThang.Value = 1;
            chkNhanEmail.Checked = false;
            dtpNgaySinh.Value = DateTime.Today;
            CapNhatHocPhi();
            txtHoTen.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
