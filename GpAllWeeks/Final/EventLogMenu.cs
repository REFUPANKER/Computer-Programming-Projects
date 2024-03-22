using System;
using System.Windows.Forms;

namespace Final
{
	public partial class EventLogMenu : Form
	{
		public EventLogMenu()
		{
			InitializeComponent();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (listBox1.Items.Count > 0)
			{
				listBox1.Items.RemoveAt(0);
			}
			
		}
		private void ResizeByLongestItem()
		{
			int max = 0;
			foreach (var item in listBox1.Items)
			{
				if (item.ToString().Length * listBox1.Font.Size > max)
				{
					max = (item.ToString().Length * ((int)listBox1.Font.Size))-item.ToString().Length/2;
				}
			}
			this.Width = max;
			listBox1.Width = this.Width;
		}

		public void AddEvent(object sender, object eventName)
		{
			object data = sender.GetType().Name + " " + eventName;
			if (!listBox1.Items.Contains(data) || listBox1.Items.Count == 0)
			{
				listBox1.Items.Add(data);
			}
			else if (listBox1.Items.Contains(data))
			{
				object trash = listBox1.Items[0];
				listBox1.Items[listBox1.Items.IndexOf(data)] = trash;
				listBox1.Items[0] = data;
			}
			ResizeByLongestItem();
		}
	}
}
