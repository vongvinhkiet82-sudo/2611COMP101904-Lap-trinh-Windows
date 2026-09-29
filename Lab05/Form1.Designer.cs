namespace Lab05_Đăng_ký_khóa_học
{
    partial class Dangkykhoahoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDangKyKhoaHoc = new System.Windows.Forms.Label();
            this.grbHocVien = new System.Windows.Forms.GroupBox();
            this.lblNhanemail = new System.Windows.Forms.Label();
            this.chkNhanEmail = new System.Windows.Forms.CheckBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblDemKyTu = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.grbKhoaHoc = new System.Windows.Forms.GroupBox();
            this.lblTien = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblHocPhi = new System.Windows.Forms.Label();
            this.lblHocPhiThang = new System.Windows.Forms.Label();
            this.numSoThang = new System.Windows.Forms.NumericUpDown();
            this.lblSoThang = new System.Windows.Forms.Label();
            this.radTrucTiep = new System.Windows.Forms.RadioButton();
            this.radOnline = new System.Windows.Forms.RadioButton();
            this.lblHinhThucHoc = new System.Windows.Forms.Label();
            this.cboKhoaHoc = new System.Windows.Forms.ComboBox();
            this.lblKhoaHoc = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.grbHocVien.SuspendLayout();
            this.grbKhoaHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoThang)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDangKyKhoaHoc
            // 
            this.lblDangKyKhoaHoc.AutoSize = true;
            this.lblDangKyKhoaHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangKyKhoaHoc.ForeColor = System.Drawing.Color.Green;
            this.lblDangKyKhoaHoc.Location = new System.Drawing.Point(303, 32);
            this.lblDangKyKhoaHoc.Name = "lblDangKyKhoaHoc";
            this.lblDangKyKhoaHoc.Size = new System.Drawing.Size(475, 32);
            this.lblDangKyKhoaHoc.TabIndex = 0;
            this.lblDangKyKhoaHoc.Text = "ĐĂNG KÝ KHÓA HỌC NGẮN HẠN";
            // 
            // grbHocVien
            // 
            this.grbHocVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grbHocVien.Controls.Add(this.lblNhanemail);
            this.grbHocVien.Controls.Add(this.chkNhanEmail);
            this.grbHocVien.Controls.Add(this.dtpNgaySinh);
            this.grbHocVien.Controls.Add(this.lblNgaySinh);
            this.grbHocVien.Controls.Add(this.txtSoDienThoai);
            this.grbHocVien.Controls.Add(this.lblSDT);
            this.grbHocVien.Controls.Add(this.lblDemKyTu);
            this.grbHocVien.Controls.Add(this.txtHoTen);
            this.grbHocVien.Controls.Add(this.lblHoTen);
            this.grbHocVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbHocVien.Location = new System.Drawing.Point(39, 104);
            this.grbHocVien.Name = "grbHocVien";
            this.grbHocVien.Size = new System.Drawing.Size(486, 294);
            this.grbHocVien.TabIndex = 1;
            this.grbHocVien.TabStop = false;
            this.grbHocVien.Text = "Thông tin học viên";
            // 
            // lblNhanemail
            // 
            this.lblNhanemail.AutoSize = true;
            this.lblNhanemail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhanemail.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblNhanemail.Location = new System.Drawing.Point(130, 219);
            this.lblNhanemail.Name = "lblNhanemail";
            this.lblNhanemail.Size = new System.Drawing.Size(246, 20);
            this.lblNhanemail.TabIndex = 8;
            this.lblNhanemail.Text = "Không nhận email thông báo";
            // 
            // chkNhanEmail
            // 
            this.chkNhanEmail.AutoSize = true;
            this.chkNhanEmail.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNhanEmail.Location = new System.Drawing.Point(155, 193);
            this.chkNhanEmail.Name = "chkNhanEmail";
            this.chkNhanEmail.Size = new System.Drawing.Size(189, 23);
            this.chkNhanEmail.TabIndex = 7;
            this.chkNhanEmail.Text = "Nhận email thông báo";
            this.chkNhanEmail.UseVisualStyleBackColor = true;
            this.chkNhanEmail.CheckedChanged += new System.EventHandler(this.chkNhanEmail_CheckedChanged);
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(144, 120);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(200, 27);
            this.dtpNgaySinh.TabIndex = 6;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySinh.Location = new System.Drawing.Point(6, 116);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(95, 19);
            this.lblNgaySinh.TabIndex = 5;
            this.lblNgaySinh.Text = "Ngày Sinh :";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(144, 81);
            this.txtSoDienThoai.MaxLength = 10;
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(202, 27);
            this.txtSoDienThoai.TabIndex = 4;
            this.txtSoDienThoai.TextChanged += new System.EventHandler(this.txtSoDienThoai_TextChanged);
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Location = new System.Drawing.Point(50, 85);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(51, 19);
            this.lblSDT.TabIndex = 3;
            this.lblSDT.Text = "SĐT :";
            // 
            // lblDemKyTu
            // 
            this.lblDemKyTu.AutoSize = true;
            this.lblDemKyTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDemKyTu.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblDemKyTu.Location = new System.Drawing.Point(374, 52);
            this.lblDemKyTu.Name = "lblDemKyTu";
            this.lblDemKyTu.Size = new System.Drawing.Size(45, 20);
            this.lblDemKyTu.TabIndex = 2;
            this.lblDemKyTu.Text = "0/50";
            this.lblDemKyTu.Click += new System.EventHandler(this.lblDemKyTu_Click);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(144, 48);
            this.txtHoTen.MaxLength = 50;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(202, 27);
            this.txtHoTen.TabIndex = 1;
            this.txtHoTen.TextChanged += new System.EventHandler(this.txtHoTen_TextChanged);
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.Location = new System.Drawing.Point(30, 52);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(71, 19);
            this.lblHoTen.TabIndex = 0;
            this.lblHoTen.Text = "Họ Tên :";
            // 
            // grbKhoaHoc
            // 
            this.grbKhoaHoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grbKhoaHoc.Controls.Add(this.lblTien);
            this.grbKhoaHoc.Controls.Add(this.lblTongTien);
            this.grbKhoaHoc.Controls.Add(this.lblHocPhi);
            this.grbKhoaHoc.Controls.Add(this.lblHocPhiThang);
            this.grbKhoaHoc.Controls.Add(this.numSoThang);
            this.grbKhoaHoc.Controls.Add(this.lblSoThang);
            this.grbKhoaHoc.Controls.Add(this.radTrucTiep);
            this.grbKhoaHoc.Controls.Add(this.radOnline);
            this.grbKhoaHoc.Controls.Add(this.lblHinhThucHoc);
            this.grbKhoaHoc.Controls.Add(this.cboKhoaHoc);
            this.grbKhoaHoc.Controls.Add(this.lblKhoaHoc);
            this.grbKhoaHoc.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbKhoaHoc.Location = new System.Drawing.Point(578, 104);
            this.grbKhoaHoc.Name = "grbKhoaHoc";
            this.grbKhoaHoc.Size = new System.Drawing.Size(486, 294);
            this.grbKhoaHoc.TabIndex = 2;
            this.grbKhoaHoc.TabStop = false;
            this.grbKhoaHoc.Text = "Thông tin khóa học";
            // 
            // lblTien
            // 
            this.lblTien.AutoSize = true;
            this.lblTien.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTien.ForeColor = System.Drawing.Color.Green;
            this.lblTien.Location = new System.Drawing.Point(210, 207);
            this.lblTien.Name = "lblTien";
            this.lblTien.Size = new System.Drawing.Size(58, 19);
            this.lblTien.TabIndex = 10;
            this.lblTien.Text = "0 VND";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(54, 207);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(86, 19);
            this.lblTongTien.TabIndex = 9;
            this.lblTongTien.Text = "Tổng tiền :";
            // 
            // lblHocPhi
            // 
            this.lblHocPhi.AutoSize = true;
            this.lblHocPhi.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHocPhi.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblHocPhi.Location = new System.Drawing.Point(210, 165);
            this.lblHocPhi.Name = "lblHocPhi";
            this.lblHocPhi.Size = new System.Drawing.Size(58, 19);
            this.lblHocPhi.TabIndex = 8;
            this.lblHocPhi.Text = "0 VND";
            // 
            // lblHocPhiThang
            // 
            this.lblHocPhiThang.AutoSize = true;
            this.lblHocPhiThang.Location = new System.Drawing.Point(9, 165);
            this.lblHocPhiThang.Name = "lblHocPhiThang";
            this.lblHocPhiThang.Size = new System.Drawing.Size(131, 19);
            this.lblHocPhiThang.TabIndex = 7;
            this.lblHocPhiThang.Text = "Học phí / tháng :";
            // 
            // numSoThang
            // 
            this.numSoThang.Location = new System.Drawing.Point(183, 120);
            this.numSoThang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numSoThang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoThang.Name = "numSoThang";
            this.numSoThang.Size = new System.Drawing.Size(67, 27);
            this.numSoThang.TabIndex = 6;
            this.numSoThang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoThang.ValueChanged += new System.EventHandler(this.numSoThang_ValueChanged);
            // 
            // lblSoThang
            // 
            this.lblSoThang.AutoSize = true;
            this.lblSoThang.Location = new System.Drawing.Point(56, 122);
            this.lblSoThang.Name = "lblSoThang";
            this.lblSoThang.Size = new System.Drawing.Size(84, 19);
            this.lblSoThang.TabIndex = 5;
            this.lblSoThang.Text = "Số tháng :";
            // 
            // radTrucTiep
            // 
            this.radTrucTiep.AutoSize = true;
            this.radTrucTiep.Location = new System.Drawing.Point(294, 83);
            this.radTrucTiep.Name = "radTrucTiep";
            this.radTrucTiep.Size = new System.Drawing.Size(95, 23);
            this.radTrucTiep.TabIndex = 4;
            this.radTrucTiep.TabStop = true;
            this.radTrucTiep.Text = "Trực tiếp";
            this.radTrucTiep.UseVisualStyleBackColor = true;
            this.radTrucTiep.CheckedChanged += new System.EventHandler(this.radTrucTiep_CheckedChanged);
            // 
            // radOnline
            // 
            this.radOnline.AutoSize = true;
            this.radOnline.Location = new System.Drawing.Point(183, 83);
            this.radOnline.Name = "radOnline";
            this.radOnline.Size = new System.Drawing.Size(76, 23);
            this.radOnline.TabIndex = 3;
            this.radOnline.TabStop = true;
            this.radOnline.Text = "Online";
            this.radOnline.UseVisualStyleBackColor = true;
            this.radOnline.CheckedChanged += new System.EventHandler(this.radOnline_CheckedChanged);
            // 
            // lblHinhThucHoc
            // 
            this.lblHinhThucHoc.AutoSize = true;
            this.lblHinhThucHoc.Location = new System.Drawing.Point(17, 85);
            this.lblHinhThucHoc.Name = "lblHinhThucHoc";
            this.lblHinhThucHoc.Size = new System.Drawing.Size(123, 19);
            this.lblHinhThucHoc.TabIndex = 2;
            this.lblHinhThucHoc.Text = "Hình thức học :";
            // 
            // cboKhoaHoc
            // 
            this.cboKhoaHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoaHoc.FormattingEnabled = true;
            this.cboKhoaHoc.Location = new System.Drawing.Point(172, 45);
            this.cboKhoaHoc.Name = "cboKhoaHoc";
            this.cboKhoaHoc.Size = new System.Drawing.Size(227, 27);
            this.cboKhoaHoc.TabIndex = 1;
            this.cboKhoaHoc.SelectedIndexChanged += new System.EventHandler(this.cboKhoaHoc_SelectedIndexChanged);
            // 
            // lblKhoaHoc
            // 
            this.lblKhoaHoc.AutoSize = true;
            this.lblKhoaHoc.Location = new System.Drawing.Point(49, 48);
            this.lblKhoaHoc.Name = "lblKhoaHoc";
            this.lblKhoaHoc.Size = new System.Drawing.Size(91, 19);
            this.lblKhoaHoc.TabIndex = 0;
            this.lblKhoaHoc.Text = "Khóa Học :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnLamMoi);
            this.panel1.Controls.Add(this.btnDangKy);
            this.panel1.Location = new System.Drawing.Point(277, 438);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 69);
            this.panel1.TabIndex = 3;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Red;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThoat.Location = new System.Drawing.Point(395, 19);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(106, 32);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.MediumBlue;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLamMoi.Location = new System.Drawing.Point(211, 19);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(106, 32);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.LimeGreen;
            this.btnDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDangKy.Location = new System.Drawing.Point(32, 19);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(106, 32);
            this.btnDangKy.TabIndex = 0;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // Dangkykhoahoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 560);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grbKhoaHoc);
            this.Controls.Add(this.grbHocVien);
            this.Controls.Add(this.lblDangKyKhoaHoc);
            this.Name = "Dangkykhoahoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký khóa học";
            this.Load += new System.EventHandler(this.Dangkykhoahoc_Load);
            this.grbHocVien.ResumeLayout(false);
            this.grbHocVien.PerformLayout();
            this.grbKhoaHoc.ResumeLayout(false);
            this.grbKhoaHoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoThang)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDangKyKhoaHoc;
        private System.Windows.Forms.GroupBox grbHocVien;
        private System.Windows.Forms.GroupBox grbKhoaHoc;
        private System.Windows.Forms.Label lblDemKyTu;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblNhanemail;
        private System.Windows.Forms.CheckBox chkNhanEmail;
        private System.Windows.Forms.Label lblKhoaHoc;
        private System.Windows.Forms.RadioButton radTrucTiep;
        private System.Windows.Forms.RadioButton radOnline;
        private System.Windows.Forms.Label lblHinhThucHoc;
        private System.Windows.Forms.ComboBox cboKhoaHoc;
        private System.Windows.Forms.NumericUpDown numSoThang;
        private System.Windows.Forms.Label lblSoThang;
        private System.Windows.Forms.Label lblHocPhiThang;
        private System.Windows.Forms.Label lblHocPhi;
        private System.Windows.Forms.Label lblTien;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnDangKy;
    }
}

