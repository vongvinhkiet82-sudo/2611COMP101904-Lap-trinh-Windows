using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab08_SimplePaint
{


    public partial class Form1 : Form
    {
        //du lieu
        private List<DrawItem> items = new List<DrawItem>();
        private DrawItem currentItem = null;
        private bool isDrawing = false;
        private Color currentColor = Color.Black;

        private DrawMode CurrentMode
        {
            get { return (DrawMode)cboMode.SelectedIndex; }
        }

        public Form1()
        {
            InitializeComponent();
            SetupControls();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SetupControls()
        {
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            // chế độ vẽ
            cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMode.Items.AddRange(Enum.GetNames(typeof(DrawMode)));
            cboMode.SelectedIndex = 0;

            // độ dày
            numWidth.Minimum = 1;
            numWidth.Maximum = 20;
            numWidth.Value = 3;

            // vùng vẽ nền trắng, bật DoubleBuffered để không nhấp nháy
            canvas.BackColor = Color.White;
            typeof(Panel).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(canvas, true, null);

            lblStatus.Text = "X=0, Y=0";

            // gắn sự kiện bằng code
            canvas.Paint += canvas_Paint;
            canvas.MouseDown += canvas_MouseDown;
            canvas.MouseMove += canvas_MouseMove;
            canvas.MouseUp += canvas_MouseUp;
            btnColor.Click += btnColor_Click;
            btnUndo.Click += btnUndo_Click;
            btnClear.Click += btnClear_Click;
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            isDrawing = true;

            currentItem = new DrawItem();
            currentItem.Mode = CurrentMode;
            currentItem.Start = e.Location;
            currentItem.End = e.Location;
            currentItem.Color = currentColor;
            currentItem.Width = (float)numWidth.Value;
            currentItem.Points.Add(e.Location);

            canvas.Invalidate();
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            lblStatus.Text = "X=" + e.X + ", Y=" + e.Y;

            if (!isDrawing || currentItem == null) return;

            currentItem.End = e.Location;

            if (currentItem.Mode == DrawMode.Pen)
                currentItem.Points.Add(e.Location);

            canvas.Invalidate();
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing || currentItem == null) return;

            currentItem.End = e.Location;
            items.Add(currentItem);

            currentItem = null;
            isDrawing = false;
            canvas.Invalidate();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (DrawItem item in items)
                DrawOneItem(e.Graphics, item);

            if (currentItem != null)
                DrawOneItem(e.Graphics, currentItem);
        }

        private void DrawOneItem(Graphics g, DrawItem item)
        {
            using (Pen pen = new Pen(item.Color, item.Width))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                pen.LineJoin = LineJoin.Round;

                Rectangle rect = GetRectangle(item.Start, item.End);

                switch (item.Mode)
                {
                    case DrawMode.Pen:
                        if (item.Points.Count >= 2)
                        {
                            g.DrawLines(pen, item.Points.ToArray());
                        }
                        else if (item.Points.Count == 1)
                        {
                            // Chỉ click 1 điểm -> vẽ chấm tròn nhỏ
                            using (Brush dotBrush = new SolidBrush(item.Color))
                            {
                                float r = item.Width / 2f;
                                g.FillEllipse(dotBrush, item.Points[0].X - r, item.Points[0].Y - r, item.Width, item.Width);
                            }
                        }
                        break;

                    case DrawMode.Line:
                        g.DrawLine(pen, item.Start, item.End);
                        break;

                    case DrawMode.Rectangle:
                        if (rect.Width > 0 && rect.Height > 0)
                            g.DrawRectangle(pen, rect);
                        break;

                    case DrawMode.Ellipse:
                        if (rect.Width > 0 && rect.Height > 0)
                            g.DrawEllipse(pen, rect);
                        break;
                }
            }
        }


        private Rectangle GetRectangle(Point p1, Point p2)
        {
            int x = Math.Min(p1.X, p2.X);
            int y = Math.Min(p1.Y, p2.Y);
            int width = Math.Abs(p1.X - p2.X);
            int height = Math.Abs(p1.Y - p2.Y);
            return new Rectangle(x, y, width, height);
        }

        // Các nút
        private void btnColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog dlg = new ColorDialog())
            {
                dlg.Color = currentColor;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    currentColor = dlg.Color;
                    btnColor.BackColor = currentColor;

                    // Đổi màu chữ của nút cho dễ nhìn
                    int brightness = (currentColor.R + currentColor.G + currentColor.B) / 3;
                    btnColor.ForeColor = brightness > 128 ? Color.Black : Color.White;
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            items.Clear();
            canvas.Invalidate();
        }
        private void Undo()
        {
            if (items.Count > 0)
            {
                items.RemoveAt(items.Count - 1);
                canvas.Invalidate();
            }
        }
        // phím tắt Ctrl+Z
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                Undo();
                e.Handled = true;
            }
        }
    }

    // che do ve
    public enum DrawMode
    {
        Pen, Line, Rectangle, Ellipse
    }
    public class DrawItem
    {
        public DrawMode Mode { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }
        public Color Color { get; set; }
        public float Width { get; set; }
        public List<Point> Points { get; set; }

        public DrawItem()
        {
            Points = new List<Point>();
        }
    }
}
