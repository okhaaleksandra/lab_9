using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_9
{
    class Triangle
    {
        double a;
        double b;
        double c;
        double area;
        bool check;
        public static int count = 0;
        public static bool showArea = false;

        public Triangle()
        {
            A = 0;
            B = 0;
            C = 0;
            area = 0;
            count++;
            check = false;
        }

        public Triangle(double s1, double s2, double s3)
        {
            A = s1;
            B = s2;
            C = s3;
            area = 0;
            count++;
            check = SidesCheck(A, B, C);
        }

        public double A
        {
            get { return a; }
            set
            {
                if (value < 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"Ошибка. Cторона a меньше нуля.");
                    Console.ResetColor();
                    a = 0;
                }
                else a = value;
            }
        }

        public double B
        {
            get { return b; }
            set
            {
                if (value < 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Ошибка. Сторона b меньше нуля.");
                    Console.ResetColor();
                    b = 0;
                }
                else b = value;
            }
        }

        public double C
        {
            get { return c; }
            set
            {
                if (value < 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("Ошибка. Сторона c  меньше нуля.");
                    Console.ResetColor();
                    c = 0;
                }
                else c = value;
            }
        }
        
        public static bool SidesCheck(double a, double b, double c)
        {
            if ((a + b <= c) || (b + c <= a) || (a + c <= b) || (a == 0 || b == 0 || c == 0))
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"Ошибка. Треугольник с такими сторонами не существует.");
                Console.ResetColor();
                return false;
            }
            else return true;
        }

        public static void SidesCheckVoid(double a, double b, double c)
        {
            if ((a + b <= c) || (b + c <= a) || (a + c <= b))
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"Ошибка. Треугольник с такими сторонами не существует.");
                Console.ResetColor();
                return;
            }
            else return;
        }

        public Triangle AreaCalc()
        {
            if (!this.check)
                this.area = -1;
            else
            {
                double p = (this.A + this.B + this.C) / 2;
                this.area = Math.Round(Math.Sqrt(p * (p - this.A) * (p - this.B) * (p - this.C)), 3);
            }
            showArea = true;
            return this;           
        }

        public static Triangle AreaCalc (Triangle t)
        {
            if (!SidesCheck(t.A, t.B, t.C))
                t.area = -1;
            else
            {
                double p = (t.A + t.B + t.C) / 2;
                t.area = Math.Round(Math.Sqrt(p * (p - t.A) * (p - t.B) * (p - t.C)), 3);
            }
            showArea = true;
            return t;
        }

        public void Show()
        {
            if (showArea && area == -1)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Ошибка. Площадь вычислить невозможно.");
                Console.ResetColor();
                Console.WriteLine();
            }
            else
            {
                if (!showArea)
                {
                    Console.WriteLine($"a = {A}, b = {B}, c = {C}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Площадь треугольника со сторонами {A}, {B} и {C} равна {area}.");
                    Console.WriteLine();
                }
            }
        }

        public static Triangle operator ++ (Triangle t)
        {
            t.A++;
            t.B++;
            t.C++;
            SidesCheckVoid(t.A, t.B, t.C);
            t. check = SidesCheck(t.A, t.B, t.C);
            showArea = false;
            return t;
        }

        public static Triangle operator --(Triangle t)
        {
            t.A--;
            t.B--;
            t.C--;
            SidesCheckVoid(t.A, t.B, t.C);
            t.check = SidesCheck(t.A, t.B, t.C);
            showArea = false;
            return t;
        }

        public static bool operator >=(Triangle t1, Triangle t2)
        {
            if (!t1.check || !t2.check)
                throw new Exception("Ошибка. Площадь одного из треугольников не может быть вычислена.");
            else
            {
                AreaCalc(t1);
                AreaCalc(t2);
                return t1.area >= t2.area;
            }
        }

        public static bool operator <=(Triangle t1, Triangle t2)
        {
            if (!t1.check || !t2.check)
                throw new Exception("Ошибка. Площадь одного из треугольников не может быть вычислена.");

            else
            {
                AreaCalc(t1);
                AreaCalc(t2);
                return t1.area <= t2.area;
            }
        }

        public static implicit operator bool (Triangle t)
        {
            if (t.check)
                return true;
            else return false;
        }

        public static implicit operator double(Triangle t)
        {
            showArea = true;

            if (t.check)
            {
                AreaCalc(t);
                return t.area;
            }
            else return t.area = -1;
        }

    }
}
