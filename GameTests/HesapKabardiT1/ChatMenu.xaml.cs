using HesapKabardiT1.Managers;
using System;
using System.Diagnostics.CodeAnalysis;
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
		// mi : message item 
		Style? miHolder, miStack, miSender, miContent;
		private void InitApp()
		{
			InitializeComponent();
			miHolder = (Style)FindResource("MessageItem");
			miStack = (Style)FindResource("MessageItemStack");
			miSender = (Style)FindResource("MessageItemSender");
			miContent = (Style)FindResource("MessageItemContent");

			dbm.OnMessage += Dbm_OnMessage;
		}
		ActionInvoker actink = new ActionInvoker(new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(1) });
		private void Dbm_OnMessage(string sender, string content)
		{
			actink.AddAction(new Action(() =>
			{
				if (messageHolder.Children.Count > 3)
				{
					dbm.StopMessageReader();
				}
				else
				{
					AddMessageItem(sender, content);
				}
			}));
		}

		[AllowNull]
		private DatabaseManager dbm;

		public ChatMenu(DatabaseManager dbm) { this.dbm = dbm; InitApp(); }

		public void AddMessageItem(string user, string message)
		{
			Border holder = new Border() { Style = miHolder };
			StackPanel stack = new StackPanel() { Style = miStack };
			Label sender = new Label() { Style = miSender, Content = user };
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
				AddMessageItem("qwe", MessageContent.Text);
				MessageContent.Text = string.Empty;
			}
		}

		private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.Visibility == Visibility.Visible)
			{
				dbm.StartMessageReader(1000);
			}
			else
			{
				dbm.StopMessageReader();
				messageHolder.Children.Clear();
			}
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
			Hide();
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
	}
}
