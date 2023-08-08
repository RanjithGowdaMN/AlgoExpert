using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList._02_Hard
{
	public static class ReverseLinkedLists
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

/*
 using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Program.LinkedList test = newLinkedList(new int[] { 0, 1, 2, 3, 4, 5 });
    List<int> result = toList(Program.ReverseLinkedList(test));
    int[] expected = new int[] { 5, 4, 3, 2, 1, 0 };
    Utils.AssertTrue(arraysEqual(result, expected));
  }

  public Program.LinkedList newLinkedList(int[] values) {
    Program.LinkedList ll = new Program.LinkedList(values[0]);
    Program.LinkedList current = ll;
    for (int i = 1; i < values.Length; i++) {
      current.Next = new Program.LinkedList(values[i]);
      current = current.Next;
    }
    return ll;
  }

  public List<int> toList(Program.LinkedList ll) {
    List<int> arr = new List<int>();
    Program.LinkedList current = ll;
    while (current != null) {
      arr.Add(current.Value);
      current = current.Next;
    }
    return arr;
  }

  public bool arraysEqual(List<int> arr1, int[] arr2) {
    if (arr1.Count != arr2.Length) return false;
    for (int i = 0; i < arr1.Count; i++) {
      if (arr1[i] != arr2[i]) return false;
    }
    return true;
  }
}


Test Case 1 passed!
Expected Output
{
  "head": "5",
  "nodes": [
    {"id": "5", "next": "4", "value": 5},
    {"id": "4", "next": "3", "value": 4},
    {"id": "3", "next": "2", "value": 3},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "0", "value": 1},
    {"id": "0", "next": null, "value": 0}
  ]
}
Your Code's Output
{
  "head": "5",
  "nodes": [
    {"id": "5", "next": "4", "value": 5},
    {"id": "4", "next": "3", "value": 4},
    {"id": "3", "next": "2", "value": 3},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "0", "value": 1},
    {"id": "0", "next": null, "value": 0}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "1", "value": 0},
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": null, "value": 5}
    ]
  }
}
Test Case 2 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": null, "value": 0}
  ]
}
Your Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": null, "value": 0}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": null, "value": 0}
    ]
  }
}
Test Case 3 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "0", "value": 1},
    {"id": "0", "next": null, "value": 0}
  ]
}
Your Code's Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "0", "value": 1},
    {"id": "0", "next": null, "value": 0}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "1", "value": 0},
      {"id": "1", "next": null, "value": 1}
    ]
  }
}
Test Case 4 passed!
Expected Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "0", "value": 1},
    {"id": "0", "next": null, "value": 0}
  ]
}
Your Code's Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "0", "value": 1},
    {"id": "0", "next": null, "value": 0}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "1", "value": 0},
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": null, "value": 2}
    ]
  }
}
Test Case 5 passed!
Expected Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "2", "value": 3},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "0", "value": 1},
    {"id": "0", "next": null, "value": 0}
  ]
}
Your Code's Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "2", "value": 3},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "0", "value": 1},
    {"id": "0", "next": null, "value": 0}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "1", "value": 0},
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": null, "value": 3}
    ]
  }
}
Test Case 6 passed!
Expected Output
{
  "head": "6",
  "nodes": [
    {"id": "6", "next": "5", "value": 6},
    {"id": "5", "next": "4", "value": 5},
    {"id": "4", "next": "3", "value": 4},
    {"id": "3", "next": "2", "value": 3},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "0", "value": 1},
    {"id": "0", "next": null, "value": 0}
  ]
}
Your Code's Output
{
  "head": "6",
  "nodes": [
    {"id": "6", "next": "5", "value": 6},
    {"id": "5", "next": "4", "value": 5},
    {"id": "4", "next": "3", "value": 4},
    {"id": "3", "next": "2", "value": 3},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "0", "value": 1},
    {"id": "0", "next": null, "value": 0}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "1", "value": 0},
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "6", "value": 5},
      {"id": "6", "next": null, "value": 6}
    ]
  }
}
Test Case 7 passed!
Expected Output
{
  "head": "12",
  "nodes": [
    {"id": "12", "next": "11", "value": 12},
    {"id": "11", "next": "10", "value": 11},
    {"id": "10", "next": "9", "value": 10},
    {"id": "9", "next": "8", "value": 9},
    {"id": "8", "next": "7", "value": 8},
    {"id": "7", "next": "6", "value": 7},
    {"id": "6", "next": "5", "value": 6},
    {"id": "5", "next": "4", "value": 5},
    {"id": "4", "next": "3", "value": 4},
    {"id": "3", "next": "2", "value": 3},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "0", "value": 1},
    {"id": "0", "next": null, "value": 0}
  ]
}
Your Code's Output
{
  "head": "12",
  "nodes": [
    {"id": "12", "next": "11", "value": 12},
    {"id": "11", "next": "10", "value": 11},
    {"id": "10", "next": "9", "value": 10},
    {"id": "9", "next": "8", "value": 9},
    {"id": "8", "next": "7", "value": 8},
    {"id": "7", "next": "6", "value": 7},
    {"id": "6", "next": "5", "value": 6},
    {"id": "5", "next": "4", "value": 5},
    {"id": "4", "next": "3", "value": 4},
    {"id": "3", "next": "2", "value": 3},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "0", "value": 1},
    {"id": "0", "next": null, "value": 0}
  ]
}
View Outputs Side By Side
Input(s)
{
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
      {"id": "9", "next": "10", "value": 9},
      {"id": "10", "next": "11", "value": 10},
      {"id": "11", "next": "12", "value": 11},
      {"id": "12", "next": null, "value": 12}
    ]
  }
}
 */