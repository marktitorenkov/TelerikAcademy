namespace IEnumerableExtensions
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public static class IEnumerableExtensions
	{
		public static T Sum<T>(this IEnumerable<T> collection)
        {
            dynamic sum = default(T);
            foreach (var item in collection)
            {
                sum += item;
            }
            return sum;
        }
		public static T Product<T>(this IEnumerable<T> collection)
		{
			dynamic product = 1;
			foreach (var item in collection)
			{
				product *= item;
			}
			return product;
		}
		public static T Min<T>(this IEnumerable<T> collection) where T: IComparable
		{
			dynamic min = collection.First();
			foreach (var item in collection)
			{
				if (item.CompareTo(min) == -1)
				{
					min = item;
				}
			}
			return min;
		}
		public static T Max<T>(this IEnumerable<T> collection) where T : IComparable
		{
			dynamic max = collection.First();
			foreach (var item in collection)
			{
				if (item.CompareTo(max) == 1)
				{
					max = item;
				}
			}
			return max;
		}
		public static T Average<T>(this IEnumerable<T> collection)
		{
			dynamic sum = default(T);
			int count = 0;
			foreach (var item in collection)
			{
				sum += item;
				count++;
			}
			return sum / count;
		}
		public static string ToStringCustom<T>(this IEnumerable<T> collection)
		{
			return string.Join(", ", collection);
		}
	}
}