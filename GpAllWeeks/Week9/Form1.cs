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

namespace Week9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            updatePrice();
        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AboutBox1()).ShowDialog();
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Text = "Open Project :" + folderBrowserDialog1.SelectedPath;
            }
        }

        void updatePrice()
        {
            label2.Text = $"Total price : {((monthCalendar1.SelectionRange.End - monthCalendar1.SelectionRange.Start).Days + 1) * numericUpDown1.Value}$";
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            updatePrice();
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            updatePrice();
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new NewProject()).ShowDialog();
        }
    }
}
