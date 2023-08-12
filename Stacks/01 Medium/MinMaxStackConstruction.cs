using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks._01_Medium
{
    public class MinMaxStackProgram
    {
        // Feel free to add new properties and methods to the class.
        public class MinMaxStack
        {
            List<Dictionary<string, int>> minMaxStack =
                new List<Dictionary<string, int>>();
            List<int> stack = new List<int>();

            public int Peek()
            {
                return stack[stack.Count - 1];
            }

            public int Pop()
            {
                minMaxStack.RemoveAt(minMaxStack.Count - 1);
                var val = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                return val;
            }

            public void Push(int number)
            {
                Dictionary<string, int> newMinMax = new Dictionary<string, int>();
                newMinMax.Add("min", number);
                newMinMax.Add("max", number);
                if (minMaxStack.Count > 0)
                {
                    Dictionary<string, int> lastMinMax =
                        new Dictionary<string, int>(minMaxStack[minMaxStack.Count - 1]);
                    newMinMax["min"] = Math.Min(lastMinMax["min"], number);
                    newMinMax["max"] = Math.Max(lastMinMax["max"], number);
                }
                minMaxStack.Add(newMinMax);
                stack.Add(number);
            }

            public int GetMin()
            {
                return minMaxStack[minMaxStack.Count - 1]["min"];
            }

            public int GetMax()
            {
                return minMaxStack[minMaxStack.Count - 1]["max"];
            }
        }
    }

}
/*
 public class ProgramTest {
  public void testMinMaxPeek(
    int min, int max, int Peek, Program.MinMaxStack stack
  ) {
    Utils.AssertTrue(stack.GetMin() == min);
    Utils.AssertTrue(stack.GetMax() == max);
    Utils.AssertTrue(stack.Peek() == Peek);
  }

  [Test]
  public void TestCase1() {
    Program.MinMaxStack stack = new Program.MinMaxStack();
    stack.Push(5);
    testMinMaxPeek(5, 5, 5, stack);
    stack.Push(7);
    testMinMaxPeek(5, 7, 7, stack);
    stack.Push(2);
    testMinMaxPeek(2, 7, 2, stack);
    Utils.AssertTrue(stack.Pop() == 2);
    Utils.AssertTrue(stack.Pop() == 7);
    testMinMaxPeek(5, 5, 5, stack);
  }
}

4 / 4 test cases passed.

Test Case 1 passed!
Expected Output
[
  {
    "arguments": [5],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 5
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 5
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 5
  },
  {
    "arguments": [7],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 5
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 7
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 7
  },
  {
    "arguments": [2],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 2
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 7
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 2
  },
  {
    "arguments": [],
    "method": "pop",
    "output": 2
  },
  {
    "arguments": [],
    "method": "pop",
    "output": 7
  },
  {
    "arguments": [],... 
Your Code's Output
[
  {
    "arguments": [5],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 5
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 5
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 5
  },
  {
    "arguments": [7],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 5
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 7
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 7
  },
  {
    "arguments": [2],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 2
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 7
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 2
  },
  {
    "arguments": [],
    "method": "pop",
    "output": 2
  },
  {
    "arguments": [],
    "method": "pop",
    "output": 7
  },
  {
    "arguments": [],... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [5],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [7],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [2],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    }
  ]
}
Test Case 2 passed!
Expected Output
[
  {
    "arguments": [2],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 2
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 2
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 2
  },
  {
    "arguments": [7],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 2
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 7
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 7
  },
  {
    "arguments": [1],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 1
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 7
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 1
  },
  {
    "arguments": [8],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 1
  },
  {
    "argumen... 
Your Code's Output
[
  {
    "arguments": [2],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 2
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 2
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 2
  },
  {
    "arguments": [7],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 2
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 7
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 7
  },
  {
    "arguments": [1],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 1
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 7
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 1
  },
  {
    "arguments": [8],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 1
  },
  {
    "argumen... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [2],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [7],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [1],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [8],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [3],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [9],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    }
  ]
}
Test Case 3 passed!
Expected Output
[
  {
    "arguments": [5],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 5
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 5
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 5
  },
  {
    "arguments": [5],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 5
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 5
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 5
  },
  {
    "arguments": [5],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 5
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 5
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 5
  },
  {
    "arguments": [5],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 5
  },
  {
    "argumen... 
Your Code's Output
[
  {
    "arguments": [5],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 5
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 5
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 5
  },
  {
    "arguments": [5],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 5
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 5
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 5
  },
  {
    "arguments": [5],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 5
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 5
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 5
  },
  {
    "arguments": [5],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 5
  },
  {
    "argumen... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [5],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [5],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [5],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [5],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [8],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [8],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [0],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [8],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [9],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [5],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    }
  ]
}
Test Case 4 passed!
Expected Output
[
  {
    "arguments": [2],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 2
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 2
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 2
  },
  {
    "arguments": [0],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 0
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 2
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 0
  },
  {
    "arguments": [5],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 0
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 5
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 5
  },
  {
    "arguments": [4],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 0
  },
  {
    "argumen... 
Your Code's Output
[
  {
    "arguments": [2],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 2
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 2
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 2
  },
  {
    "arguments": [0],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 0
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 2
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 0
  },
  {
    "arguments": [5],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 0
  },
  {
    "arguments": [],
    "method": "getMax",
    "output": 5
  },
  {
    "arguments": [],
    "method": "peek",
    "output": 5
  },
  {
    "arguments": [4],
    "method": "push",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMin",
    "output": 0
  },
  {
    "argumen... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [2],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [0],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [5],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [4],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [4],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [11],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [-11],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    },
    {
      "arguments": [6],
      "method": "push"
    },
    {
      "arguments": [],
      "method": "getMin"
    },
    {
      "arguments": [],
      "method": "getMax"
    },
    {
      "arguments": [],
      "method": "peek"
    },
    {
      "arguments": [],
      "method": "pop"
    }
  ]
}
 
 */