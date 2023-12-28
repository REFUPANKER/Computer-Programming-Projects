using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week9
{
    public partial class NewProject : Form
    {
        public NewProject()
        {
            InitializeComponent();
        }

        private void NewProject_Load(object sender, EventArgs e)
        {
            int countto = 100;
            for (int i = 0; i < countto; i++)
            {
                progressBar1.Value = (i + 1) * 100 / countto;
                label3.Text = "Type : " + i;
                listBox1.Items.Add(i);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Color preColor;
                //int prePos;
                int prepos = richTextBox1.SelectionStart;
                richTextBox1.Select(0, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = richTextBox1.ForeColor;
                richTextBox1.DeselectAll();
                richTextBox1.Select(prepos, 0);
                for (int i = 0; i < richTextBox1.Text.Length; i++)
                {
                    ChangeByColor("class", Color.Lime, i);
                    ChangeByColor("public", Color.Blue, i);
                    ChangeByColor("void", Color.Red, i);
                    ChangeByColor("return", Color.Pink, i);


                    ChangeByColor("(", Color.Orange, i);
                    ChangeByColor(")", Color.Orange, i);
                    ChangeByColor("{", Color.Yellow, i);
                    ChangeByColor("}", Color.Yellow, i);
                    ChangeByColor(";", Color.Red, i);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        void ChangeByColor(string word, Color color, int index)
        {
            if (richTextBox1.Text.Substring(index).StartsWith(word))
            {
                int prePos;
                richTextBox1.DeselectAll();
                prePos = richTextBox1.SelectionStart;
                richTextBox1.Select(index, word.Length);
                richTextBox1.SelectionColor = color;
                richTextBox1.DeselectAll();
                richTextBox1.Select(prePos, 0);
                richTextBox1.SelectionColor = richTextBox1.ForeColor;
            }
        }

        private void NewProject_Resize(object sender, EventArgs e)
        {
            richTextBox1.Width = this.Width / 2;
        }
    }
}
