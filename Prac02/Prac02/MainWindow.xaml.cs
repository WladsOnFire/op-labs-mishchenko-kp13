using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prac02
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static double[] countDistances(int[,] citiesCoords, int[,] ways, int populationsAmnt)
        {
            double[] distances = new double[populationsAmnt * 2];

            for (int i = 0; i < populationsAmnt * 2; i++)
            {
                double a = 0;
                double b = 0;
                double distance = 0;
                for (int j = 0; j < citiesCoords.GetLength(0); j++)
                {
                    if (j != citiesCoords.GetLength(0) - 1)
                    {
                        a = Math.Abs(citiesCoords[ways[i, j], 0] - citiesCoords[ways[i, j + 1], 0]);
                        b = Math.Abs(citiesCoords[ways[i, j], 1] - citiesCoords[ways[i, j + 1], 1]);
                    }
                    else
                    {
                        a = Math.Abs(citiesCoords[ways[i, j], 0] - citiesCoords[ways[i, 0], 0]);
                        b = Math.Abs(citiesCoords[ways[i, j], 1] - citiesCoords[ways[i, 0], 1]);
                    }

                    double c = Math.Sqrt(a * a + b * b);
                    distance += c;
                }
                distances[i] = distance;
            }

            return distances;
        }
        static Random rnd = new Random();

        static Grid bufferGrid = new Grid();
        public void Draw (int[,] coords, int citiesAmnt, int[,] way)
        {
            Grid myGrid = new Grid();
            myGrid.Children.Remove(bufferGrid);
            bufferGrid.Children.Clear();
            Rectangle bg = new Rectangle();
            bg.Stroke = Brushes.Black;
            bg.Fill = Brushes.White;
            bg.HorizontalAlignment = HorizontalAlignment.Left;
            bg.VerticalAlignment = VerticalAlignment.Top;
            bg.Margin = new Thickness(300, 50, 0, 0);
            bg.Height = 400+13;
            bg.Width = 400+13;
            myGrid.Children.Add(bg);
            for (int i =0; i< citiesAmnt; i++)
            {
                Rectangle myRect = new Rectangle();
                myRect.Stroke = Brushes.Black;
                myRect.Fill = Brushes.SkyBlue;
                myRect.HorizontalAlignment = HorizontalAlignment.Left;
                myRect.VerticalAlignment = VerticalAlignment.Top;
                myRect.Margin = new Thickness(coords[i, 0]+300, coords[i, 1]+50, 0, 0);
                myRect.Height = 13;
                myRect.Width = 13;
                myGrid.Children.Add(myRect);
            }
            
            for(int i =0; i< citiesAmnt-1; i++)
            {
                Line myLine = new Line();
                myLine.Stroke = System.Windows.Media.Brushes.Red;
                myLine.X1 = coords[way[0,i], 0]+300+6;
                myLine.X2 = coords[way[0,i + 1], 0]+300+6;
                myLine.Y1 = coords[way[0,i], 1]+50+6;
                myLine.Y2 = coords[way[0,i + 1], 1]+50+6;
                myLine.HorizontalAlignment = HorizontalAlignment.Left;
                myLine.VerticalAlignment = VerticalAlignment.Top;
                myLine.StrokeThickness = 2;
                myGrid.Children.Add(myLine);
            }
            Line myLine2 = new Line();
            myLine2.Stroke = System.Windows.Media.Brushes.Red;
            myLine2.X1 = coords[way[0, citiesAmnt-1], 0] + 300 + 6;
            myLine2.X2 = coords[way[0, 0], 0] + 300 + 6;
            myLine2.Y1 = coords[way[0, citiesAmnt - 1], 1] + 50 + 6;
            myLine2.Y2 = coords[way[0, 0], 1] + 50 + 6;
            myLine2.HorizontalAlignment = HorizontalAlignment.Left;
            myLine2.VerticalAlignment = VerticalAlignment.Top;
            myLine2.StrokeThickness = 2;
            myGrid.Children.Add(myLine2);
         
            WindowGrid.Children.Add(myGrid);
            bufferGrid = myGrid;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            LaunchBt.IsEnabled = false;
            BreakBt.IsEnabled = true;
            int citiesAmt = int.Parse(citiesT.Text);
            int populationsAmt = int.Parse(populationsT.Text);
            int[,] ways = new int[populationsAmt * 2, citiesAmt];
            int[,] coords = new int[citiesAmt, 2];
            int iterations = int.Parse(iterationsT.Text);
            double mutationChance = double.Parse(mutationT.Text);

            for (int i = 0; i < citiesAmt; i++)
            {
                coords[i, 0] = rnd.Next(400);
                coords[i, 1] = rnd.Next(400);
            }
            

            for (int i = 0; i < populationsAmt; i++)
            {
                List<int> checkCities = new List<int>();
                for (int j = 0; j < citiesAmt; j++)
                {
                x1:
                    int bufferCity = rnd.Next(citiesAmt);
                    if (!checkCities.Contains(bufferCity))
                    {
                        checkCities.Add(bufferCity);
                        ways[i, j] = bufferCity;
                    }
                    else goto x1;
                }
            }

            ////////

            for (int it = 0; it < iterations; it++)
            {
                for (int m = 0; m < populationsAmt; m++)
                {
                    int chr1 = rnd.Next(populationsAmt);
                    int chr2 = rnd.Next(populationsAmt);
                    int crossoverPoint = 1 + rnd.Next(populationsAmt - 2);

                    int[] temp1 = new int[citiesAmt * 2];
                    int[] temp2 = new int[citiesAmt * 2];

                    for (int n = 0; n < citiesAmt; n++)
                    {
                        if (n <= crossoverPoint)
                        {
                            temp1[n] = ways[chr1, n];
                            temp2[n] = ways[chr2, n];
                        }
                        else
                        {
                            temp1[n] = ways[chr2, n];
                            temp2[n] = ways[chr1, n];
                        }
                    }

                    for (int k = citiesAmt; k < citiesAmt * 2; k++)
                    {
                        temp1[k] = temp2[k - citiesAmt];
                        temp2[k] = temp1[k - citiesAmt];
                    }

                    int[] temp3 = new int[citiesAmt];
                    int[] temp4 = new int[citiesAmt];

                    int l = 0;
                    int p = 0;
                    List<int> check1 = new List<int>();
                    List<int> check2 = new List<int>();

                    for (int z = 0; z < citiesAmt * 2; z++)
                    {
                        if (!check1.Contains(temp1[z]))
                        {
                            temp3[l] = temp1[z];
                            l++;
                            check1.Add(temp1[z]);
                        }

                        if (!check2.Contains(temp2[z]))
                        {
                            temp4[p] = temp2[z];
                            p++;
                            check2.Add(temp2[z]);
                        }
                    }

                    if (rnd.NextDouble() <= 0.5)
                        for (int o = 0; o < citiesAmt; o++)
                            ways[populationsAmt + m, o] = temp3[o];
                    else
                        for (int o = 0; o < citiesAmt; o++)
                            ways[populationsAmt + m, o] = temp4[o];

                    if (rnd.NextDouble() <= mutationChance)
                    {
                    x2:
                        int point1 = 1 + rnd.Next(citiesAmt - 2);
                        int point2 = 1 + rnd.Next(citiesAmt - 2);
                        if (point1 == point2) goto x2;

                        if (point1 > point2)
                        {
                            int buf = point1;
                            point1 = point2;
                            point2 = buf;
                        }

                        int[] array = new int[point2-point1 + 1];
                        int u = 0;
                        for (int f = 0; f < citiesAmt; f++)
                            if (f >= point1 && f <= point2)
                            {
                                array[u] = ways[populationsAmt + m, f];
                                u++;
                            }

                        Array.Reverse(array);

                        u = 0;
                        for (int f = 0; f < citiesAmt; f++)
                            if (f >= point1 && f <= point2)
                            {
                                ways[populationsAmt + m, f] = array[u];
                                u++;
                            }

                    }
                }

                double[] distances = countDistances(coords, ways, populationsAmt);

                bool swaped = true;
                while (swaped == true)
                {
                    swaped = false;
                    for (int i = 0; i < populationsAmt * 2 - 1; i++)
                    {
                        if (distances[i] > distances[i + 1])
                        {
                            double distBuf = distances[i];
                            distances[i] = distances[i + 1];
                            distances[i + 1] = distBuf;

                            int[] wayBuf = new int[citiesAmt];
                            for (int j = 0; j < citiesAmt; j++)
                            {
                                wayBuf[j] = ways[i, j];
                                ways[i, j] = ways[i + 1, j];
                                ways[i + 1, j] = wayBuf[j];
                            }

                            swaped = true;
                        }
                    }
                }


                

                if(it % 10 == 0)
                {
                    await Task.Delay(1);
                    if (BreakBt.IsEnabled == false)
                        break;
                    iter.Content = it;
                    dist.Content = distances[0];
                    Draw(coords, citiesAmt, ways);
                    await Task.Delay(1);
                }
                



                /* WriteLine("----------");
                 for (int i = 0; i < populationsAmt * 2; i++)
                     WriteLine(distances[i]);*/
                //WriteLine();
            }
            LaunchBt.IsEnabled = true;
            BreakBt.IsEnabled = false;
        
        }

        private void BreakBt_Click(object sender, RoutedEventArgs e)
        {
            BreakBt.IsEnabled = false;
            LaunchBt.IsEnabled = true;
        }
    }
}
