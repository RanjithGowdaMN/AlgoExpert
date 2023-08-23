using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs._01_Medium
{
    class RiverSizesProgram
    {
        public static List<int> RiverSizes(int[,] matrix)
        {
            // O(wh) time | O(wh) space
            List<int> sizes = new List<int>();
            bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (visited[i, j])
                    {
                        continue;
                    }
                    traverseNode(i, j, matrix, visited, sizes);
                }
            }
            return sizes;
        }
        public static void traverseNode(
            int i, int j, int[,] matrix, bool[,] visited, List<int> sizes
        )
        {
            int currentRiverSize = 0;
            Stack<int[]> nodesToExplore = new Stack<int[]>();
            nodesToExplore.Push(new int[] { i, j });
            while (nodesToExplore.Count != 0)
            {
                int[] currentNode = nodesToExplore.Pop();
                i = currentNode[0];
                j = currentNode[1];
                if (visited[i, j])
                {
                    continue;
                }
                visited[i, j] = true;
                if (matrix[i, j] == 0)
                {
                    continue;
                }
                currentRiverSize++;
                List<int[]> unvisitedNeighbors =
                    getUnvisitedNeighbors(i, j, matrix, visited);
                foreach (var neighbor in unvisitedNeighbors)
                {
                    nodesToExplore.Push(neighbor);
                }
            }
            if (currentRiverSize > 0)
            {
                sizes.Add(currentRiverSize);
            }
        }
        public static List<int[]> getUnvisitedNeighbors(
            int i, int j, int[,] matrix, bool[,] visited
        )
        {
            List<int[]> unvisitedNeighbors = new List<int[]>();
            if (i > 0 && !visited[i - 1, j])
            {
                unvisitedNeighbors.Add(new int[] { i - 1, j });
            }
            if (i < matrix.GetLength(0) - 1 && !visited[i + 1, j])
            {
                unvisitedNeighbors.Add(new int[] { i + 1, j });
            }
            if (j > 0 && !visited[i, j - 1])
            {
                unvisitedNeighbors.Add(new int[] { i, j - 1 });
            }
            if (j < matrix.GetLength(1) - 1 && !visited[i, j + 1])
            {
                unvisitedNeighbors.Add(new int[] { i, j + 1 });
            }
            return unvisitedNeighbors;
        }
    }
}
/*
 using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[,] input = {
      { 1, 0, 0, 1, 0 },
      { 1, 0, 1, 0, 0 },
      { 0, 0, 1, 0, 1 },
      { 1, 0, 1, 0, 1 },
      { 1, 0, 1, 1, 0 },
    };
    int[] expected = { 1, 2, 2, 2, 5 };
    List<int> output = Program.RiverSizes(input);
    output.Sort();
    Utils.AssertTrue(compare(output, expected));
  }

  public static bool compare(List<int> arr1, int[] arr2) {
    if (arr1.Count != arr2.Length) {
      return false;
    }
    for (int i = 0; i < arr1.Count; i++) {
      if (arr1[i] != arr2[i]) {
        return false;
      }
    }
    return true;
  }
}

12 / 12 test cases passed.

Test Case 1 passed!
Expected Output
[2, 1, 5, 2, 2]
Your Code's Output
[2, 1, 5, 2, 2]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 0, 1, 0],
    [1, 0, 1, 0, 0],
    [0, 0, 1, 0, 1],
    [1, 0, 1, 0, 1],
    [1, 0, 1, 1, 0]
  ]
}
Test Case 2 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0]
  ]
}
Test Case 3 passed!
Expected Output
[1]
Your Code's Output
[1]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1]
  ]
}
Test Case 4 passed!
Expected Output
[3, 2, 1]
Your Code's Output
[3, 2, 1]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 0]
  ]
}
Test Case 5 passed!
Expected Output
[2, 1, 3, 1]
Your Code's Output
[2, 1, 3, 1]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 0, 1],
    [1, 0, 1, 0],
    [0, 0, 1, 0],
    [1, 0, 1, 0]
  ]
}
Test Case 6 passed!
Expected Output
[2, 1, 21, 5, 2, 1]
Your Code's Output
[2, 1, 21, 5, 2, 1]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 0, 1, 0, 1, 0, 0, 1, 1, 1, 0],
    [1, 0, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0],
    [0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1],
    [1, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0],
    [1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1]
  ]
}
Test Case 7 passed!
Expected Output
[1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
Your Code's Output
[1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 0, 0, 0, 0, 1],
    [0, 1, 0, 0, 0, 1, 0],
    [0, 0, 1, 0, 1, 0, 0],
    [0, 0, 0, 1, 0, 0, 0],
    [0, 0, 1, 0, 1, 0, 0],
    [0, 1, 0, 0, 0, 1, 0],
    [1, 0, 0, 0, 0, 0, 1]
  ]
}
Test Case 8 passed!
Expected Output
[1, 1, 1, 1, 7, 1, 1, 1, 1]
Your Code's Output
[1, 1, 1, 1, 7, 1, 1, 1, 1]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 0, 0, 0, 0, 1],
    [0, 1, 0, 0, 0, 1, 0],
    [0, 0, 1, 0, 1, 0, 0],
    [0, 0, 1, 1, 1, 0, 0],
    [0, 0, 1, 0, 1, 0, 0],
    [0, 1, 0, 0, 0, 1, 0],
    [1, 0, 0, 0, 0, 0, 1]
  ]
}
Test Case 9 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0]
  ]
}
Test Case 10 passed!
Expected Output
[49]
Your Code's Output
[49]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 1, 1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1, 1, 1]
  ]
}
Test Case 11 passed!
Expected Output
[3, 5, 6]
Your Code's Output
[3, 5, 6]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 1, 0, 0, 0, 0, 1, 1],
    [1, 0, 1, 1, 1, 1, 0, 1],
    [0, 1, 1, 0, 0, 0, 1, 1]
  ]
}
Test Case 12 passed!
Expected Output
[10, 1, 1, 2, 6]
Your Code's Output
[10, 1, 1, 2, 6]
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 1, 0],
    [1, 0, 1],
    [1, 1, 1],
    [1, 1, 0],
    [1, 0, 1],
    [0, 1, 0],
    [1, 0, 0],
    [1, 0, 0],
    [0, 0, 0],
    [1, 0, 0],
    [1, 0, 1],
    [1, 1, 1]
  ]
}
 
 
 */