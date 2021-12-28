using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class FigureRotation
    {
        
        // Примененяет матрицу преобразований к точке
        static private P3D change_point(P3D pnt, double[,] matrix)
        {
            var matrixPoint = Projection.MultMatrix(matrix, affine.matrixColumnFromPoint3D(pnt));
            P3D newPoint = new P3D((int)(matrixPoint[0, 0] / matrixPoint[3, 0]), (int)(matrixPoint[1, 0] / matrixPoint[3, 0]), (int)(matrixPoint[2, 0] / matrixPoint[3, 0]));
            return newPoint;

        }

     
        // Поворачивает список точек (образующей)
        static public List<P3D> rotate_points(List<P3D> lstPoints, float angle, char axis)
        {
            double sin = (float)Math.Sin(angle * Math.PI / 180);
            double cos = (float)Math.Cos(angle * Math.PI / 180);
            double[,] matrix;
            switch (axis)
            {
                case 'x':
                    matrix = new double[,]{{ 1,  0,   0,  0},
                                          { 0, cos,-sin, 0},
                                          { 0, sin, cos, 0},
                                          { 0,  0,   0,  1}};
                    break;
                case 'y':
                    matrix = new double[,]{{ cos, 0, sin, 0},
                                          {  0,  1,  0,  0},
                                          {-sin, 0, cos, 0},
                                          {  0,  0,  0,  1}};
                    break;
                case 'z':
                    matrix = new double[,]{{ cos, -sin, 0, 0},
                                          { sin,  cos, 0, 0},
                                          {  0,    0,  1, 0},
                                          {  0,    0,  0, 1}};
                    break;
                default:
                    matrix = new double[,] {{ 1, 0, 0, 0 },
                                           { 0, 1, 0, 0 },
                                           { 0, 0, 1, 0 },
                                           { 0, 0, 0, 1 }};
                    break;
            }
            List<P3D> res = new List<P3D>();
            foreach (var point in lstPoints)
            {
                res.Add(change_point(point, matrix));
            }
            return res;
        }

        
        // Создает фигуру вращения по заданной образующей(набору точек)
        static public Polyhedron createFigureRotation(List<P3D> lst, char axis, int partitions)
        {
            List<P3D> res = new List<P3D>();   // Содержит все точки многогранника (фигуры вращения)
            int lstCount = lst.Count;          // количество точек в кривой, которая задаёт образующую
            float angle = 360.0f / partitions; // угол вращения
            res.AddRange(lst);                 // Добавляем точки образующей в список точек многогранника
            for (int i = 1; i < partitions; i++)
            {
                res.AddRange(rotate_points(lst, angle * i, axis));
            }

            Polyhedron figure = new Polyhedron(res);

            // Добавляет ребра
            for (int i = 0; i < partitions; i++)
            {
                for (int j = 0; j < lstCount; j++)
                {
                    int current = i * lstCount + j;
                    if ((current + 1) % lstCount == 0)
                        figure.AddEdges(current, new List<int> { (current + lstCount) % res.Count });
                    else
                    {
                        // добавляет грани в порядке: текущая, ниже текущей, правее предыдущей, выше предыдущей
                        figure.AddEdges(current, new List<int> { current + 1, (current + lstCount) % res.Count });
                        figure.AddFace(new List<int> { current, current + 1, (current + 1 + lstCount) % res.Count, (current + lstCount) % res.Count });
                    }

                }
            }
            return figure;
        }
    }
}
