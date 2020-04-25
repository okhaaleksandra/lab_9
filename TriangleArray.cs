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

        public TriangleArray(int size)
        {
            arr = new Triangle[size];
            for (int i = 0; i < size; i++)
            {
                Triangle t = new Triangle(rnd.Next(0, 100), rnd.Next(0, 100), rnd.Next(0, 100));
                arr[i] = t;
            }
            countArr++;
        }

        public TriangleArray(int size, bool consoleInput)
        {
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
                Console.WriteLine("Массив пустой");
                return;
            }
            else
            {
                Console.WriteLine("Массив:");
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

            for (int i = 1; i < arr.Length -1; i++)
            {
                if ((double)arr[min] != -1)
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
