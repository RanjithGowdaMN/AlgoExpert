namespace LinkedList._02_Hard
{
    public class FindLoops
	{
		public static LinkedList FindLoop(LinkedList head)
		{
			// Write your code here.
			LinkedList first = head.next;
			LinkedList second = head.next.next;

			while (first != second)
			{ 
				first = first.next;
				second = second.next.next;
			}
			first = head;
            while (first != second)
            {
				first = first.next;
				second= second.next;
            }
			return first;
		}

		public class LinkedList
		{
			public int value;
			public LinkedList next = null;

			public LinkedList(int value)
			{
				this.value = value;
			}
		}
	}
}
/*
 public class ProgramTest {
  [Test]
  public void TestCase1() {
    TestLinkedList test = new TestLinkedList(0);
    test.addMany(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
    test.getNthNode(10).next = test.getNthNode(5);
    Utils.AssertTrue(Program.FindLoop(test) == test.getNthNode(5));
  }

  public class TestLinkedList : Program.LinkedList {
    public TestLinkedList(int value) : base(value) {}

    public void addMany(int[] values) {
      Program.LinkedList current = this;
      while (current.next != null) {
        current = current.next;
      }
      foreach (int value in values) {
        current.next = new Program.LinkedList(value);
        current = current.next;
      }
    }

    public Program.LinkedList getNthNode(int n) {
      int counter = 1;
      Program.LinkedList current = this;
      while (counter < n) {
        current = current.next;
        counter++;
      }
      return current;
    }
  }
}

14 / 14 test cases passed.

Test Case 1 passed!
Expected Output
{
  "head": "4",
  "nodes": [
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "4", "value": 9}
  ]
}
Our Code's Output
{
  "head": "4",
  "nodes": [
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "4", "value": 9}
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
      {"id": "9", "next": "4", "value": 9}
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
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "0", "value": 9}
  ]
}
Our Code's Output
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
    {"id": "9", "next": "0", "value": 9}
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
      {"id": "9", "next": "0", "value": 9}
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
    {"id": "9", "next": "1", "value": 9}
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
    {"id": "9", "next": "1", "value": 9}
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
      {"id": "9", "next": "1", "value": 9}
    ]
  }
}
Test Case 4 passed!
Expected Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "2", "value": 9}
  ]
}
Our Code's Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": "3", "value": 2},
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "2", "value": 9}
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
      {"id": "9", "next": "2", "value": 9}
    ]
  }
}
Test Case 5 passed!
Expected Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "3", "value": 9}
  ]
}
Our Code's Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "4", "value": 3},
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "3", "value": 9}
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
      {"id": "9", "next": "3", "value": 9}
    ]
  }
}
Test Case 6 passed!
Expected Output
{
  "head": "5",
  "nodes": [
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "5", "value": 9}
  ]
}
Our Code's Output
{
  "head": "5",
  "nodes": [
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "5", "value": 9}
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
      {"id": "9", "next": "5", "value": 9}
    ]
  }
}
Test Case 7 passed!
Expected Output
{
  "head": "6",
  "nodes": [
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "6", "value": 9}
  ]
}
Our Code's Output
{
  "head": "6",
  "nodes": [
    {"id": "6", "next": "7", "value": 6},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "6", "value": 9}
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
      {"id": "9", "next": "6", "value": 9}
    ]
  }
}
Test Case 8 passed!
Expected Output
{
  "head": "7",
  "nodes": [
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "7", "value": 9}
  ]
}
Our Code's Output
{
  "head": "7",
  "nodes": [
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "7", "value": 9}
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
      {"id": "9", "next": "7", "value": 9}
    ]
  }
}
Test Case 9 passed!
Expected Output
{
  "head": "8",
  "nodes": [
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "8", "value": 9}
  ]
}
Our Code's Output
{
  "head": "8",
  "nodes": [
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "8", "value": 9}
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
      {"id": "9", "next": "8", "value": 9}
    ]
  }
}
Test Case 10 passed!
Expected Output
{
  "head": "9",
  "nodes": [
    {"id": "9", "next": "9", "value": 9}
  ]
}
Our Code's Output
{
  "head": "9",
  "nodes": [
    {"id": "9", "next": "9", "value": 9}
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
      {"id": "9", "next": "9", "value": 9}
    ]
  }
}
Test Case 11 passed!
Expected Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "2", "value": 3},
    {"id": "2", "next": "3", "value": 2}
  ]
}
Our Code's Output
{
  "head": "3",
  "nodes": [
    {"id": "3", "next": "2", "value": 3},
    {"id": "2", "next": "3", "value": 2}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "1", "value": 5},
      {"id": "1", "next": "2", "value": 4},
      {"id": "2", "next": "3", "value": 3},
      {"id": "3", "next": "2", "value": 2}
    ]
  }
}
Test Case 12 passed!
Expected Output
{
  "head": "4",
  "nodes": [
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "2", "value": 6},
    {"id": "2", "next": "7", "value": 2},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "4", "value": 9}
  ]
}
Our Code's Output
{
  "head": "4",
  "nodes": [
    {"id": "4", "next": "5", "value": 4},
    {"id": "5", "next": "6", "value": 5},
    {"id": "6", "next": "2", "value": 6},
    {"id": "2", "next": "7", "value": 2},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "4", "value": 9}
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
      {"id": "6", "next": "2-2", "value": 6},
      {"id": "2-2", "next": "7", "value": 2},
      {"id": "7", "next": "8", "value": 7},
      {"id": "8", "next": "9", "value": 8},
      {"id": "9", "next": "4", "value": 9}
    ]
  }
}
Test Case 13 passed!
Expected Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": "7", "value": 2},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "2", "value": 9}
  ]
}
Our Code's Output
{
  "head": "2",
  "nodes": [
    {"id": "2", "next": "7", "value": 2},
    {"id": "7", "next": "8", "value": 7},
    {"id": "8", "next": "9", "value": 8},
    {"id": "9", "next": "2", "value": 9}
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
      {"id": "6", "next": "2-2", "value": 6},
      {"id": "2-2", "next": "7", "value": 2},
      {"id": "7", "next": "8", "value": 7},
      {"id": "8", "next": "9", "value": 8},
      {"id": "9", "next": "2-2", "value": 9}
    ]
  }
}
Test Case 14 passed!
Expected Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "0-2", "value": 0},
    {"id": "0-2", "next": "0-3", "value": 0},
    {"id": "0-3", "next": "0", "value": 0}
  ]
}
Our Code's Output
{
  "head": "0",
  "nodes": [
    {"id": "0", "next": "0-2", "value": 0},
    {"id": "0-2", "next": "0-3", "value": 0},
    {"id": "0-3", "next": "0", "value": 0}
  ]
}
View Outputs Side By Side
Input(s)
{
  "linkedList": {
    "head": "0",
    "nodes": [
      {"id": "0", "next": "0-2", "value": 0},
      {"id": "0-2", "next": "0-3", "value": 0},
      {"id": "0-3", "next": "0-4", "value": 0},
      {"id": "0-4", "next": "0-5", "value": 0},
      {"id": "0-5", "next": "0-6", "value": 0},
      {"id": "0-6", "next": "0-7", "value": 0},
      {"id": "0-7", "next": "0-8", "value": 0},
      {"id": "0-8", "next": "0-9", "value": 0},
      {"id": "0-9", "next": "0-7", "value": 0}
    ]
  }
}
 
 
 */