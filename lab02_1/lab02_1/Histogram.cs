using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab02_1
{
    static class Histogram
    {
        public static Bitmap DrawHistogram(Bitmap image, string my_color, int boxWidth, int boxHeight, out string maxS)
        {
            // ширина и высота входного изображения
            int width = image.Width, height = image.Height;
            Bitmap hist = new Bitmap(boxWidth, boxHeight);

            //массив, для хранения количества повторений каждого из значений каналов
            int[] arr_colors = new int[256];

            Color color;
            // получаем количество повторений каждого из значений канала
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                {
                    color = image.GetPixel(i, j);
                    if (my_color == "R")
                    {
                        arr_colors[color.R]++;
                    }
                    else if (my_color == "G")
                    {
                        arr_colors[color.G]++;
                    }
                    else
                    {
                        arr_colors[color.B]++;
                    }
                }

            // определяем коэффициент масштабирования по высоте
            int max = 0;
            for (int i = 0; i < 256; ++i)
            {
                if (arr_colors[i] > max)
                    max = arr_colors[i];
            }
            // выводим максимальное значение на график
            maxS = max.ToString();
            // коэффициент масштабирования
            double point = (double)max / boxHeight;

            // рисуем гистограмму
            Color histColor;
            if (my_color == "R")
            {
                histColor = Color.Red;
            }
            else if (my_color == "G")
            {
                histColor = Color.Green;
            }
            else if (my_color == "B")
            {
                histColor = Color.Blue;
            }
            else
            {
                histColor = Color.Black;
            }
            for (int i = 0; i < 256; ++i)
            {
                for (var j = boxHeight - 1; j > boxHeight - arr_colors[i] / point; --j)
                {
                    hist.SetPixel(i, j, histColor);
                }
            }
            return hist;
        }
    }
}
