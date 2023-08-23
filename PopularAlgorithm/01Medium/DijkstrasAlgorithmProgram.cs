using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopularAlgorithm._01Medium
{
    class DijkstrasAlgorithmProgram
    {
        public int[] DijkstrasAlgorithm(int start, int[][][] edges)
        {
            // O(v^2 + e) time | O(v)
            int numberOfVertices = edges.Length;

            int[] minDistances = new int[edges.Length];
            Array.Fill(minDistances, Int32.MaxValue);
            minDistances[start] = 0;
            HashSet<int> visited = new HashSet<int>();

            while (visited.Count != numberOfVertices)
            {
                int[] getVertexData = getVertexWithMinDistances(minDistances, visited);
                int vertex = getVertexData[0];
                int currentMinDistance = getVertexData[1];

                if (currentMinDistance == Int32.MaxValue)
                {
                    break;
                }
                visited.Add(vertex);
                foreach (var edge in edges[vertex])
                {
                    int destination = edge[0];
                    int distanceToDestination = edge[1];

                    if (visited.Contains(destination))
                    {
                        continue;
                    }
                    int newPathDistance = currentMinDistance + distanceToDestination;
                    int currentDestinationDistance = minDistances[destination];
                    if (newPathDistance < currentDestinationDistance)
                    {
                        minDistances[destination] = newPathDistance;
                    }
                }
            }

            int[] finalDistances = new int[minDistances.Length];
            for (int i = 0; i < minDistances.Length; i++)
            {
                int distance = minDistances[i];
                if (distance == Int32.MaxValue)
                {
                    finalDistances[i] = -1;
                }
                else
                {
                    finalDistances[i] = distance;
                }
            }
            return finalDistances;
        }
        public int[] getVertexWithMinDistances(
            int[] distances, HashSet<int> visited
        )
        {
            int currentMinDistance = Int32.MaxValue;
            int vertex = -1;

            for (int vertexIdx = 0; vertexIdx < distances.Length; vertexIdx++)
            {
                int distance = distances[vertexIdx];

                if (visited.Contains(vertexIdx))
                {
                    continue;
                }

                if (distance <= currentMinDistance)
                {
                    vertex = vertexIdx;
                    currentMinDistance = distance;
                }
            }
            return new int[] { vertex, currentMinDistance };
        }
    }
}

