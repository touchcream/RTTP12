using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace RayTracer
{
    class Sphere : IComparable
    {
        public int x { get; set;}
        public int y { get; set; }
        public float z { get; set; }
        public int rayon { get; set; }
        public Color color { get; set; }

        public Sphere(int x, int y, int z, int radius, Color color)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.rayon = radius;
            this.color = color;
        }

        public bool is_in_bound(int x, int y)
        {
            //float prof = z / 10;
            float prof = 1;
            return (x - this.x) * (x - this.x) + (y - this.y) * (y - this.y) < (rayon/prof * rayon/prof);
        }

        public int CompareTo(object obj)
        {
            if (obj is Sphere)
            {
                Sphere d = (Sphere)obj;
                return z.CompareTo(d.z);
            }
            else
                throw new Exception();
        }

        public override string ToString()
        {
            return "Sphere:{"+x+";"+y+";"+z+"}:"+rayon;
        }
    }
}
