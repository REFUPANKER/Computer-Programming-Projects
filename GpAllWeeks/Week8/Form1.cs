using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week8
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen p1 = new Pen(Color.Black, 1);
        public Form1()
        {
            InitializeComponent();
            for (int x = 0; x < imageList1.Images.Count; x++)
            {
                Bitmap bx = (Bitmap)imageList1.Images[x];
                g = Graphics.FromImage(bx);
                for (int i = 0; i < bx.Height; i++)
                {
                    for (int j = 0; j < bx.Width - i; j++)
                    {
                        int px = i, py = bx.Width - 1 - j;
                        Color by = bx.GetPixel(px, py);
                        int avg = (bx.GetPixel(px, py).R + bx.GetPixel(px, py).G + bx.GetPixel(px, py).B) / 3;

                        if (avg <= 127)
                        {
                            bx.SetPixel(px, py, Color.Black);
                        }
                        else
                        {
                            bx.SetPixel(px, py, Color.White);
                        }

                        //bx.SetPixel(px, py, Color.FromArgb(255 - by.R, 255 - by.G, 255 - by.B));

                        //if (avg >= 50 && avg <= 100)
                        //{
                        //    bx.SetPixel(px, py, Color.Gray);
                        //}
                    }
                }
                int line = 4;
                p1.Width = line;
                p1.Color = Color.Black;
                g.DrawLine(p1, 0, 0, bx.Width, bx.Height);
                int corner = 2;
                p1.Width = corner;
                p1.Color = Color.Silver;
                g.DrawLine(p1, 0, line / 2 + corner, bx.Width - corner - line / 2, bx.Height);
                g.DrawLine(p1, line / 2 + corner, 0, bx.Width, bx.Height - corner - line / 2);
                imageList1.Images[x] = bx;
            }
            pictureBox1.Image = imageList1.Images[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control item in ((Control)sender).Parent.Controls)
            {
                if (item.Tag + "" == "cevap")
                {
                    if (((RadioButton)item).Checked)
                    {
                        MessageBox.Show("doru");
                        break;
                    }
                    else
                    {
                        MessageBox.Show("yanlis");
                        break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in ((Control)sender).Parent.Controls)
            {
                if (item.GetType() == typeof(RadioButton))
                {
                    ((RadioButton)item).Checked = false;
                }
            }
        }
        int selectedImg = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            if (selectedImg - 1 >= 0)
            {
                selectedImg -= 1;
            }
            pictureBox1.Image = imageList1.Images[selectedImg];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (selectedImg + 1 < imageList1.Images.Count)
            {
                selectedImg += 1;
            }
            pictureBox1.Image = imageList1.Images[selectedImg];
        }
    }
}
