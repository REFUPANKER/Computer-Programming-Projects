using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week2
{
    public partial class NotifyiconUi : Form
    {
        public NotifyiconUi()
        {
            InitializeComponent();
        }

        private void NotifyiconUi_MouseLeave(object sender, EventArgs e)
        {

        }
        int errorCount = 0;
        private void DoubleCalc()
        {
            try
            {
                textBox3.Text = (Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text)).ToString();
                errorCount = 0;
            }
            catch
            {
                textBox3.Text = "Error" + errorCount++;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            DoubleCalc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
