using System;
using static System.Console;
using System.Collections;

namespace Prac02
{
    public class Program
    {
        static Random rnd = new Random();
        static void Main(String[] args)
        {
            int citiesAmmount = 10;
            int populationAmmount = 5;
            double mutationProbability = 0.3;
            int iterations = 10000;

            double[,] citiesCoords = new double[citiesAmmount,2];
            for (int i = 0; i< citiesAmmount; i++)
            {
                citiesCoords[i, 0] = rnd.Next(100); //x
                citiesCoords[i, 1] = rnd.Next(100); //y
            }

            List<int[]> ways = new List<int[]>();
            List<double> distances = new List<double>();

            for (int i= 0;i< populationAmmount; i++)
            {
                ways.Add(generateWay(citiesAmmount));
            }


            for (int it = 0; it <= iterations; it++)
            {

                for (int i = 0; i < populationAmmount; i++)
                {
                x1:
                    int chromosome1 = rnd.Next(populationAmmount);
                    int chromosome2 = rnd.Next(populationAmmount);
                    if (chromosome1 == chromosome2) goto x1;

                    int crossoverPoint = rnd.Next(citiesAmmount);

                    List<int> temp1 = new List<int>();
                    List<int> temp2 = new List<int>();

                    for (int j = 0; j < citiesAmmount; j++)
                    {
                        if (j <= crossoverPoint)
                        {
                            temp1.Add(ways[chromosome1][j]);
                            temp2.Add(ways[chromosome2][j]);
                        }
                        else
                        {
                            temp1.Add(ways[chromosome2][j]);
                            temp2.Add(ways[chromosome1][j]);
                        }
                    }

                    List<int> tempBuffer = new List<int>();
                    foreach (int city in temp1)
                        tempBuffer.Add(city);

                    foreach (int city in temp2)
                        temp1.Add(city);

                    foreach (int city in tempBuffer)
                        temp2.Add(city);

                    List<int> check1 = new List<int>();
                    List<int> check2 = new List<int>();

                    for (int k = 0; k < temp1.Count; k++)
                    {
                        if (check1.Contains(temp1[k]))
                        {
                            temp1.RemoveAt(k);
                            k--;
                        }
                        else check1.Add(temp1[k]);
                    }

                    for (int k = 0; k < temp2.Count; k++)
                    {
                        if (check2.Contains(temp2[k]))
                        {
                            temp2.RemoveAt(k);
                            k--;
                        }
                        else check2.Add(temp2[k]);
                    }
                    if (rnd.NextDouble() > 0.5)
                        ways.Add(temp1.ToArray());
                    else ways.Add(temp2.ToArray());

                    if (rnd.NextDouble() <= mutationProbability)
                    {
                        

                        x2:
                        int pos1 = rnd.Next(citiesAmmount);
                        int pos2 = rnd.Next(citiesAmmount);
                        if (pos1 >= pos2) goto x2;

                        int[] bufferway = ways[populationAmmount+i];


                        int[] reverse = new int[pos2 - pos1 + 2];
                        int ii = (pos2 - pos1 + 2) - 1;
                        for (int m = 0; m < bufferway.Length; m++)
                        {
                            if (m >= pos1 && m <= pos2)
                            {
                                reverse[ii] = bufferway[m];
                                ii--;
                            }
                        }

                        ii = 0;
                        for (int m = 0; m< bufferway.Length; m++)
                        {
                            if (m <= pos2 && m >=pos1)
                            {
                                ways[populationAmmount+i][m] = reverse[ii];
                                ii++;
                            }
                        }
                    }

                    //////////////

                    /*
                    foreach (int city in temp1)
                        Write("* " + city);
                    WriteLine();
                    foreach (int city in temp2)
                        Write("* " + city);
                    Write(" || x1[{0}] x2[{1}]", chromosome1+1, chromosome2+1);
                    WriteLine(" | cross - " + (crossoverPoint+1));*/


                }
                
                foreach (int[] way in ways)
                {
                    distances.Add(countDistance(way, citiesCoords));
                }

                //int j = 1;
                bool swaped = true;
                while (swaped != false)
                {
                    swaped = false;
                    for (int i = 0; i < (populationAmmount * 2) - 1; i++)
                    {
                        if (distances[i] > distances[i + 1])
                        {
                            double bufferDist = distances[i];
                            distances[i] = distances[i + 1];
                            distances[i + 1] = bufferDist;

                            int[] bufferWay = ways[i];
                            ways[i] = ways[i + 1];
                            ways[i + 1] = bufferWay;

                            swaped = true;
                        }
                    }
                }

                for (int i = 0; i < populationAmmount; i++)
                    ways.RemoveAt(populationAmmount);

                if (it % 100 == 0)
                {
                    WriteLine("Iteration: " + it);
                    WriteLine("Distance: " + distances[0]);
                    WriteLine();
                }
                


                distances.Clear();
            }





            /*showCities(citiesCoords);
            WriteLine("----Ways-----");
            foreach(int[] way in ways)
            {
                foreach(int city in way)
                {
                    Write(city + " - ");
                }
                WriteLine();
            }


            //
            
            //

            WriteLine("----Distances-----");
            foreach (double distance in distances)
                WriteLine(distance);*/
            ReadLine();
        }

        static int[] generateWay(int cities)
        {
            List<int> check = new List<int>();
            int[] way = new int[cities];
            for (int i = 0; i< cities; i++)
            {
                int city = rnd.Next(cities) + 1;
                if (check.Contains(city) == false)
                {
                    check.Add(city);
                    way[i] = city;
                }
                else
                {
                    i--;
                    continue;
                }
            }

            return way;
        }

        static double countDistance(int[] cities, double[,] coords)
        {
            double distance = 0;
            int i = 0;
            foreach(int city in cities)
            {
                if (i != cities.Length - 1)
                {
                    double a = Math.Abs(coords[cities[i]-1, 0] - coords[cities[i + 1]-1, 0]);
                    double b = Math.Abs(coords[cities[i]-1, 1] - coords[cities[i + 1]-1, 1]);
                    distance += Math.Sqrt(a * a + b * b);
                }
                else
                {
                    double a = Math.Abs(coords[cities[i]-1, 0] - coords[cities[0]-1, 0]);
                    double b = Math.Abs(coords[cities[i]-1, 1] - coords[cities[0]-1, 1]);
                    distance += Math.Sqrt(a * a + b * b);
                }
                i++;
            }
                

            return distance;
        }
        static void showCities (double[,] coords)
        {
            for (int i = 0;i< coords.GetLength(0); i++)
            {
                Console.WriteLine("City-{0}- [{1}, {2}]", (i + 1), coords[i, 0], coords[i, 1]);
            }
        }
    }
}


