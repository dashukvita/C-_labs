using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Комп. число с вещественной частью:");
            Complex com1 = new Complex(-8);
            Console.WriteLine(com1);

            Console.WriteLine("\nКомп. число с вещественной и мнимой частью:");
            Complex com2 = new Complex(2, 4);
            Console.WriteLine(com2);

            Console.WriteLine("\nСоздание комп. числа по модулю {0: 0.00} и аргументу {1: 0.00}: ", com2.Mod, com2.Argument);
            Console.WriteLine(Complex.Complex_ModuleAndArg(com2.Mod, com2.Argument));

            Console.WriteLine("\nМодуль числа {0} = {1:0.00}", com2, com2.Mod);
            Console.WriteLine("\nАргумент числа {0} = {1:0.00}", com2, com2.Argument);

            Console.Write("\nАрифмитические операции над комп. числами:");
            Console.Write("\n{0} + {1} = {2}", com1, com2, com1 + com2);
            Console.Write("\n{0} - {1} = {2}", com2, com1, com2 - com1);
            Console.Write("\n{0} * {1} = {2}", com1, com2, com1 * com2);
            Console.WriteLine("\n{0} / {1} = {2}", com2, com1, com2 / com1);

            Console.Write("\nСравнение комп. чисел (1, -8) и (1, 3) : = {0}",
                               new Complex(1, -8) == new Complex(1, 3));
            Console.WriteLine("\nСравнение комп. чисел (1, -8) и (1, -8) : = {0}",
                               new Complex(1, -8) == new Complex(1, -8));


            Console.WriteLine("\nПриведение типов:");
            double d = (double)new Complex(-8, -1);
            Console.WriteLine(d);
            Complex f = 7.15;
            Console.WriteLine(f);

            Console.WriteLine("\nКрасивый вывод комплексных чисел:");
            Console.WriteLine("{0}", com1);
            Console.WriteLine("{0}", com2);
            Console.WriteLine("{0}", new Complex(0, -5));
            Console.WriteLine("{0}", new Complex(4, -6));
            Console.WriteLine("{0}", new Complex(4, 1));
            Console.WriteLine("{0}", new Complex(-8, -1));
            Console.WriteLine("{0}", new Complex(0, 0));

            Console.ReadLine();
        }
    }
}
