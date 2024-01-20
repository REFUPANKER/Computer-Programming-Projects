using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;
namespace Week14
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""datasrc.xlsx"";Extended Properties='Excel 12.0 Xml;HDR=YES'");
		private void button1_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Add(new object[] { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, (float)((Convert.ToDouble(textBox3.Text) * 0.4f) + (Convert.ToDouble(textBox4.Text) * 0.6f)) });
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < 30; i++)
			{
				dataGridView1.Rows.Add(new object[] { "123", "123332", 50, 50, 50 });
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Excel.Application ea = new Excel.Application();
			ea.Visible = false;
			try
			{
				Excel.Workbook excelWorkbook = ea.Workbooks.Open(@"C:\Users\Computer\Documents\Education\GorselProgramlama2\Computer-Programming-Projects\GpAllWeeks\Week14\bin\Debug\datasrc.xlsx");
				//Excel.Workbook excelWorkbook = ea.Workbooks.Add();
				Excel._Worksheet dset = excelWorkbook.Sheets[1];
				for (int i = 0; i < dataGridView1.Rows.Count; i++)
				{
					for (int j = 0; j < dataGridView1.Columns.Count; j++)
					{
						//MessageBox.Show(dataGridView1.Rows[i].Cells[j].Value.ToString());
						dset.Cells[i + 1, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
					}
				}
				excelWorkbook.Save();
				excelWorkbook.Close();
			}
			catch (Exception ex)
			{
				Clipboard.SetText(ex.Message);
				MessageBox.Show(ex.ToString(), "error copied");
			}
			finally
			{
				ea.Quit();
				MessageBox.Show("Added!");
			}
			//con.Open();
			//OleDbCommand com = new OleDbCommand();
			//com.Connection = con;
			//foreach (DataGridViewRow item in dataGridView1.Rows)
			//{
			//	com.CommandText = "INSERT INTO [Data1] (OgrenciNo, AdSoyad, Vize, Final, [Not]) VALUES (@v1, @v2, @v3, @v4, @v5)";
			//	com.Parameters.Clear(); // Önceki döngüden kalma parametreleri temizle

			//	for (int i = 0; i < dataGridView1.Columns.Count; i++)
			//	{
			//		com.Parameters.AddWithValue($"@v{i + 1}", item.Cells[i].Value);
			//	}

			//	com.ExecuteNonQuery();
			//}
			//con.Close();
			//MessageBox.Show("İkinci işlem tamamlandı");
			this.BringToFront();
		}
	}
}
