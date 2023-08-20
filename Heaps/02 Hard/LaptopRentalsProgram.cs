using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps._02_Hard
{
    class LaptopRentalsProgram
    {
        public int LaptopRentals(List<List<int>> times)
        {
            if (times.Count == 0)
            {
                return 0;
            }
            times.Sort((a, b) => a[0].CompareTo(b[0]));
            List<List<int>> timesWhenLaptopIsUsed = new List<List<int>>();
            timesWhenLaptopIsUsed.Add(times[0]);
            MinHeap heap = new MinHeap(timesWhenLaptopIsUsed);

            for (int idx = 1; idx < times.Count; idx++)
            {
                List<int> currentInterval = times[idx];
                if (heap.peek()[1] <= currentInterval[0])
                {
                    heap.remove();
                }
                heap.insert(currentInterval);
            }
            return timesWhenLaptopIsUsed.Count;
        }

        public class MinHeap
        {
            List<List<int>> heap = new List<List<int>>();

            public MinHeap(List<List<int>> array)
            {
                heap = buildHeap(array);
            }
            public List<List<int>> buildHeap(List<List<int>> array)
            {
                int firstParentIdx = (array.Count - 2) / 2;
                for (int currentIdx = firstParentIdx; currentIdx >= 0; currentIdx--)
                {
                    siftDown(currentIdx, array.Count - 1, array);
                }
                return array;
            }

            public void siftDown(int currentIdx, int endIdx, List<List<int>> heap)
            {
                int newCurrentIdx = currentIdx;
                int childOneIdx = currentIdx * 2 + 1;
                while (childOneIdx <= endIdx)
                {
                    int childTwoIdx =
                        newCurrentIdx * 2 + 2 <= endIdx ? newCurrentIdx * 2 + 2 : -1;
                    int idxToSwap;
                    if (childTwoIdx != -1 && heap[childTwoIdx][1] < heap[childOneIdx][1])
                    {
                        idxToSwap = childTwoIdx;
                    }
                    else
                    {
                        idxToSwap = childOneIdx;
                    }
                    if (heap[idxToSwap][1] < heap[currentIdx][1])
                    {
                        swap(newCurrentIdx, idxToSwap, heap);
                        newCurrentIdx = idxToSwap;
                        childOneIdx = newCurrentIdx * 2 + 1;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            public void siftUp(int currentIdx, List<List<int>> heap)
            {
                int newCurrentIdx = currentIdx;
                int parentIdx = (currentIdx - 1) / 2;

                while (currentIdx > 0 && heap[newCurrentIdx][1] < heap[parentIdx][1])
                {
                    swap(newCurrentIdx, parentIdx, heap);
                    newCurrentIdx = parentIdx;
                    parentIdx = (newCurrentIdx - 1) / 2;
                }
            }
            public List<int> peek()
            {
                return heap[0];
            }
            public List<int> remove()
            {
                swap(0, heap.Count - 1, heap);
                List<int> valueToRemove = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);
                siftDown(0, heap.Count - 1, heap);
                return valueToRemove;
            }

            public void insert(List<int> value)
            {
                heap.Add(value);
                siftUp(heap.Count - 1, heap);
            }

            public void swap(int i, int j, List<List<int>> heap)
            {
                List<int> temp = heap[j];
                heap[j] = heap[i];
                heap[i] = temp;
            }
        }

        public int LaptopRentalsSol2(List<List<int>> times)
        {
            if (times.Count == 0)
            {
                return 0;
            }
            int usedLaptop = 0;
            List<int> startTimes = new List<int>();
            List<int> endTimes = new List<int>();

            foreach (var interval in times)
            {
                startTimes.Add(interval[0]);
                endTimes.Add(interval[1]);
            }
            startTimes.Sort();
            endTimes.Sort();

            int startIterator = 0;
            int endIterator = 0;

            while (startIterator < times.Count)
            {
                if (startTimes[startIterator] >= endTimes[endIterator])
                {
                    usedLaptop -= 1;
                    endIterator += 1;
                }
                usedLaptop += 1;
                startIterator += 1;
            }
            return usedLaptop;
        }
    }
}

/*
 using System.Collections.Generic;
using System.Linq;
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[][] times = new int[][] {
      new int[] { 0, 2 },
      new int[] { 1, 4 },
      new int[] { 4, 6 },
      new int[] { 0, 4 },
      new int[] { 7, 8 },
      new int[] { 9, 11 },
      new int[] { 3, 10 }
    };
    List<List<int> > input = new List<List<int> >();
    foreach (var time in times) {
      input.Add(new List<int> { time[0], time[1] });
    }
    int expected = 3;
    var actual = new Program().LaptopRentals(input);
    Utils.AssertTrue(expected == actual);
  }
}


15 / 15 test cases passed.

Test Case 1 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "times": [
    [0, 2],
    [1, 4],
    [4, 6],
    [0, 4],
    [7, 8],
    [9, 11],
    [3, 10]
  ]
}
Test Case 2 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "times": [
    [0, 4],
    [2, 3],
    [2, 3],
    [2, 3]
  ]
}
Test Case 3 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "times": [
    [1, 5],
    [5, 6],
    [6, 7],
    [7, 9]
  ]
}
Test Case 4 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "times": [
    [0, 4]
  ]
}
Test Case 5 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "times": []
}
Test Case 6 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "times": [
    [0, 5],
    [2, 4],
    [4, 7],
    [5, 7],
    [9, 20],
    [3, 15],
    [6, 10]
  ]
}
Test Case 7 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "times": [
    [10, 20],
    [0, 5],
    [5, 10],
    [10, 15]
  ]
}
Test Case 8 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "times": [
    [0, 5],
    [3, 8],
    [4, 10],
    [7, 11],
    [6, 10]
  ]
}
Test Case 9 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "times": [
    [0, 5],
    [1, 4],
    [2, 3],
    [3, 8],
    [7, 9],
    [11, 20],
    [0, 20],
    [3, 10]
  ]
}
Test Case 10 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "times": [
    [10, 20],
    [5, 15],
    [0, 6],
    [0, 20],
    [21, 22],
    [0, 1],
    [2, 5]
  ]
}
Test Case 11 passed!
Expected Output
6
Your Code's Output
6
View Outputs Side By Side
Input(s)
{
  "times": [
    [0, 10],
    [1, 9],
    [2, 8],
    [3, 7],
    [4, 6],
    [5, 6]
  ]
}
Test Case 12 passed!
Expected Output
7
Your Code's Output
7
View Outputs Side By Side
Input(s)
{
  "times": [
    [0, 20],
    [0, 10],
    [1, 9],
    [2, 8],
    [3, 7],
    [4, 6],
    [5, 6],
    [10, 15],
    [11, 12]
  ]
}
Test Case 13 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "times": [
    [5, 10],
    [1, 2],
    [1, 2],
    [1, 2],
    [3, 5],
    [4, 5]
  ]
}
Test Case 14 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "times": [
    [1, 3],
    [2, 5],
    [4, 5],
    [0, 20],
    [1, 10],
    [10, 20],
    [11, 15],
    [12, 13],
    [0, 1],
    [0, 2]
  ]
}
Test Case 15 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "times": [
    [5, 6],
    [4, 5],
    [3, 4],
    [2, 3],
    [1, 2]
  ]
}
 
 
 */