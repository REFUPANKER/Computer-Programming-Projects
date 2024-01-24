using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week12
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		#region Passed Time
		Graphics g;
		Pen pen = new Pen(Color.Black, 5);
		int rad = 0;
		int seconds = 0;
		private void timer1_Tick(object sender, EventArgs e)
		{
			pictureBox1.Refresh();
			int lineRad = pictureBox1.Width / 4;
			int dx = pictureBox1.Width / 2 + ((int)(lineRad * Math.Sin(rad * Math.PI / 30)));
			int dy = pictureBox1.Height / 2 - ((int)(lineRad * Math.Cos(rad * Math.PI / 30)));
			g.DrawLine(pen, pictureBox1.Width / 2, pictureBox1.Height / 2, dx, dy);
			rad += 1;
			if (dy >= pictureBox1.Height / 2)
			{
				g.DrawString((seconds++) + "", this.Font, pen.Brush, pictureBox1.Width / 2 - this.Font.Height / 2, this.Font.Height * 2);
			}
			else
			{
				g.DrawString((seconds++) + "", this.Font, pen.Brush, pictureBox1.Width / 2 - this.Font.Height / 2, pictureBox1.Height - this.Font.Height * 3);
			}
			g.DrawEllipse(pen, pictureBox1.Width / 4, pictureBox1.Height / 4, pictureBox1.Width / 2, pictureBox1.Height / 2);
		}
		#endregion

		public string pDesktop { get => Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\"; }
		private void Form1_Load(object sender, EventArgs e)
		{
			g = pictureBox1.CreateGraphics();
			//CreateTree(pDesktop);
		}

		#region Tree Search
		void CreateTree(string path)
		{
			TreeSearch(path, null);
			string[] files = Directory.GetFiles(pDesktop);
			for (int j = 0; j < files.Length; j++)
			{
				files[j] = files[j].Substring(files[j].LastIndexOf("\\"));
				treeView1.Nodes.Add(files[j]);
			}
		}
		void TreeSearch(string path, TreeNode parent)
		{
			string[] paths = Directory.GetDirectories(path);
			for (int i = 0; i < paths.Length; i++)
			{
				string dname = paths[i].Substring(paths[i].LastIndexOf("\\"));
				if (parent == null)
				{
					TreeSearch(paths[i], treeView1.Nodes.Add(dname));
				}
				else
				{
					TreeNode nextParent = parent.Nodes.Add(dname);
					TreeSearch(paths[i], nextParent);
					string[] files = Directory.GetFiles(paths[i]);
					for (int j = 0; j < files.Length; j++)
					{
						files[j] = files[j].Substring(files[j].LastIndexOf("\\"));
						nextParent.Nodes.Add(files[j]);
					}
				}

			}
		}
		#endregion

		Button[,] table;
		int cols = 9, rows = 9;
		int w = 0, h = 0;
		char p1 = 'X', p2 = '0';
		private char c;
		public char current { get => c; set { c = value; label2.Text = c.ToString(); } }
		Random random = new Random();
		private void button1_Click(object sender, EventArgs e)
		{
			if (rows < 3 || cols < 3)
			{
				rows = 3;
				cols = 3;
			}
			if (random.Next(1, 3) == 1)
			{
				current = p1;
			}
			else
			{
				current = p2;
			}
			p1Score = 0;
			p2Score = 0;
			label3.Text = $"1. Oyuncu ({p2})";
			label4.Text = $"1. Oyuncu ({p1})";
			label5.Text = p1Score.ToString();
			label6.Text = p2Score.ToString();
			if (table == null)
			{
				table = new Button[rows, cols];
			}
			if (panel1.Controls.Count > 0)
			{
				foreach (Button item in panel1.Controls)
				{
					item.Text = "";
					item.BackColor = Color.Transparent;
				}
				return;
			}

			w = panel1.Width / rows;
			h = panel1.Height / cols;

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					Button b = new Button();
					b.Width = w;
					b.Height = h;
					b.FlatStyle = FlatStyle.Flat;
					b.BackColor = Color.Transparent;
					b.ForeColor = Color.Black;
					b.TextAlign = ContentAlignment.MiddleCenter;
					b.Font = new Font(this.Font.FontFamily, ((int)(w * 0.6)), FontStyle.Regular);
					panel1.Controls.Add(b);
					b.Left = i * w;
					b.Top = j * h;
					b.Click += B_Click;
					table[i, j] = b;
				}
			}
		}
		int p1Score = 0, p2Score = 0;
		void Scored()
		{
			this.Text = "Score!!! " + (current == p1 ? p2 : p1);
			if (current == p1)
			{
				++p2Score;
			}
			else
			{
				++p1Score;
			}
			label5.Text = p1Score.ToString();
			label6.Text = p2Score.ToString();
		}
		// from  [Right,Left,Top,Bottom] to [Right,Left,Top,Bottom]
		Color fLtR = Color.Red;
		Color fRtL = Color.Orange;
		Color fTtB = Color.FromArgb(40, 40, 170);
		Color fBtT = Color.FromArgb(40, 40, 70);
		private void B_Click(object sender, EventArgs e)
		{
			Button who = (Button)sender;
			if (who.Text == "")
			{
				who.Text = current.ToString();
				if (current == p1)
				{
					current = p2;
				}
				else
				{
					current = p1;
				}
			}
			int index = panel1.Controls.GetChildIndex(who);
			int wx = (index % cols);
			int wy = (index / rows);
			string lineCheck = "";
			// From Left To right
			lineCheck = "";
			for (int i = wy; i < wy + 3; i++)
			{
				if (i < cols)
				{
					lineCheck += table[i, wx].Text;
				}
			}
			if (lineCheck.StartsWith(p1.ToString() + p2.ToString() + p1.ToString()))
			{
				for (int i = wy; i < wy + 3; i++)
				{
					table[i, wx].BackColor = fRtL;
				}
				Scored();
				return;
			}
			// From Right To Left
			lineCheck = "";
			for (int i = wy; i > wy - 3; i--)
			{
				if (i > 0)
				{
					lineCheck += table[i, wx].Text;
				}
			}
			if (lineCheck.StartsWith(p1.ToString() + p2.ToString() + p1.ToString()))
			{
				for (int i = wy; i > wy - 3; i--)
				{
					table[i, wx].BackColor = fLtR;
				}
				Scored();
				return;
			}
			//// From Bottom To Top
			lineCheck = "";
			for (int i = wx; i < wx + 3; i++)
			{
				if (i < rows)
				{
					lineCheck += table[wy, i].Text;
				}
			}
			if (lineCheck.StartsWith(p1.ToString() + p2.ToString() + p1.ToString()))
			{
				for (int i = wx; i < wx + 3; i++)
				{
					table[wy, i].BackColor = fBtT;
				}
				Scored();
				return;
			}
			//// From Top To Bottom
			lineCheck = "";
			for (int i = wy; i > wy - 3; i--)
			{
				if (i < rows && i >= 0)
				{
					lineCheck += table[i, wx].Text;
				}
			}
			if (lineCheck.StartsWith(p1.ToString() + p2.ToString() + p1.ToString()))
			{
				for (int i = wx - 3; i > wx; i++)
				{
					table[wy, i].BackColor = fTtB;
				}
				Scored();
				return;
			}
			//lineCheck = "";
			//for (int i = 2; i >= 0; i--)
			//{
			//    lineCheck += table[wy, i].Text;
			//}
			//if (lineCheck.StartsWith(p1.ToString() + p2.ToString() + p1.ToString()))
			//{
			//    for (int i = 2; i >= 0; i--)
			//    {
			//        table[wy, i].BackColor = fTtB;
			//    }
			//    Scored();
			//    return;
			//}
		}


	}
}
