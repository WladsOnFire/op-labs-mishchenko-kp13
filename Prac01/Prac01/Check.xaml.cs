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
    /// Логика взаимодействия для Check.xaml
    /// </summary>
    public partial class Check : Window
    {
        public Check()
        {
            InitializeComponent();
            StreamReader sr = new StreamReader("keyword.txt");
            kwL.Content = sr.ReadLine();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        static Random rnd = new Random();
        static int countKeys = 0;
        static Stopwatch stopWatch = new Stopwatch();
        static StreamWriter sw2 = new StreamWriter("CheckSample.txt");
        static int attempts = 0;
        static int currentAttempt = 0;
        static double alpha = 0;
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {


            attempts = AttemptsCB.SelectedIndex + 5;
            switch (AlphaCB.SelectedIndex)
            {
                case 0:
                    alpha = 0.10; //0
                    break;
                case 1:
                    alpha = 0.05; //1
                    break;
                case 2:
                    alpha = 0.01; //2
                    break;
                case 3:
                    alpha = 0.001; //3
                    break;
            }
            e.Handled = true;
            AlphaCB.IsEnabled = false;
            AttemptsCB.IsEnabled = false;
            if (countKeys != kwL.Content.ToString().Length)
            {
                if (e.Key.ToString() == "" + kwL.Content.ToString()[countKeys])
                {
                    if (countKeys != 0)
                    {
                        stopWatch.Stop();
                        TimeSpan ts = stopWatch.Elapsed;
                        stopWatch.Reset();
                        if (countKeys != kwL.Content.ToString().Length - 1)
                            sw2.Write(ts.Seconds + ts.Milliseconds/1000.0 + " ");
                        else sw2.Write(ts.Seconds + ts.Milliseconds / 1000.0);
                    }

                    stopWatch.Start();
                    CheckTB.Text += e.Key.ToString();
                    countKeys++;
                    CheckTB.SelectionStart = CheckTB.Text.Length;
                }
            }

            if (countKeys == kwL.Content.ToString().Length)
            {
                CheckTB.Text = "";
                countKeys = 0;
                sw2.WriteLine();
                currentAttempt++;
                stopWatch.Reset();
                if (currentAttempt == attempts)
                {
                    sw2.Close();
                    CheckTB.IsEnabled = false;
                    CheckTB.Text = "finished";



                    List<string> lines = new List<string>();
                    StreamReader sr2 = new StreamReader("CheckSample.txt");
                    List<string> Learnlines = new List<string>();
                    StreamReader sr3 = new StreamReader("sample.txt");
                    while (!sr2.EndOfStream)
                    {
                        lines.Add(sr2.ReadLine());
                    }
                    sr2.Close();

                    while (!sr3.EndOfStream)
                    {
                        Learnlines.Add(sr3.ReadLine());
                    }
                    sr3.Close();

                    List<double[]> attemptArrays = new List<double[]>();
                    List<double[]> LearnAttemptArrays = new List<double[]>();
                    
                    for (int j = 0; j<attempts; j++)
                    {
                        double[] array = new double[kwL.Content.ToString().Length - 1];
                        string[] stringArray = lines[j].Split(' ');

                        for (int i = 0; i < kwL.Content.ToString().Length - 1; i++)
                            array[i] = double.Parse(stringArray[i]);

                        attemptArrays.Add(array);
                    }

                    for (int j = 0; j < Learnlines.Count ; j++)
                    {
                        double[] array = new double[kwL.Content.ToString().Length - 1];
                        string[] stringArray = Learnlines[j].Split(' ');

                        for (int i = 0; i < kwL.Content.ToString().Length - 1; i++)
                            array[i] = double.Parse(stringArray[i]);

                        LearnAttemptArrays.Add(array);
                    }

                    List<double[]> learnStudentArrays = new List<double[]>();
                    List<double[]> studentArrays = new List<double[]>();
                    for (int j = 0; j < Learnlines.Count; j++)
                    {
                        double[] stArr = new double[kwL.Content.ToString().Length - 1];
                        for (int i = 0; i < kwL.Content.ToString().Length - 1; i++)
                        {
                            stArr[i] = Student(i, LearnAttemptArrays[j]);
                        }
                        learnStudentArrays.Add(stArr);
                    }

                    for (int j =0; j < attempts; j++)
                    {
                        double[] stArr = new double[kwL.Content.ToString().Length - 1];
                        for (int i = 0; i < kwL.Content.ToString().Length - 1; i++)
                        {
                            stArr[i] = Student(i, attemptArrays[j]);
                        }
                        studentArrays.Add(stArr);
                    }
                    int znachushchist = kwL.Content.ToString().Length - 2;


                    StreamWriter sw3 = new StreamWriter("CheckStudent.txt");
                    foreach(double[] array in studentArrays)
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] > critStudent[znachushchist, AlphaCB.SelectedIndex])
                                array[i] = 0;
                            else array[i] = 1;
                            sw3.Write(array[i] + " ");
                        }
                        sw3.WriteLine();
                    }
                    sw3.Close();

                    StreamWriter sw4 = new StreamWriter("LearnStudent.txt");
                    foreach (double[] array in learnStudentArrays)
                    {
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i] > critStudent[znachushchist, AlphaCB.SelectedIndex])
                                array[i] = 0;
                            else array[i] = 1;
                            sw4.Write(array[i] + " ");
                        }
                        sw4.WriteLine();
                    }
                    sw4.Close();

                }
            }


        }
        static double[,] critStudent = new double[9, 4]
        {  //0.10   0.05  0.01   0.001
            {6.31, 12.7, 63.7, 637.0},
            {2.92, 4.3,  9.92, 31.6 },
            {2.35, 3.18, 5.84, 12.9 },
            {2.13, 2.78, 4.6,  8.61 },
            {2.01, 2.57, 4.03, 6.86 },
            {1.94, 2.45, 3.71, 5.96 },
            {1.89, 2.36, 3.5,  5.4  },
            {1.86, 2.31, 3.36, 5.04 },
            {1.83, 2.26, 3.25, 4.78 },
        };
        public double Student(int index, double[]array)
        {
            double M = 0;
            double sum = 0;
            for(int i = 0; i<array.Length; i++)
                if (i != index) sum += array[i];

            M = sum / (array.Length - 1.0);

            
            double sum2 = 0;
            for (int i = 0; i< array.Length - 1; i++)
                if (i != index)
                    sum2 += Math.Pow(array[i] - M, 2);

            double S2 = sum2 / (array.Length - 1.0 - 1.0);

            double S = Math.Sqrt(S2);

            double tp = Math.Abs((array[index] - M) / (S / Math.Sqrt(array.Length - 1)));
            
            return tp;
        }


    }
}
