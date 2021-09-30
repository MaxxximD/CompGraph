using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_Lesson_2
{
    public partial class Form1 : Form
    {
        string file_name;
        double newHue = 0;
        double newSaturation = 0.0;
        double newValue = 0.0;

        public Form1()
        {
            InitializeComponent();
            file_name = "";
        }

        private void Hue_Enter(object sender, EventArgs e)
        {
            if (Hue_textBox.Text == "[-360, 360]")
            {
                Hue_textBox.Text = "";

                Hue_textBox.ForeColor = Color.Black;
            }
        }

        private void Hue_Leave(object sender, EventArgs e)
        {
            if (Hue_textBox.Text == "")
            {
                Hue_textBox.Text = "[-360, 360]";

                Hue_textBox.ForeColor = Color.Silver;
            }
        }

        private void Saturation_Enter(object sender, EventArgs e)
        {
            if (Saturation_textBox.Text == "[-1, 1]")
            {
                Saturation_textBox.Text = "";

                Saturation_textBox.ForeColor = Color.Black;
            }
        }

        private void Saturation_Leave(object sender, EventArgs e)
        {
            if (Saturation_textBox.Text == "")
            {
                Saturation_textBox.Text = "[-1, 1]";

                Saturation_textBox.ForeColor = Color.Silver;
            }
        }

        private void Value_Enter(object sender, EventArgs e)
        {
            if (Value_textBox.Text == "[-1, 1]")
            {
                Value_textBox.Text = "";

                Value_textBox.ForeColor = Color.Black;
            }
        }

        private void Value_Leave(object sender, EventArgs e)
        {
            if (Value_textBox.Text == "")
            {
                Value_textBox.Text = "[-1, 1]";

                Value_textBox.ForeColor = Color.Silver;
            }
        }
        private void choose_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                file_name = openFileDialog1.FileName;
            }

            //read image
            Bitmap bmp = new Bitmap(file_name);

            //load image in picturebox
            pictureBox1.Image = bmp;

        }
        private void convert_button_Click(object sender, EventArgs e)
        {
            bool f = double.TryParse(Hue_textBox.Text, out newHue);
            if (!f)
            {
                MessageBox.Show("Hue block doesn't have a number", "Error", MessageBoxButtons.OK);
            }
            f = double.TryParse(Saturation_textBox.Text, out newSaturation);
            if (!f)
            {
                MessageBox.Show("Saturation block doesn't have a number", "Error", MessageBoxButtons.OK);
            }
            f = double.TryParse(Value_textBox.Text, out newValue);
            if (!f)
            {
                MessageBox.Show("Value block doesn't have a number", "Error", MessageBoxButtons.OK);
            }

            double hue_cur = 0;
            double saturation_cur = 0.0;
            double value_cur = 0.0;

            // Create a Bitmap object from an image file.
            if (file_name != "")
            {
                Bitmap myBitmap = new Bitmap(file_name);
                Bitmap newBitmap = new Bitmap(myBitmap.Width, myBitmap.Height);
                //Bitmap newBitmap = new Bitmap(file_name.Split('.')[0] + "_out." + file_name.Split('.')[1]);

                // Get the color of a pixel within myBitmap.
                for (int x = 0; x < pictureBox1.Image.Width; x++)
                {
                    for (int y = 0; y < pictureBox1.Image.Height; y++)
                    {
                        Color pixelColor = myBitmap.GetPixel(x, y);

                        ColorToHSV(pixelColor, out hue_cur, out saturation_cur, out value_cur);
                        hue_cur += newHue;
                        saturation_cur += newSaturation;
                        value_cur += newValue;

                        //----------------------------------
                        if (hue_cur > 360)
                            hue_cur = 360;

                        if (saturation_cur > 1)
                            saturation_cur = 1;

                        if (value_cur > 1)
                            value_cur = 1;

                        if (hue_cur < 0)
                            hue_cur = 0;

                        if (saturation_cur < 0)
                            saturation_cur = 0;

                        if (value_cur < 0)
                            value_cur = 0;
                        //----------------------------------


                        Color newPixelColor = ColorFromHSV(hue_cur, saturation_cur, value_cur);

                        newBitmap.SetPixel(x, y, newPixelColor);
                    }
                }

                //load image in picturebox
                pictureBox2.Image = newBitmap;
            }
            else MessageBox.Show("Picture not found", "Error", MessageBoxButtons.OK);
        }
        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
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

        private void save_button_Click(object sender, EventArgs e)
        {
            Bitmap btm = new Bitmap(pictureBox2.Image);
            Image img = btm;
            img.Save(file_name.Split('.')[0] + "_out." + file_name.Split('.')[1]);
        }
    }
}
