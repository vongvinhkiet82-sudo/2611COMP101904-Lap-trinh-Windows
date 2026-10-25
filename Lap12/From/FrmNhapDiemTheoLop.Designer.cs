namespace QLSinhVienLab12.Forms
{
    partial class FrmNhapDiemTheoLop
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
            this.lblLop = new System.Windows.Forms.Label();
            this.cboLop = new System.Windows.Forms.ComboBox();
            this.cboMonHoc = new System.Windows.Forms.ComboBox();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.btnTaiDanhSach = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.btnLuuTatCa = new System.Windows.Forms.Button();
            this.stsTrangThai = new System.Windows.Forms.StatusStrip();
            this.tslTrangThai = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.stsTrangThai.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(11, 24);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(45, 22);
            this.lblLop.TabIndex = 0;
            this.lblLop.Text = "Lớp:";
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(62, 21);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(264, 30);
            this.cboLop.TabIndex = 1;
            // 
            // cboMonHoc
            // 
            this.cboMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonHoc.FormattingEnabled = true;
            this.cboMonHoc.Location = new System.Drawing.Point(444, 21);
            this.cboMonHoc.Name = "cboMonHoc";
            this.cboMonHoc.Size = new System.Drawing.Size(264, 30);
            this.cboMonHoc.TabIndex = 2;
            // 
            // lblMonHoc
            // 
            this.lblMonHoc.AutoSize = true;
            this.lblMonHoc.Location = new System.Drawing.Point(355, 24);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(83, 22);
            this.lblMonHoc.TabIndex = 3;
            this.lblMonHoc.Text = "Môn học:";
            // 
            // btnTaiDanhSach
            // 
            this.btnTaiDanhSach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTaiDanhSach.Location = new System.Drawing.Point(738, 18);
            this.btnTaiDanhSach.Name = "btnTaiDanhSach";
            this.btnTaiDanhSach.Size = new System.Drawing.Size(140, 34);
            this.btnTaiDanhSach.TabIndex = 4;
            this.btnTaiDanhSach.Text = "Tải danh sách";
            this.btnTaiDanhSach.UseVisualStyleBackColor = false;
            this.btnTaiDanhSach.Click += new System.EventHandler(this.btnTaiDanhSach_Click);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(18, 78);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(87, 22);
            this.lblTimKiem.TabIndex = 5;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(111, 75);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(327, 28);
            this.txtTimKiem.TabIndex = 6;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnThongKe.Location = new System.Drawing.Point(468, 72);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(102, 34);
            this.btnThongKe.TabIndex = 7;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            this.dgvKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKetQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKetQua.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Location = new System.Drawing.Point(22, 126);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.RowHeadersVisible = false;
            this.dgvKetQua.RowHeadersWidth = 51;
            this.dgvKetQua.RowTemplate.Height = 24;
            this.dgvKetQua.Size = new System.Drawing.Size(856, 356);
            this.dgvKetQua.TabIndex = 8;
            this.dgvKetQua.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvKetQua_DataError);
            // 
            // btnLuuTatCa
            // 
            this.btnLuuTatCa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuTatCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLuuTatCa.Location = new System.Drawing.Point(738, 488);
            this.btnLuuTatCa.Name = "btnLuuTatCa";
            this.btnLuuTatCa.Size = new System.Drawing.Size(140, 34);
            this.btnLuuTatCa.TabIndex = 9;
            this.btnLuuTatCa.Text = "Lưu tất cả";
            this.btnLuuTatCa.UseVisualStyleBackColor = false;
            this.btnLuuTatCa.Click += new System.EventHandler(this.btnLuuTatCa_Click);
            // 
            // stsTrangThai
            // 
            this.stsTrangThai.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsTrangThai.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslTrangThai});
            this.stsTrangThai.Location = new System.Drawing.Point(0, 524);
            this.stsTrangThai.Name = "stsTrangThai";
            this.stsTrangThai.Size = new System.Drawing.Size(904, 26);
            this.stsTrangThai.TabIndex = 10;
            this.stsTrangThai.Text = "Trạng thái";
            // 
            // tslTrangThai
            // 
            this.tslTrangThai.Name = "tslTrangThai";
            this.tslTrangThai.Size = new System.Drawing.Size(68, 20);
            this.tslTrangThai.Text = "Sẵn sàng";
            // 
            // FrmNhapDiemTheoLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(904, 550);
            this.Controls.Add(this.stsTrangThai);
            this.Controls.Add(this.btnLuuTatCa);
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.btnTaiDanhSach);
            this.Controls.Add(this.lblMonHoc);
            this.Controls.Add(this.cboMonHoc);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.lblLop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmNhapDiemTheoLop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập điểm theo lớp";
            this.Load += new System.EventHandler(this.FrmNhapDiemTheoLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.stsTrangThai.ResumeLayout(false);
            this.stsTrangThai.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.ComboBox cboMonHoc;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.Button btnTaiDanhSach;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.Button btnLuuTatCa;
        private System.Windows.Forms.StatusStrip stsTrangThai;
        private System.Windows.Forms.ToolStripStatusLabel tslTrangThai;
    }
}

