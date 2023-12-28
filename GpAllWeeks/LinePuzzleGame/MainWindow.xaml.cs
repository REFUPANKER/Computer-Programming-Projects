using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LinePuzzleGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region form movement
        Point pxy;
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.Left += e.GetPosition(this).X - pxy.X;
                this.Top += e.GetPosition(this).Y - pxy.Y;
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            pxy = e.GetPosition(this);
        }
        #endregion

        Style DarkBox, OrangeBox, UserBox, PathBox;

        Border[,] table = new Border[9, 9];

        bool UseOutline = false;

        public MainWindow()
        {
            InitializeComponent();
            DarkBox = (Style)FindResource("DarkBox");
            OrangeBox = (Style)FindResource("OrangeBox");
            UserBox = (Style)FindResource("UserBox");
            PathBox = (Style)FindResource("PathBox");
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Border b = new Border();
                    b.Style = (UseOutline && (i == 0 || i == 8 || j == 0 || j == 8)) ? OrangeBox : DarkBox;
                    //b.Style = DarkBox;
                    Grid.SetColumn(b, i);
                    Grid.SetRow(b, j);
                    grid1.Children.Add(b);
                    table[i, j] = b;
                    b.MouseDown += CellClick;
                }
            }
            //RandomOrangeBox(4);
            CreateUser();
            MapsComboBox.Items.Add("None");
            MapsComboBox.SelectedIndex = 0;
            UploadMaps(DesktopPath + "\\path.txt");
        }

        void CellClick(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Border current = ((Border)sender);
                if (current.Style == OrangeBox)
                {
                    current.Style = DarkBox;
                }
                else if (current.Style == DarkBox || current.Style == PathBox)
                {
                    current.Style = OrangeBox;
                }
            }
        }

        string RandomIdGen(int length)
        {
            string result = "";
            for (int i = 0; i < length; i++)
            {
                if (rnd.Next(1, 3) == 1)
                {
                    result += rnd.Next(0, 10);
                }
                else
                {
                    result += ((char)rnd.Next(65, 91));
                }
            }
            return result;
        }
        public string DesktopPath { get => Environment.GetFolderPath(Environment.SpecialFolder.Desktop); }
        void SaveMap()
        {
            string CordinateString = $"Map {RandomIdGen(8)}\n";
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j].Style == OrangeBox)
                    {
                        CordinateString += $"({i},{j})";
                        CordinateString += (j + 1 < table.GetLength(0) ? "\n" : "");
                    }
                }
                CordinateString += (i + 1 < table.GetLength(0) ? "\n" : "");
            }
            StreamWriter fs = new StreamWriter(DesktopPath + "\\path.txt", true);
            fs.WriteLine(CordinateString);
            fs.Close();
            MessageBox.Show("Map Saved");
        }

        void RemovePathBoxes()
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j].Style == PathBox)
                    {
                        table[i, j].Style = DarkBox;
                    }
                }
            }
        }
        void RemoveOrangeBoxes()
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j].Style == OrangeBox)
                    {
                        table[i, j].Style = DarkBox;
                    }
                }
            }
        }
        void RemoveUser()
        {
            TotalMovement = 0;
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j].Style == UserBox)
                    {
                        table[i, j].Style = DarkBox;
                    }
                }
            }
        }

        Dictionary<string, List<Point>> MapsList = new Dictionary<string, List<Point>>();

        void UploadMaps(string path)
        {
            try
            {
                string mapdata = File.ReadAllText(path);
                foreach (var item in mapdata.Split("Map "))
                {
                    if (item != null && item.Replace("\n", "").Length > 1)
                    {
                        string mapName = item.Substring(0, item.IndexOf("\n"));
                        MapsComboBox.Items.Add(mapName);
                        List<Point> mapPoints = new List<Point>();
                        string line = item.Substring(mapName.Length + 1);
                        foreach (var pxy in line.Split("\n"))
                        {
                            if (pxy.Length > 1)
                            {
                                int num1 = Convert.ToInt32(pxy.Substring(1, pxy.IndexOf(",") - 1));
                                int num2 = Convert.ToInt32(pxy.Substring(pxy.IndexOf(",") + 1).Replace(")", ""));
                                mapPoints.Add(new Point(num1, num2));
                            }
                        }
                        MapsList.Add(mapName, mapPoints);
                    }
                }

            }
            catch (Exception e) { MessageBox.Show(e + ""); }
        }

        Random rnd = new Random();
        void RandomOrangeBox(int count)
        {
            for (int i = 0; i < count; i++)
            {
                int rpoint = rnd.Next(0, 81);
                if (((Border)grid1.Children[rpoint]).Style != OrangeBox)
                {
                    ((Border)grid1.Children[rpoint]).Style = OrangeBox;
                }
                else
                {
                    i--;
                }
            }
        }

        public Border? User
        {
            get
            {
                for (int i = 0; i < grid1.Children.Count; i++)
                {
                    if (((Border)grid1.Children[i]).Style == UserBox)
                    {
                        return ((Border)grid1.Children[i]);
                    }
                }
                return null;
            }
        }

        void CreateUser()
        {
            RemoveUser();
            int rpoint = 0;
            Border userobj;
            while (true)
            {
                rpoint = rnd.Next(GetLowestBound, 81);
                userobj = (Border)grid1.Children[rpoint];
                if (userobj.Style != OrangeBox)
                {
                    userobj.Style = UserBox;
                    break;
                }
            }
        }

        private void pathbox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                RemovePathBoxes();
        }

        private void orangebox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                RemoveOrangeBoxes();
        }

        private void darkbox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                SaveMap();
        }

        private void exitButton_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                Application.Current.Shutdown();
        }

        private void userbox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                CreateUser();
        }

        public int GetHighestBound { get => UseOutline ? 7 : 8; }
        public int GetLowestBound { get => UseOutline ? 1 : 0; }

        bool increased = false;
        private int moves = 0;

        private void MapsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TotalMovement = 0;
            if (MapsComboBox.SelectedItem.ToString() == "None")
            {
                RemovePathBoxes();
                RemoveOrangeBoxes();
            }
            else
            {
                RemovePathBoxes();
                RemoveOrangeBoxes();
                foreach (var item in MapsList)
                {
                    if (item.Key == MapsComboBox.SelectedItem.ToString())
                    {
                        foreach (Point xys in item.Value)
                        {
                            table[((int)xys.X), ((int)xys.Y)].Style = OrangeBox;
                        }
                    }
                }
                CreateUser();
            }
        }

        public int TotalMovement
        {
            get => moves;
            set
            {
                moves = value;
                TotalMovesLabel.Content = "Moves " + moves;
            }
        }

        void UserBoxMoved()
        {
            TotalMovement += 1;
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            increased = false;
            if (e.Key == Key.D || e.Key == Key.Right)
            {
                for (int i = Grid.GetColumn(User); i < GetHighestBound; i++)
                {
                    if (table[i + 1, Grid.GetRow(User)].Style != OrangeBox)
                    {
                        table[i + 1, Grid.GetRow(User)].Style = UserBox;
                        table[i, Grid.GetRow(User)].Style = PathBox;
                        if (!increased)
                        {
                            UserBoxMoved();
                            increased = true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (e.Key == Key.A || e.Key == Key.Left)
            {
                for (int i = Grid.GetColumn(User); i > GetLowestBound; i--)
                {
                    if (table[i - 1, Grid.GetRow(User)].Style != OrangeBox)
                    {
                        table[i - 1, Grid.GetRow(User)].Style = UserBox;
                        table[i, Grid.GetRow(User)].Style = PathBox;
                        if (!increased)
                        {
                            UserBoxMoved();
                            increased = true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (e.Key == Key.W || e.Key == Key.Up)
            {
                for (int i = Grid.GetRow(User); i > GetLowestBound; i--)
                {
                    if (table[Grid.GetColumn(User), i - 1].Style != OrangeBox)
                    {
                        table[Grid.GetColumn(User), i - 1].Style = UserBox;
                        table[Grid.GetColumn(User), i].Style = PathBox;
                        if (!increased)
                        {
                            UserBoxMoved();
                            increased = true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (e.Key == Key.S || e.Key == Key.Down)
            {
                for (int i = Grid.GetRow(User); i < GetHighestBound; i++)
                {
                    if (table[Grid.GetColumn(User), i + 1].Style != OrangeBox)
                    {
                        table[Grid.GetColumn(User), i + 1].Style = UserBox;
                        table[Grid.GetColumn(User), i].Style = PathBox;
                        if (!increased)
                        {
                            UserBoxMoved();
                            increased = true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
