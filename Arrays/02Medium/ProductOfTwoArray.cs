using System;

namespace Arrays
{
    public class ProductOfTwoArray
    {
        public static int[] ArrayOfProducts(int[] array)
        {
            // Write your code here.
            int[] left  = new int[array.Length];
            int[] output = new int[array.Length];
            int product = 1;
            for (int i = 0; i < array.Length; i++)
            {
                left[i] = product;
                product = array[i]*product;
            }
            product = 1;
            for (int j = array.Length -1; j >= 0; j--)
            {
                output[j] = product * left[j];
                product = array[j]*product;
            }

            foreach (int i in output)
            {
                Console.WriteLine(i);
            }

            return output;
        }

    }

}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var input = new int[] { 5, 1, 4, 2 };
    var expected = new int[] { 8, 40, 10, 20 };
    int[] actual = new Program().ArrayOfProducts(input);
    Utils.AssertTrue(expected.Length == actual.Length);
    for (int i = 0; i < actual.Length; i++) {
      Utils.AssertTrue(actual[i] == expected[i]);
    }
  }
}

11 / 11 test cases passed.

Test Case 1 passed!
Expected Output
[8, 40, 10, 20]
Your Code's Output
[8, 40, 10, 20]
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 4, 2]
}
Test Case 2 passed!
Expected Output
[384, 48, 64, 192, 96]
Your Code's Output
[384, 48, 64, 192, 96]
View Outputs Side By Side
Input(s)
{
  "array": [1, 8, 6, 2, 4]
}
Test Case 3 passed!
Expected Output
[672, -1680, 840, -240, 560]
Your Code's Output
[672, -1680, 840, -240, 560]
View Outputs Side By Side
Input(s)
{
  "array": [-5, 2, -4, 14, -6]
}
Test Case 4 passed!
Expected Output
[1620, 4860, 7290, 14580, 1620, 2916, 4860, 7290]
Your Code's Output
[1620, 4860, 7290, 14580, 1620, 2916, 4860, 7290]
View Outputs Side By Side
Input(s)
{
  "array": [9, 3, 2, 1, 9, 5, 3, 2]
}
Test Case 5 passed!
Expected Output
[4, 4]
Your Code's Output
[4, 4]
View Outputs Side By Side
Input(s)
{
  "array": [4, 4]
}
Test Case 6 passed!
Expected Output
[0, 0, 0, 0]
Your Code's Output
[0, 0, 0, 0]
View Outputs Side By Side
Input(s)
{
  "array": [0, 0, 0, 0]
}
Test Case 7 passed!
Expected Output
[1, 1, 1, 1]
Your Code's Output
[1, 1, 1, 1]
View Outputs Side By Side
Input(s)
{
  "array": [1, 1, 1, 1]
}
Test Case 8 passed!
Expected Output
[1, 1, 1]
Your Code's Output
[1, 1, 1]
View Outputs Side By Side
Input(s)
{
  "array": [-1, -1, -1]
}
Test Case 9 passed!
Expected Output
[-1, -1, -1, -1]
Your Code's Output
[-1, -1, -1, -1]
View Outputs Side By Side
Input(s)
{
  "array": [-1, -1, -1, -1]
}
Test Case 10 passed!
Expected Output
[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
Your Code's Output
[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
View Outputs Side By Side
Input(s)
{
  "array": [0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
}
Test Case 11 passed!
Expected Output
[362880, 0, 0, 0, 0, 0, 0, 0, 0, 0]
Your Code's Output
[362880, 0, 0, 0, 0, 0, 0, 0, 0, 0]
View Outputs Side By Side
Input(s)
{
  "array": [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
}
 
 */