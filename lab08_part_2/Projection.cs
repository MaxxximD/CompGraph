using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Projection
    {
        static private double[,] perspective =
        {
            { 1, 0, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 0, 0, (float)-0.001 },
            { 0, 0, 0, 1 }
        };

        static private double[,] isometric =
           {  { (float)Math.Sqrt(0.5), 0, (float)-Math.Sqrt(0.5), 0 },
               { 1 / (float)Math.Sqrt(6), 2 /(float) Math.Sqrt(6), 1 / (float)Math.Sqrt(6), 0 },
               { 1 / (float)Math.Sqrt(3), -1 / (float)Math.Sqrt(3), 1 / (float)Math.Sqrt(3), 0 },
               { 0, 0, 0, 1 }

        };

        static public double[,] MultMatrix(double[,] m1, double[,] m2)
        {
            double[,] res = new double[m1.GetLength(0), m2.GetLength(1)];
            for (int i = 0; i < m1.GetLength(0); ++i)
                for (int j = 0; j < m2.GetLength(1); ++j)
                    for (int k = 0; k < m2.GetLength(0); k++)
                    {
                        res[i, j] += m1[i, k] * m2[k, j];
                    }
            return res;
        }

        public List<Line> Project(Polyhedron polyhedron, int mode)
        {
            double[,] matr;
            switch (mode)
            {
                case 0:
                    matr = perspective;
                    break;
                case 1:
                    matr = isometric;
                    break;
                default:
                    throw new ArgumentException();
            }
            List<Line> edges = new List<Line>();
            int i = 0;
            foreach (P3D p in polyhedron.Vertexes)
            {
                double[,] tmp = MultMatrix(new double[,] { { (double)p.x, (double)p.y, (double)p.z, 1 } }, matr);
                P3D p1 = new P3D((int)(tmp[0, 0] / tmp[0, 3]), (int)(tmp[0, 1] / tmp[0, 3]));
                foreach (int index in polyhedron.Adjacency[i])
                {
                    P3D t = polyhedron.Vertexes[index];
                    double[,] tmp1 = MultMatrix(new double[,] { { (double)t.x, (double)t.y, (double)t.z, 1 } }, matr);
                    P3D p2 = new P3D((int)(tmp1[0, 0] / tmp1[0, 3]), (int)(tmp1[0, 1] / tmp1[0, 3]));
                    edges.Add(new Line(p1, p2));
                }
                i++;
            }
            return edges;
        }

        public List<P3D> Project2(List<P3D> face, int mode = 0)
        {
            double[,] matr;
            switch (mode)
            {
                case 0:
                    matr = perspective;
                    break;
                case 1:
                    matr = isometric;
                    break;
                default:
                    throw new ArgumentException();
            }

            List<P3D> points = new List<P3D>(face);

            for (int i = 0; i < points.Count; ++i)
            {
                double[,] tmp1 = MultMatrix(new double[,] { { points[i].x, points[i].y, points[i].z, 1 } }, matr);
                points[i] = new P3D((int)(tmp1[0, 0] / tmp1[0, 3]), (int)(tmp1[0, 1] / tmp1[0, 3]), (int)(points[i].z));
            }
            return points;
        }
    }
}
