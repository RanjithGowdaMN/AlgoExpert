using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._04VeryHard
{
    using System;
    using System.Collections.Generic;

    public class CApartmentHunting
    {
        public static int ApartmentHunting(List<Dictionary<string, bool>> blocks, string[] reqs)
        {
            // Write your code here.
            int[][] minDistancesFromBlocks = new int[reqs.Length][];
            for (int i = 0; i < reqs.Length; i++)
            {
                minDistancesFromBlocks[i] = getMinDistances(blocks, reqs[i]);
            }
            int[] maxDistancesAtBlocks =
                getMaxDistancesAtBlocks(blocks, minDistancesFromBlocks);
            return getIdxAtMinValue(maxDistancesAtBlocks);
        }

        public static int[] getMinDistances(List<Dictionary<string, bool>> blocks, string req)
        {
            int[] minDistances = new int[blocks.Count];
            int closestReqIdx = Int16.MaxValue;
            for (int i = 0; i < blocks.Count; i++)
            {
                if (blocks[i][req]) closestReqIdx = i;
                minDistances[i] = distanceBetween(i, closestReqIdx);
            }
            for (int i = blocks.Count - 1; i >= 0; i--)
            {
                if (blocks[i][req]) closestReqIdx = i;
                minDistances[i] = Math.Min(minDistances[i], distanceBetween(i, closestReqIdx));
            }
            return minDistances;
        }
        public static int[] getMaxDistancesAtBlocks(List<Dictionary<string, bool>> blocks,
                                                   int[][] minDistancesFromBlocks)
        {
            int[] maxDistancesAtBlocks = new int[blocks.Count];
            for (int i = 0; i < blocks.Count; i++)
            {
                int[] minDistancesAtBlocks = new int[minDistancesFromBlocks.Length];
                for (int j = 0; j < minDistancesFromBlocks.Length; j++)
                {
                    minDistancesAtBlocks[j] = minDistancesFromBlocks[j][i];
                }
                maxDistancesAtBlocks[i] = arrayMax(minDistancesAtBlocks);
            }
            return maxDistancesAtBlocks;
        }

        public static int getIdxAtMinValue(int[] array)
        {
            int idxAtMinValue = 0;
            int minValue = Int32.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                int currentValue = array[i];
                if (currentValue < minValue)
                {
                    minValue = currentValue;
                    idxAtMinValue = i;
                }
            }
            return idxAtMinValue;
        }

        public static int distanceBetween(int a, int b)
        {
            return Math.Abs(a - b);
        }

        public static int arrayMax(int[] array)
        {
            int max = array[0];
            foreach (int a in array)
            {
                if (a > max)
                {
                    max = a;
                }
            }
            return max;
        }
    }

}

