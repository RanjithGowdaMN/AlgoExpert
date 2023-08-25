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
/*
 
 using System.Collections.Generic;
using System.Linq;
using System;

// AE_WRAPPER_V2

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Program.LinkedList ll1 =
      addMany(new Program.LinkedList(2), new int[] { 4, 7, 1 });
    Program.LinkedList ll2 =
      addMany(new Program.LinkedList(9), new int[] { 4, 5 });
    Program.LinkedList expected =
      addMany(new Program.LinkedList(1), new int[] { 9, 2, 2 });
    var actual = new Program().SumOfLinkedLists(ll1, ll2);
    Utils.AssertTrue(Enumerable.SequenceEqual(
      getNodesInArray(expected), getNodesInArray(actual)
    ));
  }

  public Program
    .LinkedList addMany(Program.LinkedList linkedList, int[] values) {
    var current = linkedList;
    while (current.next != null) {
      current = current.next;
    }
    foreach (var value in values) {
      current.next = new Program.LinkedList(value);
      current = current.next;
    }
    return linkedList;
  }

  public List<int> getNodesInArray(Program.LinkedList linkedList) {
    List<int> nodeValues = new List<int>();
    Program.LinkedList current = linkedList;
    while (current != null) {
      nodeValues.Add(current.value);
      current = current.next;
    }
    return nodeValues;
  }
}


8 / 8 test cases passed.

Test Case 1 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "9", "value": 1},
    {"id": "9", "next": "2", "value": 9},
    {"id": "2", "next": "2-2", "value": 2},
    {"id": "2-2", "next": null, "value": 2}
  ]
}
Our Code's Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "9", "value": 1},
    {"id": "9", "next": "2", "value": 9},
    {"id": "2", "next": "2-2", "value": 2},
    {"id": "2-2", "next": null, "value": 2}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedListOne": {
    "head": "2",
    "nodes": [
      {"id": "2", "next": "4", "value": 2},
      {"id": "4", "next": "7", "value": 4},
      {"id": "7", "next": "1", "value": 7},
      {"id": "1", "next": null, "value": 1}
    ]
  },
  "linkedListTwo": {
    "head": "9",
    "nodes": [
      {"id": "9", "next": "4", "value": 9},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": null, "value": 5}
    ]
  }
}
Test Case 2 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "1-2", "value": 1},
    {"id": "1-2", "next": null, "value": 1}
  ]
}
Our Code's Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "1-2", "value": 1},
    {"id": "1-2", "next": null, "value": 1}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedListOne": {
    "head": "2",
    "nodes": [
      {"id": "2", "next": null, "value": 2}
    ]
  },
  "linkedListTwo": {
    "head": "9",
    "nodes": [
      {"id": "9", "next": null, "value": 9}
    ]
  }
}
Test Case 3 passed!
Expected Output
{
  "head": "9",
  "nodes": [
    {"id": "9", "next": "0", "value": 9},
    {"id": "0", "next": "0-2", "value": 0},
    {"id": "0-2", "next": "5", "value": 0},
    {"id": "5", "next": null, "value": 5}
  ]
}
Our Code's Output
{
  "head": "9",
  "nodes": [
    {"id": "9", "next": "0", "value": 9},
    {"id": "0", "next": "0-2", "value": 0},
    {"id": "0-2", "next": "5", "value": 0},
    {"id": "5", "next": null, "value": 5}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedListOne": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "0-2", "value": 0},
      {"id": "0-2", "next": "0-3", "value": 0},
      {"id": "0-3", "next": "5", "value": 0},
      {"id": "5", "next": null, "value": 5}
    ]
  },
  "linkedListTwo": {
    "head": "9",
    "nodes": [
      {"id": "9", "next": null, "value": 9}
    ]
  }
}
Test Case 4 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "1-2", "value": 1},
    {"id": "1-2", "next": "1-3", "value": 1},
    {"id": "1-3", "next": null, "value": 1}
  ]
}
Our Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "1-2", "value": 1},
    {"id": "1-2", "next": "1-3", "value": 1},
    {"id": "1-3", "next": null, "value": 1}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedListOne": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "1-2", "value": 1},
      {"id": "1-2", "next": "1-3", "value": 1},
      {"id": "1-3", "next": null, "value": 1}
    ]
  },
  "linkedListTwo": {
    "head": "9",
    "nodes": [
      {"id": "9", "next": "9-2", "value": 9},
      {"id": "9-2", "next": "9-3", "value": 9},
      {"id": "9-3", "next": null, "value": 9}
    ]
  }
}
Test Case 5 passed!
Expected Output
{
  "head": "7",
  "nodes": [
    {"id": "7", "next": "9", "value": 7},
    {"id": "9", "next": "2", "value": 9},
    {"id": "2", "next": "2-2", "value": 2},
    {"id": "2-2", "next": "8", "value": 2},
    {"id": "8", "next": null, "value": 8}
  ]
}
Our Code's Output
{
  "head": "7",
  "nodes": [
    {"id": "7", "next": "9", "value": 7},
    {"id": "9", "next": "2", "value": 9},
    {"id": "2", "next": "2-2", "value": 2},
    {"id": "2-2", "next": "8", "value": 2},
    {"id": "8", "next": null, "value": 8}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedListOne": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": null, "value": 3}
    ]
  },
  "linkedListTwo": {
    "head": "6",
    "nodes": [
      {"id": "6", "next": "7", "value": 6},
      {"id": "7", "next": "9", "value": 7},
      {"id": "9", "next": "1", "value": 9},
      {"id": "1", "next": "8", "value": 1},
      {"id": "8", "next": null, "value": 8}
    ]
  }
}
Test Case 6 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": null, "value": 0}
  ]
}
Our Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": null, "value": 0}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedListOne": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": null, "value": 0}
    ]
  },
  "linkedListTwo": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": null, "value": 0}
    ]
  }
}
Test Case 7 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "0-2", "value": 0},
    {"id": "0-2", "next": "0-3", "value": 0},
    {"id": "0-3", "next": "0-4", "value": 0},
    {"id": "0-4", "next": "0-5", "value": 0},
    {"id": "0-5", "next": "8", "value": 0},
    {"id": "8", "next": null, "value": 8}
  ]
}
Our Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "0-2", "value": 0},
    {"id": "0-2", "next": "0-3", "value": 0},
    {"id": "0-3", "next": "0-4", "value": 0},
    {"id": "0-4", "next": "0-5", "value": 0},
    {"id": "0-5", "next": "8", "value": 0},
    {"id": "8", "next": null, "value": 8}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedListOne": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": null, "value": 0}
    ]
  },
  "linkedListTwo": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "0-2", "value": 0},
      {"id": "0-2", "next": "0-3", "value": 0},
      {"id": "0-3", "next": "0-4", "value": 0},
      {"id": "0-4", "next": "0-5", "value": 0},
      {"id": "0-5", "next": "8", "value": 0},
      {"id": "8", "next": null, "value": 8}
    ]
  }
}
Test Case 8 passed!
Expected Output
{
  "head": "4",
  "nodes": [
    {"id": "4", "next": "6", "value": 4},
    {"id": "6", "next": "9", "value": 6},
    {"id": "9", "next": "3", "value": 9},
    {"id": "3", "next": "3-2", "value": 3},
    {"id": "3-2", "next": "7", "value": 3},
    {"id": "7", "next": null, "value": 7}
  ]
}
Our Code's Output
{
  "head": "4",
  "nodes": [
    {"id": "4", "next": "6", "value": 4},
    {"id": "6", "next": "9", "value": 6},
    {"id": "9", "next": "3", "value": 9},
    {"id": "3", "next": "3-2", "value": 3},
    {"id": "3-2", "next": "7", "value": 3},
    {"id": "7", "next": null, "value": 7}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedListOne": {
    "head": "4",
    "nodes": [
      {"id": "4", "next": "6", "value": 4},
      {"id": "6", "next": "9", "value": 6},
      {"id": "9", "next": "3", "value": 9},
      {"id": "3", "next": "1", "value": 3},
      {"id": "1", "next": null, "value": 1}
    ]
  },
  "linkedListTwo": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "0-2", "value": 0},
      {"id": "0-2", "next": "0-3", "value": 0},
      {"id": "0-3", "next": "0-4", "value": 0},
      {"id": "0-4", "next": "2", "value": 0},
      {"id": "2", "next": "7", "value": 2},
      {"id": "7", "next": null, "value": 7}
    ]
  }
}
 
 */