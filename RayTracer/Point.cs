using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RayTracer
{
    class Point
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public Point(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public int Distance(Point p)
        {
            return (int)Math.Sqrt((Math.Pow(p.x - x, 2) + Math.Pow(p.y - y, 2) + Math.Pow(p.z - z, 2)));
        }

        public int CompareTo(object obj)
        {
            if (obj is Point)
            {
                Point d = (Point)obj;
                return z.CompareTo(d.z);
            }
            else
                throw new Exception();
        }
        

        public override string ToString()
        {
            return "Point:{" + x + ";" + y + ";" + z + "}";
        }

        static public float operator * (Point v1, Point v2 ) 
        {
	        return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
        }

        static public Point operator +(Point v1, Point v2)
        {
            return new Point(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        static public Point operator -(Point v1, Point v2)
        {
            return new Point(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        static public Point operator *(float v1, Point v2)
        {
            return new Point(v1 * v2.x, v1 * v2.y, v1 * v2.z);
        }
    }
}
