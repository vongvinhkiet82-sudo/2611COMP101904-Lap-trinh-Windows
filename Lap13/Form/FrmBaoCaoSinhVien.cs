using StudentReportDemo.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace StudentReportDemo.Forms
{
    public partial class FrmBaoCaoSinhVien : Form
    {
        private const string TAT_CA = "Tất cả";
        private const string TAT_CA_LOP = "Tất cả lớp";
        private const string DAT = "Đạt";
        private const string KHONG_DAT = "Không đạt";
        private const double DIEM_DAT = 5;

        private const string SX_DIEM_GIAM = "Điểm giảm dần";
        private const string SX_DIEM_TANG = "Điểm tăng dần";
        private const string SX_HO_TEN = "Họ tên (A-Z)";
        private const string SX_MA_SV = "Mã SV";

        // Nguồn dữ liệu gốc
        private List<SinhVien> danhSachSinhVien = new List<SinhVien>();
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        public FrmBaoCaoSinhVien()
        {
            InitializeComponent();
        }

        // 1. SỰ KIỆN FORM LOAD
        private void FrmBaoCaoSinhVien_Load(object sender, EventArgs e)
        {
            SendMessage(txtTuKhoa.Handle, EM_SETCUEBANNER, 1, "Mã SV hoặc họ tên...");
            TaoDuLieuMau();
            LoadComboBox();
            XemBaoCao(false);   // hiển thị toàn bộ khi mở form
        }

        // 2. TẠO DỮ LIỆU MẪU (15 sinh viên, 3 lớp)
        private void TaoDuLieuMau()
        {
            danhSachSinhVien = new List<SinhVien>
            {
                new SinhVien { MaSV = "SV001", HoTen = "Nguyễn Văn An",     MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 8.2 },
                new SinhVien { MaSV = "SV002", HoTen = "Trần Thị Bình",     MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 6.5 },
                new SinhVien { MaSV = "SV003", HoTen = "Lê Minh Cường",     MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 4.8 },
                new SinhVien { MaSV = "SV004", HoTen = "Phạm Thanh Dung",   MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 9.1 },
                new SinhVien { MaSV = "SV005", HoTen = "Phan Văn Em",       MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 5.0 },

                new SinhVien { MaSV = "SV006", HoTen = "Hoàng Quốc Huy",    MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 7.4 },
                new SinhVien { MaSV = "SV007", HoTen = "Võ Gia Khang",      MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 3.9 },
                new SinhVien { MaSV = "SV008", HoTen = "Đặng Minh Khôi",    MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 5.5 },
                new SinhVien { MaSV = "SV009", HoTen = "Bùi Thảo Linh",     MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 8.0 },
                new SinhVien { MaSV = "SV010", HoTen = "Lương Thanh Giang", MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 7.4 },

                new SinhVien { MaSV = "SV011", HoTen = "Ngô Tuấn Minh",     MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 6.0 },
                new SinhVien { MaSV = "SV012", HoTen = "Đỗ Bảo Ngọc",       MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 9.3 },
                new SinhVien { MaSV = "SV013", HoTen = "Huỳnh Gia Phúc",    MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 4.2 },
                new SinhVien { MaSV = "SV014", HoTen = "Mai Anh Thư",       MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 7.8 },
                new SinhVien { MaSV = "SV015", HoTen = "Trịnh Hoài Nam",    MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 2.5 }
            };
        }

        // 3. LOAD COMBOBOX
        private void LoadComboBox()
        {
            var mucTatCa = new[] { new { MaLop = "", TenLop = TAT_CA_LOP } };

            var dsLop = mucTatCa
                .Concat(danhSachSinhVien
                    .Select(sv => new { sv.MaLop, sv.TenLop })
                    .Distinct()
                    .OrderBy(lop => lop.MaLop))
                .ToList();

            cboLop.DataSource = dsLop;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";

            cboKetQua.Items.Clear();
            cboKetQua.Items.AddRange(new object[] { TAT_CA, DAT, KHONG_DAT });
            cboKetQua.SelectedIndex = 0;

            cboSapXep.Items.Clear();
            cboSapXep.Items.AddRange(new object[] { SX_DIEM_GIAM, SX_DIEM_TANG, SX_HO_TEN, SX_MA_SV });
            cboSapXep.SelectedIndex = 0;
        }

        // 4. XEM BÁO CÁO = LỌC + SẮP XẾP + HIỂN THỊ + THỐNG KÊ
        private void XemBaoCao(bool hienThongBaoNeuRong)
        {
            List<SinhVien> ketQuaLoc = LocDuLieu();

            // Select kèm chỉ số để đánh STT
            var baoCao = ketQuaLoc
                .Select((sv, index) => new
                {
                    STT = index + 1,
                    sv.MaSV,
                    sv.HoTen,
                    sv.TenLop,
                    sv.Diem,
                    sv.KetQua
                })
                .ToList();

            dgvBaoCao.DataSource = baoCao;
            DinhDangLuoiBaoCao();

            string ketQua = cboKetQua.SelectedItem?.ToString() ?? TAT_CA;
            lblTieuDe.Text = $"BÁO CÁO SINH VIÊN - {cboLop.Text} - Kết quả: {ketQua}";

            CapNhatThongKe(ketQuaLoc);

            if (baoCao.Count == 0 && hienThongBaoNeuRong)
            {
                MessageBox.Show("Không có dữ liệu phù hợp với điều kiện lọc.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private List<SinhVien> LocDuLieu()
        {
            string maLop = cboLop.SelectedValue?.ToString() ?? "";
            string ketQua = cboKetQua.SelectedItem?.ToString() ?? TAT_CA;
            string kieuSapXep = cboSapXep.SelectedItem?.ToString() ?? SX_DIEM_GIAM;
            string tuKhoa = txtTuKhoa.Text.Trim().ToLower();

            IEnumerable<SinhVien> query = danhSachSinhVien;

            // Lọc theo lớp (rỗng = tất cả lớp)
            if (!string.IsNullOrEmpty(maLop))
            {
                query = query.Where(sv => sv.MaLop == maLop);
            }

            // Lọc theo kết quả
            if (ketQua == DAT)
            {
                query = query.Where(sv => sv.Diem >= DIEM_DAT);
            }
            else if (ketQua == KHONG_DAT)
            {
                query = query.Where(sv => sv.Diem < DIEM_DAT);
            }

            // Lọc theo từ khóa (mã SV hoặc họ tên)
            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                query = query.Where(sv =>
                    sv.MaSV.ToLower().Contains(tuKhoa) ||
                    sv.HoTen.ToLower().Contains(tuKhoa));
            }

            // Sắp xếp
            IOrderedEnumerable<SinhVien> daSapXep;
            switch (kieuSapXep)
            {
                case SX_DIEM_TANG:
                    daSapXep = query.OrderBy(sv => sv.Diem).ThenBy(sv => sv.HoTen);
                    break;
                case SX_HO_TEN:
                    daSapXep = query.OrderBy(sv => sv.HoTen);
                    break;
                case SX_MA_SV:
                    daSapXep = query.OrderBy(sv => sv.MaSV);
                    break;
                default:
                    daSapXep = query.OrderByDescending(sv => sv.Diem).ThenBy(sv => sv.HoTen);
                    break;
            }

            return daSapXep.ToList();
        }

        private void DinhDangLuoiBaoCao()
        {
            if (dgvBaoCao.Columns.Count == 0) return;

            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvBaoCao.Columns["STT"].HeaderText = "STT";
            dgvBaoCao.Columns["STT"].FillWeight = 40;
            dgvBaoCao.Columns["STT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvBaoCao.Columns["MaSV"].HeaderText = "Mã SV";
            dgvBaoCao.Columns["MaSV"].FillWeight = 80;

            dgvBaoCao.Columns["HoTen"].HeaderText = "Họ tên";
            dgvBaoCao.Columns["HoTen"].FillWeight = 140;

            dgvBaoCao.Columns["TenLop"].HeaderText = "Lớp";
            dgvBaoCao.Columns["TenLop"].FillWeight = 100;

            dgvBaoCao.Columns["Diem"].HeaderText = "Điểm";
            dgvBaoCao.Columns["Diem"].DefaultCellStyle.Format = "0.0";
            dgvBaoCao.Columns["Diem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvBaoCao.Columns["KetQua"].HeaderText = "Kết quả";
            dgvBaoCao.Columns["KetQua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dgvBaoCao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || !dgvBaoCao.Columns.Contains("KetQua")) return;

            string ketQua = dgvBaoCao.Rows[e.RowIndex].Cells["KetQua"].Value?.ToString();
            if (ketQua == KHONG_DAT)
            {
                e.CellStyle.ForeColor = Color.Red;
            }
        }

        // 5. CẬP NHẬT THỐNG KÊ TRÊN STATUSSTRIP
        private void CapNhatThongKe(List<SinhVien> danhSach)
        {
            int tongSo = danhSach.Count;
            int soDat = danhSach.Count(sv => sv.Diem >= DIEM_DAT);
            int soKhongDat = danhSach.Count(sv => sv.Diem < DIEM_DAT);

            double diemTB = tongSo > 0 ? danhSach.Average(sv => sv.Diem) : 0;

            lblTongSo.Text = $"Tổng số SV: {tongSo}";
            lblSoDat.Text = $"Đạt: {soDat}";
            lblSoKhongDat.Text = $"Không đạt: {soKhongDat}";
            lblDiemTB.Text = $"Điểm TB: {diemTB:0.00}";
        }

        // 6. THỐNG KÊ THEO LỚP
        private void ThongKeTheoLop()
        {
            var thongKe = danhSachSinhVien
                .GroupBy(sv => new { sv.MaLop, sv.TenLop })
                .OrderBy(g => g.Key.MaLop)
                .Select((g, index) => new
                {
                    STT = index + 1,
                    g.Key.MaLop,
                    g.Key.TenLop,
                    SoLuong = g.Count(),
                    SoDat = g.Count(sv => sv.Diem >= DIEM_DAT),
                    SoKhongDat = g.Count(sv => sv.Diem < DIEM_DAT),
                    DiemTrungBinh = Math.Round(g.Average(sv => sv.Diem), 2)
                })
                .ToList();

            dgvBaoCao.DataSource = thongKe;

            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaoCao.Columns["STT"].HeaderText = "STT";
            dgvBaoCao.Columns["STT"].FillWeight = 40;
            dgvBaoCao.Columns["MaLop"].HeaderText = "Mã lớp";
            dgvBaoCao.Columns["TenLop"].HeaderText = "Tên lớp";
            dgvBaoCao.Columns["SoLuong"].HeaderText = "Số lượng SV";
            dgvBaoCao.Columns["SoDat"].HeaderText = "Số đạt";
            dgvBaoCao.Columns["SoKhongDat"].HeaderText = "Số không đạt";
            dgvBaoCao.Columns["DiemTrungBinh"].HeaderText = "Điểm TB";
            foreach (DataGridViewColumn cot in dgvBaoCao.Columns)
            {
                cot.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            lblTieuDe.Text = "THỐNG KÊ SINH VIÊN THEO LỚP";
            CapNhatThongKe(danhSachSinhVien);
        }

        // 7. XUẤT FILE
        private void XuatFile()
        {
            if (dgvBaoCao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV file (*.csv)|*.csv|Text file (*.txt)|*.txt";
                sfd.FileName = "BaoCaoSinhVien";
                sfd.DefaultExt = "csv";
                sfd.AddExtension = true;

                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    bool laCsv = Path.GetExtension(sfd.FileName).ToLower() == ".csv";
                    string phanCach = laCsv ? "," : "\t";

                    var cotHienThi = dgvBaoCao.Columns.Cast<DataGridViewColumn>().ToList();

                    string dongTieuDe = string.Join(phanCach,
                        cotHienThi.Select(c => EscapeCsv(c.HeaderText, laCsv)));

                    var cacDong = dgvBaoCao.Rows.Cast<DataGridViewRow>()
                        .Where(r => !r.IsNewRow)
                        .Select(r => string.Join(phanCach,
                            cotHienThi.Select(c => EscapeCsv(r.Cells[c.Index].FormattedValue?.ToString() ?? "", laCsv))));

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(lblTieuDe.Text);
                    sb.AppendLine(dongTieuDe);
                    foreach (string dong in cacDong)
                    {
                        sb.AppendLine(dong);
                    }
                    sb.AppendLine();
                    sb.AppendLine($"{lblTongSo.Text}; {lblSoDat.Text}; {lblSoKhongDat.Text}; {lblDiemTB.Text}");

                    File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));

                    MessageBox.Show("Xuất file thành công:\n" + sfd.FileName, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Không ghi được file (có thể file đang được mở):\n" + ex.Message,
                        "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("Không có quyền ghi vào vị trí đã chọn:\n" + ex.Message,
                        "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất file: " + ex.Message,
                        "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        /// <summary>Giá trị có dấu phẩy, nháy kép hoặc xuống dòng thì bọc trong "..." (chuẩn CSV).</summary>
        private static string EscapeCsv(string giaTri, bool laCsv)
        {
            if (!laCsv) return giaTri.Replace("\t", " ");

            if (giaTri.Contains(",") || giaTri.Contains("\"") || giaTri.Contains("\n"))
            {
                return "\"" + giaTri.Replace("\"", "\"\"") + "\"";
            }
            return giaTri;
        }

        // 8. SỰ KIỆN NÚT BẤM
        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            XemBaoCao(true);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeTheoLop();
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            XuatFile();
        }
    }
}