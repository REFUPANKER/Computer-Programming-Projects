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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            listBox1.Items.Clear();
            prekey = Keys.None;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Cyan;
            textBox1.PasswordChar = Convert.ToChar(0);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';
            textBox1.BackColor = Color.White;
        }

        Point exy;
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            exy = e.Location;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - exy.X;
                this.Top += e.Y - exy.Y;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Keys prekey;
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != prekey)
            {
                prekey = e.KeyCode;
                listBox1.Items.Add(e.KeyCode+" "+e.KeyValue);
            }
        }
    }
}
