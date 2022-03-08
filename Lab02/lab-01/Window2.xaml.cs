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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab_01
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            InitializeControls();
        }

        Label ResultLb = new Label();
        private void InitializeControls()
        {
            this.ResizeMode = ResizeMode.CanMinimize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = "Tic-Tac-Toe";

            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();
            myLinearGradientBrush.StartPoint = new Point(0.5, 0);
            myLinearGradientBrush.EndPoint = new Point(0.5, 1);
            myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.LimeGreen, 1));
            myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.GhostWhite, 0));
            this.Background = myLinearGradientBrush;

            Button BackBtn = new Button();
            BackBtn.Content = "Back";
            BackBtn.Height = 50;
            BackBtn.Width = 150;
            BackBtn.Click += Exit;



            ResultLb.Content = "";
            ResultLb.FontSize = 26;
            int M = 7, N = 5;
            Grid MyGrid = new Grid();
            MyGrid.HorizontalAlignment = HorizontalAlignment.Center;
            MyGrid.VerticalAlignment = VerticalAlignment.Center;
            //MyGrid.ShowGridLines = true;
            MyGrid.Margin = new Thickness(15, 15, 15, 15);

            RowDefinition[] rows = new RowDefinition[M];
            ColumnDefinition[] cols = new ColumnDefinition[N];
            Rectangle[,] ArrBtn = new Rectangle[N,N];


            LinearGradientBrush RectangleLinearGradientBrush = new LinearGradientBrush();
            RectangleLinearGradientBrush.StartPoint = new Point(0.5, 0);
            RectangleLinearGradientBrush.EndPoint = new Point(0.5, 1);
            RectangleLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.LimeGreen, 1));
            RectangleLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.GhostWhite, 0));


            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    ArrBtn[i, j] = new Rectangle();
                    ArrBtn[i, j].MouseLeftButtonDown += GameButton_Click;
                    ArrBtn[i, j].Height = 50;
                    ArrBtn[i, j].Width = 50;
                    ArrBtn[i, j].Stroke = Brushes.Black;
                    ArrBtn[i, j].Fill = RectangleLinearGradientBrush;
                    ArrBtn[i, j].Name = "r" + i + "" + j; 
                }

            for (int i = 0; i < M; i++)
            {
                rows[i] = new RowDefinition();
                MyGrid.RowDefinitions.Add(rows[i]);
            }
            for (int i = 0; i < N; i++)
            {
                cols[i] = new ColumnDefinition();
                MyGrid.ColumnDefinitions.Add(cols[i]);
            }

            Grid.SetRow(ResultLb, 0);
            Grid.SetColumn(ResultLb, 0);
            Grid.SetColumnSpan(ResultLb, 5);
            MyGrid.Children.Add(ResultLb);

            for (int i = 1; i <= N; i++)
                for (int j = 0; j < N; j++)
                {
                    Grid.SetRow(ArrBtn[i-1, j], i);
                    Grid.SetColumn(ArrBtn[i-1, j], j);
                    MyGrid.Children.Add(ArrBtn[i-1, j]);
                }

            Grid.SetRow(BackBtn, 6);
            Grid.SetColumn(BackBtn, 2);
            Grid.SetColumnSpan(BackBtn, 3);
            MyGrid.Children.Add(BackBtn);

            this.Content = MyGrid;
        }



        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Visibility = Visibility.Visible;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    net[i, j] = 0;

            zero = false;
            isEndOfTheGame = false;
            Close();
        }


        static int[,] net = { { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
        static bool zero = false;

        static bool isEndOfTheGame = false;
        public void checkWhoWon(int[,] net)
        {
            if(!isEndOfTheGame)
            for (int i = 0; i < 5; i++)
                    for (int j =0; j<3; j++)
                    if ((net[i, j] == net[i, j+1]) && (net[i, j+1] == net[i, j+2]))
                        winner(net[i, j], net);

            if (!isEndOfTheGame)
                for(int i = 0; i<3; i++)
                    for (int j = 0; j < 5; j++)
                         if ((net[i, j] == net[i+1, j]) && (net[i+1, j] == net[i+2, j]))
                             winner(net[i, j], net);

            if (!isEndOfTheGame)
                for(int i =0; i<3; i++)
                {
                    for(int j=0; j<3; j++)
                    {
                        if (net[i, j] == net[i + 1, j + 1] && net[i + 1, j + 1] == net[i + 2, j + 2])
                            winner(net[i, j], net);
                    }
                }
                    

            if (!isEndOfTheGame)
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 4; j >=2; j--)
                        {
                            if (net[i, j] == net[i + 1, j - 1] && net[i + 1, j - 1] == net[i + 2, j - 2])
                                winner(net[i, j], net);
                        }
                    }


            if (!isEndOfTheGame)
            {
                int nulls = 0;
                foreach (int value in net)
                {
                    if (value == 0) nulls++;
                }

                if (nulls == 0)
                {
                    ResultLb.Content = "DRAW!";
                    isEndOfTheGame = true;
                }
            }
                

            void winner(int val, int[,]neeeet)
            {
                if (val == 0) 
                {
                    
                }
                if (val == 1) 
                {
                    ResultLb.Content = "'Cross' player won!";
                    isEndOfTheGame = true;
                }
                if (val == 2)
                {
                    ResultLb.Content = "'Circle' player won!";
                    isEndOfTheGame = true;
                }
            }
        }



        

        private void GameButton_Click(object sender, MouseButtonEventArgs e)
        {
            Rectangle GameButton = (Rectangle)sender;
            int I; int J;
            I = int.Parse("" + GameButton.Name[1]);
            J = int.Parse("" + GameButton.Name[2]);
            if (net[I, J] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[I, J] = 1;
                    zero = true;
                    GameButton.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[I, J] = 2;
                    zero = false;
                    GameButton.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

    }
}
