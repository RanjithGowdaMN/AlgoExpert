using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopularAlgorithm._02Hard
{
    class KruskalsAlgorithmProgram
    {
        public int[][][] KruskalsAlgorithm(int[][][] edges)
        {
            //O(e * log(e)) time | O(e+v) space
            List<List<int>> sortedEdges = new List<List<int>>();
            for (int sourceIndex = 0; sourceIndex < edges.Length; sourceIndex++)
            {
                foreach (var edge in edges[sourceIndex])
                {
                    if (edge[0] > sourceIndex)
                    {
                        sortedEdges.Add(new List<int> { sourceIndex, edge[0], edge[1] });
                    }
                }
            }

            sortedEdges.Sort((edge1, edge2) => edge1[2] - edge2[2]);

            int[] parents = new int[edges.Length];
            int[] ranks = new int[edges.Length];
            List<List<int[]>> mst = new List<List<int[]>>();

            for (int i = 0; i < edges.Length; i++)
            {
                parents[i] = i;
                ranks[i] = 0;
                mst.Insert(i, new List<int[]>());
            }
            foreach (var edge in sortedEdges)
            {
                int vertex1Root = find(edge[0], parents);
                int vertex2Root = find(edge[1], parents);
                if (vertex1Root != vertex2Root)
                {
                    mst[edge[0]].Add(new int[] { edge[1], edge[2] });
                    mst[edge[1]].Add(new int[] { edge[0], edge[2] });
                    union(vertex1Root, vertex2Root, parents, ranks);
                }
            }
            int[][][] arrayMst = new int[edges.Length][][];
            for (int i = 0; i < mst.Count; i++)
            {
                arrayMst[i] = new int[mst[i].Count][];
                for (int j = 0; j < mst[i].Count; j++)
                {
                    arrayMst[i][j] = mst[i][j];
                }
            }
            return arrayMst;
        }
        private int find(int vertex, int[] parents)
        {
            if (vertex != parents[vertex])
            {
                parents[vertex] = find(parents[vertex], parents);
            }
            return parents[vertex];
        }
        private void union(int vertex1Root, int vertex2Root, int[] parents, int[] ranks)
        {
            if (ranks[vertex1Root] < ranks[vertex2Root])
            {
                parents[vertex1Root] = vertex2Root;
            }
            else if (ranks[vertex1Root] > ranks[vertex2Root])
            {
                parents[vertex2Root] = vertex1Root;
            }
            else
            {
                parents[vertex2Root] = vertex1Root;
                ranks[vertex1Root]++;
            }
        }
    }
}

