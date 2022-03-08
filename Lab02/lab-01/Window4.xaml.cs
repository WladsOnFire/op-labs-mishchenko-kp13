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
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
            InitializeControls();
        }
        private void InitializeControls()
        {
            this.ResizeMode = ResizeMode.CanMinimize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = "Info";

            Button BackBtn = new Button();
            BackBtn.Height = 50;
            BackBtn.Width = 200;
            BackBtn.Content = "Back";
            BackBtn.Click += Button_Click;
            BackBtn.Margin = new Thickness(250, 300, 0, 0);

            LinearGradientBrush brush = new LinearGradientBrush();
            brush.EndPoint = new Point(0.5, 1);
            brush.StartPoint = new Point(0.5, 0);
            brush.GradientStops.Add(new GradientStop(Colors.White, 0));
            brush.GradientStops.Add(new GradientStop(Colors.Pink, 1));
            this.Background = brush;

            Grid myGrid = new Grid();

            Image image = new Image();
            image.HorizontalAlignment = HorizontalAlignment.Left;
            image.Height = 275;
            image.Width = 183;
            image.Source = new BitmapImage(new Uri("info.jpg", UriKind.Relative));
            image.VerticalAlignment = VerticalAlignment.Top;
            image.Margin = new Thickness(50, 50, 0, 0);

            TextBlock txt = new TextBlock();
            txt.HorizontalAlignment = HorizontalAlignment.Left;
            txt.VerticalAlignment = VerticalAlignment.Top;
            txt.Height = 132;
            txt.Width = 272;
            txt.TextWrapping = TextWrapping.Wrap;
            txt.Text = "Виконав Міщенко Владислав Романович, студент групи КП-13, КПІ 2022";
            txt.FontFamily = new FontFamily("Arial");
            txt.FontSize = 24;
            txt.Margin = new Thickness(250, 50, 0, 0);

            myGrid.Children.Add(image);
            myGrid.Children.Add(txt);
            myGrid.Children.Add(BackBtn);

            this.Content = myGrid;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Visibility = Visibility.Visible;
            Close();
        }
    }
}
