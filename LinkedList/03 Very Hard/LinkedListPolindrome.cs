using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList._03_Very_Hard
{
    internal class LinkedListPolindromeProgram
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

        public bool LinkedListPalindrome(LinkedList head)
        {
            // Write your code here.
            LinkedList slowNode = head;
            LinkedList fastNode = head;

            while (fastNode != null && fastNode.next != null)
            {
                slowNode = slowNode.next;
                fastNode = fastNode.next.next;
            }

            LinkedList reverseSecondHalfNode = reverseLinkedList(slowNode);
            LinkedList firstHalfNode = head;

            while (reverseSecondHalfNode != null)
            {
                if (reverseSecondHalfNode.value != firstHalfNode.value) return false;
                reverseSecondHalfNode = reverseSecondHalfNode.next;
                firstHalfNode = firstHalfNode.next;
            }
            return true;
        }
        public static LinkedList reverseLinkedList(LinkedList head)
        {
            LinkedList previousNode = null;
            LinkedList currentNode = head;

            while (currentNode != null)
            {
                LinkedList nextNode = currentNode.next;
                currentNode.next = previousNode;
                previousNode = currentNode;
                currentNode = nextNode;
            }
            return previousNode;
        }
    }
}
/*
 using System.Collections.Generic;
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var head = new Program.LinkedList(0);
    head.next = new Program.LinkedList(1);
    head.next.next = new Program.LinkedList(2);
    head.next.next.next = new Program.LinkedList(2);
    head.next.next.next.next = new Program.LinkedList(1);
    head.next.next.next.next.next = new Program.LinkedList(0);
    var expected = true;
    var actual = new Program().LinkedListPalindrome(head);
    Utils.AssertTrue(expected == actual);
  }
}

14 / 14 test cases passed.

Test Case 1 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "1", "value": 0},
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "2-2", "value": 2},
      {"id": "2-2", "next": "1-2", "value": 2},
      {"id": "1-2", "next": "0-2", "value": 1},
      {"id": "0-2", "next": null, "value": 0}
    ]
  }
}
Test Case 2 passed!
Expected Output
true
Our Code's Output
true
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
false
Our Code's Output
false
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
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "0-2", "value": 0},
      {"id": "0-2", "next": null, "value": 0}
    ]
  }
}
Test Case 5 passed!
Expected Output
false
Our Code's Output
false
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
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "6",
    "nodes": [
      {"id": "6", "next": "5", "value": 6},
      {"id": "5", "next": "4", "value": 5},
      {"id": "4", "next": "3", "value": 4},
      {"id": "3", "next": "4-2", "value": 3},
      {"id": "4-2", "next": "5-2", "value": 4},
      {"id": "5-2", "next": "6-2", "value": 5},
      {"id": "6-2", "next": null, "value": 6}
    ]
  }
}
Test Case 7 passed!
Expected Output
false
Our Code's Output
false
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
      {"id": "5", "next": "5-2", "value": 5},
      {"id": "5-2", "next": "4-2", "value": 5},
      {"id": "4-2", "next": "3-2", "value": 4},
      {"id": "3-2", "next": "2-2", "value": 3},
      {"id": "2-2", "next": "1-2", "value": 2},
      {"id": "1-2", "next": "0-2", "value": 1},
      {"id": "0-2", "next": "12", "value": 0},
      {"id": "12", "next": null, "value": 12}
    ]
  }
}
Test Case 8 passed!
Expected Output
true
Our Code's Output
true
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
      {"id": "5", "next": "5-2", "value": 5},
      {"id": "5-2", "next": "4-2", "value": 5},
      {"id": "4-2", "next": "3-2", "value": 4},
      {"id": "3-2", "next": "2-2", "value": 3},
      {"id": "2-2", "next": "1-2", "value": 2},
      {"id": "1-2", "next": "0-2", "value": 1},
      {"id": "0-2", "next": null, "value": 0}
    ]
  }
}
Test Case 9 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "10000",
    "nodes": [
      {"id": "10000", "next": "10000-2", "value": 10000},
      {"id": "10000-2", "next": "10000-3", "value": 10000},
      {"id": "10000-3", "next": null, "value": 10000}
    ]
  }
}
Test Case 10 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "10000",
    "nodes": [
      {"id": "10000", "next": "10000-2", "value": 10000},
      {"id": "10000-2", "next": "10000-3", "value": 10000},
      {"id": "10000-3", "next": "10000-4", "value": 10000},
      {"id": "10000-4", "next": null, "value": 10000}
    ]
  }
}
Test Case 11 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "3",
    "nodes": [
      {"id": "3", "next": "1", "value": 3},
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3-2", "value": 2},
      {"id": "3-2", "next": null, "value": 3}
    ]
  }
}
Test Case 12 passed!
Expected Output
false
Our Code's Output
false
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
      {"id": "11", "next": "10-2", "value": 11},
      {"id": "10-2", "next": "9-2", "value": 10},
      {"id": "9-2", "next": "8-2", "value": 9},
      {"id": "8-2", "next": "7-2", "value": 8},
      {"id": "7-2", "next": "6-2", "value": 7},
      {"id": "6-2", "next": "5-2", "value": 6},
      {"id": "5-2", "next": "4-2", "value": 5},
      {"id": "4-2", "next": "3-2", "value": 4},
      {"id": "3-2", "next": "2-2", "value": 3},
      {"id": "2-2", "next": "1-2", "value": 2},
      {"id": "1-2", "next": null, "value": 1}
    ]
  }
}
Test Case 13 passed!
Expected Output
true
Our Code's Output
true
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
      {"id": "11", "next": "10-2", "value": 11},
      {"id": "10-2", "next": "9-2", "value": 10},
      {"id": "9-2", "next": "8-2", "value": 9},
      {"id": "8-2", "next": "7-2", "value": 8},
      {"id": "7-2", "next": "6-2", "value": 7},
      {"id": "6-2", "next": "5-2", "value": 6},
      {"id": "5-2", "next": "4-2", "value": 5},
      {"id": "4-2", "next": "3-2", "value": 4},
      {"id": "3-2", "next": "2-2", "value": 3},
      {"id": "2-2", "next": "1-2", "value": 2},
      {"id": "1-2", "next": "0-2", "value": 1},
      {"id": "0-2", "next": null, "value": 0}
    ]
  }
}
Test Case 14 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "1-2", "value": 3},
      {"id": "1-2", "next": "2-2", "value": 1},
      {"id": "2-2", "next": null, "value": 2}
    ]
  }
}
 
 */