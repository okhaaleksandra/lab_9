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
            Triangle t1 = new Triangle();
            t1.Show();
            Triangle t2 = new Triangle(3, 4, 5);
            t2.Show();
            Triangle t3 = new Triangle(1.5, 3, 5);
            t3.Show();
            Triangle t4 = new Triangle(-7, 9, 12);
            t4.Show();

            Console.WriteLine("Создано объектов:" + Triangle.count);
            Console.ReadKey();
        }
    }
}
