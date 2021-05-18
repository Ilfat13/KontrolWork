using System;
using System.Collections.Generic;

namespace KontrolWork
{
    class Program
    {
        static void Main(string[] args)
        {

            Task();
            Console.WriteLine(" - первые N элементы объединения");

        }
        static List<int> ListCreate()
        {
            Random random = new Random();
            List<int> list = new List<int>();

            for (int i = 0; i < random.Next(1, 20); i++)
            {
                list.Add(random.Next(0, 99));
            }
            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }

            Console.WriteLine();
            list.Sort();
            return list;
        }

        static void Task()
        {
            List<int> list = new List<int>();

            Console.Write(" Введите количество списков  чисел: ");
            int k = Convert.ToInt32(Console.ReadLine());
            Console.Write(" введите количество возвращаемых чисел: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            for (int i = 0; i < k; i++)
            {
                list.AddRange(ListCreate());
            }
            list.Sort();

            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write(list[i] + " ");
            }
        }

    }
}






