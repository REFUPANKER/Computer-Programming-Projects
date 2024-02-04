using HesapKabardiT1.Managers;
using HesapKabardiT1.Pool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HesapKabardiT1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		//ChatMenu chatmenu = Core.wChat;
		public MainWindow()
		{
			InitializeComponent();
			//UserManager.AddUser("testing","admin@gcom","12345");
		}

		private void AppCore_Loaded(object sender, RoutedEventArgs e)
		{
			FillTable();
			FillEnemyTable();
		}

		private void ExitBtn_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		Point pxy;
		private void Navbar_MouseDown(object sender, MouseButtonEventArgs e)
		{
			pxy = e.GetPosition(this);
		}
		private void Navbar_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				this.Left += e.GetPosition(this).X - pxy.X;
				this.Top += e.GetPosition(this).Y - pxy.Y;
			}
		}

		private class PointItem : Label
		{
			public List<int[]> friends = new List<int[]>();
			[AllowNull]
			public Label selectedItem;
			public Brush? preBgColor;
			public int Bet = 0;
			public bool haveBet { get { return Bet > 0; } }
		}

		bool canReplace = true;
		PointItem[,] table = new PointItem[11, 11];
		SolidColorBrush defaultBg = new SolidColorBrush(Color.FromRgb(45, 45, 45));
		private void FillTable()
		{
			int col = (int)(GameHolder.ActualWidth / 10);
			int row = (int)(GameHolder.ActualHeight / 10);
			DoubleAnimation animation = new DoubleAnimation(0, (col + row) / 2, TimeSpan.FromMilliseconds(500));
			for (int i = 0; i < GameHolder.ActualWidth / col; i++)
			{
				for (int j = 0; j < GameHolder.ActualHeight / row; j++)
				{
					PointItem b = new PointItem() { Margin = new Thickness(1), Background = defaultBg, Foreground = defaultBg };
					b.BeginAnimation(HeightProperty, animation);
					b.BeginAnimation(WidthProperty, animation);
					b.HorizontalContentAlignment = HorizontalAlignment.Center;
					b.VerticalContentAlignment = VerticalAlignment.Center;
					b.FontSize = ((col + row) / 2) * 0.5f - ($"{i},{j}".Length * 2);
					b.Content = (Convert.ToChar(65 + i)) + "," + j;
					Grid.SetColumn(b, j);
					Grid.SetRow(b, i);
					table[i, j] = b;
					GameHolder.Children.Add(b);
					b.MouseMove += B_MouseMove;
					b.MouseLeave += B_MouseLeave;
					b.MouseLeftButtonDown += B_MouseLeftButtonDown;
					b.MouseRightButtonDown += B_MouseRightButtonDown;
				}
			}
		}

		SolidColorBrush searchColor = new SolidColorBrush(Color.FromRgb(255, 255, 0));
		private void ReplaceCellsOnX(int row, int point, int length)
		{
			/* Explaintation
			 * Start from sent index (for example 5)
			 * [ ][*][*][ ][ ][ ][*][ ][*][ ]
			 *				   ^ sent index
			 * cant replace blocks to right so code needs to search for other way
			 * [ ][*][*][<>][<][<][*][ ][*][ ]
			 *			 ^ matching to length
			 * returns index 3
			 * if cant find point to replace cells,returns -1
			 * currently checking by bg color
			 */
			// first search for right side
			int stack = -1;// dont count starting point
			int[] filled = new int[length];
			//fill with -1 for not selected points
			for (int i = 0; i < length; i++)
			{
				filled[i] = -1;
			}
			for (int i = 0; i < length; i++)
			{
				if (point + i < table.GetLength(1))
				{
					if (table[row, point + i].Background == defaultBg)// default bg points empty cell
					{
						table[row, point + i].Background = searchColor;
						stack++;
						filled[stack] = point + i;
					}
					else
					{
						break;
					}
				}
			}
			//turn back from max point of right to left
			for (int i = ((point + stack) - (length - 1)); i < (point + stack); i++)
			{
				if (i < table.GetLength(1) && i >= 0)
				{
					if (table[row, i].Background == defaultBg)// default bg points empty cell
					{
						table[row, i].Background = searchColor;
						stack++;
						filled[stack] = i;
					}
				}
			}
			//set friend points
			List<int[]> friends = new List<int[]>();
			foreach (var item in filled)
			{
				if (item >= 0 && item <= table.GetLength(0))
				{
					friends.Add(new int[] { row, item });
				}
			}
			// if stack isnt matching to lengh clear SelectedItem
			if (stack + 1 != length)
			{
				foreach (var item in filled)
				{
					if (item >= 0 && item <= table.GetLength(1))
					{
						table[row, item].Background = defaultBg;
					}
				}
			}
			else//=> paint with selected item's color
			{
				foreach (var item in filled)
				{
					if (item >= 0 && item <= table.GetLength(1))
					{
						table[row, item].Background = SelectedItem.Background;
						table[row, item].Foreground = SelectedItem.Background;
						table[row, item].friends = friends;
						table[row, item].selectedItem = UiSelectedItem;
						table[row, item].preBgColor = UiSelectedItem?.Background;
					}
				}
				if (UiSelectedItem != null)
				{
					UiSelectedItem.Background = defaultBg;
					UiSelectedItem.IsEnabled = false;
				}
				DeselectItem();
			}
		}
		private void ReplaceCellsOnY(int col, int point, int length)
		{
			int stack = -1;
			int[] filled = new int[length];
			for (int i = 0; i < length; i++)
			{
				filled[i] = -1;
			}
			for (int i = 0; i < length; i++)
			{
				if (point + i < table.GetLength(1))
				{
					if (table[point + i, col].Background == defaultBg)
					{
						table[point + i, col].Background = searchColor;
						stack++;
						filled[stack] = point + i;
					}
					else
					{
						break;
					}
				}
			}
			// to top
			for (int i = ((point + stack) - (length - 1)); i < (point + stack); i++)
			{
				if (i < table.GetLength(0) && i >= 0)
				{
					if (table[i, col].Background == defaultBg)// default bg points empty cell
					{
						table[i, col].Background = searchColor;
						stack++;
						filled[stack] = i;
					}
				}
			}
			//set friend points
			List<int[]> friends = new List<int[]>();
			foreach (var item in filled)
			{
				if (item >= 0 && item <= table.GetLength(0))
				{
					friends.Add(new int[] { item, col });
				}
			}
			// if stack isnt matching to lengh clear SelectedItem
			if (stack + 1 != length)
			{
				foreach (var item in filled)
				{
					if (item >= 0 && item <= table.GetLength(0))
					{
						table[item, col].Background = defaultBg;
					}
				}
			}
			else//=> paint with selected item's color
			{
				foreach (var item in filled)
				{
					if (item >= 0 && item <= table.GetLength(0))
					{
						table[item, col].Background = SelectedItem?.Background;
						table[item, col].Foreground = SelectedItem?.Background;
						table[item, col].friends = friends;
						table[item, col].selectedItem = UiSelectedItem;
						table[item, col].preBgColor = UiSelectedItem?.Background;
					}
				}
				if (UiSelectedItem != null)
				{
					UiSelectedItem.Background = defaultBg;
					UiSelectedItem.IsEnabled = false;
				}
				DeselectItem();
			}
		}

		private void DeleteCells(int col, int row)
		{
			foreach (var item in table[row, col].friends)
			{
				table[item[0], item[1]].Background = defaultBg;
				table[item[0], item[1]].Foreground = defaultBg;
				table[item[0], item[1]].Bet = 0;
			}
			table[row, col].friends.Clear();
			table[row, col].selectedItem.Background = table[row, col].preBgColor;
			table[row, col].selectedItem.IsEnabled = true;
			totalBetOnItem.Content = "0";
			DeselectItem();
		}

		SolidColorBrush defaultEnemyBg = new SolidColorBrush(Color.FromRgb(70, 70, 70));
		private void FillEnemyTable()
		{
			int col = (int)(EnemyGameHolder.ActualWidth / 10);
			int row = (int)(EnemyGameHolder.ActualHeight / 10);
			DoubleAnimation animation = new DoubleAnimation(0, (col + row) / 2, TimeSpan.FromMilliseconds(500));
			for (int i = 0; i < EnemyGameHolder.ActualWidth / col; i++)
			{
				for (int j = 0; j < EnemyGameHolder.ActualHeight / row; j++)
				{
					// le means LabelEnemy
					Label le = new Label() { Margin = new Thickness(1), Background = defaultEnemyBg, Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255)) };
					le.BeginAnimation(HeightProperty, animation);
					le.BeginAnimation(WidthProperty, animation);
					le.HorizontalContentAlignment = HorizontalAlignment.Center;
					le.VerticalContentAlignment = VerticalAlignment.Center;
					le.FontSize = ((col + row) / 2) * 0.5f - ($"{i},{j}".Length * 2);
					le.Content = (Convert.ToChar(65 + i)) + "," + j;
					le.Foreground = new SolidColorBrush(Color.FromRgb((byte)(defaultEnemyBg.Color.R + 100), (byte)(defaultEnemyBg.Color.G + 100), (byte)(defaultEnemyBg.Color.B + 100)));
					Grid.SetColumn(le, j);
					Grid.SetRow(le, i);
					EnemyGameHolder.Children.Add(le);
					le.MouseMove += Le_MouseMove;
					le.MouseLeave += Le_MouseLeave;
					le.MouseLeftButtonDown += Le_MouseLeftButtonDown;
				}
			}
		}

		private void Le_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Label s = (Label)sender;
			if (s.IsEnabled)
			{
				DoubleAnimation animation = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(200));
				s.BeginAnimation(OpacityProperty, animation);
				s.IsEnabled = false;
			}
		}
		private void Le_MouseLeave(object sender, MouseEventArgs e)
		{
			Label s = (Label)sender;
			if (s.IsEnabled)
			{
				s.Background = defaultEnemyBg;
			}
		}
		private void Le_MouseMove(object sender, MouseEventArgs e)
		{
			Label s = (Label)sender;
			if (s.IsEnabled)
			{
				s.Background = new SolidColorBrush(Color.FromRgb(100, 30, 30));
			}
		}

		private void B_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (!canReplace) { return; }
			Label s = (Label)sender;
			int row = Convert.ToInt32(Convert.ToChar(("" + s.Content).Split(",")[0])) - 65;
			int col = Convert.ToInt32(("" + s.Content).Split(",")[1]);
			if (s.Background != defaultBg)
			{
				DeleteCells(col, row);
			}
		}
		private void B_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (!canReplace) { return; }
			PointItem s = (PointItem)sender;
			int row = Convert.ToInt32(Convert.ToChar(("" + s.Content).Split(",")[0])) - 65;
			int col = Convert.ToInt32(("" + s.Content).Split(",")[1]);
			if (s.Background == defaultBg)
			{
				if (SelectedItem.Background == null)
				{
					MessageBox.Show("Select item before replace", "Caution!", MessageBoxButton.OK, MessageBoxImage.Warning);
				}
				else
				{
					if (SelectedItem.Width >= SelectedItem.Height) // horizontal
					{
						ReplaceCellsOnX(row, col, (int)(SelectedItem.Width / SelectedItem.Height));
					}
					else
					{
						ReplaceCellsOnY(col, row, (int)(SelectedItem.Height / SelectedItem.Width));
					}
				}
			}
			else
			{
				totalBetOnItem.Content = s.Bet > 0 ? s.Bet : "Placing bet...";
				SelectedBetItem.Content = s.Content;
				PlaceBetMenu.Visibility = Visibility.Visible;
				PlacedBet.Text = s.Bet + "";
				PlacedBet.Focus();
				//MessageBox.Show("Place bet or update", "Go to Bet Panel!", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}
		private void B_MouseLeave(object sender, MouseEventArgs e)
		{
			PointItem s = (PointItem)sender;
			s.Foreground = s.Background;
			totalBetOnItem.Content = "";
		}
		private void B_MouseMove(object sender, MouseEventArgs e)
		{
			PointItem s = (PointItem)sender;
			s.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
			totalBetOnItem.Content = s.Bet;
		}

		Label? UiSelectedItem;
		private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Label s = (Label)sender;
			SelectedItem.Width = s.Width;
			SelectedItem.Height = s.Height;
			SelectedItem.Background = s.Background;
			UiSelectedItem = s;
			SetSelectedItemSizes();
		}
		private void DeselectItem()
		{
			SelectedItem.Background = null;
			SelectedItem.Height = 0;
			SelectedItem.Width = 0;
		}
		private void SetSelectedItemSizes()
		{
			if (SelectedItem != null)
			{
				SelectedItem.Background = SelectedItem.Background;
				SelectedItem.Height = SelectedItem.Height;
				SelectedItem.Width = SelectedItem.Width;
			}
		}
		void RotateItem()
		{
			if (SelectedItem != null)
			{
				SelectedItem.Width += SelectedItem.Height;
				SelectedItem.Height = SelectedItem.Width - SelectedItem.Height;
				SelectedItem.Width -= SelectedItem.Height;
				SetSelectedItemSizes();
			}
		}
		private void ItemRotateXY_Click(object sender, RoutedEventArgs e)
		{
			RotateItem();
		}

		List<int[]> ReplacedItems = new List<int[]>();
		int TotalBet = 0;
		private void ReadyBtn_Click(object sender, RoutedEventArgs e)
		{
			bool granted = true;
			foreach (StackPanel item in PointItemsUiHolder.Children)
			{
				foreach (Label uitem in item.Children)
				{
					if (uitem.Background != defaultBg)
					{
						granted = false;
					}
				}
			}
			if (granted)
			{
				canReplace = false;
				ItemReplacingMenu.Height = ItemReplacingMenu.ActualHeight;
				PlaceBetMenu.Height = PlaceBetMenu.ActualHeight;
				ItemReplacingMenu.IsEnabled = false;
				PlaceBetMenu.IsEnabled = false;

				DoubleAnimation hideMenu = new DoubleAnimation(0, TimeSpan.FromMilliseconds(300));

				ItemReplacingMenu.BeginAnimation(HeightProperty, hideMenu);
				PlaceBetMenu.BeginAnimation(HeightProperty, hideMenu);

				for (int i = 0; i < table.GetLength(0); i++)
				{
					for (int j = 0; j < table.GetLength(1); j++)
					{
						if (table[i, j].Background != defaultBg)
						{
							ReplacedItems.Add(new int[] { i, j });
						}
						if (table[i, j].haveBet)
						{
							TotalBet += table[i, j].Bet;
						}
					}
				}
				TotalBetLabel.Content = TotalBet;
				MessageBox.Show("Good luck!");
			}
			else
			{
				MessageBox.Show("Use all items");
			}
		}
		private void Confirmbet_Click(object sender, RoutedEventArgs e)
		{
			if ((SelectedBetItem.Content + "").StartsWith("-"))
			{
				MessageBox.Show("No Item Selected");
			}
			else
			{
				int row = Convert.ToInt32(Convert.ToChar(("" + SelectedBetItem.Content).Split(",")[0])) - 65;
				int col = Convert.ToInt32(("" + SelectedBetItem.Content).Split(",")[1]);
				if (string.IsNullOrEmpty(PlacedBet.Text) == false)
				{
					table[row, col].Bet = Convert.ToInt32(PlacedBet.Text);
					SelectedBetItem.Content = "-,-";
					totalBetOnItem.Content = "0";
					PlacedBet.Text = "";
					PlaceBetMenu.Visibility = Visibility.Collapsed;
					MessageBox.Show("Bets placed");
				}
				else
				{
					MessageBox.Show("Place bet (Min: 0)");
				}
			}
		}
		public const int MaxBet = 5000;
		private void PlacedBet_TextChanged(object sender, TextChangedEventArgs e)
		{
			string r = "";
			for (int i = 0; i < PlacedBet.Text.Length; i++)
			{
				int c = Convert.ToInt32(PlacedBet.Text[i]);
				if (c >= 48 && c <= 57)
				{
					r += ((char)c);
				}
			}
			if (ConvertibleToInt(r) && Convert.ToInt32(r) > MaxBet)
			{
				MessageBox.Show($"Max bet is {MaxBet}", "Caution!", MessageBoxButton.OK, MessageBoxImage.Warning);
				r = MaxBet.ToString();
			}
			PlacedBet.Text = r;
			PlacedBet.SelectionStart = PlacedBet.Text.Length;
		}
		private bool ConvertibleToInt(object msg)
		{
			bool result = false;
			try
			{
				Convert.ToInt32(msg);
				result = true;
			}
			catch { }
			return result;
		}
		private void CancelBet_Click(object sender, RoutedEventArgs e)
		{
			SelectedBetItem.Content = "-,-";
			totalBetOnItem.Content = "0";
			PlacedBet.Text = "";
			PlaceBetMenu.Visibility = Visibility.Collapsed;
		}

		private void ChatOpener_Click(object sender, RoutedEventArgs e)
		{
			//if (chatmenu.Visibility != Visibility.Visible)
			//{
			//	chatmenu.Show();
			//}
			//else
			//{
			//	chatmenu.Hide();
			//}
		}
	}
}
