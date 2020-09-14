using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDemo
{
    public class Stack<T> where T : ICloneable
    {
        private Node<T> _top; // ссылка на последний элемент стека

        // Создаем узел
        private class Node<TElement>
        {
            public Node(TElement data, Node<TElement> next = null)
            {
                Data = data;
                Next = next;
            }
            public TElement Data { get; set; }
            public Node<TElement> Next { get; set; }
        }

        // Добавляем значение в стек
        public void Push(T data)
        {
            Node<T> temp = new Node<T>(data);

            temp.Next = _top;
            _top = temp;
        }

        //Возвращаем значение из вершины стека и удаляем его из стека
        public T Pop()
        {
            if (_top == null) 
            {
                Console.WriteLine("Стек пустой."); 
                return default(T);
            }
            else
            {
                Node<T> temp = _top;
                _top = _top.Next;

                return temp.Data;
            }
        }

        //Возвращаем значение из вершины стека, не удаляя его из стека
        public T Top()
        {
            if (_top == null)
            {
                Console.WriteLine("Стек пустой.");
                return default(T);
            }
            else
            {
                return (T)_top.Data.Clone();;
            }
        }

        //Возвращаем количество элементов в стеке
        public int Count
        {
            get
            {
                int result = 0;
                Node<T> node = _top;
                while (node != null)
                {
                    node = node.Next;
                    ++result;
                }

                return result;
            }
        }

        //Печать стека
        public void Print()
        {
            Node<T> temp = _top;
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }
    }
}
