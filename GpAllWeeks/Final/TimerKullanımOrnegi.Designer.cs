namespace Final
{
	partial class TimerKullanımOrnegi
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerKullanımOrnegi));
			this.KayanYaziTimer = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.dijitalSaatTimer = new System.Windows.Forms.Timer(this.components);
			this.AnalogClock = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// KayanYaziTimer
			// 
			this.KayanYaziTimer.Enabled = true;
			this.KayanYaziTimer.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(262, 35);
			this.label1.TabIndex = 0;
			this.label1.Text = "Kayan Yazı Yapımı";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
			this.textBox1.ForeColor = System.Drawing.Color.Orange;
			this.textBox1.Location = new System.Drawing.Point(12, 47);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(776, 144);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "Timer \' ın Tick Event ine\r\n\r\nstring first = label1.Text[0]+\"\";\r\nlabel1.Text = lab" +
    "el1.Text.Substring(1)+first;\r\n";
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
			this.textBox2.ForeColor = System.Drawing.Color.Orange;
			this.textBox2.Location = new System.Drawing.Point(12, 232);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox2.Size = new System.Drawing.Size(776, 206);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = resources.GetString("textBox2.Text");
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
			this.label2.Location = new System.Drawing.Point(12, 194);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(262, 35);
			this.label2.TabIndex = 2;
			this.label2.Text = "Analog Saat Yapımı";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(907, 47);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(200, 200);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 300;
			this.toolTip1.InitialDelay = 500;
			this.toolTip1.ReshowDelay = 100;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(902, 250);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(205, 59);
			this.label3.TabIndex = 5;
			this.label3.Text = "00:00:00";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
			this.label4.Location = new System.Drawing.Point(12, 452);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(399, 35);
			this.label4.TabIndex = 6;
			this.label4.Text = "Dijital Saat yapımı";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox3
			// 
			this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
			this.textBox3.ForeColor = System.Drawing.Color.Orange;
			this.textBox3.Location = new System.Drawing.Point(12, 490);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(776, 130);
			this.textBox3.TabIndex = 7;
			this.textBox3.Text = "Timer \' ın Tick Event ine\r\n\r\nstring first = label1.Text[0]+\"\";\r\nlabel1.Text = lab" +
    "el1.Text.Substring(1)+first;\r\n";
			// 
			// dijitalSaatTimer
			// 
			this.dijitalSaatTimer.Enabled = true;
			this.dijitalSaatTimer.Interval = 1000;
			this.dijitalSaatTimer.Tick += new System.EventHandler(this.dijitalSaatTimer_Tick);
			// 
			// AnalogClock
			// 
			this.AnalogClock.Enabled = true;
			this.AnalogClock.Interval = 10;
			this.AnalogClock.Tick += new System.EventHandler(this.AnalogClock_Tick);
			// 
			// TimerKullanımOrnegi
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
			this.ClientSize = new System.Drawing.Size(1216, 676);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "TimerKullanımOrnegi";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TimerKullanımÖrneği";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer KayanYaziTimer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Timer dijitalSaatTimer;
		private System.Windows.Forms.Timer AnalogClock;
	}
}