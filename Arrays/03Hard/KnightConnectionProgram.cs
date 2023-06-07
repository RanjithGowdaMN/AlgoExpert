using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._03Hard
{
    class KnightConnectionProgram
    {
        public int KnightConnection(int[] knightA, int[] knightB)
        {
            // Write your code here.
            int[,] possibleMoves = new int[8, 2]
            {{-2,1},{-1,2},{1,2},{2,1},{2,-1},{1,-2},{-1,-2},{-2,-1}};

            Queue<List<int>> queue = new Queue<List<int>>();
            queue.Enqueue(new List<int> { knightA[0], knightA[1], 0 });

            HashSet<string> visited = new HashSet<string>();
            visited.Add(knightA.ToString());

            while (queue.Count > 0)
            {
                List<int> currentPosition = queue.Dequeue();

                if (currentPosition[0] == knightB[0] && currentPosition[1] == knightB[1])
                {
                    return (int)Math.Ceiling((double)currentPosition[2] / 2);
                }

                for (int i = 0; i < possibleMoves.GetLength(0); i++)
                {
                    List<int> position = new List<int>();
                    position.Add(currentPosition[0] + possibleMoves[i, 0]);
                    position.Add(currentPosition[1] + possibleMoves[i, 1]);
                    string positionString = String.Join(",", position.ConvertAll<string>(x => x.ToString()));

                    if (!visited.Contains(positionString))
                    {
                        position.Add(currentPosition[2] + 1);
                        queue.Enqueue(position);
                        visited.Add(positionString);
                    }
                }

            }

            return -1;
        }
    }
}
/*
 16 / 16 test cases passed.

Test Case 1 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "knightA": [0, 0],
  "knightB": [0, 0]
}
Test Case 2 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "knightA": [15, -12],
  "knightB": [15, -12]
}
Test Case 3 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "knightA": [1, 0],
  "knightB": [0, 0]
}
Test Case 4 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "knightA": [0, 0],
  "knightB": [1, 0]
}
Test Case 5 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "knightA": [1, 1],
  "knightB": [0, 0]
}
Test Case 6 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "knightA": [0, 0],
  "knightB": [-1, -1]
}
Test Case 7 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "knightA": [2, 1],
  "knightB": [0, 0]
}
Test Case 8 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "knightA": [3, 3],
  "knightB": [0, 0]
}
Test Case 9 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "knightA": [2, 1],
  "knightB": [-1, -2]
}
Test Case 10 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "knightA": [2, 1],
  "knightB": [-2, -4]
}
Test Case 11 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "knightA": [5, 2],
  "knightB": [-2, -4]
}
Test Case 12 passed!
Expected Output
7
Your Code's Output
7
View Outputs Side By Side
Input(s)
{
  "knightA": [10, 10],
  "knightB": [-10, -10]
}
Test Case 13 passed!
Expected Output
9
Your Code's Output
9
View Outputs Side By Side
Input(s)
{
  "knightA": [15, 15],
  "knightB": [-10, -10]
}
Test Case 14 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "knightA": [-15, 2],
  "knightB": [-3, 20]
}
Test Case 15 passed!
Expected Output
7
Your Code's Output
7
View Outputs Side By Side
Input(s)
{
  "knightA": [20, 20],
  "knightB": [0, 0]
}
Test Case 16 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "knightA": [18, -13],
  "knightB": [0, 12]
}
 
 */