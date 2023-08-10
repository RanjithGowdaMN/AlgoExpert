using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList._02_Hard
{

	public class mergeLinkedListProgram
	{
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

        public static LinkedList mergeLinkedLists(
          LinkedList headOne, LinkedList headTwo
        )
        {
            // Write your code here.
            LinkedList p1 = headOne;
            LinkedList p1Prev = null;
            LinkedList p2 = headTwo;

            while (p1 != null && p2 != null)
            {
                if (p1.value < p2.value)
                {
                    p1Prev = p1;
                    p1 = p1.next;
                }
                else
                {
                    if (p1Prev != null)
                    {
                        p1Prev.next = p2;
                    }
                    p1Prev = p2;
                    p2 = p2.next;
                    p1Prev.next = p1;
                }
            }
            if (p1 == null) p1Prev.next = p2;
            return headOne.value < headTwo.value ? headOne : headTwo;
        }
    }
}
/*
    
 using System.Linq;
using System.Collections.Generic;

public class ProgramTest {
  public class TestLinkedList : Program.LinkedList {
    public TestLinkedList(int val) : base(val) {}

    public TestLinkedList addMany(List<int> values) {
      TestLinkedList current = this;
      while (current.next != null) {
        current = (TestLinkedList)current.next;
      }
      foreach (int value in values) {
        current.next = new TestLinkedList(value);
        current = (TestLinkedList)current.next;
      }
      return this;
    }

    public List<int> getNodesInArray() {
      List<int> nodes = new List<int>();
      TestLinkedList current = this;
      while (current != null) {
        nodes.Add(current.value);
        current = (TestLinkedList)current.next;
      }
      return nodes;
    }
  }

  [Test]
  public void TestCase1() {
    TestLinkedList list1 = new TestLinkedList(2);
    list1.addMany(new List<int>() { 6, 7, 8 });
    TestLinkedList list2 = new TestLinkedList(1);
    list2.addMany(new List<int>() { 3, 4, 5, 9, 10 });
    TestLinkedList output =
      (TestLinkedList)Program.mergeLinkedLists(list1, list2);
    List<int> expectedNodes = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    Utils.AssertTrue(output.getNodesInArray().SequenceEqual(expectedNodes));
  }
}


Test Case 1 passed!
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
    {"id": "9", "next": "10", "value": 9},
    {"id": "10", "next": null, "value": 10}
  ]
}
Your Code's Output
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
    {"id": "9", "next": "10", "value": 9},
    {"id": "10", "next": null, "value": 10}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedListOne": {
    "head": "2",
    "nodes": [
      {"id": "2", "next": "6", "value": 2},
      {"id": "6", "next": "7", "value": 6},
      {"id": "7", "next": "8", "value": 7},
      {"id": "8", "next": null, "value": 8}
    ]
  },
  "linkedListTwo": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "3", "value": 1},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "9", "value": 5},
      {"id": "9", "next": "10", "value": 9},
      {"id": "10", "next": null, "value": 10}
    ]
  }
}
Test Case 2 passed!
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
    {"id": "9", "next": "10", "value": 9},
    {"id": "10", "next": null, "value": 10}
  ]
}
Your Code's Output
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
    {"id": "9", "next": "10", "value": 9},
    {"id": "10", "next": null, "value": 10}
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
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": null, "value": 5}
    ]
  },
  "linkedListTwo": {
    "head": "6",
    "nodes": [
      {"id": "6", "next": "7", "value": 6},
      {"id": "7", "next": "8", "value": 7},
      {"id": "8", "next": "9", "value": 8},
      {"id": "9", "next": "10", "value": 9},
      {"id": "10", "next": null, "value": 10}
    ]
  }
}
Test Case 3 passed!
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
    {"id": "9", "next": "10", "value": 9},
    {"id": "10", "next": null, "value": 10}
  ]
}
Your Code's Output
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
    {"id": "9", "next": "10", "value": 9},
    {"id": "10", "next": null, "value": 10}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedListOne": {
    "head": "6",
    "nodes": [
      {"id": "6", "next": "7", "value": 6},
      {"id": "7", "next": "8", "value": 7},
      {"id": "8", "next": "9", "value": 8},
      {"id": "9", "next": "10", "value": 9},
      {"id": "10", "next": null, "value": 10}
    ]
  },
  "linkedListTwo": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": null, "value": 5}
    ]
  }
}
Test Case 4 passed!
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
    {"id": "9", "next": "10", "value": 9},
    {"id": "10", "next": null, "value": 10}
  ]
}
Your Code's Output
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
    {"id": "9", "next": "10", "value": 9},
    {"id": "10", "next": null, "value": 10}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedListOne": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "3", "value": 1},
      {"id": "3", "next": "5", "value": 3},
      {"id": "5", "next": "7", "value": 5},
      {"id": "7", "next": "9", "value": 7},
      {"id": "9", "next": null, "value": 9}
    ]
  },
  "linkedListTwo": {
    "head": "2",
    "nodes": [
      {"id": "2", "next": "4", "value": 2},
      {"id": "4", "next": "6", "value": 4},
      {"id": "6", "next": "8", "value": 6},
      {"id": "8", "next": "10", "value": 8},
      {"id": "10", "next": null, "value": 10}
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
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "10", "value": 9},
    {"id": "10", "next": null, "value": 10}
  ]
}
Your Code's Output
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
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "10", "value": 9},
    {"id": "10", "next": null, "value": 10}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedListOne": {
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
      {"id": "9", "next": "10", "value": 9},
      {"id": "10", "next": null, "value": 10}
    ]
  },
  "linkedListTwo": {
    "head": "6",
    "nodes": [
      {"id": "6", "next": null, "value": 6}
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
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "10", "value": 9},
    {"id": "10", "next": null, "value": 10}
  ]
}
Your Code's Output
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
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "10", "value": 9},
    {"id": "10", "next": null, "value": 10}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedListOne": {
    "head": "6",
    "nodes": [
      {"id": "6", "next": null, "value": 6}
    ]
  },
  "linkedListTwo": {
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
      {"id": "9", "next": "10", "value": 9},
      {"id": "10", "next": null, "value": 10}
    ]
  }
}
Test Case 7 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": null, "value": 2}
  ]
}
Your Code's Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": null, "value": 2}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedListOne": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": null, "value": 1}
    ]
  },
  "linkedListTwo": {
    "head": "2",
    "nodes": [
      {"id": "2", "next": null, "value": 2}
    ]
  }
}
Test Case 8 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": null, "value": 2}
  ]
}
Your Code's Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": null, "value": 2}
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
    "head": "1",
    "nodes": [
      {"id": "1", "next": null, "value": 1}
    ]
  }
}
Test Case 9 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "1-2", "value": 1},
    {"id": "1-2", "next": "1-3", "value": 1},
    {"id": "1-3", "next": "1-4", "value": 1},
    {"id": "1-4", "next": "1-5", "value": 1},
    {"id": "1-5", "next": "2", "value": 1},
    {"id": "2", "next": "2-2", "value": 2},
    {"id": "2-2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "5-2", "value": 5},
    {"id": "5-2", "next": "5-3", "value": 5},
    {"id": "5-3", "next": "5-4", "value": 5},
    {"id": "5-4", "next": "5-5", "value": 5},
    {"id": "5-5", "next": "6", "value": 5},
    {"id": "6", "next": "10", "value": 6},
    {"id": "10", "next": "10-2", "value": 10},
    {"id": "10-2", "next": "10-3", "value": 10},
    {"id": "10-3", "next": null, "value": 10}
  ]
}
Your Code's Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "1-2", "value": 1},
    {"id": "1-2", "next": "1-3", "value": 1},
    {"id": "1-3", "next": "1-4", "value": 1},
    {"id": "1-4", "next": "1-5", "value": 1},
    {"id": "1-5", "next": "2", "value": 1},
    {"id": "2", "next": "2-2", "value": 2},
    {"id": "2-2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "5-2", "value": 5},
    {"id": "5-2", "next": "5-3", "value": 5},
    {"id": "5-3", "next": "5-4", "value": 5},
    {"id": "5-4", "next": "5-5", "value": 5},
    {"id": "5-5", "next": "6", "value": 5},
    {"id": "6", "next": "10", "value": 6},
    {"id": "10", "next": "10-2", "value": 10},
    {"id": "10-2", "next": "10-3", "value": 10},
    {"id": "10-3", "next": null, "value": 10}
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
      {"id": "1-3", "next": "3", "value": 1},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "5-2", "value": 5},
      {"id": "5-2", "next": "5-3", "value": 5},
      {"id": "5-3", "next": "5-4", "value": 5},
      {"id": "5-4", "next": "10", "value": 5},
      {"id": "10", "next": null, "value": 10}
    ]
  },
  "linkedListTwo": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "1-2", "value": 1},
      {"id": "1-2", "next": "2", "value": 1},
      {"id": "2", "next": "2-2", "value": 2},
      {"id": "2-2", "next": "5", "value": 2},
      {"id": "5", "next": "6", "value": 5},
      {"id": "6", "next": "10", "value": 6},
      {"id": "10", "next": "10-2", "value": 10},
      {"id": "10-2", "next": null, "value": 10}
    ]
  }
}   
 
 */