using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs._02_Hard
{
    class LargestIslandProgram
    {
        public int LargestIsland(int[][] matrix)
        {
            // O(w^2 * h^2) time | O(w*h) space
            int maxSize = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 0)
                    {
                        continue;
                    }
                    maxSize = Math.Max(maxSize, getSizeFromNode(row, col, matrix));
                }
            }
            return maxSize;
        }
        private int getSizeFromNode(int row, int col, int[][] matrix)
        {
            int size = 1;
            bool[,] visited = new bool[matrix.Length, matrix[0].Length];
            Stack<List<int>> nodesToExplore = new Stack<List<int>>();
            getLandNeighbors(row, col, matrix, nodesToExplore);

            while (nodesToExplore.Count > 0)
            {
                List<int> currentNode = nodesToExplore.Pop();
                int currentRow = currentNode[0];
                int currentCol = currentNode[1];

                if (visited[currentRow, currentCol])
                {
                    continue;
                }
                visited[currentRow, currentCol] = true;
                size++;
                getLandNeighbors(currentRow, currentCol, matrix, nodesToExplore);
            }
            return size;
        }

        private void getLandNeighbors(
            int row, int col, int[][] matrix, Stack<List<int>> nodesToExplore
        )
        {
            if (row > 0 && matrix[row - 1][col] != 1)
            {
                nodesToExplore.Push(new List<int> { row - 1, col });
            }
            if (row < matrix.Length - 1 && matrix[row + 1][col] != 1)
            {
                nodesToExplore.Push(new List<int> { row + 1, col });
            }
            if (col > 0 && matrix[row][col - 1] != 1)
            {
                nodesToExplore.Push(new List<int> { row, col - 1 });
            }
            if (col < matrix[0].Length - 1 && matrix[row][col + 1] != 1)
            {
                nodesToExplore.Push(new List<int> { row, col + 1 });
            }
        }
    }
}

