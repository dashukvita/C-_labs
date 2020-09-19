using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double result = 0.0;
            InverseFunc inverseFunc = new InverseFunc();
            inverseFunc.CalculationEvent += PrintEvent;

            // входная функция как анонимный метод
            result = inverseFunc.InverseFunction(delegate (double i) { return Math.Sin(i); }, 0.1, 1.3, 0.0001, 0.5);
            Console.WriteLine($"Ответ: {result:0.00}");
            Console.WriteLine();

            // входная функция как лямбда выражение
            result = inverseFunc.InverseFunction(x => x * x + Math.Sin(x - 2), 2.5, 3.5, 0.0001, 8);
            Console.WriteLine($"Ответ: {result:0.00}");
            Console.WriteLine();

            // входная функция как делегат
            result = inverseFunc.InverseFunction(Func, 0, 1.5, 0.0001, 8);
            Console.WriteLine($"Ответ: {result:0.00}");
            Console.WriteLine();

            Console.ReadLine();
        }

        private static void PrintEvent(object sender, CurrentСalAccurEvent e)
        {
            Console.WriteLine($"Промежуточный ответ {e.CurrentResult:0.00}, достигнутая точность = {e.Accuracy:0.0000000}");
        }

        private static double Func(double x)
        {
            return 3 * x + 5;
        }
    }
}
