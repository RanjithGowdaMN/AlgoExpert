using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps._02_Hard
{
    class SortKSortedArrayProgram
    {
        public int[] SortKSortedArray(int[] array, int k)
        {
            // Write your code here.
            List<int> heapValues = new List<int>();
            for (int i = 0; i < Math.Min(k + 1, array.Length); i++)
            {
                heapValues.Add(array[i]);
            }
            MinHeap minHeapWithKElements = new MinHeap(heapValues);
            int nextIndexToInsertElement = 0;
            for (int idx = k + 1; idx < array.Length; idx++)
            {
                int minElement = minHeapWithKElements.remove();
                array[nextIndexToInsertElement] = minElement;
                nextIndexToInsertElement += 1;

                int currentElement = array[idx];
                minHeapWithKElements.insert(currentElement);
            }

            while (!minHeapWithKElements.isEmpty())
            {
                int minElement = minHeapWithKElements.remove();
                array[nextIndexToInsertElement] = minElement;
                nextIndexToInsertElement += 1;
            }
            return array;
        }
        public class MinHeap
        {
            List<int> heap = new List<int>();

            public MinHeap(List<int> array)
            {
                heap = buildHeap(array);
            }
            public List<int> buildHeap(List<int> array)
            {
                int firstParentIdx = (array.Count - 2) / 2;
                for (int currentIdx = firstParentIdx; currentIdx >= 0; currentIdx--)
                {
                    siftDown(currentIdx, array.Count - 1, array);
                }
                return array;
            }

            public void siftDown(int currentIdx, int endIdx, List<int> heap)
            {
                int childOneIdx = currentIdx * 2 + 1;
                while (childOneIdx <= endIdx)
                {
                    int childTwoIdx =
                        currentIdx * 2 + 2 <= endIdx ? currentIdx * 2 + 2 : -1;
                    int idxToSwap;
                    if (childTwoIdx != -1 && heap[childTwoIdx] < heap[childOneIdx])
                    {
                        idxToSwap = childTwoIdx;
                    }
                    else
                    {
                        idxToSwap = childOneIdx;
                    }
                    if (heap[idxToSwap] < heap[currentIdx])
                    {
                        swap(currentIdx, idxToSwap, heap);
                        currentIdx = idxToSwap;
                        childOneIdx = currentIdx * 2 + 1;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            public void siftUp(int currentIdx, List<int> heap)
            {
                int parentIdx = (currentIdx - 1) / 2;
                while (currentIdx > 0 && heap[currentIdx] < heap[parentIdx])
                {
                    swap(currentIdx, parentIdx, heap);
                    currentIdx = parentIdx;
                    parentIdx = (currentIdx - 1) / 2;
                }
            }
            public int peek()
            {
                return heap[0];
            }
            public int remove()
            {
                swap(0, heap.Count - 1, heap);
                int valueToRemove = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);
                siftDown(0, heap.Count - 1, heap);
                return valueToRemove;
            }

            public void insert(int value)
            {
                heap.Add(value);
                siftUp(heap.Count - 1, heap);
            }

            public void swap(int i, int j, List<int> heap)
            {
                int temp = heap[j];
                heap[j] = heap[i];
                heap[i] = temp;
            }
            public bool isEmpty()
            {
                return heap.Count == 0;
            }
        }
    }
}

/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[] input = new int[] { 3, 2, 1, 5, 4, 7, 6, 5 };
    int k = 3;
    int[] expected = new int[] { 1, 2, 3, 4, 5, 5, 6, 7 };
    var actual = new Program().SortKSortedArray(input, k);
    for (int i = 0; i < expected.Length; i++) {
      Utils.AssertTrue(expected[i] == actual[i]);
    }
  }
}

4 / 14 test cases passed.

