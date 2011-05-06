using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RayTracer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Console.WriteLine("Start");
            RayTracing();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            
        }

        private void RayTracing()
        {
            
            List<Sphere> l_sphere = new List<Sphere>();
            l_sphere.Add(new Sphere(200, 200, -190, 100, Color.Blue));
            l_sphere.Add(new Sphere(380, 200, -200, 100, Color.Yellow));
            l_sphere.Add(new Sphere(290, 350, -200, 100, Color.Red));
            Bitmap bg = Draw.newImage(cutebox.Width, cutebox.Height, l_sphere);
            cutebox.Image = bg;
        }
    }
}
