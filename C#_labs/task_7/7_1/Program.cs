using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            GetInfoAboutFile getInfo = new GetInfoAboutFile();
            string fullFileName = null;
            try
            {
                //получаем на вход файл с инфомацией о сотрудниках
                string fileCSV = args[0];
                getInfo.AnalyzeFile(fileCSV);
                Console.WriteLine("Файл успешно обработан.\n");
            }
            catch (IndexOutOfRangeException)
            {
                //или создаем и заполняем файл с именем infoAboutEmployee.csv во временной директории
                Console.WriteLine("Нет параметров.\n");
                string tempPath = Path.GetTempPath();
                fullFileName = Path.Combine(tempPath, "infoAboutEmployee.csv");
                CreateAndFillCSVFile(fullFileName);
                Console.WriteLine($"Создали и заполнили файл: {fullFileName}");
                getInfo.AnalyzeFile(fullFileName);
                Console.WriteLine("Файл успешно обработан.\n");

                // Распечатаем на экране созданный файл
                Console.WriteLine($"Распечатаем на экране созданный файл: {fullFileName}");
                PrintFile(fullFileName);
            }
            catch (FileNotFoundException)
            {
                //или создаем и заполняем файл с именем infoAboutEmployee.csv во временной директории
                Console.WriteLine("Нет параметров.\n");
                string tempPath = Path.GetTempPath();
                fullFileName = Path.Combine(tempPath, "infoAboutEmployee.csv");
                CreateAndFillCSVFile(fullFileName);
                Console.WriteLine($"Создали и заполнили файл: {fullFileName}");
                getInfo.AnalyzeFile(fullFileName);
                Console.WriteLine("Файл успешно обработан.\n");

                // Распечатаем на экране созданный файл
                Console.WriteLine($"Распечатаем на экране созданный файл: {fullFileName}");
                PrintFile(fullFileName);
            }
            catch (Exception e) 
            {
                Console.WriteLine( e.Message);
            }
            finally
            {

                // Удалим созданный нами временный файл
                if (fullFileName != null)
                {
                    Console.WriteLine($"\nУдалим созданный нами временный файл: {fullFileName}");
                    File.Delete(fullFileName);
                }
                Console.WriteLine($"\nИнформация о сотрудниках:");
                Console.WriteLine($"Общее количество сотрудников: {getInfo.EmployeeCounter}");
                Console.WriteLine($"Количество правильных адресов: {getInfo.RightEmailCounter}");
                Console.WriteLine($"Количество неправильных адресов: {getInfo.WrongEmailCounter}");
                Console.WriteLine($"Количество правильных телефонов: {getInfo.RightNumbeCounter}");
                Console.WriteLine($"Количество неправильных телефонов: {getInfo.WrongEmailCounter}");
                Console.WriteLine("\nНажмите Enter, чтобы выйти ...");

            }
            Console.ReadKey();
        }

        private static void CreateAndFillCSVFile(string fullFileName)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(fullFileName);
                // Заполняем файл
                sw.WriteLine("name\temail\tphone");
                sw.WriteLine("\"Name1\"\t\"emailOne@mail.ru\"\t\"(905)559-17-66\"");
                sw.WriteLine("\"Name2\"\t\"emailTwo@mail.ru\"\t\"(499)214-05-55-35\"");
                sw.WriteLine("\"Name3\"\t\"emailThree@mail.ru\"\t\"(495)555-55-55\"");
                sw.WriteLine("\"Name4\"\t\"emailFour@mail.ru\"\t\"(495)555-55-56\"");
                sw.WriteLine("\"Name5\"\t\"emailFive@ma45354354354il.ru\"\t\"(495)555-55-57\"");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Обязательно закрыть файл
                if (sw != null) sw.Close();
            }
        }

        private static void PrintFile(string fullFileName)
        {
            using (StreamReader sr = new StreamReader(fullFileName))
            {
                while (!sr.EndOfStream) Console.WriteLine(sr.ReadLine());
            } 
        }
    }
}
