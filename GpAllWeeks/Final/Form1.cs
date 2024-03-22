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
	public partial class Form1 : Form
	{
		private EventLogMenu logEvent = new EventLogMenu();
		private InspectCode inspectCode = new InspectCode();
		Graphics g;
		Pen pen = new Pen(Color.Black);
		public Form1()
		{
			InitializeComponent();
			g = pictureBox1.CreateGraphics();
		}

		#region event log menu events
		void UpdateLogEventMenuLocation()
		{
			int range = ((int)this.Font.Size);
			logEvent.Height = this.Height - range;
			logEvent.Top = this.Top;
			if ((this.Left - logEvent.Width) + range < 0)
			{
				logEvent.Left = this.Right - range;
			}
			else
			{
				logEvent.Left = this.Left - logEvent.Width + range;
			}
		}
		private void Form1_LocationChanged(object sender, EventArgs e)
		{
			UpdateLogEventMenuLocation();
		}
		#endregion

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

		#region inspect code buttons
		private void button3_Click(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "Click");
			inspectCode.ShowCode(@"
Graphics g=pictureBox1.CreateGraphics();
Bitmap b = this.Icon.ToBitmap();
int yatayOrta=pictureBox1.Width / 2 - b.Width / 2;
int dikeyOrta=pictureBox1.Height / 2 - b.Height / 2;
g.DrawImage(b,yatayOrta,dikeyOrta);
", "PictureBox a resim çizme");

		}
		private void button4_Click(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "Click");
			inspectCode.ShowCode(@"
if (MessageBox.Show(""Mesaj içeriği"", ""Mesaj başlığı"", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
{
	colorDialog1.ShowDialog();
	pen.Color = colorDialog1.Color;
	g.FillRectangle(pen.Brush, 0, 0, 
		pictureBox1.Width, 
		pictureBox1.Height);
}
", "ColorDialog tan renk seçme");
		}
		private void button5_Click(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "Click");
			inspectCode.ShowCode(@"
this.Text=textBox1.Text;
", "Formun başlığını değiştirme");
		}
		private void button6_Click(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "Click");
			inspectCode.ShowCode(@"
iif (string.IsNullOrEmpty(textBox2.Text) == false)
{
	comboBox1.Items.Add(textBox2.Text);
	listBox1.Items.Add(textBox2.Text);
	comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
}
else
{
	MessageBox.Show(""Lütfen bir veri girin"");
}
", "ComboBox a eleman ekleme");
		}
		private void button8_Click(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "Click");
			inspectCode.ShowCode(@"
comboBox1.Sorted = (checkBox1.CheckState == CheckState.Checked) ? 
		true 
			: 
		false;
if (comboBox1.Items.Count>0)
{
	comboBox1.SelectedIndex = 0;
}
", "ComboBox un elemanlarını sıralama");
		}
		private void button10_Click(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "Click");
			inspectCode.ShowCode(@"
foreach (var item in checkedListBox1.CheckedItems)
{
	if (listBox2.Items.Contains(item) == false)
	{
		listBox2.Items.Add(item);
	}
	else
	{
		listBox2.Items.Remove(item);
	}
}
", "CheckedListBox tan ListBox a eleman aktarma");
		}

		private void button11_Click(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "Click");
			inspectCode.ShowCode(@"
progressBar1.Value = trackBar1.Value;
", "TrackBar ile ProgressBar ın yüzdesini değiştirme");
		}
		#endregion

		#region Log Event Metods
		private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "SelectedIndexChanged");
		}
		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "ValueChanged");
		}
		private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "SelectedIndexChanged");
		}
		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "CheckedChanged");
		}
		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "TextChanged");
		}
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "SelectedIndexChanged");
		}
		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "SelectedIndexChanged");
		}
		#endregion

		private void Form1_Load(object sender, EventArgs e)
		{
			AddToolTips(this);
			logEvent.Show();
			UpdateLogEventMenuLocation();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "TextChanged");
			this.Text = textBox1.Text;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "Click");
			if (MessageBox.Show("Renk seçebilmek için ColorDialog nesnesi açılıcak.\nOnaylıyormusunuz?", "Yeni bir diyalog nesnesi açılıyor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				colorDialog1.ShowDialog();
				pen.Color = colorDialog1.Color;
				g.FillRectangle(pen.Brush, 0, 0, pictureBox1.Width, pictureBox1.Height);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "Click");
			Bitmap b = this.Icon.ToBitmap();
			g.DrawImage(b, pictureBox1.Width / 2 - b.Width / 2, pictureBox1.Height / 2 - b.Height / 2);
		}


		private void button7_Click(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "Click");
			if (string.IsNullOrEmpty(textBox2.Text) == false)
			{
				comboBox1.Items.Add(textBox2.Text);
				listBox1.Items.Add(textBox2.Text);
				comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
			}
			else
			{
				MessageBox.Show("Lütfen bir veri girin");
			}
		}


		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "CheckedChanged");
			comboBox1.Sorted = (checkBox1.CheckState == CheckState.Checked) ? true : false;
			if (comboBox1.Items.Count > 0)
			{
				comboBox1.SelectedIndex = 0;
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			foreach (var item in checkedListBox1.CheckedItems)
			{
				if (listBox2.Items.Contains(item) == false)
				{
					listBox2.Items.Add(item);
				}
				else
				{
					listBox2.Items.Remove(item);
				}
			}
		}

		private void trackBar1_ValueChanged(object sender, EventArgs e)
		{
			logEvent.AddEvent(sender, "ValueChanged");
			progressBar1.Value = trackBar1.Value;
		}

		private void button12_Click(object sender, EventArgs e)
		{
			(new HakkindaFormu()).ShowDialog();
		}

		private void button13_Click(object sender, EventArgs e)
		{
			(new TimerKullanımOrnegi()).ShowDialog();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label19.Text = Cursor.Position.X + "," + Cursor.Position.Y;
		}
	}
}
