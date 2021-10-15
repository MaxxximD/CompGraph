using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{

    public partial class Form1 : Form
    {
        private Bitmap bmp;
        Pen pen;
        List<P> pointList = new List<P>();
        int x1, y1;
        List<Line> lineList = new List<Line>();
        bool checkline = true;

        //Для полигона
        List<Polygon> polygonList = new List<Polygon>();
        bool isStopPolygonAdding = true;
        int CurrentPolygon = -1;

        private String drawing = "Point";
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black);

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (drawing == "Point")
            {
                P point = new P(e.X, e.Y);
                pointList.Add(point);

                comboBox_point.Items.Add("Point-" + (pointList.Count - 1));
            }
            else if (drawing == "Line")
            {

                if (checkline)
                {
                    checkline = false;
                    x1 = e.X; y1 = e.Y;

                }
                else
                {
                    checkline = true;
                    Line lines = new Line(new P(x1, y1), new P(e.X, e.Y));
                    lineList.Add(lines);

                    comboBox_line.Items.Add("Line-" + (lineList.Count-1));
                    comboBox_line_intersection1.Items.Add("Line-" + (lineList.Count - 1));
                    comboBox_line_intersection2.Items.Add("Line-" + (lineList.Count - 1));
                }

            }
            else if (drawing == "Polygon")
            {
                if (isStopPolygonAdding)
                {
                    Polygon polygon = new Polygon();
                    polygonList.Add(polygon);
                    isStopPolygonAdding = false;
                    CurrentPolygon++;
                    
                    comboBox_polygon.Items.Add("Polygon-" + CurrentPolygon);
                }
                polygonList[CurrentPolygon].Add(new P(e.X, e.Y));
            }
            Draw();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            drawing = "Point";
            label1.Text = drawing;
        }
        private void Draw()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);

            foreach (var x in pointList)
            {
                bmp.SetPixel((int)x.x, (int)x.y, Color.Black);
            }
            foreach (var x in lineList)
            {
                x.DrawLine(g, pen);
            }
            for(int i = 0; i < polygonList.Count; i++)
            {
                polygonList[i].DrawPolygon(g, pen);
            }
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            drawing = "Line";
            label1.Text = drawing;
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bitmap;
            pictureBox1.Invalidate();

            pointList.Clear();
            lineList.Clear();
            polygonList.Clear();

            //Очистка выпадающих списков
            comboBox_point.Items.Clear();
            comboBox_line.Items.Clear();
            comboBox_polygon.Items.Clear();

            comboBox_point.ResetText();
            comboBox_line.ResetText();
            comboBox_polygon.ResetText();

            comboBox_point.SelectedIndex = -1;
            comboBox_line.SelectedIndex = -1;
            comboBox_polygon.SelectedIndex = -1;
            //-----------------------------------------
            comboBox_line_intersection1.Items.Clear();
            comboBox_line_intersection2.Items.Clear();

            comboBox_line_intersection1.ResetText();
            comboBox_line_intersection2.ResetText();

            comboBox_line_intersection1.SelectedIndex = -1;
            comboBox_line_intersection2.SelectedIndex = -1;
            //-----------------------------------------
            checkline = true;
            isStopPolygonAdding = true;
            CurrentPolygon = -1;

            drawing = "Point";
            label1.Text = drawing;
        }

        private void button_stop_adding_Click(object sender, EventArgs e)
        {
            isStopPolygonAdding = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            drawing = "Polygon";
            label1.Text = drawing;
        }
        //Перемножение матриц
        public double[,] MatrixMulti(double[,] v, double[,] m)
        {
            double[,] result = new double[1, 3];

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = 0;

                    for (int k = 0; k < 3; k++)
                    {
                        result[i, j] += v[i, k] * m[k, j];
                    }
                }
            }
            return result;
        }

        private void button_template_3_1_Click_1(object sender, EventArgs e)
        {
            checkBox_point_scaling.Checked = true;
            textBox_x_axis_scaling.Text = "0,9";
            textBox_y_axis_scaling.Text = "0,9";
            checkBox_center2.Checked = true;
        }

        private void button_template_3_2_Click(object sender, EventArgs e)
        {
            checkBox_point_scaling.Checked = true;
            textBox_x_axis_scaling.Text = "1,1";
            textBox_y_axis_scaling.Text = "1,1";
            checkBox_center2.Checked = true;
        }

        private void button_template_2_1_Click(object sender, EventArgs e)
        {
            checkBox_turn_around_point.Checked = true;
            textBox_angle.Text = "-10";
            checkBox_center1.Checked = true;
        }

        private void button_template_2_2_Click(object sender, EventArgs e)
        {
            checkBox_turn_around_point.Checked = true;
            textBox_angle.Text = "45";
            checkBox_center1.Checked = true;
        }

        private void button_template_1_1_Click(object sender, EventArgs e)
        {
            checkBox_move.Checked = true;
            textBox_dx.Text = "-50";
            textBox_dy.Text = "-50";
        }

        private void button_template_1_2_Click(object sender, EventArgs e)
        {
            checkBox_move.Checked = true;
            textBox_dx.Text = "50";
            textBox_dy.Text = "50";
        }

        private void button_line_rotate_Click(object sender, EventArgs e)
        {
            //Центр масс
            //centerX
            if (comboBox_line.SelectedIndex == -1)
            {
                MessageBox.Show("number_of_line is false", "Error", MessageBoxButtons.OK);
                return;
            }

            double sumX = lineList[comboBox_line.SelectedIndex].p1.x + lineList[comboBox_line.SelectedIndex].p2.x;
            double centerX = sumX / 2;

            double a = centerX;

            //centerY
            double sumY = lineList[comboBox_line.SelectedIndex].p1.y + lineList[comboBox_line.SelectedIndex].p2.y;
            double centerY = sumY / 2;
            double b = centerY;
            //----------------------------

            double[,] matrixTurnAroundPoint = new double[3, 3];
            matrixTurnAroundPoint[0, 0] = Math.Cos((90D / 180D) * Math.PI);
            matrixTurnAroundPoint[0, 1] = Math.Sin((90D / 180D) * Math.PI);
            matrixTurnAroundPoint[1, 0] = -1.0 * Math.Sin((90D / 180D) * Math.PI);
            matrixTurnAroundPoint[1, 1] = Math.Cos((90D / 180D) * Math.PI);
            matrixTurnAroundPoint[2, 0] = -1.0 * a * Math.Cos((90D / 180D) * Math.PI) + b * Math.Sin((90D / 180D) * Math.PI) + a;
            matrixTurnAroundPoint[2, 1] = -1.0 * a * Math.Sin((90D / 180D) * Math.PI) - b * Math.Cos((90D / 180D) * Math.PI) + b;
            matrixTurnAroundPoint[2, 2] = 1;

            double[,] v = new double[1, 3];
            v[0, 0] = lineList[comboBox_line.SelectedIndex].p1.x;
            v[0, 1] = lineList[comboBox_line.SelectedIndex].p1.y;
            v[0, 2] = 1;

            v = MatrixMulti(v, matrixTurnAroundPoint);

            lineList[comboBox_line.SelectedIndex].p1.x = v[0, 0];
            lineList[comboBox_line.SelectedIndex].p1.y = v[0, 1];

            v = new double[1, 3];
            v[0, 0] = lineList[comboBox_line.SelectedIndex].p2.x;
            v[0, 1] = lineList[comboBox_line.SelectedIndex].p2.y;
            v[0, 2] = 1;

            v = MatrixMulti(v, matrixTurnAroundPoint);

            lineList[comboBox_line.SelectedIndex].p2.x = v[0, 0];
            lineList[comboBox_line.SelectedIndex].p2.y = v[0, 1];

            Draw();
        }
        //Точка пересечения двух отрезков
        private P pointIntersection(P p1, P p2, P p3, P p4)
        {
            P pCross = new P();

            P pABDot1 = p1;
            P pABDot2 = p2;

            P pCDDot1 = p3;
            P pCDDot2 = p4;

            double a1 = pABDot2.y - pABDot1.y;
            double b1 = pABDot1.x - pABDot2.x;
            double c1 = -pABDot1.x * pABDot2.y + pABDot1.y * pABDot2.x;


            double a2 = pCDDot2.y - pCDDot1.y;
            double b2 = pCDDot1.x - pCDDot2.x;
            double c2 = -pCDDot1.x * pCDDot2.y + pCDDot1.y * pCDDot2.x;

            pCross.x = (b1 * c2 - b2 * c1) / (a1 * b2 - a2 * b1);

            pCross.y = (a2 * c1 - a1 * c2) / (a1 * b2 - a2 * b1);


            return pCross;
        }
        //Нахождение точки пересечения двух отрезков
        private void button_line_intersection_Click(object sender, EventArgs e)
        {
            if(comboBox_line_intersection1.SelectedIndex == -1)
            {
                MessageBox.Show("number_of_line_1 is false", "Error", MessageBoxButtons.OK);
                return;
            }
            if (comboBox_line_intersection2.SelectedIndex == -1)
            {
                MessageBox.Show("number_of_line_2 is false", "Error", MessageBoxButtons.OK);
                return;
            }
            Line l1 = lineList[comboBox_line_intersection1.SelectedIndex];
            Line l2 = lineList[comboBox_line_intersection2.SelectedIndex];

            P p1 = l1.p1;
            P p2 = l1.p2;

            P p3 = l2.p1;
            P p4 = l2.p2;

            //Расставим точки по порядку, чтобы p1.x <= p2.x и p3.x <= p4.x
            if (p2.x < p1.x)
            {
                P tmp = p1;
                p1 = p2;
                p2 = tmp;
            }
            if (p4.x < p3.x)
            {

                P tmp = p3;
                p3 = p4;
                p4 = tmp;
            }

            if (p2.x < p3.x)
            {
                MessageBox.Show("У отрезков нету взаимной абсциссы -> не пересекаются", "Info", MessageBoxButtons.OK);
                return;
            }

            if ((p1.x - p2.x == 0) && (p3.x - p4.x == 0))
            {
                if (p1.x == p3.x)
                {
                    if (!((Math.Max(p1.y, p2.y) < Math.Min(p3.y, p4.y)) ||
                            (Math.Min(p1.y, p2.y) > Math.Max(p3.y, p4.y))))
                    {
                        MessageBox.Show("Отрезки накладываются друг на друга -> пересекаются", "Info", MessageBoxButtons.OK);
                        return;
                    }
                }
                MessageBox.Show("оба отрезка вертикальные -> не пересекаются", "Info", MessageBoxButtons.OK);
                return;
            }

            //если первый отрезок вертикальный
            if (p1.x - p2.x == 0)
            {
                //найдём x_a, y_a - точки пересечения двух прямых
                double _x_a = p1.x;
                double _a_2 = (p3.y - p4.y) / (p3.x - p4.x);
                double _b_2 = p3.y - _a_2 * p3.x;
                double _y_a = _a_2 * _x_a + _b_2;

                if (p3.x <= _x_a && p4.x >= _x_a && Math.Min(p1.y, p2.y) <= _y_a &&
                        Math.Max(p1.y, p2.y) >= _y_a)
                {
                    MessageBox.Show("Пересекаются:\n" +
                        "x: " + _x_a + "\n" +
                        "y: " + _y_a, "Info", MessageBoxButtons.OK);
                    return;
                }
                MessageBox.Show("Не пересекаются", "Info", MessageBoxButtons.OK);
                return;
            }

            //если второй отрезок вертикальный
            if (p3.x - p4.x == 0)
            {
                //найдём x_a, y_a - точки пересечения двух прямых
                double x_a_ = p3.x;
                double a_1_ = (p1.y - p2.y) / (p1.x - p2.x);
                double b_1_ = p1.y - a_1_ * p1.x;
                double y_a_ = a_1_ * x_a_ + b_1_;

                if (p1.x <= x_a_ && p2.x >= x_a_ && Math.Min(p3.y, p4.y) <= y_a_ &&
                        Math.Max(p3.y, p4.y) >= y_a_)
                {
                    MessageBox.Show("Пересекаются:\n" +
                        "x: " + x_a_ + "\n" +
                        "y: " + y_a_, "Info", MessageBoxButtons.OK);
                    return;
                }
                MessageBox.Show("Не пересекаются", "Info", MessageBoxButtons.OK);
                return;
            }

            //оба отрезка невертикальные
            double a_1 = (p1.y - p2.y) / (p1.x - p2.x);
            double a_2 = (p3.y - p4.y) / (p3.x - p4.x);
            double b_1 = p1.y - a_1 * p1.x;
            double b_2 = p3.y - a_2 * p3.x;

            if (a_1 == a_2)
            {
                MessageBox.Show("Отрезки параллельны -> не пересекаются", "Info", MessageBoxButtons.OK);
                return;
            }

            //x_a - абсцисса точки пересечения двух прямых
            double x_a = (b_2 - b_1) / (a_1 - a_2);

            if ((x_a < Math.Max(p1.x, p3.x)) || (x_a > Math.Min(p2.x, p4.x)))
            {
                MessageBox.Show("Не пересекаются", "Info", MessageBoxButtons.OK);
                return; //точка x_a находится вне пересечения проекций отрезков на ось X 
            }
            else
            {
                P pInter = pointIntersection(p1, p2, p3, p4);

                MessageBox.Show("Пересекаются:\n" +
                    "x: " + pInter.x + "\n" +
                    "y: " + pInter.y, "Info", MessageBoxButtons.OK);
                return;
            }
        }

        private void button_make_Click(object sender, EventArgs e)
        {
            double d;
            bool f_dx = double.TryParse(textBox_dx.Text, out d);
            bool f_dy = double.TryParse(textBox_dy.Text, out d);

            bool f_angle = double.TryParse(textBox_angle.Text, out d);
            bool f_turn_around_x = double.TryParse(textBox_turn_around_x.Text, out d);
            bool f_turn_around_y = double.TryParse(textBox_turn_around_y.Text, out d);

            bool f_x_axis_scaling = double.TryParse(textBox_x_axis_scaling.Text, out d);
            bool f_y_axis_scaling = double.TryParse(textBox_y_axis_scaling.Text, out d);
            bool f_turn_around_x2 = double.TryParse(textBox_turn_around_x2.Text, out d);
            bool f_turn_around_y2 = double.TryParse(textBox_turn_around_y2.Text, out d);


            int picture_center_x = pictureBox1.Width / 2;
            int picture_center_y = pictureBox1.Height / 2;

            //------------------------------------------------------------------
            //-----move---------------
            if (!f_dx)
            {
                textBox_dx.Text = "";
            }
            if (!f_dy)
            {
                textBox_dy.Text = "";
            }
            //-----turn around point-------------------------------------------
            if (!f_angle)
            {
                textBox_angle.Text = "";
            }
            if (!f_turn_around_x)
            {
                textBox_turn_around_x.Text = "";
            }
            if (!f_turn_around_y)
            {
                textBox_turn_around_y.Text = "";
            }
            //-------point scaling-----------------------------------------
            if (!f_x_axis_scaling)
            {
                textBox_x_axis_scaling.Text = "";
            }
            if (!f_y_axis_scaling)
            {
                textBox_y_axis_scaling.Text = "";
            }
            if (!f_turn_around_x2)
            {
                textBox_turn_around_x2.Text = "";
            }
            if (!f_turn_around_y2)
            {
                textBox_turn_around_y2.Text = "";
            }
            //------------------------------------------------
            //Проверка и заполнение нужных полей

            double dx = 0;
            double dy = 0;

            double angle = 0;
            double turn_around_x = 0;
            double turn_around_y = 0;

            double x_axis_scaling = 0;
            double y_axis_scaling = 0;
            double turn_around_x2 = 0;
            double turn_around_y2 = 0;

            int number_of_polygon = 0;

            if (checkBox_move.Checked)
            {
                if(!f_dx || !f_dy)
                {
                    MessageBox.Show("move fields", "Error", MessageBoxButtons.OK);
                    return;
                }

                dx = double.Parse(textBox_dx.Text);
                dy = double.Parse(textBox_dy.Text);
            }
            if (checkBox_turn_around_point.Checked)
            {
                if (!f_angle || ((!f_turn_around_x || !f_turn_around_y) && !checkBox_center1.Checked))
                {
                    MessageBox.Show("turn_around_point fields", "Error", MessageBoxButtons.OK);
                    return;
                }

                angle = double.Parse(textBox_angle.Text);
                if (!checkBox_center1.Checked)
                {
                    turn_around_x = double.Parse(textBox_turn_around_x.Text);
                    turn_around_y = double.Parse(textBox_turn_around_y.Text);
                }
            }
            if (checkBox_point_scaling.Checked)
            {
                if (!f_x_axis_scaling || !f_y_axis_scaling || ((!f_turn_around_x2 || !f_turn_around_y2) && !checkBox_center2.Checked))
                {
                    MessageBox.Show("point_scaling fields", "Error", MessageBoxButtons.OK);
                    return;
                }
                x_axis_scaling = double.Parse(textBox_x_axis_scaling.Text);
                y_axis_scaling = double.Parse(textBox_y_axis_scaling.Text);
                if (!checkBox_center2.Checked)
                {
                    turn_around_x2 = double.Parse(textBox_turn_around_x2.Text);
                    turn_around_y2 = double.Parse(textBox_turn_around_y2.Text);
                }
            }
            if (checkBox_move.Checked || checkBox_turn_around_point.Checked || checkBox_point_scaling.Checked)
            {
                if (comboBox_polygon.SelectedIndex == -1)
                {
                    MessageBox.Show("number_of_polygon fields", "Error", MessageBoxButtons.OK);
                    return;
                }
                number_of_polygon = comboBox_polygon.SelectedIndex;
            }
            //------------------------------------------------------------------
            //Центр масс
            //centerX
            if (polygonList.Count <= number_of_polygon)
            {
                MessageBox.Show("number_of_polygon is false", "Error", MessageBoxButtons.OK);
                return;
            }

            double sumX = 0;
            foreach(P p in polygonList[number_of_polygon].points)
            {
                sumX += p.x;
            }

            double centerX = sumX / polygonList[number_of_polygon].pointCounts;
            double a1 = centerX;
            double a2 = centerX;

            //centerY
            double sumY = 0;
            foreach (P p in polygonList[number_of_polygon].points)
            {
                sumY += p.y;
            }
            double centerY = sumY / polygonList[number_of_polygon].pointCounts;
            double b1 = centerY;
            double b2 = centerY;

            //------------------------------------------------
            //Выполнение преобразований

            double[,] matrixMove;
            double[,] matrixTurnAroundPoint;
            double[,] matrixPointScaling;

            if (checkBox_move.Checked)
            {
                matrixMove = new double[3, 3];
                matrixMove[0,0] = 1;
                matrixMove[1,1] = 1;
                matrixMove[2,2] = 1;
                matrixMove[2,0] = dx;
                matrixMove[2,1] = dy;

                foreach(P p in polygonList[number_of_polygon].points)
                {
                    double[,] v = new double[1, 3];

                    v[0, 0] = p.x;
                    v[0, 1] = p.y;
                    v[0, 2] = 1;

                    v = MatrixMulti(v, matrixMove);

                    p.x = v[0, 0];
                    p.y = v[0, 1];
                }
            }

            if (checkBox_turn_around_point.Checked)
            {
                if (!checkBox_center1.Checked)
                {
                    a1 = turn_around_x;
                    b1 = turn_around_y;
                }
                matrixTurnAroundPoint = new double[3, 3];
                matrixTurnAroundPoint[0,0] = Math.Cos((angle / 180D) * Math.PI);
                matrixTurnAroundPoint[0,1] = Math.Sin((angle / 180D) * Math.PI);
                matrixTurnAroundPoint[1,0] = -1.0 * Math.Sin((angle / 180D) * Math.PI);
                matrixTurnAroundPoint[1,1] = Math.Cos((angle / 180D) * Math.PI);
                matrixTurnAroundPoint[2,0] = -1.0 * a1 * Math.Cos((angle / 180D) * Math.PI) + b1 * Math.Sin((angle / 180D) * Math.PI) + a1;
                matrixTurnAroundPoint[2,1] = -1.0 * a1 * Math.Sin((angle / 180D) * Math.PI) - b1 * Math.Cos((angle / 180D) * Math.PI) + b1;
                matrixTurnAroundPoint[2,2] = 1;

                foreach (P p in polygonList[number_of_polygon].points)
                {
                    double[,] v = new double[1, 3];

                    v[0, 0] = p.x;
                    v[0, 1] = p.y;
                    v[0, 2] = 1;

                    v = MatrixMulti(v, matrixTurnAroundPoint);

                    p.x = v[0, 0];
                    p.y = v[0, 1];
                }
            }

            if (checkBox_point_scaling.Checked)
            {
                if (!checkBox_center2.Checked)
                {
                    a2 = turn_around_x2;
                    b2 = turn_around_y2;
                }
                matrixPointScaling = new double[3, 3];
                matrixPointScaling[0,0] = x_axis_scaling;
                matrixPointScaling[1,1] = y_axis_scaling;
                matrixPointScaling[2,0] = (1 - x_axis_scaling) * a2;
                matrixPointScaling[2,1] = (1 - y_axis_scaling) * b2;
                matrixPointScaling[2,2] = 1;

                foreach (P p in polygonList[number_of_polygon].points)
                {
                    double[,] v = new double[1, 3];

                    v[0, 0] = p.x;
                    v[0, 1] = p.y;
                    v[0, 2] = 1;

                    v = MatrixMulti(v, matrixPointScaling);

                    p.x = v[0, 0];
                    p.y = v[0, 1];
                }
            }

            Draw();
        }
    }
}
