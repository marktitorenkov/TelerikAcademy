namespace GenericListT
{
	using System;
	using System.Text;

	public class GenericList<T>
	{
		private const int INITIAL_CAPACITY = 4;
		private T[] elements;

		public GenericList(int capacity)
		{
			this.Count = 0;
			this.elements = new T[this.NearestPowerOf2(capacity)];
		}
		public GenericList() : this(INITIAL_CAPACITY)
		{
		}

		public int Count { get; private set; }
		public int Capacity { get { return this.elements.Length; } }

		public T this[int index]
		{
			get
			{
				if (InRange(index))
				{
					return this.elements[index];
				}
				else
				{
					throw new ArgumentOutOfRangeException();
				}
			}
			set
			{
				if (InRange(index))
				{
					this.elements[index] = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		public static TComp Min<TComp>(GenericList<TComp> list) 
			where TComp: IComparable
		{
			TComp min = list[0];
			for (int i = 1; i < list.Count; i++)
			{
				if (list[i].CompareTo(min) == -1)
				{
					min = list[i];
				}
			}
			return min;
		}
		public static TComp Max<TComp>(GenericList<TComp> list) 
			where TComp : IComparable
		{
			TComp max = list[0];
			for (int i = 1; i < list.Count; i++)
			{
				if (list[i].CompareTo(max) == 1)
				{
					max = list[i];
				}
			}
			return max;
		}

		public void Add(T item)
		{
			if (this.Count == this.Capacity)
			{
				this.Expand();
			}
			this.elements[Count] = item;
			Count++;
		}
		public void InsertAt(T item, int index)
		{
			if (InRange(index))
			{
				if (this.Count == this.Capacity)
				{
					this.Expand();
				}
				for (int i = this.Count; i > index; i--)
				{
					this.elements[i] = this.elements[i - 1];
				}
				this[index] = item;
				Count++;
			}
			else
			{
				throw new ArgumentOutOfRangeException();
			}
		}
		public void RemoveAt(int index)
		{
			if (InRange(index))
			{
				for (int i = index; i < this.Count - 1; i++)
				{
					this.elements[i] = this.elements[i + 1];
				}
				this.elements[Count - 1] = default(T);
				Count--;
			}
			else
			{
				throw new ArgumentOutOfRangeException();
			}
		}
		public void Clear()
		{
			this.Count = 0;
			this.elements = new T[INITIAL_CAPACITY];
		}
		public int IndexOf(T item)
		{
			int index = -1;
			for (int i = 0; i < this.Count; i++)
			{
				if (this.elements[i].Equals(item))
				{
					index = i;
					break;
				}
			}
			return index;
		}
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < this.Count; i++)
			{
				sb.Append(this.elements[i]);
				if (i != this.Count - 1)
					sb.Append(", ");
			}
			return sb.ToString();
		}

		private void Expand()
		{
			T[] newEleemnts = new T[this.Capacity * 2];
			for (int i = 0; i < elements.Length; i++)
			{
				newEleemnts[i] = elements[i];
			}
			elements = newEleemnts;
		}
		private bool InRange(int index)
		{
			return index > -1 && index < this.Count;
		}
		private int NearestPowerOf2(int n)
		{
			int pow = 0;
			while (n > 0)
			{
				n >>= 1;
				pow++;
			}
			return 1 << pow;
		}
	}
}