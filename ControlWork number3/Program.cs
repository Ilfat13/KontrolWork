
using System;
using System.Collections.Generic;

namespace ControlWork3
{

    struct Section
    {
        public Point a { get; set; }
        public Point b { get; set; }

        public Section(Point a, Point b)
        {
            this.a = a;
            this.b = b;
        }
    }

    struct Point
    {
        public double x { get; set; }
        public double y { get; set; }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sections = GenerateSections(10, -100, 100);

            Console.WriteLine("Имеет ли множество пересекающиеся отрезки " + IsHaveInterseptions(sections));

            Console.ReadKey();
        }

        static bool IsHaveInterseptions(List<Section> sections)
        {
            var count = 0;

            for (int i = 0; i < sections.Count; i++)
            {
                var first = sections[i];

                for (int j = 0; j < sections.Count; j++)
                {
                    if (count >= 2)
                    {
                        return true;
                    }

                    var second = sections[j];

                    if (Check(first, second))
                    { 
                        count++;
                    }
                }
            }

            return false;
        }

        
        static bool Check(Section first, Section second)
        {
            Point p1 = first.a;
            Point p2 = first.b;
            Point p3 = second.a;
            Point p4 = second.b;

            if (p2.x < p1.x)
            {
                Point tmp = p1;
                p1 = p2;
                p2 = tmp;
            }

            if (p4.x < p3.x)
            {
                Point tmp = p3;
                p3 = p4;
                p4 = tmp;
            }

           

            if (p2.x < p3.x)
            {
                return false;
            }

           

            if ((p1.x - p2.x == 0) && (p3.x - p4.x == 0))
            {
                

                if (p1.x == p3.x)
                {
                  

                    if (!((Math.Max(p1.y, p2.y) < Math.Min(p3.y, p4.y)) ||
                        (Math.Min(p1.y, p2.y) > Math.Max(p3.y, p4.y))))
                    {
                        return true;
                    }

                }

                return false;
            }

            

            if (p1.x - p2.x == 0)
            {

                double xA = p1.x;

                double a2 = (p3.y - p4.y) / (p3.x - p4.x);

                double bb2 = p3.y - a2 * p3.x;

                double Ya = a2 * xA + bb2;

                if (p3.x <= xA && p4.x >= xA && Math.Min(p1.y, p2.y) <= Ya &&

                Math.Max(p1.y, p2.y) >= Ya)
                {

                    return true;

                }

                return false;

            }

            

            if (p3.x - p4.x == 0)
            {

               

                double xA = p3.x;

                double a1 = (p1.y - p2.y) / (p1.x - p2.x);

                double bb1 = p1.y - a1 * p1.x;

                double Ya = a1 * xA + bb1;

                if (p1.x <= xA && p2.x >= xA && Math.Min(p3.y, p4.y) <= Ya &&

                Math.Max(p3.y, p4.y) >= Ya)
                {

                    return true;

                }

                return false;

            }

           

           

            double A1 = (p1.y - p2.y) / (p1.x - p2.x);

            double A2 = (p3.y - p4.y) / (p3.x - p4.x);

            double b1 = p1.y - A1 * p1.x;

            double b2 = p3.y - A2 * p3.x;

            if (A1 == A2)
            {

                return false; 

            }

           

            double Xa = (b2 - b1) / (A1 - A2);

           
            if ((Xa < Math.Max(p1.x, p3.x)) || (Xa > Math.Min(p2.x, p4.x)))
            {
                return false;
            }

            else
            {
                return true;
            }

        }

        static List<Section> GenerateSections(int quantity, double min, double max)
        {
            var field = new List<Section>();
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                double x1, y1, x2, y2;

                x1 = NextDouble(random, min, max);
                y1 = NextDouble(random, min, max);

                if (random.Next(0, 1) == 1)
                {
                    x2 = x1;
                    y2 = NextDouble(random, min, max);
                }
                else
                {
                    x2 = NextDouble(random, min, max);
                    y2 = y1;
                }

                var a = new Point(x1, y1);
                var b = new Point(x2, y2);

                field.Add(new Section(a, b));
            }

            return field;
        }

        static double NextDouble(Random random, double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }
    }
}