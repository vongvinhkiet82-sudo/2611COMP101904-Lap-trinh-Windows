using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Reflection;
using System.Windows.Forms;

namespace Lab09_InTheSinhVien
{
    public partial class FrmStudentCard : Form
    {
        private const float RongThietKe = 856f;
        private const float CaoThietKe = 540f;
        private const float RongTheInInch = 4.5f;

        public FrmStudentCard()
        {
            InitializeComponent();
            docInThe.PrintPage += docInThe_PrintPage;
        }

        private void FrmStudentCard_Load(object sender, EventArgs e)
        {
            cboLop.Items.AddRange(new object[] { "49.01.CNTT.A", "49.01.CNTT.B", "50.01.CNTT.A", "50.01.CNTT.B", "51.01.CNTT.A", "51.01.CNTT.B", "52.01.CNTT.A", "52.01.CNTT.B" });
            cboKhoa.Items.AddRange(new object[] { "Công nghệ thông tin", "Toán - Tin học", "Vật lý", "Hóa học", "Ngữ văn", "Ngoại ngữ" });
            cboKhoaHoc.Items.AddRange(new object[] { "K49", "K50", "K51", "K52" });
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });

            dtpNgaySinh.MaxDate = DateTime.Today;
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                           .SetValue(pnlXemTruoc, true, null);   // chống nhấp nháy khi vẽ lại

