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
        private Camera camera = new Camera();
        string file_name;
        Projection projection;
        private List<Polyhedron> scene = new List<Polyhedron>();

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.Clear(Color.White);
            pen = new Pen(Color.Black, 2);
            projection = new Projection();
            camera.Position = new P3D(299, 180, 0);
            camera.Focus = new P3D(0, 0, 1000);
            camera.Offset = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);
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
            scene.Add(curPolyhedron);
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
            scene.Add(curPolyhedron);
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

                if (button13.Text == "Turn camera on")
                    Draw();
                else
                    DrawCam();
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
                {
                    affine.rotateCenter(curPolyhedron, (double)numericUpDown1.Value, 0, 0);

                }
                else if (comboBox_XYZ.Text == "OY")
                {
                    affine.rotateCenter(curPolyhedron, 0, (double)numericUpDown1.Value, 0);
                    
                }
                else if (comboBox_XYZ.Text == "OZ")
                {
                    affine.rotateCenter(curPolyhedron, 0, 0, (double)numericUpDown1.Value);
                    
                }
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
            scene.Add(curPolyhedron);
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
            scene.Add(curPolyhedron);
            Draw();
  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double r = ( 100 * (3 + (float)Math.Sqrt(5)) / 4);
            double x = ( 100 * (1 + (float)Math.Sqrt(5)) / 4); 

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

            scene.Add(curPolyhedron);
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
            affine.rotateCenter(polyhedron, 90, 0, 0);

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
                    f = (x, y) => (int)(Math.Cos(x * x + y * y) / (x * x + y * y + 1));
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
        public void DrawCam()
        {
            graphics.Clear(Color.White);


            double dist = camera.Position.DistanceTo(camera.Focus);
            //System.Diagnostics.Debug.WriteLine($"Distance: {dist}");
            double angleBeta = (180 - camera.AngleX) / 2;
            double angleGamma = 90 - angleBeta;
            float l = (float)(dist * Math.Sqrt(2 * (1 - Math.Cos(camera.AngleX * Math.PI / 180))));
            float x = (float)(l * Math.Cos(angleGamma * Math.PI / 180));
            float z = (float)(l * Math.Sin(angleGamma * Math.PI / 180));
            P3D currentPosition = camera.Position + new P3D(x, 0, z);
            //System.Diagnostics.Debug.WriteLine($"Camera Position: {currentPosition}");

            Vector3 mT = new Vector3(camera.Focus.x, camera.Focus.y, camera.Focus.z);
            Vector3 cT = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z);
            Vector3 cL = (mT - cT).Normalize();
            Vector3 cR = (Vector3.VectorProduct(new Vector3(0, 1, 0), cL)).Normalize();
            Vector3 cU = (Vector3.VectorProduct(cL, cR)).Normalize();

            double[,] matrixV =
                 {
                     { cR.X, cR.Y, cR.Z, -Vector3.ScalarProduct(cR, cT) },
                     { cU.X, cU.Y, cU.Z, -Vector3.ScalarProduct(cU, cT) },
                     { cL.X, cL.Y, cL.Z, -Vector3.ScalarProduct(cL, cT) },
                     { 0, 0, 0, 1 }
                 };

            foreach (var polyhedron in scene)
            {
                Polyhedron curPolyhedron = new Polyhedron(polyhedron);
                affine.ChangePolyhedron(curPolyhedron, matrixV);
                //System.Diagnostics.Debug.WriteLine($"Cube Position: {curPolyhedron.Center}");
                foreach (var line in projection.Project(curPolyhedron, 0))
                    graphics.DrawLine(new Pen(Color.Black), PointSum(line.p1.ConvertToPoint(), camera.Offset), PointSum(line.p2.ConvertToPoint(), camera.Offset));
            }
            pictureBox1.Invalidate();
        }
        public static Point PointSum(Point p1, PointF p2) => new Point(p1.X + (int)p2.X, p1.Y + (int)p2.Y);
        private void button11_Click(object sender, EventArgs e)
        {
            camera.MoveCamera(0, -40, 0);
            DrawCam();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (button13.Text == "Turn camera on")
            {
                DrawCam();
                button13.Text = "Turn camera off";
            }
            else {
                Draw();
                button13.Text = "Turn camera on";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            camera.MoveCamera(40,0, 0);
            DrawCam();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            camera.MoveCamera(-40, 0, 0);
            DrawCam();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            camera.MoveCamera(0, 40, 0);
            DrawCam();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            camera.MoveCamera(0, 0,-40);
            DrawCam();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            camera.MoveCamera(0, 0, 40);
            DrawCam();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            camera.RotateCamera(-1);
            DrawCam();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            camera.RotateCamera(1);
            DrawCam();
        }

        private void button18_Click(object sender, EventArgs e)
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
                    f = (x, y) => (int)(Math.Cos(x * x + y * y) / (x * x + y * y + 1));
                    break;
                default:
                    f = (x, y) => 0;
                    break;
            }
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.Clear(Color.White);
            GraphicFloatingHorizont(X0, X1, Y0, Y1, cnt, f);
            
        }
        private void GraphicFloatingHorizont(float X0, float X1, float Y0, float Y1, int countSplit, func f)
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            (float cX, float cY) = (width / 2, height / 2);

            graphics = Graphics.FromImage(pictureBox1.Image);

            int scale = 100;
            float[] maxHor = new float[width];
            float[] minHor = new float[width];
            for (int i = 0; i < width; i++)
            {
                maxHor[i] = float.MinValue;
                minHor[i] = float.MaxValue;
            }

            float dy = (Y1 - Y0) / countSplit;

            float angleX = trackBar1.Value / 10f;
            float angleY = trackBar2.Value / 10f;

            float cosX = (float)Math.Cos(angleX);
            float sinX = (float)Math.Sin(angleX);
            float cosY = (float)Math.Cos(angleY);
            float sinY = (float)Math.Sin(angleY);

            pen.Width = 1;

            for (float y = Y0; y < Y1; y += dy)
            {
                Point lastPoint = new Point(0, 0);
                for (float bmpX = -width / 2; bmpX < width / 2; bmpX++)
                {
                    float x = (bmpX + X0) / scale;

                    float rotatedX = cosX * y - sinX * x;
                    float rotatedY = sinX * y + cosX * x;

                    int centeredX = (int)(bmpX + cX);

                    if (centeredX >= width || centeredX <= 0)
                        continue;

                    float z = cosY * rotatedX + sinY * f(rotatedX, rotatedY);
                    int centeredY = (int)(z * scale + cY);
                    if (centeredY >= height || centeredY <= 0)
                        continue;

                    if (z < minHor[centeredX])
                    {
                        minHor[centeredX] = z;
                        pen.Width = 1.5f;
                        pen.Color = Color.DarkGreen;
                        Point curPoint = new Point(centeredX, centeredY);
                        if (Distance(curPoint, lastPoint) < 20) graphics.DrawLine(pen, lastPoint, new Point(centeredX, centeredY));
                        lastPoint = new Point(centeredX, centeredY);
                    }

                    if (z > maxHor[centeredX])
                    {
                        maxHor[centeredX] = z;
                        pen.Width = 1;
                        pen.Color = Color.LightGreen;
                        Point curPoint = new Point(centeredX, centeredY);
                        if (Distance(curPoint, lastPoint) < 20) graphics.DrawLine(pen, lastPoint, curPoint);
                        lastPoint = new Point(centeredX, centeredY);
                    }

                }

            }
            pictureBox1.Invalidate();
        }
        private double Distance(Point p1, Point p2) => Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            button18_Click(null,null);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            button18_Click(null, null);
        }
    }

}
