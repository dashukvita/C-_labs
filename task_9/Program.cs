using System;
using System.IO;
using System.Collections.Generic;

namespace EmployeeBase
{
    class Program
    {
        //Лист сотрудников
        public List<Employee> employees = new List<Employee>();
        private static readonly string EmployeeBinaryFileName = Path.Combine(Environment.CurrentDirectory, "EmployeeStore.bin");
        //Добавление нового сотрудника
        private void AddEmployee(string id, string lastName, string firstName, string patronymic, string phoneNumber, string address)
        {
            Employee emp = new Employee(id, lastName, firstName, patronymic, phoneNumber, address);
            if ((!employees.Exists(e => e.LastName == emp.LastName) && (!employees.Exists(e => e.FirstName == emp.FirstName))))
            {
                employees.Add(emp);
            }
            else Console.WriteLine("Такой сотрудник уже есть в базе данных\n");
        }
        //Печать списка сотрудников
        private void PrintEmployee()
        {
            Console.WriteLine("Список сотрудников предприятия:");
            foreach (Employee e in employees)
            {
                Console.WriteLine(e);
            }
        }
        //Поиск по фамилии, имени, отчеству, номеру телефона или адресу сотрудника
        private void SearchEmployee(string info)
        {
            bool findInfo = false;
            foreach (Employee e in employees)
            {
                if (e.ID.Equals(info) ||
                    e.FirstName.Equals(info) ||
                    e.LastName.Equals(info) ||
                    e.Patronymic.Equals(info) ||
                    e.PhoneNumber.Equals(info) ||
                    e.Address.Equals(info))
                {
                    Console.WriteLine($"Сотрудник с полем {info} найден: \n{e}");
                    findInfo = true;
                }
            }

            if (!findInfo) Console.WriteLine($"Сотрудник с полем {info} не найден!\n");
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Десериализация списка сотрудников");
            Console.WriteLine("-------------------------------------------------------");
            IProvider<List<Employee>> employeeProvider = new EmployeeBinaryProvider(EmployeeBinaryFileName);
            // десериализуем, если была информация о сотрудниках
            if (File.Exists(EmployeeBinaryFileName))
            {
                program.employees = employeeProvider.Load();
            }
            program.PrintEmployee();
            Console.WriteLine();

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Добавим сотрудников");
            Console.WriteLine("-------------------------------------------------------");
            program.AddEmployee("1", "Ivan", "Ivanov", "I", "Phone1", "Address1");
            program.AddEmployee("2", "Petr", "Petrov", "P", "Phone2", "Address1");
            program.AddEmployee("3", "Oleg", "Sidorov", "S", "Phone3", "Address1");
            program.AddEmployee("4", "Irina", "Ivanova", "A", "Phone1", "Address1");
            program.AddEmployee("5", "Olga", "Petrova", "V", "Phone1", "Address1");
            program.AddEmployee("6", "Ivan", "Ivanov", "I", "Phone1", "Address1");
            program.PrintEmployee();
            Console.WriteLine();

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Ищем сотрудников:");
            Console.WriteLine("-------------------------------------------------------");
            program.SearchEmployee("Ivan");
            program.SearchEmployee("Ivanova");
            program.SearchEmployee("blablabla");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Сериализация сотрудников");
            employeeProvider.Save(program.employees);

            Console.WriteLine("Нажмите Enter для выхода...");
            Console.ReadKey();
        }
    }
}
