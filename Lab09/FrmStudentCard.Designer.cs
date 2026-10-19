namespace Lab09_InTheSinhVien
{
    partial class FrmStudentCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStudentCard));
            this.grbThongTin = new System.Windows.Forms.GroupBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.cboKhoaHoc = new System.Windows.Forms.ComboBox();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.lblKhoaHoc = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.grbAnh = new System.Windows.Forms.GroupBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.picAnhDaiDien = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dlgChonAnh = new System.Windows.Forms.OpenFileDialog();
            this.grbXemTruoc = new System.Windows.Forms.GroupBox();
            this.pnlXemTruoc = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXemTruocIn = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.docInThe = new System.Drawing.Printing.PrintDocument();
            this.dlgXemTruocIn = new System.Windows.Forms.PrintPreviewDialog();
            this.dlgIn = new System.Windows.Forms.PrintDialog();
            this.grbThongTin.SuspendLayout();
            this.grbAnh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhDaiDien)).BeginInit();
            this.grbXemTruoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbThongTin
            // 
            this.grbThongTin.Controls.Add(this.dtpNgaySinh);
            this.grbThongTin.Controls.Add(this.cboGioiTinh);
            this.grbThongTin.Controls.Add(this.cboKhoa);
            this.grbThongTin.Controls.Add(this.cboKhoaHoc);
            this.grbThongTin.Controls.Add(this.cboLop);
            this.grbThongTin.Controls.Add(this.txtHoTen);
            this.grbThongTin.Controls.Add(this.txtMaSV);
            this.grbThongTin.Controls.Add(this.lblGioiTinh);
            this.grbThongTin.Controls.Add(this.lblNgaySinh);
            this.grbThongTin.Controls.Add(this.lblKhoa);
            this.grbThongTin.Controls.Add(this.lblKhoaHoc);
            this.grbThongTin.Controls.Add(this.lblLop);
            this.grbThongTin.Controls.Add(this.lblHoTen);
            this.grbThongTin.Controls.Add(this.lblMaSV);
            this.grbThongTin.Location = new System.Drawing.Point(12, 12);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Size = new System.Drawing.Size(405, 392);
            this.grbThongTin.TabIndex = 0;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông tin sinh viên";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(20, 333);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(169, 30);
            this.dtpNgaySinh.TabIndex = 14;
            this.dtpNgaySinh.ValueChanged += new System.EventHandler(this.DuLieuThayDoi);
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Location = new System.Drawing.Point(217, 333);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(169, 30);
            this.cboGioiTinh.TabIndex = 13;
            this.cboGioiTinh.SelectedIndexChanged += new System.EventHandler(this.DuLieuThayDoi);
            // 
            // cboKhoa
            // 
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.Location = new System.Drawing.Point(20, 264);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(366, 30);
            this.cboKhoa.TabIndex = 11;
            this.cboKhoa.SelectedIndexChanged += new System.EventHandler(this.DuLieuThayDoi);
            // 
            // cboKhoaHoc
            // 
            this.cboKhoaHoc.FormattingEnabled = true;
            this.cboKhoaHoc.Location = new System.Drawing.Point(217, 194);
            this.cboKhoaHoc.Name = "cboKhoaHoc";
            this.cboKhoaHoc.Size = new System.Drawing.Size(169, 30);
            this.cboKhoaHoc.TabIndex = 10;
            this.cboKhoaHoc.SelectedIndexChanged += new System.EventHandler(this.DuLieuThayDoi);
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(20, 194);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(169, 30);
            this.cboLop.TabIndex = 9;
            this.cboLop.SelectedIndexChanged += new System.EventHandler(this.DuLieuThayDoi);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(20, 128);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(366, 28);
            this.txtHoTen.TabIndex = 8;
            this.txtHoTen.TextChanged += new System.EventHandler(this.DuLieuThayDoi);
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(20, 61);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(366, 28);
            this.txtMaSV.TabIndex = 7;
            this.txtMaSV.TextChanged += new System.EventHandler(this.DuLieuThayDoi);
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(213, 308);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(76, 22);
            this.lblGioiTinh.TabIndex = 6;
            this.lblGioiTinh.Text = "Giới tính";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(16, 308);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(90, 22);
            this.lblNgaySinh.TabIndex = 5;
            this.lblNgaySinh.Text = "Ngày sinh";
            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Location = new System.Drawing.Point(16, 239);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(52, 22);
            this.lblKhoa.TabIndex = 4;
            this.lblKhoa.Text = "Khoa";
            // 
            // lblKhoaHoc
            // 
            this.lblKhoaHoc.AutoSize = true;
            this.lblKhoaHoc.Location = new System.Drawing.Point(213, 169);
            this.lblKhoaHoc.Name = "lblKhoaHoc";
            this.lblKhoaHoc.Size = new System.Drawing.Size(86, 22);
            this.lblKhoaHoc.TabIndex = 3;
            this.lblKhoaHoc.Text = "Khóa học";
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(16, 169);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(40, 22);
            this.lblLop.TabIndex = 2;
            this.lblLop.Text = "Lớp";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(16, 103);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(87, 22);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Họ và tên";
            // 
            // lblMaSV
            // 
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Location = new System.Drawing.Point(16, 36);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Size = new System.Drawing.Size(110, 22);
            this.lblMaSV.TabIndex = 0;
            this.lblMaSV.Text = "Mã sinh viên";
            // 
            // grbAnh
            // 
            this.grbAnh.Controls.Add(this.btnChonAnh);
            this.grbAnh.Controls.Add(this.picAnhDaiDien);
            this.grbAnh.Location = new System.Drawing.Point(13, 411);
            this.grbAnh.Name = "grbAnh";
            this.grbAnh.Size = new System.Drawing.Size(404, 183);
            this.grbAnh.TabIndex = 1;
            this.grbAnh.TabStop = false;
            this.grbAnh.Text = "Ảnh đại diện";
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnChonAnh.Location = new System.Drawing.Point(158, 54);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(217, 47);
            this.btnChonAnh.TabIndex = 1;
            this.btnChonAnh.Text = "Chọn ảnh";
            this.btnChonAnh.UseVisualStyleBackColor = false;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // picAnhDaiDien
            // 
            this.picAnhDaiDien.Location = new System.Drawing.Point(11, 27);
            this.picAnhDaiDien.Name = "picAnhDaiDien";
            this.picAnhDaiDien.Size = new System.Drawing.Size(114, 143);
            this.picAnhDaiDien.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnhDaiDien.TabIndex = 0;
            this.picAnhDaiDien.TabStop = false;
            // 
            // dlgChonAnh
            // 
            this.dlgChonAnh.FileName = "openFileDialog1";
            // 
            // grbXemTruoc
            // 
            this.grbXemTruoc.Controls.Add(this.pnlXemTruoc);
            this.grbXemTruoc.Location = new System.Drawing.Point(436, 12);
            this.grbXemTruoc.Name = "grbXemTruoc";
            this.grbXemTruoc.Size = new System.Drawing.Size(630, 392);
            this.grbXemTruoc.TabIndex = 2;
            this.grbXemTruoc.TabStop = false;
            this.grbXemTruoc.Text = "Xem trước thẻ";
            // 
            // pnlXemTruoc
            // 
            this.pnlXemTruoc.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlXemTruoc.Location = new System.Drawing.Point(15, 27);
            this.pnlXemTruoc.Name = "pnlXemTruoc";
            this.pnlXemTruoc.Size = new System.Drawing.Size(600, 347);
            this.pnlXemTruoc.TabIndex = 0;
            this.pnlXemTruoc.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlXemTruoc_Paint);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLamMoi.Location = new System.Drawing.Point(451, 428);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(132, 42);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXemTruocIn
            // 
            this.btnXemTruocIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnXemTruocIn.Location = new System.Drawing.Point(602, 428);
            this.btnXemTruocIn.Name = "btnXemTruocIn";
            this.btnXemTruocIn.Size = new System.Drawing.Size(132, 42);
            this.btnXemTruocIn.TabIndex = 4;
            this.btnXemTruocIn.Text = "Xem trước in";
            this.btnXemTruocIn.UseVisualStyleBackColor = false;
            this.btnXemTruocIn.Click += new System.EventHandler(this.btnXemTruocIn_Click);
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnIn.Location = new System.Drawing.Point(754, 428);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(132, 42);
            this.btnIn.TabIndex = 5;
            this.btnIn.Text = "In thẻ";
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnThoat.Location = new System.Drawing.Point(907, 428);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(132, 42);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dlgXemTruocIn
            // 
            this.dlgXemTruocIn.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.dlgXemTruocIn.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.dlgXemTruocIn.ClientSize = new System.Drawing.Size(400, 300);
            this.dlgXemTruocIn.Enabled = true;
            this.dlgXemTruocIn.Icon = ((System.Drawing.Icon)(resources.GetObject("dlgXemTruocIn.Icon")));
            this.dlgXemTruocIn.Name = "dlgXemTruocIn";
            this.dlgXemTruocIn.Visible = false;
            // 
            // dlgIn
            // 
            this.dlgIn.UseEXDialog = true;
            // 
            // FrmStudentCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1078, 606);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnXemTruocIn);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.grbXemTruoc);
            this.Controls.Add(this.grbAnh);
            this.Controls.Add(this.grbThongTin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmStudentCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thiết kế và in thẻ sinh viên";
            this.Load += new System.EventHandler(this.FrmStudentCard_Load);
            this.grbThongTin.ResumeLayout(false);
            this.grbThongTin.PerformLayout();
            this.grbAnh.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAnhDaiDien)).EndInit();
            this.grbXemTruoc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.Label lblKhoaHoc;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.ComboBox cboKhoaHoc;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.GroupBox grbAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.PictureBox picAnhDaiDien;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.OpenFileDialog dlgChonAnh;
        private System.Windows.Forms.GroupBox grbXemTruoc;
        private System.Windows.Forms.Panel pnlXemTruoc;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXemTruocIn;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnThoat;
        private System.Drawing.Printing.PrintDocument docInThe;
        private System.Windows.Forms.PrintPreviewDialog dlgXemTruocIn;
        private System.Windows.Forms.PrintDialog dlgIn;
    }
}

