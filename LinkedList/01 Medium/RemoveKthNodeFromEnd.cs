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
/*
 using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    TestLinkedList test = new TestLinkedList(0);
    test.addMany(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
    int[] expected = { 0, 1, 2, 3, 4, 5, 7, 8, 9 };
    Program.RemoveKthNodeFromEnd(test, 4);
    Utils.AssertTrue(compare(test.getNodesInArray(), expected));
  }

  public bool compare(List<int> arr1, int[] arr2) {
    if (arr1.Count != arr2.Length) {
      return false;
    }
    for (int i = 0; i < arr1.Count; i++) {
      if (arr1[i] != arr2[i]) {
        return false;
      }
    }
    return true;
  }

  public class TestLinkedList : Program.LinkedList {
    public TestLinkedList(int value) : base(value) {}

    public void addMany(int[] values) {
      Program.LinkedList current = this;
      while (current.Next != null) {
        current = current.Next;
      }
      foreach (int value in values) {
        current.Next = new Program.LinkedList(value);
        current = current.Next;
      }
    }

    public List<int> getNodesInArray() {
      List<int> nodes = new List<int>();
      Program.LinkedList current = this;
      while (current != null) {
        nodes.Add(current.Value);
        current = current.Next;
      }
      return nodes;
    }
  }
}


10 / 10 test cases passed.

Test Case 1 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "7", "value": 5},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": null, "value": 9}
  ]
}
Our Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "7", "value": 5},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": null, "value": 9}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 4,
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "1", "value": 0},
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "6", "value": 5},
      {"id": "6", "next": "7", "value": 6},
      {"id": "7", "next": "8", "value": 7},
      {"id": "8", "next": "9", "value": 8},
      {"id": "9", "next": null, "value": 9}
    ]
  }
}
Test Case 2 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": null, "value": 8}
  ]
}
Our Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": null, "value": 8}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 1,
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "1", "value": 0},
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "6", "value": 5},
      {"id": "6", "next": "7", "value": 6},
      {"id": "7", "next": "8", "value": 7},
      {"id": "8", "next": "9", "value": 8},
      {"id": "9", "next": null, "value": 9}
    ]
  }
}
Test Case 3 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "9", "value": 7},
    {"id": "9", "next": null, "value": 9}
  ]
}
Our Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "9", "value": 7},
    {"id": "9", "next": null, "value": 9}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 2,
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "1", "value": 0},
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "6", "value": 5},
      {"id": "6", "next": "7", "value": 6},
      {"id": "7", "next": "8", "value": 7},
      {"id": "8", "next": "9", "value": 8},
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
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "8", "value": 6},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": null, "value": 9}
  ]
}
Our Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "8", "value": 6},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": null, "value": 9}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 3,
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "1", "value": 0},
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "6", "value": 5},
      {"id": "6", "next": "7", "value": 6},
      {"id": "7", "next": "8", "value": 7},
      {"id": "8", "next": "9", "value": 8},
      {"id": "9", "next": null, "value": 9}
    ]
  }
}
Test Case 5 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "6", "value": 4},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": null, "value": 9}
  ]
}
Our Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "6", "value": 4},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": null, "value": 9}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 5,
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "1", "value": 0},
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "6", "value": 5},
      {"id": "6", "next": "7", "value": 6},
      {"id": "7", "next": "8", "value": 7},
      {"id": "8", "next": "9", "value": 8},
      {"id": "9", "next": null, "value": 9}
    ]
  }
}
Test Case 6 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "5", "value": 3},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": null, "value": 9}
  ]
}
Our Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "5", "value": 3},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": null, "value": 9}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 6,
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "1", "value": 0},
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "6", "value": 5},
      {"id": "6", "next": "7", "value": 6},
      {"id": "7", "next": "8", "value": 7},
      {"id": "8", "next": "9", "value": 8},
      {"id": "9", "next": null, "value": 9}
    ]
  }
}
Test Case 7 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "4", "value": 2},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": null, "value": 9}
  ]
}
Our Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "4", "value": 2},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": null, "value": 9}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 7,
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "1", "value": 0},
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "6", "value": 5},
      {"id": "6", "next": "7", "value": 6},
      {"id": "7", "next": "8", "value": 7},
      {"id": "8", "next": "9", "value": 8},
      {"id": "9", "next": null, "value": 9}
    ]
  }
}
Test Case 8 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "3", "value": 1},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": null, "value": 9}
  ]
}
Our Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "3", "value": 1},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": null, "value": 9}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 8,
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "1", "value": 0},
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "6", "value": 5},
      {"id": "6", "next": "7", "value": 6},
      {"id": "7", "next": "8", "value": 7},
      {"id": "8", "next": "9", "value": 8},
      {"id": "9", "next": null, "value": 9}
    ]
  }
}
Test Case 9 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "2", "value": 0},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": null, "value": 9}
  ]
}
Our Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "2", "value": 0},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": null, "value": 9}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 9,
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "1", "value": 0},
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "6", "value": 5},
      {"id": "6", "next": "7", "value": 6},
      {"id": "7", "next": "8", "value": 7},
      {"id": "8", "next": "9", "value": 8},
      {"id": "9", "next": null, "value": 9}
    ]
  }
}
Test Case 10 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": null, "value": 9}
  ]
}
Our Code's Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": null, "value": 9}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 10,
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "1", "value": 0},
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "6", "value": 5},
      {"id": "6", "next": "7", "value": 6},
      {"id": "7", "next": "8", "value": 7},
      {"id": "8", "next": "9", "value": 8},
      {"id": "9", "next": null, "value": 9}
    ]
  }
}


 
 
 */