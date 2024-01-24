namespace Week9
{
    partial class Form1
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
			this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uploadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contactUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.chatWithBotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.frequentlyAskedQuestionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// maskedTextBox1
			// 
			this.maskedTextBox1.Location = new System.Drawing.Point(12, 47);
			this.maskedTextBox1.Mask = "(999) 000-0000";
			this.maskedTextBox1.Name = "maskedTextBox1";
			this.maskedTextBox1.Size = new System.Drawing.Size(240, 45);
			this.maskedTextBox1.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1080, 43);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// generalToolStripMenuItem
			// 
			this.generalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.generalToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 15F);
			this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
			this.generalToolStripMenuItem.Size = new System.Drawing.Size(112, 39);
			this.generalToolStripMenuItem.Text = "general";
			// 
			// newProjectToolStripMenuItem
			// 
			this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
			this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(246, 40);
			this.newProjectToolStripMenuItem.Text = "new project";
			this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
			// 
			// openProjectToolStripMenuItem
			// 
			this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
			this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(246, 40);
			this.openProjectToolStripMenuItem.Text = "open project";
			this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(246, 40);
			this.exitToolStripMenuItem.Text = "exit";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPageToolStripMenuItem,
            this.colorsToolStripMenuItem,
            this.saveFileToolStripMenuItem,
            this.uploadFileToolStripMenuItem});
			this.editToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 15F);
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(71, 39);
			this.editToolStripMenuItem.Text = "edit";
			// 
			// newPageToolStripMenuItem
			// 
			this.newPageToolStripMenuItem.Name = "newPageToolStripMenuItem";
			this.newPageToolStripMenuItem.Size = new System.Drawing.Size(222, 40);
			this.newPageToolStripMenuItem.Text = "new page";
			// 
			// colorsToolStripMenuItem
			// 
			this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
			this.colorsToolStripMenuItem.Size = new System.Drawing.Size(222, 40);
			this.colorsToolStripMenuItem.Text = "colors";
			// 
			// saveFileToolStripMenuItem
			// 
			this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
			this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(222, 40);
			this.saveFileToolStripMenuItem.Text = "save file";
			// 
			// uploadFileToolStripMenuItem
			// 
			this.uploadFileToolStripMenuItem.Name = "uploadFileToolStripMenuItem";
			this.uploadFileToolStripMenuItem.Size = new System.Drawing.Size(222, 40);
			this.uploadFileToolStripMenuItem.Text = "upload file";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contactUsToolStripMenuItem,
            this.chatWithBotToolStripMenuItem,
            this.frequentlyAskedQuestionsToolStripMenuItem,
            this.contactToolStripMenuItem});
			this.helpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 15F);
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(77, 39);
			this.helpToolStripMenuItem.Text = "help";
			// 
			// contactUsToolStripMenuItem
			// 
			this.contactUsToolStripMenuItem.Name = "contactUsToolStripMenuItem";
			this.contactUsToolStripMenuItem.Size = new System.Drawing.Size(401, 40);
			this.contactUsToolStripMenuItem.Text = "about us";
			this.contactUsToolStripMenuItem.Click += new System.EventHandler(this.contactUsToolStripMenuItem_Click);
			// 
			// chatWithBotToolStripMenuItem
			// 
			this.chatWithBotToolStripMenuItem.Name = "chatWithBotToolStripMenuItem";
			this.chatWithBotToolStripMenuItem.Size = new System.Drawing.Size(401, 40);
			this.chatWithBotToolStripMenuItem.Text = "chat with bot";
			// 
			// frequentlyAskedQuestionsToolStripMenuItem
			// 
			this.frequentlyAskedQuestionsToolStripMenuItem.Name = "frequentlyAskedQuestionsToolStripMenuItem";
			this.frequentlyAskedQuestionsToolStripMenuItem.Size = new System.Drawing.Size(401, 40);
			this.frequentlyAskedQuestionsToolStripMenuItem.Text = "frequently asked questions";
			// 
			// contactToolStripMenuItem
			// 
			this.contactToolStripMenuItem.Name = "contactToolStripMenuItem";
			this.contactToolStripMenuItem.Size = new System.Drawing.Size(401, 40);
			this.contactToolStripMenuItem.Text = "contact";
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(4, 3);
			this.monthCalendar1.Dock = System.Windows.Forms.DockStyle.Top;
			this.monthCalendar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.monthCalendar1.Location = new System.Drawing.Point(0, 43);
			this.monthCalendar1.MaxSelectionCount = 720;
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.ShowToday = false;
			this.monthCalendar1.TabIndex = 3;
			this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.numericUpDown1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.maskedTextBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 609);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1080, 95);
			this.panel1.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label3.Location = new System.Drawing.Point(371, 38);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(159, 29);
			this.label3.TabIndex = 4;
			this.label3.Text = "price per day";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.numericUpDown1.Location = new System.Drawing.Point(549, 29);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(247, 45);
			this.numericUpDown1.TabIndex = 3;
			this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.Location = new System.Drawing.Point(802, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(250, 39);
			this.label2.TabIndex = 2;
			this.label2.Text = "Total price : 0 $";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(201, 39);
			this.label1.TabIndex = 1;
			this.label1.Text = "your contact";
			// 
			// Form1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(1080, 704);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.monthCalendar1);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactUsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatWithBotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frequentlyAskedQuestionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

