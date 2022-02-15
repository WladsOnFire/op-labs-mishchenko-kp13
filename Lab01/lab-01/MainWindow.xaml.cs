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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab_01
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            MainWindow mw = new MainWindow();
            Visibility = Visibility.Hidden;
            win1.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2();
            MainWindow mw = new MainWindow();
            Visibility = Visibility.Hidden;
            win2.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window3 win3 = new Window3();
            MainWindow mw = new MainWindow();
            Visibility = Visibility.Hidden;
            win3.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window4 win4 = new Window4();
            MainWindow mw = new MainWindow();
            Visibility = Visibility.Hidden;
            win4.Show();
        }
    }
}
