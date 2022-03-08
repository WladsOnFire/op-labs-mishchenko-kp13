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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            InitializeControls();
        }
        TextBox Output = new TextBox();
        private void InitializeControls()
        {
            this.ResizeMode = ResizeMode.CanMinimize;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = "Calculator";

            LinearGradientBrush brush = new LinearGradientBrush();
            brush.EndPoint = new Point(0.5, 1);
            brush.StartPoint = new Point(0.5, 0);
            brush.GradientStops.Add(new GradientStop(Colors.White, 0));
            brush.GradientStops.Add(new GradientStop(Colors.LightBlue, 1));

            this.Background = brush;

            Grid myGrid = new Grid();
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.Height = 400;
            myGrid.Width = 600;

            int I = 6;
            int J = 5;

            RowDefinition[] rows = new RowDefinition[I];
            ColumnDefinition[] cols = new ColumnDefinition[J];


            Button[,] ArrBtn = new Button[I-1, J-1];
            for (int i = 0; i < I-1; i++)
                for (int j = 0; j < J-1; j++)
                {
                    ArrBtn[i, j] = new Button();
                    ArrBtn[i, j].FontSize = 24;
                }

            for (int i = 0; i < I; i++)
            {
                rows[i] = new RowDefinition();
                myGrid.RowDefinitions.Add(rows[i]);
            }
            for (int i = 0; i < J; i++)
            {
                cols[i] = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(cols[i]);
            }
            for (int i = 0; i < I-1; i++)
                for (int j = 0; j < J-1; j++)
                {
                    if (!(i == 0 && j == 0))
                    {
                        Grid.SetRow(ArrBtn[i, j], i + 1);
                        Grid.SetColumn(ArrBtn[i, j], j);
                        myGrid.Children.Add(ArrBtn[i, j]);
                    }
                    
                }




            Button Back = new Button();
            Back.Content = "Back";
            Back.Click += Button_Click;
            Back.Margin = new Thickness(5, 0, 0, 0);
            Grid.SetRow(Back,I-1);
            Grid.SetColumn(Back,J-1);
            myGrid.Children.Add(Back);
            this.Content = myGrid;



            Output.IsReadOnly = true;
            Output.TextWrapping = TextWrapping.Wrap;
            Output.Text = "";
            Output.FontSize = 24;
            Output.Margin = new Thickness(0, 0, 0, 5);
            Grid.SetRow(Output, 0);
            Grid.SetColumn(Output, 0);
            Grid.SetColumnSpan(Output, 4);
            myGrid.Children.Add(Output);

            ArrBtn[0, 1].Content = "=";
            ArrBtn[0, 1].Click += Button_Click_16;

            ArrBtn[0, 2].Content = "C";
            ArrBtn[0, 2].Name = "C";
            ArrBtn[0, 2].Click += Button_Click_11;

            ArrBtn[0, 3].Content = "←";
            ArrBtn[0, 3].Click += Button_Click_13;

            ArrBtn[1, 0].Content = "7";
            ArrBtn[1, 0].Click += Button_Click_7;

            ArrBtn[1, 1].Content = "8";
            ArrBtn[1, 1].Click += Button_Click_8;

            ArrBtn[1, 2].Content = "9";
            ArrBtn[1, 2].Click += Button_Click_9;

            ArrBtn[1, 3].Content = "÷";
            ArrBtn[1, 3].Click += Button_Click_19;

            ArrBtn[2, 0].Content = "4";
            ArrBtn[2, 0].Click += Button_Click_4;

            ArrBtn[2, 1].Content = "5";
            ArrBtn[2, 1].Click += Button_Click_5;

            ArrBtn[2, 2].Content = "6";
            ArrBtn[2, 2].Click += Button_Click_6;

            ArrBtn[2, 3].Content = "x";
            ArrBtn[2, 3].Click += Button_Click_18;

            ArrBtn[3, 0].Content = "1";
            ArrBtn[3, 0].Click += Button_Click_1;

            ArrBtn[3, 1].Content = "2";
            ArrBtn[3, 1].Click += Button_Click_2;

            ArrBtn[3, 2].Content = "3";
            ArrBtn[3, 2].Click += Button_Click_3;

            ArrBtn[3, 3].Content = "-";
            ArrBtn[3, 3].Click += Button_Click_17;

            ArrBtn[4, 0].Content = "±";
            ArrBtn[4, 0].Click += Button_Click_12;

            ArrBtn[4, 1].Content = "0";
            ArrBtn[4, 1].Click += Button_Click_10;

            ArrBtn[4, 2].Content = ",";
            ArrBtn[4, 2].Click += Button_Click_14;

            ArrBtn[4, 3].Content = "+";
            ArrBtn[4, 3].Click += Button_Click_15;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Visibility = Visibility.Visible;
            Output.Text = "";
            dotCount = 0;
            inputValue1 = 0;
            inputValue2 = 0;
            isAdditional = false;
            action = Operator.NONE;
            bufferValue = 0;
            isDivisionByZero = false;
            Close();
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (isAdditional == true)
                Additional();
            if (isDivisionByZero == true)
            {
                Output.Text = "";
                dotCount = 0;
                inputValue1 = 0;
                inputValue2 = 0;
                isAdditional = false;
                action = Operator.NONE;
                bufferValue = 0;
                isDivisionByZero = false;
            }
            if (Output.Text == "0")
                Output.Text = "1";
            else if (Output.Text == "-0")
                Output.Text = "-1";
            else 
                Output.Text += "1";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (isAdditional == true)
                Additional();
            if (isDivisionByZero == true)
            {
                Output.Text = "";
                dotCount = 0;
                inputValue1 = 0;
                inputValue2 = 0;
                isAdditional = false;
                action = Operator.NONE;
                bufferValue = 0;
                isDivisionByZero = false;
            }
            if (Output.Text == "0")
                Output.Text = "2";
            else if (Output.Text == "-0")
                Output.Text = "-2";
            else
                Output.Text += "2";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (isAdditional == true)
                Additional();
            if (isDivisionByZero == true)
            {
                Output.Text = "";
                dotCount = 0;
                inputValue1 = 0;
                inputValue2 = 0;
                isAdditional = false;
                action = Operator.NONE;
                bufferValue = 0;
                isDivisionByZero = false;
            }
            if (Output.Text == "0")
                Output.Text = "3";
            else if (Output.Text == "-0")
                Output.Text = "-3";
            else
                Output.Text += "3";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (isAdditional == true)
                Additional();
            if (isDivisionByZero == true)
            {
                Output.Text = "";
                dotCount = 0;
                inputValue1 = 0;
                inputValue2 = 0;
                isAdditional = false;
                action = Operator.NONE;
                bufferValue = 0;
                isDivisionByZero = false;
            }
            if (Output.Text == "0")
                Output.Text = "4";
            else if (Output.Text == "-0")
                Output.Text = "-4";
            else
                Output.Text += "4";
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (isAdditional == true)
                Additional();
            if (isDivisionByZero == true)
            {
                Output.Text = "";
                dotCount = 0;
                inputValue1 = 0;
                inputValue2 = 0;
                isAdditional = false;
                action = Operator.NONE;
                bufferValue = 0;
                isDivisionByZero = false;
            }
            if (Output.Text == "0")
                Output.Text = "5";
            else if (Output.Text == "-0")
                Output.Text = "-5";
            else
                Output.Text += "5";
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (isAdditional == true)
                Additional();
            if (isDivisionByZero == true)
            {
                Output.Text = "";
                dotCount = 0;
                inputValue1 = 0;
                inputValue2 = 0;
                isAdditional = false;
                action = Operator.NONE;
                bufferValue = 0;
                isDivisionByZero = false;
            }
            if (Output.Text == "0")
                Output.Text = "6";
            else if (Output.Text == "-0")
                Output.Text = "-6";
            else
                Output.Text += "6";
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (isAdditional == true)
                Additional();
            if (isDivisionByZero == true)
            {
                Output.Text = "";
                dotCount = 0;
                inputValue1 = 0;
                inputValue2 = 0;
                isAdditional = false;
                action = Operator.NONE;
                bufferValue = 0;
                isDivisionByZero = false;
            }
            if (Output.Text == "0")
                Output.Text = "7";
            else if (Output.Text == "-0")
                Output.Text = "-7";
            else
                Output.Text += "7";
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (isAdditional == true)
                Additional();
            if (isDivisionByZero == true)
            {
                Output.Text = "";
                dotCount = 0;
                inputValue1 = 0;
                inputValue2 = 0;
                isAdditional = false;
                action = Operator.NONE;
                bufferValue = 0;
                isDivisionByZero = false;
            }
            if (Output.Text == "0")
                Output.Text = "8";
            else if (Output.Text == "-0")
                Output.Text = "-8";
            else
                Output.Text += "8";
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (isAdditional == true)
                Additional();
            if (isDivisionByZero == true)
            {
                Output.Text = "";
                dotCount = 0;
                inputValue1 = 0;
                inputValue2 = 0;
                isAdditional = false;
                action = Operator.NONE;
                bufferValue = 0;
                isDivisionByZero = false;
            }
            if (Output.Text == "0")
                Output.Text = "9";
            else if (Output.Text == "-0")
                Output.Text = "-9";
            else
                Output.Text += "9";
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            if (isAdditional == true)
                Additional();
            if (isDivisionByZero == true)
            {
                Output.Text = "";
                dotCount = 0;
                inputValue1 = 0;
                inputValue2 = 0;
                isAdditional = false;
                action = Operator.NONE;
                bufferValue = 0;
                isDivisionByZero = false;
            }
            int NumSize = Output.Text.Length;
            if (NumSize == 0)
                Output.Text += "0";
            else if (Output.Text == "0")
            {

            }
            else 
                Output.Text += "0";
        }

        private void Button_Click_11(object sender, RoutedEventArgs e) //c
        {
            Output.Text = "";
            dotCount=0;
            inputValue1 = 0;
            inputValue2 = 0;
            isAdditional = false;
            action = Operator.NONE;
            bufferValue = 0;
            isDivisionByZero = false;
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            string value = Output.Text;
            if (value.Length != 0)
            {
                if (value[0] == '-')
                {
                    string NewValue = "";
                    for (int i = 1; i < Output.Text.Length; i++)
                        NewValue += value[i];
                    Output.Text = NewValue;
                }
                else Output.Text = "-" + value;
            }
        }

        private void Button_Click_13(object sender, RoutedEventArgs e) //<-
        {
            string value = Output.Text;
            string newValue = "";
            if (isDivisionByZero == true)
            {
                Output.Text = "";
                dotCount = 0;
                inputValue1 = 0;
                inputValue2 = 0;
                isAdditional = false;
                action = Operator.NONE;
                bufferValue = 0;
                isDivisionByZero = false;
            }

            if (value.Length != 0)
            {
                action = Operator.NONE;
                isAdditional = false;
                if (value.Length == 2 && value[0] == '-')
                {
                    Output.Text = "";
                    return;
                }
                for (int i = 0; i < value.Length - 1; i++)
                    newValue += value[i];
                if (value[value.Length - 1] == ',')
                    dotCount = 0;
                Output.Text = newValue;
            }
        }

        static int dotCount = 0;
        private void Button_Click_14(object sender, RoutedEventArgs e) // ,
        {
            if (Output.Text.Length == 0)
            {
                Output.Text = "0,";
                dotCount++;
            }
            else if (dotCount != 1)
            {
                Output.Text += ",";
                dotCount++;
            } 
        }
        static Operator action = Operator.NONE;
        static double inputValue1 = 0;
        static double inputValue2 = 0;
        static double bufferValue = 0;
        static bool isAdditional = false;
        static bool isDivisionByZero = false;
        private void Button_Click_15(object sender, RoutedEventArgs e) //+
        {
            if (Output.Text.Length != 0 && isDivisionByZero == false)
                if (action == Operator.NONE)
                {
                    inputValue1 = double.Parse(Output.Text);
                    Output.Text = "";
                    dotCount = 0;
                    action = Operator.PLUS;
                }
                else
                {
                    Equals();
                    action = Operator.PLUS;
                    isAdditional = true;
                }
            
        }

        private void Additional()
        {
            inputValue1 = double.Parse(Output.Text);
            Output.Text = "";
            isAdditional = false;
        }
        enum Operator
        {
            MULTIPLY, DIVISION, PLUS, MINUS, NONE
        }

        private void Button_Click_16(object sender, RoutedEventArgs e) // =
        {
            Equals();
        }

        private void Equals()
        {
            switch (action)
            {
                case Operator.PLUS:
                    inputValue2 = double.Parse(Output.Text);
                    bufferValue = inputValue1 + inputValue2;
                    Output.Text = "" + bufferValue;
                    action = Operator.NONE;
                    if (Output.Text.Contains(','))
                        dotCount = 1;
                    else dotCount = 0;
                    inputValue1 = 0;
                    inputValue2 = 0;
                    bufferValue = 0;
                    break;

                case Operator.NONE:
                    break;

                case Operator.MINUS:
                    inputValue2 = double.Parse(Output.Text);
                    bufferValue = inputValue1 - inputValue2;
                    Output.Text = "" + bufferValue;
                    action = Operator.NONE;
                    if (Output.Text.Contains(','))
                        dotCount = 1;
                    else dotCount = 0;
                    inputValue1 = 0;
                    inputValue2 = 0;
                    bufferValue = 0;
                    break;

                case Operator.MULTIPLY:
                    inputValue2 = double.Parse(Output.Text);
                    bufferValue = inputValue1 * inputValue2;
                    Output.Text = "" + bufferValue;
                    action = Operator.NONE;
                    if (Output.Text.Contains(','))
                        dotCount = 1;
                    else dotCount = 0;
                    inputValue1 = 0;
                    inputValue2 = 0;
                    bufferValue = 0;
                    break;

                case Operator.DIVISION:
                    inputValue2 = double.Parse(Output.Text);

                    if (inputValue2 != 0)
                    {
                        bufferValue = inputValue1 / inputValue2;
                        Output.Text = "" + bufferValue;
                        action = Operator.NONE;
                        if (Output.Text.Contains(','))
                            dotCount = 1;
                        else dotCount = 0;
                        inputValue1 = 0;
                        inputValue2 = 0;
                        bufferValue = 0;
                    }
                    else
                    {
                        Output.Text = "division by zero";
                        isDivisionByZero = true;
                        isAdditional = false;
                        inputValue1 = 0;
                        inputValue2 = 0;
                        bufferValue = 0;
                        action = Operator.NONE;
                    }

                    break;
            }
        }

        private void Button_Click_17(object sender, RoutedEventArgs e) // -
        {
            if (Output.Text.Length != 0 && isDivisionByZero == false)
                if (action == Operator.NONE)
                {
                    inputValue1 = double.Parse(Output.Text);
                    Output.Text = "";
                    dotCount = 0;
                    action = Operator.MINUS;
                }
                else
                {
                    Equals();
                    action = Operator.MINUS;
                    isAdditional = true;
                }
        }

        private void Button_Click_18(object sender, RoutedEventArgs e) // x
        {
            if (Output.Text.Length != 0 && isDivisionByZero == false)
                if (action == Operator.NONE)
                {
                    inputValue1 = double.Parse(Output.Text);
                    Output.Text = "";
                    dotCount = 0;
                    action = Operator.MULTIPLY;
                }
                else
                {
                    Equals();
                    action = Operator.MULTIPLY;
                    isAdditional = true;
                }
        }

        private void Button_Click_19(object sender, RoutedEventArgs e) // division
        {
            if (Output.Text.Length != 0 && isDivisionByZero == false)
                if (action == Operator.NONE)
                {
                    inputValue1 = double.Parse(Output.Text);
                    Output.Text = "";
                    dotCount = 0;
                    action = Operator.DIVISION;
                }
                else
                {
                    Equals();
                    action = Operator.DIVISION;
                    if(isDivisionByZero != true) isAdditional = true;
                }
        }
    }
}
