using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopularAlgorithm._01Medium
{
    class UnionFindProgram
    {
        public class UnionFind1
        {
            // Write your code here.
            private Dictionary<int, int> parents = new Dictionary<int, int>();
            public void CreateSet(int value)
            {
                // Write your code here.
                //O(1) time | O(1) space
                parents[value] = value;

            }

            public int? Find(int value)
            {
                // Write your code here. O(n) time
                if (!parents.ContainsKey(value))
                {
                    return null;
                }
                int currentParent = value;
                while (currentParent != parents[currentParent])
                {
                    currentParent = parents[currentParent];
                }
                return currentParent;
            }

            public void Union(int valueOne, int valueTwo)
            {
                // Write your code here. O(n) time | O(1)
                if (!parents.ContainsKey(valueOne) || !parents.ContainsKey(valueTwo))
                {
                    return;
                }
                int valueOneRoot = (int)Find(valueOne);
                int valueTwoRoot = (int)Find(valueTwo);
                parents[valueTwoRoot] = valueOneRoot;
            }
        }

        public class UnionFind2
        {
            // Write your code here.
            private Dictionary<int, int> parents = new Dictionary<int, int>();
            private Dictionary<int, int> ranks = new Dictionary<int, int>();
            public void CreateSet(int value)
            {
                // Write your code here.
                parents[value] = value;
                ranks[value] = 0;
            }

            public int? Find(int value)
            {
                // Write your code here. O(n) time
                if (!parents.ContainsKey(value))
                {
                    return null;
                }
                int currentParent = value;
                while (currentParent != parents[currentParent])
                {
                    currentParent = parents[currentParent];
                }
                return currentParent;
            }

            public void Union(int valueOne, int valueTwo)
            {
                // Write your code here.
                if (!parents.ContainsKey(valueOne) || !parents.ContainsKey(valueTwo))
                {
                    return;
                }
                int valueOneRoot = (int)Find(valueOne);
                int valueTwoRoot = (int)Find(valueTwo);
                if (ranks[valueOneRoot] < ranks[valueTwoRoot])
                {
                    parents[valueOneRoot] = valueTwoRoot;
                }
                else if (ranks[valueOneRoot] > ranks[valueTwoRoot])
                {
                    parents[valueTwoRoot] = valueOneRoot;
                }
                else
                {
                    parents[valueTwoRoot] = valueOneRoot;
                    ranks[valueOneRoot] = ranks[valueOneRoot] + 1;
                }
            }
        }

        public class UnionFind3
        {
            // Write your code here.
            private Dictionary<int, int> parents = new Dictionary<int, int>();
            private Dictionary<int, int> ranks = new Dictionary<int, int>();
            public void CreateSet(int value)
            {
                // Write your code here.
                parents[value] = value;
                ranks[value] = 0;
            }

            public int? Find(int value)
            {
                // Write your code here.
                if (!parents.ContainsKey(value))
                {
                    return null;
                }
                if (value != parents[value])
                {
                    parents[value] = (int)Find(parents[value]);
                }
                return parents[value];
            }

            public void Union(int valueOne, int valueTwo)
            {
                // Write your code here.
                if (!parents.ContainsKey(valueOne) || !parents.ContainsKey(valueTwo))
                {
                    return;
                }
                int valueOneRoot = (int)Find(valueOne);
                int valueTwoRoot = (int)Find(valueTwo);
                if (ranks[valueOneRoot] < ranks[valueTwoRoot])
                {
                    parents[valueOneRoot] = valueTwoRoot;
                }
                else if (ranks[valueOneRoot] > ranks[valueTwoRoot])
                {
                    parents[valueTwoRoot] = valueOneRoot;
                }
                else
                {
                    parents[valueTwoRoot] = valueOneRoot;
                    ranks[valueOneRoot] = ranks[valueOneRoot] + 1;
                }
            }
        }
    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var unionFind = new Program.UnionFind();
    Utils.AssertTrue(unionFind.Find(1) == null);
    unionFind.CreateSet(1);
    Utils.AssertTrue(unionFind.Find(1) == 1);
    unionFind.CreateSet(5);
    Utils.AssertTrue(unionFind.Find(1) == 1);
    Utils.AssertTrue(unionFind.Find(5) == 5);
    unionFind.Union(5, 1);
    Utils.AssertTrue(unionFind.Find(5) == unionFind.Find(1));
  }
}

