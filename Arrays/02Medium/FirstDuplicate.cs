
using System;
using System.Collections.Generic;

namespace Arrays
{
    public class FirstDuplicate
    {

        public static int FirstDuplicateValue(int[] array)
        {
            // Write your code here.
            HashSet<int> set = new HashSet<int>();
            foreach (var val in array)
            {
                int index = Math.Abs(val) - 1;
                if (array[index] < 0)
                {
                    return Math.Abs(val);
                }
                else
                {
                    array[index] *= -1;
                }
            }
            return -1;
        }
    }
}

//public class ProgramTest
//{
//    [Test]
//    public void TestCase1()
//    {
//        var input = new int[] { 2, 1, 5, 2, 3, 3, 4 };
//        var expected = 2;
//        var actual = new FirstDuplicate().FirstDuplicateValue(input);
//        Utils.AssertTrue(expected == actual);
//    }
//}

