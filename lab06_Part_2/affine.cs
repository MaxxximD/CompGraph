using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class affine
    {
        static private double[,] matrixColumnFromPoint3D(P3D point)
        {
            return new double[,] { { point.x }, { point.y }, { point.z }, { 1 } };
        }

        // Применения матрицы преобразований к каждой точке многогранника
        static private void ChangePolyhedron(Polyhedron polyhedron, double[,] matrix)
        {
            List<P3D> points = new List<P3D>();
            for (int i = 0; i < polyhedron.Vertexes.Count; ++i) 
            {
                var matrixPoint = Projection.MultMatrix(matrix, matrixColumnFromPoint3D(polyhedron.Vertexes[i]));
                P3D newPoint = new P3D((int)(matrixPoint[0, 0] / matrixPoint[3, 0]), (int)(matrixPoint[1, 0] / matrixPoint[3, 0]), (int)(matrixPoint[2, 0] / matrixPoint[3, 0]));
                polyhedron.Vertexes[i] = newPoint;
            }
        }

        // Смещение
        static public void translate(Polyhedron polyhedron, double tx, double ty, double tz)
        {
            double[,] translation = { { 1, 0, 0, tx },
                                     { 0, 1, 0, ty },
                                     { 0, 0, 1, tz },
                                     { 0, 0, 0,  1 }};

            ChangePolyhedron(polyhedron, translation);
        }
        
        // Масштаб
        static public void scale(Polyhedron polyhedron, double mx, double my, double mz)
        {
            double[,] scale = { { mx,  0,  0,  0 },
                               {  0, my,  0,  0 },
                               {  0,  0, mz,  0 },
                               {  0,  0,  0,  1 }};

            ChangePolyhedron(polyhedron, scale);
        }

        //Вращение
        static public void rotation(Polyhedron polyhedron, double angleX, double angleY, double angleZ)
        {
            P3D shiftPoint = polyhedron.Center();
            double shiftX = shiftPoint.x,
                  shiftY = shiftPoint.y,
                  shiftZ = shiftPoint.z;

            translate(polyhedron, -shiftX, -shiftY, -shiftZ);

            double sin = (double)Math.Sin(angleX * Math.PI / 180);
            double cos = (double)Math.Cos(angleX * Math.PI / 180);
            double[,] matrixX = { { 1,  0,   0,  0},
                                 { 0, cos,-sin, 0},
                                 { 0, sin, cos, 0},
                                 { 0,  0,   0,  1}};

            sin = (double)Math.Sin(angleY * Math.PI / 180);
            cos = (double)Math.Cos(angleY * Math.PI / 180);
            double[,] matrixY = { { cos, 0, sin, 0},
                                 {  0,  1,  0,  0},
                                 {-sin, 0, cos, 0},
                                 {  0,  0,  0,  1}};

            sin = (double)Math.Sin(angleZ * Math.PI / 180);
            cos = (double)Math.Cos(angleZ * Math.PI / 180);
            double[,] matrixZ = { { cos, -sin, 0, 0},
                                 { sin,  cos, 0, 0},
                                 {  0,    0,  1, 0},
                                 {  0,    0,  0, 1}};

            ChangePolyhedron(polyhedron, Projection.MultMatrix(Projection.MultMatrix(matrixX, matrixY), matrixZ));

            translate(polyhedron, shiftX, shiftY, shiftZ);
        }

        // Отражение относительно выбранной координатной плоскости
        static public void reflection(Polyhedron polyhedron, string plane)
        {
            double[,] matr;
            switch (plane)
            {
                case "xy":
                    matr = new double[,] {{ 1, 0,  0, 0 },
                                           { 0, 1,  0, 0 },
                                           { 0, 0, -1, 0 },
                                           { 0, 0,  0, 1 }};
                    break;
                case "xz":
                    matr = new double[,] {{ 1,  0, 0, 0 },
                                           { 0, -1, 0, 0 },
                                           { 0,  0, 1, 0 },
                                           { 0,  0, 0, 1 }};
                    break;
                case "yz":
                    matr = new double[,] {{ -1, 0, 0, 0 },
                                           {  0, 1, 0, 0 },
                                           {  0, 0, 1, 0 },
                                           {  0, 0, 0, 1 }};
                    break;
                default:
                    matr = new double[,] {{ 1, 0, 0, 0 },
                                           { 0, 1, 0, 0 },
                                           { 0, 0, 1, 0 },
                                           { 0, 0, 0, 1 }};
                    break;
            }
            ChangePolyhedron(polyhedron, matr);
        }

        // Поворот вокруг произвольной (заданной координатами двух точек) прямой на заданный угол. 
        static public void rotate_line(Polyhedron polyhedron, double angle, Line line)
        {
            var vec = line.p1 - line.p2;
            var len = Math.Sqrt(Math.Pow(vec.x, 2) + Math.Pow(vec.y, 2) + Math.Pow(vec.z, 2));
            var l = (double)(vec.x / len);
            var m = (double)(vec.y / len);
            var n = (double)(vec.z / len);

            double sin = (double)Math.Sin(angle * Math.PI / 180);
            double cos = (double)Math.Cos(angle * Math.PI / 180);

            double[,] matr = { { l*l+cos*(1-l*l),   l*(1-cos)*m-n*sin, l*(1-cos)*n+m*sin, 0 },
                              { l*(1-cos)*m+n*sin, m*m+cos*(1-m*m),   m*(1-cos)*n-l*sin, 0 },
                              { l*(1-cos)*n-m*sin, m*(1-cos)*n+l*sin, n*n+cos*(1-n*n),   0 },
                              { 0,                 0,                 0,                 1 }};

            ChangePolyhedron(polyhedron, matr);
        }
    }
}
