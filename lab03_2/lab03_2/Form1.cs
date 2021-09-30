using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab03_2
{
    public partial class Form1 : Form
    {
        Point p;
        bool flag = false;
        Graphics g1, g2;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            g1 = pictureBox1.CreateGraphics();
            g2 = pictureBox2.CreateGraphics();
        }

        //Очистить
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
        }

        //Целочисленный алгоритм Брезенхема
        private void lineBrezenh(int x0, int x1, int y0, int y1)
        {
            var img = (pictureBox1.Image as Bitmap);
            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);
            int error = 0; // double error = 0.0;
            int deltaerr = (dy + 1);  //double deltaerr = (dy + 1) / (dx + 1)
            int y = y0;
            int diry = y1 - y0;
            if (diry > 0)
                diry = 1;
            if (diry < 0)
                diry = -1;
            for(int x = x0; x <= x1; x++)
            {
                img.SetPixel(x, y, Color.Black);
                pictureBox1.Invalidate();
                error += deltaerr;
                if(error >= (dx + 1))
                {
                    y += diry;
                    error -= (dx + 1); // error -= 1.0
                }
            }
        }

        //Алгоритм Ву - Сглаживание
        private void lineWu(Pen pen, int x0, int x1, int y0, int y1)
        {
            var img = (pictureBox2.Image as Bitmap);
            img.SetPixel(x1, y1, pen.Color);
            pictureBox1.Invalidate();
            float dx = x1 - x0;
            float dy = y1 - y0;
            float gradient = dy / dx;
            float y = y0 + gradient;
            for (int x = x0 + 1; x <= x1 - 1; x++)
            {
                img.SetPixel(x, (int)y, Color.FromArgb((int)((1 - (y - (int)y)) * 255), pen.Color.R, pen.Color.G, pen.Color.B));
                img.SetPixel(x, (int)y + 1, Color.FromArgb((int)((y - (int)y) * 255), pen.Color.R, pen.Color.G, pen.Color.B));
                pictureBox2.Invalidate();
                y += gradient;
            }

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(Color.Red);
            SolidBrush solid = new SolidBrush(Color.Red);
            g1.FillEllipse(solid, e.X, e.Y, 5, 5);

            if (flag)
                lineBrezenh(p.X, e.X, p.Y, e.Y);
            else
                p = e.Location;
            flag = !flag;
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(Color.Red);
            SolidBrush solid = new SolidBrush(Color.Red);
            g2.FillEllipse(solid, e.X, e.Y, 5, 5);

            if (flag)
                lineWu(Pens.Black, p.X, e.X, p.Y, e.Y);
            else
                p = e.Location;
            flag = !flag;
        }
    }
}
