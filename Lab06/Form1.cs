using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProductManager
{
    public partial class FrmProduct : Form
    {
        // danh sách sản phẩm lưu trong bộ nhớ
        BindingList<Product> danhSach = new BindingList<Product>();
        BindingSource bs = new BindingSource();
        ErrorProvider epLoi = new ErrorProvider();
        string duongDanAnh = "";

        public FrmProduct()
        {
            InitializeComponent();

            this.Load += FrmProduct_Load;
            tsbThem.Click += tsbThem_Click;
            tsbSua.Click += tsbSua_Click;
            tsbXoa.Click += tsbXoa_Click;
            tsbLamMoi.Click += tsbLamMoi_Click;
            tsbTimKiem.Click += tsbTimKiem_Click;
            btnChonAnh.Click += btnChonAnh_Click;
            mnuSua.Click += suaMenu_Click;
            mnuXoa.Click += tsbXoa_Click;
            mnuXemChiTiet.Click += xemChiTiet_Click;
            dgvProducts.CellClick += dgvProducts_CellClick;
            dgvProducts.CellMouseDown += dgvProducts_CellMouseDown;
            dgvProducts.CellFormatting += dgvProducts_CellFormatting;
        }

        // load form
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            //loai san pham
            cboLoaiSP.Items.Clear();
            cboLoaiSP.Items.Add("Điện tử");
            cboLoaiSP.Items.Add("Văn phòng");
            cboLoaiSP.Items.Add("Gia dụng");
            cboLoaiSP.Items.Add("Thời trang");
            cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;

            numDonGia.DecimalPlaces = 0;
            numDonGia.ThousandsSeparator = true;
            numDonGia.Maximum = 1000000000;
            numSoLuong.Maximum = 100000;

            ptbAnh.SizeMode = PictureBoxSizeMode.Zoom;
            ptbAnh.BorderStyle = BorderStyle.FixedSingle;

            // cau hinh DataGridView
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.ReadOnly = true;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.MultiSelect = false;
            dgvProducts.ContextMenuStrip = cms;

            colMaSP.DataPropertyName = "MaSP";
            colTenSP.DataPropertyName = "TenSP";
            colLoaiSP.DataPropertyName = "LoaiSP";
            colDonGia.DataPropertyName = "DonGia";
            colSoLuong.DataPropertyName = "SoLuong";
            colNgayNhap.DataPropertyName = "NgayNhap";
            colConKD.DataPropertyName = "ConKinhDoanh";
            colDonGia.DefaultCellStyle.Format = "N0";
            colNgayNhap.DefaultCellStyle.Format = "dd/MM/yyyy";

            // dữ liệu mẫu
            danhSach.Add(new Product { MaSP = "SP001", TenSP = "Laptop Dell", LoaiSP = "Điện tử", DonGia = 15000000, SoLuong = 10, NgayNhap = DateTime.Today.AddDays(-30), ConKinhDoanh = true, DuongDanAnh = "" });
            danhSach.Add(new Product { MaSP = "SP002", TenSP = "Bút bi Thiên Long", LoaiSP = "Văn phòng", DonGia = 5000, SoLuong = 200, NgayNhap = DateTime.Today.AddDays(-10), ConKinhDoanh = true, DuongDanAnh = "" });
            danhSach.Add(new Product { MaSP = "SP003", TenSP = "Nồi cơm điện", LoaiSP = "Gia dụng", DonGia = 850000, SoLuong = 25, NgayNhap = DateTime.Today.AddDays(-5), ConKinhDoanh = false, DuongDanAnh = "" });

            TaoMenu();
            HienThiTatCa();
            ClearInput();
            UpdateStatus("Sẵn sàng");
        }

        private void TaoMenu()
        {
            ToolStripMenuItem mThem = new ToolStripMenuItem("Thêm", null, tsbThem_Click);
            mThem.ShortcutKeys = Keys.Control | Keys.N;
            ToolStripMenuItem mSua = new ToolStripMenuItem("Sửa", null, tsbSua_Click);
            mSua.ShortcutKeys = Keys.F2;
            ToolStripMenuItem mXoa = new ToolStripMenuItem("Xóa", null, tsbXoa_Click);
            mXoa.ShortcutKeys = Keys.Control | Keys.D;
            ToolStripMenuItem mLamMoi = new ToolStripMenuItem("Làm mới", null, tsbLamMoi_Click);
            mLamMoi.ShortcutKeys = Keys.F5;
            quảnLýToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mThem, mSua, mXoa, mLamMoi });

            ToolStripMenuItem mThoat = new ToolStripMenuItem("Thoát", null, mThoat_Click);
            fileToolStripMenuItem.DropDownItems.Add(mThoat);

            ToolStripMenuItem mGioiThieu = new ToolStripMenuItem("Giới thiệu", null, mGioiThieu_Click);
            trợGiúpToolStripMenuItem.DropDownItems.Add(mGioiThieu);
        }

        private void mThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mGioiThieu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Quản lý sản phẩm - Lab 05\nMôn: Lập trình trên Windows", "Giới thiệu");
        }

        // Thêm
        private void tsbThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(null)) return;

            Product sp = new Product();
            GanDuLieu(sp);
            danhSach.Add(sp);

            HienThiTatCa();
            ClearInput();
            UpdateStatus("Đã thêm sản phẩm " + sp.MaSP);
        }

        // sửa
        // Cách dùng: click vào 1 dòng -> dữ liệu lên form -> chỉnh -> bấm nút Sửa
        private void tsbSua_Click(object sender, EventArgs e)
        {
            Product sp = LayDongDangChon();
            if (sp == null)
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để sửa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInput(sp)) return;

            GanDuLieu(sp);
            HienThiTatCa();
            UpdateStatus("Đã cập nhật sản phẩm " + sp.MaSP);
        }

        // sửa trong menu chuột phải
        private void suaMenu_Click(object sender, EventArgs e)
        {
            Product sp = LayDongDangChon();
            if (sp == null)
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            LoadProductToForm(sp);
            txtTenSP.Focus();
            UpdateStatus("Chỉnh sửa xong thì bấm nút Sửa trên thanh công cụ");
        }

        // xóa
        private void tsbXoa_Click(object sender, EventArgs e)
        {
            Product sp = LayDongDangChon();
            if (sp == null)
            {
                MessageBox.Show("Bạn chưa chọn dòng nào để xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult kq = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm " + sp.TenSP + " không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No) return;

            danhSach.Remove(sp);
            HienThiTatCa();
            ClearInput();
            UpdateStatus("Đã xóa sản phẩm " + sp.MaSP);
        }

        // tìm kiếm
        // gõ mã hoặc tên vào ô Mã SP / Tên SP rồi bấm Tìm kiếm
        private void tsbTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (tuKhoa == "")
            {
                MessageBox.Show("Hãy nhập mã hoặc tên sản phẩm vào ô Mã SP hoặc Tên SP rồi bấm Tìm kiếm.", "Thông báo");
                return;
            }

            tuKhoa = tuKhoa.ToLower();
            BindingList<Product> ketQua = new BindingList<Product>();
            foreach (Product p in danhSach)
            {
                if (p.MaSP.ToLower().Contains(tuKhoa) || p.TenSP.ToLower().Contains(tuKhoa))
                {
                    ketQua.Add(p);
                }
            }

            bs.DataSource = ketQua;
            dgvProducts.ClearSelection();
            UpdateStatus("Tìm thấy " + ketQua.Count + " sản phẩm");
        }

        // làm mới: xóa trắng các ô nhập, hiện lại toàn bộ danh sách
        private void tsbLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            HienThiTatCa();
            UpdateStatus("Đã làm mới");
        }

        // xem chi tiết 
        private void xemChiTiet_Click(object sender, EventArgs e)
        {
            Product sp = LayDongDangChon();
            if (sp == null)
            {
                MessageBox.Show("Bạn chưa chọn dòng nào!", "Thông báo");
                return;
            }

            string tt = sp.ConKinhDoanh ? "Còn kinh doanh" : "Ngừng kinh doanh";
            string thongTin = "Mã SP: " + sp.MaSP + "\n"
                + "Tên SP: " + sp.TenSP + "\n"
                + "Loại: " + sp.LoaiSP + "\n"
                + "Đơn giá: " + sp.DonGia.ToString("N0") + "\n"
                + "Số lượng: " + sp.SoLuong + "\n"
                + "Ngày nhập: " + sp.NgayNhap.ToString("dd/MM/yyyy") + "\n"
                + "Thành tiền: " + sp.ThanhTien.ToString("N0") + "\n"
                + "Trạng thái: " + tt;
            MessageBox.Show(thongTin, "Chi tiết sản phẩm");
        }

        // chọn ảnh 
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            openFile.Filter = "File ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                duongDanAnh = openFile.FileName;
                ptbAnh.Image = Image.FromFile(duongDanAnh);
                UpdateStatus("Đã chọn ảnh");
            }
        }

        // su kien datagridview
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Product sp = dgvProducts.Rows[e.RowIndex].DataBoundItem as Product;
            if (sp != null) LoadProductToForm(sp);
        }

        private void dgvProducts_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dgvProducts.ClearSelection();
                dgvProducts.Rows[e.RowIndex].Selected = true;
                dgvProducts.CurrentCell = dgvProducts.Rows[e.RowIndex].Cells[0];
            }
        }

        private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProducts.Columns[e.ColumnIndex] == colConKD && e.Value is bool)
            {
                bool conKD = (bool)e.Value;
                e.Value = conKD ? "Còn kinh doanh" : "Ngừng kinh doanh";
                e.FormattingApplied = true;
            }
        }

        // kiểm tra dữ liệu nhập. sp = sản phẩm đang sửa (null nếu đang thêm mới)
        private bool ValidateInput(Product sp)
        {
            epLoi.Clear();
            bool hopLe = true;

            string ma = txtMaSP.Text.Trim();
            if (ma == "")
            {
                epLoi.SetError(txtMaSP, "Mã sản phẩm không được để trống");
                hopLe = false;
            }
            else
            {
                // kiểm tra trùng mã (bỏ qua chính sản phẩm đang sửa)
                foreach (Product p in danhSach)
                {
                    if (p != sp && p.MaSP.ToLower() == ma.ToLower())
                    {
                        epLoi.SetError(txtMaSP, "Mã sản phẩm đã tồn tại");
                        hopLe = false;
                        break;
                    }
                }
            }

            if (txtTenSP.Text.Trim() == "")
            {
                epLoi.SetError(txtTenSP, "Tên sản phẩm không được để trống");
                hopLe = false;
            }

            if (cboLoaiSP.SelectedIndex == -1)
            {
                epLoi.SetError(cboLoaiSP, "Hãy chọn loại sản phẩm");
                hopLe = false;
            }

            if (numDonGia.Value <= 0)
            {
                epLoi.SetError(numDonGia, "Đơn giá phải lớn hơn 0");
                hopLe = false;
            }

            if (numSoLuong.Value < 0)
            {
                epLoi.SetError(numSoLuong, "Số lượng phải lớn hơn hoặc bằng 0");
                hopLe = false;
            }

            if (dtpNgayNhap.Value.Date > DateTime.Today)
            {
                epLoi.SetError(dtpNgayNhap, "Ngày nhập không được lớn hơn ngày hiện tại");
                hopLe = false;
            }

            if (!hopLe)
            {
                MessageBox.Show("Dữ liệu nhập chưa hợp lệ, hãy xem các ô báo lỗi!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UpdateStatus("Dữ liệu không hợp lệ");
            }
            return hopLe;
        }

        // xóa trắng các ô nhập
        private void ClearInput()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtTimKiem.Clear();
            cboLoaiSP.SelectedIndex = -1;
            numDonGia.Value = 0;
            numSoLuong.Value = 0;
            dtpNgayNhap.Value = DateTime.Today;
            chkConKinhDoanh.Checked = true;
            ptbAnh.Image = null;
            duongDanAnh = "";
            epLoi.Clear();
            txtMaSP.Focus();
        }

        // đưa dữ liệu của sản phẩm lên form
        private void LoadProductToForm(Product sp)
        {
            epLoi.Clear();
            txtMaSP.Text = sp.MaSP;
            txtTenSP.Text = sp.TenSP;
            cboLoaiSP.SelectedItem = sp.LoaiSP;
            numDonGia.Value = sp.DonGia;
            numSoLuong.Value = sp.SoLuong;
            dtpNgayNhap.Value = sp.NgayNhap;
            chkConKinhDoanh.Checked = sp.ConKinhDoanh;

            duongDanAnh = sp.DuongDanAnh;
            if (!string.IsNullOrEmpty(duongDanAnh) && File.Exists(duongDanAnh))
                ptbAnh.Image = Image.FromFile(duongDanAnh);
            else
                ptbAnh.Image = null;
        }

        // cập nhật thanh trạng thái
        private void UpdateStatus(string trangThai)
        {
            tstTrangThai.Text = trangThai;
            tstSoLuongSP.Text = "Số lượng sản phẩm: " + danhSach.Count;
        }

        // lấy dữ liệu từ form gán vào sản phẩm
        private void GanDuLieu(Product sp)
        {
            sp.MaSP = txtMaSP.Text.Trim();
            sp.TenSP = txtTenSP.Text.Trim();
            sp.LoaiSP = cboLoaiSP.SelectedItem.ToString();
            sp.DonGia = numDonGia.Value;
            sp.SoLuong = (int)numSoLuong.Value;
            sp.NgayNhap = dtpNgayNhap.Value.Date;
            sp.ConKinhDoanh = chkConKinhDoanh.Checked;
            sp.DuongDanAnh = duongDanAnh;
        }

        // hiện lại toàn bộ danh sách lên lưới
        private void HienThiTatCa()
        {
            bs.DataSource = danhSach;
            dgvProducts.DataSource = bs;
            bs.ResetBindings(false);
            dgvProducts.ClearSelection();
        }

        // lấy sản phẩm ở dòng đang chọn, chưa chọn thì trả về null
        private Product LayDongDangChon()
        {
            if (dgvProducts.SelectedRows.Count == 0) return null;
            return dgvProducts.SelectedRows[0].DataBoundItem as Product;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}