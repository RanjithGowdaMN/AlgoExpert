using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList._03_Very_Hard
{
    internal class NodeSwap
    {
    }
}
/*
 
using System.Collections.Generic;
using System.Linq;
using System;

public class ProgramTest {
  public Program.LinkedList addMany(Program.LinkedList ll, List<int> values) {
    Program.LinkedList current = ll;
    while (current.next != null) {
      current = current.next;
    }
    foreach (var value in values) {
      current.next = new Program.LinkedList(value);
      current = current.next;
    }
    return ll;
  }

  public List<int> getNodesInArray(Program.LinkedList ll) {
    List<int> nodes = new List<int>();
    Program.LinkedList current = ll;
    while (current != null) {
      nodes.Add(current.value);
      current = current.next;
    }
    return nodes;
  }

  [Test]
  public void TestCase1() {
    Program.LinkedList linkedList = new Program.LinkedList(0);
    addMany(linkedList, new List<int> { 1, 2, 3, 4, 5 });
    List<int> expectedNodes = new List<int> { 1, 0, 3, 2, 5, 4 };
    var actual = new Program().NodeSwap(linkedList);
    Utils.AssertTrue(
      Enumerable.SequenceEqual(getNodesInArray(actual), expectedNodes)
    );
  }
}


10 / 10 test cases passed.

Test Case 1 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "0", "value": 1},
    {"id": "0", "next": "3", "value": 0},
    {"id": "3", "next": "2", "value": 3},
    {"id": "2", "next": "5", "value": 2},
    {"id": "5", "next": "4", "value": 5},
    {"id": "4", "next": null, "value": 4}
  ]
}
Our Code's Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "0", "value": 1},
    {"id": "0", "next": "3", "value": 0},
    {"id": "3", "next": "2", "value": 3},
    {"id": "2", "next": "5", "value": 2},
    {"id": "5", "next": "4", "value": 5},
    {"id": "4", "next": null, "value": 4}
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
Our Code's Output
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
  "head": "10",
  "nodes": [
    {"id": "10", "next": "5", "value": 10},
    {"id": "5", "next": "20", "value": 5},
    {"id": "20", "next": "15", "value": 20},
    {"id": "15", "next": "30", "value": 15},
    {"id": "30", "next": "25", "value": 30},
    {"id": "25", "next": null, "value": 25}
  ]
}
Our Code's Output
{
  "head": "10",
  "nodes": [
    {"id": "10", "next": "5", "value": 10},
    {"id": "5", "next": "20", "value": 5},
    {"id": "20", "next": "15", "value": 20},
    {"id": "15", "next": "30", "value": 15},
    {"id": "30", "next": "25", "value": 30},
    {"id": "25", "next": null, "value": 25}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "5",
    "nodes": [
      {"id": "5", "next": "10", "value": 5},
      {"id": "10", "next": "15", "value": 10},
      {"id": "15", "next": "20", "value": 15},
      {"id": "20", "next": "25", "value": 20},
      {"id": "25", "next": "30", "value": 25},
      {"id": "30", "next": null, "value": 30}
    ]
  }
}
Test Case 5 passed!
Expected Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "1", "value": 3},
    {"id": "1", "next": "6", "value": 1},
    {"id": "6", "next": "9", "value": 6},
    {"id": "9", "next": "4", "value": 9},
    {"id": "4", "next": "20", "value": 4},
    {"id": "20", "next": null, "value": 20}
  ]
}
Our Code's Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "1", "value": 3},
    {"id": "1", "next": "6", "value": 1},
    {"id": "6", "next": "9", "value": 6},
    {"id": "9", "next": "4", "value": 9},
    {"id": "4", "next": "20", "value": 4},
    {"id": "20", "next": null, "value": 20}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "3", "value": 1},
      {"id": "3", "next": "9", "value": 3},
      {"id": "9", "next": "6", "value": 9},
      {"id": "6", "next": "20", "value": 6},
      {"id": "20", "next": "4", "value": 20},
      {"id": "4", "next": null, "value": 4}
    ]
  }
}
Test Case 6 passed!
Expected Output
{
  "head": "4",
  "nodes": [
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "2", "value": 5},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "0", "value": 3},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": null, "value": 1}
  ]
}
Our Code's Output
{
  "head": "4",
  "nodes": [
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "2", "value": 5},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "0", "value": 3},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": null, "value": 1}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
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
}
Test Case 7 passed!
Expected Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "4", "value": 1},
    {"id": "4", "next": "3", "value": 4},
    {"id": "3", "next": "6", "value": 3},
    {"id": "6", "next": "5", "value": 6},
    {"id": "5", "next": "8", "value": 5},
    {"id": "8", "next": "7", "value": 8},
    {"id": "7", "next": "10", "value": 7},
    {"id": "10", "next": "9", "value": 10},
    {"id": "9", "next": "12", "value": 9},
    {"id": "12", "next": "11", "value": 12},
    {"id": "11", "next": "14", "value": 11},
    {"id": "14", "next": "13", "value": 14},
    {"id": "13", "next": "15", "value": 13},
    {"id": "15", "next": null, "value": 15}
  ]
}
Our Code's Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": "1", "value": 2},
    {"id": "1", "next": "4", "value": 1},
    {"id": "4", "next": "3", "value": 4},
    {"id": "3", "next": "6", "value": 3},
    {"id": "6", "next": "5", "value": 6},
    {"id": "5", "next": "8", "value": 5},
    {"id": "8", "next": "7", "value": 8},
    {"id": "7", "next": "10", "value": 7},
    {"id": "10", "next": "9", "value": 10},
    {"id": "9", "next": "12", "value": 9},
    {"id": "12", "next": "11", "value": 12},
    {"id": "11", "next": "14", "value": 11},
    {"id": "14", "next": "13", "value": 14},
    {"id": "13", "next": "15", "value": 13},
    {"id": "15", "next": null, "value": 15}
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
      {"id": "11", "next": "12", "value": 11},
      {"id": "12", "next": "13", "value": 12},
      {"id": "13", "next": "14", "value": 13},
      {"id": "14", "next": "15", "value": 14},
      {"id": "15", "next": null, "value": 15}
    ]
  }
}
Test Case 8 passed!
Expected Output
{
  "head": "20",
  "nodes": [
    {"id": "20", "next": "10", "value": 20},
    {"id": "10", "next": "30", "value": 10},
    {"id": "30", "next": null, "value": 30}
  ]
}
Our Code's Output
{
  "head": "20",
  "nodes": [
    {"id": "20", "next": "10", "value": 20},
    {"id": "10", "next": "30", "value": 10},
    {"id": "30", "next": null, "value": 30}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "10",
    "nodes": [
      {"id": "10", "next": "20", "value": 10},
      {"id": "20", "next": "30", "value": 20},
      {"id": "30", "next": null, "value": 30}
    ]
  }
}
Test Case 9 passed!
Expected Output
{
  "head": "10",
  "nodes": [
    {"id": "10", "next": "30", "value": 10},
    {"id": "30", "next": "20", "value": 30},
    {"id": "20", "next": null, "value": 20}
  ]
}
Our Code's Output
{
  "head": "10",
  "nodes": [
    {"id": "10", "next": "30", "value": 10},
    {"id": "30", "next": "20", "value": 30},
    {"id": "20", "next": null, "value": 20}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "30",
    "nodes": [
      {"id": "30", "next": "10", "value": 30},
      {"id": "10", "next": "20", "value": 10},
      {"id": "20", "next": null, "value": 20}
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
    {"id": "9", "next": "10", "value": 9},
    {"id": "10", "next": null, "value": 10}
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
    {"id": "9", "next": "10", "value": 9},
    {"id": "10", "next": null, "value": 10}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "2",
    "nodes": [
      {"id": "2", "next": "1", "value": 2},
      {"id": "1", "next": "4", "value": 1},
      {"id": "4", "next": "3", "value": 4},
      {"id": "3", "next": "6", "value": 3},
      {"id": "6", "next": "5", "value": 6},
      {"id": "5", "next": "8", "value": 5},
      {"id": "8", "next": "7", "value": 8},
      {"id": "7", "next": "10", "value": 7},
      {"id": "10", "next": "9", "value": 10},
      {"id": "9", "next": null, "value": 9}
    ]
  }
}
 
 */