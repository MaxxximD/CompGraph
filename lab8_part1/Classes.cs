using System;
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
    class P3D
    {
        public double x;
        public double y;
        public double z;
        public P3D()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }
        public P3D(double x, double y, double z = 0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        static public bool operator ==(P3D point1, P3D point2)
        {
            return point1.x == point2.x && point1.y == point2.y && point1.z == point2.z;
        }

        static public bool operator !=(P3D point1, P3D point2)
        {
            return !(point1 == point2);
        }

        static public P3D operator +(P3D point1, P3D point2)
        {
            return new P3D((int)(point1.x + point2.x), (int)(point1.y + point2.y), (int)(point1.z + point2.z));
        }

        static public P3D operator -(P3D point1, P3D point2)
        {
            return new P3D((int)(point1.x - point2.x), (int)(point1.y - point2.y), (int)(point1.z - point2.z));
        }
        public Point ConvertToPoint()
        {
            return new Point((int)x, (int)y);
        }
        public float DistanceTo(P3D p2)
        {
            return (float)Math.Sqrt((x - p2.x) * (x - p2.x) + (y - p2.y) * (y - p2.y) + (z - p2.z) * (z - p2.z));
        }
    }
    class Vector3
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Length
        {
            get
            {
                return (double)Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public Vector3(double x, double y, double z)
        {
            X = x; Y = y; Z = z;
        }

        public Vector3 Normalize() => Length > 0 ? new Vector3(X / Length, Y / Length, Z / Length) : new Vector3(0, 0, 0);

        public static double ScalarProduct(Vector3 v1, Vector3 v2) => v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        public static Vector3 VectorProduct(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2) => new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        public static Vector3 operator -(Vector3 v1, Vector3 v2) => new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
    }
    class Line
    {
        public P3D p1;
        public P3D p2;
        public Line(P3D p1, P3D p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
        public Line(int x1,int y1,int z1,int x2,int y2,int z2)
        {
            p1 = new P3D(x1,y1,z1);
            p2 = new P3D(x2, y2, z2);
        }
        public void DrawLine(Graphics g, Pen p)
        {
            g.DrawLine(p, new PointF((int)p1.x, (int)p1.y), new PointF((int)p2.x, (int)p2.y));
        }
    }
    class Polygon
    {
        public List<P3D> points { get; set; }
        public bool isPolygon = false;
        public int pointCounts = 0;//кол-во точек
        public Polygon()
        {
            points = new List<P3D>();
        }
        public Polygon(List<P3D> points)
        {
            this.points = points;
        }

        public Polygon(params P3D[] ps)
        {
            for (int i = 0; i < ps.Length; i++)
            {
                Add(ps[i]);
            }
        }
        public void Add(P3D p)
        {
            points.Add(p);
            pointCounts++;
            if (pointCounts > 2)
                isPolygon = true;
        }
        public void AddPoint(int x, int y, int z)
        {
            points.Add(new P3D(x, y, z));
        }
       /* public void DrawPolygon(Graphics g, Pen p)
        {
            PointF[] pl;
            pl = new PointF[points.Count()];
            for (int i = 0; i < points.Count(); i++)
                pl[i] = new PointF((int)points[i].x, (int)points[i].y);
            if (isPolygon)
                g.DrawPolygon(p, pl);
        }*/
    }

    class Polyhedron
    {

        public List<P3D> Vertexes { get; set; } = new List<P3D>();

        public List<Line> Edges { get; set; } = new List<Line>();

        public List<List<int>> Faces { get; } = new List<List<int>>();

        public Dictionary<int, List<int>> Adjacency { get; set; } = new Dictionary<int, List<int>>();


        public P3D Center()
        {
            double x = Vertexes.Average(point => point.x);
            double y = Vertexes.Average(point => point.y);
            double z = Vertexes.Average(point => point.z);
            return new P3D(x, y, z);
        }

        public Polyhedron() { }

        public Polyhedron(List<P3D> points)
        {
            Vertexes = points;
            int i = 0;
            foreach (P3D point in points)
            {
                i++;
                Adjacency.Add(i, new List<int>());
            }
        }
        public Polyhedron(Polyhedron old)
        {
            Vertexes = new List<P3D>(old.Vertexes);
            Edges = new List<Line>(old.Edges);
            Adjacency = new Dictionary<int, List<int>>();
            foreach (var ad in old.Adjacency)
                Adjacency.Add(ad.Key, new List<int>(ad.Value));
            Faces = new List<List<int>>();
            foreach (var f in old.Faces)
                Faces.Add(new List<int>(f));
        }

        public void AddEdge(int p1, int p2)
        {
            if (!Adjacency.ContainsKey(p1))
                Adjacency.Add(p1, new List<int> { p2 });
            else
                Adjacency[p1].Add(p2);
        }
        public void AddEdges(int p1, List<int> lst)
        {
            foreach (int to in lst)
                AddEdge(p1, to);
        }

        //Добавляет грань
        public void AddFace(List<int> lst)
        {
            Faces.Add(lst);
        }
    }
}
