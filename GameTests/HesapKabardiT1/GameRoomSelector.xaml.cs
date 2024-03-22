using HesapKabardiT1.Items;
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
		public GameRoomSelector()
		{
			InitializeComponent();
			timer.Tick += Timer_Tick;
		}

		int lastSelected = -1;
		private void Timer_Tick(object? sender, EventArgs e)
		{
			if (listBox1.SelectedIndex >= 0)
			{
				lastSelected = listBox1.SelectedIndex;
			}
			listBox1.Items.Clear();
			var GetRooms = from gr in Core.dbm.GameRooms
						   where gr.Player2 != null && gr.Player2.Value == -1
						   select gr;
			foreach (var item in GetRooms)
			{
				listBox1.Items.Add(item);
			}
			if (listBox1.Items.Count > lastSelected)
			{
				listBox1.SelectedIndex = lastSelected;
			}
		}

		private void CreateRoomBtn_Click(object sender, RoutedEventArgs e)
		{
			string roomname = "";
			if (string.IsNullOrEmpty(GameRoomName.Text))
			{
				if (MessageBox.Show("Would you want to use auto created name?", "Create Game Room", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
				{
					roomname = Core.RandomName_GameRoom(10);
				}
				else
				{
					return;
				}
			}
			else
			{
				roomname = GameRoomName.Text;
			}
			Core.wChat.RoomName = roomname;
			Core.dbm.GameRooms.Add(new Items.Room() { Name = roomname, Player1 = 4, Player2 = null });
			Core.dbm.SaveChanges();
		}

		private void GameRoomSelectorWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			timer.Stop();
		}

		private void GameRoomSelectorWindow_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.Visibility == Visibility.Visible)
			{
				timer.Start();
			}
			else
			{
				timer.Stop();
			}
		}

		Room? SelectedRoom;
		private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try { SelectedRoom = (Room)listBox1.Items[listBox1.SelectedIndex]; } catch { }
		}

		private void JoinRoom_Click(object sender, RoutedEventArgs e)
		{
			if (SelectedRoom!=null)
			{
				if (MessageBox.Show($"Confirm Room\n{SelectedRoom.ToString()}?", "Join to Game Room", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
				{
					MessageBox.Show("Conntected to\n" + SelectedRoom.Name);
				}
			}
			else
			{
				MessageBox.Show("Select room");
			}
		}
	}
}