/*
using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    List<Dictionary<string, bool> > blocks =
      new List<Dictionary<string, bool> >();

    blocks.Insert(0, new Dictionary<string, bool>());
    blocks[0]["gym"] = false;
    blocks[0]["school"] = true;
    blocks[0]["store"] = false;

    blocks.Insert(1, new Dictionary<string, bool>());
    blocks[1]["gym"] = true;
    blocks[1]["school"] = false;
    blocks[1]["store"] = false;

    blocks.Insert(2, new Dictionary<string, bool>());
    blocks[2]["gym"] = true;
    blocks[2]["school"] = true;
    blocks[2]["store"] = false;

    blocks.Insert(3, new Dictionary<string, bool>());
    blocks[3]["gym"] = false;
    blocks[3]["school"] = true;
    blocks[3]["store"] = false;

    blocks.Insert(4, new Dictionary<string, bool>());
    blocks[4]["gym"] = false;
    blocks[4]["school"] = true;
    blocks[4]["store"] = true;

    string[] reqs = new string[] { "gym", "school", "store" };
    Utils.AssertTrue(Program.ApartmentHunting(blocks, reqs) == 3);
  }
}


7 / 7 test cases passed.

Test Case 1 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "blocks": [
    {
      "gym": false,
      "school": true,
      "store": false
    },
    {
      "gym": true,
      "school": false,
      "store": false
    },
    {
      "gym": true,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "school": true,
      "store": true
    }
  ],
  "reqs": ["gym", "school", "store"]
}
Test Case 2 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "blocks": [
    {
      "gym": false,
      "office": true,
      "school": true,
      "store": false
    },
    {
      "gym": true,
      "office": false,
      "school": false,
      "store": false
    },
    {
      "gym": true,
      "office": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "school": true,
      "store": true
    }
  ],
  "reqs": ["gym", "office", "school", "store"]
}
Test Case 3 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "blocks": [
    {
      "gym": false,
      "office": true,
      "school": true,
      "store": false
    },
    {
      "gym": true,
      "office": false,
      "school": false,
      "store": false
    },
    {
      "gym": true,
      "office": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "school": true,
      "store": true
    }
  ],
  "reqs": ["gym", "office", "school", "store"]
}
Test Case 4 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "blocks": [
    {
      "foo": true,
      "gym": false,
      "kappa": false,
      "office": true,
      "school": true,
      "store": false
    },
    {
      "foo": true,
      "gym": true,
      "kappa": false,
      "office": false,
      "school": false,
      "store": false
    },
    {
      "foo": true,
      "gym": true,
      "kappa": false,
      "office": false,
      "school": true,
      "store": false
    },
    {
      "foo": true,
      "gym": false,
      "kappa": false,
      "office": false,
      "school": true,
      "store": false
    },
    {
      "foo": true,
      "gym": true,
      "kappa": false,
      "office": false,
      "school": true,
      "store": false
    },
    {
      "foo": true,
      "gym": false,
      "kappa": false,
      "office": false,
      "school": true,
      "store": true
    }
  ],
  "reqs": ["gym", "school", "store"]
}
Test Case 5 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "blocks": [
    {
      "gym": true,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "school": false,
      "store": true
    },
    {
      "gym": true,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "school": true,
      "store": false
    }
  ],
  "reqs": ["gym", "school", "store"]
}
Test Case 6 passed!
Expected Output
7
Your Code's Output
7
View Outputs Side By Side
Input(s)
{
  "blocks": [
    {
      "gym": true,
      "pool": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "pool": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "pool": false,
      "school": false,
      "store": true
    },
    {
      "gym": true,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "pool": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "pool": true,
      "school": false,
      "store": false
    }
  ],
  "reqs": ["gym", "pool", "school", "store"]
}
Test Case 7 passed!
Expected Output
4
Your Code's Output
4
View Outputs Side By Side
Input(s)
{
  "blocks": [
    {
      "gym": true,
      "office": false,
      "pool": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "office": true,
      "pool": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "office": true,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "pool": false,
      "school": false,
      "store": true
    },
    {
      "gym": true,
      "office": true,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "pool": true,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "pool": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "pool": true,
      "school": false,
      "store": false
    }
  ],
  "reqs": ["gym", "pool", "school", "store"]
} 




 {
  "blocks": [
    {
      "gym": false,
      "school": true,
      "store": false
    },
    {
      "gym": true,
      "school": false,
      "store": false
    },
    {
      "gym": true,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "school": true,
      "store": true
    }
  ],
  "reqs": ["gym", "school", "store"]
}
Test Case 2
{
  "blocks": [
    {
      "gym": false,
      "office": true,
      "school": true,
      "store": false
    },
    {
      "gym": true,
      "office": false,
      "school": false,
      "store": false
    },
    {
      "gym": true,
      "office": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "school": true,
      "store": true
    }
  ],
  "reqs": ["gym", "office", "school", "store"]
}
Test Case 3
{
  "blocks": [
    {
      "gym": false,
      "office": true,
      "school": true,
      "store": false
    },
    {
      "gym": true,
      "office": false,
      "school": false,
      "store": false
    },
    {
      "gym": true,
      "office": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "school": true,
      "store": true
    }
  ],
  "reqs": ["gym", "office", "school", "store"]
}
Test Case 4
{
  "blocks": [
    {
      "foo": true,
      "gym": false,
      "kappa": false,
      "office": true,
      "school": true,
      "store": false
    },
    {
      "foo": true,
      "gym": true,
      "kappa": false,
      "office": false,
      "school": false,
      "store": false
    },
    {
      "foo": true,
      "gym": true,
      "kappa": false,
      "office": false,
      "school": true,
      "store": false
    },
    {
      "foo": true,
      "gym": false,
      "kappa": false,
      "office": false,
      "school": true,
      "store": false
    },
    {
      "foo": true,
      "gym": true,
      "kappa": false,
      "office": false,
      "school": true,
      "store": false
    },
    {
      "foo": true,
      "gym": false,
      "kappa": false,
      "office": false,
      "school": true,
      "store": true
    }
  ],
  "reqs": ["gym", "school", "store"]
}
Test Case 5
{
  "blocks": [
    {
      "gym": true,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "school": false,
      "store": true
    },
    {
      "gym": true,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "school": true,
      "store": false
    }
  ],
  "reqs": ["gym", "school", "store"]
}
Test Case 6
{
  "blocks": [
    {
      "gym": true,
      "pool": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "pool": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "pool": false,
      "school": false,
      "store": true
    },
    {
      "gym": true,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "pool": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "pool": true,
      "school": false,
      "store": false
    }
  ],
  "reqs": ["gym", "pool", "school", "store"]
}
Test Case 7
{
  "blocks": [
    {
      "gym": true,
      "office": false,
      "pool": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "office": true,
      "pool": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "office": true,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "pool": false,
      "school": false,
      "store": true
    },
    {
      "gym": true,
      "office": true,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "pool": true,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "pool": false,
      "school": false,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "pool": false,
      "school": true,
      "store": false
    },
    {
      "gym": false,
      "office": false,
      "pool": true,
      "school": false,
      "store": false
    }
  ],
  "reqs": ["gym", "pool", "school", "store"]
}
 
 */