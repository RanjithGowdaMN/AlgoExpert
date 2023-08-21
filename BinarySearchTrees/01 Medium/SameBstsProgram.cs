using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees._01_Medium
{
    class SameBstsProgram
    {
        public static bool SameBsts(List<int> arrayOne, List<int> arrayTwo)
        {
            // Write your code here.
            if (arrayOne.Count != arrayTwo.Count) return false;

            if (arrayOne.Count == 0 && arrayTwo.Count == 0) return true;

            if (arrayOne[0] != arrayTwo[0]) return false;

            List<int> leftOne = getSmaller(arrayOne);
            List<int> leftTwo = getSmaller(arrayTwo);
            List<int> rightOne = getBiggerOrEqual(arrayOne);
            List<int> rightTwo = getBiggerOrEqual(arrayTwo);

            return SameBsts(leftOne, leftTwo) && SameBsts(rightOne, rightTwo);
        }
        public static List<int> getSmaller(List<int> array)
        {
            List<int> smaller = new List<int>();
            for (int i = 1; i < array.Count; i++)
            {
                if (array[i] < array[0]) smaller.Add(array[i]);
            }
            return smaller;
        }

        public static List<int> getBiggerOrEqual(List<int> array)
        {
            List<int> biggerOrEqual = new List<int>();
            for (int i = 1; i < array.Count; i++)
            {
                if (array[i] >= array[0]) biggerOrEqual.Add(array[i]);
            }
            return biggerOrEqual;
        }
    }
}
/*
 * using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    List<int> arrayOne = new List<int>() { 10, 15, 8, 12, 94, 81, 5, 2, 11 };
    List<int> arrayTwo = new List<int>() { 10, 8, 5, 15, 2, 12, 11, 94, 81 };
    Utils.AssertTrue(Program.SameBsts(arrayOne, arrayTwo) == true);
  }
}


 
   public static bool SameBsts(List<int> arrayOne, List<int> arrayTwo) {
    // Write your code here.
    return areSameBsts(
        arrayOne, arrayTwo, 0,0, Int32.MinValue, Int32.MaxValue
    );
  }
    public static bool areSameBsts(
        List<int> arrayOne,
        List<int> arrayTwo,
        int rootIdxOne,
        int rootIdxTwo,
        int minVal,
        int maxVal
    ){
        if(rootIdxOne == -1 || rootIdxTwo == -1) return rootIdxOne == rootIdxTwo;
        if(arrayOne[rootIdxOne] != arrayTwo[rootIdxTwo]) return false;

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
    ){
        // find the index of the first smaller value after the startingidx
        // make sure that this value is greater than or equal to the minval
        // which is the value of the previous parent node in the BST if await
        // ist, then that value is located in the left subtree of the
        // previous parent node
        for(int i = startingIdx + 1; i < array.Count; i++){
            if(array[i] < array[startingIdx] && array[i] >= minVal) return i;
        }
        return -1;
    }
    public static int getIdxOfFirstBiggerOrEqual(
        List<int> array, int startingIdx, int maxVal
    ){
        // find the index of the first bigger/equal value after the startingidx
        // make sure that this value is smaller than or equal to the maxVal
        // of the previous parent node in the BST. is it isn't then that valule
        // is located in the right subtree of the previous parent node.
        for(int i = startingIdx + 1; i < array.Count; i++){
            if(array[i] >= array[startingIdx] && array[i] < maxVal) return i;
        }
        return -1;
    }
 */