using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList._02_Hard
{
    public class ShiftLinkedListProgram
    {
        public static LinkedList ShiftLinkedList(LinkedList head, int k)
        {
            int listLength = 1;
            LinkedList listTail = head;
            while (listTail.next != null)
            {
                listTail = listTail.next;
                listLength++;
            }

            int offset = Math.Abs(k) % listLength;
            if (offset == 0) return head;
            int newTailPosition = k > 0 ? listLength - offset : offset;
            LinkedList newTail = head;
            for (int i = 1; i < newTailPosition; i++)
            {
                newTail = newTail.next;
            }

            LinkedList newHead = newTail.next;
            newTail.next = null;
            listTail.next = head;
            return newHead;
        }

        public class LinkedList
        {
            public int value;
            public LinkedList next;

            public LinkedList(int value)
            {
                this.value = value;
                next = null;
            }
        }
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
    var head = new Program.LinkedList(0);
    head.next = new Program.LinkedList(1);
    head.next.next = new Program.LinkedList(2);
    head.next.next.next = new Program.LinkedList(3);
    head.next.next.next.next = new Program.LinkedList(4);
    head.next.next.next.next.next = new Program.LinkedList(5);
    var result = Program.ShiftLinkedList(head, 2);
    var array = this.linkedListToArray(result);

    var expected = new List<int> { 4, 5, 0, 1, 2, 3 };
    Utils.AssertTrue(Enumerable.SequenceEqual(expected, array));
  }
}


20 / 20 test cases passed.

Test Case 1 passed!
Expected Output
{
  "head": "4",
  "nodes": [
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": null, "value": 3}
  ]
}
Your Code's Output
{
  "head": "4",
  "nodes": [
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": null, "value": 3}
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
      {"id": "5", "next": null, "value": 5}
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
    {"id": "5", "next": null, "value": 5}
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
      {"id": "0", "next": "1", "value": 0},
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": null, "value": 5}
    ]
  }
}
Test Case 3 passed!
Expected Output
{
  "head": "5",
  "nodes": [
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": null, "value": 4}
  ]
}
Your Code's Output
{
  "head": "5",
  "nodes": [
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": null, "value": 4}
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
      {"id": "5", "next": null, "value": 5}
    ]
  }
}
Test Case 4 passed!
Expected Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": null, "value": 2}
  ]
}
Your Code's Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": null, "value": 2}
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
      {"id": "5", "next": null, "value": 5}
    ]
  }
}
Test Case 5 passed!
Expected Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": null, "value": 1}
  ]
}
Your Code's Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": null, "value": 1}
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
      {"id": "5", "next": null, "value": 5}
    ]
  }
}
Test Case 6 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": null, "value": 0}
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
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": null, "value": 0}
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
      {"id": "5", "next": null, "value": 5}
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
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": null, "value": 5}
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
    {"id": "5", "next": null, "value": 5}
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
      {"id": "5", "next": null, "value": 5}
    ]
  }
}
Test Case 8 passed!
Expected Output
{
  "head": "4",
  "nodes": [
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": null, "value": 3}
  ]
}
Your Code's Output
{
  "head": "4",
  "nodes": [
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": null, "value": 3}
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
      {"id": "5", "next": null, "value": 5}
    ]
  }
}
Test Case 9 passed!
Expected Output
{
  "head": "4",
  "nodes": [
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": null, "value": 3}
  ]
}
Your Code's Output
{
  "head": "4",
  "nodes": [
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": null, "value": 3}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": 14,
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
Test Case 10 passed!
Expected Output
{
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
Your Code's Output
{
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
View Outputs Side By Side
Input(s)
{
  "k": 18,
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
Test Case 11 passed!
Expected Output
{
  "head": "1",
  "nodes": [
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": null, "value": 0}
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
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": null, "value": 0}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": -1,
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
Test Case 12 passed!
Expected Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": null, "value": 1}
  ]
}
Your Code's Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": null, "value": 1}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": -2,
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
Test Case 13 passed!
Expected Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": null, "value": 2}
  ]
}
Your Code's Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": null, "value": 2}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": -3,
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
Test Case 14 passed!
Expected Output
{
  "head": "4",
  "nodes": [
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": null, "value": 3}
  ]
}
Your Code's Output
{
  "head": "4",
  "nodes": [
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": null, "value": 3}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": -4,
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
Test Case 15 passed!
Expected Output
{
  "head": "5",
  "nodes": [
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": null, "value": 4}
  ]
}
Your Code's Output
{
  "head": "5",
  "nodes": [
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "2", "value": 1},
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": null, "value": 4}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": -5,
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
Test Case 16 passed!
Expected Output
{
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
Your Code's Output
{
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
View Outputs Side By Side
Input(s)
{
  "k": -6,
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
Test Case 17 passed!
Expected Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": null, "value": 1}
  ]
}
Your Code's Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": null, "value": 1}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": -8,
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
Test Case 18 passed!
Expected Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": null, "value": 1}
  ]
}
Your Code's Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "0", "value": 5},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": null, "value": 1}
  ]
}
View Outputs Side By Side
Input(s)
{
  "k": -14,
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
Test Case 19 passed!
Expected Output
{
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
Your Code's Output
{
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
View Outputs Side By Side
Input(s)
{
  "k": -18,
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
Test Case 20 passed!
Expected Output
{
  "head": "5",
  "nodes": [
    {"id": "5", "next": "2", "value": 5},
    {"id": "2", "next": "0", "value": 2},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "4", "value": 1},
    {"id": "4", "next": "3", "value": 4},
    {"id": "3", "next": null, "value": 3}
  ]
}
Your Code's Output
{
  "head": "5",
  "nodes": [
    {"id": "5", "next": "2", "value": 5},
    {"id": "2", "next": "0", "value": 2},
    {"id": "0", "next": "1", "value": 0},
    {"id": "1", "next": "4", "value": 1},
    {"id": "4", "next": "3", "value": 4},
    {"id": "3", "next": null, "value": 3}
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
      {"id": "1", "next": "4", "value": 1},
      {"id": "2", "next": null, "value": 2},
      {"id": "3", "next": "5", "value": 3},
      {"id": "4", "next": "3", "value": 4},
      {"id": "5", "next": "2", "value": 5}
    ]
  }
}
 */