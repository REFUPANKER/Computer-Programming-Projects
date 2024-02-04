using HesapKabardiT1.Managers;
using HesapKabardiT1.Pool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HesapKabardiT1
{
	/// <summary>
	/// Interaction logic for GameRoomSelector.xaml
	/// </summary>
	public partial class GameRoomSelector : Window
	{
		DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1), IsEnabled = true };
		DatabaseManager dbm = Core.dbm;
		public GameRoomSelector()
		{
			InitializeComponent();

			timer.Tick += Timer_Tick;

			//dbm.Users.Add(new Items.User("Testing", "EF@gcom", "qwe123"));
			//dbm.SaveChanges();
		}

		//DatabaseManager dbm = Core.dbm;
		//List<Action> actx = new List<Action>();
		int lastid = 0;
		private void Timer_Tick(object? sender, EventArgs e)
		{
			var GetRooms = dbm.GameRooms.Select(x => x).Where(x => x.ID > lastid).ToList();
			foreach (var item in GetRooms)
			{
				if (item.ID != null)
				{
					lastid = item.ID.Value;
				}
				listBox1.Items.Add(item.ID+"\t| "+item.Name + " - " + item.Turn );
			}
		}

		private void CreateRoomBtn_Click(object sender, RoutedEventArgs e)
		{
			//DatabaseManager.RequestQuery("insert into GameRooms (name,p1) values ('ROOM',1)");
		}
	}
}
