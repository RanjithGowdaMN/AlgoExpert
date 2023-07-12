﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._02_Hard
{
    class MaxProfitWithKTransactionsProgram
    {
        //O(n^2k)
        public static int MaxProfitWithKTransactions(int[] prices, int k)
        {
            // Write your code here.
            if (prices.Length == 0)
            {
                return 0;
            }
            int[,] profits = new int[k + 1, prices.Length];
            for (int t = 1; t < k + 1; t++)
            {
                int maxThusFar = Int32.MinValue;
                for (int d = 1; d < prices.Length; d++)
                {
                    maxThusFar = Math.Max(maxThusFar, profits[t - 1, d - 1] - prices[d - 1]);
                    profits[t, d] = Math.Max(profits[t, d - 1], maxThusFar + prices[d]);
                }
            }
            return profits[k, prices.Length - 1];
        }

        //O(nk)
        public static int MaxProfitWithKTransactionsSolution2(int[] prices, int k)
        {
            // Write your code here.
            if (prices.Length == 0)
            {
                return 0;
            }
            int[] evenProfits = new int[prices.Length];
            int[] oddProfits = new int[prices.Length];
            for (int i = 0; i < prices.Length; i++)
            {
                evenProfits[i] = 0;
                oddProfits[i] = 0;
            }
            for (int t = 1; t < k + 1; t++)
            {
                int maxThusFar = Int32.MinValue;
                int[] currentProfits = new int[prices.Length];
                int[] previousProfits = new int[prices.Length];
                if (t % 2 == 1)
                {
                    currentProfits = oddProfits;
                    previousProfits = evenProfits;
                }
                else
                {
                    currentProfits = evenProfits;
                    previousProfits = oddProfits;
                }
                for (int d = 1; d < prices.Length; d++)
                {
                    maxThusFar = Math.Max(maxThusFar, previousProfits[d - 1] - prices[d - 1]);
                    currentProfits[d] = Math.Max(currentProfits[d - 1], maxThusFar + prices[d]);
                }
            }
            return k % 2 == 0 ? evenProfits[prices.Length - 1] : oddProfits[prices.Length - 1];
        }
    }
}
/*
 Expected Output
93
Your Code's Output
93
View Outputs Side By Side
Input(s)
{
  "k": 2,
  "prices": [5, 11, 3, 50, 60, 90]
}
Test Case 2 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "k": 1,
  "prices": []
}
Test Case 3 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "k": 1,
  "prices": [1]
}
Test Case 4 passed!
Expected Output
9
Your Code's Output
9
View Outputs Side By Side
Input(s)
{
  "k": 1,
  "prices": [1, 10]
}
Test Case 5 passed!
Expected Output
9
Your Code's Output
9
View Outputs Side By Side
Input(s)
{
  "k": 3,
  "prices": [1, 10]
}
Test Case 6 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "k": 1,
  "prices": [3, 2, 5, 7, 1, 3, 7]
}
Test Case 7 passed!
Expected Output
93
Your Code's Output
93
View Outputs Side By Side
Input(s)
{
  "k": 3,
  "prices": [5, 11, 3, 50, 60, 90]
}
Test Case 8 passed!
Expected Output
97
Your Code's Output
97
View Outputs Side By Side
Input(s)
{
  "k": 2,
  "prices": [5, 11, 3, 50, 40, 90]
}
Test Case 9 passed!
Expected Output
103
Your Code's Output
103
View Outputs Side By Side
Input(s)
{
  "k": 3,
  "prices": [5, 11, 3, 50, 40, 90]
}
Test Case 10 passed!
Expected Output
106
Your Code's Output
106
View Outputs Side By Side
Input(s)
{
  "k": 2,
  "prices": [50, 25, 12, 4, 3, 10, 1, 100]
}
Test Case 11 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "k": 5,
  "prices": [100, 99, 98, 97, 1]
}
Test Case 12 passed!
Expected Output
1485
Your Code's Output
1485
View Outputs Side By Side
Input(s)
{
  "k": 5,
  "prices": [1, 100, 2, 200, 3, 300, 4, 400, 5, 500]
}
Test Case 13 passed!
Expected Output
499
Your Code's Output
499
View Outputs Side By Side
Input(s)
{
  "k": 5,
  "prices": [1, 100, 101, 200, 201, 300, 301, 400, 401, 500]
}
Test Case 14 passed!
Expected Output
84
Your Code's Output
84
View Outputs Side By Side
Input(s)
{
  "k": 4,
  "prices": [1, 25, 24, 23, 12, 36, 14, 40, 31, 41, 5]
}
Test Case 15 passed!
Expected Output
62
Your Code's Output
62
View Outputs Side By Side
Input(s)
{
  "k": 2,
  "prices": [1, 25, 24, 23, 12, 36, 14, 40, 31, 41, 5]
}
 */