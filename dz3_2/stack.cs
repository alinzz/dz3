using System;


namespace z1
{
        internal class dz3_1
        {

                public static void Main(string[] args)
                {
                        string input;
                        FixedStack<int> stack = new FixedStack<int>(100);
                        while ((input = Console.ReadLine()) != "exit")
                        {
                                string[] parts = input.Split();
                                string operation = parts[0];
                                if (operation == "push")
                                {
                                        int num = int.Parse(parts[1]);
                                                stack.Push(num);
                                                Console.WriteLine("ok");
                                }
                                else if (operation == "pop")
                                {
                                        if (stack.Count == 0)
                                                Console.WriteLine("Стек пуст");
                                        else
                                        {
                                                int poppedn = stack.Pop();
                                                Console.WriteLine(poppedn);
                                        }
                                }

                                else if (operation == "back")
                                {
                                        { 
                                                if (stack.Count == 0)
                                                        Console.WriteLine("Стек пуст");
                                                else
                                                {
                                                        int topn = stack.Peek();
                                                        Console.WriteLine(topn);
                                                }
                                        }
                                }

                                else if (operation == "size")
                                {
                                        int stackSize = stack.Count;
                                        Console.WriteLine(stackSize);
                                }

                                else if (operation == "clear")
                                {
                                        stack.Clear();
                                        Console.WriteLine("ОК");
                                }
                        }
                        Console.WriteLine("bye");
                }
        }
        public class FixedStack<T>
        {
                private T[] items; // элементы стека
                private int count;  // количество элементов
                const int n = 100;   // количество элементов в массиве по умолчанию
                public FixedStack()
                {
                        items = new T[n];
                }
                public FixedStack(int length)
                {
                        items = new T[length];
                }
                public int Count
                {
                        get { return count; }
                }
                // добвление элемента
                public void Push(T item)
                {
                        items[count++] = item;
                }
                // извлечение элемента
                public T Pop()
                {
                        T item = items[--count];
                        items[count] = default(T); // сбрасываем ссылку
                        return item;
                }
                
                public int Clear()
                {
                        count = 0;
                        return count;
                }
                public T Peek()
                {
                        return items[count - 1];
                }
        }
}
