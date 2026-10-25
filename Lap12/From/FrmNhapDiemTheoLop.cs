using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using QLSinhVienLab12.DAL;

namespace QLSinhVienLab12.Forms
{
    public partial class FrmNhapDiemTheoLop : Form
    {
        private readonly KetQuaDAL ketQuaDAL = new KetQuaDAL();
        private readonly BindingSource ketQuaSource = new BindingSource();

        public FrmNhapDiemTheoLop()
        {
            InitializeComponent();
        }

        // ============ 1. Load Form: đổ dữ liệu vào ComboBox ============
        private void FrmNhapDiemTheoLop_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBox();
                dgvKetQua.DataSource = ketQuaSource;      // bind grid vào BindingSource
                btnLuuTatCa.Enabled = false;
                SetStatus("Sẵn sàng. Hãy chọn lớp, môn học rồi bấm Tải danh sách.");
            }
            catch (Exception ex)
            {
                SetStatus("Không kết nối được database.");
                MessageBox.Show("Không thể tải dữ liệu ban đầu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBox()
        {
            // Đặt DisplayMember/ValueMember TRƯỚC DataSource để tránh lỗi hiện "System.Data.DataRowView"
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
            cboLop.DataSource = ketQuaDAL.GetLop();

            cboMonHoc.DisplayMember = "TenMon";
            cboMonHoc.ValueMember = "MaMon";
            cboMonHoc.DataSource = ketQuaDAL.GetMonHoc();
        }

        // ============ 2. Tải danh sách sinh viên ============
        private void btnTaiDanhSach_Click(object sender, EventArgs e)
        {
            string maLop = Convert.ToString(cboLop.SelectedValue) ?? "";
            string maMon = Convert.ToString(cboMonHoc.SelectedValue) ?? "";

            if (maLop.Length == 0 || maMon.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp và môn học.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataTable table = ketQuaDAL.GetKetQuaByLopMon(maLop, maMon);
                ketQuaSource.Filter = "";
                txtTimKiem.Clear();
                ketQuaSource.DataSource = table;
                ConfigureGrid();

                btnLuuTatCa.Enabled = table.Rows.Count > 0;
                SetStatus("Đã tải " + table.Rows.Count + " sinh viên của lớp " + cboLop.Text + " - môn " + cboMonHoc.Text + ".");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureGrid()
        {
            dgvKetQua.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.AllowUserToDeleteRows = false;

            dgvKetQua.Columns["MaSV"].HeaderText = "Mã SV";
            dgvKetQua.Columns["MaSV"].ReadOnly = true;          // chỉ cho sửa Diem, GhiChu
            dgvKetQua.Columns["MaSV"].FillWeight = 20;

            dgvKetQua.Columns["HoTen"].HeaderText = "Họ tên";
            dgvKetQua.Columns["HoTen"].ReadOnly = true;
            dgvKetQua.Columns["HoTen"].FillWeight = 40;

            dgvKetQua.Columns["Diem"].HeaderText = "Điểm";
            dgvKetQua.Columns["Diem"].FillWeight = 15;
            dgvKetQua.Columns["Diem"].DefaultCellStyle.Format = "0.##";

            dgvKetQua.Columns["GhiChu"].HeaderText = "Ghi chú";
            dgvKetQua.Columns["GhiChu"].FillWeight = 25;
        }

        // ============ 3. Lưu tất cả (validate -> transaction) ============
        private void btnLuuTatCa_Click(object sender, EventArgs e)
        {
            try
            {
                dgvKetQua.EndEdit();          // kết thúc ô đang sửa
                ketQuaSource.EndEdit();       // đẩy giá trị về DataTable

                DataTable table = ketQuaSource.DataSource as DataTable;
                if (table == null || table.Rows.Count == 0)
                {
                    MessageBox.Show("Chưa có dữ liệu để lưu.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Bỏ filter tìm kiếm để thấy/chọn đúng dòng lỗi
                ketQuaSource.Filter = "";
                txtTimKiem.Clear();

                string loi;
                int dongLoi;
                if (!ValidateData(table, out loi, out dongLoi))
                {
                    if (dongLoi >= 0 && dongLoi < dgvKetQua.Rows.Count)
                    {
                        dgvKetQua.CurrentCell = dgvKetQua.Rows[dongLoi].Cells["Diem"];
                        dgvKetQua.BeginEdit(true);
                    }
                    SetStatus("Dữ liệu không hợp lệ - chưa lưu.");
                    MessageBox.Show(loi, "Dữ liệu không hợp lệ",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maMon = Convert.ToString(cboMonHoc.SelectedValue) ?? "";
                int count = ketQuaDAL.SaveAll(maMon, table);

                SetStatus("Đã lưu thành công " + count + " dòng.");
                MessageBox.Show("Đã lưu thành công " + count + " dòng.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                SetStatus("Lưu thất bại - đã rollback toàn bộ.");
                MessageBox.Show("Không thể lưu dữ liệu (đã rollback toàn bộ):\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Kiểm tra điểm: không rỗng, là số, 0 &lt;= điểm &lt;= 10.</summary>
        private bool ValidateData(DataTable table, out string loi, out int dongLoi)
        {
            loi = "";
            dongLoi = -1;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                string maSV = Convert.ToString(row["MaSV"]);
                string diemText = (Convert.ToString(row["Diem"]) ?? "").Trim();

                if (diemText.Length == 0)
                {
                    loi = "Điểm của sinh viên " + maSV + " đang để trống.";
                    dongLoi = i;
                    return false;
                }

                double diem;
                if (!double.TryParse(diemText, out diem))
                {
                    loi = "Điểm của sinh viên " + maSV + " không phải là số.";
                    dongLoi = i;
                    return false;
                }
                if (diem < 0 || diem > 10)
                {
                    loi = "Điểm của sinh viên " + maSV + " phải nằm trong khoảng 0 đến 10.";
                    dongLoi = i;
                    return false;
                }
            }
            return true;
        }

        // Người dùng gõ chữ vào cột Diem (kiểu số) -> báo lỗi thân thiện thay vì hộp thoại mặc định
        private void dgvKetQua_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            MessageBox.Show("Điểm phải là một số (ví dụ 8 hoặc 7,5).", "Nhập sai định dạng",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ============ Mở rộng (0.5đ): tìm kiếm + thống kê ============
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (!(ketQuaSource.DataSource is DataTable)) return;

            string keyword = txtTimKiem.Text.Trim().Replace("'", "''");
            ketQuaSource.Filter = keyword.Length == 0
                ? ""
                : "HoTen LIKE '%" + keyword + "%' OR MaSV LIKE '%" + keyword + "%'";   // lọc trên DataTable trong RAM, không đụng SQL Server
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            dgvKetQua.EndEdit();
            ketQuaSource.EndEdit();

            DataTable table = ketQuaSource.DataSource as DataTable;
            if (table == null || table.Rows.Count == 0) return;

            List<double> diems = new List<double>();
            foreach (DataRow row in table.Rows)
            {
                if (!row.IsNull("Diem"))
                    diems.Add(Convert.ToDouble(row["Diem"]));
            }

            if (diems.Count == 0)
            {
                MessageBox.Show("Chưa có điểm nào để thống kê.");
                return;
            }

            double tong = 0, cao = diems[0], thap = diems[0];
            int dat = 0;
            foreach (double d in diems)
            {
                tong += d;
                if (d > cao) cao = d;
                if (d < thap) thap = d;
                if (d >= 5) dat++;
            }

            MessageBox.Show(
                "Số sinh viên có điểm: " + diems.Count + "/" + table.Rows.Count + "\n" +
                "Điểm trung bình: " + (tong / diems.Count).ToString("0.00") + "\n" +
                "Cao nhất: " + cao.ToString("0.##") + "  -  Thấp nhất: " + thap.ToString("0.##") + "\n" +
                "Đạt (>= 5): " + dat + "  -  Chưa đạt: " + (diems.Count - dat),
                "Thống kê điểm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetStatus(string message)
        {
            tslTrangThai.Text = message;
        }
    }
}