/*
 
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var input = new int[][][] {
      new int[][] { new int[] { 1, 1 } }, new int[][] { new int[] { 0, 1 } }
    };
    var expected = new int[][][] {
      new int[][] { new int[] { 1, 1 } }, new int[][] { new int[] { 0, 1 } }
    };
    var actual = new Program().KruskalsAlgorithm(input);
    Utils.AssertTrue(jaggedArrayDeepEqual(expected, actual));
  }

  public bool jaggedArrayDeepEqual(dynamic a, dynamic b) {
    if (ReferenceEquals(a, b)) {
      return true;
    }

    if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) {
      return false;
    }

    if (!a.GetType().IsArray || !b.GetType().IsArray) {
      return Equals(a, b);
    }

    if (a.Length == b.Length) {
      for (int i = 0; i < a.Length; i++) {
        if (!jaggedArrayDeepEqual(a[i], b[i])) {
          return false;
        }
      }
      return true;
    }
    return false;
  }
}

 13 / 13 test cases passed.

Test Case 1 passed!
Expected Output
[
  [
    [1, 1]
  ],
  [
    [0, 1]
  ]
]
Your Code's Output
[
  [
    [1, 1]
  ],
  [
    [0, 1]
  ]
]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 1]
    ],
    [
      [0, 1]
    ]
  ]
}
Test Case 2 passed!
Expected Output
[
  [
    [1, 1]
  ],
  [
    [0, 1],
    [2, 2]
  ],
  [
    [1, 2]
  ]
]
Your Code's Output
[
  [
    [1, 1]
  ],
  [
    [0, 1],
    [2, 2]
  ],
  [
    [1, 2]
  ]
]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 1]
    ],
    [
      [0, 1],
      [2, 2]
    ],
    [
      [1, 2]
    ]
  ]
}
Test Case 3 passed!
Expected Output
[
  [
    [1, 3],
    [2, 5]
  ],
  [
    [0, 3],
    [3, 12]
  ],
  [
    [0, 5]
  ],
  [
    [1, 12]
  ]
]
Your Code's Output
[
  [
    [1, 3],
    [2, 5]
  ],
  [
    [0, 3],
    [3, 12]
  ],
  [
    [0, 5]
  ],
  [
    [1, 12]
  ]
]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 3],
      [2, 5]
    ],
    [
      [0, 3],
      [2, 10],
      [3, 12]
    ],
    [
      [0, 5],
      [1, 10]
    ],
    [
      [1, 12]
    ]
  ]
}
Test Case 4 passed!
Expected Output
[
  [
    [1, 3],
    [2, 5]
  ],
  [
    [0, 3],
    [3, 12],
    [4, 1]
  ],
  [
    [0, 5]
  ],
  [
    [1, 12]
  ],
  [
    [1, 1]
  ]
]
Your Code's Output
[
  [
    [1, 3],
    [2, 5]
  ],
  [
    [0, 3],
    [3, 12],
    [4, 1]
  ],
  [
    [0, 5]
  ],
  [
    [1, 12]
  ],
  [
    [1, 1]
  ]
]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 3],
      [2, 5]
    ],
    [
      [0, 3],
      [2, 10],
      [3, 12],
      [4, 1]
    ],
    [
      [0, 5],
      [1, 10],
      [4, 7]
    ],
    [
      [1, 12]
    ],
    [
      [1, 1],
      [2, 7]
    ]
  ]
}
Test Case 5 passed!
Expected Output
[
  [
    [1, 3],
    [2, 5]
  ],
  [
    [0, 3],
    [4, 1]
  ],
  [
    [0, 5]
  ],
  [
    [4, 11]
  ],
  [
    [1, 1],
    [3, 11]
  ]
]
Your Code's Output
[
  [
    [1, 3],
    [2, 5]
  ],
  [
    [0, 3],
    [4, 1]
  ],
  [
    [0, 5]
  ],
  [
    [4, 11]
  ],
  [
    [1, 1],
    [3, 11]
  ]
]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 3],
      [2, 5]
    ],
    [
      [0, 3],
      [2, 10],
      [3, 12],
      [4, 1]
    ],
    [
      [0, 5],
      [1, 10],
      [4, 7]
    ],
    [
      [1, 12],
      [4, 11]
    ],
    [
      [1, 1],
      [2, 7],
      [3, 11]
    ]
  ]
}
Test Case 6 passed!
Expected Output
[
  [
    [1, 7]
  ],
  [
    [0, 7],
    [2, 6],
    [4, 3]
  ],
  [
    [1, 6]
  ],
  [
    [4, 2]
  ],
  [
    [1, 3],
    [3, 2]
  ]
]
Your Code's Output
[
  [
    [1, 7]
  ],
  [
    [0, 7],
    [2, 6],
    [4, 3]
  ],
  [
    [1, 6]
  ],
  [
    [4, 2]
  ],
  [
    [1, 3],
    [3, 2]
  ]
]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 7]
    ],
    [
      [0, 7],
      [2, 6],
      [4, 3]
    ],
    [
      [1, 6]
    ],
    [
      [4, 2]
    ],
    [
      [1, 3],
      [3, 2]
    ]
  ]
}
Test Case 7 passed!
Expected Output
[
  [
    [1, 7]
  ],
  [
    [0, 7],
    [2, 6],
    [4, 3]
  ],
  [
    [1, 6]
  ],
  [
    [4, 2]
  ],
  [
    [1, 3],
    [3, 2]
  ]
]
Your Code's Output
[
  [
    [1, 7]
  ],
  [
    [0, 7],
    [2, 6],
    [4, 3]
  ],
  [
    [1, 6]
  ],
  [
    [4, 2]
  ],
  [
    [1, 3],
    [3, 2]
  ]
]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 7]
    ],
    [
      [0, 7],
      [2, 6],
      [4, 3]
    ],
    [
      [1, 6],
      [3, 14]
    ],
    [
      [2, 14],
      [4, 2]
    ],
    [
      [1, 3],
      [3, 2]
    ]
  ]
}
Test Case 8 passed!
Expected Output
[
  [
    [1, 7]
  ],
  [
    [0, 7],
    [2, 6],
    [4, 3]
  ],
  [
    [1, 6]
  ],
  [
    [4, 2]
  ],
  [
    [1, 3],
    [3, 2]
  ]
]
Your Code's Output
[
  [
    [1, 7]
  ],
  [
    [0, 7],
    [2, 6],
    [4, 3]
  ],
  [
    [1, 6]
  ],
  [
    [4, 2]
  ],
  [
    [1, 3],
    [3, 2]
  ]
]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 7]
    ],
    [
      [0, 7],
      [2, 6],
      [3, 20],
      [4, 3]
    ],
    [
      [1, 6],
      [3, 14]
    ],
    [
      [1, 20],
      [2, 14],
      [4, 2]
    ],
    [
      [1, 3],
      [3, 2]
    ]
  ]
}
Test Case 9 passed!
Expected Output
[
  [
    [2, 5]
  ],
  [
    [2, 6],
    [4, 3]
  ],
  [
    [0, 5],
    [1, 6]
  ],
  [
    [4, 2]
  ],
  [
    [1, 3],
    [3, 2]
  ]
]
Your Code's Output
[
  [
    [2, 5]
  ],
  [
    [2, 6],
    [4, 3]
  ],
  [
    [0, 5],
    [1, 6]
  ],
  [
    [4, 2]
  ],
  [
    [1, 3],
    [3, 2]
  ]
]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 7],
      [2, 5]
    ],
    [
      [0, 7],
      [2, 6],
      [3, 20],
      [4, 3]
    ],
    [
      [0, 5],
      [1, 6],
      [3, 14]
    ],
    [
      [1, 20],
      [2, 14],
      [4, 2]
    ],
    [
      [1, 3],
      [3, 2]
    ]
  ]
}
Test Case 10 passed!
Expected Output
[
  [
    [1, 1]
  ],
  [
    [0, 1]
  ],
  [
    [3, 1]
  ],
  [
    [2, 1]
  ]
]
Your Code's Output
[
  [
    [1, 1]
  ],
  [
    [0, 1]
  ],
  [
    [3, 1]
  ],
  [
    [2, 1]
  ]
]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 1]
    ],
    [
      [0, 1]
    ],
    [
      [3, 1]
    ],
    [
      [2, 1]
    ]
  ]
}
Test Case 11 passed!
Expected Output
[
  [
    [1, 1]
  ],
  [
    [0, 1]
  ],
  [
    [3, 3]
  ],
  [
    [2, 3]
  ],
  [
    [5, 5]
  ],
  [
    [4, 5]
  ]
]
Your Code's Output
[
  [
    [1, 1]
  ],
  [
    [0, 1]
  ],
  [
    [3, 3]
  ],
  [
    [2, 3]
  ],
  [
    [5, 5]
  ],
  [
    [4, 5]
  ]
]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 1]
    ],
    [
      [0, 1]
    ],
    [
      [3, 3]
    ],
    [
      [2, 3]
    ],
    [
      [5, 5]
    ],
    [
      [4, 5]
    ]
  ]
}
Test Case 12 passed!
Expected Output
[
  [
    [1, 3]
  ],
  [
    [0, 3],
    [3, 12]
  ],
  [
    [4, 10]
  ],
  [
    [1, 12]
  ],
  [
    [2, 10],
    [5, 15]
  ],
  [
    [4, 15]
  ]
]
Your Code's Output
[
  [
    [1, 3]
  ],
  [
    [0, 3],
    [3, 12]
  ],
  [
    [4, 10]
  ],
  [
    [1, 12]
  ],
  [
    [2, 10],
    [5, 15]
  ],
  [
    [4, 15]
  ]
]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 3]
    ],
    [
      [0, 3],
      [3, 12]
    ],
    [
      [4, 10],
      [5, 20]
    ],
    [
      [1, 12]
    ],
    [
      [2, 10],
      [5, 15]
    ],
    [
      [2, 20],
      [4, 15]
    ]
  ]
}
Test Case 13 passed!
Expected Output
[
  [
    [1, 3],
    [2, 5]
  ],
  [
    [0, 3],
    [4, 3]
  ],
  [
    [0, 5],
    [6, 10]
  ],
  [
    [4, 2]
  ],
  [
    [1, 3],
    [3, 2]
  ],
  [
    [6, 2]
  ],
  [
    [2, 10],
    [5, 2],
    [7, 100]
  ],
  [
    [6, 100]
  ]
]
Your Code's Output
[
  [
    [1, 3],
    [2, 5]
  ],
  [
    [0, 3],
    [4, 3]
  ],
  [
    [0, 5],
    [6, 10]
  ],
  [
    [4, 2]
  ],
  [
    [1, 3],
    [3, 2]
  ],
  [
    [6, 2]
  ],
  [
    [2, 10],
    [5, 2],
    [7, 100]
  ],
  [
    [6, 100]
  ]
]
View Outputs Side By Side
Input(s)
{
  "edges": [
    [
      [1, 3],
      [2, 5]
    ],
    [
      [0, 3],
      [2, 12],
      [3, 20],
      [4, 3]
    ],
    [
      [0, 5],
      [1, 12],
      [3, 14],
      [6, 10]
    ],
    [
      [1, 20],
      [2, 14],
      [4, 2]
    ],
    [
      [1, 3],
      [3, 2],
      [5, 11]
    ],
    [
      [4, 11],
      [6, 2]
    ],
    [
      [2, 10],
      [5, 2],
      [7, 100]
    ],
    [
      [6, 100]
    ]
  ]
}
 
 
 */