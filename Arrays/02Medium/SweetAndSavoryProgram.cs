using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._02Medium
{
    class SweetAndSavoryProgram
    {
        public int[] SweetAndSavory(int[] dishes, int target)
        {
            // Write your code here.
            List<int> sweetDishes = new List<int>();
            List<int> savoryDishes = new List<int>();

            foreach (var dish in dishes)
            {
                if (dish < 0)
                {
                    sweetDishes.Add(dish);
                }
                else
                {
                    savoryDishes.Add(dish);
                }
            }
            sweetDishes.Sort((a, b) => Math.Abs(a) - Math.Abs(b));
            savoryDishes.Sort();

            int[] bestPair = new int[2];
            int bestDifference = Int32.MaxValue;
            int sweetIdx = 0;
            int savorIdx = 0;

            while (sweetIdx < sweetDishes.Count && savorIdx < savoryDishes.Count)
            {
                int currentSum = sweetDishes[sweetIdx] + savoryDishes[savorIdx];

                if (currentSum <= target)
                {
                    int currentDifference = target - currentSum;
                    if (currentDifference < bestDifference)
                    {
                        bestDifference = currentDifference;
                        bestPair[0] = sweetDishes[sweetIdx];
                        bestPair[1] = savoryDishes[savorIdx];
                    }
                    savorIdx++;
                }
                else
                {
                    sweetIdx++;
                }
            }

            return bestPair;
        }
    }
}