10 / 10 test cases passed.

Test Case 1 passed!
Expected Output
[
  {
    "arguments": [0],
    "method": "find",
    "output": null
  },
  {
    "arguments": [1],
    "method": "find",
    "output": null
  }
]
Your Code's Output
[
  {
    "arguments": [0],
    "method": "find",
    "output": null
  },
  {
    "arguments": [1],
    "method": "find",
    "output": null
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [0],
      "method": "find"
    },
    {
      "arguments": [1],
      "method": "find"
    }
  ]
}
Test Case 2 passed!
Expected Output
[
  {
    "arguments": [0],
    "method": "find",
    "output": null
  },
  {
    "arguments": [1],
    "method": "find",
    "output": null
  },
  {
    "arguments": [0, 1],
    "method": "union",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": null
  },
  {
    "arguments": [1],
    "method": "find",
    "output": null
  }
]
Your Code's Output
[
  {
    "arguments": [0],
    "method": "find",
    "output": null
  },
  {
    "arguments": [1],
    "method": "find",
    "output": null
  },
  {
    "arguments": [0, 1],
    "method": "union",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": null
  },
  {
    "arguments": [1],
    "method": "find",
    "output": null
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [0],
      "method": "find"
    },
    {
      "arguments": [1],
      "method": "find"
    },
    {
      "arguments": [0, 1],
      "method": "union"
    },
    {
      "arguments": [0],
      "method": "find"
    },
    {
      "arguments": [1],
      "method": "find"
    }
  ]
}
Test Case 3 passed!
Expected Output
[
  {
    "arguments": [0],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": 0
  }
]
Your Code's Output
[
  {
    "arguments": [0],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": 0
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [0],
      "method": "createSet"
    },
    {
      "arguments": [0],
      "method": "find"
    }
  ]
}
Test Case 4 passed!
Expected Output
[
  {
    "arguments": [0],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [1],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [1],
    "method": "find",
    "output": 1
  }
]
Your Code's Output
[
  {
    "arguments": [0],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [1],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [1],
    "method": "find",
    "output": 1
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [0],
      "method": "createSet"
    },
    {
      "arguments": [1],
      "method": "createSet"
    },
    {
      "arguments": [0],
      "method": "find"
    },
    {
      "arguments": [1],
      "method": "find"
    }
  ]
}
Test Case 5 passed!
Expected Output
[
  {
    "arguments": [10],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [5],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [10],
    "method": "find",
    "output": 10
  },
  {
    "arguments": [5],
    "method": "find",
    "output": 5
  },
  {
    "arguments": [10, 5],
    "method": "union",
    "output": null
  },
  {
    "arguments": [10],
    "method": "find",
    "output": 10
  },
  {
    "arguments": [5],
    "method": "find",
    "output": 10
  }
]
Your Code's Output
[
  {
    "arguments": [10],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [5],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [10],
    "method": "find",
    "output": 10
  },
  {
    "arguments": [5],
    "method": "find",
    "output": 5
  },
  {
    "arguments": [10, 5],
    "method": "union",
    "output": null
  },
  {
    "arguments": [10],
    "method": "find",
    "output": 10
  },
  {
    "arguments": [5],
    "method": "find",
    "output": 10
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [10],
      "method": "createSet"
    },
    {
      "arguments": [5],
      "method": "createSet"
    },
    {
      "arguments": [10],
      "method": "find"
    },
    {
      "arguments": [5],
      "method": "find"
    },
    {
      "arguments": [10, 5],
      "method": "union"
    },
    {
      "arguments": [10],
      "method": "find"
    },
    {
      "arguments": [5],
      "method": "find"
    }
  ]
}
Test Case 6 passed!
Expected Output
[
  {
    "arguments": [0],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [1],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [2],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [3],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [0, 2],
    "method": "union",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [1],
    "method": "find",
    "output": 1
  },
  {
    "arguments": [2],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [3],
    "method": "find",
    "output": 3
  }
]
Your Code's Output
[
  {
    "arguments": [0],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [1],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [2],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [3],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [0, 2],
    "method": "union",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [1],
    "method": "find",
    "output": 1
  },
  {
    "arguments": [2],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [3],
    "method": "find",
    "output": 3
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [0],
      "method": "createSet"
    },
    {
      "arguments": [1],
      "method": "createSet"
    },
    {
      "arguments": [2],
      "method": "createSet"
    },
    {
      "arguments": [3],
      "method": "createSet"
    },
    {
      "arguments": [0, 2],
      "method": "union"
    },
    {
      "arguments": [0],
      "method": "find"
    },
    {
      "arguments": [1],
      "method": "find"
    },
    {
      "arguments": [2],
      "method": "find"
    },
    {
      "arguments": [3],
      "method": "find"
    }
  ]
}
Test Case 7 passed!
Expected Output
[
  {
    "arguments": [0],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [2],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [0, 2],
    "method": "union",
    "output": null
  },
  {
    "arguments": [3],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [1],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [1, 3],
    "method": "union",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [1],
    "method": "find",
    "output": 1
  },
  {
    "arguments": [2],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [3],
    "method": "find",
    "output": 1
  }
]
Your Code's Output
[
  {
    "arguments": [0],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [2],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [0, 2],
    "method": "union",
    "output": null
  },
  {
    "arguments": [3],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [1],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [1, 3],
    "method": "union",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [1],
    "method": "find",
    "output": 1
  },
  {
    "arguments": [2],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [3],
    "method": "find",
    "output": 1
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [0],
      "method": "createSet"
    },
    {
      "arguments": [2],
      "method": "createSet"
    },
    {
      "arguments": [0, 2],
      "method": "union"
    },
    {
      "arguments": [3],
      "method": "createSet"
    },
    {
      "arguments": [1],
      "method": "createSet"
    },
    {
      "arguments": [1, 3],
      "method": "union"
    },
    {
      "arguments": [0],
      "method": "find"
    },
    {
      "arguments": [1],
      "method": "find"
    },
    {
      "arguments": [2],
      "method": "find"
    },
    {
      "arguments": [3],
      "method": "find"
    }
  ]
}
Test Case 8 passed!
Expected Output
[
  {
    "arguments": [0],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [2],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [0, 2],
    "method": "union",
    "output": null
  },
  {
    "arguments": [3],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [1],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [1, 3],
    "method": "union",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [1],
    "method": "find",
    "output": 1
  },
  {
    "arguments": [2],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [3],
    "method": "find",
    "output": 1
  },
  {
    "arguments": [3, 0],
    "method": "union",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": 1
  },
  {
    "arguments": [1],
    "method": "find",
    "output": 1
  },
  {
    "arguments": [2],
    "method": "find",
... 
Your Code's Output
[
  {
    "arguments": [0],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [2],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [0, 2],
    "method": "union",
    "output": null
  },
  {
    "arguments": [3],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [1],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [1, 3],
    "method": "union",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [1],
    "method": "find",
    "output": 1
  },
  {
    "arguments": [2],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [3],
    "method": "find",
    "output": 1
  },
  {
    "arguments": [3, 0],
    "method": "union",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": 1
  },
  {
    "arguments": [1],
    "method": "find",
    "output": 1
  },
  {
    "arguments": [2],
    "method": "find",
... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [0],
      "method": "createSet"
    },
    {
      "arguments": [2],
      "method": "createSet"
    },
    {
      "arguments": [0, 2],
      "method": "union"
    },
    {
      "arguments": [3],
      "method": "createSet"
    },
    {
      "arguments": [1],
      "method": "createSet"
    },
    {
      "arguments": [1, 3],
      "method": "union"
    },
    {
      "arguments": [0],
      "method": "find"
    },
    {
      "arguments": [1],
      "method": "find"
    },
    {
      "arguments": [2],
      "method": "find"
    },
    {
      "arguments": [3],
      "method": "find"
    },
    {
      "arguments": [3, 0],
      "method": "union"
    },
    {
      "arguments": [0],
      "method": "find"
    },
    {
      "arguments": [1],
      "method": "find"
    },
    {
      "arguments": [2],
      "method": "find"
    },
    {
      "arguments": [3],
      "method": "find"
    }
  ]
}
Test Case 9 passed!
Expected Output
[
  {
    "arguments": [0],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [1],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [1],
    "method": "find",
    "output": 1
  },
  {
    "arguments": [0, 2],
    "method": "union",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [1],
    "method": "find",
    "output": 1
  },
  {
    "arguments": [0, 1],
    "method": "union",
    "output": null
  },
  {
    "arguments": [1, 0],
    "method": "union",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [1],
    "method": "find",
    "output": 0
  }
]
Your Code's Output
[
  {
    "arguments": [0],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [1],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [1],
    "method": "find",
    "output": 1
  },
  {
    "arguments": [0, 2],
    "method": "union",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [1],
    "method": "find",
    "output": 1
  },
  {
    "arguments": [0, 1],
    "method": "union",
    "output": null
  },
  {
    "arguments": [1, 0],
    "method": "union",
    "output": null
  },
  {
    "arguments": [0],
    "method": "find",
    "output": 0
  },
  {
    "arguments": [1],
    "method": "find",
    "output": 0
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [0],
      "method": "createSet"
    },
    {
      "arguments": [1],
      "method": "createSet"
    },
    {
      "arguments": [0],
      "method": "find"
    },
    {
      "arguments": [1],
      "method": "find"
    },
    {
      "arguments": [0, 2],
      "method": "union"
    },
    {
      "arguments": [0],
      "method": "find"
    },
    {
      "arguments": [1],
      "method": "find"
    },
    {
      "arguments": [0, 1],
      "method": "union"
    },
    {
      "arguments": [1, 0],
      "method": "union"
    },
    {
      "arguments": [0],
      "method": "find"
    },
    {
      "arguments": [1],
      "method": "find"
    }
  ]
}
Test Case 10 passed!
Expected Output
[
  {
    "arguments": [3],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [12],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [5],
    "method": "find",
    "output": null
  },
  {
    "arguments": [2],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [1000],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [1000, 2],
    "method": "union",
    "output": null
  },
  {
    "arguments": [1000, 5],
    "method": "union",
    "output": null
  },
  {
    "arguments": [1, 12],
    "method": "union",
    "output": null
  },
  {
    "arguments": [7],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [3, 5],
    "method": "union",
    "output": null
  },
  {
    "arguments": [7, 3],
    "method": "union",
    "output": null
  },
  {
    "arguments": [1],
    "method": "find",
    "output": null
  },
  {
    "arguments": [3],
    "method": "find",
    "output": 7
  },
  {
    "... 
Your Code's Output
[
  {
    "arguments": [3],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [12],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [5],
    "method": "find",
    "output": null
  },
  {
    "arguments": [2],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [1000],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [1000, 2],
    "method": "union",
    "output": null
  },
  {
    "arguments": [1000, 5],
    "method": "union",
    "output": null
  },
  {
    "arguments": [1, 12],
    "method": "union",
    "output": null
  },
  {
    "arguments": [7],
    "method": "createSet",
    "output": null
  },
  {
    "arguments": [3, 5],
    "method": "union",
    "output": null
  },
  {
    "arguments": [7, 3],
    "method": "union",
    "output": null
  },
  {
    "arguments": [1],
    "method": "find",
    "output": null
  },
  {
    "arguments": [3],
    "method": "find",
    "output": 7
  },
  {
    "... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [3],
      "method": "createSet"
    },
    {
      "arguments": [12],
      "method": "createSet"
    },
    {
      "arguments": [5],
      "method": "find"
    },
    {
      "arguments": [2],
      "method": "createSet"
    },
    {
      "arguments": [1000],
      "method": "createSet"
    },
    {
      "arguments": [1000, 2],
      "method": "union"
    },
    {
      "arguments": [1000, 5],
      "method": "union"
    },
    {
      "arguments": [1, 12],
      "method": "union"
    },
    {
      "arguments": [7],
      "method": "createSet"
    },
    {
      "arguments": [3, 5],
      "method": "union"
    },
    {
      "arguments": [7, 3],
      "method": "union"
    },
    {
      "arguments": [1],
      "method": "find"
    },
    {
      "arguments": [3],
      "method": "find"
    },
    {
      "arguments": [12],
      "method": "find"
    },
    {
      "arguments": [5],
      "method": "find"
    },
    {
      "arguments": [2],
      "method": "find"
    },
    {
      "arguments": [1000],
      "method": "find"
    },
    {
      "arguments": [7],
      "method": "find"
    },
    {
      "arguments": [3, 12],
      "method": "union"
    },
    {
      "arguments": [12],
      "method": "find"
    }
  ]
}

 
 */