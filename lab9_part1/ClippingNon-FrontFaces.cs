using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class ClippingNon_FrontFaces
    {
        //Получение нормали
        public static P3D ReceiveNormalVector(List<int> face, List<P3D> vertexes)
        {
            P3D vec_1 = vertexes[face[1]] - vertexes[face[0]];
            P3D vec_2 = vertexes[face[2]] - vertexes[face[1]];
            return VectorProductOfVectors(vec_1, vec_2);
        }

        //Получение видимых сторон
        public static List<List<int>> ReceiveVisibleFaces(Polyhedron p, P3D viewDirection)
        {
            List<List<int>> res = new List<List<int>>();
            P3D proec = p.Center() - viewDirection;
            int i = 0;//для нормалей
            foreach (var face in p.Faces) // для каждой грани ищем вектор нормали
            {
                //           -----
                //           (a,b)              ax * bx + ay * by
                // cos f = -------- = ---------------------------------------
                //          --- ---    sqrt(ax^2 + ay^2) * sqrt(bx^2 + by^2)
                //          |a|*|b|
                //
                P3D norm = ReceiveNormalVector(face, p.Vertexes);
              
                var scalar = norm.x * proec.x + norm.y * proec.y + norm.z * proec.z;
                var prod = Math.Sqrt(norm.x * norm.x + norm.y * norm.y + norm.z * norm.z) * Math.Sqrt(proec.x * proec.x + proec.y * proec.y + proec.z * proec.z);
               
                //Если векторы сонаправлены, то угол между ними будет равен 0°, а косинус равен 1
                //Если векторы направлены противоположно, то угол между ними будет равен 180°, так как косинус этого угла равен −1
                double cos = 0.0;
                cos = scalar / prod;

                if (cos > 0)
                    res.Add(face);

                i++;
            }
            return res;
        }

        //Векторное произведение векторов
        private static P3D VectorProductOfVectors(P3D v1, P3D v2)
        {
            double x = v1.y * v2.z - v1.z * v2.y;
            double y = v1.z * v2.x - v1.x * v2.z;
            double z = v1.x * v2.y - v1.y * v2.x;
            return new P3D(x, y, z);
        }
    }
}
