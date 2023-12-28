using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week10
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen p = new Pen(Color.Orange, 1);
        Bitmap b;
        Font f;
        int xm, ym;
        public Form1()
        {
            InitializeComponent();
            f = new Font("Arial", 20);
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            xm = this.Width / 2;
            ym = this.Height / 2;
            //for (int i = 1; i <= 360; i++)
            //{
            //    g.FillEllipse(p.Brush,
            //        xm + ((int)(100 * Math.Cos(i * Math.PI / 180))),
            //        ym + ((int)(100 * Math.Sin(i * Math.PI / 180))),
            //        5, 5);
            //}
            g.DrawString("Slide to Unlock", f, p.Brush, xm - ((f.Size * 17) / 4), ym - (f.Size * 1.5f));
            pictureBox1.Image = b;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Left = this.Width / 2 - pictureBox1.Width / 2;
            pictureBox1.Top = this.Height / 2 - pictureBox1.Height / 2;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            g.Clear(Color.Transparent);
            int prc = (100 * e.X / pictureBox1.Width);
            int px = (prc * this.Width / 100) + 20;
            int py = (prc * this.Height / 100) + 20;
            int linedist = 10;
            p.Width = 5;
            g.DrawLine(p, 0, linedist, px, linedist);
            g.DrawLine(p, linedist, 0, linedist, py);
            g.DrawLine(p, pictureBox1.Width, pictureBox1.Height - linedist, pictureBox1.Width - px, pictureBox1.Height - linedist);
            g.DrawLine(p, pictureBox1.Width - linedist, pictureBox1.Height, pictureBox1.Width - linedist, pictureBox1.Height - py);
            Color pre;
            p.Width = 10;
            for (int i = 1; i <= 380 * prc / 100; i++)
            {
                pre = p.Color;
                int rx = -((int)(100 * Math.Cos(i * Math.PI / 180)));
                int ry = -((int)(100 * Math.Sin(i * Math.PI / 180)));
                p.Color = Color.FromArgb(0, 127 * prc / 100, 0);
                //g.FillEllipse(p.Brush, xm + rx / 2, ym + ry / 2, 5, 5);
                g.DrawLine(p,
                    xm + -((int)(100 * Math.Cos((i - 1) * Math.PI / 180))) / 2,
                    ym + -((int)(100 * Math.Sin((i - 1) * Math.PI / 180))) / 2,
                    xm + rx / 1.5f, ym + ry / 1.5f);
                p.Color = Color.FromArgb(0, 255 * prc / 100, 0);
                g.FillEllipse(p.Brush, xm + ((int)(100 * Math.Cos(i * Math.PI / 180))), ym + ((int)(100 * Math.Sin(i * Math.PI / 180))), 5, 5);
                p.Color = pre;
            }
            g.DrawString("Slide to Unlock", f, p.Brush, xm - ((f.Size * 17) / 4), ym - (prc + f.Size) * 1.5f);

            int middleEllipseSize = ((int)(prc * 0.4f));
            pre = p.Color;
            p.Color = Color.White;
            g.DrawEllipse(p, xm - middleEllipseSize / 2, ym - middleEllipseSize / 2, middleEllipseSize, middleEllipseSize);
            p.Color = pre;

            pictureBox1.Image = b;
            if (prc + 1 >= 100)//gets disabled when higher 101
            {
                pictureBox1.MouseMove -= Form1_MouseMove;
                CodeEditor codeEditor = new CodeEditor();
                this.Hide();
                codeEditor.Show();
            }
        }
    }
}