/*

  public int[] DijkstrasAlgorithm(int start, int[][][] edges) {
    // Write your code here.
           int numberOfVertices = edges.Length;

      int[] minDistances = new int[edges.Length];
      Array.Fill(minDistances, Int32.MaxValue);
      minDistances[start] = 0;

      List<Item> minDistancesPairs = new List<Item>();
      for(int i=0; i < numberOfVertices; i++){
          Item item = new Item(i, Int32.MaxValue);
          minDistancesPairs.Add(item);
      }

      MinHeap minDistancesHeap = new MinHeap(minDistancesPairs);
      minDistancesHeap.Update(start, 0);

      while(!minDistancesHeap.isEmpty()){
          Item heapItem = minDistancesHeap.Remove();
          int vertex = heapItem.vertex;
          int currentMinDistance = heapItem.distance;

          if(currentMinDistance == Int32.MaxValue){
              break;
          }
          foreach(var edge in edges[vertex]){
              int destination = edge[0];
              int distanceToDestination = edge[1];
              int newPathDistance = currentMinDistance + distanceToDestination;
              int currentDestinationDistance = minDistances[destination];
              if(newPathDistance < currentDestinationDistance){
                  minDistances[destination] = newPathDistance;
                  minDistancesHeap.Update(destination, newPathDistance);
              }
          }
      }
      int[] finalDistances = new int[minDistances.Length];
      for(int i=0; i < minDistances.Length; i++){
          int distance = minDistances[i];
          if(distance == Int32.MaxValue){
              finalDistances[i] = -1;
          } else {
              finalDistances[i] = distance;
          }
      }
      return finalDistances;
  }
    public class Item{
        public int vertex;
        public int distance;

        public Item(int vertex, int distance){
            this.vertex = vertex;
            this.distance = distance;
        }
    };

    public class MinHeap{
        Dictionary<int, int> vertexDictionary = new Dictionary<int, int>();
        List<Item> heap = new List<Item>();

        public MinHeap(List<Item> array){
            for(int i=0; i < array.Count; i++){
                Item item = array[i];
                vertexDictionary[item.vertex] = item.vertex;
            }
            heap = buildHeap(array);
        }
        List<Item> buildHeap(List<Item> array){
            int firstParentIdx = (array.Count - 2)/2;
            for(int currentIdx = firstParentIdx + 1; currentIdx >=0; currentIdx--){
                siftDown(currentIdx, array.Count-1, array);
            }
            return array;
        }
        public bool isEmpty(){
            return heap.Count == 0;
        }
        void siftDown(int currentIdx, int endIdx, List<Item> heap){
            int childOneIdx = currentIdx * 2 +1;
            while(childOneIdx <= endIdx){
                int childTwoIdx = 
                    currentIdx * 2 + 2 <= endIdx ? currentIdx *2 + 2 : -1;
                int idxToSwap;
                if(childTwoIdx != -1 && heap[childTwoIdx].distance < heap[childOneIdx].distance){
                    idxToSwap = childTwoIdx;
                } else {
                    idxToSwap = childOneIdx;
                }
                if(heap[idxToSwap].distance < heap[currentIdx].distance){
                    swap(currentIdx, idxToSwap);
                    currentIdx = idxToSwap;
                    childOneIdx = currentIdx * 2 + 1;
                } else {
                    return;
                }
                
            }
        }
        void siftUp(int currentIdx){
            int parentIdx = (currentIdx - 1)/2;
            while(currentIdx > 0 &&
                 heap[currentIdx].distance < heap[parentIdx].distance){
                swap(currentIdx, parentIdx);
                currentIdx = parentIdx;
                parentIdx = (currentIdx - 1)/2;
            }
        }
        public Item Remove(){
            swap(0, heap.Count - 1);
            Item lastItem = heap[heap.Count - 1];
            int vertex = lastItem.vertex;
            int distance = lastItem.distance;
            heap.RemoveAt(heap.Count-1);
            vertexDictionary.Remove(vertex);
            siftDown(0, heap.Count - 1, heap);
            return new Item(vertex, distance);
        }

        public void Update(int vertex, int value){
            heap[vertexDictionary[vertex]] = new Item(vertex, value);
            siftUp(vertexDictionary[vertex]);
        }

        void swap(int i, int j){
            vertexDictionary[heap[i].vertex] = j;
            vertexDictionary[heap[j].vertex] = i;
            Item temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
________________________________________________________________________________________ 

using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int start = 0;
    int[][][] edges = {
      new int[][] { new int[] { 1, 7 } },
      new int[][] {
        new int[] { 2, 6 }, new int[] { 3, 20 }, new int[] { 4, 3 }
      },
      new int[][] { new int[] { 3, 14 } },
      new int[][] { new int[] { 4, 2 } },
      new int[][] {},
      new int[][] {}
    };
    int[] expected = { 0, 7, 13, 27, 10, -1 };
    int[] actual = new Program().DijkstrasAlgorithm(start, edges);
    Utils.AssertTrue(expected.Length == actual.Length);
    for (int i = 0; i < expected.Length; i++) {
      Utils.AssertTrue(expected[i] == actual[i]);
    }
  }
}



--------------------------------------------------------------------------------------------
 9 / 9 test cases passed.

Test Case 1 passed!
Expected Output
[0, 7, 13, 27, 10, -1]
Your Code's Output
[0, 7, 13, 27, 10, -1]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 7]
    ],
    [
      [2, 6],
      [3, 20],
      [4, 3]
    ],
    [
      [3, 14]
    ],
    [
      [4, 2]
    ],
    [],
    []
  ],
  "start": 0
}
Test Case 2 passed!
Expected Output
[-1, 0, -1, -1]
Your Code's Output
[-1, 0, -1, -1]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [],
    [],
    [],
    []
  ],
  "start": 1
}
Test Case 3 passed!
Expected Output
[7, 8, 9, 8, 10, 11, 10, 0]
Your Code's Output
[7, 8, 9, 8, 10, 11, 10, 0]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 1],
      [3, 1]
    ],
    [
      [2, 1]
    ],
    [
      [6, 1]
    ],
    [
      [1, 3],
      [2, 4],
      [4, 2],
      [5, 3],
      [6, 5]
    ],
    [
      [5, 1]
    ],
    [
      [4, 1]
    ],
    [
      [5, 2]
    ],
    [
      [0, 7]
    ]
  ],
  "start": 7
}
Test Case 4 passed!
Expected Output
[2, 5, 4, 1, 0]
Your Code's Output
[2, 5, 4, 1, 0]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 3],
      [2, 2]
    ],
    [
      [3, 7]
    ],
    [
      [1, 2],
      [3, 4],
      [4, 1]
    ],
    [],
    [
      [0, 2],
      [1, 8],
      [3, 1]
    ]
  ],
  "start": 4
}
Test Case 5 passed!
Expected Output
[1, 0, -1, -1]
Your Code's Output
[1, 0, -1, -1]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 2]
    ],
    [
      [0, 1]
    ],
    [
      [3, 1]
    ],
    [
      [2, 2]
    ]
  ],
  "start": 1
}
Test Case 6 passed!
Expected Output
[0, 1, 2, 3, 4, 5, 6, 7]
Your Code's Output
[0, 1, 2, 3, 4, 5, 6, 7]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 1],
      [7, 8]
    ],
    [
      [2, 1]
    ],
    [
      [3, 1]
    ],
    [
      [4, 1]
    ],
    [
      [5, 1]
    ],
    [
      [6, 1]
    ],
    [
      [7, 1]
    ],
    []
  ],
  "start": 0
}
Test Case 7 passed!
Expected Output
[3, 4, -1, 0, 4, -1, 7, 8, 7, -1, 7]
Your Code's Output
[3, 4, -1, 0, 4, -1, 7, 8, 7, -1, 7]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 2],
      [3, 3],
      [4, 2]
    ],
    [
      [0, 1],
      [6, 3]
    ],
    [
      [3, 9]
    ],
    [
      [0, 3],
      [1, 4],
      [4, 4],
      [8, 7]
    ],
    [
      [0, 1],
      [10, 3]
    ],
    [
      [7, 1],
      [8, 4]
    ],
    [
      [8, 1]
    ],
    [],
    [
      [7, 1]
    ],
    [
      [10, 2]
    ],
    []
  ],
  "start": 3
}
Test Case 8 passed!
Expected Output
[20, 16, 5, 15, 12, 12, 9, 10, 0, 17]
Your Code's Output
[20, 16, 5, 15, 12, 12, 9, 10, 0, 17]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 4],
      [7, 11]
    ],
    [
      [0, 4],
      [2, 11],
      [7, 14]
    ],
    [
      [1, 11],
      [3, 10],
      [5, 7],
      [8, 5]
    ],
    [
      [2, 10],
      [4, 12],
      [5, 17]
    ],
    [
      [3, 12],
      [5, 13],
      [6, 3]
    ],
    [
      [2, 7],
      [3, 17],
      [4, 13],
      [6, 5]
    ],
    [
      [4, 3],
      [5, 6],
      [7, 4],
      [9, 8]
    ],
    [
      [0, 11],
      [1, 14],
      [6, 4],
      [8, 10]
    ],
    [
      [2, 5],
      [6, 9],
      [7, 10]
    ],
    []
  ],
  "start": 8
}
Test Case 9 passed!
Expected Output
[3, 8, 7, 0]
Your Code's Output
[3, 8, 7, 0]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [2, 4]
    ],
    [
      [0, 2]
    ],
    [
      [1, 1],
      [3, 2]
    ],
    [
      [0, 3]
    ]
  ],
  "start": 3
}
 */