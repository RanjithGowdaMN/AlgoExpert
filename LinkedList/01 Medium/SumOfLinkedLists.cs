using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList._01_Medium
{
	public static class Program
	{
		// This is an input class. Do not edit.
		public class LinkedList
		{
			public int value;
			public LinkedList next;

			public LinkedList(int value)
			{
				this.value = value;
				this.next = null;
			}
		}

		public static LinkedList SumOfLinkedLists(LinkedList linkedListOne, LinkedList linkedListTwo)
		{
			// Write your code here.
			LinkedList newLinkedList = new LinkedList(0);
			LinkedList currentNode = newLinkedList;
			int carry = 0;

			LinkedList firstList = linkedListOne;
			LinkedList secondList = linkedListTwo;

            while (firstList !=null || secondList !=null || carry!=0)
            {
				int firstVal = 0;
				int secondVal = 0;
				//set value 0 if fisrt or second node is null
				if (firstList != null)
				{
					firstVal = firstList.value;
				}
				else
				{
					firstVal = 0;
				}

				if (secondList != null)
				{
					secondVal = secondList.value;
				}
				else
				{ 
					secondVal= 0;
				}

				// calculate sum and carry
				int value1 = (firstVal + secondVal + carry)/10;
				carry = (firstVal + secondVal + carry) % 10;

				LinkedList linkedList = new LinkedList(value1);
				currentNode.next = linkedList;
				currentNode = linkedList;

				//point to next node
				if (firstList != null)
				{
					firstList = firstList.next;
				}
				else
				{
					firstList = null;
				}

				if (secondList != null)
				{
					secondList = secondList.next;
				}
				else
				{
					secondList = null;
				}

			}
		return newLinkedList.next;
		}
	}

}
