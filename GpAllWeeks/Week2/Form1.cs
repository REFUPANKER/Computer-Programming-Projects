using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection dbcon = new MySqlConnection("server=localhost;uid=root;password=12345;database=sakila");
        private void Form1_Load(object sender, EventArgs e)
        {
            nofui.Hide();
            //Process process = new Process()
            //{
            //    StartInfo = new ProcessStartInfo()
            //    {
            //        FileName="tree",
            //        //Arguments= "query mysql80",
            //        UseShellExecute = true,
            //        RedirectStandardOutput = false,
            //        RedirectStandardInput =false,
            //        RedirectStandardError = false,
            //    }
            //};
            
            //StreamReader r = process.StandardOutput;
            //string rx = r.ReadToEnd();
            
            //MessageBox.Show(rx);
            
        }
        private void StartMySqlService()
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = "cmd",
                UseShellExecute = true,
                RedirectStandardOutput = false,
                Verb = "runas",
                Arguments = "/c sc start mysql80"
            });
        }
        private void MySqlAccess()
        {
            try
            {
                //select * from city where country_id = (select country_id from country where country = 'Turkey')
                dbcon.Open();
                MySqlCommand cmd = dbcon.CreateCommand();
                cmd.CommandText = textBox3.Text;
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();
                string item = "";
                listBox1.Items.Clear();
                while (reader.Read())
                {
                    item = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        item += reader.GetValue(i) + " ";
                    }
                    listBox1.Items.Add(item);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Cant connect mysql \n" + e.Message+"\nError Type :"+e.GetType().Name);
                if (e.Message.StartsWith("Unable to connect"))
                {
                    MessageBox.Show("starting mysql service");
                    StartMySqlService();
                    MessageBox.Show("try again");
                }
            }
            finally
            {
                dbcon.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlAccess();
        }
        NotifyiconUi nofui = new NotifyiconUi();
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            nofui.Show();
            nofui.Left = Cursor.Position.X - nofui.Width;
            nofui.Top = Cursor.Position.Y - nofui.Height;
            nofui.BringToFront();
        }
    }
}
