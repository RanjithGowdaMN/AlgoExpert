using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopularAlgorithm._03VeryHard
{
    class AStarAlgorithmProgram
    {
        public int[][] AStarAlgorithm(
    int startRow, int startCol, int endRow, int endCol, int[][] graph
    )
        {
            List<List<Node>> nodes = initializeNodes(graph);
            Node startNode = nodes[startRow][startCol];
            Node endNode = nodes[endRow][endCol];

            startNode.distanceFromStart = 0;
            startNode.estimatedDistanceToEnd = calculateManhattanDistance(startNode, endNode);

            List<Node> nodesToVisitList = new List<Node>();
            nodesToVisitList.Add(startNode);
            MinHeap nodesToVisit = new MinHeap(nodesToVisitList);

            while (!nodesToVisit.isEmpty())
            {
                Node currentMinDistanceNode = nodesToVisit.Remove();
                if (currentMinDistanceNode == endNode)
                {
                    break;
                }


                List<Node> neighbors = getNeighbors(currentMinDistanceNode, nodes);
                foreach (var neighbor in neighbors)
                {
                    if (neighbor.value == 1)
                    {
                        continue;
                    }

                    int tentativeDistanceToNeighbor = currentMinDistanceNode.distanceFromStart + 1;
                    if (tentativeDistanceToNeighbor >= neighbor.distanceFromStart)
                    {
                        continue;
                    }

                    neighbor.cameFrom = currentMinDistanceNode;
                    neighbor.distanceFromStart = tentativeDistanceToNeighbor;
                    neighbor.estimatedDistanceToEnd = tentativeDistanceToNeighbor + calculateManhattanDistance(neighbor, endNode);

                    if (!nodesToVisit.ContainsNode(neighbor))
                    {
                        nodesToVisit.Insert(neighbor);
                    }
                    else
                    {
                        nodesToVisit.Update(neighbor);
                    }
                }
            }
            return reconstructPath(endNode);
        }

        List<List<Node>> initializeNodes(int[][] graph)
        {
            List<List<Node>> nodes = new List<List<Node>>();

            for (int i = 0; i < graph.Length; i++)
            {
                List<Node> nodeList = new List<Node>();
                nodes.Add(nodeList);
                for (int j = 0; j < graph[i].Length; j++)
                {
                    nodes[i].Add(new Node(i, j, graph[i][j]));
                }
            }
            return nodes;
        }
        int calculateManhattanDistance(Node currentNode, Node endNode)
        {
            int currentRow = currentNode.row;
            int currentCol = currentNode.col;
            int endRow = endNode.row;
            int endCol = endNode.col;
            return Math.Abs(currentRow - endRow) + Math.Abs(currentCol - endCol);
        }

        List<Node> getNeighbors(Node node, List<List<Node>> nodes)
        {
            List<Node> neighbors = new List<Node>();
            int numRows = nodes.Count;
            int numCols = nodes[0].Count;

            int row = node.row;
            int col = node.col;

            if (row < numRows - 1)
            {
                neighbors.Add(nodes[row + 1][col]);
            }

            if (row > 0)
            {
                neighbors.Add(nodes[row - 1][col]);
            }
            if (col < numCols - 1)
            {
                neighbors.Add(nodes[row][col + 1]);
            }


            if (col > 0)
            { //LEFT
                neighbors.Add(nodes[row][col - 1]);
            }
            return neighbors;
        }

        int[][] reconstructPath(Node endNode)
        {
            if (endNode.cameFrom == null)
            {
                return new int[][] { };
            }
            Node currentNode = endNode;
            List<List<int>> path = new List<List<int>>();

            while (currentNode != null)
            {
                List<int> nodeData = new List<int>();
                nodeData.Add(currentNode.row);
                nodeData.Add(currentNode.col);
                path.Add(nodeData);
                currentNode = currentNode.cameFrom;
            }

            int[][] res = new int[path.Count][];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = path[res.Length - 1 - i].ToArray();
            }
            return res;
        }

        public class Node
        {
            public string id;
            public int row;
            public int col;
            public int value;
            public int distanceFromStart;
            public int estimatedDistanceToEnd;
            public Node cameFrom;
            public Node(int row, int col, int value)
            {
                this.id = row.ToString() + '-' + col.ToString();
                this.row = row;
                this.col = col;
                this.value = value;
                this.distanceFromStart = Int32.MaxValue;
                this.estimatedDistanceToEnd = Int32.MaxValue;
                this.cameFrom = null;
            }
        };

        public class MinHeap
        {
            List<Node> heap = new List<Node>();
            Dictionary<string, int> nodePositionsInHeap = new Dictionary<string, int>();
            public MinHeap(List<Node> array)
            {
                for (int i = 0; i < array.Count; i++)
                {
                    Node node = array[i];
                    nodePositionsInHeap[node.id] = i;
                }
                heap = buildHeap(array);
            }

            public bool isEmpty()
            {
                return heap.Count == 0;
            }

            public List<Node> buildHeap(List<Node> array)
            {
                int firstParentIdx = (array.Count - 2) / 2;
                for (int currentIdx = firstParentIdx; currentIdx >= 0; currentIdx--)
                {
                    siftDown(currentIdx, array.Count - 1, array);
                }
                return array;
            }


            public void siftDown(int currentIdx, int endIdx, List<Node> array)
            {
                int childOneIdx = currentIdx * 2 + 1;
                while (childOneIdx < endIdx)
                {
                    int childTwoIdx =
                        currentIdx * 2 + 2 <= endIdx ? currentIdx * 2 + 2 : -1;
                    int idxToSwap;
                    if (childTwoIdx != -1 && array[childTwoIdx].estimatedDistanceToEnd < heap[childOneIdx].estimatedDistanceToEnd)
                    {
                        idxToSwap = childTwoIdx;
                    }
                    else
                    {
                        idxToSwap = childOneIdx;
                    }
                    if (array[idxToSwap].estimatedDistanceToEnd < heap[currentIdx].estimatedDistanceToEnd)
                    {
                        swap(currentIdx, idxToSwap);
                        currentIdx = idxToSwap;
                        childOneIdx = currentIdx * 2 + 1;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            public void siftUp(int currentIdx)
            {
                int parentIdx = (currentIdx - 1) / 2;
                while (currentIdx > 0 && heap[currentIdx].estimatedDistanceToEnd < heap[parentIdx].estimatedDistanceToEnd)
                {
                    swap(currentIdx, parentIdx);
                    currentIdx = parentIdx;
                    parentIdx = (currentIdx - 1) / 2;
                }
            }

            public Node Remove()
            {
                if (isEmpty())
                {
                    return null;
                }
                swap(0, heap.Count - 1);
                Node node = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);
                nodePositionsInHeap.Remove(node.id);
                siftDown(0, heap.Count - 1, heap);
                return node;
            }

            public void Insert(Node node)
            {
                heap.Add(node);
                nodePositionsInHeap[node.id] = heap.Count - 1;
                siftUp(heap.Count - 1);
            }

            public void Update(Node node)
            {
                siftUp(nodePositionsInHeap[node.id]);
            }

            public bool ContainsNode(Node node)
            {
                return nodePositionsInHeap.ContainsKey(node.id);
            }

            public void swap(int i, int j)
            {
                nodePositionsInHeap[heap[i].id] = j;
                nodePositionsInHeap[heap[j].id] = i;

                Node temp = heap[i];
                heap[i] = heap[j];
                heap[j] = temp;
            }
        }
    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int startRow = 0;
    int startCol = 1;
    int endRow = 4;
    int endCol = 3;
    int[][] graph = new int[][] {
      new int[] { 0, 0, 0, 0, 0 },
      new int[] { 0, 1, 1, 1, 0 },
      new int[] { 0, 0, 0, 0, 0 },
      new int[] { 1, 0, 1, 1, 1 },
      new int[] { 0, 0, 0, 0, 0 },
    };
    int[][] expected = new int[][] {
      new int[] { 0, 1 },
      new int[] { 0, 0 },
      new int[] { 1, 0 },
      new int[] { 2, 0 },
      new int[] { 2, 1 },
      new int[] { 3, 1 },
      new int[] { 4, 1 },
      new int[] { 4, 2 },
      new int[] { 4, 3 }
    };
    var actual =
      new Program().AStarAlgorithm(startRow, startCol, endRow, endCol, graph);
    Utils.AssertTrue(expected.Length == actual.Length);
    for (int i = 0; i < expected.Length; i++) {
      for (int j = 0; j < expected[i].Length; j++) {
        Utils.AssertTrue(expected[i][j] == actual[i][j]);
      }
    }
  }
}

8 / 8 test cases passed.

Test Case 1 passed!
Expected Output
[
  [0, 1],
  [0, 0],
  [1, 0],
  [2, 0],
  [2, 1],
  [3, 1],
  [4, 1],
  [4, 2],
  [4, 3]
]
Our Code's Output
[
  [0, 1],
  [0, 0],
  [1, 0],
  [2, 0],
  [2, 1],
  [3, 1],
  [4, 1],
  [4, 2],
  [4, 3]
]
View Outputs Side By Side
Input(s)
{
  "endCol": 3,
  "endRow": 4,
  "graph": [
    [0, 0, 0, 0, 0],
    [0, 1, 1, 1, 0],
    [0, 0, 0, 0, 0],
    [1, 0, 1, 1, 1],
    [0, 0, 0, 0, 0]
  ],
  "startCol": 1,
  "startRow": 0
}
Test Case 2 passed!
Expected Output
[
  [1, 1],
  [1, 2],
  [1, 3],
  [1, 4],
  [1, 5],
  [1, 6],
  [1, 7],
  [1, 8],
  [2, 8],
  [3, 8],
  [4, 8],
  [5, 8],
  [6, 8],
  [7, 8],
  [8, 8]
]
Our Code's Output
[
  [1, 1],
  [1, 2],
  [1, 3],
  [1, 4],
  [1, 5],
  [1, 6],
  [1, 7],
  [1, 8],
  [2, 8],
  [3, 8],
  [4, 8],
  [5, 8],
  [6, 8],
  [7, 8],
  [8, 8]
]
View Outputs Side By Side
Input(s)
{
  "endCol": 8,
  "endRow": 8,
  "graph": [
    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
    [1, 0, 0, 0, 0, 0, 0, 0, 0, 1],
    [1, 1, 0, 1, 1, 1, 1, 1, 0, 1],
    [1, 1, 0, 0, 0, 1, 0, 1, 0, 1],
    [1, 1, 0, 0, 0, 1, 0, 1, 0, 1],
    [1, 1, 0, 0, 0, 1, 0, 1, 0, 1],
    [1, 1, 0, 0, 0, 1, 0, 1, 0, 1],
    [1, 1, 0, 0, 0, 1, 0, 1, 0, 1],
    [1, 1, 1, 1, 1, 1, 0, 0, 0, 1],
    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
  ],
  "startCol": 1,
  "startRow": 1
}
Test Case 3 passed!
Expected Output
[
  [1, 1],
  [1, 2],
  [2, 2],
  [3, 2],
  [3, 3],
  [3, 4],
  [4, 4],
  [5, 4],
  [6, 4],
  [7, 4]
]
Our Code's Output
[
  [1, 1],
  [1, 2],
  [2, 2],
  [3, 2],
  [3, 3],
  [3, 4],
  [4, 4],
  [5, 4],
  [6, 4],
  [7, 4]
]
View Outputs Side By Side
Input(s)
{
  "endCol": 4,
  "endRow": 7,
  "graph": [
    [1, 0, 0, 1, 0, 0, 0, 0, 0, 0],
    [1, 0, 0, 1, 0, 0, 0, 0, 0, 0],
    [1, 1, 0, 1, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 1, 0, 1, 1, 0, 0, 0],
    [0, 0, 0, 1, 0, 0, 1, 0, 0, 0],
    [0, 0, 0, 1, 0, 0, 1, 1, 1, 0],
    [0, 0, 0, 1, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 1, 1, 1, 0, 1, 1, 1],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
  ],
  "startCol": 1,
  "startRow": 1
}
Test Case 4 passed!
Expected Output
[
  [1, 8],
  [2, 8],
  [3, 8],
  [4, 8],
  [5, 8],
  [6, 8],
  [7, 8],
  [8, 8],
  [9, 8],
  [9, 7],
  [9, 6],
  [9, 5],
  [9, 4],
  [9, 3],
  [9, 2],
  [9, 1],
  [8, 1]
]
Our Code's Output
[
  [1, 8],
  [2, 8],
  [3, 8],
  [4, 8],
  [5, 8],
  [6, 8],
  [7, 8],
  [8, 8],
  [9, 8],
  [9, 7],
  [9, 6],
  [9, 5],
  [9, 4],
  [9, 3],
  [9, 2],
  [9, 1],
  [8, 1]
]
View Outputs Side By Side
Input(s)
{
  "endCol": 1,
  "endRow": 8,
  "graph": [
    [0, 0, 0, 0, 1, 0, 0, 0, 0, 0],
    [0, 0, 1, 0, 1, 0, 0, 0, 0, 0],
    [0, 0, 1, 0, 1, 1, 1, 0, 0, 0],
    [0, 0, 1, 0, 0, 0, 1, 0, 0, 0],
    [0, 0, 1, 1, 1, 0, 1, 0, 0, 0],
    [0, 0, 1, 0, 1, 0, 1, 0, 0, 0],
    [0, 0, 1, 0, 1, 0, 1, 0, 0, 0],
    [0, 0, 1, 0, 1, 0, 1, 0, 0, 0],
    [0, 0, 1, 0, 1, 0, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
  ],
  "startCol": 8,
  "startRow": 1
}
Test Case 5 passed!
Expected Output
[
  [0, 0],
  [0, 1],
  [0, 2],
  [0, 3],
  [0, 4],
  [0, 5],
  [0, 6],
  [0, 7],
  [0, 8],
  [0, 9],
  [0, 10],
  [0, 11],
  [0, 12],
  [1, 12],
  [2, 12],
  [2, 13],
  [3, 13],
  [4, 13],
  [4, 14],
  [4, 15],
  [4, 16],
  [5, 16],
  [6, 16],
  [6, 17],
  [6, 18],
  [6, 19],
  [5, 19],
  [4, 19],
  [3, 19],
  [2, 19],
  [1, 19],
  [0, 19]
]
Our Code's Output
[
  [0, 0],
  [0, 1],
  [0, 2],
  [0, 3],
  [0, 4],
  [0, 5],
  [0, 6],
  [0, 7],
  [0, 8],
  [0, 9],
  [0, 10],
  [0, 11],
  [0, 12],
  [1, 12],
  [2, 12],
  [2, 13],
  [3, 13],
  [4, 13],
  [4, 14],
  [4, 15],
  [4, 16],
  [5, 16],
  [6, 16],
  [6, 17],
  [6, 18],
  [6, 19],
  [5, 19],
  [4, 19],
  [3, 19],
  [2, 19],
  [1, 19],
  [0, 19]
]
View Outputs Side By Side
Input(s)
{
  "endCol": 19,
  "endRow": 0,
  "graph": [
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0],
    [0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0],
    [0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 1, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0],
    [0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0],
    [0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0],
    [0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
  ],
  "startCol": 0,
  "startRow": 0
}
Test Case 6 passed!
Expected Output
[]
Our Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "endCol": 17,
  "endRow": 18,
  "graph": [
    [0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0],
    [0, 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0],
    [0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0],
    [0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0],
    [0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 0],
    [0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0],
    [0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0],
    [0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0],
    [0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0],
    [0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0],
    [0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 1, 0],
    [0, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0],
    [0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0],
    [0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0],
    [0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1],
    [0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0],
    [0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0]
  ],
  "startCol": 1,
  "startRow": 1
}
Test Case 7 passed!
Expected Output
[
  [1, 1],
  [1, 2]
]
Our Code's Output
[
  [1, 1],
  [1, 2]
]
View Outputs Side By Side
Input(s)
{
  "endCol": 2,
  "endRow": 1,
  "graph": [
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 1, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 1, 0, 0, 0],
    [0, 0, 1, 0, 0, 0, 1, 0, 0, 0],
    [0, 1, 1, 0, 1, 1, 1, 0, 0, 0],
    [0, 1, 0, 1, 1, 0, 1, 0, 1, 0],
    [0, 1, 0, 1, 0, 0, 1, 0, 1, 0],
    [0, 1, 0, 1, 0, 0, 1, 0, 0, 0],
    [0, 1, 0, 0, 0, 0, 1, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
  ],
  "startCol": 1,
  "startRow": 1
}
Test Case 8 passed!
Expected Output
[
  [1, 11],
  [1, 10],
  [1, 9],
  [1, 8],
  [1, 7],
  [1, 6],
  [1, 5],
  [1, 4],
  [1, 3],
  [1, 2],
  [1, 1],
  [1, 0],
  [2, 0],
  [3, 0],
  [4, 0],
  [5, 0],
  [6, 0],
  [7, 0],
  [8, 0],
  [9, 0],
  [10, 0],
  [11, 0],
  [12, 0],
  [13, 0],
  [14, 0],
  [15, 0],
  [16, 0],
  [17, 0],
  [18, 0],
  [19, 0],
  [20, 0],
  [21, 0],
  [22, 0],
  [23, 0],
  [24, 0],
  [24, 1],
  [24, 2],
  [23, 2],
  [22, 2],
  [21, 2],
  [21, 3],
  [21, 4],
  [22, 4]
]
Our Code's Output
[
  [1, 11],
  [1, 10],
  [1, 9],
  [1, 8],
  [1, 7],
  [1, 6],
  [1, 5],
  [1, 4],
  [1, 3],
  [1, 2],
  [1, 1],
  [1, 0],
  [2, 0],
  [3, 0],
  [4, 0],
  [5, 0],
  [6, 0],
  [7, 0],
  [8, 0],
  [9, 0],
  [10, 0],
  [11, 0],
  [12, 0],
  [13, 0],
  [14, 0],
  [15, 0],
  [16, 0],
  [17, 0],
  [18, 0],
  [19, 0],
  [20, 0],
  [21, 0],
  [22, 0],
  [23, 0],
  [24, 0],
  [24, 1],
  [24, 2],
  [23, 2],
  [22, 2],
  [21, 2],
  [21, 3],
  [21, 4],
  [22, 4]
]
View Outputs Side By Side
Input(s)
{
  "endCol": 4,
  "endRow": 22,
  "graph": [
    [1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1],
    [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
    [0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0],
    [0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
  ],
  "startCol": 11,
  "startRow": 1
}
 
 */