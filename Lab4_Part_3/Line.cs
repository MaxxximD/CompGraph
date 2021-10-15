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
    class Line
    {
        public P p1;
        public P p2;
        public Line(P p1, P p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
        public void DrawLine(Graphics g, Pen p)
        {
            g.DrawLine(p, new PointF((int)p1.x, (int)p1.y), new PointF((int)p2.x, (int)p2.y));
        }
    }
}
