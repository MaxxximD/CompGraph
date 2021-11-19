﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    class Camera
    {
        public P3D Position { get; set; } = new P3D(0, 0, 0);
        public P3D Focus { get; set; } = new P3D(0, 0, 0);
        public PointF Offset { get; set; } = new PointF(0, 0);
        public double AngleX { get; private set; } = 0;

        public void MoveCamera(int dx, int dy, int dz)
        {
            Position += new P3D(dx, dy, dz);
            Focus += new P3D(dx, dy, 0);
        }
        public void RotateCamera(double ax)
        {
            AngleX += ax;

            if (AngleX > 360) AngleX -= 360;
            else if (AngleX < 0) AngleX += 360;
        }
    }

    class Projection
    {
        static public double[,] perspective =
        {
            { 1, 0, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 0, 0, (float)-0.001 },
            { 0, 0, 0, 1 }
        };

        static public double[,] isometric =
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
                P3D p1 = new P3D((tmp[0, 0] / tmp[0, 3]), (tmp[0, 1] / tmp[0, 3]));
                foreach (int index in polyhedron.Adjacency[i])
                {
                    P3D t = polyhedron.Vertexes[index];
                    double[,] tmp1 = MultMatrix(new double[,] { { (double)t.x, (double)t.y, (double)t.z, 1 } }, matr);
                    P3D p2 = new P3D((tmp1[0, 0] / tmp1[0, 3]), (tmp1[0, 1] / tmp1[0, 3]));
                    edges.Add(new Line(p1, p2));
                }
                i++;
            }
            return edges;
        }
    }
}
