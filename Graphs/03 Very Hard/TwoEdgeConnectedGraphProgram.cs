using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs._03_Very_Hard
{
    class TwoEdgeConnectedGraphProgram
    {
        public bool TwoEdgeConnectedGraph(int[][] edges)
        {
            // O(v + e) time | O(v)
            if (edges.Length == 0) return true;

            int[] arraivalTimes = new int[edges.Length];
            Array.Fill(arraivalTimes, -1);
            int startVertex = 0;
            if (getMinimumArraivalTimeOfAncestors(startVertex, -1, 0, arraivalTimes, edges) == -1)
            {
                return false;
            }
            return areAllVerticesVisited(arraivalTimes);
        }
        public bool areAllVerticesVisited(int[] arraivalTimes)
        {
            foreach (var time in arraivalTimes)
            {
                if (time == -1)
                {
                    return false;
                }
            }
            return true;
        }

        public int getMinimumArraivalTimeOfAncestors(
            int currentVertex,
            int parent,
            int currentTime,
            int[] arraivalTimes,
            int[][] edges
        )
        {
            arraivalTimes[currentVertex] = currentTime;

            int minimumArraivalTime = currentTime;

            foreach (var destination in edges[currentVertex])
            {
                if (arraivalTimes[destination] == -1)
                {
                    minimumArraivalTime = Math.Min(
                        minimumArraivalTime,
                        getMinimumArraivalTimeOfAncestors(destination, currentVertex, currentTime + 1, arraivalTimes, edges));
                }
                else if (destination != parent)
                {
                    minimumArraivalTime =
                        Math.Min(minimumArraivalTime, arraivalTimes[destination]);
                }
            }
            //A bridge was detected, which mean the graph isn't tow-edges-connected
            if (minimumArraivalTime == currentTime && parent != -1)
            {
                return -1;
            }

            return minimumArraivalTime;
        }
    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[][] input = new int[][] {
      new int[] { 1, 2, 5 },
      new int[] { 0, 2 },
      new int[] { 0, 1, 3 },
      new int[] { 2, 4, 5 },
      new int[] { 3, 5 },
      new int[] { 0, 3, 4 },
    };
    bool expected = true;
    var actual = new Program().TwoEdgeConnectedGraph(input);
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
  "edges": [
    [1, 2, 5],
    [0, 2],
    [0, 1, 3],
    [2, 4, 5],
    [3, 5],
    [0, 3, 4]
  ]
}
Test Case 2 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1],
    [0, 2, 3],
    [1, 3],
    [1, 2]
  ]
}
Test Case 3 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1, 2],
    [0, 2, 3],
    [1, 3, 0],
    [1, 2]
  ]
}
Test Case 4 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1],
    [0]
  ]
}
Test Case 5 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "edges": [
    [],
    []
  ]
}
Test Case 6 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1, 2, 3],
    [0, 2],
    [0, 1],
    [0, 4, 5],
    [3, 5],
    [3, 4]
  ]
}
Test Case 7 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1, 2, 3, 5],
    [0, 2],
    [0, 1],
    [0, 4, 5],
    [3, 5],
    [3, 4, 0]
  ]
}
Test Case 8 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": [
    []
  ]
}
Test Case 9 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1, 5, 6],
    [0, 2, 6],
    [1, 6, 3],
    [6, 2, 4],
    [5, 6, 3],
    [4, 6, 0],
    [0, 1, 2, 3, 4, 5]
  ]
}
Test Case 10 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1, 5, 6],
    [0, 2, 6],
    [1, 6, 3],
    [6, 2, 4],
    [6, 3],
    [0],
    [0, 1, 2, 3, 4]
  ]
}
Test Case 11 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1, 2],
    [0, 2, 3],
    [1, 0, 4],
    [1, 4],
    [3, 2]
  ]
}
Test Case 12 passed!
Expected Output
false
Our Code's Output
false
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1, 2],
    [0, 2, 3],
    [1, 0, 4],
    [1, 4],
    [3, 2],
    []
  ]
}
Test Case 13 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": [
    [1, 7, 4],
    [0, 2, 7],
    [1, 6],
    [7, 5],
    [0, 7, 5],
    [4, 7, 6, 3],
    [5, 2, 7],
    [6, 0, 1, 3, 4, 5]
  ]
}
Test Case 14 passed!
Expected Output
true
Our Code's Output
true
View Outputs Side By Side
Input(s)
{
  "edges": []
}
 
 
 */