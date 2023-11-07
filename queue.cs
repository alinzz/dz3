using System;

namespace dz32
{
        internal class Program
        {
                public static void Main()
                {
                        Queue<string> queue = new Queue<string>();
                        string input;
                        while ((input = Console.ReadLine()) != "exit")
                        {
                                string[] parts = input.Split();
                                string operation = parts[0];
                                if (operation == "push")
                                {
                                        string str = parts[1];
                                        queue.Enqueue(str);
                                        Console.WriteLine("ok");
                                }
                                else if (operation == "pop")
                                {
                                        if (queue.Count != 0)
                                        {
                                                var popped = queue.Dequeue();
                                                Console.WriteLine(popped);
                                        }
                                        else Console.WriteLine("error");
                                }

                                else if (operation == "front")
                                {
                                        if (queue.Count != 0)
                                        {
                                                var topn = queue.Peek();
                                                Console.WriteLine(topn);
                                        }
                                        else Console.WriteLine("error");
                                }

                                else if (operation == "size")
                                {
                                        int qSize = queue.Count;
                                        Console.WriteLine(qSize);
                                }

                                else if (operation == "clear")
                                {
                                        queue.Clear();
                                        Console.WriteLine("ОК");
                                }
                        }

                        Console.WriteLine("bye");
                        System.Environment.Exit(0);
                }


                public class Queue<T>
                {
                        private int _front = 0;
                        private int _tail = 0;
                        private int _count = -1;
                        private readonly int _size = 10;
                        private readonly T[] _array;
                        
                        public Queue()
                        {
                                _array = new T[_size];
                        }

                        public bool IsEmpty()
                        {
                                return _count == 0;
                        }

                        public void Enqueue(T item)
                        {
                                if (this.IsEmpty())
                                        throw new Exception("full");
                                
                                _array[_tail] = item;
                                _tail++;
                        }

                        public T Dequeue()
                        {
                                if (this.IsEmpty())
                                        throw new Exception("empty");
                                T value = _array[++_front];
                                _count--;
                                if (_front == _tail)
                                        _front = 1;
                                else
                                        _tail = 1;
                                return value;
                        }

                        public int Count
                        {
                                get { return _tail - _front; }
                        }

                        public T Peek()
                        {
                                T value = _array[_front];
                                return value;
                        }

                        public int Clear()
                        {
                                _count = 0;
                                return _count;
                        }
                }
        }
}