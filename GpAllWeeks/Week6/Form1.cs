using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Control> boxes = new List<Control>();
        int size = 25, firstlength = 3;
        enum directions
        {
            Up,
            Left,
            Right,
            Down
        }
        directions currentDirection = directions.Down;
        Point target = new Point(0, 0);
        Random rnd = new Random();
        Box TARGET = new Box();
        private int scx = 0;
        public int score { get { return scx; } set { scx = value; label2.Text = scx.ToString(); } }
        private void Form1_Load(object sender, EventArgs e)
        {
            ReStart();
        }
        void ReStart()
        {
            // create had
            score = 0;
            label3.Text = "V/ms:" + timer1.Interval;
            Box bx = new Box()
            {
                Visible = true,
                Width = size,
                Height = size,
                Left = 0,
                Top = 0,
                ShowInTaskbar = false,
            };
            boxes.Add(bx);
            boxes[0].BackColor = Color.Lime;
            for (int i = 0; i < firstlength; i++)
            {
                newBox();
            }
            boxes[0].BringToFront();
            this.Top = Screen.PrimaryScreen.Bounds.Height - this.Height;
            this.Left = Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2;
            // create target
            TARGET.Visible = true;
            TARGET.BackColor = Color.Red;
            TARGET.Size = new Size(size, size);
        }
        void newBox()
        {
            Box bx = new Box()
            {
                Visible = true,
                BackColor = (boxes.Count % 2 == 0) ? Color.Green : Color.DarkGreen,
                Width = size,
                Height = size,
                Left = (boxes[boxes.Count - 1]).Location.X,
                Top = (boxes[boxes.Count - 1]).Location.Y
            };
            bx.Show();
            boxes.Add(bx);
        }
        void newTarget()
        {
            target.X = rnd.Next(size, Screen.PrimaryScreen.Bounds.Width - size * 2);
            target.Y = rnd.Next(size, Screen.PrimaryScreen.Bounds.Height - size * 2);
            TARGET.Location = target;
            newBox();
            score += 1;
        }
        void BoxMovement()
        {
            for (int i = boxes.Count - 1; i >= 1; i--)
            {
                boxes[i].Location = boxes[i - 1].Location;
            }
            switch (currentDirection)
            {
                case directions.Up:
                    boxes[0].Top -= size;
                    if (boxes[0].Top <= -size)
                    {
                        boxes[0].Top = Screen.PrimaryScreen.Bounds.Height - size;
                    }
                    break;
                case directions.Left:
                    boxes[0].Left -= size;
                    if (boxes[0].Left <= -size)
                    {
                        boxes[0].Left = Screen.PrimaryScreen.Bounds.Width - size;
                    }
                    break;
                case directions.Right:
                    boxes[0].Left += size;
                    if (boxes[0].Left >= Screen.PrimaryScreen.Bounds.Width + size)
                    {
                        boxes[0].Left = 0;
                    }
                    break;
                case directions.Down:
                    boxes[0].Top += size;
                    if (boxes[0].Bottom >= Screen.PrimaryScreen.Bounds.Height + size)
                    {
                        boxes[0].Top = 0;
                    }
                    break;
            }
            if ((Math.Abs(boxes[0].Location.X - target.X) <= size && Math.Abs(boxes[0].Location.Y - target.Y) <= size))
            {
                newTarget();
            }
            if (boxes.Count >= firstlength)
            {
                for (int i = 1; i < boxes.Count; i++)
                {
                    if (boxes[0].Location == boxes[i].Location)
                    {
                        timer1.Stop();
                        MessageBox.Show("game over");
                        for (int j = 0; j < boxes.Count; j++)
                        {
                            ((Form)boxes[j]).Close();
                        }
                        currentDirection = directions.Right;
                        boxes.Clear();
                        ReStart();
                    }
                }
            }
        }
        void PauseResume()
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                label1.Text = "▶️";
            }
            else
            {
                timer1.Start();
                label1.Text = "⏸️";
            }
            for (int i = 0; i < boxes.Count; i++)
            {
                boxes[i].BringToFront();
            }
            TARGET.BringToFront();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            BoxMovement();
            this.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            PauseResume();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (currentDirection != directions.Right)
                        currentDirection = directions.Left;
                    break;
                case Keys.Right:
                    if (currentDirection != directions.Left)
                        currentDirection = directions.Right;
                    break;
                case Keys.Up:
                    if (currentDirection != directions.Down)
                        currentDirection = directions.Up;
                    break;
                case Keys.Down:
                    if (currentDirection != directions.Up)
                        currentDirection = directions.Down;
                    break;
                case Keys.W:
                    if (timer1.Interval - 1 > 0)
                    {
                        timer1.Interval -= 1;
                    }
                    label3.Text = "V/ms:" + timer1.Interval;
                    break;
                case Keys.S:
                    timer1.Interval += 1;
                    label3.Text = "V/ms:" + timer1.Interval;
                    break;
                case Keys.B:
                    size += 5;
                    for (int i = boxes.Count - 1; i >= 0; i -= 1)
                    {
                        boxes[i].Width = size;
                        boxes[i].Height = boxes[i].Width;
                    }
                    TARGET.Width = size;
                    TARGET.Height = TARGET.Width;
                    break;
                case Keys.N:
                    if (size - 5 > 0)
                    {
                        size -= 5;
                        for (int i = boxes.Count - 1; i >= 0; i -= 1)
                        {
                            boxes[i].Width = size;
                            boxes[i].Height = boxes[i].Width;
                        }
                        TARGET.Width = size;
                        TARGET.Height = TARGET.Width;
                    }
                    break;
                case Keys.P:
                    PauseResume();
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
                case Keys.H:
                    break;
            }
        }
    }
}
