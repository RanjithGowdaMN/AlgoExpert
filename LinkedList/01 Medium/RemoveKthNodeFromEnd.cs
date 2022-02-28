using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList._01_Medium
{
    internal class RemoveKthNodeFromEnd
    {
		public class Program
		{
			public static void RemoveKthNodeFromEnd(LinkedList head, int k)
			{
				// Write your code here.
				int counter = 1;
				LinkedList first = head;
				LinkedList second = head;
                while (counter <= k)
                {
					second = second.Next;
					counter += 1;
                }
                if (second == null)
                {
					head.Value = head.Next.Value;
					head.Next = head.Next.Next;
					return;
                }
				while (second.Next != null)
				{ 
					first = first.Next;
					second = second.Next;
				}
				first.Next = first.Next.Next;
			}

			public class LinkedList
			{
				public int Value;
				public LinkedList Next = null;

				public LinkedList(int value)
				{
					this.Value = value;
				}
			}
		}
	}
}
