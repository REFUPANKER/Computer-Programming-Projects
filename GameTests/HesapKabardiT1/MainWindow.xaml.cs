using System;
using System.Collections.Generic;
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
		public MainWindow()
		{
			InitializeComponent();
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
		Border selection = new Border();
		Label[,] table = new Label[11, 11];
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
					Label b = new Label() { Margin = new Thickness(1), Background = defaultBg, Foreground = defaultBg };
					b.BeginAnimation(HeightProperty, animation);
					b.BeginAnimation(WidthProperty, animation);
					b.HorizontalContentAlignment = HorizontalAlignment.Center;
					b.VerticalContentAlignment = VerticalAlignment.Center;
					b.FontSize = ((col + row) / 2) * 0.5f - ($"{i},{j}".Length * 2);
					b.Content = i + "," + j;
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

		private void B_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
		{
			Label s = (Label)sender;
			int row = Convert.ToInt32(("" + s.Content).Split(",")[0]);
			int col = Convert.ToInt32(("" + s.Content).Split(",")[1]);
			table[row, col].Background = searchColor;
		}

		private void B_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Label s = (Label)sender;
			int row = Convert.ToInt32(("" + s.Content).Split(",")[0]);
			int col = Convert.ToInt32(("" + s.Content).Split(",")[1]);
			if (selection == null)
			{
				MessageBox.Show("Select item before replace", "Caution!", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}
			if (s.Background==defaultBg)
			{
				if (selection.Width >= selection.Height)//horizontal
				{
					ReplaceCellsOnX(row, col, (int)(selection.Width / selection.Height));
				}
				else
				{
					MessageBox.Show("Vertical system is still developing");
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
			// if stack isnt matching to lengh clear selection
			if (stack + 1 != length)
			{
				foreach (var item in filled)
				{
					table[row, item].Background = defaultBg;
				}
			}
			else//=> paint with selected item's color
			{
				foreach (var item in filled)
				{
					table[row, item].Background = selection?.Background;
				}
			}
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
					le.Content = (i == 0 || j == 0) ? (Convert.ToChar(65 + i)) + "," + j : "";
					le.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
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
				s.Background = new SolidColorBrush(Color.FromRgb(40, 10, 10));
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

		private void B_MouseLeave(object sender, MouseEventArgs e)
		{
			((Label)sender).Foreground = ((Label)sender).Background;
		}

		private void B_MouseMove(object sender, MouseEventArgs e)
		{
			((Label)sender).Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
		}

		private void AppCore_Loaded(object sender, RoutedEventArgs e)
		{
			FillTable();
			FillEnemyTable();
		}

		private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Border s = (Border)sender;
			selection.Width = s.Width;
			selection.Height = s.Height;
			selection.Background = s.Background;
			SetSelectedItemSizes();
		}
		private void SetSelectedItemSizes()
		{
			if (selection != null)
			{
				SelectedItem.Background = selection.Background;
				SelectedItem.Height = selection.Height;
				SelectedItem.Width = selection.Width;
			}
		}

		private void ItemRotateXY_Click(object sender, RoutedEventArgs e)
		{
			if (selection != null)
			{
				selection.Width += selection.Height;
				selection.Height = selection.Width - selection.Height;
				selection.Width -= selection.Height;
				SetSelectedItemSizes();
			}
		}
	}
}
