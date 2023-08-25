using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList._03_Very_Hard
{
    internal class ZipLinkedList
    {
    }
}
/*
 using System.Collections.Generic;
using System.Linq;
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var head = new Program.LinkedList(1);
    addMany(head, new int[] { 2, 3, 4, 5, 6 });
    List<int> expected = new List<int> { 1, 6, 2, 5, 3, 4 };
    var actual = getNodesInArray(new Program().ZipLinkedList(head));
    Utils.AssertTrue(Enumerable.SequenceEqual(expected, actual));
  }

  public List<int> getNodesInArray(Program.LinkedList linkedList) {
    var nodes = new List<int>();
    var current = linkedList;
    while (current != null) {
      nodes.Add(current.value);
      current = current.next;
    }
    return nodes;
  }

  public void addMany(Program.LinkedList head, int[] values) {
    Program.LinkedList current = head;
    while (current.next != null) {
      current = current.next;
    }
    foreach (var value in values) {
      current.next = new Program.LinkedList(value);
      current = current.next;
    }
  }
}


10 / 10 test cases passed.

Test Case 1 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "6", "value": 1},
    {"id": "6", "next": "2", "value": 6},
    {"id": "2", "next": "5", "value": 2},
    {"id": "5", "next": "3", "value": 5},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": null, "value": 4}
  ]
}
Our Code's Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "6", "value": 1},
    {"id": "6", "next": "2", "value": 6},
    {"id": "2", "next": "5", "value": 2},
    {"id": "5", "next": "3", "value": 5},
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
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "6", "value": 5},
      {"id": "6", "next": null, "value": 6}
    ]
  }
}
Test Case 2 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "7", "value": 1},
    {"id": "7", "next": "2", "value": 7},
    {"id": "2", "next": "6", "value": 2},
    {"id": "6", "next": "3", "value": 6},
    {"id": "3", "next": "5", "value": 3},
    {"id": "5", "next": "4", "value": 5},
    {"id": "4", "next": null, "value": 4}
  ]
}
Our Code's Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "7", "value": 1},
    {"id": "7", "next": "2", "value": 7},
    {"id": "2", "next": "6", "value": 2},
    {"id": "6", "next": "3", "value": 6},
    {"id": "3", "next": "5", "value": 3},
    {"id": "5", "next": "4", "value": 5},
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
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "6", "value": 5},
      {"id": "6", "next": "7", "value": 6},
      {"id": "7", "next": null, "value": 7}
    ]
  }
}
Test Case 3 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "3", "value": 1},
    {"id": "3", "next": "2", "value": 3},
    {"id": "2", "next": null, "value": 2}
  ]
}
Our Code's Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "3", "value": 1},
    {"id": "3", "next": "2", "value": 3},
    {"id": "2", "next": null, "value": 2}
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
Test Case 4 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": null, "value": 2}
  ]
}
Our Code's Output
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
  "linkedList": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": null, "value": 2}
    ]
  }
}
Test Case 5 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": null, "value": 1}
  ]
}
Our Code's Output
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
Test Case 6 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "9", "value": 1},
    {"id": "9", "next": "2", "value": 9},
    {"id": "2", "next": "8", "value": 2},
    {"id": "8", "next": "3", "value": 8},
    {"id": "3", "next": "7", "value": 3},
    {"id": "7", "next": "4", "value": 7},
    {"id": "4", "next": "6", "value": 4},
    {"id": "6", "next": "5", "value": 6},
    {"id": "5", "next": null, "value": 5}
  ]
}
Our Code's Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "9", "value": 1},
    {"id": "9", "next": "2", "value": 9},
    {"id": "2", "next": "8", "value": 2},
    {"id": "8", "next": "3", "value": 8},
    {"id": "3", "next": "7", "value": 3},
    {"id": "7", "next": "4", "value": 7},
    {"id": "4", "next": "6", "value": 4},
    {"id": "6", "next": "5", "value": 6},
    {"id": "5", "next": null, "value": 5}
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
Test Case 7 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "10", "value": 1},
    {"id": "10", "next": "2", "value": 10},
    {"id": "2", "next": "9", "value": 2},
    {"id": "9", "next": "3", "value": 9},
    {"id": "3", "next": "8", "value": 3},
    {"id": "8", "next": "4", "value": 8},
    {"id": "4", "next": "7", "value": 4},
    {"id": "7", "next": "5", "value": 7},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": null, "value": 6}
  ]
}
Our Code's Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "10", "value": 1},
    {"id": "10", "next": "2", "value": 10},
    {"id": "2", "next": "9", "value": 2},
    {"id": "9", "next": "3", "value": 9},
    {"id": "3", "next": "8", "value": 3},
    {"id": "8", "next": "4", "value": 8},
    {"id": "4", "next": "7", "value": 4},
    {"id": "7", "next": "5", "value": 7},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": null, "value": 6}
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
Test Case 8 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "11", "value": 1},
    {"id": "11", "next": "2", "value": 11},
    {"id": "2", "next": "10", "value": 2},
    {"id": "10", "next": "3", "value": 10},
    {"id": "3", "next": "9", "value": 3},
    {"id": "9", "next": "4", "value": 9},
    {"id": "4", "next": "8", "value": 4},
    {"id": "8", "next": "5", "value": 8},
    {"id": "5", "next": "7", "value": 5},
    {"id": "7", "next": "6", "value": 7},
    {"id": "6", "next": null, "value": 6}
  ]
}
Our Code's Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "11", "value": 1},
    {"id": "11", "next": "2", "value": 11},
    {"id": "2", "next": "10", "value": 2},
    {"id": "10", "next": "3", "value": 10},
    {"id": "3", "next": "9", "value": 3},
    {"id": "9", "next": "4", "value": 9},
    {"id": "4", "next": "8", "value": 4},
    {"id": "8", "next": "5", "value": 8},
    {"id": "5", "next": "7", "value": 5},
    {"id": "7", "next": "6", "value": 7},
    {"id": "6", "next": null, "value": 6}
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
      {"id": "10", "next": "11", "value": 10},
      {"id": "11", "next": null, "value": 11}
    ]
  }
}
Test Case 9 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "99", "value": 1},
    {"id": "99", "next": "-6", "value": 99},
    {"id": "-6", "next": "-100", "value": -6},
    {"id": "-100", "next": "8", "value": -100},
    {"id": "8", "next": "11", "value": 8},
    {"id": "11", "next": "5", "value": 11},
    {"id": "5", "next": "2", "value": 5},
    {"id": "2", "next": "10", "value": 2},
    {"id": "10", "next": "0", "value": 10},
    {"id": "0", "next": "-1", "value": 0},
    {"id": "-1", "next": null, "value": -1}
  ]
}
Our Code's Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "99", "value": 1},
    {"id": "99", "next": "-6", "value": 99},
    {"id": "-6", "next": "-100", "value": -6},
    {"id": "-100", "next": "8", "value": -100},
    {"id": "8", "next": "11", "value": 8},
    {"id": "11", "next": "5", "value": 11},
    {"id": "5", "next": "2", "value": 5},
    {"id": "2", "next": "10", "value": 2},
    {"id": "10", "next": "0", "value": 10},
    {"id": "0", "next": "-1", "value": 0},
    {"id": "-1", "next": null, "value": -1}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "-6", "value": 1},
      {"id": "-6", "next": "8", "value": -6},
      {"id": "8", "next": "5", "value": 8},
      {"id": "5", "next": "10", "value": 5},
      {"id": "10", "next": "-1", "value": 10},
      {"id": "-1", "next": "0", "value": -1},
      {"id": "0", "next": "2", "value": 0},
      {"id": "2", "next": "11", "value": 2},
      {"id": "11", "next": "-100", "value": 11},
      {"id": "-100", "next": "99", "value": -100},
      {"id": "99", "next": null, "value": 99}
    ]
  }
}
Test Case 10 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "50", "value": 1},
    {"id": "50", "next": "-6", "value": 50},
    {"id": "-6", "next": "99", "value": -6},
    {"id": "99", "next": "8", "value": 99},
    {"id": "8", "next": "-100", "value": 8},
    {"id": "-100", "next": "5", "value": -100},
    {"id": "5", "next": "11", "value": 5},
    {"id": "11", "next": "10", "value": 11},
    {"id": "10", "next": "2", "value": 10},
    {"id": "2", "next": "-1", "value": 2},
    {"id": "-1", "next": "0", "value": -1},
    {"id": "0", "next": null, "value": 0}
  ]
}
Our Code's Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "50", "value": 1},
    {"id": "50", "next": "-6", "value": 50},
    {"id": "-6", "next": "99", "value": -6},
    {"id": "99", "next": "8", "value": 99},
    {"id": "8", "next": "-100", "value": 8},
    {"id": "-100", "next": "5", "value": -100},
    {"id": "5", "next": "11", "value": 5},
    {"id": "11", "next": "10", "value": 11},
    {"id": "10", "next": "2", "value": 10},
    {"id": "2", "next": "-1", "value": 2},
    {"id": "-1", "next": "0", "value": -1},
    {"id": "0", "next": null, "value": 0}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "-6", "value": 1},
      {"id": "-6", "next": "8", "value": -6},
      {"id": "8", "next": "5", "value": 8},
      {"id": "5", "next": "10", "value": 5},
      {"id": "10", "next": "-1", "value": 10},
      {"id": "-1", "next": "0", "value": -1},
      {"id": "0", "next": "2", "value": 0},
      {"id": "2", "next": "11", "value": 2},
      {"id": "11", "next": "-100", "value": 11},
      {"id": "-100", "next": "99", "value": -100},
      {"id": "99", "next": "50", "value": 99},
      {"id": "50", "next": null, "value": 50}
    ]
  }
}
 
 */