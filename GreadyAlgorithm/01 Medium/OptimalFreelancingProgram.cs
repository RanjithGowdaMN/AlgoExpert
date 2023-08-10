using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreadyAlgorithm._01_Medium
{
    class OptimalFreelancingProgram
    { 
        public int OptimalFreelancing(Dictionary<string, int>[] jobs)
    {
        // Write your code here.
        const int LENGTH_OF_WEEK = 7;
        int profit = 0;
        Array.Sort(
            jobs,
            Comparer<Dictionary<string, int>>.Create((jobOne, jobTwo) => jobTwo["payment"].CompareTo(jobOne["payment"])));
        bool[] timeline = new bool[LENGTH_OF_WEEK];

        foreach (var job in jobs)
        {
            int maxTime = Math.Min(job["deadline"], LENGTH_OF_WEEK);
            for (int time = maxTime - 1; time >= 0; time--)
            {
                if (!timeline[time])
                {
                    timeline[time] = true;
                    profit += job["payment"];
                    break;
                }
            }
        }
        return profit;
    }
}
}

/*
 using System.Collections.Generic;
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Dictionary<string, int>[] input = new Dictionary<string, int>[1];
    Dictionary<string, int> job = new Dictionary<string, int>();
    job["deadline"] = 1;
    job["payment"] = 1;
    input[0] = job;
    var expected = 1;
    var actual = new Program().OptimalFreelancing(input);
    Utils.AssertTrue(expected == actual);
  }
}

 3 / 13 test cases passed.

Test Case 1 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "jobs": []
}
Test Case 2 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "jobs": [
    {
      "deadline": 1,
      "payment": 1
    }
  ]
}
Test Case 3 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "jobs": [
    {
      "deadline": 1,
      "payment": 2
    },
    {
      "deadline": 1,
      "payment": 1
    }
  ]
}
Test Case 4 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "jobs": [
    {
      "deadline": 1,
      "payment": 1
    },
    {
      "deadline": 1,
      "payment": 2
    }
  ]
}
Test Case 5 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "jobs": [
    {
      "deadline": 1,
      "payment": 1
    },
    {
      "deadline": 2,
      "payment": 1
    }
  ]
}
Test Case 6 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "jobs": [
    {
      "deadline": 1,
      "payment": 1
    },
    {
      "deadline": 2,
      "payment": 2
    },
    {
      "deadline": 2,
      "payment": 1
    }
  ]
}
Test Case 7 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "jobs": [
    {
      "deadline": 8,
      "payment": 3
    },
    {
      "deadline": 1,
      "payment": 1
    },
    {
      "deadline": 1,
      "payment": 2
    }
  ]
}
Test Case 8 passed!
Expected Output
13
Your Code's Output
13
View Outputs Side By Side
Input(s)
{
  "jobs": [
    {
      "deadline": 2,
      "payment": 2
    },
    {
      "deadline": 4,
      "payment": 3
    },
    {
      "deadline": 5,
      "payment": 1
    },
    {
      "deadline": 7,
      "payment": 2
    },
    {
      "deadline": 3,
      "payment": 1
    },
    {
      "deadline": 3,
      "payment": 2
    },
    {
      "deadline": 1,
      "payment": 3
    }
  ]
}
Test Case 9 passed!
Expected Output
13
Your Code's Output
13
View Outputs Side By Side
Input(s)
{
  "jobs": [
    {
      "deadline": 2,
      "payment": 1
    },
    {
      "deadline": 2,
      "payment": 2
    },
    {
      "deadline": 2,
      "payment": 3
    },
    {
      "deadline": 2,
      "payment": 4
    },
    {
      "deadline": 2,
      "payment": 5
    },
    {
      "deadline": 2,
      "payment": 6
    },
    {
      "deadline": 2,
      "payment": 7
    }
  ]
}
Test Case 10 passed!
Expected Output
13
Your Code's Output
13
View Outputs Side By Side
Input(s)
{
  "jobs": [
    {
      "deadline": 8,
      "payment": 1
    },
    {
      "deadline": 6,
      "payment": 4
    },
    {
      "deadline": 1,
      "payment": 2
    },
    {
      "deadline": 1,
      "payment": 3
    },
    {
      "deadline": 2,
      "payment": 3
    },
    {
      "deadline": 5,
      "payment": 2
    }
  ]
}
Test Case 11 passed!
Expected Output
16
Your Code's Output
16
View Outputs Side By Side
Input(s)
{
  "jobs": [
    {
      "deadline": 2,
      "payment": 1
    },
    {
      "deadline": 1,
      "payment": 4
    },
    {
      "deadline": 3,
      "payment": 2
    },
    {
      "deadline": 1,
      "payment": 3
    },
    {
      "deadline": 4,
      "payment": 3
    },
    {
      "deadline": 4,
      "payment": 2
    },
    {
      "deadline": 4,
      "payment": 1
    },
    {
      "deadline": 5,
      "payment": 4
    },
    {
      "deadline": 8,
      "payment": 1
    }
  ]
}
Test Case 12 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "jobs": [
    {
      "deadline": 10,
      "payment": 1
    }
  ]
}
Test Case 13 passed!
Expected Output
7
Your Code's Output
7
View Outputs Side By Side
Input(s)
{
  "jobs": [
    {
      "deadline": 1,
      "payment": 1
    },
    {
      "deadline": 2,
      "payment": 1
    },
    {
      "deadline": 3,
      "payment": 1
    },
    {
      "deadline": 4,
      "payment": 1
    },
    {
      "deadline": 5,
      "payment": 1
    },
    {
      "deadline": 6,
      "payment": 1
    },
    {
      "deadline": 7,
      "payment": 1
    },
    {
      "deadline": 8,
      "payment": 1
    },
    {
      "deadline": 9,
      "payment": 1
    },
    {
      "deadline": 10,
      "payment": 1
    }
  ]
}
 
 */