using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать.
//    Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом.
//    Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, 
//    сделав ряд, он спускается вниз. Второй садовник начинает работу с нижнего правого угла сада 
//    и перемещается снизу вверх, сделав ряд, он перемещается влево. Если садовник видит, что участок 
//    сада уже выполнен другим садовником, он идет дальше. Садовники должны работать параллельно.
//    Создать многопоточное приложение, моделирующее работу садовников.

namespace Task21
{
    class Program
    {
        const int n = 6, m = 6;
        static int[,] area = new int[n, m];

        static void Main(string[] args)
        {
            SetArray();
            PrintArray();
            Console.WriteLine();

            ThreadStart threadstart = new ThreadStart(Gar2);
            Thread thread = new Thread(threadstart);
            thread.Start();

            Gar1();

            PrintArray();
            Console.ReadKey();
        }

        static void SetArray()
        {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        area[i,j] = i*10 +j*10;
        }
        static void Gar1()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (area[i, j] >= 0)
                    {
                        int delay = area[i, j];
                        area[i, j] =-1;
                        Thread.Sleep(delay);
                    }
        }

        static void Gar2()
        {
            for (int i = n - 1; i >= 0; i--)
                for (int j = m - 1; j >= 0; j--)
                    if (area[i, j] >= 0)
                    {
                        int delay = area[i, j];
                        area[i, j] = -2;
                        Thread.Sleep(delay);
                    }
        }

        static void PrintArray()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(area[i, j] + " ");
                Console.WriteLine();
            }
        }
    }
}
