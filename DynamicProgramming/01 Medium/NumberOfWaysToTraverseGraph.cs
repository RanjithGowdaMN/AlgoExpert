using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._01_Medium
{
    class NumberOfWaysToTraverseGraph
    {
        //O(2^(m+n)) | O(n)
        public int NumberOfWaysToTraverseGraph1(int width, int height)
        {
            // Write your code here.
            if (width == 1 || height == 1)
            {
                return 1;
            }

            return NumberOfWaysToTraverseGraph1(width - 1, height) + NumberOfWaysToTraverseGraph1(width, height - 1);
        }
        //O(m*n)
        public int NumberOfWaysToTraverseGraph2(int width, int height)
        {
            // Write your code here.
            int[,] numberOfWays = new int[height + 1, width + 1];

            for (int widthIdx = 1; widthIdx < width + 1; widthIdx++)
            {
                for (int heigthIdx = 1; heigthIdx < height + 1; heigthIdx++)
                {
                    if (widthIdx == 1 || heigthIdx == 1)
                    {
                        numberOfWays[heigthIdx, widthIdx] = 1;
                    }
                    else
                    {
                        int waysLeft = numberOfWays[heigthIdx, widthIdx - 1];
                        int waysUp = numberOfWays[heigthIdx - 1, widthIdx];
                        numberOfWays[heigthIdx, widthIdx] = waysLeft + waysUp;
                    }
                }
            }

            return numberOfWays[height, width];
        }

        public int NumberOfWaysToTraverseGraph3(int width, int height)
        {
            // Write your code here.
            int xDistanceToCorner = width - 1;
            int yDistanceToCorner = height - 1;

            int numerator = factorial(xDistanceToCorner+yDistanceToCorner);
            int denominator =
                factorial(xDistanceToCorner) * factorial(yDistanceToCorner);
            return numerator / denominator;
        }
        public int factorial(int num)
        {
            int result = 1;
            for (int n = 2; n < num + 1; n++)
            {
                result *= n;
            }
            return result;
        }
    }
   
}
/*
 
public int NumberOfWaysToTraverseGraph(int width, int height) {
		// Write your code here.
        int[,] numberOfWays = new int[height + 1, width + 1];

        for(int widthIdx=1; widthIdx < width +1; widthIdx++ ){
            for(int heigthIdx = 1; heigthIdx < height +1; heigthIdx++ ){
                if(widthIdx ==1||heigthIdx==1){
                    numberOfWays[heigthIdx, widthIdx] = 1;
                }else{
                    int waysLeft = numberOfWays[heigthIdx, widthIdx - 1];
                    int waysUp = numberOfWays[heigthIdx -1, widthIdx];
                    numberOfWays[heigthIdx, widthIdx] = waysLeft+ waysUp;
                }
            }
        }
        
		return numberOfWays[height, width];
	}

 
 15 / 15 test cases passed.

Test Case 1 passed!
Expected Output
10
Your Code's Output
10
View Outputs Side By Side
Input(s)
{
  "height": 3,
  "width": 4
}
Test Case 2 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "height": 2,
  "width": 3
}
Test Case 3 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "height": 3,
  "width": 2
}
Test Case 4 passed!
Expected Output
70
Your Code's Output
70
View Outputs Side By Side
Input(s)
{
  "height": 5,
  "width": 5
}
Test Case 5 passed!
Expected Output
126
Your Code's Output
126
View Outputs Side By Side
Input(s)
{
  "height": 6,
  "width": 5
}
Test Case 6 passed!
Expected Output
210
Your Code's Output
210
View Outputs Side By Side
Input(s)
{
  "height": 5,
  "width": 7
}
Test Case 7 passed!
Expected Output
10
Your Code's Output
10
View Outputs Side By Side
Input(s)
{
  "height": 2,
  "width": 10
}
Test Case 8 passed!
Expected Output
11
Your Code's Output
11
View Outputs Side By Side
Input(s)
{
  "height": 2,
  "width": 11
}
Test Case 9 passed!
Expected Output
495
Your Code's Output
495
View Outputs Side By Side
Input(s)
{
  "height": 9,
  "width": 5
}
Test Case 10 passed!
Expected Output
462
Your Code's Output
462
View Outputs Side By Side
Input(s)
{
  "height": 7,
  "width": 6
}
Test Case 11 passed!
Expected Output
330
Your Code's Output
330
View Outputs Side By Side
Input(s)
{
  "height": 5,
  "width": 8
}
Test Case 12 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "height": 2,
  "width": 2
}
Test Case 13 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "height": 1,
  "width": 2
}
Test Case 14 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "height": 2,
  "width": 1
}
Test Case 15 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "height": 3,
  "width": 3
}
 */