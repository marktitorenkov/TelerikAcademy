using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Swapping
{
	public class Node<T>: IEnumerable<T>
	{
		public Node(T value)
		{
			this.Value = value;
			this.Next = null;
			this.Prev = null;
		}

		public T Value { get; }

		public Node<T> Next { get; private set; }

		public Node<T> Prev { get; private set; }

		public void Detach()
		{
			if (this.Next != null)
			{
				this.Next.Prev = null;
				this.Next = null;
			}

			if (this.Prev != null)
			{
				this.Prev.Next = null;
				this.Prev = null;
			}
		}

		public void Attach(Node<T> node)
		{
			if (this == node)
			{
				return;
			}

			this.Next = node;
			node.Prev = this;
		}

		public IEnumerator<T> GetEnumerator()
		{
			var node = this;
			while (node != null)
			{
				yield return node.Value;
				node = node.Next;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}

	class Program
	{
		static void Main()
		{
			int n = int.Parse(Console.ReadLine());
			var swapNums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

			var nums = new Node<int>[n];
			for (int i = 0; i < n; i++)
			{
				var node = new Node<int>(i + 1);
				nums[i] = node;
				if (i != 0)
				{
					nums[i - 1].Attach(node);
				}
			}
			var first = nums[0];
			var last = nums[n - 1];

			foreach (int swapNum in swapNums)
			{
				var swapNode = nums[swapNum - 1];

				var prev = swapNode.Prev;
				var next = swapNode.Next;

				swapNode.Detach();

				swapNode.Attach(first);
				last.Attach(swapNode);

				first = next ?? swapNode;
				last = prev ?? swapNode;
			}

			Console.WriteLine(string.Join(" ", first));
		}
	}
}