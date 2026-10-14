using ShopManagerMini.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManagerMini
{
    public partial class FrmCustomer : Form
    {

        public FrmCustomer()
        {
            InitializeComponent();

            Load += FrmCustomer_Load;
            btnThemKH.Click += btnThemKH_Click;
            btnSuaKH.Click += btnSuaKH_Click;
            btnXoaKH.Click += btnXoaKH_Click;
            dgvKhachHang.SelectionChanged += dgvKhachHang_SelectionChanged;
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            cboLoaiKH.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiKH.Items.Clear();
            cboLoaiKH.Items.AddRange(new object[] { "Thường", "Thân thiết", "VIP" });

            SetupGrid();
            RefreshGrid();
            ClearInputs();
        }

        // Grid

        private void SetupGrid()
        {
            dgvKhachHang.AutoGenerateColumns = false;
            dgvKhachHang.Columns.Clear();
            dgvKhachHang.Columns.Add(MakeColumn("colMaKH", "Mã KH", "Id"));
            dgvKhachHang.Columns.Add(MakeColumn("colTenKH", "Họ tên", "FullName"));
            dgvKhachHang.Columns.Add(MakeColumn("colSDT", "Số điện thoại", "Phone"));
            dgvKhachHang.Columns.Add(MakeColumn("colLoaiKH", "Loại khách hàng", "CustomerType"));

            dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.AllowUserToDeleteRows = false;
            dgvKhachHang.MultiSelect = false;
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.RowHeadersVisible = false;
        }

        private static DataGridViewTextBoxColumn MakeColumn(string name, string header, string property)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = property
            };
        }

        private void RefreshGrid()
        {
            dgvKhachHang.DataSource = new BindingList<Customer>(Program.Customers.ToList());
            dgvKhachHang.ClearSelection();
        }

        private Customer GetSelectedCustomer()
        {
            if (dgvKhachHang.SelectedRows.Count == 0) return null;
            return dgvKhachHang.SelectedRows[0].DataBoundItem as Customer;
        }

        private void dgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            Customer c = GetSelectedCustomer();
            if (c == null) return;

            txtMaKH.Text = c.Id;
            txtTenKH.Text = c.FullName;
            txtSDT.Text = c.Phone;
            cboLoaiKH.SelectedItem = c.CustomerType;
        }

        private void ClearInputs()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            cboLoaiKH.SelectedIndex = -1;
        }


        private bool ValidateInput(out string id, out string name, out string phone, out string type)
        {
            id = txtMaKH.Text.Trim();
            name = txtTenKH.Text.Trim();
            phone = txtSDT.Text.Trim();
            type = cboLoaiKH.SelectedItem as string;

            if (id.Length == 0) { Warn("Vui lòng nhập mã khách hàng.", txtMaKH); return false; }
            if (name.Length == 0) { Warn("Vui lòng nhập họ tên khách hàng.", txtTenKH); return false; }
            if (phone.Length == 0) { Warn("Vui lòng nhập số điện thoại.", txtSDT); return false; }
            if (!Regex.IsMatch(phone, @"^0\d{9}$"))
            {
                Warn("Số điện thoại không hợp lệ (gồm 10 chữ số, bắt đầu bằng 0).", txtSDT);
                return false;
            }
            if (string.IsNullOrEmpty(type)) { Warn("Vui lòng chọn loại khách hàng.", cboLoaiKH); return false; }
            return true;
        }

        private void Warn(string message, Control focus)
        {
            MessageBox.Show(message, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focus.Focus();
        }

        // buttons

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            string id, name, phone, type;
            if (!ValidateInput(out id, out name, out phone, out type)) return;

            if (Program.Customers.Any(c => c.Id.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã khách hàng \"" + id + "\" đã tồn tại!", "Trùng mã",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaKH.Focus();
                return;
            }

            Program.Customers.Add(new Customer(id, name, phone, type));
            RefreshGrid();
            ClearInputs();
            MessageBox.Show("Thêm khách hàng thành công.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            Customer selected = GetSelectedCustomer();
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa trong danh sách.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string id, name, phone, type;
            if (!ValidateInput(out id, out name, out phone, out type)) return;

            if (!id.Equals(selected.Id, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không được thay đổi mã khách hàng khi sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Text = selected.Id;
                return;
            }

            selected.FullName = name;
            selected.Phone = phone;
            selected.CustomerType = type;

            RefreshGrid();
            ClearInputs();
            MessageBox.Show("Cập nhật khách hàng thành công.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            Customer selected = GetSelectedCustomer();
            if (selected == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa trong danh sách.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa khách hàng \"" + selected.FullName + "\" không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            Program.Customers.Remove(selected);
            RefreshGrid();
            ClearInputs();
        }
    }
}
