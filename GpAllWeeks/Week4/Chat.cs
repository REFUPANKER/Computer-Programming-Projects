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
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
        }
        Point exy;
        private void Chat_MouseDown(object sender, MouseEventArgs e)
        {
            exy = e.Location;
        }

        private void Chat_MouseMove(object sender, MouseEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            sendmsg();
        }
        private void sendmsg()
        {
            Label msg = new Label()
            {
                Width = flowLayoutPanel1.Width - 15,
                Height = (textBox1.Text.Split('\n').Length) * 30,
                Font = new Font("Arial", 15),
                BackColor = Color.FromArgb(15, 15, 15),
                ForeColor = Color.White,
                Text = (!string.IsNullOrEmpty(textBox1.Text)) ? textBox1.Text : "No message",
                Margin = new Padding(15 / 2, 5, 0, 0)
            };
            flowLayoutPanel1.Controls.Add(msg);
            textBox1.Text = "";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    sendmsg();
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
                case Keys.Left:
                    if (this.Left >= 0)
                    {
                        this.Left -= 10;
                    }
                    break;
                case Keys.Right:
                    if (this.Right <= Screen.PrimaryScreen.Bounds.Width)
                    {
                        this.Left += 10;
                    }
                    break;
                case Keys.Up:
                    if (this.Top >= 0)
                    {
                        this.Top -= 10;
                    }
                    break;
                case Keys.Down:
                    if (this.Bottom <= Screen.PrimaryScreen.Bounds.Height)
                    {
                        this.Top += 10;
                    }
                    break;
            }
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