/*
 Test Case 1 passed!
Expected Output
[0, 0]
Your Code's Output
[0, 0]
View Outputs Side By Side
Input(s)
{
  "dishes": [],
  "target": 10
}
Test Case 2 passed!
Expected Output
[0, 0]
Your Code's Output
[0, 0]
View Outputs Side By Side
Input(s)
{
  "dishes": [4],
  "target": 10
}
Test Case 3 passed!
Expected Output
[0, 0]
Your Code's Output
[0, 0]
View Outputs Side By Side
Input(s)
{
  "dishes": [-5, 10],
  "target": 4
}
Test Case 4 passed!
Expected Output
[0, 0]
Your Code's Output
[0, 0]
View Outputs Side By Side
Input(s)
{
  "dishes": [],
  "target": -10
}
Test Case 5 passed!
Expected Output
[0, 0]
Your Code's Output
[0, 0]
View Outputs Side By Side
Input(s)
{
  "dishes": [4],
  "target": -10
}
Test Case 6 passed!
Expected Output
[0, 0]
Your Code's Output
[0, 0]
View Outputs Side By Side
Input(s)
{
  "dishes": [-5, 10],
  "target": -4
}
Test Case 7 passed!
Expected Output
[-10, 5]
Your Code's Output
[-10, 5]
View Outputs Side By Side
Input(s)
{
  "dishes": [5, -10],
  "target": -4
}
Test Case 8 passed!
Expected Output
[-5, 10]
Your Code's Output
[-5, 10]
View Outputs Side By Side
Input(s)
{
  "dishes": [-5, 10],
  "target": 5
}
Test Case 9 passed!
Expected Output
[0, 0]
Your Code's Output
[0, 0]
View Outputs Side By Side
Input(s)
{
  "dishes": [-5, 10],
  "target": 0
}
Test Case 10 passed!
Expected Output
[-10, 5]
Your Code's Output
[-10, 5]
View Outputs Side By Side
Input(s)
{
  "dishes": [5, -10],
  "target": 0
}
Test Case 11 passed!
Expected Output
[-5, 10]
Your Code's Output
[-5, 10]
View Outputs Side By Side
Input(s)
{
  "dishes": [10, -5],
  "target": 5
}
Test Case 12 passed!
Expected Output
[-5, 10]
Your Code's Output
[-5, 10]
View Outputs Side By Side
Input(s)
{
  "dishes": [10, -5],
  "target": 100
}
Test Case 13 passed!
Expected Output
[-5, 5]
Your Code's Output
[-5, 5]
View Outputs Side By Side
Input(s)
{
  "dishes": [5, -5, 5, -5, 5, -5],
  "target": 10
}
Test Case 14 passed!
Expected Output
[-5, 5]
Your Code's Output
[-5, 5]
View Outputs Side By Side
Input(s)
{
  "dishes": [5, -5, 5, -5, 5, -5],
  "target": 0
}
Test Case 15 passed!
Expected Output
[0, 0]
Your Code's Output
[0, 0]
View Outputs Side By Side
Input(s)
{
  "dishes": [3, 5, 7, 2, 6, 8, 1],
  "target": 10
}
Test Case 16 passed!
Expected Output
[-3, 7]
Your Code's Output
[-3, 7]
View Outputs Side By Side
Input(s)
{
  "dishes": [-3, -5, 1, 7],
  "target": 8
}
Test Case 17 passed!
Expected Output
[-3, 1]
Your Code's Output
[-3, 1]
View Outputs Side By Side
Input(s)
{
  "dishes": [-3, -5, 1, 7],
  "target": 0
}
Test Case 18 passed!
Expected Output
[-7, 2]
Your Code's Output
[-7, 2]
View Outputs Side By Side
Input(s)
{
  "dishes": [2, 5, -4, -7, 12, 100, -25],
  "target": -5
}
Test Case 19 passed!
Expected Output
[-25, 12]
Your Code's Output
[-25, 12]
View Outputs Side By Side
Input(s)
{
  "dishes": [2, 5, -4, -7, 12, 100, -25],
  "target": -7
}
Test Case 20 passed!
Expected Output
[-4, 2]
Your Code's Output
[-4, 2]
View Outputs Side By Side
Input(s)
{
  "dishes": [2, 4, -4, -7, 12, 100, -25],
  "target": -1
}
Test Case 21 passed!
Expected Output
[-25, 5]
Your Code's Output
[-25, 5]
View Outputs Side By Side
Input(s)
{
  "dishes": [2, 5, -4, -7, 12, 100, -25],
  "target": -20
}
Test Case 22 passed!
Expected Output
[-7, 12]
Your Code's Output
[-7, 12]
View Outputs Side By Side
Input(s)
{
  "dishes": [2, 5, -4, -7, 12, 100, -25],
  "target": 5
}
Test Case 23 passed!
Expected Output
[-7, 12]
Your Code's Output
[-7, 12]
View Outputs Side By Side
Input(s)
{
  "dishes": [2, 5, -4, -7, 12, 100, -25],
  "target": 7
}
Test Case 24 passed!
Expected Output
[-4, 5]
Your Code's Output
[-4, 5]
View Outputs Side By Side
Input(s)
{
  "dishes": [2, 5, -4, -7, 12, 100, -25],
  "target": 1
}
Test Case 25 passed!
Expected Output
[-4, 12]
Your Code's Output
[-4, 12]
View Outputs Side By Side
Input(s)
{
  "dishes": [2, 5, -4, -7, 12, 100, -25],
  "target": 20
}
Test Case 26 passed!
Expected Output
[-1, 5]
Your Code's Output
[-1, 5]
View Outputs Side By Side
Input(s)
{
  "dishes": [-5, -4, -3, -2, -1, 1, 2, 3, 4, 5],
  "target": 6
}
Test Case 27 passed!
Expected Output
[0, 0]
Your Code's Output
[0, 0]
View Outputs Side By Side
Input(s)
{
  "dishes": [-5, -4, -3, -2, -1, 1, 2, 3, 4, 5],
  "target": -6
}
Test Case 28 passed!
Expected Output
[-90, 102]
Your Code's Output
[-90, 102]
View Outputs Side By Side
Input(s)
{
  "dishes": [17, 37, 12, -102, 53, 49, -90, 102, 49, 16, 52],
  "target": 12
}
Test Case 29 passed!
Expected Output
[-102, 102]
Your Code's Output
[-102, 102]
View Outputs Side By Side
Input(s)
{
  "dishes": [17, 37, 12, -102, 53, 49, -90, 102, 49, 16, 52],
  "target": 11
}
Test Case 30 passed!
Expected Output
[0, 0]
Your Code's Output
[0, 0]
View Outputs Side By Side
Input(s)
{
  "dishes": [17, 37, 12, -102, 53, 49, -90, 102, 49, 16, 52],
  "target": -100
}
Test Case 31 passed!
Expected Output
[-90, 53]
Your Code's Output
[-90, 53]
View Outputs Side By Side
Input(s)
{
  "dishes": [17, 37, 12, -102, 53, 49, -90, 102, 49, 16, 52],
  "target": -28
}
Test Case 32 passed!
Expected Output
[-53, 53]
Your Code's Output
[-53, 53]
View Outputs Side By Side
Input(s)
{
  "dishes": [-12, 13, 100, -53, 540, -538, 53, 76, 32, -63],
  "target": 0
}
Test Case 33 passed!
Expected Output
[-53, 13]
Your Code's Output
[-53, 13]
View Outputs Side By Side
Input(s)
{
  "dishes": [-12, 13, 100, -53, 540, -538, 53, 76, 32, -63],
  "target": -34
}
Test Case 34 passed!
Expected Output
[-53, 32]
Your Code's Output
[-53, 32]
View Outputs Side By Side
Input(s)
{
  "dishes": [-12, 13, 100, -53, 540, -538, 53, 76, 32, -63],
  "target": -15
}
Test Case 35 passed!
Expected Output
[-12, 53]
Your Code's Output
[-12, 53]
View Outputs Side By Side
Input(s)
{
  "dishes": [-12, 13, 100, -53, 540, -538, 53, 76, 32, -63],
  "target": 42
}
 
 */