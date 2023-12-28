using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstWeek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            timer.Start();
            OnTotalInvokedActionCount += Form1_OnTotalInvokedActionCount;
            OnActionAdded += Form1_OnActionAdded;
        }

        private void Form1_OnActionAdded(Action act)
        {
            Log("Act invoked " + act.Target);
        }

        private void Form1_OnTotalInvokedActionCount()
        {
            Log("ActInvoker Ran");
        }

        List<Action> actInvoker = new List<Action>();

        public delegate void eOnActionAdded(Action act);
        public event eOnActionAdded OnActionAdded;
        private void AddAction(Action act)
        {
            actInvoker.Add(act);
            OnActionAdded.Invoke(act);
        }

        public delegate void eOnTotalInvokedActionCount();
        public event eOnTotalInvokedActionCount OnTotalInvokedActionCount;

        private int prTotalInvokedActionCount = 0;
        public int TotalInvokedActionCount
        {
            get
            {
                OnTotalInvokedActionCount.Invoke();
                return prTotalInvokedActionCount;
            }
            set => prTotalInvokedActionCount = value;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < actInvoker.Count; i++)
                {
                    actInvoker[i].Invoke();
                    actInvoker.RemoveAt(i);
                    TotalInvokedActionCount++;
                }
            }
            catch { }

        }
        public void Log(string msg)
        {
            LogListBox.Items.Add(msg);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Log("App started");
            AddAction(() =>
            {
                Thread th2 = new Thread(() =>
                {
                    string r = "";
                    for (int i = 0; i < 1000; i++)
                    {
                        r += Convert.ToChar(i)+"\n";
                    }
                    MessageBox.Show("thread2 :" + r);
                });
                th2.Start();
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log("Calculation started");
            try
            {
                textBox3.Text = (Convert.ToInt32(textBox1.Text) + Convert.ToInt32(textBox2.Text)) + "";
                Log(textBox3.Text);
            }
            catch
            {
                Log("Calculation throw error");
            }
            Log("Calculation ended");
        }
        private void NumberOnlyText(object sender, EventArgs e)
        {
            try
            {
                string res = "";
                for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    int asciiCode = (int)textBox1.Text[i];
                    if (asciiCode >= 48 && asciiCode <= 57)
                    {
                        res += textBox1.Text[i];
                    }
                }
                textBox1.Text = res;
                textBox1.SelectionStart = textBox1.Text.Length;
            }
            catch { }
        }
    }
}
