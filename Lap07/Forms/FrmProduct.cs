using ShopManagerMini.Models;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ShopManagerMini
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();

            Load += FrmProduct_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            dgvSanPham.SelectionChanged += dgvSanPham_SelectionChanged;
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            cboLoaiSP.Items.Clear();
            cboLoaiSP.Items.AddRange(new object[] { "Đồ uống", "Thực phẩm", "Bánh kẹo", "Gia dụng", "Khác" });
            SetupGrid();
            RefreshGrid(null);
            ClearInputs();
        }
        // grid
        private void SetupGrid()
        {
            dgvSanPham.AutoGenerateColumns = false;
            colMaSp.DataPropertyName = "Id";
            colTenSp.DataPropertyName = "Name";
            colLoaiSP.DataPropertyName = "Category";
            colDonGia.DataPropertyName = "Price";
            colSoLuong.DataPropertyName = "Quantity";

            colDonGia.DefaultCellStyle.Format = "N0";
            colDonGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void RefreshGrid(string keyword)
        {
            IEnumerable<Product> data = Program.Products;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                string k = keyword.Trim();
                data = data.Where(p =>
                    Contains(p.Id, k) || Contains(p.Name, k) || Contains(p.Category, k));
            }
            dgvSanPham.DataSource = new BindingList<Product>(data.ToList());
            dgvSanPham.ClearSelection();
        }

        private static bool Contains(string source, string keyword)
        {
            return source != null && source.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private Product GetSelectedProduct()
        {
            if (dgvSanPham.SelectedRows.Count == 0) return null;
            return dgvSanPham.SelectedRows[0].DataBoundItem as Product;
        }

        private void dgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            Product p = GetSelectedProduct();
            if (p == null) return;

            txtId.Text = p.Id;
            txtName.Text = p.Name;
            cboLoaiSP.SelectedItem = p.Category;
            txtDonGia.Text = p.Price.ToString("0.##", CultureInfo.CurrentCulture);
            txtSoLuong.Text = p.Quantity.ToString();
        }

        private void ClearInputs()
        {
            txtId.Clear();
            txtName.Clear();
            cboLoaiSP.SelectedIndex = -1;
            txtDonGia.Clear();
            txtSoLuong.Clear();
        }

        private bool ValidateInput(out string id, out string name, out string category,
                                   out decimal price, out int quantity)
        {
            id = txtId.Text.Trim();
            name = txtName.Text.Trim();
            category = cboLoaiSP.SelectedItem as string;
            price = 0;
            quantity = 0;

            if (id.Length == 0) { Warn("Vui lòng nhập mã sản phẩm.", txtId); return false; }
            if (name.Length == 0) { Warn("Vui lòng nhập tên sản phẩm.", txtName); return false; }
            if (string.IsNullOrEmpty(category)) { Warn("Vui lòng chọn loại sản phẩm.", cboLoaiSP); return false; }

            if (!decimal.TryParse(txtDonGia.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out price))
            {
                Warn("Đơn giá phải là một số hợp lệ.", txtDonGia);
                return false;
            }
            if (price < 0) { Warn("Đơn giá không được âm.", txtDonGia); return false; }

            if (!int.TryParse(txtSoLuong.Text.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture, out quantity))
            {
                Warn("Số lượng phải là một số nguyên hợp lệ.", txtSoLuong);
                return false;
            }
            if (quantity < 0) { Warn("Số lượng không được âm.", txtSoLuong); return false; }

            return true;
        }

        private void Warn(string message, Control focus)
        {
            MessageBox.Show(message, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focus.Focus();
        }

        // buttons

        private void btnThem_Click(object sender, EventArgs e)
        {
            string id, name, category;
            decimal price;
            int quantity;
            if (!ValidateInput(out id, out name, out category, out price, out quantity)) return;

            // Không cho thêm trùng mã
            if (Program.Products.Any(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã sản phẩm \"" + id + "\" đã tồn tại!", "Trùng mã",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtId.Focus();
                return;
            }

            Program.Products.Add(new Product(id, name, category, price, quantity));
            txtTimKiem.Clear();
            RefreshGrid(null);
            ClearInputs();
            MessageBox.Show("Thêm sản phẩm thành công.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Product selected = GetSelectedProduct();
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa trong danh sách.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string id, name, category;
            decimal price;
            int quantity;
            if (!ValidateInput(out id, out name, out category, out price, out quantity)) return;

            if (!id.Equals(selected.Id, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không được thay đổi mã sản phẩm khi sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtId.Text = selected.Id;
                return;
            }

            selected.Name = name;
            selected.Category = category;
            selected.Price = price;
            selected.Quantity = quantity;

            RefreshGrid(txtTimKiem.Text);
            ClearInputs();
            MessageBox.Show("Cập nhật sản phẩm thành công.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Product selected = GetSelectedProduct();
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa trong danh sách.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa sản phẩm \"" + selected.Name + "\" không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            Program.Products.Remove(selected);
            RefreshGrid(txtTimKiem.Text);
            ClearInputs();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            RefreshGrid(null);
            ClearInputs();
            txtId.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            RefreshGrid(txtTimKiem.Text);
            ClearInputs();
            if (dgvSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm phù hợp.", "Kết quả tìm kiếm",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnTimKiem.PerformClick();
            }
        }
    }
}
