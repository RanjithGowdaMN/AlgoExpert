using System;

public class TandemBicycleProgram
{
    public int TandemBicycle(
      int[] redShirtSpeeds, int[] blueShirtSpeeds, bool fastest
    )
    {
        Array.Sort(redShirtSpeeds);
        Array.Sort(blueShirtSpeeds);

        if (!fastest)
        {
            revereseArrayInPlance(redShirtSpeeds);
        }
        int totalSpeed = 0;
        for (int i = 0; i < redShirtSpeeds.Length; i++)
        {
            int rider1 = redShirtSpeeds[i];
            int rider2 = blueShirtSpeeds[blueShirtSpeeds.Length - i - 1];
            totalSpeed += Math.Max(rider1, rider2);
        }
        return totalSpeed;
    }
    public void revereseArrayInPlance(int[] array)
    {
        int start = 0;
        int end = array.Length - 1;
        while (start < end)
        {
            int temp = array[start];
            array[start] = array[end];
            array[end] = temp;
            start++;
            end--;
        }
    }
}
/*
 using System;

public class ProgramTest {
 [Test]
 public void TestCase1() {
   int[] redShirtSpeeds = new int[] { 5, 5, 3, 9, 2 };
   int[] blueShirtSpeeds = new int[] { 3, 6, 7, 2, 1 };
   bool fastest = true;
   int expected = 32;
   var actual =
     new Program().TandemBicycle(redShirtSpeeds, blueShirtSpeeds, fastest);
   Utils.AssertTrue(expected == actual);
 }
}


17 / 17 test cases passed.

Test Case 1 passed!
Expected Output
32
Your Code's Output
32
View Outputs Side By Side
Input(s)
{
  "blueShirtSpeeds": [3, 6, 7, 2, 1],
  "fastest": true,
  "redShirtSpeeds": [5, 5, 3, 9, 2]
}
Test Case 2 passed!
Expected Output
25
Your Code's Output
25
View Outputs Side By Side
Input(s)
{
  "blueShirtSpeeds": [3, 6, 7, 2, 1],
  "fastest": false,
  "redShirtSpeeds": [5, 5, 3, 9, 2]
}
Test Case 3 passed!
Expected Output
30
Your Code's Output
30
View Outputs Side By Side
Input(s)
{
  "blueShirtSpeeds": [3, 3, 4, 6, 1, 2],
  "fastest": false,
  "redShirtSpeeds": [1, 2, 1, 9, 12, 3]
}
Test Case 4 passed!
Expected Output
37
Your Code's Output
37
View Outputs Side By Side
Input(s)
{
  "blueShirtSpeeds": [3, 3, 4, 6, 1, 2],
  "fastest": true,
  "redShirtSpeeds": [1, 2, 1, 9, 12, 3]
}
Test Case 5 passed!
Expected Output
816
Your Code's Output
816
View Outputs Side By Side
Input(s)
{
  "blueShirtSpeeds": [3, 3, 4, 6, 1, 2, 5, 6, 34, 256, 123, 32],
  "fastest": true,
  "redShirtSpeeds": [1, 2, 1, 9, 12, 3, 1, 54, 21, 231, 32, 1]
}
Test Case 6 passed!
Expected Output
484
Your Code's Output
484
View Outputs Side By Side
Input(s)
{
  "blueShirtSpeeds": [3, 3, 4, 6, 1, 2, 5, 6, 34, 256, 123, 32],
  "fastest": false,
  "redShirtSpeeds": [1, 2, 1, 9, 12, 3, 1, 54, 21, 231, 32, 1]
}
Test Case 7 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "blueShirtSpeeds": [5],
  "fastest": true,
  "redShirtSpeeds": [1]
}
Test Case 8 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "blueShirtSpeeds": [5],
  "fastest": false,
  "redShirtSpeeds": [1]
}
Test Case 9 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "blueShirtSpeeds": [1, 1, 1, 1],
  "fastest": true,
  "redShirtSpeeds": [1, 1, 1, 1]
}
Test Case 10 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "blueShirtSpeeds": [1, 1, 1, 1],
  "fastest": false,
  "redShirtSpeeds": [1, 1, 1, 1]
}
Test Case 11 passed!
Expected Output
48
Your Code's Output
48
View Outputs Side By Side
Input(s)
{
  "blueShirtSpeeds": [1, 1, 1, 1, 3, 3, 3, 3, 5, 7],
  "fastest": true,
  "redShirtSpeeds": [1, 1, 1, 1, 2, 2, 2, 2, 9, 11]
}
Test Case 12 passed!
Expected Output
36
Your Code's Output
36
View Outputs Side By Side
Input(s)
{
  "blueShirtSpeeds": [1, 1, 1, 1, 3, 3, 3, 3, 5, 7],
  "fastest": false,
  "redShirtSpeeds": [1, 1, 1, 1, 2, 2, 2, 2, 9, 11]
}
Test Case 13 passed!
Expected Output
49
Your Code's Output
49
View Outputs Side By Side
Input(s)
{
  "blueShirtSpeeds": [3, 4, 4, 1, 1, 8, 9],
  "fastest": true,
  "redShirtSpeeds": [9, 8, 2, 2, 3, 5, 6]
}
Test Case 14 passed!
Expected Output
35
Your Code's Output
35
View Outputs Side By Side
Input(s)
{
  "blueShirtSpeeds": [3, 4, 4, 1, 1, 8, 9],
  "fastest": false,
  "redShirtSpeeds": [9, 8, 2, 2, 3, 5, 6]
}
Test Case 15 passed!
Expected Output
15
Your Code's Output
15
View Outputs Side By Side
Input(s)
{
  "blueShirtSpeeds": [1, 2, 3, 4, 5],
  "fastest": false,
  "redShirtSpeeds": [5, 4, 3, 2, 1]
}
Test Case 16 passed!
Expected Output
21
Your Code's Output
21
View Outputs Side By Side
Input(s)
{
  "blueShirtSpeeds": [1, 2, 3, 4, 5],
  "fastest": true,
  "redShirtSpeeds": [5, 4, 3, 2, 1]
}
Test Case 17 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "blueShirtSpeeds": [],
  "fastest": true,
  "redShirtSpeeds": []
}
 */