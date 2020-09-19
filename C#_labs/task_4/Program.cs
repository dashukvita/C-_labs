using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создаем стек int, string, double:");
            Stack<GetInt> intStack = new Stack<GetInt>();
            intStack.Push(new GetInt(5));
            intStack.Push(new GetInt(4));
            intStack.Push(new GetInt(3));
            intStack.Push(new GetInt(2));
            intStack.Push(new GetInt(1));
            Console.WriteLine("\n   Стек int содержит:");
            intStack.Print();

            Stack<GetString> stringStack = new Stack<GetString>();
            stringStack.Push(new GetString("понедельник"));
            stringStack.Push(new GetString("вторник"));
            stringStack.Push(new GetString("среда"));
            stringStack.Push(new GetString("четверг"));
            stringStack.Push(new GetString("пятница"));
            stringStack.Push(new GetString("суббота"));
            stringStack.Push(new GetString("воскресенье"));
            Console.WriteLine("\n   Стек string содержит:");
            stringStack.Print();

            Stack<GetDouble> doubleStack = new Stack<GetDouble>();
            doubleStack.Push(new GetDouble(1.1));
            doubleStack.Push(new GetDouble(2.2));
            doubleStack.Push(new GetDouble(3.3));
            Console.WriteLine("\n   Стек Double содержит:");
            doubleStack.Print();

            Console.WriteLine("\n   Демонстрация работы функций стека с использованием обобщенного метода:");
            ChangeStack(intStack);
            ChangeStack(stringStack);
            ChangeStack(doubleStack);

            Console.ReadLine();
        }

        static void ChangeStack<T>(Stack<T> stack) where T : ICloneable
        {
            if (stack.Count == 0)
            {
                Console.WriteLine("Стек пустой."); 
            }
            else
            {
                Console.WriteLine("Вершина стека (Pop без удаления): {0}", stack.Top());
                Console.WriteLine("Число элементов в стеке: {0}", stack.Count);
                Console.WriteLine("Вершина стека (Pop с удалением): {0}", stack.Pop());
                Console.WriteLine("Теперь число элементов в стеке: {0}", stack.Count);
                Console.WriteLine("Теперь вершина стека (Pop без удаления): {0}\n", stack.Top());
            }
        }
    }
}
