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
                         if ((net[i, j] == net[i+1, j]) && (net[1, j] == net[i+2, j]))
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
                if ((net[0,2] == net[1,1]) && (net[1,1] == net[2, 0]))
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
                    L1.Content = "DRAW!";
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
                    L1.Content = "'Cross' player won!";
                    isEndOfTheGame = true;
                }
                if (val == 2)
                {
                    L1.Content = "'Circle' player won!";
                    isEndOfTheGame = true;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
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


        private void r1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[0,0] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[0, 0] = 1;
                    zero = true;
                    r1.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[0, 0] = 2;
                    zero = false;
                    r1.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
                checkWhoWon(net);
            }
            
        }

        private void r2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[0, 1] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[0, 1] = 1;
                    zero = true;
                    r2.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[0, 1] = 2;
                    zero = false;
                    r2.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
                checkWhoWon(net);
            }
        }

        private void r3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[0, 2] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[0, 2] = 1;
                    zero = true;
                    r3.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[0, 2] = 2;
                    zero = false;
                    r3.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
                checkWhoWon(net);
            }
        }

        private void r4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[1, 0] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[1, 0] = 1;
                    zero = true;
                    r4.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[1, 0] = 2;
                    zero = false;
                    r4.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
                checkWhoWon(net);
            }
        }

        private void r5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[1, 1] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[1, 1] = 1;
                    zero = true;
                    r5.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[1, 1] = 2;
                    zero = false;
                    r5.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
                checkWhoWon(net);
            }
        }

        private void r6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[1, 2] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[1, 2] = 1;
                    zero = true;
                    r6.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[1, 2] = 2;
                    zero = false;
                    r6.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
                checkWhoWon(net);
            }
        }

        private void r7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[2, 0] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[2, 0] = 1;
                    zero = true;
                    r7.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[2, 0] = 2;
                    zero = false;
                    r7.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

        private void r8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[2, 1] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[2, 1] = 1;
                    zero = true;
                    r8.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[2, 1] = 2;
                    zero = false;
                    r8.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

        private void r9_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[2, 2] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[2, 2] = 1;
                    zero = true;
                    r9.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[2, 2] = 2;
                    zero = false;
                    r9.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

        private void r10_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[0, 3] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[0, 3] = 1;
                    zero = true;
                    r10.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[0, 3] = 2;
                    zero = false;
                    r10.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

        private void r11_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[1, 3] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[1, 3] = 1;
                    zero = true;
                    r11.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[1, 3] = 2;
                    zero = false;
                    r11.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

        private void r12_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[2, 3] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[2, 3] = 1;
                    zero = true;
                    r12.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[2, 3] = 2;
                    zero = false;
                    r12.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

        private void r13_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[3, 0] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[3, 0] = 1;
                    zero = true;
                    r13.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[3, 0] = 2;
                    zero = false;
                    r13.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

        private void r14_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[3, 1] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[3, 1] = 1;
                    zero = true;
                    r14.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[3, 1] = 2;
                    zero = false;
                    r14.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

        private void r15_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[3, 2] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[3, 2] = 1;
                    zero = true;
                    r15.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[3, 2] = 2;
                    zero = false;
                    r15.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

        private void r16_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[3, 3] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[3, 3] = 1;
                    zero = true;
                    r16.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[3, 3] = 2;
                    zero = false;
                    r16.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

        private void r17_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[4, 0] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[4, 0] = 1;
                    zero = true;
                    r17.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[4, 0] = 2;
                    zero = false;
                    r17.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

        private void r18_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[4, 1] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[4, 1] = 1;
                    zero = true;
                    r18.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[4, 1] = 2;
                    zero = false;
                    r18.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

        private void r19_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[4, 2] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[4, 2] = 1;
                    zero = true;
                    r19.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[4, 2] = 2;
                    zero = false;
                    r19.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

        private void r20_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[4, 3] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[2, 2] = 1;
                    zero = true;
                    r20.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[4, 3] = 2;
                    zero = false;
                    r20.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

        private void r21_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[0, 4] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[0, 4] = 1;
                    zero = true;
                    r21.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[0, 4] = 2;
                    zero = false;
                    r21.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

        private void r22_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[1, 4] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[1, 4] = 1;
                    zero = true;
                    r22.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[1, 4] = 2;
                    zero = false;
                    r22.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

        private void r23_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[2, 4] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[2, 4] = 1;
                    zero = true;
                    r23.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[2, 4] = 2;
                    zero = false;
                    r23.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

        private void r24_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[3, 4] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[3, 4] = 1;
                    zero = true;
                    r24.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[3, 4] = 2;
                    zero = false;
                    r24.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }

        private void r25_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (net[4, 4] == 0 && !isEndOfTheGame)
            {
                if (zero == false)
                {
                    net[4, 4] = 1;
                    zero = true;
                    r25.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("x.png", UriKind.Relative))
                    };
                }
                else
                {
                    net[4, 4] = 2;
                    zero = false;
                    r25.Fill = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("z.png", UriKind.Relative))
                    };
                }
            }
            checkWhoWon(net);
        }
    }
}
