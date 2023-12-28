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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            Label clabel = new Label()
            {
                BackColor = flowLayoutPanel1.BackColor,
                Text = flowLayoutPanel1.BackColor.ToString(),
                AutoSize = true,
                ForeColor = Color.FromArgb(255 - flowLayoutPanel1.BackColor.R, 255 - flowLayoutPanel1.BackColor.G, 255 - flowLayoutPanel1.BackColor.B),
                Font = new Font("Arial", 15),
            };
            clabel.Click += Clabel_Click;
            flowLayoutPanel1.Controls.Add(clabel);
        }

        private void Clabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(((Label)sender).BackColor.ToString(), "Display color");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            flowLayoutPanel1.Width = ((int)(this.Width * 0.65));
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            flowLayoutPanel1.BackColor = Color.FromArgb(
                rnd.Next(0, 256),
                rnd.Next(0, 256),
                rnd.Next(0, 256));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
        }
    }
}
