using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week3
{
    public partial class Form1 : Form
    {
        SecondWindow secondWindow = new SecondWindow();
        public Form1()
        {
            InitializeComponent();
            //secondWindow.MdiParent = this;
            //panel2.Controls.Add(secondWindow);
        }

        private void formparent_Click(object sender, EventArgs e)
        {
            if (secondWindow.Visible)
            {
                secondWindow.Hide();
            }
            else
            {
                secondWindow.Show();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void firstClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
