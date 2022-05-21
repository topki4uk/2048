using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace _2048
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    class Coords
    {
        public int x, y, num;
        
        public Coords(int num, int x, int y)
        {
            this.num=num;
            this.x = x;
            this.y = y;
        }

        public Coords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public partial class MainWindow : Window
    {
        //List<block> blocks = new List<block>();
        List<int> nums = new List<int> { 1, 3, 5, 7};
        List<Coords> lst = new List<Coords>();
        List<List<int>> matrix = new List<List<int>>{
            new  List<int>() { -1, -1, -1, -1 },
            new List<int>() { -1, -1, -1, -1 },
            new List<int>() { -1, -1, -1, -1 },
            new List<int>() { -1, -1, -1, -1 }
            };

       private List<Coords> vacancies()
        {
            List<Coords> list = new List<Coords>();
            for (int i = 0; i < matrix.Count; ++i)
            {
                for (int j = 0; j < matrix[i].Count; ++j)
                {
                    if (matrix[i][j] == -1)
                    {
                        list.Add(new Coords(2*j+1, 2 * i + 1));
                    } 
                }
            }
            return list;
        }

        private void Append()
        {
            //blocks = new List<block>();
            block b = Create();
            if (lst.Count > 0) grid.Children.Add(b);
            GetCoords();
        }
        private void GetCoords()
        {
            matrix = new List<List<int>>() {
            new  List<int>() { -1, -1, -1, -1 },
            new List<int>() { -1, -1, -1, -1 },
            new List<int>() { -1, -1, -1, -1 },
            new List<int>() { -1, -1, -1, -1 }
            };
            for (int i = 1; i < grid.Children.Count; i++)
            {
                matrix[Grid.GetRow(grid.Children[i]) / 2][Grid.GetColumn(grid.Children[i])/2] = i;
            }

            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    //Console.Write(matrix[i][j]+" ");
                }
                //Console.WriteLine();
            }
        }
        private List<Coords> GetX(List<Coords> list, int y)
        {
            List<Coords> list_x = new List<Coords>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].y == y) list_x.Add(list[i]);
            }
            return list_x;
        }
        private List<int> GetY(List<Coords> list, int x)
        {
            List<int> list_y = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].x == x) list_y.Add(list[i].y);
            }
            return list_y;
        }
        private block Create()
        {
            block b = new block() { };
            //b.txt.Text = (grid.Children.Count-1).ToString();

            Random random = new Random();
            lst = vacancies();
            Trace.WriteLine(lst.Count);
            if (lst.Count != 0) {
            Coords coords = lst[random.Next(0, lst.Count-1)];
            //Coords coords = new Coords(nums[random.Next(0, 4)], nums[random.Next(0, 4)]);

            Grid.SetColumn(b, coords.x);
            Grid.SetRow(b, coords.y);
            return b;
            }
            return null;
        }
        public MainWindow()
        {
            InitializeComponent();
            Append();
        }

        private void GetColor(block b)
        {
            if (b.txt.Text == "4")
            {
                b.color.Fill = new SolidColorBrush(Color.FromRgb(236, 224, 201));
                b.color.Stroke = new SolidColorBrush(Color.FromRgb(236, 224, 201));
            }
            if (b.txt.Text == "8")
            {
                b.color.Fill = new SolidColorBrush(Color.FromRgb(242, 177, 121));
                b.color.Stroke = new SolidColorBrush(Color.FromRgb(242, 177, 121));
            }
            if (b.txt.Text == "16")
            {
                b.color.Fill = new SolidColorBrush(Color.FromRgb(245, 149, 99));
                b.color.Stroke = new SolidColorBrush(Color.FromRgb(245, 149, 99));
            }
            if (b.txt.Text == "32")
            {
                b.color.Fill = new SolidColorBrush(Color.FromRgb(242, 124, 95));
                b.color.Stroke = new SolidColorBrush(Color.FromRgb(242, 124, 95));
            }
            if (b.txt.Text == "64")
            {
                b.color.Fill = new SolidColorBrush(Color.FromRgb(244, 95, 58));
                b.color.Stroke = new SolidColorBrush(Color.FromRgb(244, 95, 58));
            }
            if (b.txt.Text == "128")
            {
                b.color.Fill = new SolidColorBrush(Color.FromRgb(235, 207, 116));
                b.color.Stroke = new SolidColorBrush(Color.FromRgb(235, 207, 116));
            }
            if (b.txt.Text == "256")
            {
                b.color.Fill = new SolidColorBrush(Color.FromRgb(237, 204, 97));
                b.color.Stroke = new SolidColorBrush(Color.FromRgb(237, 204, 97));
            }
            if (b.txt.Text == "512")
            {
                b.color.Fill = new SolidColorBrush(Color.FromRgb(236, 200, 80));
                b.color.Stroke = new SolidColorBrush(Color.FromRgb(236, 200, 80));
            }
            if (b.txt.Text == "1024")
            {
                b.color.Fill = new SolidColorBrush(Color.FromRgb(237, 197, 65));
                b.color.Stroke = new SolidColorBrush(Color.FromRgb(237, 197, 65));
            }
            if (b.txt.Text == "2048")
            {
                b.color.Fill = new SolidColorBrush(Color.FromRgb(238, 194, 46));
                b.color.Stroke = new SolidColorBrush(Color.FromRgb(238, 194, 46));
            }
        }

        private void GoRight()
        {
            
            //Trace.Write(matrix.Count);
            for (int k = 0; k < 4; k++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (matrix[i][j] != -1 &&  matrix[i][j+1] == -1) {
                            matrix[i][j + 1] = matrix[i][j];
                            matrix[i][j] = -1;
                            
                        }

                        if (matrix[i][j] != -1 && matrix[i][j + 1] != -1)
                        {
                            block p1 = (block)grid.Children[matrix[i][j]];
                            block p2 = (block)grid.Children[matrix[i][j + 1]];

                            if (p1.txt.Text == p2.txt.Text && matrix[i][j+1] != -1)
                            {
                                block b = new block();
                                b.txt.Text = Convert.ToString(2 * Convert.ToInt16(p1.txt.Text));
                                if (b.txt.Text.Length == 3) b.txt.FontSize = 48;
                                if (b.txt.Text.Length == 4) b.txt.FontSize = 36;
                                grid.Children.RemoveAt(matrix[i][j]);
                                if (matrix[i][j] > matrix[i][j+1]) grid.Children.RemoveAt(matrix[i][j + 1]);
                                else grid.Children.RemoveAt(matrix[i][j + 1]-1);

                                GetColor(b);

                                grid.Children.Add(b);
                                Grid.SetColumn(b, 2 * j + 1);
                                Grid.SetRow(b, 2 * i + 1);
                                
                                GetCoords();
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < 16; i++)
            {
                if (matrix[i / 4][i % 4] != -1) Grid.SetColumn(grid.Children[matrix[i / 4][i % 4]], nums[i%4]);
            }
        }
        //if (Find_X(list_x, (nums[i+1])) != -1) Grid.SetColumn(blocks[list_x[Find_X(list_x, nums[i])].num], (nums[i+1]));

        private void goLeft()
        {
            for (int k = 0; k < 4; k++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (matrix[i][j] == -1 && matrix[i][j + 1] != -1)
                        {
                            matrix[i][j] = matrix[i][j+1];
                            matrix[i][j+1] = -1;
                        }

                        if (matrix[i][j] != -1 && matrix[i][j + 1] != -1)
                        {
                            block p1 = (block)grid.Children[matrix[i][j]];
                            block p2 = (block)grid.Children[matrix[i][j + 1]];

                            if (p1.txt.Text == p2.txt.Text && matrix[i][j] != -1)
                            {
                                block b = new block();
                                b.txt.Text = Convert.ToString(2 * Convert.ToInt16(p1.txt.Text));
                                if (b.txt.Text.Length == 3) b.txt.FontSize = 48;
                                if (b.txt.Text.Length == 4) b.txt.FontSize = 36;

                                grid.Children.RemoveAt(matrix[i][j]);
                                if (matrix[i][j] > matrix[i][j + 1]) grid.Children.RemoveAt(matrix[i][j + 1]);
                                else grid.Children.RemoveAt(matrix[i][j + 1] - 1);

                                GetColor(b);

                                grid.Children.Add(b);
                                Grid.SetColumn(b, 2 * j + 1);
                                Grid.SetRow(b, 2 * i + 1);

                                GetCoords();
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < 16; i++)
            {
                if (matrix[i / 4][i % 4] != -1) Grid.SetColumn(grid.Children[matrix[i / 4][i % 4]], nums[i % 4]);
            }
        }
       private void goUp()
        {
            for (int k = 0; k < 4; k++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (matrix[i][j] == -1 && matrix[i+1][j] != -1)
                        {
                            matrix[i][j] = matrix[i+1][j];
                            matrix[i+1][j] = -1;
                        }

                        if (matrix[i][j] != -1 && matrix[i+1][j] != -1)
                        {
                            block p1 = (block)grid.Children[matrix[i][j]];
                            block p2 = (block)grid.Children[matrix[i+1][j]];

                            if (p1.txt.Text == p2.txt.Text && matrix[i][j] != -1)
                            {
                                block b = new block();
                                b.txt.Text = Convert.ToString(2 * Convert.ToInt16(p1.txt.Text));
                                if (b.txt.Text.Length == 3) b.txt.FontSize = 48;
                                if (b.txt.Text.Length == 4) b.txt.FontSize = 36;

                                grid.Children.RemoveAt(matrix[i][j]);
                                if (matrix[i][j] > matrix[i+1][j]) grid.Children.RemoveAt(matrix[i+1][j]);
                                else grid.Children.RemoveAt(matrix[i+1][j] - 1);

                                GetColor(b);

                                grid.Children.Add(b);
                                Grid.SetColumn(b, 2 * j + 1);
                                Grid.SetRow(b, 2 * i + 1);

                                GetCoords();
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < 16; i++)
            {
                if (matrix[i / 4][i % 4] != -1) Grid.SetRow(grid.Children[matrix[i / 4][i % 4]], nums[i / 4]);
            }
        }
        private void goDown()
        {
            for (int k = 0; k < 4; k++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (matrix[i][j] != -1 && matrix[i + 1][j] == -1)
                        {
                            matrix[i+1][j] = matrix[i][j];
                            matrix[i][j] = -1;
                        }

                        if (matrix[i][j] != -1 && matrix[i + 1][j] != -1)
                        {
                            block p1 = (block)grid.Children[matrix[i][j]];
                            block p2 = (block)grid.Children[matrix[i + 1][j]];

                            if (p1.txt.Text == p2.txt.Text && matrix[i][j] != -1)
                            {
                                block b = new block();
                                b.txt.Text = Convert.ToString(2 * Convert.ToInt16(p1.txt.Text));
                                if (b.txt.Text.Length == 3) b.txt.FontSize = 48;
                                if (b.txt.Text.Length == 4) b.txt.FontSize = 36;

                                grid.Children.RemoveAt(matrix[i][j]);
                                if (matrix[i][j] > matrix[i+1][j]) grid.Children.RemoveAt(matrix[i+1][j]);
                                else grid.Children.RemoveAt(matrix[i+1][j] - 1);

                                GetColor(b);

                                grid.Children.Add(b);
                                Grid.SetColumn(b, 2 * j + 1);
                                Grid.SetRow(b, 2 * i + 1);

                                GetCoords();
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < 16; i++)
            {
                if (matrix[i / 4][i % 4] != -1) Grid.SetRow(grid.Children[matrix[i / 4][i % 4]], nums[i / 4]);
            }
        }
        
        /*private bool ISEmpty(Coords coords)
        {
            for (int i = 0; i < current_coords.Count; i++)
            {
                if (current_coords[i].x == coords.x && current_coords[i].y == coords.y) return false;
            }
            return true;
        }*/

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D) GoRight();
            if (e.Key == Key.A) goLeft();
            if (e.Key == Key.W) goUp();
            if (e.Key == Key.S) goDown();
            Append();
        }
    }
}
