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
            try
            {
                Console.WriteLine("Введите путь к папке: ");
                string fullFileName = Console.ReadLine();
                Console.WriteLine("Введите имя log-файла: ");
                string logFileName = Console.ReadLine();

                Console.WriteLine("Нажмите Enter для выхода ...");
                FileMonitoring fileMonitoring = new FileMonitoring();
                fileMonitoring.startMonitoring(fullFileName, logFileName);

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Нажмите Enter для выхода ...");
                Console.ReadLine();
            }
        }
    }
}
