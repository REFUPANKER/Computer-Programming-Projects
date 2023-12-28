using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week11
{
    public partial class BouncingBox : Form
    {
        public BouncingBox()
        {
            InitializeComponent();
            targetElement = this;
            this.BackColor = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            RandomDirection();
            this.BringToFront();
            bounceCountLabel = label2;
        }
        private System.Windows.Forms.Label bounceCountLabel;
        Control targetElement;
        public int pLeft
        {
            get { return targetElement.Left; }
            set
            {
                if (pLeft <= 0)
                {
                    gright = true;
                    gleft = false;
                    Bounced();
                }
                targetElement.Left = value;
            }
        }
        public int pRight
        {
            get { return targetElement.Right; }
            set
            {
                if (pRight >= Screen.PrimaryScreen.Bounds.Width)
                {
                    gright = false;
                    gleft = true;
                    Bounced();
                }
                targetElement.Left = value - targetElement.Width;
            }
        }
        public int pTop
        {
            get
            {
                return targetElement.Top;
            }
            set
            {
                if (pTop <= 0)
                {
                    gtop = false;
                    gbottom = true;
                    Bounced();
                }
                targetElement.Top = value;
            }
        }
        public int pBottom
        {
            get
            {
                return targetElement.Bottom;
            }
            set
            {
                if (pBottom >= Screen.PrimaryScreen.Bounds.Height)
                {
                    gbottom = false;
                    gtop = true;
                    Bounced();
                }
                targetElement.Top = value - targetElement.Height;
            }
        }
        bool started = false;
        Random rnd = new Random();
        public int speed { get => 10; }
        bool gleft = false, gright = false, gtop = false, gbottom = false;

        int p_totalbounces = 0;
        public int TotalBounces
        {
            get => p_totalbounces; set
            {
                p_totalbounces = value;
                bounceCountLabel.Text = p_totalbounces.ToString();
                bounceCountLabel.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - bounceCountLabel.Width / 2, bounceCountLabel.Height);
            }
        }

        private void BouncingBox_Load(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        void Bounced()
        {
            targetElement.BackColor = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            if ((this.BackColor.R+ this.BackColor.G + this.BackColor.B)/3<127)
            {
                this.ForeColor = Color.White;
            }
            else
            {
                this.ForeColor = Color.Black;
            }
            TotalBounces += 1;
            this.BringToFront();
        }
        void RandomDirection()
        {
            if (rnd.Next(1, 3) == 2)
            {
                gright = true;
                gleft = false;
            }
            else
            {
                gright = false;
                gleft = true;
            }
            if (rnd.Next(1, 3) == 2)
            {
                gtop = true;
                gbottom = false;
            }
            else
            {
                gtop = false;
                gbottom = true;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // starting direction
            //if (!started)
            //{
            //    gleft = true;
            //    gbottom = true;
            //    started = true;
            //}

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
