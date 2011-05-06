using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace RayTracer
{
    class Draw
    {
        public static Bitmap newImage(int width, int height, List<Sphere> l_sphere)
        {
            Bitmap image = new Bitmap(width, height);
            
            l_sphere.Sort();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Ray r = new Ray(new Point(x, y, -2000), new Point(0f, 0f, 1), 1);
                    Color c = Color.White;
                    float dis = -r.Position.z;
                    Sphere currentSphere =  r.Intersection(l_sphere, ref dis);
                    image.SetPixel(x, y, Color.Black);
                    Point inter = r.Position + dis * r.Direction;
                    Point normal = inter - new Point(currentSphere.x, currentSphere.y, currentSphere.z);
                    float temp = normal * normal;
                    if (temp != 0 && dis != -r.Position.z)
                    {
                        temp = 1.0f / (float)Math.Sqrt(temp);
                        normal = temp * normal;
                        float lambert = r.Direction * normal;
                        float red = currentSphere.color.R * lambert;
                        float green = currentSphere.color.G * lambert;
                        float blue = currentSphere.color.B * lambert;
                        //image.SetPixel(x, y, Color.FromArgb((int)red, (int)green, (int)blue));
                        image.SetPixel(x, y, Color.FromArgb(((int)(currentSphere.color.R * (currentSphere.z - inter.z)) / currentSphere.rayon), (int)((currentSphere.color.G * (currentSphere.z - inter.z)) / currentSphere.rayon), (int)((currentSphere.color.B * (currentSphere.z - inter.z)) / currentSphere.rayon)));
                    }
                }
            }
            return image;
        }
        


    }
}
