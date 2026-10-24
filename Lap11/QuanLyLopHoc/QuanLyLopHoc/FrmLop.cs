using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace QuanLyLopHoc
{
    public partial class FrmLop : Form
    {
        private readonly string connectionString =
            @"Data Source=.;Initial Catalog=EduManagerDB_Lab11;Integrated Security=True;TrustServerCertificate=True";

        public FrmLop()
        {
            InitializeComponent();
        }

        // ===== F1: load khi mo form =====
        private void FrmLop_Load(object sender, EventArgs e)
        {
            dgvLop.AutoGenerateColumns = false;
            LoadData();
        }

        private void LoadData(string keyword = null)
        {
            try
            {
                string sql = @"SELECT l.MaLop, l.TenLop, COUNT(sv.MaSV) AS SoSinhVien
                               FROM LOP l
                               LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop";
                bool coLoc = !string.IsNullOrWhiteSpace(keyword);
                if (coLoc)
                    sql += " WHERE l.MaLop LIKE @kw OR l.TenLop LIKE @kw";
                sql += " GROUP BY l.MaLop, l.TenLop ORDER BY l.MaLop";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    if (coLoc)
                        cmd.Parameters.AddWithValue("@kw", "%" + keyword.Trim() + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvLop.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Loi("Lỗi load dữ liệu: " + ex.Message);
            }
        }

        private void ThongBao(string noiDung)
        {
            MessageBox.Show(noiDung, "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CanhBao(string noiDung)
        {
            MessageBox.Show(noiDung, "Cảnh báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Loi(string noiDung)
        {
            MessageBox.Show(noiDung, "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                CanhBao("Vui lòng nhập mã lớp");
                txtMaLop.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                CanhBao("Vui lòng nhập tên lớp");
                txtTenLop.Focus();
                return false;
            }
            return true;
        }

        private bool IsMaLopExists(string maLop)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM LOP WHERE MaLop = @ma", conn))
            {
                cmd.Parameters.AddWithValue("@ma", maLop);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private int CountSinhVienByLop(string maLop)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM SINHVIEN WHERE MaLop = @ma", conn))
            {
                cmd.Parameters.AddWithValue("@ma", maLop);
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // F7: xoa TextBox + mo khoa txtMaLop
        private void ClearInput()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtMaLop.ReadOnly = false;
            txtMaLop.Focus();
        }

        private bool DaChonLop()
        {
            return txtMaLop.ReadOnly && !string.IsNullOrWhiteSpace(txtMaLop.Text);
        }

        // ===== F2: click dong =====
        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvLop.Rows[e.RowIndex];
            txtMaLop.Text = Convert.ToString(row.Cells["MaLop"].Value);
            txtTenLop.Text = Convert.ToString(row.Cells["TenLop"].Value);
            txtMaLop.ReadOnly = true;
            this.dgvLop.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLop_CellClick);
        }

        // ===== F3: Them =====
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();

            try
            {
                if (IsMaLopExists(ma))
                {
                    CanhBao("Mã lớp đã tồn tại");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO LOP(MaLop, TenLop) VALUES(@ma, @ten)", conn))
                {
                    cmd.Parameters.AddWithValue("@ma", ma);
                    cmd.Parameters.AddWithValue("@ten", ten);
                    conn.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        ThongBao("Thêm lớp thành công");
                        LoadData();
                        ClearInput();
                    }
                }
            }
            catch (Exception ex)
            {
                Loi("Lỗi thêm lớp: " + ex.Message);
            }
        }

        // ===== F4: Sua =====
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!DaChonLop())
            {
                CanhBao("Vui lòng chọn lớp cần sửa");
                return;
            }
            if (!ValidateInput()) return;

            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE LOP SET TenLop = @ten WHERE MaLop = @ma", conn))
                {
                    cmd.Parameters.AddWithValue("@ma", ma);
                    cmd.Parameters.AddWithValue("@ten", ten);
                    conn.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        ThongBao("Cập nhật lớp thành công");
                        LoadData();
                        ClearInput();
                    }
                    else
                    {
                        CanhBao("Không tìm thấy lớp cần sửa");
                    }
                }
            }
            catch (Exception ex)
            {
                Loi("Lỗi cập nhật: " + ex.Message);
            }
        }

        // ===== F5: Xoa =====
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!DaChonLop())
            {
                CanhBao("Vui lòng chọn lớp cần xóa");
                return;
            }
            string ma = txtMaLop.Text.Trim();

            try
            {
                if (CountSinhVienByLop(ma) > 0)
                {
                    CanhBao("Không thể xóa lớp đang có sinh viên");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Bạn có chắc muốn xóa lớp " + ma + "?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (result != DialogResult.Yes) return;

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("DELETE FROM LOP WHERE MaLop = @ma", conn))
                {
                    cmd.Parameters.AddWithValue("@ma", ma);
                    conn.Open();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        ThongBao("Xóa lớp thành công");
                        LoadData();
                        ClearInput();
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 547) // vi pham khoa ngoai
            {
                CanhBao("Không thể xóa vì lớp đang được sinh viên tham chiếu");
            }
            catch (Exception ex)
            {
                Loi("Lỗi xóa lớp: " + ex.Message);
            }
        }

        // ===== F6: Tim kiem =====
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData(txtTimKiem.Text);
        }

        // ===== F7: Lam moi =====
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            ClearInput();
            LoadData();
        }
    }
}