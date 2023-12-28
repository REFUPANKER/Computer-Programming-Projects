using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace Week3
{
    public partial class SecondWindow : Form
    {
        public SecondWindow()
        {
            InitializeComponent();
        }
        string pretext = "you got rickrolled!";
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = (label1.Text != pretext) ? pretext : "if you reading this message ...";
            try
            {
                Process.Start("cmd", "/c start https://youtu.be/dQw4w9WgXcQ?si=1_Rwk14-0JEoP0Xu");
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public int pLeft
        {
            get { return this.Left; }
            set
            {
                if (pLeft <= 0)
                {
                    gright = true;
                    gleft = false;
                }
                this.Left = value;
            }
        }
        public int pRight
        {
            get { return this.Right; }
            set
            {
                if (pRight >= Screen.PrimaryScreen.Bounds.Width)
                {
                    gright = false;
                    gleft = true;
                }
                this.Left = value - this.Width;
            }
        }
        public int pTop
        {
            get
            {
                return this.Top;
            }
            set
            {
                if (pTop <= 0)
                {
                    gtop = false;
                    gbottom = true;
                }
                this.Top = value;
            }
        }
        public int pBottom
        {
            get
            {
                return this.Bottom;
            }
            set
            {
                if (pBottom >= Screen.PrimaryScreen.Bounds.Height)
                {
                    gbottom = false;
                    gtop = true;
                }
                this.Top = value - this.Height;
            }
        }
        bool started = false;
        Random rnd = new Random();
        public int speed { get => 10; }
        bool gleft = false, gright = false, gtop = false, gbottom = false;

        private void SecondWindow_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!started)
            {
                gleft = true;
                gbottom = true;
                started = true;
            }

            if (gright)
            {
                pRight += speed;
            }
            if (gleft)
            {
                pLeft -= speed;
            }
            if (gtop)
            {
                pTop -= speed;
            }
            if (gbottom)
            {
                pBottom += speed;
            }
        }
    }
}
