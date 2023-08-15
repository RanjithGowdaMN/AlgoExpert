using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion._00Easy
{
    class ProductSumsProgram
    {
        public static int ProductSum(List<object> array)
        {
            // Write your code here.
            return producthelper(array, 1);
        }

        public static int producthelper(List<object> array, int mult)
        {
            int sum = 0;
            foreach (object ele in array)
            {
                if (ele is IList<object>)
                {
                    sum += producthelper((List<object>)ele, mult + 1);
                }
                else
                {
                    sum += (int)ele;
                }
            }
            return sum * mult;
        }
    }
}


/*
 
 using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    List<object> test = new List<object>() {
      5,
      2,
      new List<object>() { 7, -1 },
      3,
      new List<object>() {
        6,
        new List<object>() { -13, 8 },
        4,
      },
    };
    Utils.AssertTrue(Program.ProductSum(test) == 12);
  }
}

6 / 6 test cases passed.

Test Case 1 passed!
Expected Output
12
Your Code's Output
12
View Outputs Side By Side
Input(s)
{
  "array": [5, 2, [7, -1], 3, [6, [-13, 8], 4]]
}
Test Case 2 passed!
Expected Output
15
Your Code's Output
15
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5]
}
Test Case 3 passed!
Expected Output
18
Your Code's Output
18
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, [3], 4, 5]
}
Test Case 4 passed!
Expected Output
27
Your Code's Output
27
View Outputs Side By Side
Input(s)
{
  "array": [
    [1, 2],
    3,
    [4, 5]
  ]
}
Test Case 5 passed!
Expected Output
600
Your Code's Output
600
View Outputs Side By Side
Input(s)
{
  "array": [
    [
      [
        [
          [5]
        ]
      ]
    ]
  ]
}
Test Case 6 passed!
Expected Output
1351
Your Code's Output
1351
View Outputs Side By Side
Input(s)
{
  "array": [9, [2, -3, 4], 1, [1, 1, [1, 1, 1]], [[[[3, 4, 1]]], 8], [1, 2, 3, 4, 5, [6, 7], -7], [1, [2, 3, [4, 5]], [6, 0, [7, 0, -8]], -7], [1, -3, 2, [1, -3, 2, [1, -3, 2], [1, -3, 2, [1, -3, 2]], [1, -3, 2]]], -3]
}

 */