using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab6
{
    class Z
    {
        private static int ProjMode = 0;

        public static Bitmap Z_buffer(int width, int heigh, List<Polyhedron> scene, List<Color> colors, int projMode = 0)
        {
            ProjMode = projMode;

            Bitmap newImg = new Bitmap(width, heigh);
            double[,] zbuff = new double[width, heigh];

            for (int i = 0; i < width; i++)
                for (int j = 0; j < heigh; j++)
                    newImg.SetPixel(i, j, Color.White);
         
            for (int i = 0; i < width; i++)
                for (int j = 0; j < heigh; j++)
                    zbuff[i, j] = double.MinValue;

            List<List<List<P3D>>> rasterizedScene = new List<List<List<P3D>>>();
            for (int i = 0; i < scene.Count; i++)
                rasterizedScene.Add(Rasterize(scene[i]));

            var centerX = width / 2;
            var centerY = heigh / 2;

            int new_i = 0;
            for (int i = 0; i < rasterizedScene.Count; i++)
            {
                //Смещение по центру фигуры
                var figureLeftX = rasterizedScene[i].Where(face => face.Count != 0).Min(face => face.Min(vertex => vertex.x));
                var figureLeftY = rasterizedScene[i].Where(face => face.Count != 0).Min(face => face.Min(vertex => vertex.y));
                var figureRightX = rasterizedScene[i].Where(face => face.Count != 0).Max(face => face.Max(vertex => vertex.x));
                var figureRightY = rasterizedScene[i].Where(face => face.Count != 0).Max(face => face.Max(vertex => vertex.y));
                var figureCenterX = (figureRightX - figureLeftX) / 2;
                var figureCenterY = (figureRightY - figureLeftY) / 2;

                Random r = new Random();

                for (int j = 0; j < rasterizedScene[i].Count; j++)
                {
                    List<P3D> curr = rasterizedScene[i][j];
                    foreach (P3D point in curr)
                    {
                        int x = (int)(point.x + centerX - figureCenterX);
                        int y = (int)(point.y + centerY - figureCenterY);
                        if (x < width && y < heigh && x > 0 && y > 0)
                        {
                            if (point.z > zbuff[x, y])
                            {
                                zbuff[x, y] = point.z;
                                newImg.SetPixel(x, y, colors[new_i % colors.Count]);
                            }
                        }
                    }
                    new_i++;
                }
            }
            return newImg;
        }

        private static List<List<P3D>> Rasterize(Polyhedron polyhedron)
        {
            List<List<P3D>> rasterized = new List<List<P3D>>();
            foreach (var facet in polyhedron.Faces)
            {
                List<P3D> currentFac = new List<P3D>();
                List<P3D> facetPoint3Ds = new List<P3D>();
                for (int i = 0; i < facet.Count; i++)
                {
                    facetPoint3Ds.Add(polyhedron.Vertexes[facet[i]]);
                }

                List<List<P3D>> triangles = triangulate(facetPoint3Ds);
                foreach (List<P3D> triangle in triangles)
                {
                    currentFac.AddRange(RasterizeTriangle(MakeProj(triangle)));
                }
                rasterized.Add(currentFac);
            }
            return rasterized;
        }


        private static List<P3D> RasterizeTriangle(List<P3D> points)
        {
            List<P3D> res = new List<P3D>();

            points.Sort((point1, point2) => point1.y.CompareTo(point2.y));
            //var rpoints = points.Select(point => (x: (int)Math.Round(point.x), y: (int)Math.Round(point.y), z: (int)Math.Round(point.z))).ToList();

            var interX1 = interpolate((int)Math.Round(points[0].y), (int)Math.Round(points[0].x), (int)Math.Round(points[1].y), (int)Math.Round(points[1].x));
            var interX2 = interpolate((int)Math.Round(points[1].y), (int)Math.Round(points[1].x), (int)Math.Round(points[2].y), (int)Math.Round(points[2].x));
            var interX3 = interpolate((int)Math.Round(points[0].y), (int)Math.Round(points[0].x), (int)Math.Round(points[2].y), (int)Math.Round(points[2].x));

            var interZ1 = interpolate((int)Math.Round(points[0].y), (int)Math.Round(points[0].z), (int)Math.Round(points[1].y), (int)Math.Round(points[1].z));
            var interZ2 = interpolate((int)Math.Round(points[1].y), (int)Math.Round(points[1].z), (int)Math.Round(points[2].y), (int)Math.Round(points[2].z));
            var interZ3 = interpolate((int)Math.Round(points[0].y), (int)Math.Round(points[0].z), (int)Math.Round(points[2].y), (int)Math.Round(points[2].z));


            interX1.RemoveAt(interX1.Count - 1);
            List<int> unitedX = interX1.Concat(interX2).ToList();

            interZ1.RemoveAt(interZ1.Count - 1);
            List<int> unitedZ = interZ1.Concat(interZ2).ToList();

            int middle = unitedX.Count / 2;
            List<int> leftX, rightX, leftZ, rightZ;

            if (interX3[middle] < unitedX[middle])
            {
                leftX = interX3;
                rightX = unitedX;

                leftZ = interZ3;
                rightZ = unitedZ;
            }
            else
            {
                leftX = unitedX;
                rightX = interX3;

                leftZ = unitedZ;
                rightZ = interZ3;
            }

            int y0 = (int)Math.Round(points[0].y);
            int y2 = (int)Math.Round(points[2].y);

            while (y2 - y0 > leftX.Count || y2 - y0 > rightX.Count || y2 - y0 > rightZ.Count || y2 - y0 > leftZ.Count)
            {
                y2--;
            }
            

            for (int ind = 0; ind <= y2 - y0; ind++)
            {
                int XL = leftX[ind];
                int XR = rightX[ind];

                List<int> intCurrZ = interpolate(XL, leftZ[ind], XR, rightZ[ind]);

                for (int x = XL; x < XR; x++)
                {
                    res.Add(new P3D(x, y0 + ind, intCurrZ[x - XL]));
                }
            }

            return res;
        }


        private static List<List<P3D>> triangulate(List<P3D> points)
        {
            List<List<P3D>> res = new List<List<P3D>>();

            if (points.Count == 3)
                return new List<List<P3D>> { points };

           
            for (int i = 2; i < points.Count; i++)
            {
                res.Add(new List<P3D> { points[0], points[i - 1], points[i] });
            }

            return res;
        }

        // d = f(i)
        private static List<int> interpolate(int i0, int d0, int i1, int d1)
        {
            if (i0 == i1)
            {
                return new List<int> { d0 };
            }
            List<int> res = new List<int>();

            double step = (d1 - d0) * 1.0f / (i1 - i0);
            double value = d0;
            for (int i = i0; i <= i1; i++)
            {
                res.Add((int)value);
                value += step;
            }

            return res;
        }

        public static List<P3D> MakeProj(List<P3D> init) => new Projection().Project2(init, ProjMode);
    }
}
