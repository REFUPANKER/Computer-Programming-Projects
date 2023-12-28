using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week11
{
    public partial class ScreenProtector : Form
    {

        public int sWidth { get => Screen.PrimaryScreen.Bounds.Width; }
        public int sHeight { get => Screen.PrimaryScreen.Bounds.Height; }

        public ScreenProtector()
        {
            InitializeComponent();
            Cursor.Position = new Point(sWidth, sHeight);
            this.Size = new Size(sWidth, sHeight);
            this.Location = new Point(0, 0);


            Font f = new Font(label1.Font.FontFamily, (this.Height + this.Width) / 2 * 0.2f);
            label1.Font = f;
            label1.Location = new Point(this.Width / 2 - label1.Width / 2, this.Height / 2 - label1.Height / 2);

            Font f2 = new Font(label2.Font.FontFamily, (this.Height + this.Width) / 2 * 0.05f);
            label2.Font = f2;
            label2.Location = new Point(this.Width / 2 - label2.Width / 2, this.Height - label2.Height * 2);
            label2.Text = DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year;

            label3.Font = f2;
            label3.Location = new Point(this.Width / 2 - label3.Width / 2, label3.Height);


        }

        private void clock_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Hour < 10 ? "0" + DateTime.Now.Hour : DateTime.Now.Hour
                + ":" + (DateTime.Now.Minute < 10 ? "0" + DateTime.Now.Minute : DateTime.Now.Minute.ToString())
                + ":" + (DateTime.Now.Second < 10 ? "0" + DateTime.Now.Second : DateTime.Now.Second.ToString());
            label1.Location = new Point(this.Width / 2 - label1.Width / 2, this.Height / 2 - label1.Height / 2);
        }

        private void ScreenProtector_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                BouncingBox b = new BouncingBox();
                b.Show();
                b.BringToFront();
            }
            label3.Text = "Total boxes :5";
        }
    }
}
