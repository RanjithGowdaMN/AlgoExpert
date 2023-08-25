using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList._03_Very_Hard
{
    internal class RearrangeLinkedList
    {
    }
}
/*
 
using System;
using System.Linq;
using System.Collections.Generic;

public class ProgramTest {
  public List<int> linkedListToArray(Program.LinkedList head) {
    var array = new List<int>();
    var current = head;
    while (current != null) {
      array.Add(current.value);
      current = current.next;
    }
    return array;
  }

  [Test]
  public void TestCase1() {
    var head = new Program.LinkedList(3);
    head.next = new Program.LinkedList(0);
    head.next.next = new Program.LinkedList(5);
    head.next.next.next = new Program.LinkedList(2);
    head.next.next.next.next = new Program.LinkedList(1);
    head.next.next.next.next.next = new Program.LinkedList(4);
    var result = Program.RearrangeLinkedList(head, 3);
    var array = this.linkedListToArray(result);

    var expected = new List<int> { 0, 2, 1, 3, 5, 4 };
    Utils.AssertTrue(Enumerable.SequenceEqual(expected, array));
  }
}


11 / 11 test cases passed.

Test Case 1 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "2", "value": 0},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "3", "value": 1},
    {"id": "3", "next": "5", "value": 3},
    {"id": "5", "next": "4", "value": 5},
    {"id": "4", "next": null, "value": 4}
  ]
}
Our Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "2", "value": 0},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "3", "value": 1},
    {"id": "3", "next": "5", "value": 3},
    {"id": "5", "next": "4", "value": 5},
    {"id": "4", "next": null, "value": 4}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 3,
  "linkedList": {
    "head": "3",
    "nodes": [
      {"id": "3", "next": "0", "value": 3},
      {"id": "0", "next": "5", "value": 0},
      {"id": "5", "next": "2", "value": 5},
      {"id": "2", "next": "1", "value": 2},
      {"id": "1", "next": "4", "value": 1},
      {"id": "4", "next": null, "value": 4}
    ]
  }
}
Test Case 2 passed!
Expected Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "0", "value": 3},
    {"id": "0", "next": "2", "value": 0},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "4", "value": 1},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": null, "value": 5}
  ]
}
Our Code's Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "0", "value": 3},
    {"id": "0", "next": "2", "value": 0},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "4", "value": 1},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": null, "value": 5}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 4,
  "linkedList": {
    "head": "3",
    "nodes": [
      {"id": "3", "next": "0", "value": 3},
      {"id": "0", "next": "2", "value": 0},
      {"id": "2", "next": "1", "value": 2},
      {"id": "1", "next": "4", "value": 1},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": null, "value": 5}
    ]
  }
}
Test Case 3 passed!
Expected Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "0", "value": 3},
    {"id": "0", "next": "2", "value": 0},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "4", "value": 1},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": null, "value": 5}
  ]
}
Our Code's Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "0", "value": 3},
    {"id": "0", "next": "2", "value": 0},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "4", "value": 1},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": null, "value": 5}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 5,
  "linkedList": {
    "head": "3",
    "nodes": [
      {"id": "3", "next": "0", "value": 3},
      {"id": "0", "next": "2", "value": 0},
      {"id": "2", "next": "1", "value": 2},
      {"id": "1", "next": "4", "value": 1},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": null, "value": 5}
    ]
  }
}
Test Case 4 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "3", "value": 0},
    {"id": "3", "next": "2", "value": 3},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "4", "value": 1},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": null, "value": 5}
  ]
}
Our Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "3", "value": 0},
    {"id": "3", "next": "2", "value": 3},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "4", "value": 1},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": null, "value": 5}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 0,
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "3", "value": 0},
      {"id": "3", "next": "2", "value": 3},
      {"id": "2", "next": "1", "value": 2},
      {"id": "1", "next": "4", "value": 1},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": null, "value": 5}
    ]
  }
}
Test Case 5 passed!
Expected Output
{
  "head": "-9000",
  "nodes": [
    {"id": "-9000", "next": "0", "value": -9000},
    {"id": "0", "next": "3", "value": 0},
    {"id": "3", "next": "2", "value": 3},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "4", "value": 1},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "3-2", "value": 5},
    {"id": "3-2", "next": "-1", "value": 3},
    {"id": "-1", "next": "-2", "value": -1},
    {"id": "-2", "next": "3-3", "value": -2},
    {"id": "3-3", "next": "6", "value": 3},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "3-4", "value": 7},
    {"id": "3-4", "next": "2-2", "value": 3},
    {"id": "2-2", "next": null, "value": 2}
  ]
}
Our Code's Output
{
  "head": "-9000",
  "nodes": [
    {"id": "-9000", "next": "0", "value": -9000},
    {"id": "0", "next": "3", "value": 0},
    {"id": "3", "next": "2", "value": 3},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "4", "value": 1},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "3-2", "value": 5},
    {"id": "3-2", "next": "-1", "value": 3},
    {"id": "-1", "next": "-2", "value": -1},
    {"id": "-2", "next": "3-3", "value": -2},
    {"id": "3-3", "next": "6", "value": 3},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "3-4", "value": 7},
    {"id": "3-4", "next": "2-2", "value": 3},
    {"id": "2-2", "next": null, "value": 2}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": -9000,
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "3", "value": 0},
      {"id": "3", "next": "2", "value": 3},
      {"id": "2", "next": "1", "value": 2},
      {"id": "1", "next": "4", "value": 1},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "3-2", "value": 5},
      {"id": "3-2", "next": "-1", "value": 3},
      {"id": "-1", "next": "-2", "value": -1},
      {"id": "-2", "next": "3-3", "value": -2},
      {"id": "3-3", "next": "6", "value": 3},
      {"id": "6", "next": "7", "value": 6},
      {"id": "7", "next": "3-4", "value": 7},
      {"id": "3-4", "next": "2-2", "value": 3},
      {"id": "2-2", "next": "-9000", "value": 2},
      {"id": "-9000", "next": null, "value": -9000}
    ]
  }
}
Test Case 6 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "-1", "value": 1},
    {"id": "-1", "next": "-2", "value": -1},
    {"id": "-2", "next": "-9000", "value": -2},
    {"id": "-9000", "next": "2", "value": -9000},
    {"id": "2", "next": "2-2", "value": 2},
    {"id": "2-2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "3-2", "value": 5},
    {"id": "3-2", "next": "3-3", "value": 3},
    {"id": "3-3", "next": "6", "value": 3},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "3-4", "value": 7},
    {"id": "3-4", "next": null, "value": 3}
  ]
}
Our Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "-1", "value": 1},
    {"id": "-1", "next": "-2", "value": -1},
    {"id": "-2", "next": "-9000", "value": -2},
    {"id": "-9000", "next": "2", "value": -9000},
    {"id": "2", "next": "2-2", "value": 2},
    {"id": "2-2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "3-2", "value": 5},
    {"id": "3-2", "next": "3-3", "value": 3},
    {"id": "3-3", "next": "6", "value": 3},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "3-4", "value": 7},
    {"id": "3-4", "next": null, "value": 3}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 2,
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "3", "value": 0},
      {"id": "3", "next": "2", "value": 3},
      {"id": "2", "next": "1", "value": 2},
      {"id": "1", "next": "4", "value": 1},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "3-2", "value": 5},
      {"id": "3-2", "next": "-1", "value": 3},
      {"id": "-1", "next": "-2", "value": -1},
      {"id": "-2", "next": "3-3", "value": -2},
      {"id": "3-3", "next": "6", "value": 3},
      {"id": "6", "next": "7", "value": 6},
      {"id": "7", "next": "3-4", "value": 7},
      {"id": "3-4", "next": "2-2", "value": 3},
      {"id": "2-2", "next": "-9000", "value": 2},
      {"id": "-9000", "next": null, "value": -9000}
    ]
  }
}
Test Case 7 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "2", "value": 0},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "-1", "value": 1},
    {"id": "-1", "next": "-2", "value": -1},
    {"id": "-2", "next": "2-2", "value": -2},
    {"id": "2-2", "next": "-9000", "value": 2},
    {"id": "-9000", "next": "3", "value": -9000},
    {"id": "3", "next": "3-2", "value": 3},
    {"id": "3-2", "next": "3-3", "value": 3},
    {"id": "3-3", "next": "3-4", "value": 3},
    {"id": "3-4", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": null, "value": 7}
  ]
}
Our Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "2", "value": 0},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "-1", "value": 1},
    {"id": "-1", "next": "-2", "value": -1},
    {"id": "-2", "next": "2-2", "value": -2},
    {"id": "2-2", "next": "-9000", "value": 2},
    {"id": "-9000", "next": "3", "value": -9000},
    {"id": "3", "next": "3-2", "value": 3},
    {"id": "3-2", "next": "3-3", "value": 3},
    {"id": "3-3", "next": "3-4", "value": 3},
    {"id": "3-4", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": null, "value": 7}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 3,
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "3", "value": 0},
      {"id": "3", "next": "2", "value": 3},
      {"id": "2", "next": "1", "value": 2},
      {"id": "1", "next": "4", "value": 1},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "3-2", "value": 5},
      {"id": "3-2", "next": "-1", "value": 3},
      {"id": "-1", "next": "-2", "value": -1},
      {"id": "-2", "next": "3-3", "value": -2},
      {"id": "3-3", "next": "6", "value": 3},
      {"id": "6", "next": "7", "value": 6},
      {"id": "7", "next": "3-4", "value": 7},
      {"id": "3-4", "next": "2-2", "value": 3},
      {"id": "2-2", "next": "-9000", "value": 2},
      {"id": "-9000", "next": null, "value": -9000}
    ]
  }
}
Test Case 8 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "3-2", "value": 3},
    {"id": "3-2", "next": "3-3", "value": 3},
    {"id": "3-3", "next": "3-4", "value": 3},
    {"id": "3-4", "next": "4", "value": 3},
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
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "3-2", "value": 3},
    {"id": "3-2", "next": "3-3", "value": 3},
    {"id": "3-3", "next": "3-4", "value": 3},
    {"id": "3-4", "next": "4", "value": 3},
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
  "k": 3,
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "1", "value": 0},
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "3-2", "value": 3},
      {"id": "3-2", "next": "3-3", "value": 3},
      {"id": "3-3", "next": "3-4", "value": 3},
      {"id": "3-4", "next": "4", "value": 3},
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
  "head": "3",
  "nodes": [
    {"id": "3", "next": "0", "value": 3},
    {"id": "0", "next": "5", "value": 0},
    {"id": "5", "next": "2", "value": 5},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "4", "value": 1},
    {"id": "4", "next": null, "value": 4}
  ]
}
Our Code's Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "0", "value": 3},
    {"id": "0", "next": "5", "value": 0},
    {"id": "5", "next": "2", "value": 5},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "4", "value": 1},
    {"id": "4", "next": null, "value": 4}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": -1,
  "linkedList": {
    "head": "3",
    "nodes": [
      {"id": "3", "next": "0", "value": 3},
      {"id": "0", "next": "5", "value": 0},
      {"id": "5", "next": "2", "value": 5},
      {"id": "2", "next": "1", "value": 2},
      {"id": "1", "next": "4", "value": 1},
      {"id": "4", "next": null, "value": 4}
    ]
  }
}
Test Case 10 passed!
Expected Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "0", "value": 3},
    {"id": "0", "next": "5", "value": 0},
    {"id": "5", "next": "2", "value": 5},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "4", "value": 1},
    {"id": "4", "next": null, "value": 4}
  ]
}
Our Code's Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "0", "value": 3},
    {"id": "0", "next": "5", "value": 0},
    {"id": "5", "next": "2", "value": 5},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "4", "value": 1},
    {"id": "4", "next": null, "value": 4}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 6,
  "linkedList": {
    "head": "3",
    "nodes": [
      {"id": "3", "next": "0", "value": 3},
      {"id": "0", "next": "5", "value": 0},
      {"id": "5", "next": "2", "value": 5},
      {"id": "2", "next": "1", "value": 2},
      {"id": "1", "next": "4", "value": 1},
      {"id": "4", "next": null, "value": 4}
    ]
  }
}
Test Case 11 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "2", "value": 0},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "6", "value": 1},
    {"id": "6", "next": "5", "value": 6},
    {"id": "5", "next": "4", "value": 5},
    {"id": "4", "next": null, "value": 4}
  ]
}
Our Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "2", "value": 0},
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "6", "value": 1},
    {"id": "6", "next": "5", "value": 6},
    {"id": "5", "next": "4", "value": 5},
    {"id": "4", "next": null, "value": 4}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 3,
  "linkedList": {
    "head": "6",
    "nodes": [
      {"id": "6", "next": "0", "value": 6},
      {"id": "0", "next": "5", "value": 0},
      {"id": "5", "next": "2", "value": 5},
      {"id": "2", "next": "1", "value": 2},
      {"id": "1", "next": "4", "value": 1},
      {"id": "4", "next": null, "value": 4}
    ]
  }
}

 
 */