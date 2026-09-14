using System.Text.RegularExpressions;

namespace UNGDUNGTHONGTINCANHAN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHienThi_Click(object? sender, EventArgs e)
        {
            // ktra họ tên
            string hoTen = txtHoTen.Text.Trim();
            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            // ktra năm sinh
            string namSinhText = txtNamSinh.Text.Trim();
            if (string.IsNullOrEmpty(namSinhText))
            {
                MessageBox.Show("Vui lòng nhập năm sinh.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamSinh.Focus();
                return;
            }

            if (!int.TryParse(namSinhText, out int namSinh))
            {
                MessageBox.Show("Năm sinh phải là số nguyên.", "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNamSinh.Focus();
                return;
            }

            int namHienTai = DateTime.Now.Year;
            if (namSinh < 1900 || namSinh > namHienTai)
            {
                MessageBox.Show($"Năm sinh phải nằm trong khoảng từ 1900 đến {namHienTai}.",
                    "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNamSinh.Focus();
                return;
            }

            // ktra email
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            const string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Email không đúng định dạng (ví dụ: ten@example.com).",
                    "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            // ktra chọn giới tính chưa
            if (!radNam.Checked && !radNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";

            // ktra chọn khoa/lớp chưa
            if (cboKhoa.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn khoa hoặc lớp.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string khoa = cboKhoa.SelectedItem.ToString()!;

            int tuoi = namHienTai - namSinh;
            string ketQua =
                "THÔNG TIN SINH VIÊN" + Environment.NewLine +
                $"Họ tên: {hoTen}" + Environment.NewLine +
                $"Tuổi: {tuoi}" + Environment.NewLine +
                $"Email: {email}" + Environment.NewLine +
                $"Giới tính: {gioiTinh}" + Environment.NewLine +
                $"Khoa/Lớp: {khoa}";

            txtKetQua.Text = ketQua;
            MessageBox.Show(ketQua, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnXoa_Click(object? sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtNamSinh.Clear();
            txtEmail.Clear();

            radNam.Checked = false;
            radNu.Checked = false;

            cboKhoa.SelectedIndex = -1;
            txtKetQua.Clear();
            txtHoTen.Focus();
        }
        private void btnThoat_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
