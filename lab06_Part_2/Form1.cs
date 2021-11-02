using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form1 : Form
    {
        Polyhedron curPolyhedron;
        Graphics graphics;
        Pen pen;
        Projection projection;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.Clear(Color.White);
            pen = new Pen(Color.Black, 2);
            projection = new Projection();
        }
        private void Draw()
        {
            int mode = 0;
            if (radioButton1.Checked)
                mode = 0;
            else
                mode = 1;
            graphics.Clear(Color.White);         
            List<Line> edges = projection.Project(curPolyhedron, mode);

            var centerX = pictureBox1.Width / 2;
            var centerY = pictureBox1.Height / 2;

            var figureLeftX = edges.Min(e => e.p1.x < e.p2.x ? e.p1.x : e.p2.x);
            var figureLeftY = edges.Min(e => e.p1.y < e.p2.y ? e.p1.y : e.p2.y);
            var figureRightX = edges.Max(e => e.p1.x < e.p2.x ? e.p1.x : e.p2.x);
            var figureRightY = edges.Max(e => e.p1.y < e.p2.y ? e.p1.y : e.p2.y);
            var figureCenterX = (figureRightX - figureLeftX) / 2;
            var figureCenterY = (figureRightY - figureLeftY) / 2;

            foreach (Line line in edges)
            {
                var p1 = (line.p1).ConvertToPoint();
                var p2 = (line.p2).ConvertToPoint();
                graphics.DrawLine(pen, (float)(p1.X + centerX - figureCenterX), (float)(p1.Y + centerY - figureCenterY), (float)(p2.X + centerX - figureCenterX), (float)(p2.Y + centerY - figureCenterY));
            }
            pictureBox1.Invalidate();
        }
        private void button1_Click(object sender, EventArgs e)
        {          
                P3D start = new P3D(0, 0, 0);
                int len = 150;

                List<P3D> points = new List<P3D>
            {
                start,
                start + new P3D(len, 0, 0),
                start + new P3D(len, 0, len),
                start + new P3D(0, 0, len),

                start + new P3D(0, len, 0),
                start + new P3D(len, len, 0),
                start + new P3D(len, len, len),
                start + new P3D(0, len, len)
            };
                curPolyhedron = new Polyhedron(points);
                curPolyhedron.AddEdges(0, new List<int> { 1, 4 });
                curPolyhedron.AddEdges(1, new List<int> { 2, 5 });
                curPolyhedron.AddEdges(2, new List<int> { 6, 3 });
                curPolyhedron.AddEdges(3, new List<int> { 7, 0 });
                curPolyhedron.AddEdges(4, new List<int> { 5 });
                curPolyhedron.AddEdges(5, new List<int> { 6 });
                curPolyhedron.AddEdges(6, new List<int> { 7 });
                curPolyhedron.AddEdges(7, new List<int> { 4 });

                Draw();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            P3D start = new P3D(0, 0, 0); 
            int len = 150;

            List<P3D> points = new List<P3D>
            {
                start,
                start + new P3D(len, 0, len),
                start + new P3D(len, len, 0),
                start + new P3D(0, len, len),
            };

            curPolyhedron = new Polyhedron(points);
            curPolyhedron.AddEdges(0, new List<int> { 1, 3, 2 });
            curPolyhedron.AddEdges(1, new List<int> { 3 });
            curPolyhedron.AddEdges(2, new List<int> { 1, 3 });

            Draw();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //смещение
            if (radioButton3.Checked) 
            {
                float x = float.Parse(textBox1.Text);
                float y = float.Parse(textBox2.Text);
                float z = float.Parse(textBox3.Text);

                affine.translate(curPolyhedron, x, y, z);
                Draw();
            }
            if (radioButton4.Checked) //поворот
            {
                float x = float.Parse(textBox1.Text);
                float y = float.Parse(textBox2.Text);
                float z = float.Parse(textBox3.Text);
                affine.rotation(curPolyhedron, x, y, z);
                Draw();
               
            }
            if (radioButton5.Checked)//масштаб
            {
                float x = float.Parse(textBox1.Text) / 100;
                float y = float.Parse(textBox2.Text) / 100;
                float z = float.Parse(textBox3.Text) / 100;
                if (x > 0 && y > 0 && z > 0)
                {
                    affine.scale(curPolyhedron, x, y, z);
                    Draw();
                }
            }
            if (radioButton6.Checked) // Отражение относительно выбранной координатной плоскости.
            {
                string plane = "";
                switch (comboBox1.Text)
                {
                    case "xy":
                        plane = "xy";
                        break;
                    case "xz":
                        plane = "xz";
                        break;
                    case "yz":
                        plane = "yz";
                        break;
                    default:
                        break;
                }
                if (plane != "")
                {
                    affine.reflection(curPolyhedron, plane);
                    Draw();
                }
            }
            
            //Draw();
        }

        //Вращать
        private void button7_Click(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                affine.rotate_line(curPolyhedron, (double)numericUpDown1.Value, new Line(int.Parse(x1.Text), int.Parse(y1.Text), int.Parse(z1.Text),
                                                                                         int.Parse(x2.Text), int.Parse(y2.Text), int.Parse(z2.Text)));
                Draw();
            }
                

        }

        private void button3_Click(object sender, EventArgs e)
        {
            P3D start = new P3D(0, 0, 0); 
            int len = 150;

            List<P3D> points = new List<P3D>
            {
                start,
                start + new P3D(len , len , 0),
                start + new P3D(-len, len , 0),
                start + new P3D(0, len , -len ),
                start + new P3D(0, len , len ),
                start + new P3D(0,  2 *len, 0),
            };
            curPolyhedron = new Polyhedron(points);
            curPolyhedron.AddEdges(0, new List<int> { 1, 3, 2, 4 });
            curPolyhedron.AddEdges(5, new List<int> { 1, 3, 2, 4 });
            curPolyhedron.AddEdges(1, new List<int> { 3 });
            curPolyhedron.AddEdges(3, new List<int> { 2 });
            curPolyhedron.AddEdges(2, new List<int> { 4 });
            curPolyhedron.AddEdges(4, new List<int> { 1 });
            Draw();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int r = (int)(100 * (1 + (float)Math.Sqrt(5)) / 4); 

            List<P3D> points = new List<P3D>
            {
                new P3D(0, -50, -r),
                new P3D(0, 50, -r),
                new P3D(50, r, 0),
                new P3D(r, 0, -50),
                new P3D(50, -r, 0),
                new P3D(-50, -r, 0),
                new P3D(-r, 0, -50),
                new P3D(-50, r, 0),
                new P3D(r, 0, 50),
                new P3D(-r, 0, 50),
                new P3D(0, -50, r),
                new P3D(0, 50, r)
            };

            Polyhedron iko = new Polyhedron(points);

            iko.AddEdges(0, new List<int> { 1, 3, 4, 5, 6 });
            iko.AddEdges(1, new List<int> { 2, 3, 6, 7 });
            iko.AddEdges(2, new List<int> { 3, 7, 8, 11 });
            iko.AddEdges(3, new List<int> { 4, 8 });
            iko.AddEdges(4, new List<int> { 5, 8, 10 });
            iko.AddEdges(5, new List<int> { 6, 9, 10 });
            iko.AddEdges(6, new List<int> { 7, 9 });
            iko.AddEdges(7, new List<int> { 9, 11 });
            iko.AddEdges(8, new List<int> { 10, 11 });
            iko.AddEdges(9, new List<int> { 10, 11 });
            iko.AddEdges(10, new List<int> { 11 });

            curPolyhedron = iko;
            Draw();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int r =(int)( 100 * (3 + (float)Math.Sqrt(5)) / 4); 
            int x =(int)( 100 * (1 + (float)Math.Sqrt(5)) / 4); 

            List<P3D> points = new List<P3D>
            {
                new P3D(0, -50, -r),
                new P3D(0, 50, -r),
                new P3D(x, x, -x),
                new P3D(r, 0, -50),
                new P3D(x, -x, -x),
                new P3D(50, -r, 0),
                new P3D(-50, -r, 0),
                new P3D(-x, -x, -x),
                new P3D(-r, 0, -50),
                new P3D(-x, x, -x),
                new P3D(-50, r, 0),
                new P3D(50, r, 0),
                new P3D(-x, -x, x),
                new P3D(0, -50, r),
                new P3D(x, -x, x),
                new P3D(0, 50, r),
                new P3D(-x, x, x),
                new P3D(x, x, x),
                new P3D(-r, 0, 50),
                new P3D(r, 0, 50)
            };

            Polyhedron dode = new Polyhedron(points);

            dode.AddEdges(0, new List<int> { 1, 4, 7 });
            dode.AddEdges(1, new List<int> { 2, 9 });
            dode.AddEdges(2, new List<int> { 3, 11 });
            dode.AddEdges(3, new List<int> { 4, 19 });
            dode.AddEdges(4, new List<int> { 5 });
            dode.AddEdges(5, new List<int> { 6, 14 });
            dode.AddEdges(6, new List<int> { 7, 12 });
            dode.AddEdges(7, new List<int> { 8 });
            dode.AddEdges(8, new List<int> { 9, 18 });
            dode.AddEdges(9, new List<int> { 10 });
            dode.AddEdges(10, new List<int> { 11, 16 });
            dode.AddEdges(11, new List<int> { 17 });
            dode.AddEdges(12, new List<int> { 13, 18 });
            dode.AddEdges(13, new List<int> { 14, 15 });
            dode.AddEdges(14, new List<int> { 19 });
            dode.AddEdges(15, new List<int> { 16, 17 });
            dode.AddEdges(16, new List<int> { 18 });
            dode.AddEdges(17, new List<int> { 19 });
            curPolyhedron = dode;

            Draw();
        }

    }
}
