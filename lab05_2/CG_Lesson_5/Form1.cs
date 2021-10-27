using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_Lesson_5
{
    public partial class Form1 : Form
    {
        Graphics g;
        int[,] data;//пиксели
        int width = 512;
        int height = 512;
        int step = 1;//Шаг отрисовки

        double roughness = 2.0;
        int water_level = 10;
        Random r = new Random();
        Bitmap b;

        //--------------------
        int sum = 0;
        int avg = 0;
        int dataMax = 0;

        public Form1()
        {
            InitializeComponent();
            data = new int[width, height];
            pictureBox.Image = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    data[i, j] = -1;

            g = Graphics.FromImage(pictureBox.Image);
            b = new Bitmap(width, height);
        }

        void Clean()
        {
            g = Graphics.FromImage(pictureBox.Image);
            g.Clear(Color.White);
            pictureBox.Refresh();
            data = new int[width+1, height+1];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    data[i, j] = -1;
            label_step.Text = "Start (do grid)";

            sum = 0;
            avg = 0;
            dataMax = 0;
        }

        private void button_next_step_Click(object sender, EventArgs e)
        {
            if (step == 1)
            {
                Clean();
                double d;
                bool f_r = double.TryParse(textBox_roughness.Text, out d);
                if (!f_r || d<0)
                {
                    textBox_roughness.Text = "";
                    MessageBox.Show("roughness fields", "Error", MessageBoxButtons.OK);
                    return;
                }

                roughness = d;
                //-----------
                int d2;
                bool f_w = int.TryParse(textBox_water_level.Text, out d2);
                if (!f_w || d2 < 0)
                {
                    textBox_water_level.Text = "";
                    MessageBox.Show("water fields", "Error", MessageBoxButtons.OK);
                    return;
                }

                water_level = d2;
                //------------------------------------------
                CreatingGrid();

                MakePicture();
                label_step.Text = "do mountain picture";
            }
            else if (step == 2)
            {
                MakeMountainPicture();
                label_step.Text = "do water";
            }
            else if (step == 3)
            {
                Water();
                label_step.Text = "Start (do grid)";
                step = 0;
            }
            step++;
        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            Clean();
            step = 1;
        }

        //Шаг 1 для алгоритма Diamond-square
        void Square(int x1, int y1, int x2, int y2)
        {
            int l = (x2 - x1) / 2;//Просто l, потому что квадрат

            data[x1 + l, y1 + l] = (data[x1, y1] + data[x2, y2] + data[x1, y2] + data[x2, y1]) / 4
                    + r.Next((int)(-1 * roughness * l), (int)(roughness * l));
        }

        //Шаг 2 для алгоритма Diamond-square
        void Diamond(int x, int y, int l)
        {
            //           a
            //
            //     b   (x,y)   d
            //
            //           c
            //
            int a;
            int b;
            int c;
            int d;

            //a
            if (y - l >= 0)
                 a = data[x, y - l];
            else a = data[x, height - l + y];//По тору

            //b
            if (x - l >= 0)
                b = data[x - l, y];
            else b = data[width - l + x, y];

            //c
            if (y + l < height)
                 c = data[x, y + l];
            else c = data[x, y + l - height];//По тору

            //d
            if (x + l < width)
                d = data[x + l, y];
            else d = data[l + x - width, y];

            data[x, y] = (a + b + c + d) / 4
                    + r.Next((int)(-1 * roughness * l), (int)(roughness * l));
        }

        //Алгоритм Diamond-square
        void DiamondSquare(int x1, int y1, int x2, int y2)
        {
            // p1-----
            //   |   |
            //   -----p2
            int l = (x2 - x1) / 2;
            Square(x1, y1, x2, y2);

            Diamond(x1 + l, y1, l);//верх
            Diamond(x2, y2 - l, l);//право
            Diamond(x2 - l, y2, l);//низ
            Diamond(x1, y1 + l, l);//лево
        }

        void CreatingGrid()
        {
            data[0, 0] = (int)(roughness * r.Next(50, 100));
            data[0, height - 1] = (int)(roughness * r.Next(50, 100));
            data[width - 1, 0] = (int)(roughness * r.Next(50, 100));
            data[width - 1, height - 1] = (int)(roughness * r.Next(50, 100));

            for (int l = height / 2; l > 0; l /= 2)
                for (int x = 0; x < width; x += l)
                {
                    for (int y = 0; y < height; y += l)
                        DiamondSquare(x, y, x + l, y + l);
                }
        }

        //Возводим в квадрат по статье
        void SqrData()
        {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    data[x, y] = data[x, y]* data[x, y];
        }
        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);// V = MAX
            int Vmin = Convert.ToInt32((1 - saturation) * value);//вместо 100 у нас 1
            int Vdec = Convert.ToInt32(value * (1 - f * saturation));
            int Vinc = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, Vinc, Vmin);
            else if (hi == 1)
                return Color.FromArgb(255, Vdec, v, Vmin);
            else if (hi == 2)
                return Color.FromArgb(255, Vmin, v, Vinc);
            else if (hi == 3)
                return Color.FromArgb(255, Vmin, Vdec, v);
            else if (hi == 4)
                return Color.FromArgb(255, Vinc, Vmin, v);
            else
                return Color.FromArgb(255, v, Vmin, Vdec);
        }
        void MakePicture()
        {
            SqrData();
            int d = 0;
            Color c = Color.White;

            sum = 0;
            avg = 0;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (dataMax < data[x, y])
                    {
                        dataMax = data[x, y];
                    }
                    sum += data[x, y];
                }
            }
            avg = Math.Abs(sum / (width * height));

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    //(( X — X0 ) х ( Y1 — Y0) / ( X1 — X0) ) + Y0

                    int x1 = dataMax;

                    int y0 = 104;
                    int y1 = 255;

                    double r1 = (double)(y1 - y0) / (double)x1;
                    double r2 = (data[x, y]) * (double)r1;
                    d = (int)r2 + y0;
                    c = Color.FromArgb(d, d, d);

                    b.SetPixel(x, y, c);
                }

            pictureBox.Image = b;
            pictureBox.Refresh();
        }
        void MakeMountainPicture()
        {
            Color c = Color.White;

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    int d;
                    if (data[x, y] < dataMax / 500)
                        c = Color.FromArgb(255, 209, 174);
                    else if (data[x, y] < dataMax / 50)
                    {
                        d = data[x, y] % 3;
                        if (d == 0)
                            c = Color.Green;
                        else if (d == 1)
                            c = Color.FromArgb(51, 102, 0);
                        else if (d == 2)
                            c = Color.FromArgb(36, 119, 25);
                    }
                    else if (data[x, y] < Math.Max(avg, dataMax / 10))
                    {

                        int hue = 94;
                        int s = 100;
                        double v;
                        int x0 = 1000;
                        int x1 = Math.Max(avg, dataMax / 10) - 1;

                        double y0 = 70;
                        double y1 = 50;

                        //(( X — X0 ) х ( Y1 — Y0) / ( X1 — X0) ) + Y0

                        double r1 = (double)(y1 - y0) / (double)x1;
                        double r2 = (data[x, y] - x0) * (double)r1;
                        v = (double)r2 + y0;
                        c = ColorFromHSV(hue, s / 100, v / 100);
                    }
                    else
                    {
                        //Интерполяция цвета
                        //X - текущий пиксель
                        //X0 - Первый пиксель по вычисленной длине
                        //X1 - Последний пиксель по вычисленной длине
                        //Y - получаемый цвет
                        //Y0 - цвет в X0
                        //Y1 - цвет в X1
                        //(( X — X0 ) х ( Y1 — Y0) / ( X1 — X0) ) + Y0

                        //Т.к. x0 равен 0, тогда
                        //( X * ( Y1 — Y0) / X1  ) + Y0

                        int hue = 94;
                        double s;
                        double v = 0.5;
                        int x0 = Math.Max(avg, dataMax / 10);
                        //int x1 = Math.Max(avg * 2, dataMax / 5);
                        int x1 = dataMax;

                        double y0 = 100;
                        double y1 = 6;

                        //(( X — X0 ) х ( Y1 — Y0) / ( X1 — X0) ) + Y0

                        double r1 = (double)(y1 - y0) / (double)x1;
                        double r2 = (data[x, y] - x0) * (double)r1;
                        s = (double)r2 + y0;
                        c = ColorFromHSV(hue, s / 100, v);
                    }
                    b.SetPixel(x, y, c);
                }

            pictureBox.Image = b;
            pictureBox.Refresh();
        }
        void Water()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                    if (data[i, j] <= water_level)
                    {
                        b.SetPixel(i, j, Color.FromArgb(0, 125, 255));
                    }
            }

            pictureBox.Image = b;
            pictureBox.Refresh();
        }

        private void button_pattern_Click(object sender, EventArgs e)
        {
            textBox_roughness.Text = "2,0";
            textBox_water_level.Text = "10";
        }
    }
}
