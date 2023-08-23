using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs._01_Medium
{
    class TwoColorableProgram
    {
        public bool TwoColorable(int[][] edges)
        {
            int[] colors = new int[edges.Length];
            colors[0] = 1;
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                int node = stack.Pop();
                foreach (var connection in edges[node])
                {
                    if (colors[connection] == 0)
                    {
                        colors[connection] = colors[node] == 1 ? 2 : 1;
                        stack.Push(connection);
                    }
                    else if (colors[connection] == colors[node])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[][] input = new int[][] { new int[] { 1 }, new int[] { 0 } };
    var expected = true;
    var actual = new Program().TwoColorable(input);
    Utils.AssertTrue(expected == actual);
  }
}

 11 / 11 test cases passed.

Test Case 1 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1],
    [0]
  ]
}
Test Case 2 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "edges": [
    [0]
  ]
}
Test Case 3 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1, 2],
    [0, 2],
    [0, 1]
  ]
}
Test Case 4 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1],
    [0, 2],
    [1]
  ]
}
Test Case 5 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1, 2, 3],
    [0],
    [0],
    [0]
  ]
}
Test Case 6 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1, 2, 3],
    [0, 2],
    [0, 1],
    [0]
  ]
}
Test Case 7 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1, 2, 3],
    [0, 2, 3],
    [0, 1],
    [0, 1]
  ]
}
Test Case 8 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": [
    [2],
    [2, 3],
    [0, 1],
    [1]
  ]
}
Test Case 9 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1, 2],
    [0, 2, 3],
    [0, 1, 3],
    [1, 2]
  ]
}
Test Case 10 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1, 4],
    [0, 2, 3],
    [1, 3, 4],
    [1, 2],
    [0, 2]
  ]
}
Test Case 11 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1, 4],
    [0, 2, 3],
    [1, 4],
    [1],
    [0, 2]
  ]
}
 
 */