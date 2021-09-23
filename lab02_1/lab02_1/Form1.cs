using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab02_1
{
    public partial class Form1 : Form
    {
        Bitmap image1;
        Bitmap image2;

        public Form1()
        {
            InitializeComponent();
        }

        //Загрузить 
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Image Files(*.JPG)|*.JPG|All files(*.*)|*.*"; 
            if (op.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = new Bitmap(op.FileName);
        }

        //Выполнить
        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap input = new Bitmap(pictureBox1.Image);
                image1 = GetShadesOfgray(input, "NTSC");
                pictureBox2.Image = image1;
                image2 = GetShadesOfgray(input, "sRGB");
                pictureBox3.Image = image2;
                pictureBox4.Image = GetDiff(image1, image2);
            }
            else
                MessageBox.Show("Сначала загрузите изображение!");
           
        }

        //Построить гистограмму интенсивности оттенков серого после преобразований
        private void button3_Click(object sender, EventArgs e)
        {
            string s_out;
            pictureBox5.Image = Histogram.DrawHistogram(image1, "GRAY", pictureBox3.Width, pictureBox3.Height, out s_out);
            label4.Text = "max значение:" + s_out;
            pictureBox6.Image = Histogram.DrawHistogram(image2, "GRAY", pictureBox4.Width, pictureBox4.Height, out s_out);
            label5.Text = "max значение:" + s_out;
        }

        static private Bitmap GetShadesOfgray(Bitmap source, string formula)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);
            switch (formula)
            {
                case "NTSC":
                    for (int i = 0; i < source.Width; i++)
                        for (int j = 0; j < source.Height; j++)
                        {
                            Color color = source.GetPixel(i, j);
                            var res = 0.299 * color.R + 0.587 * color.G + 0.114 * color.B; // Преобразование цветного изображения в оттенки серого
                            var new_color = (int)(res <= 255 ? res : 255); // чтобы не выйти за границы диапазона
                            result.SetPixel(i, j, Color.FromArgb(color.A, new_color, new_color, new_color));
                        }
                    break;
                case "sRGB":
                    for (int i = 0; i < source.Width; i++)
                        for (int j = 0; j < source.Height; j++)
                        {
                            Color color = source.GetPixel(i, j);
                            var res = 0.2126 * color.R + 0.7152 * color.G + 0.0722 * color.B; // Преобразование цветного изображения в оттенки серого
                            var new_color = (int)(res <= 255 ? res : 255);
                            result.SetPixel(i, j, Color.FromArgb(color.A, new_color, new_color, new_color));
                        }
                    break;
                default:
                    break;
            }
            return result;
        }


        // получить разницу
        static private Bitmap GetDiff(Bitmap img1, Bitmap img2)
        {
            //Инициализация
            Bitmap diff = new Bitmap(img1.Width, img1.Height);
            List<List<(int, int, int, int)>> lst = new List<List<(int, int, int, int)>>(img1.Width);
            for (int i = 0; i < img1.Width; i++)
            {
                lst.Add(new List<(int, int, int, int)>(img1.Height));
                for (int j = 0; j < img1.Height; j++)
                    lst[i].Add((0, 0, 0, 0));
            }
            

            //Вычисление разницы
            for (int i = 0; i < img1.Width; i++)
                for (int j = 0; j < img1.Height; j++)
                {
                    Color color1 = img1.GetPixel(i, j);
                    Color color2 = img2.GetPixel(i, j);
                    lst[i][j] = (color1.A - color2.A, color1.R - color2.R, color1.G - color2.G, color1.B - color2.B);
                }


            //Подсчёт минимума
            var min = (lst.Min(a => a.Min(i => i.Item1)), lst.Min(a => a.Min(i => i.Item2)), lst.Min(a => a.Min(i => i.Item2)), lst.Min(a => a.Min(i => i.Item2)));
            var max = (lst.Max(a => a.Max(i => i.Item1)), lst.Max(a => a.Max(i => i.Item2)), lst.Max(a => a.Max(i => i.Item2)), lst.Max(a => a.Max(i => i.Item2)));
            var dif = (max.Item1 - min.Item1, max.Item2 - min.Item2, max.Item3 - min.Item3, max.Item4 - min.Item4);


            //Нормализация на основе минимума
              for (int i = 0; i < img1.Width; i++)
                 for (int j = 0; j < img1.Height; j++)
                 {
                     diff.SetPixel(i, j, Color.FromArgb((lst[i][j].Item2 - min.Item2) * (255 / dif.Item2), (lst[i][j].Item3 - min.Item3) * (255 / dif.Item3), (lst[i][j].Item4 - min.Item4) * (255 / dif.Item4)));
                 }
            return diff;
            
        }



    }
}
