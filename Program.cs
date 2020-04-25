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
            TriangleArray arr = new TriangleArray(3, true);
            arr.Show();

            TriangleArray.MinIndex(arr);

            Console.ReadKey();
        }
    }
}
