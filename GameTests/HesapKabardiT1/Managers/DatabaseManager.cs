using HesapKabardiT1.Items;
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
		ActionInvoker actink = new ActionInvoker(new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(1) });

		private bool MessageReaderCanContinue = true;
		private int lastid = 0;
		/// <summary>
		/// TODO:add room metrics
		/// TODO:create User object fro sender parameter
		/// </summary>
		public void StartMessageReader(int interval)
		{
			MessageReaderCanContinue = true;
			Thread MessageReader = new Thread(() =>
			{
				while (MessageReaderCanContinue)
				{
					DataTable? data = RequestQueryInThread($"select * from RoomMessage where room=3 and id>{lastid}", true);
					if (data?.Rows != null)
					{
						foreach (DataRow item in data.Rows)
						{
							lastid = Convert.ToInt32(item["id"]);
							actink.AddAction(new Action(() =>
							{
								OnMessage?.Invoke(item["sender"] + "", item["message"] + "");
							}));
						}
					}
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
		SqlConnection threadCon = new SqlConnection(StringPool.MsSqlCon);

		public static DataTable? RequestQuery(string query, bool returns=false)
		{
			DataTable? result = null;
			try
			{
				con.Open();
				SqlCommand cmd = con.CreateCommand();
				cmd.CommandText = query;
				cmd.ExecuteNonQuery();
				if (returns==true)
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
		public DataTable? RequestQueryInThread(string query, bool returns = false)
		{
			DataTable? result = null;
			try
			{
				threadCon.Close();
				threadCon.Open();
				SqlCommand cmd = threadCon.CreateCommand();
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
				threadCon.Close();
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


		public void SendMessage(int room, int sender, string message)
		{
			RequestQuery($"insert into RoomMessage (room,sender,message) values ({room},{sender},'{message}');", false);
		}
	}
}
