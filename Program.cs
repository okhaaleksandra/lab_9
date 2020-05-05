using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle t1 = new Triangle(2, 3, 4);
            t1.Show();
            Triangle t2 = new Triangle(3, 4, 5);
            t2.Show();
            Triangle t3 = new Triangle(1.5, 3, 5);
            t3.Show();
            Triangle t4 = new Triangle(-7, 9, 12);
            t4.Show();

            t1.AreaCalc().Show();
            t3.AreaCalc().Show();
            Triangle.AreaCalc(t2).Show();
            Triangle.AreaCalc(t4).Show();

            Console.WriteLine("Создано объектов:" + Triangle.count);
            Console.WriteLine("—————————————————————————часть 2—————————————————————————————————————————\n");


            Console.WriteLine("Операции ++ и --");
            t1++.Show();
            Triangle t5 = new Triangle(0, 1, 1.5);
            t5.Show();
            t5++.Show();

            t3--.Show();
            t2--.Show();

            Console.WriteLine("Явное приведение к типу double");
            Console.WriteLine((double)t5);
            Console.WriteLine((double)t1--);//можно сверить со значением в части 1 (сошлось)
            Console.WriteLine((double)t3 + "\n");//-1 => площадь нельзя вычислить

            Console.WriteLine("Явное приведение к типу bool");
            Console.WriteLine((bool)t5);
            Console.WriteLine((bool)t1++);
            Console.WriteLine((bool)t3 + "\n");

            Console.WriteLine("Операции >= и <=");
            Console.WriteLine(t1 >=t5);
            //Console.WriteLine((t3 >= t1)); exception
            Console.WriteLine((t2 <= t1) + "\n");
            Console.WriteLine("—————————————————————————часть 3—————————————————————————————————————————\n");


            TriangleArray trArr1 = new TriangleArray();
            trArr1.Show();
            TriangleArray trArr2 = new TriangleArray(3);
            trArr2.Show();
            TriangleArray trArr3 = new TriangleArray(3, true);
            trArr3.Show();
            Console.WriteLine("Создано объектов:" + TriangleArray.countArr + "\n");

            TriangleArray.MinIndex(trArr1);
            TriangleArray.MinIndex(trArr2);
            TriangleArray.MinIndex(trArr3);


            Console.ReadKey();

        }
    }
}
