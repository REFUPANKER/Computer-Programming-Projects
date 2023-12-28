using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (var item in DateTimeFormatInfo.CurrentInfo.MonthNames)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.PasswordChar = Convert.ToChar(0);
                checkBox1.Text = "Hide";
            }
            else
            {
                checkBox1.Text = "Show";
                textBox1.PasswordChar = '*';
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 11)
            {
                MessageBox.Show("Licence key length must be 11");
            }
            else
            {
                MessageBox.Show("Wellcome to the LSD");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text = listBox1.SelectedItems.Count + " Items selected";
            listBox2.Items.Clear();
            foreach (var item in listBox1.SelectedItems)
            {
                listBox2.Items.Add(item);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Clipboard.GetImage();
        }
        Graphics g;
        private void label4_Click(object sender, EventArgs e)
        {
            int bound = 100;
            Image img = new Bitmap(pictureBox1.Width + bound * 2, pictureBox1.Height + bound * 2);
            g = Graphics.FromImage(img);
            g.CopyFromScreen(
                this.Location.X+20+pictureBox1.Location.X,
                this.Top+30+pictureBox1.Location.Y,
                1,1,
                img.Size);
            //g.CopyFromScreen(this.Left + pictureBox1.Left - bound, 0,1,1, pictureBox1.Size);
            pictureBox1.Image = img;
            pictureBox1.Refresh();
        }

        private void checkedListBox1_MouseUp(object sender, MouseEventArgs e)
        {
            listBox3.Items.Clear();
            foreach (object item in checkedListBox1.CheckedItems)
            {
                listBox3.Items.Add(item);
            }
        }
    }
}
