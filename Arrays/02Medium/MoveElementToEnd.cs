using System;
using System.Collections.Generic;

namespace Arrays
{
    public class MoveElementToEnd
    {

        public static List<int> MoveElementToEndT(List<int> array, int toMove)
        {
            // Write your code here.

            if (array.Count == 1 || array.Count == 0)
            {
                return array;
            }

            int right = array.Count -1;
            int left = 0;
            while (left<right)
            {

                while (left <= right)
                {
                    if (array[left] != toMove)
                    {
                        left++;
                    }
                    else
                    {
                        break;
                    }
                }
                while (left <= right)
                {
                    if (array[right] == toMove)
                    {
                        right--;
                    }
                    else
                    {
                        break;
                    }
                }
                if (left<right)
                {
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                }
                
            }

            foreach (int i in array)
            { Console.WriteLine(i); }


            return array;
        }



    }
}
/*
 using System.Linq;
using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    List<int> array = new List<int>() { 2, 1, 2, 2, 2, 3, 4, 2 };
    int toMove = 2;
    List<int> expectedStart = new List<int>() { 1, 3, 4 };
    List<int> expectedEnd = new List<int>() { 2, 2, 2, 2, 2 };
    List<int> output = Program.MoveElementToEnd(array, toMove);
    List<int> outputStart = output.GetRange(0, 3);
    outputStart.Sort();
    List<int> outputEnd = output.GetRange(3, output.Count - 3);
    Utils.AssertTrue(outputStart.SequenceEqual(expectedStart));
    Utils.AssertTrue(outputEnd.SequenceEqual(expectedEnd));
  }
}


11 / 11 test cases passed.

Test Case 1 passed!
Expected Output
[4, 1, 3, 2, 2, 2, 2, 2]
Your Code's Output
[4, 1, 3, 2, 2, 2, 2, 2]
View Outputs Side By Side
Input(s)
{
  "array": [2, 1, 2, 2, 2, 3, 4, 2],
  "toMove": 2
}
Test Case 2 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "array": [],
  "toMove": 3
}
Test Case 3 passed!
Expected Output
[1, 2, 4, 5, 6]
Your Code's Output
[1, 2, 4, 5, 6]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 4, 5, 6],
  "toMove": 3
}
Test Case 4 passed!
Expected Output
[3, 3, 3, 3, 3]
Your Code's Output
[3, 3, 3, 3, 3]
View Outputs Side By Side
Input(s)
{
  "array": [3, 3, 3, 3, 3],
  "toMove": 3
}
Test Case 5 passed!
Expected Output
[5, 1, 2, 4, 3]
Your Code's Output
[5, 1, 2, 4, 3]
View Outputs Side By Side
Input(s)
{
  "array": [3, 1, 2, 4, 5],
  "toMove": 3
}
Test Case 6 passed!
Expected Output
[1, 2, 4, 5, 3]
Your Code's Output
[1, 2, 4, 5, 3]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 4, 5, 3],
  "toMove": 3
}
Test Case 7 passed!
Expected Output
[1, 2, 5, 4, 3]
Your Code's Output
[1, 2, 5, 4, 3]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5],
  "toMove": 3
}
Test Case 8 passed!
Expected Output
[6, 4, 5, 2, 2, 2, 2]
Your Code's Output
[6, 4, 5, 2, 2, 2, 2]
View Outputs Side By Side
Input(s)
{
  "array": [2, 4, 2, 5, 6, 2, 2],
  "toMove": 2
}
Test Case 9 passed!
Expected Output
[12, 11, 10, 9, 8, 7, 1, 2, 3, 4, 6, 5, 5, 5, 5, 5, 5]
Your Code's Output
[12, 11, 10, 9, 8, 7, 1, 2, 3, 4, 6, 5, 5, 5, 5, 5, 5]
View Outputs Side By Side
Input(s)
{
  "array": [5, 5, 5, 5, 5, 5, 1, 2, 3, 4, 6, 7, 8, 9, 10, 11, 12],
  "toMove": 5
}
Test Case 10 passed!
Expected Output
[1, 2, 3, 4, 6, 7, 8, 9, 10, 11, 12, 5, 5, 5, 5, 5, 5]
Your Code's Output
[1, 2, 3, 4, 6, 7, 8, 9, 10, 11, 12, 5, 5, 5, 5, 5, 5]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 6, 7, 8, 9, 10, 11, 12, 5, 5, 5, 5, 5, 5],
  "toMove": 5
}
Test Case 11 passed!
Expected Output
[12, 1, 2, 11, 10, 3, 4, 6, 7, 9, 8, 5, 5, 5, 5, 5, 5]
Your Code's Output
[12, 1, 2, 11, 10, 3, 4, 6, 7, 9, 8, 5, 5, 5, 5, 5, 5]
View Outputs Side By Side
Input(s)
{
  "array": [5, 1, 2, 5, 5, 3, 4, 6, 7, 5, 8, 9, 10, 11, 5, 5, 12],
  "toMove": 5
}
 */