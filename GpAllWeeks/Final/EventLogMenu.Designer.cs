namespace Final
{
	partial class EventLogMenu
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.BackColor = System.Drawing.Color.Black;
			this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(166)))), ((int)(((byte)(17)))));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 23;
			this.listBox1.Location = new System.Drawing.Point(4, 47);
			this.listBox1.Margin = new System.Windows.Forms.Padding(10);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(243, 368);
			this.listBox1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(247, 44);
			this.label1.TabIndex = 1;
			this.label1.Text = "Event Listener";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 4000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// EventLogMenu
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(247, 422);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBox1);
			this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "EventLogMenu";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "EventLogMenu";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer1;
	}
}