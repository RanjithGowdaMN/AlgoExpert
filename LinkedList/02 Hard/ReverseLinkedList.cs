using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList._02_Hard
{
	public class ReverseLinkedLists
	{
		public static LinkedList ReverseLinkedList(LinkedList head)
		{
			// Write your code here.
			LinkedList ref1 = null;
			LinkedList ref2 = head;
            while(ref2!=null)
            {
				LinkedList ref3 = ref2.Next;
				ref2.Next = ref1;
				ref1 = ref2;
				ref2 = ref3;
            }
			return ref1;
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
