using HesapKabardiT1.Items;
using HesapKabardiT1.Managers;
using HesapKabardiT1.Pool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace HesapKabardiT1
{
	/// <summary>
	/// Interaction logic for ChatMenu.xaml
	/// </summary>
	public partial class ChatMenu : Window
	{
		private DatabaseManager dbm = Core.dbm;

		/// <summary>
		/// Created for synchronizing Thread with UI
		/// </summary>
		DispatcherTimer msgTimer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1), IsEnabled = true };
		// mi : message item 
		Style? miHolder, miStack, miSender, miContent;
		public ChatMenu()
		{
			InitializeComponent();
			miHolder = (Style)FindResource("MessageItem");
			miStack = (Style)FindResource("MessageItemStack");
			miSender = (Style)FindResource("MessageItemSender");
			miContent = (Style)FindResource("MessageItemContent");

			msgTimer.Tick += MsgTimer_Tick;
		}


		public void AddMessageItem(string? user, string message)
		{
			Border holder = new Border() { Style = miHolder };
			StackPanel stack = new StackPanel() { Style = miStack };
			Label sender = new Label() { Style = miSender, Content = (user != null ? user : string.Empty) };
			TextBlock content = new TextBlock() { Style = miContent, Text = message };
			stack.Children.Add(sender);
			stack.Children.Add(content);
			holder.Child = stack;
			messageHolder.Children.Add(holder);
			messageScroll.ScrollToEnd();
		}
		private void SendMessageIfPossible()
		{
			if (!string.IsNullOrEmpty(MessageContent.Text))
			{
				SendMessage(3, MessageContent.Text);
				MessageContent.Text = string.Empty;
			}
		}
		public void SendMessage(int room, string message)
		{
			dbm.RoomMessages.Add(new Items.RoomMessage() { Message = message, Room = room, Sender = 4 });
			dbm.SaveChanges();
		}

		private int lastid = 0;
		/// <summary>
		/// TODO:add room metrics
		/// </summary>
		private void MsgTimer_Tick(object? sender, EventArgs e)
		{
			var GetMessages = from rm in dbm.RoomMessages
							  join u in dbm.Users on rm.Sender equals u.ID
							  where rm.ID > lastid && rm.Room == 3
							  select new { RoomMessage = rm, User = u.Name };
			foreach (var item in GetMessages)
			{
				if (item.RoomMessage.ID != null)
				{
					lastid = item.RoomMessage.ID.Value;
				}
				AddMessageItem(item.User, item.RoomMessage.Message + string.Empty);
			}
		}
		private void ClearChatButton_Click(object sender, RoutedEventArgs e)
		{
			messageHolder.Children.Clear();
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			msgTimer.Stop();
		}
		private void SendMessageBtn_Click(object sender, RoutedEventArgs e)
		{
			SendMessageIfPossible();
		}
		private void MessageContent_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				SendMessageIfPossible();
			}
		}
		private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.Visibility == Visibility.Visible)
			{
				msgTimer.Start();
			}
			else
			{
				msgTimer.Stop();
				messageHolder.Children.Clear();
			}
		}
	}
}
