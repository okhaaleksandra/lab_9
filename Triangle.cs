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
                    Console.WriteLine($"Ошибка. Cторона a меньше нуля.");
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
                    Console.WriteLine("Ошибка. Сторона b меньше нуля.");
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
                    Console.WriteLine("Ошибка. Сторона c  меньше нуля.");
                    c = 0;
                }
                else c = value;
            }
        }

        public static bool SidesCheck(double a, double b, double c)
        {
            if ((a + b <= c) || (b + c <= a) || (a + c <= b))
            {
                Console.WriteLine($"Ошибка. Треугольник с такими сторонами не существует. (№ {count})\n");
                return false;
            }
            else return true;
        }

        public Triangle AreaCalc()
        {
            if (!this.check)
                this.area = -1;
            else
            {
                double p = (this.A + this.B + this.C) / 2;
                this.area = Math.Sqrt(p * (p - this.A) * (p - this.B) * (p - this.C));
            }
            return this;

        }

        public static Triangle AreaCalc (Triangle t)
        {
            if (!SidesCheck(t.A, t.B, t.C))
                t.area = -1;
            else
            {
                double p = (t.A + t.B + t.C) / 2;
                t.area = Math.Sqrt(p * (p - t.A) * (p - t.B) * (p - t.C));
            }
            return t;
        }

        public void Show()
        {
            if (area == -1)
            {
                Console.WriteLine("Ошибка. Площадь вычислить невозможно.");
                Console.WriteLine();
            }
            else
            {
                if (area == 0)
                {
                    Console.WriteLine($"Треугольник со сторонами {A}, {B} и {C}.");
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
            return t;
        }

        public static Triangle operator --(Triangle t)
        {
            t.A--;
            t.B--;
            t.C--;
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
            if (t.check)
            {
                AreaCalc(t);
                return t.area;
            }
            else return t.area = -1;
        }

    }
}
