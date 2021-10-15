using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    class Polygon
    {
        public List<P> points { get; set; }
        public bool isPolygon = false;
        public int pointCounts = 0;//кол-во точек
        public Polygon()
        {
            points = new List<P>();
        }
        public Polygon(params P[] ps)
        {
            for (int i = 0; i < ps.Length; i++)
            {
                Add(ps[i]);
            }
        }
        public void Add(P p)
        {
            points.Add(p);
            pointCounts++;
            if (pointCounts > 2)
                isPolygon = true;

        }
        public void DrawPolygon(Graphics g, Pen p)
        {
            PointF[] pl;
            pl = new PointF[points.Count()];
            for (int i = 0; i < points.Count(); i++)
                pl[i] = new PointF((int)points[i].x, (int)points[i].y);
            if (isPolygon)
                g.DrawPolygon(p, pl);
        }
    }
}
