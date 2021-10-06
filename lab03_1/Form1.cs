using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab03_1
{
    public partial class Form1 : Form
    {
        private Point newP;
        private LinkedList<Tuple<int, int>> points;
        private Bitmap bmp;
        Color c;
        bool paint = false;
        private Point old;
        private bool drawing = false;
        Pen pen;
        private Graphics g;
        Bitmap bm;
        public Form1()
        {          
            c = Color.Black;
            InitializeComponent();
            pen = new Pen(Color.Black);
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            bm = (Bitmap)pictureBox1.Image;
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            pictureBox2.BackColor = Color.Black;
        }

      
        private void Push(Stack<Point> points, Point p, int maxW, int maxH)
        {
            if (p.X < 0 || p.X >= maxW || p.Y < 0 || p.Y >= maxH)
                return;
            points.Push(p);
        }
        private void Fill(int x, int y,Color c)
        {
            int width = bm.Width;
            int height = bm.Height;
            bool[,] flags = new bool[width, height];
            Color replaced = bm.GetPixel(x, y);
            Stack<Point> points = new Stack<Point>();
            points.Push(new Point(x, y));
            while (points.Count > 0)
            {
                Point p = points.Pop();
                if (flags[p.X, p.Y]) continue;
                flags[p.X, p.Y] = true;
                if (bm.GetPixel(p.X, p.Y) != replaced) continue;
                bm.SetPixel(p.X, p.Y, c);
                Push(points, new Point(p.X, p.Y + 1), width, height);
                Push(points, new Point(p.X, p.Y - 1), width, height);
                Push(points, new Point(p.X + 1, p.Y), width, height);
                Push(points, new Point(p.X - 1, p.Y), width, height);
            }
        }
        private void FillPic(int x, int y)
        {
            if (bmp != null)
            {
                int width = bm.Width;
                int height = bm.Height;
                bool[,] flags = new bool[width, height];
                Color replaced = bm.GetPixel(x, y);
                Stack<Point> points = new Stack<Point>();
                points.Push(new Point(x, y));
                while (points.Count > 0)
                {

                    Point p = points.Pop();
                    Color color = bmp.GetPixel(p.X%bmp.Width, p.Y%bmp.Height);
                    if (flags[p.X, p.Y]) continue;
                    flags[p.X, p.Y] = true;
                    if (bm.GetPixel(p.X, p.Y) != replaced) continue;
                    bm.SetPixel(p.X, p.Y, Color.FromArgb(color.A, color.R, color.G, color.B));
                    Push(points, new Point(p.X, p.Y + 1), width, height);
                    Push(points, new Point(p.X, p.Y - 1), width, height);
                    Push(points, new Point(p.X + 1, p.Y), width, height);
                    Push(points, new Point(p.X - 1, p.Y), width, height);
                }
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (paint) {
                if (checkBox1.Checked)
                {
                    FillPic(e.X, e.Y);
                    pictureBox1.Image = bm;
                }
                else
                {
                    Fill(e.X, e.Y, c);
                    pictureBox1.Image = bm;
                }
            }
            else
            {
                old = e.Location;
                drawing = true;
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                newP = e.Location;
                g.DrawLine(pen, old.X, old.Y, e.X, e.Y);
                old = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Draw";
            paint = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Fill";
            paint = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
                c= colorDialog1.Color;
                pictureBox2.BackColor = colorDialog1.Color;
            }
        }
        private Tuple<int, int> nextPixel(int x, int y, int direction)
        {
            switch (direction)
            {
                case 0:
                    x += 1;
                    break;
                case 1:
                    x += 1;
                    y -= 1;
                    break;
                case 2:
                    y -= 1;
                    break;
                case 3:
                    x -= 1;
                    y -= 1;
                    break;
                case 4:
                    x -= 1;
                    break;
                case 5:
                    x -= 1;
                    y += 1;
                    break;
                case 6:
                    y += 1;
                    break;
                case 7:
                    x += 1;
                    y += 1;
                    break;
            }
            return Tuple.Create(x, y);
        }
        private Color color(int x, int y, int direction)
        {
            var point = nextPixel(x, y, direction);
            return bm.GetPixel(point.Item1, point.Item2);
        }
        private void FindBorder(int x, int y)
        {
            var areaColor = bm.GetPixel(x, y);
            points = new LinkedList<Tuple<int, int>>();
            var count = 0;
            var maxCount = bm.Width * bm.Height;

            points.AddLast(Tuple.Create(x, y));
            int currentDirection = 6;

            // стартовые значения x, y и направления 
            var x_start = x;
            var y_start = y;
            var startDirection = 6;

            if (color(x, y, currentDirection) == areaColor)
            {
                y += 1;
                currentDirection = 4;
                points.AddLast(Tuple.Create(x, y));
            }
            else
            {
                while (color(x, y, currentDirection) != areaColor)
                {
                    currentDirection = (currentDirection + 1) % 8;
                }
                var pair = nextPixel(x, y, currentDirection);
                x = pair.Item1;
                y = pair.Item2;
                currentDirection = (currentDirection + 8 - 2) % 8;
                points.AddLast(Tuple.Create(x, y));
            }

            while ((x != x_start || y != y_start || currentDirection != startDirection) && count != maxCount)
            {
                count++;
                if (color(x, y, currentDirection) == areaColor)
                {
                    var pair = nextPixel(x, y, currentDirection);
                    x = pair.Item1;
                    y = pair.Item2;
                    currentDirection = (currentDirection + 8 - 2) % 8;
                    points.AddLast(Tuple.Create(x, y));
                }
                else
                {
                    while (color(x, y, currentDirection) != areaColor)
                    {
                        currentDirection = (currentDirection + 1) % 8;
                    }
                    var pair = nextPixel(x, y, currentDirection);
                    x = pair.Item1;
                    y = pair.Item2;
                    currentDirection = (currentDirection + 8 - 2) % 8;
                    points.AddLast(Tuple.Create(x, y));
                }

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.JPG;*.PNG)|;*.JPG;*.PNG|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    bmp = new Bitmap(ofd.FileName);

                }
                catch
                {
                    MessageBox.Show("unsupported type", "error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DrawBorder()
        {
            foreach (Tuple<int, int> tp in points)
            {
                int i = tp.Item1;
                int j = tp.Item2;
                bm.SetPixel(i, j, Color.Red);
            }
            pictureBox1.Image = bm;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            FindBorder(newP.X, newP.Y);
            DrawBorder();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Invalidate();
        }
    }
}
