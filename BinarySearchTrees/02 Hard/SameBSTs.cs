using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees._02_Hard
{
    internal class SameBSTs
    {
        public static bool SameBsts(List<int> arrayOne, List<int> arrayTwo)
        {
            // Write your code here.
            return areSameBsts(
                arrayOne, arrayTwo, 0, 0, Int32.MinValue, Int32.MaxValue
            );
        }
        public static bool areSameBsts(
            List<int> arrayOne,
            List<int> arrayTwo,
            int rootIdxOne,
            int rootIdxTwo,
            int minVal,
            int maxVal
        )
        {
            if (rootIdxOne == -1 || rootIdxTwo == -1) return rootIdxOne == rootIdxTwo;
            if (arrayOne[rootIdxOne] != arrayTwo[rootIdxTwo]) return false;

            int leftRootIdxOne = getIdxOfFirstSmaller(arrayOne, rootIdxOne, minVal);
            int leftRootIdxTwo = getIdxOfFirstSmaller(arrayTwo, rootIdxTwo, minVal);
            int rightRootIdxOne =
                getIdxOfFirstBiggerOrEqual(arrayOne, rootIdxOne, maxVal);
            int rightRootIdxTwo =
                getIdxOfFirstBiggerOrEqual(arrayTwo, rootIdxTwo, maxVal);

            int currentValue = arrayOne[rootIdxOne];
            bool leftAreSame = areSameBsts(
                arrayOne, arrayTwo, leftRootIdxOne, leftRootIdxTwo, minVal, currentValue
            );
            bool rightAreSame = areSameBsts(
                arrayOne, arrayTwo, rightRootIdxOne, rightRootIdxTwo, currentValue, maxVal
            );
            return leftAreSame && rightAreSame;
        }
        public static int getIdxOfFirstSmaller(
            List<int> array, int startingIdx, int minVal
        )
        {
            // find the index of the first smaller value after the startingidx
            // make sure that this value is greater than or equal to the minval
            // which is the value of the previous parent node in the BST if await
            // ist, then that value is located in the left subtree of the
            // previous parent node
            for (int i = startingIdx + 1; i < array.Count; i++)
            {
                if (array[i] < array[startingIdx] && array[i] >= minVal) return i;
            }
            return -1;
        }
        public static int getIdxOfFirstBiggerOrEqual(
            List<int> array, int startingIdx, int maxVal
        )
        {
            // find the index of the first bigger/equal value after the startingidx
            // make sure that this value is smaller than or equal to the maxVal
            // of the previous parent node in the BST. is it isn't then that valule
            // is located in the right subtree of the previous parent node.
            for (int i = startingIdx + 1; i < array.Count; i++)
            {
                if (array[i] >= array[startingIdx] && array[i] < maxVal) return i;
            }
            return -1;
        }

    }
}
/*
 ______________________________________________________________________________

 public static bool SameBsts(List<int> arrayOne, List<int> arrayTwo) {
    // Write your code here.
      if(arrayOne.Count != arrayTwo.Count) return false;
      
      if(arrayOne.Count ==0 && arrayTwo.Count == 0) return true;

      if(arrayOne[0] != arrayTwo[0]) return false;

      List<int> leftOne = getSmaller(arrayOne);
      List<int> leftTwo = getSmaller(arrayTwo);
      List<int> rightOne = getBiggerOrEqual(arrayOne);
      List<int> rightTwo = getBiggerOrEqual(arrayTwo);
      
    return SameBsts(leftOne, leftTwo) && SameBsts(rightOne, rightTwo);
  }
    public static List<int> getSmaller(List<int> array){
        List<int> smaller= new List<int>();
        for(int i = 1; i<array.Count; i++){
            if(array[i] < array[0]) smaller.Add(array[i]);
        }
        return smaller;
    }

    public static List<int> getBiggerOrEqual(List<int> array){
        List<int> biggerOrEqual = new List<int>();
        for(int i=1; i < array.Count; i++){
            if(array[i] >= array[0]) biggerOrEqual.Add(array[i]);
        }
        return biggerOrEqual;
    }
_____________________________________________________________________________________

using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    List<int> arrayOne = new List<int>() { 10, 15, 8, 12, 94, 81, 5, 2, 11 };
    List<int> arrayTwo = new List<int>() { 10, 8, 5, 15, 2, 12, 11, 94, 81 };
    Utils.AssertTrue(Program.SameBsts(arrayOne, arrayTwo) == true);
  }
}

13 / 13 test cases passed.

Test Case 1 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "arrayOne": [10, 15, 8, 12, 94, 81, 5, 2, 11],
  "arrayTwo": [10, 8, 5, 15, 2, 12, 11, 94, 81]
}
Test Case 2 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1, 2, 3, 4, 5, 6, 7],
  "arrayTwo": [1, 2, 3, 4, 5, 6, 7]
}
Test Case 3 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "arrayOne": [7, 6, 5, 4, 3, 2, 1],
  "arrayTwo": [7, 6, 5, 4, 3, 2, 1]
}
Test Case 4 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "arrayOne": [10, 15, 8, 12, 94, 81, 5, 2],
  "arrayTwo": [10, 8, 5, 15, 2, 12, 94, 81]
}
Test Case 5 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "arrayOne": [10, 15, 8, 12, 94, 81, 5, 2],
  "arrayTwo": [11, 8, 5, 15, 2, 12, 94, 81]
}
Test Case 6 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "arrayOne": [10, 15, 8, 12, 94, 81, 5, 2, -1, 100, 45, 12, 8, -1, 8, 2, -34],
  "arrayTwo": [10, 8, 5, 15, 2, 12, 94, 81, -1, -1, -34, 8, 2, 8, 12, 45, 100]
}
Test Case 7 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "arrayOne": [10, 15, 8, 12, 94, 81, 5, 2, -1, 101, 45, 12, 8, -1, 8, 2, -34],
  "arrayTwo": [10, 8, 5, 15, 2, 12, 94, 81, -1, -1, -34, 8, 2, 8, 12, 45, 100]
}
Test Case 8 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "arrayOne": [5, 2, -1, 100, 45, 12, 8, -1, 8, 10, 15, 8, 12, 94, 81, 2, -34],
  "arrayTwo": [5, 8, 10, 15, 2, 8, 12, 45, 100, 2, 12, 94, 81, -1, -1, -34, 8]
}
Test Case 9 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "arrayOne": [10, 15, 8, 12, 94, 81, 5, 2, -1, 100, 45, 12, 9, -1, 8, 2, -34],
  "arrayTwo": [10, 8, 5, 15, 2, 12, 94, 81, -1, -1, -34, 8, 2, 9, 12, 45, 100]
}
Test Case 10 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "arrayOne": [1, 2, 3, 4, 5, 6, 7, 8],
  "arrayTwo": [1, 2, 3, 4, 5, 6, 7]
}
Test Case 11 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "arrayOne": [7, 6, 5, 4, 3, 2, 1],
  "arrayTwo": [7, 6, 5, 4, 3, 2, 1, 0]
}
Test Case 12 passed!
Expected Output
false
Your Code's Output
false
View Outputs Side By Side
Input(s)
{
  "arrayOne": [10, 15, 8, 12, 94, 81, 5, 2, 10],
  "arrayTwo": [10, 8, 5, 15, 2, 10, 12, 94, 81]
}
Test Case 13 passed!
Expected Output
true
Your Code's Output
true
View Outputs Side By Side
Input(s)
{
  "arrayOne": [50, 76, 81, 23, 23, 23, 100, 56, 12, -1, 3],
  "arrayTwo": [50, 23, 76, 23, 23, 12, 56, 81, -1, 3, 100]
}

 
 */