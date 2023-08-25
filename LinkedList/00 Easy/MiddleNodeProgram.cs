using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList._00_Easy
{
    
    class MiddleNodeProgram
    {
        public static void Main()
        {

        }
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

        public LinkedList MiddleNode(LinkedList linkedList)
        {
            // Write your code here.
            LinkedList slowNode = linkedList;
            LinkedList fastNode = linkedList;

            while (fastNode != null && fastNode.next != null)
            {
                slowNode = slowNode.next;
                fastNode = fastNode.next.next;
            }

            return slowNode;
        }
    }
}

/*
 * 
using System.Collections.Generic;
using System.Linq;
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Program.LinkedList linkedList = new Program.LinkedList(1);
    Program.LinkedList curr = linkedList;
    for (int i = 1; i < 4; i++) {
      curr.next = new Program.LinkedList(i);
      curr = curr.next;
    }

    List<int> expected = new List<int> { 2, 3 };
    var actual = new Program().MiddleNode(linkedList);
    Utils.AssertTrue(Enumerable.SequenceEqual(expected, toList(actual)));
  }

  private List<int> toList(Program.LinkedList linkedList) {
    List<int> list = new List<int>();
    Program.LinkedList curr = linkedList;
    while (curr != null) {
      list.Add(curr.value);
      curr = curr.next;
    }
    return list;
  }
}



 10 / 10 test cases passed.

Test Case 1 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": null, "value": 1}
  ]
}
Your Code's Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": null, "value": 1}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": null, "value": 1}
    ]
  }
}
Test Case 2 passed!
Expected Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": null, "value": 3}
  ]
}
Your Code's Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": null, "value": 3}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": null, "value": 3}
    ]
  }
}
Test Case 3 passed!
Expected Output
{
  "head": "7",
  "nodes": [
    {"id": "7", "next": "9", "value": 7},
    {"id": "9", "next": null, "value": 9}
  ]
}
Your Code's Output
{
  "head": "7",
  "nodes": [
    {"id": "7", "next": "9", "value": 7},
    {"id": "9", "next": null, "value": 9}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "5",
    "nodes": [
      {"id": "5", "next": "7", "value": 5},
      {"id": "7", "next": "9", "value": 7},
      {"id": "9", "next": null, "value": 9}
    ]
  }
}
Test Case 4 passed!
Expected Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": null, "value": 4}
  ]
}
Your Code's Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": null, "value": 4}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": null, "value": 4}
    ]
  }
}
Test Case 5 passed!
Expected Output
{
  "head": "5",
  "nodes": [
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": null, "value": 9}
  ]
}
Your Code's Output
{
  "head": "5",
  "nodes": [
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
  "linkedList": {
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
}
Test Case 6 passed!
Expected Output
{
  "head": "6",
  "nodes": [
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "10", "value": 9},
    {"id": "10", "next": null, "value": 10}
  ]
}
Your Code's Output
{
  "head": "6",
  "nodes": [
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
  "linkedList": {
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
}
Test Case 7 passed!
Expected Output
{
  "head": "5",
  "nodes": [
    {"id": "5", "next": "9", "value": 5},
    {"id": "9", "next": "10", "value": 9},
    {"id": "10", "next": null, "value": 10}
  ]
}
Your Code's Output
{
  "head": "5",
  "nodes": [
    {"id": "5", "next": "9", "value": 5},
    {"id": "9", "next": "10", "value": 9},
    {"id": "10", "next": null, "value": 10}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
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
Test Case 8 passed!
Expected Output
{
  "head": "5",
  "nodes": [
    {"id": "5", "next": "5-2", "value": 5},
    {"id": "5-2", "next": "5-3", "value": 5},
    {"id": "5-3", "next": "5-4", "value": 5},
    {"id": "5-4", "next": "10", "value": 5},
    {"id": "10", "next": null, "value": 10}
  ]
}
Your Code's Output
{
  "head": "5",
  "nodes": [
    {"id": "5", "next": "5-2", "value": 5},
    {"id": "5-2", "next": "5-3", "value": 5},
    {"id": "5-3", "next": "5-4", "value": 5},
    {"id": "5-4", "next": "10", "value": 5},
    {"id": "10", "next": null, "value": 10}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
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
  }
}
Test Case 9 passed!
Expected Output
{
  "head": "5",
  "nodes": [
    {"id": "5", "next": "5-2", "value": 5},
    {"id": "5-2", "next": "7", "value": 5},
    {"id": "7", "next": "10", "value": 7},
    {"id": "10", "next": null, "value": 10}
  ]
}
Your Code's Output
{
  "head": "5",
  "nodes": [
    {"id": "5", "next": "5-2", "value": 5},
    {"id": "5-2", "next": "7", "value": 5},
    {"id": "7", "next": "10", "value": 7},
    {"id": "10", "next": null, "value": 10}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "1-2", "value": 2},
      {"id": "1-2", "next": "4", "value": 1},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "5-2", "value": 5},
      {"id": "5-2", "next": "7", "value": 5},
      {"id": "7", "next": "10", "value": 7},
      {"id": "10", "next": null, "value": 10}
    ]
  }
}
Test Case 10 passed!
Expected Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "5-2", "value": 5},
    {"id": "5-2", "next": "7", "value": 5},
    {"id": "7", "next": "10", "value": 7},
    {"id": "10", "next": null, "value": 10}
  ]
}
Your Code's Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "5-2", "value": 5},
    {"id": "5-2", "next": "7", "value": 5},
    {"id": "7", "next": "10", "value": 7},
    {"id": "10", "next": null, "value": 10}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "1-2", "value": 1},
      {"id": "1-2", "next": "1-3", "value": 1},
      {"id": "1-3", "next": "1-4", "value": 1},
      {"id": "1-4", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "5-2", "value": 5},
      {"id": "5-2", "next": "7", "value": 5},
      {"id": "7", "next": "10", "value": 7},
      {"id": "10", "next": null, "value": 10}
    ]
  }
}
 
 */