using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вызовем метод Peek для пустой очереди:");
            QueueDemo queue = new QueueDemo();
            queue.Peek();
            Console.WriteLine();
            Console.WriteLine("Вызовем метод Dequeue для пустой очереди:");
            queue.Dequeue();
            Console.WriteLine();
            Console.WriteLine("Число элементов в пустой очереди: {0}", queue._Count);
            Console.WriteLine();
            Console.WriteLine("Создаем и заполняем нашу очередь, вызов метода Enqueue");
            queue.Enqueue(new Complex(5, 6));
            queue.Enqueue(new Complex(1, 6));
            queue.Enqueue(new Complex(2, 2));
            queue.Enqueue(new Complex(5, 6));
            queue.Enqueue(new Complex(4, 0));
            queue.Enqueue(new Complex(5, 9));
            queue.Enqueue(new Complex(7, 4));

            Console.WriteLine("Число элементов в созданной очереди: {0}", queue._Count);
            Console.WriteLine("Печать элементов созданной очереди:");
            queue.Print();
            Console.WriteLine();
            Console.WriteLine("Число, находящееся в начале очереди: {0}", queue.Peek());
            Console.WriteLine("Удалим верхушку очереди, вызов метода Dequeue");
            queue.Dequeue();
            Console.WriteLine();
            Console.WriteLine("Теперь число элементов в очереди: {0}", queue._Count);
            Console.WriteLine("Теперь число, находящееся в начале очереди: {0}", queue.Peek());
            Console.WriteLine("Печать элементов измененной очереди:");
            queue.Print();
            Console.ReadLine();
        }
    }
}
