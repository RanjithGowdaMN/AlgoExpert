using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._03_Hard
{
    class CMinRewards
    {
        public static int MinRewards(int[] scores)
        {
            // Write your code here.
            int[] rewards = new int[scores.Length];
            Array.Fill(rewards, 1);
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] > scores[i - 1])
                {
                    rewards[i] = rewards[i - 1] + 1;
                }
            }

            for (int i = scores.Length - 2; i >= 0; i--)
            {

                if (scores[i] > scores[i + 1])
                {
                    rewards[i] = Math.Max(rewards[i], rewards[i + 1] + 1);
                }
            }
            return rewards.Sum();
        }
    }
}
//Expected Output
//25
//Your Code's Output
//25
//View Outputs Side By Side
//Input(s)
//{
//    "scores": [8, 4, 2, 1, 3, 6, 7, 9, 5]
//}
//Test Case 2 passed!
//Expected Output
//1
//Your Code's Output
//1
//View Outputs Side By Side
//Input(s)
//{
//    "scores": [1]
//}
//Test Case 3 passed!
//Expected Output
//3
//Your Code's Output
//3
//View Outputs Side By Side
//Input(s)
//{
//    "scores": [5, 10]
//}
//Test Case 4 passed!
//Expected Output
//3
//Your Code's Output
//3
//View Outputs Side By Side
//Input(s)
//{
//    "scores": [10, 5]
//}
//Test Case 5 passed!
//Expected Output
//8
//Your Code's Output
//8
//View Outputs Side By Side
//Input(s)
//{
//    "scores": [4, 2, 1, 3]
//}
//Test Case 6 passed!
//Expected Output
//9
//Your Code's Output
//9
//View Outputs Side By Side
//Input(s)
//{
//    "scores": [0, 4, 2, 1, 3]
//}
//Test Case 7 passed!
//Expected Output
//52
//Your Code's Output
//52
//View Outputs Side By Side
//Input(s)
//{
//    "scores": [2, 20, 13, 12, 11, 8, 4, 3, 1, 5, 6, 7, 9, 0]
//}
//Test Case 8 passed!
//Expected Output
//15
//Your Code's Output
//15
//View Outputs Side By Side
//Input(s)
//{
//    "scores": [2, 1, 4, 3, 6, 5, 8, 7, 10, 9]
//}
//Test Case 9 passed!
//Expected Output
//93
//Your Code's Output
//93
//View Outputs Side By Side
//Input(s)
//{
//    "scores": [800, 400, 20, 10, 30, 61, 70, 90, 17, 21, 22, 13, 12, 11, 8, 4, 2, 1, 3, 6, 7, 9, 0, 68, 55, 67, 57, 60, 51, 661, 50, 65, 53]
//}
