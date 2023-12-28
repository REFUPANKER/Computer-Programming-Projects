using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] categories = new string[]
        {
            "action","love","horror","biography","art","sports"
        };
        int size = 20, length = 12;
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in categories)
            {
                comboBox1.Items.Add(item);
            }
            panel1.Width = size * length;
            panel1.Height = panel1.Width;
            for (int j = 0; j < length; j++)
            {
                for (int i = 0; i < length; i++)
                {
                    Label btn = new Label()
                    {
                        Size = new Size(size, size),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = ((j + i) % 2 == 0) ? Color.Black : Color.White,
                        Left = size * i,
                        Top = size * j,
                        ForeColor = ((j + i) % 2 == 0) ? Color.White : Color.Black,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font(this.Font.FontFamily, Convert.ToInt32(size * 0.6)),
                        //Text = $"{j},{i}"
                    };
                    panel1.Controls.Add(btn);
                }
            }
            for (int i = length; i < length * 2; i++)
            {
                panel1.Controls[i].Text = "♟️";
                panel1.Controls[i].ForeColor = Color.Red;
                panel1.Controls[panel1.Controls.Count - 1 - i].Text = "♟️";
                panel1.Controls[panel1.Controls.Count - 1 - i].ForeColor = Color.Blue;
            }


            Random rnd = new Random();
            for (int i = 0; i < 50; i++)
            {
                dataGridView1.Rows.Add(new object[] { 2205113000 + i, "alpha" + i, "test" + i + 2 / 2, rnd.Next(100000000, 999999999)+""+rnd.Next(10,100), i + rnd.Next(0, 100 - i), 40 + rnd.Next(0, 60) });
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                string name = dataGridView1.Rows[item.Index].Cells[1].Value.ToString();
                int q1 = Convert.ToInt32(dataGridView1.Rows[item.Index].Cells[4].Value);
                int q2 = Convert.ToInt32(dataGridView1.Rows[item.Index].Cells[5].Value);
                label2.Text = $"{name} Q Avg ({q1}+{q2})/2\t = " + Convert.ToInt32((q1 + q2) / 2);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string content = "";
            switch (comboBox1.SelectedItem.ToString())
            {
                case "action":
                    content = "action";
                    MessageBox.Show("Action selected");
                    break;
                case "love":
                    content = "LOVE ♥️";
                    MessageBox.Show("yo bro, fk love");
                    break;
                case "horror":
                    content = "Jigsaw";
                    MessageBox.Show("r u shit in your pants o_O");
                    break;
            }
            listBox1.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                listBox1.Items.Add(content + i);
            }
        }
    }
}
