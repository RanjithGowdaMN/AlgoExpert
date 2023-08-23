using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs._01_Medium
{
    class CycleInGraphProgram
    {
        public bool CycleInGraph(int[][] edges)
        {
            // O(v+e) time | O(v)
            int numberOfNodes = edges.Length;
            bool[] visited = new bool[numberOfNodes];
            bool[] currentlyInStack = new bool[numberOfNodes];
            Array.Fill(visited, false);
            Array.Fill(currentlyInStack, false);

            for (int node = 0; node < numberOfNodes; node++)
            {
                if (visited[node])
                {
                    continue;
                }
                bool containsCycle =
                    isNodeInCycle(node, edges, visited, currentlyInStack);
                if (containsCycle)
                {
                    return true;
                }
            }

            return false;
        }
        public bool isNodeInCycle(
            int node, int[][] edges, bool[] visited, bool[] currentlyInStack
        )
        {
            visited[node] = true;
            currentlyInStack[node] = true;

            bool containsCycle = false;
            int[] neighbors = edges[node];
            foreach (var neighbor in neighbors)
            {
                if (!visited[neighbor])
                {
                    containsCycle =
                        isNodeInCycle(neighbor, edges, visited, currentlyInStack);
                }
                if (containsCycle)
                {
                    return true;
                }
                else if (currentlyInStack[neighbor])
                {
                    return true;
                }
            }
            currentlyInStack[node] = false;
            return false;
        }
    }
}
/*
 ______________________________________________________________________
public class Program {
    int WHITE = 0;
    int GREY = 1;
    int BLACK = 3;
  public bool CycleInGraph(int[][] edges) {
    // O(v+e)  time | O(v) space
      int numberOfNodes = edges.Length;
      int[] colors = new int[numberOfNodes];
      Array.Fill(colors, WHITE);

      for(int node = 0; node < numberOfNodes; node++){
          if(colors[node] != WHITE) continue;
          bool containsCycle = traverseAndColorNodes(node, edges, colors);
          if(containsCycle) return true;
      }
    return false;
  }
    public bool traverseAndColorNodes(int node, int[][] edges, int[] colors){
        colors[node] = GREY;
        int[] neighbors = edges[node];
        foreach(var neighbor in neighbors){
            int neighborColor = colors[neighbor];

            if(neighborColor == GREY){
                return true;
            }
            if(neighborColor == BLACK){
                continue;
            }
            bool containsCycle = traverseAndColorNodes(neighbor, edges, colors);
            if(containsCycle){
                return true;
            }
        }
        colors[node] = BLACK;
        return false;
    }
}

______________________________________________________________________
 
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[][] input = new int[][] {
      new int[] { 1, 3 },
      new int[] { 2, 3, 4 },
      new int[] { 0 },
      new int[] {},
      new int[] { 2, 5 },
      new int[] {}
    };
    bool expected = true;
    var actual = new Program().CycleInGraph(input);
    Utils.AssertTrue(expected == actual);
  }
}

12 / 12 test cases passed.

Test Case 1 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1, 3],
    [2, 3, 4],
    [0],
    [],
    [2, 5],
    []
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
    [1, 2],
    [2],
    []
  ]
}
Test Case 3 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1, 2],
    [2],
    [1]
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
    [1, 2],
    [2],
    [1, 3],
    [3]
  ]
}
Test Case 5 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "edges": [
    [],
    [0, 2],
    [0, 3],
    [0, 4],
    [0, 5],
    [0]
  ]
}
Test Case 6 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": [
    [0]
  ]
}
Test Case 7 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": [
    [8],
    [0, 2],
    [0, 3],
    [0, 4],
    [0, 5],
    [0],
    [7],
    [8],
    [6]
  ]
}
Test Case 8 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1],
    [2, 3, 4, 5, 6, 7],
    [],
    [2, 7],
    [5],
    [],
    [4],
    []
  ]
}
Test Case 9 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1],
    [2, 3, 4, 5, 6, 7],
    [],
    [2, 7],
    [5],
    [],
    [4],
    [0]
  ]
}
Test Case 10 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": [
    [0],
    [1]
  ]
}
Test Case 11 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1, 2],
    [2],
    []
  ]
}
Test Case 12 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": [
    [],
    [0, 3],
    [0],
    [1, 2]
  ]
}
 
 */