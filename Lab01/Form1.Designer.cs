namespace UNGDUNGTHONGTINCANHAN
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new Label();

            this.lblHoTen = new Label();
            this.txtHoTen = new TextBox();

            this.lblNamSinh = new Label();
            this.txtNamSinh = new TextBox();

            this.lblEmail = new Label();
            this.txtEmail = new TextBox();

            this.grpGioiTinh = new GroupBox();
            this.radNam = new RadioButton();
            this.radNu = new RadioButton();

            this.lblKhoa = new Label();
            this.cboKhoa = new ComboBox();

            this.btnHienThi = new Button();
            this.btnXoa = new Button();
            this.btnThoat = new Button();

            this.txtKetQua = new TextBox();

            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Text = "ỨNG DỤNG THÔNG TIN CÁ NHÂN SINH VIÊN";
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Size = new Size(440, 35);

            // lblHoTen + txtHoTen
            this.lblHoTen.Text = "Họ tên:";
            this.lblHoTen.Location = new Point(30, 70);
            this.lblHoTen.Size = new Size(100, 23);

            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Location = new Point(150, 67);
            this.txtHoTen.Size = new Size(300, 23);

            // lblNamSinh + txtNamSinh
            this.lblNamSinh.Text = "Năm sinh:";
            this.lblNamSinh.Location = new Point(30, 105);
            this.lblNamSinh.Size = new Size(100, 23);

            this.txtNamSinh.Name = "txtNamSinh";
            this.txtNamSinh.Location = new Point(150, 102);
            this.txtNamSinh.Size = new Size(300, 23);

            // lblEmail + txtEmail
            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new Point(30, 140);
            this.lblEmail.Size = new Size(100, 23);

            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Location = new Point(150, 137);
            this.txtEmail.Size = new Size(300, 23);

            // grpGioiTinh
            this.grpGioiTinh.Text = "Giới tính";
            this.grpGioiTinh.Location = new Point(30, 175);
            this.grpGioiTinh.Size = new Size(200, 50);

            this.radNam.Name = "radNam";
            this.radNam.Text = "Nam";
            this.radNam.Location = new Point(15, 20);
            this.radNam.Size = new Size(70, 24);

            this.radNu.Name = "radNu";
            this.radNu.Text = "Nữ";
            this.radNu.Location = new Point(100, 20);
            this.radNu.Size = new Size(70, 24);

            this.grpGioiTinh.Controls.Add(this.radNam);
            this.grpGioiTinh.Controls.Add(this.radNu);

            // lblKhoa + cboKhoa
            this.lblKhoa.Text = "Khoa/Lớp:";
            this.lblKhoa.Location = new Point(250, 185);
            this.lblKhoa.Size = new Size(80, 23);

            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Location = new Point(340, 182);
            this.cboKhoa.Size = new Size(160, 23);
            this.cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboKhoa.Items.AddRange(new object[] {
                "Công nghệ thông tin",
                "Kinh tế",
                "Ngôn ngữ Anh",
                "Kỹ thuật phần mềm"
            });

            // btnHienThi, btnXoa, btnThoat
            this.btnHienThi.Text = "Hiển thị";
            this.btnHienThi.Location = new Point(30, 240);
            this.btnHienThi.Size = new Size(130, 32);
            this.btnHienThi.Click += new EventHandler(this.btnHienThi_Click);

            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new Point(185, 240);
            this.btnXoa.Size = new Size(130, 32);
            this.btnXoa.Click += new EventHandler(this.btnXoa_Click);

            this.btnThoat.Text = "Thoát";
            this.btnThoat.Location = new Point(340, 240);
            this.btnThoat.Size = new Size(130, 32);
            this.btnThoat.Click += new EventHandler(this.btnThoat_Click);

            // txtKetQua
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Location = new Point(30, 285);
            this.txtKetQua.Size = new Size(440, 140);
            this.txtKetQua.Multiline = true;
            this.txtKetQua.ReadOnly = true;
            this.txtKetQua.ScrollBars = ScrollBars.Vertical;
            this.txtKetQua.Font = new Font("Consolas", 10F);

            // Form1
            this.ClientSize = new Size(490, 450);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblNamSinh);
            this.Controls.Add(this.txtNamSinh);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.grpGioiTinh);
            this.Controls.Add(this.lblKhoa);
            this.Controls.Add(this.cboKhoa);
            this.Controls.Add(this.btnHienThi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.txtKetQua);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Thông tin cá nhân sinh viên";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblNamSinh;
        private TextBox txtNamSinh;
        private Label lblEmail;
        private TextBox txtEmail;
        private GroupBox grpGioiTinh;
        private RadioButton radNam;
        private RadioButton radNu;
        private Label lblKhoa;
        private ComboBox cboKhoa;
        private Button btnHienThi;
        private Button btnXoa;
        private Button btnThoat;
        private TextBox txtKetQua;
    }
}
