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
