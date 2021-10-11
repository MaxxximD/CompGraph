using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_Lesson_3._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void X1_textBox_Enter(object sender, EventArgs e)
        {
            if (X1_textBox.Text == "[0, 500]")
            {
                X1_textBox.Text = "";

                X1_textBox.ForeColor = Color.Black;
            }
        }

        private void X1_textBox_Leave(object sender, EventArgs e)
        {
            if (X1_textBox.Text == "")
            {
                X1_textBox.Text = "[0, 500]";

                X1_textBox.ForeColor = Color.Silver;
            }
        }

        private void X2_textBox_Enter(object sender, EventArgs e)
        {
            if (X2_textBox.Text == "[0, 500]")
            {
                X2_textBox.Text = "";

                X2_textBox.ForeColor = Color.Black;
            }
        }

        private void X2_textBox_Leave(object sender, EventArgs e)
        {
            if (X2_textBox.Text == "")
            {
                X2_textBox.Text = "[0, 500]";

                X2_textBox.ForeColor = Color.Silver;
            }
        }

        private void X3_textBox_Enter(object sender, EventArgs e)
        {
            if (X3_textBox.Text == "[0, 500]")
            {
                X3_textBox.Text = "";

                X3_textBox.ForeColor = Color.Black;
            }
        }

        private void X3_textBox_Leave(object sender, EventArgs e)
        {
            if (X3_textBox.Text == "")
            {
                X3_textBox.Text = "[0, 500]";

                X3_textBox.ForeColor = Color.Silver;
            }
        }

        private void Y1_textBox_Enter(object sender, EventArgs e)
        {
            if (Y1_textBox.Text == "[0, 500]")
            {
                Y1_textBox.Text = "";

                Y1_textBox.ForeColor = Color.Black;
            }
        }

        private void Y1_textBox_Leave(object sender, EventArgs e)
        {
            if (Y1_textBox.Text == "")
            {
                Y1_textBox.Text = "[0, 500]";

                Y1_textBox.ForeColor = Color.Silver;
            }
        }

        private void Y2_textBox_Enter(object sender, EventArgs e)
        {
            if (Y2_textBox.Text == "[0, 500]")
            {
                Y2_textBox.Text = "";

                Y2_textBox.ForeColor = Color.Black;
            }
        }

        private void Y2_textBox_Leave(object sender, EventArgs e)
        {
            if (Y2_textBox.Text == "")
            {
                Y2_textBox.Text = "[0, 500]";

                Y2_textBox.ForeColor = Color.Silver;
            }
        }

        private void Y3_textBox_Enter(object sender, EventArgs e)
        {
            if (Y3_textBox.Text == "[0, 500]")
            {
                Y3_textBox.Text = "";

                Y3_textBox.ForeColor = Color.Black;
            }
        }

        private void Y3_textBox_Leave(object sender, EventArgs e)
        {
            if (Y3_textBox.Text == "")
            {
                Y3_textBox.Text = "[0, 500]";

                Y3_textBox.ForeColor = Color.Silver;
            }
        }

        private void R1_textBox_Enter(object sender, EventArgs e)
        {
            if (R1_textBox.Text == "[0, 255]")
            {
                R1_textBox.Text = "";

                R1_textBox.ForeColor = Color.Black;
            }
        }

        private void R1_textBox_Leave(object sender, EventArgs e)
        {
            if (R1_textBox.Text == "")
            {
                R1_textBox.Text = "[0, 255]";

                R1_textBox.ForeColor = Color.Silver;
            }
        }

        private void R2_textBox_Enter(object sender, EventArgs e)
        {
            if (R2_textBox.Text == "[0, 255]")
            {
                R2_textBox.Text = "";

                R2_textBox.ForeColor = Color.Black;
            }
        }

        private void R2_textBox_Leave(object sender, EventArgs e)
        {
            if (R2_textBox.Text == "")
            {
                R2_textBox.Text = "[0, 255]";

                R2_textBox.ForeColor = Color.Silver;
            }
        }

        private void R3_textBox_Enter(object sender, EventArgs e)
        {
            if (R3_textBox.Text == "[0, 255]")
            {
                R3_textBox.Text = "";

                R3_textBox.ForeColor = Color.Black;
            }
        }

        private void R3_textBox_Leave(object sender, EventArgs e)
        {
            if (R3_textBox.Text == "")
            {
                R3_textBox.Text = "[0, 255]";

                R3_textBox.ForeColor = Color.Silver;
            }
        }

        private void G1_textBox_Enter(object sender, EventArgs e)
        {
            if (G1_textBox.Text == "[0, 255]")
            {
                G1_textBox.Text = "";

                G1_textBox.ForeColor = Color.Black;
            }
        }

        private void G1_textBox_Leave(object sender, EventArgs e)
        {
            if (G1_textBox.Text == "")
            {
                G1_textBox.Text = "[0, 255]";

                G1_textBox.ForeColor = Color.Silver;
            }
        }

        private void G2_textBox_Enter(object sender, EventArgs e)
        {
            if (G2_textBox.Text == "[0, 255]")
            {
                G2_textBox.Text = "";

                G2_textBox.ForeColor = Color.Black;
            }
        }

        private void G2_textBox_Leave(object sender, EventArgs e)
        {
            if (G2_textBox.Text == "")
            {
                G2_textBox.Text = "[0, 255]";

                G2_textBox.ForeColor = Color.Silver;
            }
        }

        private void G3_textBox_Enter(object sender, EventArgs e)
        {
            if (G3_textBox.Text == "[0, 255]")
            {
                G3_textBox.Text = "";

                G3_textBox.ForeColor = Color.Black;
            }
        }

        private void G3_textBox_Leave(object sender, EventArgs e)
        {
            if (G3_textBox.Text == "")
            {
                G3_textBox.Text = "[0, 255]";

                G3_textBox.ForeColor = Color.Silver;
            }
        }

        private void B1_textBox_Enter(object sender, EventArgs e)
        {
            if (B1_textBox.Text == "[0, 255]")
            {
                B1_textBox.Text = "";

                B1_textBox.ForeColor = Color.Black;
            }
        }

        private void B1_textBox_Leave(object sender, EventArgs e)
        {
            if (B1_textBox.Text == "")
            {
                B1_textBox.Text = "[0, 255]";

                B1_textBox.ForeColor = Color.Silver;
            }
        }

        private void B2_textBox_Enter(object sender, EventArgs e)
        {
            if (B2_textBox.Text == "[0, 255]")
            {
                B2_textBox.Text = "";

                B2_textBox.ForeColor = Color.Black;
            }
        }

        private void B2_textBox_Leave(object sender, EventArgs e)
        {
            if (B2_textBox.Text == "")
            {
                B2_textBox.Text = "[0, 255]";

                B2_textBox.ForeColor = Color.Silver;
            }
        }

        private void B3_textBox_Enter(object sender, EventArgs e)
        {
            if (B3_textBox.Text == "[0, 255]")
            {
                B3_textBox.Text = "";

                B3_textBox.ForeColor = Color.Black;
            }
        }

        private void B3_textBox_Leave(object sender, EventArgs e)
        {
            if (B3_textBox.Text == "")
            {
                B3_textBox.Text = "[0, 255]";

                B3_textBox.ForeColor = Color.Silver;
            }
        }
        class p
        {
            public int x;
            public int y;
            public int r;
            public int g;
            public int b;

            public p(int x_, int y_, int r_, int g_, int b_)
            {
                this.x = x_;
                this.y = y_;
                this.r = r_;
                this.g = g_;
                this.b = b_;
            }
            public void GetInfo()
            {
                Console.WriteLine($"x: {x}; y: {y}; r: {r}; g: {g}; b: {b}.");
            }
        }

        //Алгоритм Брезенхема для рисования отрезка
        void Step_Draw_Segment(ref int error_l, 
                                ref int dy_l, ref int dx_l, 
                                ref int x_l_cur, ref int y_l_cur, 
                                ref int signX_l, ref int signY_l)
        {
            int error2_l = error_l * 2;

            if (error2_l > -dy_l)
            {
                error_l -= dy_l;
                x_l_cur += signX_l;
            }
            if (error2_l < dx_l)
            {
                error_l += dx_l;
                y_l_cur += signY_l;
            }
        }
        //При достижении точки поменять направления + проверка на достижение
        void Change_of_direction(ref int p_count,
                                ref bool flag_p,
                                ref int error, ref int error_23,
                                ref int x_cur, ref int y_cur, 
                                ref int x, ref int y,
                                ref int dx, ref int dy,
                                ref int dx_23, ref int dy_23,
                                ref int signX, ref int signY,
                                ref int signX_23, ref int signY_23,
                                ref int x3, ref int y3)
        {

            if ((x_cur == x && y_cur == y) && flag_p)//Это будет p, если смотреть по схеме
            {
                /*MessageBox.Show("[" + (p_count+1) + "/3]." +
                    "\nx_r_cur: " + x_cur +
                    "\ny_r_cur: " + y_cur +
                    "\nx_r: " + x +
                    "\ny_r: " + y, "Info", MessageBoxButtons.OK);*/

                p_count++;

                //по оставшейся стороне
                x_cur = x;
                y_cur = y;

                x = x3;
                y = y3;

                dx = dx_23;
                dy = dy_23;
                error = error_23;
                signX = signX_23;
                signY = signY_23;

                flag_p = false;
            }
        }

        //Получить расстояния в пикселях для отрезков
        void Get_Pixel_segments(int p_count, int error_l, int error_r, int error_23,
                                int x_r, int y_r, int x_l, int y_l,
                                int dx_23, int dy_23,
                                int signX_23, int signY_23, int x3, int y3,
                                int dy_l, int dy_r, int dx_l, int dx_r,
                                int x_l_cur, int x_r_cur, int y_l_cur, int y_r_cur,
                                int signX_l, int signX_r, int signY_l, int signY_r,
                                bool flag_p2, bool flag_p3,
                                ref int pixel_s_12, ref int pixel_s_13, ref int pixel_s_23)
        {
            while (p_count < 3)//p_count != 2
            {
                //Идём по левой части
                Step_Draw_Segment(ref error_l, ref dy_l, ref dx_l, ref x_l_cur, ref y_l_cur, ref signX_l, ref signY_l);

                //Идём по правой части
                Step_Draw_Segment(ref error_r, ref dy_r, ref dx_r, ref x_r_cur, ref y_r_cur, ref signX_r, ref signY_r);

                //Подсчёт кол-ва длины отрезков в пикселях
                if (flag_p2)
                {
                    pixel_s_12++;
                }
                else pixel_s_23++;

                if (flag_p3)
                {
                    pixel_s_13++;
                }

                //Достигли точки p2
                Change_of_direction(ref p_count,
                                ref flag_p2,
                                ref error_r, ref error_23,
                                ref x_r_cur, ref y_r_cur,
                                ref x_r, ref y_r,
                                ref dx_r, ref dy_r,
                                ref dx_23, ref dy_23,
                                ref signX_r, ref signY_r,
                                ref signX_23, ref signY_23,
                                ref x3, ref y3);

                //Достигли точки p3
                Change_of_direction(ref p_count,
                                ref flag_p3,
                                ref error_l, ref error_23,
                                ref x_l_cur, ref y_l_cur,
                                ref x_l, ref y_l,
                                ref dx_l, ref dy_l,
                                ref dx_23, ref dy_23,
                                ref signX_l, ref signY_l,
                                ref signX_23, ref signY_23,
                                ref x3, ref y3);

                if (!flag_p2 && !flag_p3 && (x_r_cur == x_r && y_r_cur == y_r))
                {
                    p_count++;
                }
            }
        }

        //Получение текущего цвета по интерполяции
        void Get_Cur_Color(int pixel_s_cur, int pixel_s, Color pixelColor1, Color pixelColor2, ref Color pixelColor1_cur)
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

            int x_c = pixel_s_cur;
            int x1_c = pixel_s + 1;

            if (x1_c < x_c)
                x_c = x1_c;

            Color y0_c = pixelColor1;
            Color y1_c = pixelColor2;

            double r1 = (double)(y1_c.R - y0_c.R) / (double)x1_c;
            double r2 = x_c * (double)r1;
            int new_r = (int)r2 + y0_c.R;

            double g1 = (double)(y1_c.G - y0_c.G) / (double)x1_c;
            double g2 = x_c * (double)g1;
            int new_g = (int)g2 + y0_c.G;

            double b1 = (double)(y1_c.B - y0_c.B) / (double)x1_c;
            double b2 = x_c * (double)b1;
            int new_b = (int)b2 + y0_c.B;

            //int new_r = (x_c * ((y1_c.R - y0_c.R) / x1_c)) + y0_c.R;
            //int new_g = (x_c * ((y1_c.G - y0_c.G) / x1_c)) + y0_c.G;
            //int new_b = (x_c * ((y1_c.B - y0_c.B) / x1_c)) + y0_c.B;


            pixelColor1_cur = Color.FromArgb(255, new_r, new_g, new_b);
        }
        private void template1_Click(object sender, EventArgs e)
        {
            X1_textBox.Text = "200";
            Y1_textBox.Text = "10";
            
            X2_textBox.Text = "300";
            Y2_textBox.Text = "100";
            
            X3_textBox.Text = "100";
            Y3_textBox.Text = "250";
            if (checkBox_run_auto.Checked)
            {
                Build_button_Click(sender, e);
            }
        }
        private void template2_Click(object sender, EventArgs e)
        {
            X1_textBox.Text = "200";
            Y1_textBox.Text = "220";

            X2_textBox.Text = "300";
            Y2_textBox.Text = "250";

            X3_textBox.Text = "100";
            Y3_textBox.Text = "250";
            if (checkBox_run_auto.Checked)
            {
                Build_button_Click(sender, e);
            }
        }
        private void template3_Click(object sender, EventArgs e)
        {
            X1_textBox.Text = "200";
            Y1_textBox.Text = "100";

            X2_textBox.Text = "300";
            Y2_textBox.Text = "500";

            X3_textBox.Text = "100";
            Y3_textBox.Text = "500";
            if (checkBox_run_auto.Checked)
            {
                Build_button_Click(sender, e);
            }
        }
        private void template4_Click(object sender, EventArgs e)
        {
            X1_textBox.Text = "200";
            Y1_textBox.Text = "220";

            X2_textBox.Text = "300";
            Y2_textBox.Text = "400";

            X3_textBox.Text = "100";
            Y3_textBox.Text = "450";
            if (checkBox_run_auto.Checked)
            {
                Build_button_Click(sender, e);
            }
        }
        private void template5_Click(object sender, EventArgs e)
        {
            X1_textBox.Text = "100";
            Y1_textBox.Text = "100";

            X2_textBox.Text = "200";
            Y2_textBox.Text = "100";

            X3_textBox.Text = "200";
            Y3_textBox.Text = "200";
            if (checkBox_run_auto.Checked)
            {
                Build_button_Click(sender, e);
            }
        }
        private void template6_Click(object sender, EventArgs e)
        {
            X1_textBox.Text = "100";
            Y1_textBox.Text = "100";

            X2_textBox.Text = "100";
            Y2_textBox.Text = "200";

            X3_textBox.Text = "200";
            Y3_textBox.Text = "200";
            if (checkBox_run_auto.Checked)
            {
                Build_button_Click(sender, e);
            }
        }
        private void template7_Click(object sender, EventArgs e)
        {
            X1_textBox.Text = "100";
            Y1_textBox.Text = "300";

            X2_textBox.Text = "100";
            Y2_textBox.Text = "200";

            X3_textBox.Text = "200";
            Y3_textBox.Text = "200";
            if (checkBox_run_auto.Checked)
            {
                Build_button_Click(sender, e);
            }
        }
        private void template8_Click(object sender, EventArgs e)
        {
            X1_textBox.Text = "200";
            Y1_textBox.Text = "300";

            X2_textBox.Text = "100";
            Y2_textBox.Text = "200";

            X3_textBox.Text = "200";
            Y3_textBox.Text = "200";
            if (checkBox_run_auto.Checked)
            {
                Build_button_Click(sender, e);
            }
        }
        private void template1_color_Click(object sender, EventArgs e)
        {
            R1_textBox.Text = "255";
            B1_textBox.Text = "0";
            G1_textBox.Text = "0";
            
            R2_textBox.Text = "0";
            B2_textBox.Text = "255";
            G2_textBox.Text = "0";
            
            R3_textBox.Text = "0";
            B3_textBox.Text = "0";
            G3_textBox.Text = "255";
            if (checkBox_run_auto.Checked)
            {
                Build_button_Click(sender, e);
            }
        }
        private void template2_color_Click(object sender, EventArgs e)
        {
            R1_textBox.Text = "255";
            B1_textBox.Text = "0";
            G1_textBox.Text = "0";

            R2_textBox.Text = "0";
            B2_textBox.Text = "0";
            G2_textBox.Text = "255";

            R3_textBox.Text = "0";
            B3_textBox.Text = "0";
            G3_textBox.Text = "255";
            if (checkBox_run_auto.Checked)
            {
                Build_button_Click(sender, e);
            }
        }
        private void template3_color_Click(object sender, EventArgs e)
        {
            R1_textBox.Text = "0";
            B1_textBox.Text = "0";
            G1_textBox.Text = "255";

            R2_textBox.Text = "0";
            B2_textBox.Text = "0";
            G2_textBox.Text = "255";

            R3_textBox.Text = "0";
            B3_textBox.Text = "0";
            G3_textBox.Text = "255";
            if (checkBox_run_auto.Checked)
            {
                Build_button_Click(sender, e);
            }
        }
        private void template4_color_Click(object sender, EventArgs e)
        {
            R1_textBox.Text = "0";
            B1_textBox.Text = "0";
            G1_textBox.Text = "0";

            R2_textBox.Text = "0";
            B2_textBox.Text = "0";
            G2_textBox.Text = "0";

            R3_textBox.Text = "255";
            B3_textBox.Text = "255";
            G3_textBox.Text = "255";
            if (checkBox_run_auto.Checked)
            {
                Build_button_Click(sender, e);
            }
        }
        private void Build_button_Click(object sender, EventArgs e)
        {
            int d;
            bool f_p1 = int.TryParse(X1_textBox.Text, out d) &&
                     int.TryParse(Y1_textBox.Text, out d);

            bool f_p2 = int.TryParse(X2_textBox.Text, out d) &&
                     int.TryParse(Y2_textBox.Text, out d);

            bool f_p3 = int.TryParse(X3_textBox.Text, out d) &&
                     int.TryParse(Y3_textBox.Text, out d);

            bool f_1 = int.TryParse(R1_textBox.Text, out d) &&
                       int.TryParse(G1_textBox.Text, out d) &&
                       int.TryParse(B1_textBox.Text, out d);

            bool f_2 = int.TryParse(R2_textBox.Text, out d) &&
                       int.TryParse(G2_textBox.Text, out d) &&
                       int.TryParse(B2_textBox.Text, out d);

            bool f_3 = int.TryParse(R3_textBox.Text, out d) &&
                       int.TryParse(B3_textBox.Text, out d) &&
                       int.TryParse(G3_textBox.Text, out d);
            if (!f_p1)
            {
                X1_textBox.Text = "200";
                Y1_textBox.Text = "10";
            }
            if (!f_p2)
            {
                X2_textBox.Text = "300";
                Y2_textBox.Text = "100";
            }
            if (!f_p3)
            {
                X3_textBox.Text = "100";
                Y3_textBox.Text = "250";
            }
            if (!f_1)
            {
                R1_textBox.Text = "255";
                B1_textBox.Text = "0";
                G1_textBox.Text = "0";
            }
            if (!f_2)
            {
                R2_textBox.Text = "0";
                B2_textBox.Text = "255";
                G2_textBox.Text = "0";
            }
            if (!f_3)
            {
                R3_textBox.Text = "0";
                B3_textBox.Text = "0";
                G3_textBox.Text = "255";
            }

            //----------------
            int x1 = int.Parse(X1_textBox.Text);
            int x2 = int.Parse(X2_textBox.Text);
            int x3 = int.Parse(X3_textBox.Text);

            int y1 = int.Parse(Y1_textBox.Text);
            int y2 = int.Parse(Y2_textBox.Text);
            int y3 = int.Parse(Y3_textBox.Text);

            int r1 = int.Parse(R1_textBox.Text);
            int r2 = int.Parse(R2_textBox.Text);
            int r3 = int.Parse(R3_textBox.Text);

            int g1 = int.Parse(G1_textBox.Text);
            int g2 = int.Parse(G2_textBox.Text);
            int g3 = int.Parse(G3_textBox.Text);

            int b1 = int.Parse(B1_textBox.Text);
            int b2 = int.Parse(B2_textBox.Text);
            int b3 = int.Parse(B3_textBox.Text);

            p p1 = new p(x1, y1, r1, g1, b1);
            p p2 = new p(x2, y2, r2, g2, b2);
            p p3 = new p(x3, y3, r3, g3, b3);

            //--------------------------------------------------------

            //Условие (при несоответствии поменять):
            //p1 - верхняя
            //p2 - средняя
            //p3 - нижняя

            p[] ps = { p1,p2,p3};
            p t;
            for (int i = 0; i < 3; i++)
            {
                for (int j = i + 1; j < 3; j++)
                {
                    if (ps[i].y > ps[j].y)
                    {
                        t = ps[i];
                        ps[i] = ps[j];
                        ps[j] = t;
                    }
                }
            }

            p1 = ps[0];
            p2 = ps[1];
            p3 = ps[2];

            //Проверка

            for(int i=0; i < 3; i++)
            {
                if(ps[i].x < 0 || ps[i].x > 500 ||
                    ps[i].y < 0 || ps[i].y > 500 ||
                    ps[i].r < 0 || ps[i].r > 255 ||
                    ps[i].g < 0 || ps[i].g > 255 ||
                    ps[i].b < 0 || ps[i].b > 255)
                {
                    MessageBox.Show("Incorrectly entered data", "Error", MessageBoxButtons.OK);
                    return;
                }
            }

            //------------------------------------

            Pen pen = new Pen(Color.Black, 1);
            Bitmap myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Color pixelColor1 = Color.FromArgb(255, p1.r, p1.g, p1.b);
            Color pixelColor2 = Color.FromArgb(255, p2.r, p2.g, p2.b);
            Color pixelColor3 = Color.FromArgb(255, p3.r, p3.g, p3.b);

            int p_count = 0;//Кол-во достижимых точек. При старте 0, при финале 2
            //-----------------------------------
            //12
            var dy_12 = Math.Abs(p2.y - p1.y);
            var dx_12 = Math.Abs(p2.x - p1.x);
            int signX_12 = p1.x < p2.x ? 1 : -1;
            int signY_12 = p1.y < p2.y ? 1 : -1;

            int error_12 = dx_12 - dy_12;

            //23
            var dy_23 = Math.Abs(p3.y - p2.y);
            var dx_23 = Math.Abs(p3.x - p2.x);
            int signX_23 = p2.x < p3.x ? 1 : -1;
            int signY_23 = p2.y < p3.y ? 1 : -1;

            int error_23 = dx_23 - dy_23;

            //13
            var dy_13 = Math.Abs(p3.y - p1.y);
            var dx_13 = Math.Abs(p3.x - p1.x);
            int signX_13 = p1.x < p3.x ? 1 : -1;
            int signY_13 = p1.y < p3.y ? 1 : -1;

            int error_13 = dx_13 - dy_13;
            //-----------------------------------

            //Записываем текущие и некие конечные параметры
            Color pixelColor1_r = pixelColor1;
            Color pixelColor1_l = pixelColor1;

            int x_r_cur = p1.x;
            int x_l_cur = p1.x;
            int y_r_cur = p1.y;
            int y_l_cur = p1.y;

            int x_r = p2.x;
            int x_l = p3.x;

            int y_r = p2.y;
            int y_l = p3.y;

            //При пересечении первой точки поменять
            var dy_l = dy_13;
            var dy_r = dy_12;

            var dx_l = dx_13;
            var dx_r = dx_12;

            int signX_l = signX_13;
            int signX_r = signX_12;

            int signY_l = signY_13;
            int signY_r = signY_12;

            var error_l = error_13;
            var error_r = error_12;

            //-----------------------------------
            myBitmap.SetPixel(p2.x, p2.y, pixelColor2);
            myBitmap.SetPixel(p3.x, p3.y, pixelColor3);

            //Флаги для точек
            bool flag_p2 = true;
            bool flag_p3 = true;

            //Для цветов--------------------------------------------------------------------------------

            //Длина отрезков
            double s_12 = Math.Sqrt(Math.Pow(dy_12, 2) + Math.Pow(dy_12, 2));
            double s_13 = Math.Sqrt(Math.Pow(dy_13, 2) + Math.Pow(dy_13, 2));
            double s_23 = Math.Sqrt(Math.Pow(dy_23, 2) + Math.Pow(dy_23, 2));

            //Разница цветов
            Color diff_color_12 = Color.FromArgb(255, Math.Abs(pixelColor1.R - pixelColor2.R),
                                                      Math.Abs(pixelColor1.G - pixelColor2.G),
                                                      Math.Abs(pixelColor1.B - pixelColor2.B));

            Color diff_color_13 = Color.FromArgb(255, Math.Abs(pixelColor1.R - pixelColor3.R),
                                                      Math.Abs(pixelColor1.G - pixelColor3.G),
                                                      Math.Abs(pixelColor1.B - pixelColor3.B));

            Color diff_color_23 = Color.FromArgb(255, Math.Abs(pixelColor2.R - pixelColor3.R),
                                                      Math.Abs(pixelColor2.G - pixelColor3.G),
                                                      Math.Abs(pixelColor2.B - pixelColor3.B));

            //Длина отрезков в пикселях
            int pixel_s_12 = 0;
            int pixel_s_13 = 0;
            int pixel_s_23 = 0;

            int pixel_s_12_cur = 0;
            int pixel_s_13_cur = 0;
            int pixel_s_23_cur = 0;

            int y_cur = p1.y;//Будем идти вниз постепенно

            //Флаги y
            bool down_y_l = false;
            bool down_y_r = false;

            //************************************************************************************************

            //Получим расстояние в пикселях------------------------------------------------------------------------------------
            Get_Pixel_segments(p_count, error_l, error_r, error_23,
                                x_r, y_r, x_l, y_l,
                                dx_23, dy_23,
                                signX_23, signY_23, p3.x, p3.y,
                                dy_l, dy_r, dx_l, dx_r,
                                x_l_cur, x_r_cur, y_l_cur, y_r_cur,
                                signX_l, signX_r, signY_l, signY_r,
                                flag_p2, flag_p3,
                                ref pixel_s_12, ref pixel_s_13, ref pixel_s_23);

            while (x_r_cur != p3.x || y_r_cur != p3.y)
            {
                if (flag_p2)
                {
                    Get_Cur_Color(pixel_s_12_cur, pixel_s_12, pixelColor1, pixelColor2, ref pixelColor1_r);
                }
                else Get_Cur_Color(pixel_s_23_cur, pixel_s_23, pixelColor2, pixelColor3, ref pixelColor1_r);

                Get_Cur_Color(pixel_s_13_cur, pixel_s_13, pixelColor1, pixelColor3, ref pixelColor1_l);

                //Идём по одному y
                if (down_y_l && down_y_r)
                {
                    int pixel_length_cur;
                    if (x_r_cur > x_l_cur)
                    {
                        pixel_length_cur = x_r_cur - x_l_cur + 1;
                        for (int i = 0; i < pixel_length_cur; i++)
                        {
                            Color pixelColor1_c = pixelColor1_l;
                            Get_Cur_Color(i, pixel_length_cur, pixelColor1_l, pixelColor1_r, ref pixelColor1_c);
                            myBitmap.SetPixel(x_l_cur + i, y_cur, pixelColor1_c);//Рисуем по левой стороне
                        }
                    }
                    else
                    {
                        pixel_length_cur = x_l_cur - x_r_cur + 1;
                        for (int i = 0; i < pixel_length_cur; i++)
                        {
                            Color pixelColor1_c = pixelColor1_l;
                            Get_Cur_Color(i, pixel_length_cur, pixelColor1_l, pixelColor1_r, ref pixelColor1_c);
                            myBitmap.SetPixel(x_l_cur - i, y_cur, pixelColor1_c);//Рисуем по левой стороне
                        }
                    }
                    y_cur++;

                    down_y_r = false;
                    down_y_l = false;
                }

                //Идём по левой части
                if (!down_y_l)
                {
                    myBitmap.SetPixel(x_l_cur, y_l_cur, pixelColor1_l);//Рисуем по левой стороне
                    Step_Draw_Segment(ref error_l, ref dy_l, ref dx_l, ref x_l_cur, ref y_l_cur, ref signX_l, ref signY_l);
                    pixel_s_13_cur++;//Прошли пиксель

                    if (y_cur < y_l_cur)
                        down_y_l = true;
                }

                //Идём по правой части
                if (!down_y_r)
                {
                    myBitmap.SetPixel(x_r_cur, y_r_cur, pixelColor1_r);//Рисуем по правой стороне
                    Step_Draw_Segment(ref error_r, ref dy_r, ref dx_r, ref x_r_cur, ref y_r_cur, ref signX_r, ref signY_r);
                    if (flag_p2)
                    {
                        pixel_s_12_cur++;
                    }
                    else pixel_s_23_cur++;

                    if (y_cur < y_r_cur)
                        down_y_r = true;
                }

                //Достигли точки p2
                Change_of_direction(ref p_count,
                                ref flag_p2,
                                ref error_r, ref error_23,
                                ref x_r_cur, ref y_r_cur,
                                ref x_r, ref y_r,
                                ref dx_r, ref dy_r,
                                ref dx_23, ref dy_23,
                                ref signX_r, ref signY_r,
                                ref signX_23, ref signY_23,
                                ref p3.x, ref p3.y);

                //Достигли точки p3
                if ((x_l_cur == p3.x && y_l_cur == p3.y) && flag_p3)//Это будет p3, если смотреть по схеме
                {
                    flag_p3 = false;
                }
            }
            //************************************************************************

            pictureBox1.Image = myBitmap;
        }

        private void background_1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;
        }

        private void background_2_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Black;
        }

        private void background_3_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Red;
        }
    }
}
