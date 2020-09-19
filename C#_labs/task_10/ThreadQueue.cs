using System;
using System.Collections.Generic;
using System.Threading;

namespace Task11
{
    class ThreadQueue<T>
    {
        private Queue<T> queue = new Queue<T>();
        object lockObject = new object();

        public int Count()
        {
            int count = 0;

            lock (lockObject) 
            {
                count += queue.Count;
            }
            return count;
        }

        public void Enqueue(T element)
        {
            lock (lockObject)
            {
                queue.Enqueue(element);
            }
        }

        public T Dequeue()
        {
            T obj = default(T);
            lock (lockObject)
            {
                obj = queue.Dequeue();
            }
            return obj;
        }

    }
}
