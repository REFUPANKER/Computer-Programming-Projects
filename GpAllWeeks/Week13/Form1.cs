using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            trackBar1.Maximum = pictureBox1.Height - size - drawingMargin;
            trackBar2.Maximum = pictureBox1.Height - size - drawingMargin;
            trackBar3.Maximum = pictureBox1.Width - size - drawingMargin;
        }
        int drawingMargin = 10;

        Graphics g;
        Pen p = new Pen(Color.Black);

        private void Form1_Load(object sender, EventArgs e)
        {
            DrawCordinates();
        }
        public int orgX { get => pictureBox1.Width / 3; }
        public int orgY { get => pictureBox1.Height / 2; }
        float[,] cps = new float[8, 3];
        int size = 100;
        void DrawCordinates()
        {
            pictureBox1.Refresh();
            p.Color = Color.Black;
            g.DrawLine(p, pictureBox1.Width / 3, 0, pictureBox1.Width / 3, pictureBox1.Height / 2);
            g.DrawLine(p, pictureBox1.Width / 3, pictureBox1.Height / 2, 0, pictureBox1.Height);
            g.DrawLine(p, pictureBox1.Width / 3, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            p.Color = Color.BlueViolet;

            //back face
            cps[0, 0] = 0;
            cps[0, 1] = 0;
            cps[0, 2] = 0;

            cps[1, 0] = 1;
            cps[1, 1] = 0;
            cps[1, 2] = 0;

            cps[2, 0] = 1;
            cps[2, 1] = 0;
            cps[2, 2] = 1;

            cps[3, 0] = 0;
            cps[3, 1] = 0;
            cps[3, 2] = 1;

            g.DrawLine(p, orgX + ((int)((cps[0, 0] * Math.PI / 180) * trackBar1.Value)), orgY + ((int)((cps[0, 1] * Math.PI / 180) * trackBar1.Value)), 0, 0);
        }




        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            DrawCordinates();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            DrawCordinates();
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            DrawCordinates();
        }
    }
}
