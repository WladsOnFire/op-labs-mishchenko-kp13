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
using System.IO;
using System.Collections.Generic;

namespace Prac01
{
    /// <summary>
    /// Логика взаимодействия для Learn.xaml
    /// </summary>
    public partial class Learn : Window
    {
        public Learn()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //exit
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        static Random rnd = new Random();
        static bool isLearning = false;
        static int countKeys = 0;
        private void GenerateBT_Click(object sender, RoutedEventArgs e)
        {
            string alphabet1 = "bcdfghjklmnpqrstvwxz";
            string alphabet2 = "aeiouy";
            int keyLettersAmmount = rnd.Next(5, 8);
            string keyWord = "";
            StreamWriter sw = new StreamWriter("keyword.txt");

            for(int i=0; i<keyLettersAmmount/2; i++)
            {
                keyWord += "" + alphabet1[rnd.Next(0, 20)];
                keyWord += "" + alphabet2[rnd.Next(0, 6)];
            }
                

            KeyWordTB.Text = keyWord;
            sw.WriteLine(keyWord);
            sw.Close();
            LearnKeyWordTB.IsEnabled = true;
        }
        
        
        private void LearnKeyWordTB_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            
            
        }
    }
}
