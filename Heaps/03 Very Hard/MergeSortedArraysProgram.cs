﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps._03_Very_Hard
{
    class MergeSortedArraysProgram
    {
        public static List<int> MergeSortedArrays(List<List<int>> arrays)
        {
            // O(nlog(k) + k) time | O(n + k) space
            List<int> sortedList = new List<int>();
            List<Item> smallestItems = new List<Item>();

            for (int arrayIdx = 0; arrayIdx < arrays.Count; arrayIdx++)
            {
                smallestItems.Add(new Item(arrayIdx, 0, arrays[arrayIdx][0]));
            }

            MinHeap minHeap = new MinHeap(smallestItems);
            while (!minHeap.isEmplty())
            {
                Item smallestItem = minHeap.Remove();
                sortedList.Add(smallestItem.num);
                if (smallestItem.elementIdx == arrays[smallestItem.arrayIdx].Count - 1)
                    continue;
                minHeap.Insert(
                  new Item(smallestItem.arrayIdx,
                  smallestItem.elementIdx + 1,
                  arrays[smallestItem.arrayIdx][smallestItem.elementIdx + 1])
                );
            }

            return sortedList;
        }

        public class Item
        {
            public int arrayIdx;
            public int elementIdx;
            public int num;

            public Item(int arrayIdx, int elementIdx, int num)
            {
                this.arrayIdx = arrayIdx;
                this.elementIdx = elementIdx;
                this.num = num;
            }
        }

        public class MinHeap
        {
            List<Item> heap = new List<Item>();

            public MinHeap(List<Item> array)
            {
                heap = buildHeap(array);
            }

            public bool isEmplty()
            {
                return heap.Count == 0;
            }

            public List<Item> buildHeap(List<Item> array)
            {
                int firstParentIdx = (array.Count - 2) / 2;
                for (int currentIdx = firstParentIdx; currentIdx >= 0; currentIdx--)
                {
                    siftDown(currentIdx, array.Count - 1, array);
                }
                return array;
            }


            public void siftDown(int currentIdx, int endIdx, List<Item> heap)
            {
                int childOneIdx = currentIdx * 2 + 1;
                while (childOneIdx <= endIdx)
                {
                    int childTwoIdx =
                        currentIdx * 2 + 2 <= endIdx ? currentIdx * 2 + 2 : -1;
                    int idxToSwap;
                    if (childTwoIdx != -1 && heap[childTwoIdx].num < heap[childOneIdx].num)
                    {
                        idxToSwap = childTwoIdx;
                    }
                    else
                    {
                        idxToSwap = childOneIdx;
                    }
                    if (heap[idxToSwap].num < heap[currentIdx].num)
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

            public void siftUp(int currentIdx, List<Item> heap)
            {
                int parentIdx = (currentIdx - 1) / 2;
                while (currentIdx > 0 && heap[currentIdx].num < heap[parentIdx].num)
                {
                    swap(currentIdx, parentIdx, heap);
                    currentIdx = parentIdx;
                    parentIdx = (currentIdx - 1) / 2;
                }
            }

            public Item Remove()
            {
                swap(0, heap.Count - 1, heap);
                Item valueToRemove = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);
                siftDown(0, heap.Count - 1, heap);
                return valueToRemove;
            }

            public void Insert(Item value)
            {
                heap.Add(value);
                siftUp(heap.Count - 1, heap);
            }

            public void swap(int i, int j, List<Item> heap)
            {
                Item temp = heap[j];
                heap[j] = heap[i];
                heap[i] = temp;
            }
        }
    }
}
/*
 using System;
using System.Linq;
using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var arrays = new List<List<int> > {
      new List<int> { 1, 5, 9, 21 },
      new List<int> { -1, 0 },
      new List<int> { -124, 81, 121 },
      new List<int> { 3, 6, 12, 20, 150 },
    };
    var actual = Program.MergeSortedArrays(arrays);
    var expected =
      new List<int> { -124, -1, 0, 1, 3, 5, 6, 9, 12, 20, 21, 81, 121, 150 };
    Utils.AssertTrue(Enumerable.SequenceEqual(expected, actual));
  }
}

20 / 20 test cases passed.

Test Case 1 passed!
Expected Output
[-124, -1, 0, 1, 3, 5, 6, 9, 12, 20, 21, 81, 121, 150]
Our Code's Output
[-124, -1, 0, 1, 3, 5, 6, 9, 12, 20, 21, 81, 121, 150]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [1, 5, 9, 21],
    [-1, 0],
    [-124, 81, 121],
    [3, 6, 12, 20, 150]
  ]
}
Test Case 2 passed!
Expected Output
[-92, -78, -76, -74, -68, -66, -62, -49, -46, -40, -26, -23, -16, -8, 12, 20, 21, 28, 33, 33, 36, 38, 42, 43, 46, 46, 48, 50, 55, 79, 79, 81, 94]
Our Code's Output
[-92, -78, -76, -74, -68, -66, -62, -49, -46, -40, -26, -23, -16, -8, 12, 20, 21, 28, 33, 33, 36, 38, 42, 43, 46, 46, 48, 50, 55, 79, 79, 81, 94]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [-92, -78, -68, 43, 46, 46, 79, 79],
    [-66, -49, -26, -16, 21, 28, 33, 50],
    [-40, -8, 12, 20, 36, 38, 81],
    [-76, -74, -62, -46, -23, 33, 42, 48, 55, 94]
  ]
}
Test Case 3 passed!
Expected Output
[-95, -89, -86, -85, -78, -77, -75, -74, -73, -67, -66, -55, -35, -28, -25, -25, -22, -21, -13, 1, 2, 4, 22, 28, 38, 41, 72, 84, 95, 98]
Our Code's Output
[-95, -89, -86, -85, -78, -77, -75, -74, -73, -67, -66, -55, -35, -28, -25, -25, -22, -21, -13, 1, 2, 4, 22, 28, 38, 41, 72, 84, 95, 98]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [-95, -74, 1],
    [-28, 28, 95],
    [-89, -78, -67, -66, -25, -22, 2, 38],
    [-86, -35, -25, -13, 41],
    [-85, -77, -21, 72],
    [-55, 4, 84, 98],
    [-75, -73, 22]
  ]
}
Test Case 4 passed!
Expected Output
[-100, -79, -48, -43, -43, -33, -19, -15, -15, -8, -8, 12, 13, 17, 20, 40, 44, 50, 52, 81, 89, 91, 95]
Our Code's Output
[-100, -79, -48, -43, -43, -33, -19, -15, -15, -8, -8, 12, 13, 17, 20, 40, 44, 50, 52, 81, 89, 91, 95]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [-79, -43, -15, 89],
    [-48, 13, 20],
    [-33, -19, -8, 12, 40, 44, 50, 52, 91, 95],
    [-100, -43, -8, 17],
    [-15, 81]
  ]
}
Test Case 5 passed!
Expected Output
[-90, -88, -86, -75, -67, -66, -62, -56, -55, -50, -48, -48, -45, -43, -42, -41, -38, -27, -27, -22, -19, -13, -8, -6, -3, 2, 4, 6, 8, 8, 20, 34, 35, 39, 40, 42, 47, 48, 53, 55, 55, 56, 62, 68, 69, 74, 77, 82, 87, 91]
Our Code's Output
[-90, -88, -86, -75, -67, -66, -62, -56, -55, -50, -48, -48, -45, -43, -42, -41, -38, -27, -27, -22, -19, -13, -8, -6, -3, 2, 4, 6, 8, 8, 20, 34, 35, 39, 40, 42, 47, 48, 53, 55, 55, 56, 62, 68, 69, 74, 77, 82, 87, 91]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [-88, -56, -43, -41, -13, -8, 82],
    [-38, 53],
    [-75, -48, -42, -27, 20, 35, 55],
    [-55, -50, -48, -45, 62, 69, 77],
    [-90, -27, -22, -19, -6, -3, 4, 6, 91],
    [-86, -67, -66, 2, 8, 8, 39, 74],
    [-62, 34, 40, 42, 47, 48, 55, 56, 68, 87]
  ]
}
Test Case 6 passed!
Expected Output
[-100, -93, -83, -83, -82, -57, -51, -43, -43, -41, -33, -33, -32, -32, -29, -18, -16, -15, -14, -11, -5, 0, 12, 23, 29, 29, 40, 43, 50, 60, 70, 74, 76, 78, 80, 80]
Our Code's Output
[-100, -93, -83, -83, -82, -57, -51, -43, -43, -41, -33, -33, -32, -32, -29, -18, -16, -15, -14, -11, -5, 0, 12, 23, 29, 29, 40, 43, 50, 60, 70, 74, 76, 78, 80, 80]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [-93, -83, -43, -32, -32, -15, -14, 12, 78, 80],
    [-83],
    [-82, -51, -29, 40, 60, 76, 80],
    [50],
    [-33, -16],
    [-100],
    [-33, -11, 23, 29, 29, 43],
    [0, 70],
    [-57, -43, -41, -18, -5, 74]
  ]
}
Test Case 7 passed!
Expected Output
[-98, -91, -91, -90, -87, -83, -79, -73, -73, -65, -63, -62, -61, -56, -56, -56, -49, -47, -43, -42, -40, -33, -30, -30, -26, -24, -21, -20, -16, -10, -5, -4, 8, 11, 16, 19, 19, 21, 32, 34, 49, 67, 80, 83, 86, 91, 94, 98]
Our Code's Output
[-98, -91, -91, -90, -87, -83, -79, -73, -73, -65, -63, -62, -61, -56, -56, -56, -49, -47, -43, -42, -40, -33, -30, -30, -26, -24, -21, -20, -16, -10, -5, -4, 8, 11, 16, 19, 19, 21, 32, 34, 49, 67, 80, 83, 86, 91, 94, 98]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [98],
    [-87, -79, -56, -33, -20, -10, -5, 19, 49, 86],
    [-73, -49],
    [-98, -63, -47, -4, 21],
    [-56, -43, -24, 8, 34, 80, 83],
    [-83, -65, -61, -30, -26, -16, 16, 19],
    [-91, -42, -21, 91],
    [-73, -62, -56, -30, 11, 67],
    [-91, -90, -40, 32, 94]
  ]
}
Test Case 8 passed!
Expected Output
[-86, -81, -67, -65, -58, -54, -47, -40, -39, -35, -25, -3, 9, 17, 24, 29, 32, 36, 53, 55, 57, 59, 66, 75, 75, 82, 88, 92, 94, 95]
Our Code's Output
[-86, -81, -67, -65, -58, -54, -47, -40, -39, -35, -25, -3, 9, 17, 24, 29, 32, 36, 53, 55, 57, 59, 66, 75, 75, 82, 88, 92, 94, 95]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [-81, 36, 57, 59],
    [-65, -58, -47, -39, 29, 53, 66, 75, 88, 92],
    [-67, -54, -40, -25, 9, 17, 55, 75, 94],
    [-35, -3, 24, 82],
    [-86, 32, 95]
  ]
}
Test Case 9 passed!
Expected Output
[-93, -90, -83, -78, -75, -75, -57, -50, -49, -40, -40, -32, -20, 7, 11, 13, 18, 21, 42, 48, 53, 61, 71, 84, 89, 96, 96, 97]
Our Code's Output
[-93, -90, -83, -78, -75, -75, -57, -50, -49, -40, -40, -32, -20, 7, 11, 13, 18, 21, 42, 48, 53, 61, 71, 84, 89, 96, 96, 97]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [-93, -83, -78, -75, -40, -32, 48],
    [-90, -75, -57, 7, 11, 21, 53, 84, 89],
    [-50, -40, -20, 71, 96],
    [-49, 13, 18, 61, 97],
    [42, 96]
  ]
}
Test Case 10 passed!
Expected Output
[-98, -96, -96, -96, -95, -95, -89, -85, -71, -63, -62, -59, -56, -55, -55, -51, -51, -48, -45, -37, -28, -24, -24, -21, -19, -18, -16, -12, -12, -9, -2, -1, 5, 8, 11, 11, 19, 27, 29, 32, 33, 34, 37, 46, 47, 57, 64, 79, 80, 86, 87, 90, 92, 93, 96, 97, 97, 97, 100]
Our Code's Output
[-98, -96, -96, -96, -95, -95, -89, -85, -71, -63, -62, -59, -56, -55, -55, -51, -51, -48, -45, -37, -28, -24, -24, -21, -19, -18, -16, -12, -12, -9, -2, -1, 5, 8, 11, 11, 19, 27, 29, 32, 33, 34, 37, 46, 47, 57, 64, 79, 80, 86, 87, 90, 92, 93, 96, 97, 97, 97, 100]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [-63, -55, -9, 37, 86, 97],
    [-62, -48, -37, -16, 11, 33, 80, 97],
    [-51, 5, 34],
    [-24, -24, -19, 32, 46, 97],
    [-98, -56, -12, -2, -1, 11, 47, 79],
    [-59, 64, 93, 96],
    [-96, -51, -21, -18, 29, 57, 87, 90, 92],
    [-89, -85, -55, -12, 27],
    [-96, -96, -95, -95, -71, -45, -28, 8, 19, 100]
  ]
}
Test Case 11 passed!
Expected Output
[-95, -77, -49, -18, -16, 1, 11, 16, 36, 40, 49, 65, 72, 75, 91, 92]
Our Code's Output
[-95, -77, -49, -18, -16, 1, 11, 16, 36, 40, 49, 65, 72, 75, 91, 92]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [49, 72],
    [-95, -49, -18, -16, 1, 16, 36, 40, 75, 92],
    [-77, 11, 65, 91]
  ]
}
Test Case 12 passed!
Expected Output
[-94, -94, -93, -83, -83, -74, -54, -40, -25, -2, 9, 10, 22, 46, 49, 64, 64, 67, 85]
Our Code's Output
[-94, -94, -93, -83, -83, -74, -54, -40, -25, -2, 9, 10, 22, 46, 49, 64, 64, 67, 85]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [-94, -93, -25, -2, 67, 85],
    [-83, -74, 64],
    [-83, 10, 46, 64],
    [-94, -54, -40, 9, 22, 49]
  ]
}
Test Case 13 passed!
Expected Output
[-99, -98, -97, -90, -87, -85, -78, -73, -67, -65, -62, -56, -17, -15, -3, 5, 11, 15, 27, 43, 44, 50, 66, 67, 77, 78, 92]
Our Code's Output
[-99, -98, -97, -90, -87, -85, -78, -73, -67, -65, -62, -56, -17, -15, -3, 5, 11, 15, 27, 43, 44, 50, 66, 67, 77, 78, 92]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [-87, -67, -56, -15, 67],
    [-98, -90, -85, -3, 5, 43, 44],
    [-97, -78, -73, -65, -17, 27, 66, 77, 78, 92],
    [-99, -62, 11, 15, 50]
  ]
}
Test Case 14 passed!
Expected Output
[-98, -93, -93, -90, -79, -77, -48, -44, -39, -33, -32, -27, -5, 9, 10, 10, 14, 20, 39, 40, 61, 69, 83, 85, 90, 96, 99]
Our Code's Output
[-98, -93, -93, -90, -79, -77, -48, -44, -39, -33, -32, -27, -5, 9, 10, 10, 14, 20, 39, 40, 61, 69, 83, 85, 90, 96, 99]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [-79, -77, -48, -39, -27, 10, 39, 61, 83, 99],
    [-93, 10],
    [-98, -90, -44, -33, -5, 40, 69, 90, 96],
    [-93],
    [-32, 9, 14, 20, 85]
  ]
}
Test Case 15 passed!
Expected Output
[-88, -16, 14, 26, 38, 51, 62, 84, 88]
Our Code's Output
[-88, -16, 14, 26, 38, 51, 62, 84, 88]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [14],
    [-88, -16, 26, 38, 51, 62, 84, 88]
  ]
}
Test Case 16 passed!
Expected Output
[-98, -62, -54, -54, -41, -25, -14, 31, 33, 34, 34, 51, 68, 83]
Our Code's Output
[-98, -62, -54, -54, -41, -25, -14, 31, 33, 34, 34, 51, 68, 83]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [-62, -54, -54, 31, 34, 51],
    [-41],
    [33, 34],
    [-98, 68, 83],
    [-25, -14]
  ]
}
Test Case 17 passed!
Expected Output
[-99, -96, -95, -93, -88, -65, -62, -53, -48, -47, -45, -42, -41, -39, -38, -32, -28, -25, -16, -16, -13, -11, -8, -7, -6, -4, 4, 7, 8, 21, 25, 26, 35, 44, 49, 55, 59, 63, 64, 64, 76, 79, 82, 86, 98]
Our Code's Output
[-99, -96, -95, -93, -88, -65, -62, -53, -48, -47, -45, -42, -41, -39, -38, -32, -28, -25, -16, -16, -13, -11, -8, -7, -6, -4, 4, 7, 8, 21, 25, 26, 35, 44, 49, 55, 59, 63, 64, 64, 76, 79, 82, 86, 98]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [-53, -16, -13, -11, -6, 21, 26, 35],
    [-99, -93, -62, -47, -16, 4, 55, 59, 64, 76],
    [-96, -41, -8],
    [-39, -28, -4],
    [-95, -48, -45, -25, 63, 64, 98],
    [-38, -32, -7, 82],
    [-42, 25, 49, 79, 86],
    [-88, -65, 7, 8, 44]
  ]
}
Test Case 18 passed!
Expected Output
[-91, -76, -72, -62, -59, -58, -55, -47, -46, -46, -37, -35, -33, -26, -25, -21, -16, -12, -10, -8, 2, 3, 9, 16, 21, 30, 38, 46, 46, 47, 56, 57, 67, 71, 74, 82, 93, 97]
Our Code's Output
[-91, -76, -72, -62, -59, -58, -55, -47, -46, -46, -37, -35, -33, -26, -25, -21, -16, -12, -10, -8, 2, 3, 9, 16, 21, 30, 38, 46, 46, 47, 56, 57, 67, 71, 74, 82, 93, 97]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [-33, 57, 74],
    [-76, -72, -46, -21, -16, -10, 16, 21, 47, 67],
    [-59, -55, -47, -46, -35, 38],
    [-62, -25, 3, 30, 46, 71],
    [-91, -37, -26, -12, -8, 2, 9, 46, 56, 93],
    [-58, 82, 97]
  ]
}
Test Case 19 passed!
Expected Output
[-96, -93, -88, -86, -73, -72, -71, -66, -65, -64, -60, -59, -57, -55, -53, -51, -44, -36, -28, -27, -19, -12, -11, -10, -7, -5, -5, 1, 1, 6, 11, 12, 13, 13, 17, 21, 22, 27, 27, 27, 32, 36, 38, 43, 48, 58, 62, 70, 77, 79, 79, 87, 88, 88, 99]
Our Code's Output
[-96, -93, -88, -86, -73, -72, -71, -66, -65, -64, -60, -59, -57, -55, -53, -51, -44, -36, -28, -27, -19, -12, -11, -10, -7, -5, -5, 1, 1, 6, 11, 12, 13, 13, 17, 21, 22, 27, 27, 27, 32, 36, 38, 43, 48, 58, 62, 70, 77, 79, 79, 87, 88, 88, 99]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [-64, -51, -5, 1, 6, 12, 27, 32, 62, 88],
    [-66, -65, -60, 17, 22],
    [-57, -7, 13, 70, 79],
    [-88, -86, -73, -59, -36, -12, 11, 48, 58, 99],
    [-71, -28],
    [21, 38],
    [-55, -44, -27],
    [-96, -93, -5, 13],
    [-19, -11, 27, 36, 43, 79, 87],
    [-72, -53, -10, 1, 27, 77, 88]
  ]
}
Test Case 20 passed!
Expected Output
[-94, -53, -53, -28, -27, -19, -10, -3, 27, 31, 33, 34, 42, 44, 70, 73, 77, 86, 91, 96, 99]
Our Code's Output
[-94, -53, -53, -28, -27, -19, -10, -3, 27, 31, 33, 34, 42, 44, 70, 73, 77, 86, 91, 96, 99]
View Outputs Side By Side
Input(s)
{
  "arrays": [
    [-19, 33, 34],
    [-94, -53, -10, -3, 44, 73],
    [27, 42, 70, 86],
    [-28, 91],
    [-53, -27, 31, 77, 96, 99]
  ]
}
 
 */