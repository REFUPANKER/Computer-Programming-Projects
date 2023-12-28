using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week10
{
    public partial class CodeEditor : Form
    {
        public CodeEditor()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int prepos = richTextBox1.SelectionStart;
                richTextBox1.Select(0, richTextBox1.Text.Length);
                richTextBox1.SelectionColor = richTextBox1.ForeColor;
                richTextBox1.DeselectAll();
                richTextBox1.Select(prepos, 0);
                for (int i = 0; i < richTextBox1.Text.Length; i++)
                {
                    ChangeByColor("class", Color.Lime, i);
                    ChangeByColor("void", Color.DarkRed, i);
                    ChangeByColor("interface", Color.FromArgb(90, 200, 90), i);

                    ChangeByColor("public", Color.Cyan, i);
                    ChangeByColor("private", Color.FromArgb(137, 30, 70), i);
                    ChangeByColor("internal", Color.FromArgb(137, 30, 70), i);


                    ChangeByColor("return", Color.Pink, i);

                    ChangeByColor("for", Color.FromArgb(190, 40, 80), i);
                    ChangeByColor("foreach", Color.FromArgb(190, 40, 80), i);
                    ChangeByColor("while", Color.FromArgb(190, 40, 80), i);

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

        private void CodeEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        string p = "";
        private void timer1_Tick(object sender, EventArgs e)
        {
            p = this.Text[0].ToString();
            this.Text = this.Text.Substring(1);
            //for (int i = 1; i < this.Text.Length; i++)
            //{
            //    this.Text.ToCharArray()[i - 1] = this.Text[i];
            //}
            this.Text+= p;
        }
    }
}
