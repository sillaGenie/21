using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        private static int[,] field;
        private static int m;
        private static int n;
        static void Main(string[] args)
        {
            n = Convert.ToInt32(Console.ReadLine());
            m = Convert.ToInt32(Console.ReadLine());
            field = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(field[i, j] + " ");
                }
                Console.WriteLine();
            }
            Thread gardener1 = new Thread(Gardener1);
            Thread gardener2 = new Thread(Gardener2);
            gardener1.Start();
            gardener2.Start();
            gardener1.Join();
            gardener2.Join();

            for (int i = 0; i < n; i++)
            { 
                for (int j = 0; j < m; j++)
                {
                    Console.Write(field[i, j] + " ");
                }
               Console.WriteLine();
            }
        }
        private static void Gardener1()
        {
            for (int i = 0; i<n; i++)
            {
                for (int j = 0; j<m; j++)
                {
                    if (field[i, j] == 0)
                        field[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
         }
        private static void Gardener2()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (field[i, j] == 0)
                        field[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }
    }
}
