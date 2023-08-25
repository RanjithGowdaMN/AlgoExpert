using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList._01_Medium
{
    public class MergingLinkedList
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

        public LinkedList MergingLinkedLists(LinkedList linkedListOne, LinkedList linkedListTwo)
        {
            // Write your code here.
            LinkedList point1 = linkedListOne;
            LinkedList point2 = linkedListTwo;

            while (point1 != point2)
            {
                if (point1 == null)
                {
                    point1 = linkedListTwo;
                }
                else
                {
                    point1 = point1.next;

                }
                if (point2 == null)
                {
                    point2 = linkedListOne;
                }
                else
                {
                    point2 = point2.next;

                }
            }

            return point1;
        }
    }
}

/* 
 using System.Collections.Generic;
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var l1 = new Program.LinkedList(1);
    l1.next = new Program.LinkedList(2);
    var l2 = new Program.LinkedList(3);
    l2.next = l1.next;

    var expected = l1.next;
    var actual = new Program().MergingLinkedLists(l1, l2);
    Utils.AssertTrue(expected == actual);
  }
}


9 / 9 test cases passed.

Test Case 1 passed!
Expected Output
{
  "head": null,
  "nodes": []
}
Our Code's Output
{
  "head": null,
  "nodes": []
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
Test Case 2 passed!
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
  "linkedListOne": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": null, "value": 1}
    ]
  },
  "linkedListTwo": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": null, "value": 1}
    ]
  }
}
Test Case 3 passed!
Expected Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": null, "value": 2}
  ]
}
Our Code's Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": null, "value": 2}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedListOne": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": null, "value": 2}
    ]
  },
  "linkedListTwo": {
    "head": "4",
    "nodes": [
      {"id": "4", "next": "2", "value": 4},
      {"id": "2", "next": null, "value": 2}
    ]
  }
}
Test Case 4 passed!
Expected Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": null, "value": 3}
  ]
}
Our Code's Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": null, "value": 3}
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
    "head": "4",
    "nodes": [
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "3", "value": 5},
      {"id": "3", "next": null, "value": 3}
    ]
  }
}
Test Case 5 passed!
Expected Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": null, "value": 4}
  ]
}
Our Code's Output
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
  "linkedListOne": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": null, "value": 4}
    ]
  },
  "linkedListTwo": {
    "head": "5",
    "nodes": [
      {"id": "5", "next": "3", "value": 5},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": null, "value": 4}
    ]
  }
}
Test Case 6 passed!
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
  "linkedListOne": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": null, "value": 1}
    ]
  },
  "linkedListTwo": {
    "head": "2",
    "nodes": [
      {"id": "2", "next": "3", "value": 2},
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "1", "value": 4},
      {"id": "1", "next": null, "value": 1}
    ]
  }
}
Test Case 7 passed!
Expected Output
{
  "head": "13",
  "nodes": [
    {"id": "13", "next": "21", "value": 13},
    {"id": "21", "next": "33", "value": 21},
    {"id": "33", "next": "9", "value": 33},
    {"id": "9", "next": null, "value": 9}
  ]
}
Our Code's Output
{
  "head": "13",
  "nodes": [
    {"id": "13", "next": "21", "value": 13},
    {"id": "21", "next": "33", "value": 21},
    {"id": "33", "next": "9", "value": 33},
    {"id": "9", "next": null, "value": 9}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedListOne": {
    "head": "5",
    "nodes": [
      {"id": "5", "next": "12", "value": 5},
      {"id": "12", "next": "14", "value": 12},
      {"id": "14", "next": "2", "value": 14},
      {"id": "2", "next": "13", "value": 2},
      {"id": "13", "next": "21", "value": 13},
      {"id": "21", "next": "33", "value": 21},
      {"id": "33", "next": "9", "value": 33},
      {"id": "9", "next": null, "value": 9}
    ]
  },
  "linkedListTwo": {
    "head": "10",
    "nodes": [
      {"id": "10", "next": "3", "value": 10},
      {"id": "3", "next": "48", "value": 3},
      {"id": "48", "next": "0", "value": 48},
      {"id": "0", "next": "13", "value": 0},
      {"id": "13", "next": "21", "value": 13},
      {"id": "21", "next": "33", "value": 21},
      {"id": "33", "next": "9", "value": 33},
      {"id": "9", "next": null, "value": 9}
    ]
  }
}
Test Case 8 passed!
Expected Output
{
  "head": null,
  "nodes": []
}
Our Code's Output
{
  "head": null,
  "nodes": []
}
View Outputs Side By Side
Input(s)
{
  "linkedListOne": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": null, "value": 2}
    ]
  },
  "linkedListTwo": {
    "head": "3",
    "nodes": [
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": null, "value": 4}
    ]
  }
}
Test Case 9 passed!
Expected Output
{
  "head": null,
  "nodes": []
}
Our Code's Output
{
  "head": null,
  "nodes": []
}
View Outputs Side By Side
Input(s)
{
  "linkedListOne": {
    "head": "1",
    "nodes": [
      {"id": "1", "next": "2", "value": 1},
      {"id": "2", "next": null, "value": 2}
    ]
  },
  "linkedListTwo": {
    "head": "3",
    "nodes": [
      {"id": "3", "next": "4", "value": 3},
      {"id": "4", "next": "5", "value": 4},
      {"id": "5", "next": "6", "value": 5},
      {"id": "6", "next": null, "value": 6}
    ]
  }
}


 
 
 */