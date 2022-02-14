using System.Collections.Generic;
using System;

public class RemovingDuplicates
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

	public LinkedList RemoveDuplicatesFromLinkedList(LinkedList linkedList)
	{
		// Write your code here.
		LinkedList currentNode = linkedList;

		while (currentNode != null)
		{
			LinkedList nextDisctinctNode = currentNode.next;
            while (nextDisctinctNode != null && nextDisctinctNode.value == currentNode.value)
            {
				nextDisctinctNode = nextDisctinctNode.next;
            }

			currentNode.next = nextDisctinctNode;
			currentNode = nextDisctinctNode;
		}

		return linkedList;
	}
}
