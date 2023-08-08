using LinkedList._02_Hard;
using System.Collections.Generic;
using NUnit.Framework;

namespace AlgoExpertTestCases.LinkedListTest
{

    public class ReverseLinkedListTest
    {
        [Test]
        public void TestCase1()
        {
            ReverseLinkedLists.LinkedList test = newLinkedList(new int[] { 0, 1, 2, 3, 4, 5 });
            List<int> result = toList(ReverseLinkedLists.ReverseLinkedList(test));
            int[] expected = new int[] { 5, 4, 3, 2, 1, 0 };
            Assert.AreEqual(result, expected);
            //Utils.AssertTrue(arraysEqual(result, expected));
        }

        public ReverseLinkedLists.LinkedList newLinkedList(int[] values)
        {
            ReverseLinkedLists.LinkedList ll = new ReverseLinkedLists.LinkedList(values[0]);
            ReverseLinkedLists.LinkedList current = ll;
            for (int i = 1; i < values.Length; i++)
            {
                current.Next = new ReverseLinkedLists.LinkedList(values[i]);
                current = current.Next;
            }
            return ll;
        }

        public List<int> toList(ReverseLinkedLists.LinkedList ll)
        {
            List<int> arr = new List<int>();
            ReverseLinkedLists.LinkedList current = ll;
            while (current != null)
            {
                arr.Add(current.Value);
                current = current.Next;
            }
            return arr;
        }

        public bool arraysEqual(List<int> arr1, int[] arr2)
        {
            if (arr1.Count != arr2.Length) return false;
            for (int i = 0; i < arr1.Count; i++)
            {
                if (arr1[i] != arr2[i]) return false;
            }
            return true;
        }
    }

}
