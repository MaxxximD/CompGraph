using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace lab6
{
    public partial class Form1 : Form
    {
        Polyhedron curPolyhedron;
        Graphics graphics;
        Pen pen;
        Projection projection;

        string file_name;
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
            var figureRightX = edges.Max(e => e.p1.x > e.p2.x ? e.p1.x : e.p2.x);
            var figureRightY = edges.Max(e => e.p1.y > e.p2.y ? e.p1.y : e.p2.y);
            var figureCenterX = (figureRightX - figureLeftX) / 2;
            var figureCenterY = (figureRightY - figureLeftY) / 2;

            var fixX = centerX - figureCenterX + (figureLeftX < 0 ? Math.Abs(figureLeftX) : -Math.Abs(figureLeftX));
            var fixY = centerY - figureCenterY + (figureLeftY < 0 ? Math.Abs(figureLeftY) : -Math.Abs(figureLeftY));

            foreach (Line line in edges)
            {
                var p1 = (line.p1).ConvertToPoint();
                var p2 = (line.p2).ConvertToPoint();
                //graphics.DrawLine(pen, (float)(p1.X + centerX - figureCenterX), (float)(p1.Y + centerY - figureCenterY), (float)(p2.X + centerX - figureCenterX), (float)(p2.Y + centerY - figureCenterY));
                graphics.DrawLine(pen, (float)(p1.X + fixX), (float)(p1.Y + fixY), (float)(p2.X + fixX), (float)(p2.Y + fixY));
            }
            pictureBox1.Invalidate();
        }
        //Построение куба
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

            curPolyhedron.AddFace(new List<int> { 0, 1, 2, 3 });
            curPolyhedron.AddFace(new List<int> { 1, 2, 6, 5 });
            curPolyhedron.AddFace(new List<int> { 0, 3, 7, 4 });
            curPolyhedron.AddFace(new List<int> { 4, 5, 6, 7 });
            curPolyhedron.AddFace(new List<int> { 2, 3, 7, 6 });
            curPolyhedron.AddFace(new List<int> { 0, 1, 5, 4 });

            Draw();            
        }
        // Построение тетраэдра
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

            curPolyhedron.AddFace(new List<int> { 0, 1, 2 });
            curPolyhedron.AddFace(new List<int> { 0, 1, 3 });
            curPolyhedron.AddFace(new List<int> { 0, 2, 3 });
            curPolyhedron.AddFace(new List<int> { 1, 2, 3 });

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

            //Масштабирование многогранника относительно своего центра
            if (radioButton_CenterScaling.Checked)
            {
                double k = double.Parse(textBox_CenterScaling.Text)/100;
                affine.scaleCenter(curPolyhedron, k);
                Draw();
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
            }
            //Вращение многогранника вокруг прямой проходящей через центр многогранника, параллельно выбранной координатной оси
            if (radioButton_rotateCenter.Checked)
            {
                if (comboBox_XYZ.Text == "OX")
                    affine.rotateCenter(curPolyhedron, (double)numericUpDown1.Value, 0, 0);
                else if (comboBox_XYZ.Text == "OY")
                    affine.rotateCenter(curPolyhedron, 0, (double)numericUpDown1.Value, 0);
                else if (comboBox_XYZ.Text == "OZ")
                    affine.rotateCenter(curPolyhedron, 0, 0, (double)numericUpDown1.Value);
            }
            Draw();
        }

        // Построение октаэдра
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

            curPolyhedron.AddFace(new List<int> { 0, 1, 3 });
            curPolyhedron.AddFace(new List<int> { 0, 1, 4 });
            curPolyhedron.AddFace(new List<int> { 0, 2, 3 });
            curPolyhedron.AddFace(new List<int> { 0, 2, 4 });
            curPolyhedron.AddFace(new List<int> { 5, 1, 3 });
            curPolyhedron.AddFace(new List<int> { 5, 1, 4 });
            curPolyhedron.AddFace(new List<int> { 5, 2, 3 });
            curPolyhedron.AddFace(new List<int> { 5, 2, 4 });

            Draw();
        }

        //Построение икосаэдра
        private void button4_Click(object sender, EventArgs e)
        {
            double r = (100 * (1 + (float)Math.Sqrt(5)) / 4); 

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
            double r =( 100 * (3 + (float)Math.Sqrt(5)) / 4); 
            double x =( 100 * (1 + (float)Math.Sqrt(5)) / 4); 

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

        //Загрузка
        private void button_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                file_name = openFileDialog1.FileName;

                curPolyhedron = JsonConvert.DeserializeObject<Polyhedron>(File.ReadAllText(file_name, Encoding.UTF8));
                Draw();
            }
        }

        //Сохранение
        private void button_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult result = sfd.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                file_name = sfd.FileName;

                File.WriteAllText(file_name, JsonConvert.SerializeObject(curPolyhedron, Formatting.Indented), Encoding.UTF8);
            }
        }
        private void Graphic(float X0, float X1, float Y0, float Y1, int countSplit, func f)
        {
            float dx = (X1 - X0) / countSplit;
            float dy = (Y1 - Y0) / countSplit;
            float currentX, currentY = Y0;

            List<P3D> points = new List<P3D>();
            Console.WriteLine(dx);
            for (int i = 0; i <= countSplit; ++i)
            {
                currentX = X0;
                for (int j = 0; j <= countSplit; ++j)
                {
                    Console.WriteLine(f(currentX, currentY));
                    points.Add(new P3D(currentX, currentY, f(currentX, currentY)));
                    currentX += dx;
                }
                currentY += dy;
            }
            Polyhedron polyhedron = new Polyhedron(points);
   

            int N = countSplit + 1;

            for (int i = 0; i < N; ++i)
                for (int j = 0; j < N; ++j)
                {
                    if (j != N - 1)
                        polyhedron.AddEdge(i * N + j, i * N + j + 1);
                    if (i != N - 1)
                        polyhedron.AddEdge(i * N + j, (i + 1) * N + j); 
                    if (j != N - 1 && i != N - 1)
                    {
                        polyhedron.AddFace(new List<int> { i * N + j, i * N + j + 1, (i + 1) * N + j, (i + 1) * N + (j + 1) });

                    }
                }
            affine.scaleCenter(polyhedron, 40);
            affine.rotateCenter(polyhedron, 60, 0, 0);

            curPolyhedron = polyhedron;
            pen.Width = 1;
            Draw();
        }
        delegate float func(float x, float y);
        private void button8_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(textBox4.Text, out float X0))
                X0 = -5;
            if (!float.TryParse(textBox6.Text, out float X1))
                X1 = 5;
            if (!float.TryParse(textBox5.Text, out float Y0))
                Y0 = -5;
            if (!float.TryParse(textBox7.Text, out float Y1))
                Y0 = 5;
            if (!int.TryParse(textBox8.Text, out int cnt))
                cnt = 10;

            func f;
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    f = (x, y) => (float)(Math.Sin(x + y));
                    break;
                case 1:
                    f = (x, y) => (float)(Math.Cos(x + y));
                    break;
                case 2:
                    f = (x, y) => (float)(Math.Sin(x * x + y * y));
                    break;
                case 3:
                    f = (x, y) => (float)(Math.Cos(x * x + y * y));
                    break;
                case 4:
                    f = (x, y) => (float)(Math.Cos(x * x + y * y) / (x * x + y * y + 1));
                    break;
                default:
                    f = (x, y) => 0;
                    break;
            }

            Graphic(X0, X1, Y0, Y1, cnt, f);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}
