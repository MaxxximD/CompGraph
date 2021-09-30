using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.JPG;*.PNG)|;*.JPG;*.PNG|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);

                }
                catch
                {
                    MessageBox.Show("unsupported type", "error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] arr = new int[256];
            Bitmap input = new Bitmap(pictureBox1.Image);
            Bitmap result = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            for (int i = 0; i < input.Width; i++)
            {
                for (int j = 0; j < input.Height; j++)
                {
                    Color color = input.GetPixel(i, j);
                    arr[color.R]++;
                    result.SetPixel(i, j, Color.FromArgb(color.A, color.R, color.R, color.R));
                }
            }
            pictureBox2.Image = result;
            int max = 0;
            for (int i = 0; i < 256; ++i)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            double point = (double)max / pictureBox2.Height;
            Bitmap histogram = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            for (int i = 0; i < 256; ++i)
            {
                for (var j = pictureBox3.Height - 1; j > pictureBox3.Height - arr[i] / point; --j)
                {
                    histogram.SetPixel(i, j, Color.Red);
                }
            }
            pictureBox3.Image = histogram;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] arr = new int[256];
            Bitmap input = new Bitmap(pictureBox1.Image);
            Bitmap result = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            for (int i = 0; i < input.Width; i++)
            {
                for (int j = 0; j < input.Height; j++)
                {
                    Color color = input.GetPixel(i, j);
                    arr[color.G]++;
                    result.SetPixel(i, j, Color.FromArgb(color.A, color.G, color.G, color.G));
                }
            }
            pictureBox2.Image = result;
            int max = 0;
            for (int i = 0; i < 256; ++i)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            double point = (double)max / pictureBox2.Height;
            Bitmap histogram = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            for (int i = 0; i < 256; ++i)
            {
                for (var j = pictureBox3.Height - 1; j > pictureBox3.Height - arr[i] / point; --j)
                {
                    histogram.SetPixel(i, j, Color.Green);
                }
            }
            pictureBox3.Image = histogram;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] arr = new int[256];
            Bitmap input = new Bitmap(pictureBox1.Image);
            Bitmap result = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            for (int i = 0; i < input.Width; i++)
            {
                for (int j = 0; j < input.Height; j++)
                {
                    Color color = input.GetPixel(i, j);
                    arr[color.B]++;
                    result.SetPixel(i, j, Color.FromArgb(color.A, color.B, color.B, color.B));
                }
            }
            pictureBox2.Image = result;
            int max = 0;
            for (int i = 0; i < 256; ++i)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            double point = (double)max / pictureBox2.Height;

            Bitmap histogram = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            for (int i = 0; i < 256; ++i)
            {
                for (var j = pictureBox3.Height - 1; j > pictureBox3.Height - arr[i] / point; --j)
                {
                    histogram.SetPixel(i, j, Color.Blue);
                }
            }
            pictureBox3.Image = histogram;
        }
    }
}
