using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace HesapKabardiT1.Managers
{
	public class DatabaseManager
	{
		private bool MessageReaderCanContinue = true;
		/// <summary>
		/// TODO:add room metrics
		/// </summary>
		public void StartMessageReader(int interval)
		{
			MessageReaderCanContinue = true;
			Thread MessageReader = new Thread(() =>
			{
				while (MessageReaderCanContinue)
				{
					OnMessage?.Invoke("qwe", "icardi");
					Thread.Sleep(interval);
				}
			})
			{ IsBackground = true, Name = "HesapKabardi-Reader" };
			MessageReader.Start();
		}
		public void StopMessageReader()
		{
			MessageReaderCanContinue = false;
		}
		static SqlConnection con = new SqlConnection(StringPool.MsSqlCon);

		protected static DataTable? RequestQuery(string query, bool returns)
		{
			DataTable? result = null;
			try
			{
				con.Close();
				con.Open();
				SqlCommand cmd = con.CreateCommand();
				cmd.CommandText = query;
				cmd.ExecuteNonQuery();
				if (returns)
				{
					SqlDataReader reader = cmd.ExecuteReader();
					DataTable data = new DataTable();
					data.Load(reader);
					result = data;
					reader.Close();
				}
			}
			catch (Exception e) { MessageBox.Show(e + ""); }
			finally
			{
				con.Close();
			}
			return result;
		}

		public delegate void OnMessageReceived(string sender, string content);
		/// <summary>
		/// Creates thread for reading messages<br/>
		/// its invoking inside of thread <br/>
		/// so you need to concat times with <seealso cref="DispatcherTimer"/>
		/// </summary>
		public event OnMessageReceived? OnMessage;
	}
}
