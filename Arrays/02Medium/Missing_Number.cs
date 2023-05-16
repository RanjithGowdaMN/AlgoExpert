using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._02Medium
{
    public class Missing_Numbers
    {
        public int[] MissingNumbers(int[] nums)
        {
            // Write your code here.
            HashSet<int> included = new HashSet<int>();

            foreach (var num in nums)
            {
                included.Add(num);
            }
            int[] solution = new int[] { -1, -1 };
            for (int i = 1; i < nums.Length + 3; i++)
            {
                if (!included.Contains(i))
                {
                    if (solution[0] == -1)
                    {
                        solution[0] = i;
                    }
                    else
                    {
                        solution[1] = i;
                    }
                }
            }

            return solution;
        }
    }


}

/*
 Test Case 1
{
  "nums": []
}
Test Case 2
{
  "nums": [1]
}
Test Case 3
{
  "nums": [2]
}
Test Case 4
{
  "nums": [3]
}
Test Case 5
{
  "nums": [1, 3]
}
Test Case 6
{
  "nums": [3, 1]
}
Test Case 7
{
  "nums": [1, 2, 3]
}
Test Case 8
{
  "nums": [3, 2, 1]
}
Test Case 9
{
  "nums": [3, 1, 2]
}
Test Case 10
{
  "nums": [3, 4, 5]
}
Test Case 11
{
  "nums": [4, 5, 3]
}
Test Case 12
{
  "nums": [1, 3, 4, 5]
}
Test Case 13
{
  "nums": [4, 5, 1, 3]
}
Test Case 14
{
  "nums": [1, 2, 4, 5, 7]
}
Test Case 15
{
  "nums": [1, 2, 7, 5, 4]
}
Test Case 16
{
  "nums": [1, 2, 3, 4, 5, 6, 7]
}
Test Case 17
{
  "nums": [7, 6, 5, 4, 3, 2, 1]
}
Test Case 18
{
  "nums": [3, 5, 1, 2, 4, 7, 6]
}
Test Case 19
{
  "nums": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 15, 16, 17, 18, 20, 21, 22]
}
Test Case 20
{
  "nums": [3, 5, 7, 8, 1, 10, 11, 2, 4, 13, 17, 22, 18, 21, 16, 20, 6, 9, 15, 12]
}
Test Case 21
{
  "nums": [3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
}
Test Case 22
{
  "nums": [14, 15, 16, 17, 18, 19, 20, 21, 22, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
}
Test Case 23
{
  "nums": [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
}
Test Case 24
{
  "nums": [11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
}
 */