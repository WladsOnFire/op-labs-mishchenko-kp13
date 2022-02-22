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

                    ///
                    int znachushchist = kwL.Content.ToString().Length - 2;
                    ///

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


                    ////////////////////////

                    List<string> sampleLines = new List<string>();
                    StreamReader learn_sw = new StreamReader("sample.txt");
                    while (!learn_sw.EndOfStream)
                    {
                        sampleLines.Add(learn_sw.ReadLine());
                    }
                    learn_sw.Close();
                    double[,] sample = new double[sampleLines.Count(), kwL.Content.ToString().Length - 1];
                    
                    for (int i = 0; i<sampleLines.Count(); i++)
                    {
                        string[] sampleLine = sampleLines[i].Split(' ');
                        for (int j = 0; j < sampleLines[0].Split(' ').Length; j++)
                        {
                            sample[i, j] = double.Parse(sampleLine[j]);
                        }
                    }

                    List<string> checkLines = new List<string>();
                    StreamReader check_sw = new StreamReader("CheckSample.txt");
                    while (!check_sw.EndOfStream)
                    {
                        checkLines.Add(check_sw.ReadLine());
                    }
                    check_sw.Close();
                    double[,] check = new double[checkLines.Count(), kwL.Content.ToString().Length - 1];

                    for (int i = 0; i < checkLines.Count(); i++)
                    {
                        string[] checkLine = checkLines[i].Split(' ');
                        for (int j = 0; j < kwL.Content.ToString().Length - 1; j++)
                        {
                            check[i, j] = double.Parse(checkLine[j]);
                        }
                    }

                    int minAttempts = 0;
                    if (checkLines.Count > sampleLines.Count)
                        minAttempts = sampleLines.Count;
                    else
                        minAttempts = checkLines.Count;

                    double[] Tps = T_p(sample, check, minAttempts, kwL.Content.ToString().Length - 1, AlphaCB.SelectedIndex);

                    List<bool> solutions = new List<bool>();
                    znachushchist = kwL.Content.ToString().Length - 2;

                    foreach (double tp in Tps)
                    {
                        if (tp > critStudent[znachushchist, AlphaCB.SelectedIndex])
                            solutions.Add(false);
                        else solutions.Add(true);
                    }

                    double sols = 0;
                    double badsols = 0;
                    StreamWriter sol_sw = new StreamWriter("solutions.txt");
                    foreach (bool solution in solutions)
                        if (solution == false)
                        {
                            sol_sw.WriteLine("0");
                            badsols++;
                        }
                        else
                        {
                            sol_sw.WriteLine("1");
                            sols++;
                        }
                    sol_sw.Close();

                    int user = User.SelectedIndex;
                    switch (user)
                    {
                        case 0:
                            StreamReader dv_sr = new StreamReader("developer.txt");
                            double badsols_r = double.Parse(dv_sr.ReadLine());
                            badsols_r += badsols;
                            double all_developer = double.Parse(dv_sr.ReadLine());
                            all_developer += Convert.ToDouble(minAttempts);
                            dv_sr.Close();

                            StreamWriter dv_sw = new StreamWriter("developer.txt");
                            dv_sw.WriteLine(badsols_r);
                            dv_sw.WriteLine(all_developer);
                            dv_sw.Close();

                            double P1 = badsols_r / all_developer;
                            P1Lb.Content = P1;
                            break;
                        case 1:
                            StreamReader us_sr = new StreamReader("user.txt");
                            double sols_r = double.Parse(us_sr.ReadLine());
                            sols_r += sols;
                            double all_user = double.Parse(us_sr.ReadLine());
                            all_user += Convert.ToDouble(minAttempts);
                            us_sr.Close();
                            StreamWriter us_sw = new StreamWriter("user.txt");
                            us_sw.WriteLine(sols_r);
                            us_sw.WriteLine(all_user);
                            us_sw.Close();

                            double P2 = sols_r / all_user;
                            P2Lb.Content = P2;
                            break;
                    }

                    StreamWriter tps_sw = new StreamWriter("tps.txt");
                    foreach (double tp in Tps)
                        tps_sw.WriteLine(tp);
                    tps_sw.Close();

                    double P = sols / Convert.ToDouble(minAttempts);
                    PLb.Content = "" + P;

                    
                    

                    
                }
            }


        }
        double[] T_p(double[,] sample, double[,] check, int attempts, double periods, int index)
        {
            double[] Tps = new double[attempts];
            List<double> Ss = new List<double>();

            for (int i = 0; i< attempts; i++)
            { 
                double Msum_x = 0;
                double Msum_y = 0;

                for (int j =0; j< periods; j++)
                {
                    Msum_x += sample[i, j];
                    Msum_y += check[i, j];
                }
                double Mx = Msum_x / periods;
                double My = Msum_y / periods;

                double sum_x = 0;
                for (int j = 0; j< periods; j++)
                {
                    sum_x += Math.Pow( sample[i,j] - Mx, 2 );
                }
                double S2x = sum_x / (periods - 1.0);

                double sum_y = 0;
                for (int j = 0; j < periods; j++)
                {
                    sum_y += Math.Pow(check[i, j] - My, 2);
                }
                double S2y = sum_y / (periods - 1.0);

                double S = Math.Sqrt((S2x + S2y) * (periods - 1.0) / ((2 * periods) - 1.0));

                double tp = Math.Abs(Mx - My) / (S * Math.Sqrt(2 / periods));
                Tps[i] = tp;

                Ss.Add(S2x);
                Ss.Add(S2y);
            }

            double min2 = Ss[0];
            for (int i=0; i<Ss.Count; i++)
                if (Ss[i] < min2) min2 = Ss[i];

            double max2 = Ss[0];
            for (int i = 0; i < Ss.Count; i++)
                if (Ss[i] > max2) max2 = Ss[i];

            double Fp = max2 / min2;
            if(index != 4)
            {
                if (Fp > critFisher[Convert.ToInt32(periods - 1), index])
                {
                    Disp.Content = "Дисперсiї неоднорідні"; //neodnoridni
                }
                else
                {
                    Disp.Content = "Дисперсiї однорідні"; //odnoridni
                }
            }
            else Disp.Content = "none";

            return Tps;
        }

        /*static double M(double[,] array, int i, int j_count, int j)
        {
            double sum = 0;
            
            for (int j1 = 0; j1 < j_count; j1++)
            {
                if (j1 != j) sum += array[i, j1];
            }

            double M = sum / (j_count - 1);
            return M;
        }*/

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

        static double[,] critFisher = new double[7, 3]
        {   //0.1  0.05  0.01  0.001 - none
            {39.86,161,4052},
            {9.00,19,99.01},
            {5.39,9.28,29.46},
            {4.11,6.39,15.98},
            {3.45,5.05,10.97},
            {3.05,4.28,8.47},
            {2.78,3.79,7.00}
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
