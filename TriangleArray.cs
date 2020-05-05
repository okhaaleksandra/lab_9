using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_9
{
    class TriangleArray
    {
        Triangle[] arr = null;
        static Random rnd = new Random();
        public static int countArr = 0;

        public int Length => arr.Length;

        public static void RandomTriangle(out double a, out double b, out double c)
        {
            a = 0; b = 0; c = 0;
            while ((a + b <= c) || (b + c <= a) || (a + c <= b))
            {
                a = rnd.Next(0, 10);
                b = rnd.Next(0, 10);
                c = rnd.Next(0, 10);
            }
        }

        public TriangleArray()
        {
            double a  =0, b = 0 , c = 0;
            Triangle.showArea = false;
            arr = new Triangle[1];

            RandomTriangle(out a, out b, out c);
            Triangle t = new Triangle(a, b, c);
            arr[0] = t;
            countArr++;
        }

        public TriangleArray(int size)
        {
            double a = 0, b = 0, c = 0;
            Triangle.showArea = false;
            arr = new Triangle[size];
            for (int i = 0; i < size; i++)
            {
                RandomTriangle(out a, out b, out c);
                Triangle t = new Triangle(a, b, c);
                arr[i] = t;
            }
            countArr++;
        }

        public TriangleArray(int size, bool consoleInput)
        {
            Triangle.showArea = false;
            arr = new Triangle[size];
            Console.WriteLine("Для  каждого элемента массива (треугольника) задайте три значения через пробел (длины сторон).\n");

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"треугольник {i + 1}:");
                string str = Console.ReadLine();
                double[] tmp = str.Split(' ').Select(x => Convert.ToDouble(x)).ToArray();
                Triangle t = new Triangle(tmp[0], tmp[1], tmp[2]);
                arr[i] = t;
            }
            countArr++;
        }

        public void Show()
        {
            if (arr == null || arr.Length == 0)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Массив пустой");
                Console.ResetColor();
                return;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Массив:");
                Console.ResetColor();
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i].Show();
                }
            }
        }

        public Triangle this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                    return arr[index];
                else
                    Console.WriteLine("Ошибка. Индекс за пределами диапазона.");
                throw new IndexOutOfRangeException();
            }
            set
            {
                arr[index] = value;
            }
        }

        public static int MinIndex(TriangleArray arr)
        {
            int min = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if ((double)arr[i] != -1)
                 min = i;
            }
            if ((double)arr[min] == -1)
            {
                Console.WriteLine("Ошибка. Площадь ни одного из треугольников нельзя вычислить.");
                return -1;
            }
            else
            {
                for (int i = 1; i < arr.Length - 1; i++)
                {
                    if ((double)arr[i] < (double)arr[min])
                        min = i;
                }
                Console.WriteLine("Индекс треугольника с минимальной площадью:" + (min + 1));
                return min;
            }
        }

    }
}
