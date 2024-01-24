using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
	public partial class TimerKullanımOrnegi : Form
	{
		public TimerKullanımOrnegi()
		{
			InitializeComponent();
			AddToolTips(this);
		}
		#region tooltip setup

		void AddToolTips(Control parent)
		{
			foreach (Control item in parent.Controls)
			{
				item.MouseMove += Item_MouseMove;
				item.MouseLeave += Item_MouseLeave;
				AddToolTips(item);
			}
		}
		private void Item_MouseLeave(object sender, EventArgs e)
		{
			toolTip1.Hide(this);
		}

		private void Item_MouseMove(object sender, MouseEventArgs e)
		{
			Control c = sender as Control;
			toolTip1.Show((c.GetType().Name == "Button" && c.Text.Contains("ℹ️")) ? "Kodu göster" : c.GetType().Name, this, (MousePosition.X - this.Location.X) - (c.GetType().Name.Length * ((int)this.Font.Size)) / 2, c.Location.Y + ((int)this.Font.Size));
		}
		#endregion
		private void timer1_Tick(object sender, EventArgs e)
		{
			string first = label1.Text[0] + "";
			label1.Text = label1.Text.Substring(1) + first;
		}

		private void dijitalSaatTimer_Tick(object sender, EventArgs e)
		{
			label3.Text = DateTime.Now.ToShortTimeString();
		}
		Graphics g;
		Pen pen = new Pen(Color.Orange, 5);
		int rad = 0;
		int seconds = 0;
		private void AnalogClock_Tick(object sender, EventArgs e)
		{
			g = pictureBox1.CreateGraphics();
			pictureBox1.Refresh();
			pen.Color = Color.Lime;
			g.DrawLine(pen, pictureBox1.Width / 2, pictureBox1.Height / 2, calcX(30), calcY(30));
			pen.Color = Color.Cyan;
			g.DrawLine(pen, pictureBox1.Width / 2, pictureBox1.Height / 2, calcX(60), calcY(60));
			pen.Color = Color.Red;
			g.DrawLine(pen, pictureBox1.Width / 2, pictureBox1.Height / 2, calcX(60 * 24), calcY(60 * 24));
			g.DrawEllipse(pen, 0, 0, pictureBox1.Width, pictureBox1.Height);
			rad += 1;
		}
		private int calcX(int target)
		{
			return pictureBox1.Width / 2 + ((int)((pictureBox1.Width / 4) * Math.Sin(rad * Math.PI / target / 2)));
		}
		private int calcY(int target)
		{
			return pictureBox1.Height / 2 - ((int)((pictureBox1.Height / 4) * Math.Cos(rad * Math.PI / target / 2)));
		}
	}
}
