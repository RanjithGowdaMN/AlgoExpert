namespace LinkedList._01_Medium
{
    public class DoublyLinkedList
    {
        public Node Head;
        public Node Tail;

        public void SetHead(Node node)
        {
            // Write your code here.
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }
            InsertBefore(Head, node);
        }

        public void SetTail(Node node)
        {
            // Write your code here.
            if (Tail == null)
            {
                SetHead(node);
                return;
            }
            InsertAfter(Tail, node);
        }

        public void InsertBefore(Node node, Node nodeToInsert)
        {
            // Write your code here.
            if (nodeToInsert == Head && nodeToInsert == Tail)
            {
                return;
            }
            Remove(nodeToInsert);
            nodeToInsert.Prev = node.Prev;
            nodeToInsert.Next = node;

            //check if node is head
            if (node.Prev == null)
            {
                Head = nodeToInsert;
            }
            else
            {
                node.Prev.Next = nodeToInsert;
            }
            node.Prev = nodeToInsert;
        }

        public void InsertAfter(Node node, Node nodeToInsert)
        {
            // Write your code here.
            if (nodeToInsert == Head && nodeToInsert == Tail)
            {
                return;
            }
            Remove(nodeToInsert);
            nodeToInsert.Prev = node;
            nodeToInsert.Next = node.Next;
            if (node.Next == null)
            {
                Tail = nodeToInsert;
            }
            else
            {
                node.Next.Prev = nodeToInsert;
            }
            node.Next = nodeToInsert;
        }

        public void InsertAtPosition(int position, Node nodeToInsert)
        {
            // Write your code here.
            if (position == 1)
            {
                SetHead(nodeToInsert);
                return;
            }
            Node node = Head;
            int counter = 1;
            while (node != null && counter != position)
            {
                node = node.Next;
                counter++;
            }
            if (node == null)
            {
                SetTail(nodeToInsert);
            }
            else
            {
                InsertBefore(node, nodeToInsert);
            }
        }

        public void RemoveNodesWithValue(int value)
        {
            Node node = Head;
            while (node != null)
            {
                Node nodeToRemove = node;
                node = node.Next;
                if (nodeToRemove.Value == value)
                {
                    Remove(nodeToRemove);
                }
            }
        }

        public void Remove(Node node)
        {
            // Write your code here.
            if (node == Head)
            {
                Head = Head.Next;
            }
            if (node == Tail)
            {
                Tail = Tail.Prev;
            }
            RemoveBinding(node);
        }

        public void RemoveBinding(Node node)
        {
            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }
            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }
            node.Prev = null;
            node.Next = null;
        }

        public bool ContainsNodeWithValue(int value)
        {
            // Write your code here.
            Node node = Head;
            while (node != null && node.Value != value)
            {
                node = node.Next;
            }
            return node != null;
        }
    }

    // Do not edit the class below.
    public class Node
    {
        public int Value;
        public Node Prev;
        public Node Next;

        public Node(int value)
        {
            Value = value;
        }
    }
}
/*
 using System.Collections.Generic;

public class ProgramTest {
  private List<int> getNodeValuesHeadToTail(Program.DoublyLinkedList linkedList
  ) {
    List<int> values = new List<int>();
    Program.Node node = linkedList.Head;
    while (node != null) {
      values.Add(node.Value);
      node = node.Next;
    }
    return values;
  }

  private List<int> getNodeValuesTailToHead(Program.DoublyLinkedList linkedList
  ) {
    List<int> values = new List<int>();
    Program.Node node = linkedList.Tail;
    while (node != null) {
      values.Add(node.Value);
      node = node.Prev;
    }
    return values;
  }

  private void bindNodes(Program.Node nodeOne, Program.Node nodeTwo) {
    nodeOne.Next = nodeTwo;
    nodeTwo.Prev = nodeOne;
  }

  private bool compare(List<int> array1, int[] array2) {
    if (array1.Count != array2.Length) {
      return false;
    }
    for (int i = 0; i < array1.Count; i++) {
      if (array1[i] != array2[i]) {
        return false;
      }
    }
    return true;
  }

  [Test]
  public void TestCase1() {
    Program.DoublyLinkedList linkedList = new Program.DoublyLinkedList();
    Program.Node one = new Program.Node(1);
    Program.Node two = new Program.Node(2);
    Program.Node three = new Program.Node(3);
    Program.Node three2 = new Program.Node(3);
    Program.Node three3 = new Program.Node(3);
    Program.Node four = new Program.Node(4);
    Program.Node five = new Program.Node(5);
    Program.Node six = new Program.Node(6);
    bindNodes(one, two);
    bindNodes(two, three);
    bindNodes(three, four);
    bindNodes(four, five);
    linkedList.Head = one;
    linkedList.Tail = five;

    linkedList.SetHead(four);
    Utils.AssertTrue(
      compare(getNodeValuesHeadToTail(linkedList), new int[] { 4, 1, 2, 3, 5 })
    );
    Utils.AssertTrue(
      compare(getNodeValuesTailToHead(linkedList), new int[] { 5, 3, 2, 1, 4 })
    );

    linkedList.SetTail(six);
    Utils.AssertTrue(compare(
      getNodeValuesHeadToTail(linkedList), new int[] { 4, 1, 2, 3, 5, 6 }
    ));
    Utils.AssertTrue(compare(
      getNodeValuesTailToHead(linkedList), new int[] { 6, 5, 3, 2, 1, 4 }
    ));

    linkedList.InsertBefore(six, three);
    Utils.AssertTrue(compare(
      getNodeValuesHeadToTail(linkedList), new int[] { 4, 1, 2, 5, 3, 6 }
    ));
    Utils.AssertTrue(compare(
      getNodeValuesTailToHead(linkedList), new int[] { 6, 3, 5, 2, 1, 4 }
    ));

    linkedList.InsertAfter(six, three2);
    Utils.AssertTrue(compare(
      getNodeValuesHeadToTail(linkedList), new int[] { 4, 1, 2, 5, 3, 6, 3 }
    ));
    Utils.AssertTrue(compare(
      getNodeValuesTailToHead(linkedList), new int[] { 3, 6, 3, 5, 2, 1, 4 }
    ));

    linkedList.InsertAtPosition(1, three3);
    Utils.AssertTrue(compare(
      getNodeValuesHeadToTail(linkedList), new int[] { 3, 4, 1, 2, 5, 3, 6, 3 }
    ));
    Utils.AssertTrue(compare(
      getNodeValuesTailToHead(linkedList), new int[] { 3, 6, 3, 5, 2, 1, 4, 3 }
    ));

    linkedList.RemoveNodesWithValue(3);
    Utils.AssertTrue(
      compare(getNodeValuesHeadToTail(linkedList), new int[] { 4, 1, 2, 5, 6 })
    );
    Utils.AssertTrue(
      compare(getNodeValuesTailToHead(linkedList), new int[] { 6, 5, 2, 1, 4 })
    );

    linkedList.Remove(two);
    Utils.AssertTrue(
      compare(getNodeValuesHeadToTail(linkedList), new int[] { 4, 1, 5, 6 })
    );
    Utils.AssertTrue(
      compare(getNodeValuesTailToHead(linkedList), new int[] { 6, 5, 1, 4 })
    );

    Utils.AssertTrue(linkedList.ContainsNodeWithValue(5));
  }
}


22 / 22 test cases passed.

Test Case 1 passed!
Expected Output
[
  {
    "arguments": ["5"],
    "linkedList": {
      "head": "5",
      "nodes": [
        {"id": "5", "next": null, "prev": null, "value": 5}
      ],
      "tail": "5"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["4"],
    "linkedList": {
      "head": "4",
      "nodes": [
        {"id": "4", "next": "5", "prev": null, "value": 4},
        {"id": "5", "next": null, "prev": "4", "value": 5}
      ],
      "tail": "5"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["3"],
    "linkedList": {
      "head": "3",
      "nodes": [
        {"id": "3", "next": "4", "prev": null, "value": 3},
        {"id": "4", "next": "5", "prev": "3", "value": 4},
        {"id": "5", "next": null, "prev": "4", "value": 5}
      ],
      "tail": "5"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["2"],
    "linkedList": {
      "head": "2",
      "nodes": [
        {"id": "2", "next": "3", "prev": null, "value": ... 
Our Code's Output
[
  {
    "arguments": ["5"],
    "linkedList": {
      "head": "5",
      "nodes": [
        {"id": "5", "next": null, "prev": null, "value": 5}
      ],
      "tail": "5"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["4"],
    "linkedList": {
      "head": "4",
      "nodes": [
        {"id": "4", "next": "5", "prev": null, "value": 4},
        {"id": "5", "next": null, "prev": "4", "value": 5}
      ],
      "tail": "5"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["3"],
    "linkedList": {
      "head": "3",
      "nodes": [
        {"id": "3", "next": "4", "prev": null, "value": 3},
        {"id": "4", "next": "5", "prev": "3", "value": 4},
        {"id": "5", "next": null, "prev": "4", "value": 5}
      ],
      "tail": "5"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["2"],
    "linkedList": {
      "head": "2",
      "nodes": [
        {"id": "2", "next": "3", "prev": null, "value": ... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["5"],
      "method": "setHead"
    },
    {
      "arguments": ["4"],
      "method": "setHead"
    },
    {
      "arguments": ["3"],
      "method": "setHead"
    },
    {
      "arguments": ["2"],
      "method": "setHead"
    },
    {
      "arguments": ["1"],
      "method": "setHead"
    },
    {
      "arguments": ["4"],
      "method": "setHead"
    },
    {
      "arguments": ["6"],
      "method": "setTail"
    },
    {
      "arguments": ["6", "3"],
      "method": "insertBefore"
    },
    {
      "arguments": ["6", "3-2"],
      "method": "insertAfter"
    },
    {
      "arguments": [1, "3-3"],
      "method": "insertAtPosition"
    },
    {
      "arguments": [3],
      "method": "removeNodesWithValue"
    },
    {
      "arguments": ["2"],
      "method": "remove"
    },
    {
      "arguments": [5],
      "method": "containsNodeWithValue"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1},
    {"id": "2", "next": null, "prev": null, "value": 2},
    {"id": "3", "next": null, "prev": null, "value": 3},
    {"id": "3-2", "next": null, "prev": null, "value": 3},
    {"id": "3-3", "next": null, "prev": null, "value": 3},
    {"id": "4", "next": null, "prev": null, "value": 4},
    {"id": "5", "next": null, "prev": null, "value": 5},
    {"id": "6", "next": null, "prev": null, "value": 6}
  ]
}
Test Case 2 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  }
]
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setHead"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1}
  ]
}
Test Case 3 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setTail",
    "output": null
  }
]
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setTail",
    "output": null
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setTail"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1}
  ]
}
Test Case 4 passed!
Expected Output
[
  {
    "arguments": [1, "1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "insertAtPosition",
    "output": null
  }
]
Our Code's Output
[
  {
    "arguments": [1, "1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "insertAtPosition",
    "output": null
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [1, "1"],
      "method": "insertAtPosition"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1}
  ]
}
Test Case 5 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "setTail",
    "output": null
  }
]
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "setTail",
    "output": null
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setHead"
    },
    {
      "arguments": ["2"],
      "method": "setTail"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1},
    {"id": "2", "next": null, "prev": null, "value": 2}
  ]
}
Test Case 6 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["2"],
    "linkedList": {
      "head": "2",
      "nodes": [
        {"id": "2", "next": "1", "prev": null, "value": 2},
        {"id": "1", "next": null, "prev": "2", "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  }
]
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["2"],
    "linkedList": {
      "head": "2",
      "nodes": [
        {"id": "2", "next": "1", "prev": null, "value": 2},
        {"id": "1", "next": null, "prev": "2", "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setHead"
    },
    {
      "arguments": ["2"],
      "method": "setHead"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1},
    {"id": "2", "next": null, "prev": null, "value": 2}
  ]
}
Test Case 7 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  }
]
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setHead"
    },
    {
      "arguments": ["1", "2"],
      "method": "insertAfter"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1},
    {"id": "2", "next": null, "prev": null, "value": 2}
  ]
}
Test Case 8 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "2",
      "nodes": [
        {"id": "2", "next": "1", "prev": null, "value": 2},
        {"id": "1", "next": null, "prev": "2", "value": 1}
      ],
      "tail": "1"
    },
    "method": "insertBefore",
    "output": null
  }
]
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "2",
      "nodes": [
        {"id": "2", "next": "1", "prev": null, "value": 2},
        {"id": "1", "next": null, "prev": "2", "value": 1}
      ],
      "tail": "1"
    },
    "method": "insertBefore",
    "output": null
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setHead"
    },
    {
      "arguments": ["1", "2"],
      "method": "insertBefore"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1},
    {"id": "2", "next": null, "prev": null, "value": 2}
  ]
}
Test Case 9 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": "3", "prev": "1", "value": 2},
        {"id": "3", "next": null, "prev": "2", "value": 3}
      ],
      "tail": "3"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", ... 
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": "3", "prev": "1", "value": 2},
        {"id": "3", "next": null, "prev": "2", "value": 3}
      ],
      "tail": "3"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", ... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setHead"
    },
    {
      "arguments": ["1", "2"],
      "method": "insertAfter"
    },
    {
      "arguments": ["2", "3"],
      "method": "insertAfter"
    },
    {
      "arguments": ["3", "4"],
      "method": "insertAfter"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1},
    {"id": "2", "next": null, "prev": null, "value": 2},
    {"id": "3", "next": null, "prev": null, "value": 3},
    {"id": "4", "next": null, "prev": null, "value": 4}
  ]
}
Test Case 10 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setTail",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "2",
      "nodes": [
        {"id": "2", "next": "1", "prev": null, "value": 2},
        {"id": "1", "next": null, "prev": "2", "value": 1}
      ],
      "tail": "1"
    },
    "method": "insertBefore",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "3",
      "nodes": [
        {"id": "3", "next": "2", "prev": null, "value": 3},
        {"id": "2", "next": "1", "prev": "3", "value": 2},
        {"id": "1", "next": null, "prev": "2", "value": 1}
      ],
      "tail": "1"
    },
    "method": "insertBefore",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "4",
      "nodes": [
        {"id": "4", "next": "3"... 
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setTail",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "2",
      "nodes": [
        {"id": "2", "next": "1", "prev": null, "value": 2},
        {"id": "1", "next": null, "prev": "2", "value": 1}
      ],
      "tail": "1"
    },
    "method": "insertBefore",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "3",
      "nodes": [
        {"id": "3", "next": "2", "prev": null, "value": 3},
        {"id": "2", "next": "1", "prev": "3", "value": 2},
        {"id": "1", "next": null, "prev": "2", "value": 1}
      ],
      "tail": "1"
    },
    "method": "insertBefore",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "4",
      "nodes": [
        {"id": "4", "next": "3"... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setTail"
    },
    {
      "arguments": ["1", "2"],
      "method": "insertBefore"
    },
    {
      "arguments": ["2", "3"],
      "method": "insertBefore"
    },
    {
      "arguments": ["3", "4"],
      "method": "insertBefore"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1},
    {"id": "2", "next": null, "prev": null, "value": 2},
    {"id": "3", "next": null, "prev": null, "value": 3},
    {"id": "4", "next": null, "prev": null, "value": 4}
  ]
}
Test Case 11 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": "3", "prev": "1", "value": 2},
        {"id": "3", "next": null, "prev": "2", "value": 3}
      ],
      "tail": "3"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", ... 
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": "3", "prev": "1", "value": 2},
        {"id": "3", "next": null, "prev": "2", "value": 3}
      ],
      "tail": "3"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", ... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setHead"
    },
    {
      "arguments": ["1", "2"],
      "method": "insertAfter"
    },
    {
      "arguments": ["2", "3"],
      "method": "insertAfter"
    },
    {
      "arguments": ["3", "4"],
      "method": "insertAfter"
    },
    {
      "arguments": ["1"],
      "method": "setTail"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1},
    {"id": "2", "next": null, "prev": null, "value": 2},
    {"id": "3", "next": null, "prev": null, "value": 3},
    {"id": "4", "next": null, "prev": null, "value": 4}
  ]
}
Test Case 12 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setTail",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "2",
      "nodes": [
        {"id": "2", "next": "1", "prev": null, "value": 2},
        {"id": "1", "next": null, "prev": "2", "value": 1}
      ],
      "tail": "1"
    },
    "method": "insertBefore",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "3",
      "nodes": [
        {"id": "3", "next": "2", "prev": null, "value": 3},
        {"id": "2", "next": "1", "prev": "3", "value": 2},
        {"id": "1", "next": null, "prev": "2", "value": 1}
      ],
      "tail": "1"
    },
    "method": "insertBefore",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "4",
      "nodes": [
        {"id": "4", "next": "3"... 
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setTail",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "2",
      "nodes": [
        {"id": "2", "next": "1", "prev": null, "value": 2},
        {"id": "1", "next": null, "prev": "2", "value": 1}
      ],
      "tail": "1"
    },
    "method": "insertBefore",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "3",
      "nodes": [
        {"id": "3", "next": "2", "prev": null, "value": 3},
        {"id": "2", "next": "1", "prev": "3", "value": 2},
        {"id": "1", "next": null, "prev": "2", "value": 1}
      ],
      "tail": "1"
    },
    "method": "insertBefore",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "4",
      "nodes": [
        {"id": "4", "next": "3"... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setTail"
    },
    {
      "arguments": ["1", "2"],
      "method": "insertBefore"
    },
    {
      "arguments": ["2", "3"],
      "method": "insertBefore"
    },
    {
      "arguments": ["3", "4"],
      "method": "insertBefore"
    },
    {
      "arguments": ["1"],
      "method": "setHead"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1},
    {"id": "2", "next": null, "prev": null, "value": 2},
    {"id": "3", "next": null, "prev": null, "value": 3},
    {"id": "4", "next": null, "prev": null, "value": 4}
  ]
}
Test Case 13 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": "3", "prev": "1", "value": 2},
        {"id": "3", "next": null, "prev": "2", "value": 3}
      ],
      "tail": "3"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", ... 
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": "3", "prev": "1", "value": 2},
        {"id": "3", "next": null, "prev": "2", "value": 3}
      ],
      "tail": "3"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", ... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setHead"
    },
    {
      "arguments": ["1", "2"],
      "method": "insertAfter"
    },
    {
      "arguments": ["2", "3"],
      "method": "insertAfter"
    },
    {
      "arguments": ["3", "4"],
      "method": "insertAfter"
    },
    {
      "arguments": ["2", "1"],
      "method": "insertAfter"
    },
    {
      "arguments": ["3", "4"],
      "method": "insertBefore"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1},
    {"id": "2", "next": null, "prev": null, "value": 2},
    {"id": "3", "next": null, "prev": null, "value": 3},
    {"id": "4", "next": null, "prev": null, "value": 4}
  ]
}
Test Case 14 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": "3", "prev": "1", "value": 2},
        {"id": "3", "next": null, "prev": "2", "value": 3}
      ],
      "tail": "3"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", ... 
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": "3", "prev": "1", "value": 2},
        {"id": "3", "next": null, "prev": "2", "value": 3}
      ],
      "tail": "3"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", ... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setHead"
    },
    {
      "arguments": ["1", "2"],
      "method": "insertAfter"
    },
    {
      "arguments": ["2", "3"],
      "method": "insertAfter"
    },
    {
      "arguments": ["3", "4"],
      "method": "insertAfter"
    },
    {
      "arguments": ["4", "5"],
      "method": "insertAfter"
    },
    {
      "arguments": ["5", "6"],
      "method": "insertAfter"
    },
    {
      "arguments": ["6", "7"],
      "method": "insertAfter"
    },
    {
      "arguments": [7, "1"],
      "method": "insertAtPosition"
    },
    {
      "arguments": [1, "1"],
      "method": "insertAtPosition"
    },
    {
      "arguments": [2, "1"],
      "method": "insertAtPosition"
    },
    {
      "arguments": [3, "1"],
      "method": "insertAtPosition"
    },
    {
      "arguments": [4, "1"],
      "method": "insertAtPosition"
    },
    {
      "arguments": [5, "1"],
      "method": "insertAtPosition"
    },
    {
      "arguments": [6, "1"],
      "method": "insertAtPosition"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1},
    {"id": "2", "next": null, "prev": null, "value": 2},
    {"id": "3", "next": null, "prev": null, "value": 3},
    {"id": "4", "next": null, "prev": null, "value": 4},
    {"id": "5", "next": null, "prev": null, "value": 5},
    {"id": "6", "next": null, "prev": null, "value": 6},
    {"id": "7", "next": null, "prev": null, "value": 7}
  ]
}
Test Case 15 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1"],
    "linkedList": {
      "head": null,
      "nodes": [],
      "tail": null
    },
    "method": "remove",
    "output": null
  }
]
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1"],
    "linkedList": {
      "head": null,
      "nodes": [],
      "tail": null
    },
    "method": "remove",
    "output": null
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setHead"
    },
    {
      "arguments": ["1"],
      "method": "remove"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1}
  ]
}
Test Case 16 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": [1],
    "linkedList": {
      "head": null,
      "nodes": [],
      "tail": null
    },
    "method": "removeNodesWithValue",
    "output": null
  }
]
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": [1],
    "linkedList": {
      "head": null,
      "nodes": [],
      "tail": null
    },
    "method": "removeNodesWithValue",
    "output": null
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setHead"
    },
    {
      "arguments": [1],
      "method": "removeNodesWithValue"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1}
  ]
}
Test Case 17 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": "3", "prev": "1", "value": 2},
        {"id": "3", "next": null, "prev": "2", "value": 3}
      ],
      "tail": "3"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", ... 
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": "3", "prev": "1", "value": 2},
        {"id": "3", "next": null, "prev": "2", "value": 3}
      ],
      "tail": "3"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", ... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setHead"
    },
    {
      "arguments": ["1", "2"],
      "method": "insertAfter"
    },
    {
      "arguments": ["2", "3"],
      "method": "insertAfter"
    },
    {
      "arguments": ["3", "4"],
      "method": "insertAfter"
    },
    {
      "arguments": ["1"],
      "method": "remove"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1},
    {"id": "2", "next": null, "prev": null, "value": 2},
    {"id": "3", "next": null, "prev": null, "value": 3},
    {"id": "4", "next": null, "prev": null, "value": 4}
  ]
}
Test Case 18 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": "3", "prev": "1", "value": 2},
        {"id": "3", "next": null, "prev": "2", "value": 3}
      ],
      "tail": "3"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", ... 
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": "3", "prev": "1", "value": 2},
        {"id": "3", "next": null, "prev": "2", "value": 3}
      ],
      "tail": "3"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", ... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setHead"
    },
    {
      "arguments": ["1", "2"],
      "method": "insertAfter"
    },
    {
      "arguments": ["2", "3"],
      "method": "insertAfter"
    },
    {
      "arguments": ["3", "4"],
      "method": "insertAfter"
    },
    {
      "arguments": ["4"],
      "method": "remove"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1},
    {"id": "2", "next": null, "prev": null, "value": 2},
    {"id": "3", "next": null, "prev": null, "value": 3},
    {"id": "4", "next": null, "prev": null, "value": 4}
  ]
}
Test Case 19 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": "3", "prev": "1", "value": 2},
        {"id": "3", "next": null, "prev": "2", "value": 3}
      ],
      "tail": "3"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", ... 
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": "3", "prev": "1", "value": 2},
        {"id": "3", "next": null, "prev": "2", "value": 3}
      ],
      "tail": "3"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", ... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setHead"
    },
    {
      "arguments": ["1", "2"],
      "method": "insertAfter"
    },
    {
      "arguments": ["2", "3"],
      "method": "insertAfter"
    },
    {
      "arguments": ["3", "4"],
      "method": "insertAfter"
    },
    {
      "arguments": ["2"],
      "method": "remove"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1},
    {"id": "2", "next": null, "prev": null, "value": 2},
    {"id": "3", "next": null, "prev": null, "value": 3},
    {"id": "4", "next": null, "prev": null, "value": 4}
  ]
}
Test Case 20 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "1-2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "1-2", "prev": null, "value": 1},
        {"id": "1-2", "next": null, "prev": "1", "value": 1}
      ],
      "tail": "1-2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["1-2", "1-3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "1-2", "prev": null, "value": 1},
        {"id": "1-2", "next": "1-3", "prev": "1", "value": 1},
        {"id": "1-3", "next": null, "prev": "1-2", "value": 1}
      ],
      "tail": "1-3"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["1-3", "1-4"],
    "linkedList": {
      "head": "1",
      "nodes": [
     ... 
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "1-2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "1-2", "prev": null, "value": 1},
        {"id": "1-2", "next": null, "prev": "1", "value": 1}
      ],
      "tail": "1-2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["1-2", "1-3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "1-2", "prev": null, "value": 1},
        {"id": "1-2", "next": "1-3", "prev": "1", "value": 1},
        {"id": "1-3", "next": null, "prev": "1-2", "value": 1}
      ],
      "tail": "1-3"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["1-3", "1-4"],
    "linkedList": {
      "head": "1",
      "nodes": [
     ... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setHead"
    },
    {
      "arguments": ["1", "1-2"],
      "method": "insertAfter"
    },
    {
      "arguments": ["1-2", "1-3"],
      "method": "insertAfter"
    },
    {
      "arguments": ["1-3", "1-4"],
      "method": "insertAfter"
    },
    {
      "arguments": [1],
      "method": "removeNodesWithValue"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1},
    {"id": "1-2", "next": null, "prev": null, "value": 1},
    {"id": "1-3", "next": null, "prev": null, "value": 1},
    {"id": "1-4", "next": null, "prev": null, "value": 1}
  ]
}
Test Case 21 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["2", "1-2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": "1-2", "prev": "1", "value": 2},
        {"id": "1-2", "next": null, "prev": "2", "value": 1}
      ],
      "tail": "1-2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["1-2", "3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "ne... 
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["2", "1-2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": "1-2", "prev": "1", "value": 2},
        {"id": "1-2", "next": null, "prev": "2", "value": 1}
      ],
      "tail": "1-2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["1-2", "3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "ne... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setHead"
    },
    {
      "arguments": ["1", "2"],
      "method": "insertAfter"
    },
    {
      "arguments": ["2", "1-2"],
      "method": "insertAfter"
    },
    {
      "arguments": ["1-2", "3"],
      "method": "insertAfter"
    },
    {
      "arguments": ["3", "1-3"],
      "method": "insertAfter"
    },
    {
      "arguments": ["1-3", "4"],
      "method": "insertAfter"
    },
    {
      "arguments": [1],
      "method": "removeNodesWithValue"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1},
    {"id": "1-2", "next": null, "prev": null, "value": 1},
    {"id": "1-3", "next": null, "prev": null, "value": 1},
    {"id": "1-4", "next": null, "prev": null, "value": 1},
    {"id": "2", "next": null, "prev": null, "value": 2},
    {"id": "3", "next": null, "prev": null, "value": 3},
    {"id": "4", "next": null, "prev": null, "value": 4}
  ]
}
Test Case 22 passed!
Expected Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": "3", "prev": "1", "value": 2},
        {"id": "3", "next": null, "prev": "2", "value": 3}
      ],
      "tail": "3"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", ... 
Our Code's Output
[
  {
    "arguments": ["1"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": null, "prev": null, "value": 1}
      ],
      "tail": "1"
    },
    "method": "setHead",
    "output": null
  },
  {
    "arguments": ["1", "2"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": null, "prev": "1", "value": 2}
      ],
      "tail": "2"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["2", "3"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", "prev": null, "value": 1},
        {"id": "2", "next": "3", "prev": "1", "value": 2},
        {"id": "3", "next": null, "prev": "2", "value": 3}
      ],
      "tail": "3"
    },
    "method": "insertAfter",
    "output": null
  },
  {
    "arguments": ["3", "4"],
    "linkedList": {
      "head": "1",
      "nodes": [
        {"id": "1", "next": "2", ... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["1"],
      "method": "setHead"
    },
    {
      "arguments": ["1", "2"],
      "method": "insertAfter"
    },
    {
      "arguments": ["2", "3"],
      "method": "insertAfter"
    },
    {
      "arguments": ["3", "4"],
      "method": "insertAfter"
    },
    {
      "arguments": [1],
      "method": "containsNodeWithValue"
    },
    {
      "arguments": [2],
      "method": "containsNodeWithValue"
    },
    {
      "arguments": [3],
      "method": "containsNodeWithValue"
    },
    {
      "arguments": [4],
      "method": "containsNodeWithValue"
    },
    {
      "arguments": [5],
      "method": "containsNodeWithValue"
    }
  ],
  "nodes": [
    {"id": "1", "next": null, "prev": null, "value": 1},
    {"id": "2", "next": null, "prev": null, "value": 2},
    {"id": "3", "next": null, "prev": null, "value": 3},
    {"id": "4", "next": null, "prev": null, "value": 4}
  ]
}
 
 
 */