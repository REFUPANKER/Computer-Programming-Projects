using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
	public partial class InspectCode : Form
	{
		public InspectCode()
		{
			InitializeComponent();
			defaultTitle = this.Text;
			this.Show();
			this.Hide();
		}
		readonly string defaultTitle = "";
		public void ShowCode(string code, string name)
		{
			code = (code.Length > 2) ? code.Substring(1, code.Length - 2) : code;
			textBox1.Text = code;
			textBox1.SelectionStart = textBox1.Text.Length - 1;
			this.Text = defaultTitle + " : " + name;
			this.ShowDialog();

		}
	}
}
