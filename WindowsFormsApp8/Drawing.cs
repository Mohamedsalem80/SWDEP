using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Drawing : Form
    {
        public Point current = new Point();
        public Point old = new Point();

        public Graphics g;
        public Graphics graph;

        public Pen pen = new Pen(Color.Black, 5);
        Bitmap surface;
        public Drawing()
        {
            InitializeComponent();

            g = canvasPannel.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            pen.SetLineCap(System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.LineCap.Round, System.Drawing.Drawing2D.DashCap.Round);

            surface = new Bitmap(canvasPannel.Width, canvasPannel.Height);

            graph = Graphics.FromImage(surface);

            canvasPannel.BackgroundImage = surface;
            canvasPannel.BackgroundImageLayout = ImageLayout.None;

            pen.Width = (float)paintbrush_size.Value;
        }

        private void Drawing_Load(object sender, EventArgs e)
        {

        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            old = e.Location;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                current = e.Location;
                g.DrawLine(pen, old, current);
                graph.DrawLine(pen, old, current);

                old = current;
            }
        }
        private Point mouseOffsetPos;
        private Boolean isMouseDown = false;

        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                mouseOffsetPos = new Point(-e.X, -e.Y);
                isMouseDown = true;
            }
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousepos = Control.MousePosition;
                mousepos.Offset(mouseOffsetPos.X, mouseOffsetPos.Y);
                this.Location = mousepos;
            }
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void eraser_btn_Click(object sender, EventArgs e)
        {
            pen.Color = Color.White;
            pen.Width = 15;
        }

        private void paintbrush_btn_Click(object sender, EventArgs e)
        {
            pen.Color = colorbox.BackColor;
            pen.Width = 3;
        }

        private void colorbox_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if(cd.ShowDialog() == DialogResult.OK)
            {
                pen.Color = cd.Color;
                colorbox.BackColor = cd.Color;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            graph.Clear(Color.White);
            canvasPannel.Invalidate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Png Files (*png) | *.png";
            sfd.DefaultExt = "png";
            sfd.AddExtension = true;

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                surface.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void paintbrushsize_changed(object sender, EventArgs e)
        {
            pen.Width = (float)paintbrush_size.Value;
        }
    }
}
