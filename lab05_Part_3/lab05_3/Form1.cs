using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab05_3
{
    public partial class Form1 : Form
    {
        Graphics g;
        Point curPoint;
        List<Point> arrPoints;
        PointF[] bezierPoints;
        bool flag = false;
        

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            arrPoints = new List<Point>();
            bezierPoints = new PointF[101];
        }



        // Сбросить
        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Invalidate();
            arrPoints.Clear();
        }


        int Fact(int n)
        {
            int x = 1;
            for (int i = 1; i <= n; i++)
            {
                x *= i;
            }
            return x;
        }


        /// <summary>
        /// вычисляет полинома Бернштейна
        /// </summary>
        /// <param name="k"></param>
        /// <param name="n"></param>
        /// <param name="t">определяет, где именно на расстоянии от P0 до P1 находится B(t)</param>
        /// <returns></returns>
        float Pol(int k, int n, float t)
        {
            return (Fact(n) / (Fact(k) * Fact(n - k))) * (float)Math.Pow(t, k) * (float)Math.Pow(1 - t, n - k); // Полином Бернштейна
        }

        public void Bezier()
        {
            if (!flag)
                flag = true;
            else
                g.DrawLines(new Pen(Color.White), bezierPoints);

            int new_size = 0;

            for (float t = 0; t < 1; t += 0.01f)
            {
                float sum_x = 0;
                float sum_y = 0;
                for (int i = 0; i < arrPoints.Count; i++)
                {
                    float b = Pol(i, arrPoints.Count - 1, t); 
                    sum_x += arrPoints[i].X * b;
                    sum_y += arrPoints[i].Y * b;
                }
                bezierPoints[new_size] = new PointF(sum_x, sum_y);
                new_size += 1;
            }

            g.DrawLines(new Pen(Color.Black), bezierPoints);
            
        }


        


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(radioButton1.Checked)//Рисовать точки
            {
                curPoint = e.Location;
                arrPoints.Add(curPoint);
                g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(curPoint.X, curPoint.Y, 5, 5));
                pictureBox1.Invalidate();
            }
            else if(radioButton2.Checked)// Удалить
            {
                curPoint = e.Location;
                for (int i = 0; i < arrPoints.Count; i++)
                {
                    if(Math.Abs(curPoint.X - arrPoints[i].X) <= 5 && Math.Abs(curPoint.Y - arrPoints[i].Y) <= 5)
                    {
                        g.FillEllipse(new SolidBrush(Color.White), new Rectangle(arrPoints[i].X, arrPoints[i].Y, 5, 5));
                        arrPoints.RemoveAt(i);
                        Bezier();
                    }
                    pictureBox1.Invalidate();
                }
                
            }
            else if (radioButton3.Checked)// Переместить
            {
                curPoint = e.Location;
                for (int i = 0; i < arrPoints.Count; i++)
                {
                    if (Math.Abs(curPoint.X - arrPoints[i].X) <= 5 && Math.Abs(curPoint.Y - arrPoints[i].Y) <= 5)
                    {
                        g.FillEllipse(new SolidBrush(Color.White), new Rectangle(arrPoints[i].X, arrPoints[i].Y, 5, 5));
                        Point new_Point = new Point(arrPoints[i].X + (int)numericUpDown1.Value, arrPoints[i].Y + (int)numericUpDown2.Value);
                        arrPoints[i] = new_Point;
                        g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(arrPoints[i].X, arrPoints[i].Y, 5, 5));
                        Bezier();
                    }
                }
            }
        }



        // Выполнить
        private void button1_Click(object sender, EventArgs e)
        {
            Bezier();
            pictureBox1.Invalidate();
        }

        
    }
}
