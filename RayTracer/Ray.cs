using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace RayTracer
{
    class Ray
    {
        public Point Direction { get; set; }
        public Point Position { get; set; }
        public int intensity { get; set; }

        public Ray(Point pos, Point dir, int intens)
        {
            Direction = dir;
            Position = pos;
            intensity = intens;
        }

        public Point Intersection(List<Sphere> l_sphere)
        {
            List<Point> l_point = new List<Point>();
            foreach (Sphere s in l_sphere)
            {

                double a, b, c, delta, t1, t2;
                Point p1, p2, p;
                a = Math.Pow(Direction.x, 2) + Math.Pow(Direction.y, 2) + Math.Pow(Direction.z, 2);
                b = 2 * Direction.x * (Position.x - s.x) + 2 * Direction.y * (Position.y - s.y) + 2 * Direction.z * (Position.z - s.z);
                c = Math.Pow(Position.x - s.x, 2) + Math.Pow(Position.y - s.y, 2) + Math.Pow(Position.z - s.z, 2) - s.rayon;
                //Console.WriteLine("abc: a=" + a + " b=" + b + " c=" + c);
                delta = Math.Pow(b, 2) - 4 * a * c;
                //Console.WriteLine(delta);
                if (delta > 0)
                {
                    t1 = (-b - Math.Sqrt(delta)) / 2 * a;
                    t2 = (-b + Math.Sqrt(delta)) / 2 * a;
                    //Console.WriteLine(t1 + "--" + t2);
                    p1 = new Point((int)(Direction.x * t1 + Position.x), (int)(Direction.y * t1 + Position.y), (int)(Direction.z * t1 + Position.z));
                    p2 = new Point((int)(Direction.x * t2 + Position.x), (int)(Direction.y * t2 + Position.y), (int)(Direction.z * t2 + Position.z));
                    if (Position.Distance(p1) < Position.Distance(p2))
                        p = p1;
                    else
                        p = p2;
                    Console.WriteLine("Intersection: " + p.x + ";" + p.y + ";" + p.z);
                    //Console.WriteLine("P1: " + p1.x + ";" + p1.y + ";" + p1.z);
                    //Console.WriteLine("P2: " + p2.x + ";" + p2.y + ";" + p2.z);
                    l_point.Add(p);
                }
                

                
            }
            if (l_point.Count == 0)
                return null;
            else
            {
                l_point.Sort();
                return l_point.First();
            }
        }

        public Sphere Intersection(List<Sphere> l_sphere, ref float t)
        {
            Sphere retSp = new Sphere(0, 0, 0, 1, Color.White);
            foreach (Sphere s in l_sphere)
            {
                Point dist = new Point(s.x - Position.x, s.y - Position.y, s.z - Position.z);
                float B = Direction * dist;
                float D = B * B - dist.x * dist.x - dist.y * dist.y - dist.z * dist.z + s.rayon * s.rayon;
                float t0 = B - (float)Math.Sqrt(D);
                float t1 = B + (float)Math.Sqrt(D);
                
                if ((t0 > 0.1f) && (t0 < t))
                {
                    t = t0;
                    retSp = s;
                }
                if ((t1 > 0.1f) && (t1 < t))
                {
                    t = t1;
                    retSp = s;
                }
                //Console.WriteLine("lol");
                
            }
            return retSp;
        }
    }
}
