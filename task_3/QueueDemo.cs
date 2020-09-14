using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueDemo
{
    class QueueDemo
    {
        private Node _first;
        private Node _last;
        public int _Count = 0;

        //Создаем узел
        #region
        private class Node
        {
            public Complex Data { get; set; }
            public Node next { get; set; }

            public Node(Complex data)
            {
                Data = data;
            }
        }
        #endregion
        //Помещает число в очередь(в конец)
        #region
        public void Enqueue(Complex data)
        {
            _Count++;
            Node temp = new Node(data);
            if (_first == null)
            {
                _first = _last = temp;
            }
            else
            {
                _last.next = temp;
                _last = temp;
            }
        }
        #endregion
        //Получает число из начала очереди и удаляет его
        #region
        public Complex Dequeue()
        {
            if (_first == null)
            {
                Console.WriteLine("Очередь пустая.");
                return 0;
            }
            else
            {
                _Count--;
                Node current = _first;
                _first = current.next;
                return _first.Data;
            }
        }
        #endregion
        //Возвращает число, находящееся в начале очереди
        #region
        public Complex Peek()
        {
            if (_first == null)
            {
                Console.WriteLine("Очередь пустая.");
                return 0;
            }
            else
            {
                return _first.Data;
            }
        }
        #endregion
        //Печать очереди
        #region
        public void Print()
        {
            Node temp = _first;
            int i = 0;
            while (temp != null && i <= _Count)
            {
                i++;
                Console.WriteLine(temp.Data);
                temp = temp.next;
            }
        }
        #endregion
    }
}
