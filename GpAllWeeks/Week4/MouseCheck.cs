using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week4
{
    public partial class MouseCheck : Form
    {
        public MouseCheck()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }
        Graphics g;
        Pen p1 = new Pen(Color.Red, 5);

        private void MouseCheck_Load(object sender, EventArgs e)
        {

        }
        Random rnd = new Random();

        private void MouseCheck_MouseMove(object sender, MouseEventArgs e)
        {
            //this.Refresh();
            pictureBox1.Refresh();

            // arcs

            //g.DrawArc(p1, this.Width / 2-100, this.Height / 2-100, 100, 100,0, -((((e.X + (p1.Width * 2)) * 100) / this.Width) * 360) / 100);
            //g.FillEllipse(p1.Brush, this.Width / 2-50, this.Height / 2, 30, 30);
            //g.DrawLine(p1, 100,100+ ((int)Math.Atan2(e.X, e.Y)), ((int)Math.Cos(e.X * Math.PI * 360)), 5);

            // draw lines from corners

            //g.DrawLine(p1, 0, 0, e.X, e.Y);
            //g.DrawLine(p1, this.Width, 0, e.X, e.Y);
            //g.DrawLine(p1, 0, this.Height, e.X, e.Y);
            //g.DrawLine(p1, this.Width, this.Height, e.X, e.Y);


            // draw triangles

            //p1.Color = Color.Red;
            //g.FillPolygon(p1.Brush, new Point[] { new Point(0,0), new Point(this.Width,0), new Point(e.X, e.Y) });
            //p1.Color = Color.DarkRed;
            //g.FillPolygon(p1.Brush, new Point[] { new Point(0, 0), new Point(0, this.Height), new Point(e.X, e.Y) });
            //p1.Color = Color.LightSalmon;
            //g.FillPolygon(p1.Brush, new Point[] { new Point(this.Width, 0), new Point(this.Width, this.Height), new Point(e.X, e.Y) });
        }


    }
}
