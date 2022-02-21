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
using System.Diagnostics;

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

  
        private void GenerateBT_Click(object sender, RoutedEventArgs e)
        {
            string alphabet1 = "bcdfghjklmnpqrstvwxz";
            string alphabet2 = "aeiouy";
            int keyLettersAmmount = rnd.Next(6, 10);
            string keyWord = "";
            StreamWriter sw = new StreamWriter("keyword.txt");

            for(int i=0; i<keyLettersAmmount/2; i++)
            {
                keyWord += "" + alphabet1[rnd.Next(0, 20)];
                keyWord += "" + alphabet2[rnd.Next(0, 6)];
            }

            keyWord = keyWord.ToUpper();
            KeyWordTB.Text = keyWord;
            sw.WriteLine(keyWord);
            sw.Close();
            LearnKeyWordTB.IsEnabled = true;
        }

        static Stopwatch stopWatch = new Stopwatch();
        static StreamWriter sw = new StreamWriter("sample.txt");
        static int attempts = 0;
        static int currentAttempt = 0;
        private void LearnKeyWordTB_KeyDown(object sender, KeyEventArgs e)
        {
            attempts = AttemptsCB.SelectedIndex + 5;
            e.Handled = true;
            GenerateBT.IsEnabled = false;
            AttemptsCB.IsEnabled = false;
            if (countKeys != KeyWordTB.Text.Length)
            {
                if (e.Key.ToString() == "" + KeyWordTB.Text[countKeys])
                {
                    if (countKeys != 0)
                    {
                        stopWatch.Stop();
                        TimeSpan ts = stopWatch.Elapsed;
                        stopWatch.Reset();
                        if (countKeys != KeyWordTB.Text.Length-1)
                            sw.Write(ts.Seconds + ts.Milliseconds / 1000.0 + " ");
                        else sw.Write(ts.Seconds + ts.Milliseconds / 1000.0);
                    }

                    stopWatch.Start();
                    LearnKeyWordTB.Text += e.Key.ToString();
                    countKeys++;
                    LearnKeyWordTB.SelectionStart = LearnKeyWordTB.Text.Length;
                }
            }
            if (countKeys == KeyWordTB.Text.Length)
            {
                LearnKeyWordTB.Text = "";
                countKeys = 0;
                sw.WriteLine();
                currentAttempt++;
                stopWatch.Reset();
                if (currentAttempt == attempts)
                {
                    sw.Close();
                    LearnKeyWordTB.IsEnabled = false;
                    LearnKeyWordTB.Text = "finished learning";
                }
            }
            

        }

        static Random rnd = new Random();
        static int countKeys = 0;
 
    }
}
