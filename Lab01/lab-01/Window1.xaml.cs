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

namespace lab_01
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Visibility = Visibility.Visible;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> lines = new List<string>();
                StreamReader sr = new StreamReader("data.txt");
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine());
                }
                sr.Close();

                StreamWriter sw = new StreamWriter("data.txt", false, System.Text.Encoding.Default);
                
                foreach(string line in lines)
                {
                    string[] split = line.Split(' ');
                    if (split[3] != DN.Text) sw.WriteLine(line);
                }

                sw.Close();
                DN.Text = "";
                DButton.IsEnabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (DN.Text == "")
                DButton.IsEnabled = false;
            else DButton.IsEnabled = true;

            if (Name.Text == "" || Surname.Text == "" || Father.Text == "" || N.Text == "")
                AButton.IsEnabled = false;
            else AButton.IsEnabled = true;
        }

        private void AButton_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("data.txt", true, System.Text.Encoding.Default);
            sw.WriteLine(Surname.Text + " " + Name.Text + " " + Father.Text + " " + N.Text);
            sw.Close();
            Surname.Text = "";
            Name.Text = "";
            Father.Text = "";
            N.Text = "";
            AButton.IsEnabled = false;
        }
    }
}
