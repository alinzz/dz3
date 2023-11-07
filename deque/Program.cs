using System;
using System.Collections.Generic;
using node;

namespace dz34
{
	public class MyDeque<T>
	{
		public MyDeque()
		{
			head = null;
		}

		DoublyNode<T> head { get; set; }

		public void AddFirst(T data)
		{
			var node = new DoublyNode<T>(data);
			if (head != null)
				head.Prev = node;
			node.Next = head;
			head = node;
		}

		public T RemoveFirst()
		{
			if (head == null) throw new Exception("Empty deque");
			var data = head.Data;
			head = head.Next;
			if (head != null)
				head.Prev = null;
			return data;
		}

		public void AddLast(T data)
		{
			var node = new DoublyNode<T>(data);
			if (head == null)
			{
				head = node;
				return;
			}

			var current = head;
			while (current.Next != null)
			{
				current = current.Next;
			}

			current.Next = node;
			node.Prev = current;
		}

		public T RemoveLast()
		{
			if (head == null) throw new Exception("Empty deque");
			var current = head;
			while (current.Next != null)
			{
				current = current.Next;
			}

			var data = current.Data;
			if (current.Prev != null)
			{
				current.Prev.Next = null;
			}
			else
			{
				head = null;
			}

			return data;
		}

		public List<int> FindData(T data)
		{
			if (head == null) throw new Exception("Empty deque");
			var list = new List<int>();
			int index = 0;
			var current = head;
			do
			{
				if (current.Data.Equals(data))
					list.Add(index);
				current = current.Next;
				index++;
			} 
			while (current != null);
			return list;
		}

		public T RemoveIndex(int index)
		{
			if (head == null) throw new Exception("Empty deque");
			var current = head;
			for (int i = 0; i < index; i++)
			{
				if (current.Next == null) throw new Exception("Index out of range");
				current = current.Next;
			}

			var data = current.Data;
			if (current.Next != null)
				current.Next.Prev = current.Prev;
			if (current.Prev != null)
				current.Prev.Next = current.Next;
			else
				head = current.Next;
			return data;
		}

		public void RemoveData(T data)
		{
			if (head == null) throw new Exception("Empty deque");
			var list = FindData(data);
			int removed = 0;
			foreach (var i in list)
			{
				RemoveIndex(i - removed);
				removed++;
			}
		}

		public void Print()
		{
			if (head == null)
			{
				Console.WriteLine("empty");
				return;
			}

			string result = "";
			var current = head;
			do
			{
				result += current.Data.ToString() + " ";
				current = current.Next;
			} while (current != null);

			Console.WriteLine(result);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var usersDeck = new MyDeque<string>();
			usersDeck.AddFirst("Alice");
			usersDeck.AddLast("Kate");
			usersDeck.AddLast("Tom");
			usersDeck.AddFirst("Sam");
			usersDeck.Print();
			var list = usersDeck.FindData("Alice");
			string found = "Index(es): ";
			foreach (var l in list)
			{
				found += l + " ";
			}
			Console.WriteLine(found);
			usersDeck.RemoveData("Kate");
			usersDeck.RemoveFirst();
			usersDeck.RemoveLast();
			usersDeck.Print();
		}
	}
}