/*
   public int LargestIsland(int[][] matrix) {
    // O(w^2 * h^2) time | O(w*h) space
      List<int> islandSizes = new List<int>();
      int islandNumber = 2;
      for(int row=0; row < matrix.Length; row++){
          for(int col =0; col < matrix[row].Length; col++){
              if(matrix[row][col] == 0){
                  islandSizes.Add(getSizeFromNode(row, col, matrix, islandNumber));
                  islandNumber++;
              }
          }
      }
      int maxSize = 0;
      for(int row = 0; row < matrix.Length; row++){
          for(int col =0; col < matrix[row].Length; col++){
              if(matrix[row][col] != 1){
                  continue;
              }

              List<List<int>> landNeighbors = getLandNeighbors(row, col, matrix);
              HashSet<int> islands = new HashSet<int>();
              foreach(var neighbor in landNeighbors){
                  islands.Add(matrix[neighbor[0]][neighbor[1]]);
              }
              int size = 1;
              foreach(var island in islands){
                  size+= islandSizes[island - 2];
              }
              maxSize = Math.Max(maxSize, size);
          }
      }
      return maxSize;
  }
    
 private int getSizeFromNode(int row, int col, int[][] matrix, int islandNumber){
        int size = 0;
        Stack<List<int>> nodesToExplore = new Stack<List<int>>();
        nodesToExplore.Push(new List<int> {row, col});

        while(nodesToExplore.Count > 0){
            List<int> currentNode = nodesToExplore.Pop();
            int currentRow = currentNode[0];
            int currentCol = currentNode[1];

            if(matrix[currentRow][currentCol] !=0 ){
                continue;
            }
            matrix[currentRow][currentCol] = islandNumber;

            size++;
            List<List<int>> newNeighbors = 
                getLandNeighbors(currentRow, currentCol, matrix);
            foreach(var neighbor in newNeighbors){
                nodesToExplore.Push(neighbor);
            }
        }
        return size;
    }
    private List<List<int>> getLandNeighbors(
        int row, int col, int[][] matrix
    ){
        List<List<int>> landNeighbors = new List<List<int>>();
        if(row > 0 && matrix[row - 1][col] != 1){
            landNeighbors.Add(new List<int> {row - 1, col});
        }
        if(row < matrix.Length - 1 && matrix[row + 1][col] != 1){
            landNeighbors.Add(new List<int> {row + 1, col});
        }
        if(col > 0 && matrix[row][col-1] != 1){
            landNeighbors.Add(new List<int> {row, col - 1});
        }
        if(col < matrix[0].Length - 1 && matrix[row][col + 1] != 1){
            landNeighbors.Add(new List<int> {row, col + 1});
        }
        return landNeighbors;
    }
-___________________________________________________________________________-

 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var input = new int[][] {
      new int[] { 0, 1, 1 }, new int[] { 0, 0, 1 }, new int[] { 1, 1, 0 }
    };
    var expected = 5;
    var actual = new Program().LargestIsland(input);
    Utils.AssertTrue(expected == actual);
  }
}


17 / 17 test cases passed.

Test Case 1 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1]
  ]
}
Test Case 2 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 1]
  ]
}
Test Case 3 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, 1]
  ]
}
Test Case 4 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, 0],
    [0, 1]
  ]
}
Test Case 5 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 1],
    [1, 1]
  ]
}
Test Case 6 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, 1],
    [1, 0]
  ]
}
Test Case 7 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, 1, 0],
    [1, 0, 1],
    [1, 0, 1]
  ]
}
Test Case 8 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 1, 1],
    [0, 1, 0],
    [0, 1, 0]
  ]
}
Test Case 9 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, 1, 1],
    [1, 1, 0],
    [0, 1, 0]
  ]
}
Test Case 10 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, 1, 0],
    [1, 1, 1],
    [0, 1, 0]
  ]
}
Test Case 11 passed!
Expected Output
9
Your Code's Output
9
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, 0, 0],
    [0, 1, 0],
    [0, 0, 0]
  ]
}
Test Case 12 passed!
Expected Output
9
Your Code's Output
9
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [0, 0, 0],
    [0, 0, 0],
    [0, 0, 1]
  ]
}
Test Case 13 passed!
Expected Output
9
Your Code's Output
9
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 1, 0, 0],
    [0, 0, 1, 1, 0],
    [0, 1, 1, 1, 1],
    [0, 1, 1, 0, 0]
  ]
}
Test Case 14 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 1, 0, 0],
    [1, 1, 1, 1, 0],
    [0, 1, 1, 1, 1],
    [0, 1, 1, 0, 0]
  ]
}
Test Case 15 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1],
    [1, 1, 1, 1, 1]
  ]
}
Test Case 16 passed!
Expected Output
20
Your Code's Output
20
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 1, 0, 0, 1, 1, 0, 0, 1],
    [1, 1, 1, 1, 0, 0, 0, 0, 1, 1],
    [0, 1, 1, 1, 1, 1, 1, 1, 0, 0],
    [0, 1, 1, 0, 0, 0, 1, 0, 1, 0],
    [1, 1, 1, 0, 0, 1, 1, 0, 0, 0],
    [0, 0, 1, 1, 0, 1, 0, 1, 0, 1],
    [1, 0, 1, 0, 0, 0, 0, 1, 1, 1]
  ]
}
Test Case 17 passed!
Expected Output
14
Your Code's Output
14
View Outputs Side By Side
Input(s)
{
  "matrix": [
    [1, 0, 1, 0, 1, 1, 1, 1, 1, 1],
    [1, 1, 1, 1, 0, 0, 0, 0, 1, 1],
    [0, 1, 1, 1, 1, 1, 1, 1, 0, 0],
    [0, 1, 1, 0, 0, 0, 1, 0, 1, 0],
    [1, 1, 1, 0, 1, 1, 1, 0, 0, 0],
    [0, 0, 1, 1, 1, 1, 0, 1, 0, 1],
    [1, 0, 1, 0, 0, 0, 0, 1, 1, 1]
  ]
}
 
 */