Test Case 1 passed!
Expected Output
[1, 2, 3, 4, 5, 5, 6, 7]
Your Code's Output
[1, 2, 3, 4, 5, 5, 6, 7]
View Outputs Side By Side
Input(s)
{
  "array": [3, 2, 1, 5, 4, 7, 6, 5],
  "k": 3
}
Test Case 2 passed!
Expected Output
[-4, -3, -1, 1, 2, 3]
Your Code's Output
[-4, -3, -1, 1, 2, 3]
View Outputs Side By Side
Input(s)
{
  "array": [-1, -3, -4, 2, 1, 3],
  "k": 2
}
Test Case 3 passed!
Expected Output
[1, 2, 3, 4, 5]
Your Code's Output
[1, 2, 3, 4, 5]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5],
  "k": 0
}
Test Case 4 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "array": [],
  "k": 5
}
Test Case 5 passed!
Expected Output
[1, 2, 2, 3, 4, 5, 6]
Your Code's Output
[1, 2, 2, 3, 4, 5, 6]
View Outputs Side By Side
Input(s)
{
  "array": [4, 3, 2, 1, 2, 5, 6],
  "k": 4
}
Test Case 6 passed!
Expected Output
[0, 1, 2, 3, 4, 5, 6, 7, 7, 8, 9]
Your Code's Output
[0, 1, 2, 3, 4, 5, 6, 7, 7, 8, 9]
View Outputs Side By Side
Input(s)
{
  "array": [3, 2, 1, 0, 4, 7, 6, 5, 9, 8, 7],
  "k": 3
}
Test Case 7 passed!
Expected Output
[1, 2, 3, 4, 5, 6, 7, 8]
Your Code's Output
[1, 2, 3, 4, 5, 6, 7, 8]
View Outputs Side By Side
Input(s)
{
  "array": [2, 1, 4, 3, 5, 6, 8, 7],
  "k": 1
}
Test Case 8 passed!
Expected Output
[0, 1, 1, 1, 1, 1, 1, 1]
Your Code's Output
[0, 1, 1, 1, 1, 1, 1, 1]
View Outputs Side By Side
Input(s)
{
  "array": [1, 0, 1, 1, 1, 1, 1, 1],
  "k": 1
}
Test Case 9 passed!
Expected Output
[-100, 2, 3, 4, 5]
Your Code's Output
[-100, 2, 3, 4, 5]
View Outputs Side By Side
Input(s)
{
  "array": [5, 4, 3, 2, -100],
  "k": 5
}
Test Case 10 passed!
Expected Output
[1, 2, 3, 3, 4, 4, 5, 6, 7, 8, 9, 11, 12]
Your Code's Output
[1, 2, 3, 3, 4, 4, 5, 6, 7, 8, 9, 11, 12]
View Outputs Side By Side
Input(s)
{
  "array": [3, 3, 2, 1, 6, 4, 4, 5, 9, 7, 8, 11, 12],
  "k": 3
}
Test Case 11 passed!
Expected Output
[1]
Your Code's Output
[1]
View Outputs Side By Side
Input(s)
{
  "array": [1],
  "k": 1
}
Test Case 12 passed!
Expected Output
[-5, -1]
Your Code's Output
[-5, -1]
View Outputs Side By Side
Input(s)
{
  "array": [-1, -5],
  "k": 1
}
Test Case 13 passed!
Expected Output
[-3, -2, 1, 1, 1, 2, 2, 3, 3, 8, 9, 12, 100, 130]
Your Code's Output
[-3, -2, 1, 1, 1, 2, 2, 3, 3, 8, 9, 12, 100, 130]
View Outputs Side By Side
Input(s)
{
  "array": [-2, -3, 1, 2, 3, 1, 1, 2, 3, 8, 100, 130, 9, 12],
  "k": 4
}
Test Case 14 passed!
Expected Output
[1, 1, 2, 3, 4, 5, 6]
Your Code's Output
[1, 1, 2, 3, 4, 5, 6]
View Outputs Side By Side
Input(s)
{
  "array": [1, 2, 3, 4, 5, 6, 1],
  "k": 8
}
 
 */