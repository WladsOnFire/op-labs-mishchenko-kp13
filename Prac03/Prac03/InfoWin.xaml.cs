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

namespace Prac03
{
    /// <summary>
    /// Логика взаимодействия для InfoWin.xaml
    /// </summary>
    public partial class InfoWin : Window
    {
        MainWindow MainWin;
        public InfoWin(MainWindow mw)
        {
            InitializeComponent();
            MainWin = mw;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWin.Show();
        }
    }
}