            ResetForm();
        }

        private void FrmStudentCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            picAnhDaiDien.Image?.Dispose();
        }

        // chon anh
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            if (dlgChonAnh.ShowDialog() != DialogResult.OK) return;

            try
            {
                LoadImageSafe(dlgChonAnh.FileName);
                pnlXemTruoc.Invalidate();
            }
            catch (Exception)
            {
                MessageBox.Show("Không đọc được file ảnh. Hãy chọn file JPG, PNG hoặc BMP hợp lệ.",
                                "Lỗi ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadImageSafe(string fileName)
        {
            using Image temp = Image.FromFile(fileName);
            Image copy = new Bitmap(temp);

            picAnhDaiDien.Image?.Dispose();
            picAnhDaiDien.Image = copy;
            picAnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private bool HasValidPhoto(bool hienThongBao)
        {
            if (picAnhDaiDien.Image == null)
            {
                if (hienThongBao)
                {
                    MessageBox.Show("Vui lòng chọn ảnh sinh viên.", "Thiếu dữ liệu",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnChonAnh.Focus();
                }
                return false;
            }
            return true;
        }

        private bool ValidateInput() => ValidateInput(true);

        private bool ValidateInput(bool hienThongBao)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                if (hienThongBao)
                {
                    MessageBox.Show("Vui lòng nhập mã sinh viên.", "Thiếu dữ liệu",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaSV.Focus();
                }
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                if (hienThongBao)
                {
                    MessageBox.Show("Vui lòng nhập họ và tên.", "Thiếu dữ liệu",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtHoTen.Focus();
                }
                return false;
            }

            return HasValidPhoto(hienThongBao);
        }

        // lay du lieu tu form de ve thẻ sinh viên
        private StudentCardInfo GetStudentInfo()
        {
            return new StudentCardInfo
            {
                StudentId = txtMaSV.Text.Trim(),
                FullName = txtHoTen.Text.Trim(),
                ClassName = cboLop.Text,
                Faculty = cboKhoa.Text,
                Course = cboKhoaHoc.Text,
                Gender = cboGioiTinh.Text,
                BirthDate = dtpNgaySinh.Value,
                Photo = picAnhDaiDien.Image
            };
        }

        private void DuLieuThayDoi(object sender, EventArgs e)
        {
            pnlXemTruoc.Invalidate();
        }

        private void pnlXemTruoc_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(pnlXemTruoc.BackColor);

            if (!ValidateInput(false))
            {
                using Font font = new Font("Segoe UI", 11f, FontStyle.Italic);
                using StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString("Nhập mã sinh viên, họ tên và chọn ảnh\nđể xem trước thẻ sinh viên.",
                             font, Brushes.Gray, pnlXemTruoc.ClientRectangle, sf);
                return;
            }

            StudentCardInfo info = GetStudentInfo();

            // Vùng thẻ: căn giữa Panel, giữ đúng tỉ lệ thẻ ngang.
            const int le = 15;
            float tiLe = Math.Min((pnlXemTruoc.ClientSize.Width - 2f * le) / RongThietKe,
                                  (pnlXemTruoc.ClientSize.Height - 2f * le) / CaoThietKe);
            int w = (int)(RongThietKe * tiLe);
            int h = (int)(CaoThietKe * tiLe);
            Rectangle card = new Rectangle((pnlXemTruoc.ClientSize.Width - w) / 2,
                                           (pnlXemTruoc.ClientSize.Height - h) / 2, w, h);

            DrawStudentCard(g, card, info);
        }

        private void DrawStudentCard(Graphics g, Rectangle card, StudentCardInfo s)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            float k = card.Width / RongThietKe;
            Color mauChinh = Color.FromArgb(21, 76, 140);
            Color mauNen = Color.FromArgb(235, 244, 252);

            // Đổi tọa độ thiết kế -> tọa độ thật trên vùng thẻ
            RectangleF Vung(float x, float y, float w, float h) =>
                new RectangleF(card.Left + x * k, card.Top + y * k, w * k, h * k);
            Font TaoFont(float coChu, FontStyle kieu) =>
                new Font("Segoe UI", coChu * k, kieu, GraphicsUnit.Pixel);

            using (Pen borderPen = new Pen(mauChinh, Math.Max(2f, 5f * k)))
            using (SolidBrush nenBrush = new SolidBrush(mauNen))
            using (SolidBrush mainBrush = new SolidBrush(mauChinh))
            using (StringFormat giua = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            using (StringFormat cat = new StringFormat
            {
                Trimming = StringTrimming.EllipsisCharacter,
                FormatFlags = StringFormatFlags.NoWrap,
                LineAlignment = StringAlignment.Center
            })
            {
                // Khung ngoài + nền + thanh tiêu đề
                RectangleF khung = Vung(2, 2, RongThietKe - 4, CaoThietKe - 4);
                using (GraphicsPath path = TaoHinhBoGoc(khung, 28f * k))
                {
                    g.FillPath(nenBrush, path);

                    GraphicsState st = g.Save();
                    g.SetClip(path, CombineMode.Intersect);
                    g.FillRectangle(mainBrush, Vung(0, 0, RongThietKe, 100));
                    g.Restore(st);

                    g.DrawPath(borderPen, path);
                }

                // Tên trường
                using (Font f1 = TaoFont(20, FontStyle.Bold))
                using (Font f2 = TaoFont(24, FontStyle.Regular))
                {
                    g.DrawString("BỘ GIÁO DỤC VÀ ĐÀO TẠO", f1, Brushes.White, Vung(0, 8, RongThietKe, 40), giua);
                    g.DrawString("TRƯỜNG ĐẠI HỌC SƯ PHẠM TP. HỒ CHÍ MINH", f2, Brushes.White, Vung(0, 52, RongThietKe, 40), giua);
                }

                // Tiêu đề THẺ SINH VIÊN
                using (Font f = TaoFont(38, FontStyle.Bold))
                    g.DrawString("THẺ SINH VIÊN", f, mainBrush, Vung(0, 108, RongThietKe, 60), giua);

                // Ảnh bên trái (khung 3x4, giữ tỉ lệ)
                Rectangle khungAnh = Rectangle.Round(Vung(40, 185, 220, 293));
                g.FillRectangle(Brushes.White, khungAnh);
                if (s.Photo != null) DrawImageZoom(g, s.Photo, khungAnh);
                using (Pen viền = new Pen(mauChinh, Math.Max(1.5f, 3f * k)))
                    g.DrawRectangle(viền, khungAnh);

                // Thông tin bên phải
                string[] nhan = { "MSSV:", "Họ tên:", "Lớp:", "Khoa:", "Ngày sinh:", "Giới tính:" };
                string[] giaTri =
                {
                    s.StudentId,
                    s.FullName.ToUpper(),
                    (s.ClassName + (string.IsNullOrWhiteSpace(s.Course) ? "" : " - " + s.Course)).Trim(),
                    s.Faculty,
                    s.BirthDate.ToString("dd/MM/yyyy"),
                    s.Gender
                };

                using (Font fNhan = TaoFont(24, FontStyle.Regular))
                using (Font fGiaTri = TaoFont(26, FontStyle.Bold))
                using (SolidBrush nhanBrush = new SolidBrush(Color.FromArgb(70, 70, 70)))
                {
                    for (int i = 0; i < nhan.Length; i++)
                    {
                        float dong = 190 + i * 50f;
                        g.DrawString(nhan[i], fNhan, nhanBrush, Vung(290, dong, 150, 44), cat);
                        g.DrawString(giaTri[i], fGiaTri, Brushes.Black, Vung(440, dong, 395, 44), cat);
                    }
                }
            }
        }

        private void DrawImageZoom(Graphics g, Image image, Rectangle box)
        {
            float ratio = Math.Min(
                (float)box.Width / image.Width,
                (float)box.Height / image.Height);

            int w = (int)(image.Width * ratio);
            int h = (int)(image.Height * ratio);
            int x = box.Left + (box.Width - w) / 2;
            int y = box.Top + (box.Height - h) / 2;

            g.DrawImage(image, new Rectangle(x, y, w, h));
        }

        private static GraphicsPath TaoHinhBoGoc(RectangleF r, float bk)
        {
            float d = bk * 2;
            GraphicsPath p = new GraphicsPath();
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        // in ấn 
        private void btnXemTruocIn_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            dlgXemTruocIn.Document = docInThe;
            dlgXemTruocIn.ShowDialog(this);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            if (dlgIn.ShowDialog(this) == DialogResult.OK)
            {
                try { docInThe.Print(); }
                catch (Exception ex)
                {
                    MessageBox.Show("Không in được: " + ex.Message, "Lỗi in ấn",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void docInThe_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Pixel; // đơn vị pixel để tính toán chính xác theo DPI

            float dpiX = g.DpiX;
            float dpiY = g.DpiY;
            int trai = (int)(e.MarginBounds.Left / 100f * dpiX); 
            int tren = (int)(e.MarginBounds.Top / 100f * dpiY);
            int rong = (int)(RongTheInInch * dpiX);
            int cao = (int)(rong * CaoThietKe / RongThietKe);

            Rectangle card = new Rectangle(trai, tren, rong, cao);
            DrawStudentCard(g, card, GetStudentInfo());

            e.HasMorePages = false;
        }

        // làm mới form
        private void ResetForm()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            cboLop.SelectedIndex = 0;
            cboKhoa.SelectedIndex = 0;
            cboKhoaHoc.SelectedIndex = 0;
            cboGioiTinh.SelectedIndex = 0;
            dtpNgaySinh.Value = new DateTime(2005, 1, 1);

            picAnhDaiDien.Image?.Dispose();
            picAnhDaiDien.Image = null;

            pnlXemTruoc.Invalidate();
            txtMaSV.Focus();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (kq == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}