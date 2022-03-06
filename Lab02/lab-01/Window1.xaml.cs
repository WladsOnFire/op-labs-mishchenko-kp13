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
using System.Drawing;

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
            initControls();
        }
        Button AButton = new Button();
        Button DButton = new Button();
        private void initControls()
        {
            this.ResizeMode = ResizeMode.CanMinimize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.KeyUp += Window_KeyUp;
            this.Title = "Student's data";

            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();
            myLinearGradientBrush.StartPoint = new Point(0.5, 0);
            myLinearGradientBrush.EndPoint = new Point(0.5, 1);
            myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.OrangeRed, 1));
            myLinearGradientBrush.GradientStops.Add(new GradientStop(Colors.AliceBlue, 0));
            this.Background = myLinearGradientBrush;


            Grid myGrid = new Grid();
            myGrid.Width = 580;
            myGrid.Height = 640;
            myGrid.ShowGridLines = true;
            
            Button BackBtn = new Button();
            BackBtn.Content = "Back";
            BackBtn.HorizontalAlignment = HorizontalAlignment.Right;
            BackBtn.VerticalAlignment = VerticalAlignment.Top;
            BackBtn.Height = 50;
            BackBtn.Width = 200;
            BackBtn.Margin = new Thickness(0, 370, 0, 0);
            BackBtn.Click += Button_Click_Exit;

            
            AButton.Content = "Add";
            AButton.HorizontalAlignment = HorizontalAlignment.Left;
            AButton.VerticalAlignment = VerticalAlignment.Top;
            AButton.Height = 36;
            AButton.Width = 154;
            AButton.IsEnabled = false;
            AButton.Margin = new Thickness(143, 232, 0, 0);
            AButton.Click += AButton_Click;


            DButton.Content = "Delete";
            DButton.HorizontalAlignment = HorizontalAlignment.Left;
            DButton.VerticalAlignment = VerticalAlignment.Top;
            DButton.Height = 36;
            DButton.Width = 154;
            DButton.IsEnabled = false;
            DButton.Margin = new Thickness(143, 382, 0, 0);
            DButton.Click += DButton_Click;


            Label label_1 = new Label();
            label_1.Content = "Прізвище";
            label_1.HorizontalAlignment = HorizontalAlignment.Left;
            label_1.VerticalAlignment = VerticalAlignment.Top;
            label_1.Margin = new Thickness(10, 56, 0, 0);
            label_1.FontSize = 16;
            label_1.FontWeight = FontWeights.Normal;
            label_1.FontFamily = new FontFamily("Arial Black");


            Label label_2 = new Label();
            label_2.Content = "Ім'я";
            label_2.HorizontalAlignment = HorizontalAlignment.Left;
            label_2.VerticalAlignment = VerticalAlignment.Top;
            label_2.Margin = new Thickness(10, 91, 0, 0);
            label_2.FontSize = 16;
            label_2.FontWeight = FontWeights.Normal;
            label_2.FontFamily = new FontFamily("Arial Black");


            Label label_3 = new Label();
            label_3.Content = "По-батькові";
            label_3.HorizontalAlignment = HorizontalAlignment.Left;
            label_3.VerticalAlignment = VerticalAlignment.Top;
            label_3.Margin = new Thickness(10, 131, 0, 0);
            label_3.FontSize = 16;
            label_3.FontWeight = FontWeights.Normal;
            label_3.FontFamily = new FontFamily("Arial Black");


            Label label_4 = new Label();
            label_4.Content = "Квиток №";
            label_4.HorizontalAlignment = HorizontalAlignment.Left;
            label_4.VerticalAlignment = VerticalAlignment.Top;
            label_4.Margin = new Thickness(10, 176, 0, 0);
            label_4.FontSize = 16;
            label_4.FontWeight = FontWeights.Normal;
            label_4.FontFamily = new FontFamily("Arial Black");


            Label label_5 = new Label();
            label_5.Content = "Видалення за студентським квитком";
            label_5.HorizontalAlignment = HorizontalAlignment.Left;
            label_5.VerticalAlignment = VerticalAlignment.Top;
            label_5.Margin = new Thickness(10, 302, 0, 0);
            label_5.FontSize = 16;
            label_5.FontWeight = FontWeights.Normal;
            label_5.FontFamily = new FontFamily("Arial Black");


            Surname.HorizontalAlignment = HorizontalAlignment.Left;
            Surname.VerticalAlignment = VerticalAlignment.Top;
            Surname.Width = 200;
            Surname.Height = 20;
            Surname.Margin = new Thickness(143, 60, 0, 0);
            Surname.Text = "";
            Surname.BorderBrush = Brushes.Black;


            Name.HorizontalAlignment = HorizontalAlignment.Left;
            Name.VerticalAlignment = VerticalAlignment.Top;
            Name.Width = 200;
            Name.Height = 20;
            Name.Margin = new Thickness(143, 100, 0, 0);
            Name.Text = "";
            Name.BorderBrush = Brushes.Black;


            Father.HorizontalAlignment = HorizontalAlignment.Left;
            Father.VerticalAlignment = VerticalAlignment.Top;
            Father.Width = 200;
            Father.Height = 20;
            Father.Margin = new Thickness(143, 140, 0, 0);
            Father.Text = "";
            Father.BorderBrush = Brushes.Black;

            N.HorizontalAlignment = HorizontalAlignment.Left;
            N.VerticalAlignment = VerticalAlignment.Top;
            N.Width = 200;
            N.Height = 20;
            N.Margin = new Thickness(143, 180, 0, 0);
            N.Text = "";
            N.BorderBrush = Brushes.Black;

            DN.HorizontalAlignment = HorizontalAlignment.Left;
            DN.VerticalAlignment = VerticalAlignment.Top;
            DN.Width = 200;
            DN.Height = 20;
            DN.Margin = new Thickness(143, 335, 0, 0);
            DN.Text = "";
            DN.BorderBrush = Brushes.Black;

            myGrid.Children.Add(BackBtn);
            myGrid.Children.Add(AButton);
            myGrid.Children.Add(DButton);
            myGrid.Children.Add(label_1);
            myGrid.Children.Add(label_2);
            myGrid.Children.Add(label_3);
            myGrid.Children.Add(label_4);
            myGrid.Children.Add(label_5);
            myGrid.Children.Add(Surname);
            myGrid.Children.Add(Name);
            myGrid.Children.Add(Father);
            myGrid.Children.Add(N);
            myGrid.Children.Add(DN);

            this.Content = myGrid;
        }

        TextBox Surname = new TextBox();
        TextBox Name = new TextBox();
        TextBox Father = new TextBox();
        TextBox N = new TextBox();
        TextBox DN = new TextBox();

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Visibility = Visibility.Visible;
            Close();
        }

        private void DButton_Click(object sender, RoutedEventArgs e)
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
