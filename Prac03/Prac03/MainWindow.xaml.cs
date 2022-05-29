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

namespace Prac03
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

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminModeWin AdminWindow = new AdminModeWin(this);
            AdminWindow.Show();
            this.Hide();
        }

        private void UserBtn_Click(object sender, RoutedEventArgs e)
        {
            UserModeWin UserWindow = new UserModeWin(this);
            UserWindow.Show();
            this.Hide();
        }

        private void InfoBtn_Click(object sender, RoutedEventArgs e)
        {
            InfoWin InfoWindow = new InfoWin(this);
            InfoWindow.Show();
            this.Hide();
        }
    }
}
