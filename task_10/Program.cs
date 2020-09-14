using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Task11
{
    class Program
    {
        /*для однопоточного режима*/
        private static string PathOne = System.IO.Path.Combine(Environment.CurrentDirectory, "testfile1.txt");
        /*для многопоточного режима*/
        private static string Path = System.IO.Path.Combine(Environment.CurrentDirectory, "testfile2.txt");
        /*суммарное количество объектов в массиве*/
        private const int MaxPersons = 100;
        /*количество массивов в очереди*/
        private const int MaxArrayOfPersons = 1000;
        /*закончилось чтение данных*/
        static bool Stop;
        static ThreadQueue<Person[]> threadQueue = new ThreadQueue<Person[]>();

        static void Main(string[] args)
        {
            TimeSpan ts;
            Stopwatch stopWatch;
            /*поток на чтение*/
            Thread treadRead;
            /*поток на запись*/
            Thread treadWrite;
        
            /*------------------------------------------------------------*/
            Console.WriteLine("Многопоточный режим:");
            stopWatch = new Stopwatch();
            /*запуск тамера*/
            stopWatch.Start();
            treadRead = new Thread(ReadData);
            treadRead.Start();
            treadWrite = new Thread(WriteData);
            treadWrite.Start();
            treadRead.Join();
            treadWrite.Join();
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine("Продолжительность обработки: {0} с", ts);
            /*------------------------------------------------------------*/
            Console.WriteLine("Однопоточный режим:");
            stopWatch = new Stopwatch();
            /*запуск тамера*/
            stopWatch.Start();
            WorkwithOneThread();
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            Console.WriteLine("Продолжительность обработки: {0} с", ts);
            /*------------------------------------------------------------*/

            Console.WriteLine("Нажмите клавишу Enter");
            Console.ReadKey();
        }

        static void WorkwithOneThread()
        {
            int num = 1;
            Person[] persons;
            Stop = false;
            PersonsProvider personsProvider = new PersonsProvider();

            FileStream fileStream = File.Create(PathOne);
            StreamWriter sw = new StreamWriter(fileStream);

            try
            {
                while (!Stop)
                {
                    persons = personsProvider.GetPersons(num, MaxArrayOfPersons);
                    if (persons.Length == 0) Stop = true;
                    num += MaxArrayOfPersons;

                    foreach (Person person in persons)
                    {
                        sw.WriteLine(person);
                    }
                }
            }
            finally
            {
                sw.Close();
            }
        }

        public static void ReadData()
        {
            int num = 1;
            Person[] persons;
            PersonsProvider personsProvider = new PersonsProvider();
            /*Читаем пока есть данные, те пока метод не вернет пустой массив*/
            while (!Stop)
            {
                /*кладем экземпляр в очередь, пока в ней не более 100 000 объектов*/
                if (threadQueue.Count() < (MaxPersons * MaxArrayOfPersons))
                {
                    persons = personsProvider.GetPersons(num, MaxArrayOfPersons);
                    if (persons.Length == 0) Stop = true;
                    num += MaxArrayOfPersons;
                    threadQueue.Enqueue(persons);             
                }
            }              
        }

        public static void WriteData()
        {
            FileStream fileStream = File.Create(Path);
            StreamWriter sw = new StreamWriter(fileStream);
            try
            {
                /*Пишем данные, пока очередь не равно нулю и есть данные*/
                while (!(threadQueue.Count() == 0 && Stop))
                {
                    if (threadQueue.Count() > 0)
                    {
                        Person[] persons = threadQueue.Dequeue();
                        foreach (Person person in persons)
                        {
                            sw.WriteLine(person);
                        }
                    }
                }
            }
            finally
            {
                sw.Close();
            }
            
        }
    }
}
