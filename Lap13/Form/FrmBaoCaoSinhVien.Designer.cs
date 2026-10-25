namespace StudentReportDemo.Forms
{
    partial class FrmBaoCaoSinhVien
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
            this.lblKetQua = new System.Windows.Forms.Label();
            this.cboKetQua = new System.Windows.Forms.ComboBox();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.lblSapXep = new System.Windows.Forms.Label();
            this.cboSapXep = new System.Windows.Forms.ComboBox();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnXuatfile = new System.Windows.Forms.Button();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.stsThongKe = new System.Windows.Forms.StatusStrip();
            this.lblTongSo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSoDat = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSoKhongDat = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDiemTB = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.stsThongKe.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(30, 25);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(45, 22);
            this.lblLop.TabIndex = 0;
            this.lblLop.Text = "Lớp:";
            // 
            // cboLop
            // 
            this.cboLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLop.FormattingEnabled = true;
            this.cboLop.Location = new System.Drawing.Point(81, 22);
            this.cboLop.Name = "cboLop";
            this.cboLop.Size = new System.Drawing.Size(225, 30);
            this.cboLop.TabIndex = 1;
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(343, 25);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(77, 22);
            this.lblKetQua.TabIndex = 2;
            this.lblKetQua.Text = "Kết quả:";
            // 
            // cboKetQua
            // 
            this.cboKetQua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKetQua.FormattingEnabled = true;
            this.cboKetQua.Location = new System.Drawing.Point(426, 22);
            this.cboKetQua.Name = "cboKetQua";
            this.cboKetQua.Size = new System.Drawing.Size(225, 30);
            this.cboKetQua.TabIndex = 3;
            // 
            // lblTuKhoa
            // 
            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Location = new System.Drawing.Point(763, 25);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(81, 22);
            this.lblTuKhoa.TabIndex = 4;
            this.lblTuKhoa.Text = "Từ khóa:";
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(850, 22);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(274, 28);
            this.txtTuKhoa.TabIndex = 5;
            // 
            // lblSapXep
            // 
            this.lblSapXep.AutoSize = true;
            this.lblSapXep.Location = new System.Drawing.Point(763, 82);
            this.lblSapXep.Name = "lblSapXep";
            this.lblSapXep.Size = new System.Drawing.Size(81, 22);
            this.lblSapXep.TabIndex = 6;
            this.lblSapXep.Text = "Sắp xếp:";
            // 
            // cboSapXep
            // 
            this.cboSapXep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSapXep.FormattingEnabled = true;
            this.cboSapXep.Location = new System.Drawing.Point(850, 79);
            this.cboSapXep.Name = "cboSapXep";
            this.cboSapXep.Size = new System.Drawing.Size(179, 30);
            this.cboSapXep.TabIndex = 7;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnXemBaoCao.Location = new System.Drawing.Point(80, 72);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(125, 42);
            this.btnXemBaoCao.TabIndex = 8;
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = false;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnThongKe.Location = new System.Drawing.Point(270, 72);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(125, 42);
            this.btnThongKe.TabIndex = 9;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnXuatfile
            // 
            this.btnXuatfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnXuatfile.Location = new System.Drawing.Point(460, 72);
            this.btnXuatfile.Name = "btnXuatfile";
            this.btnXuatfile.Size = new System.Drawing.Size(125, 42);
            this.btnXuatfile.TabIndex = 10;
            this.btnXuatfile.Text = "Xuất file";
            this.btnXuatfile.UseVisualStyleBackColor = false;
            this.btnXuatfile.Click += new System.EventHandler(this.btnXuatFile_Click);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTieuDe.Location = new System.Drawing.Point(341, 136);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(255, 32);
            this.lblTieuDe.TabIndex = 11;
            this.lblTieuDe.Text = "Báo cáo sinh viên";
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.AllowUserToAddRows = false;
            this.dgvBaoCao.AllowUserToDeleteRows = false;
            this.dgvBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCao.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCao.Location = new System.Drawing.Point(34, 171);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.RowHeadersVisible = false;
            this.dgvBaoCao.RowHeadersWidth = 51;
            this.dgvBaoCao.RowTemplate.Height = 24;
            this.dgvBaoCao.Size = new System.Drawing.Size(1090, 490);
            this.dgvBaoCao.TabIndex = 12;
            // 
            // stsThongKe
            // 
            this.stsThongKe.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stsThongKe.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTongSo,
            this.lblSoDat,
            this.lblSoKhongDat,
            this.lblDiemTB});
            this.stsThongKe.Location = new System.Drawing.Point(0, 664);
            this.stsThongKe.Name = "stsThongKe";
            this.stsThongKe.Size = new System.Drawing.Size(1167, 26);
            this.stsThongKe.TabIndex = 13;
            this.stsThongKe.Text = "Thống kê";
            // 
            // lblTongSo
            // 
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Size = new System.Drawing.Size(90, 20);
            this.lblTongSo.Text = "Tổng số SV :";
            // 
            // lblSoDat
            // 
            this.lblSoDat.Name = "lblSoDat";
            this.lblSoDat.Size = new System.Drawing.Size(40, 20);
            this.lblSoDat.Text = "Đạt :";
            // 
            // lblSoKhongDat
            // 
            this.lblSoKhongDat.Name = "lblSoKhongDat";
            this.lblSoKhongDat.Size = new System.Drawing.Size(85, 20);
            this.lblSoKhongDat.Text = "Không đạt :";
            // 
            // lblDiemTB
            // 
            this.lblDiemTB.Name = "lblDiemTB";
            this.lblDiemTB.Size = new System.Drawing.Size(73, 20);
            this.lblDiemTB.Text = "Điểm TB :";
            // 
            // FrmBaoCaoSinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1167, 690);
            this.Controls.Add(this.stsThongKe);
            this.Controls.Add(this.dgvBaoCao);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.btnXuatfile);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnXemBaoCao);
            this.Controls.Add(this.cboSapXep);
            this.Controls.Add(this.lblSapXep);
            this.Controls.Add(this.txtTuKhoa);
            this.Controls.Add(this.lblTuKhoa);
            this.Controls.Add(this.cboKetQua);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.cboLop);
            this.Controls.Add(this.lblLop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBaoCaoSinhVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo sinh viên theo lớp";
            this.Load += new System.EventHandler(this.FrmBaoCaoSinhVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.stsThongKe.ResumeLayout(false);
            this.stsThongKe.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.ComboBox cboLop;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.ComboBox cboKetQua;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Label lblSapXep;
        private System.Windows.Forms.ComboBox cboSapXep;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnXuatfile;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.StatusStrip stsThongKe;
        private System.Windows.Forms.ToolStripStatusLabel lblTongSo;
        private System.Windows.Forms.ToolStripStatusLabel lblSoDat;
        private System.Windows.Forms.ToolStripStatusLabel lblSoKhongDat;
        private System.Windows.Forms.ToolStripStatusLabel lblDiemTB;
    }
}

