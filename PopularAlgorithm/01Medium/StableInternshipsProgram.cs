using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopularAlgorithm._01Medium
{
    class StableInternshipsProgram
    {
        public int[][] StableInternships(int[][] interns, int[][] teams)
        {
            // O(n^2) time | O(n^2) space
            Dictionary<int, int> chosenInterns = new Dictionary<int, int>();
            Stack<int> freeInterns = new Stack<int>();
            for (int i = 0; i < interns.Length; i++)
            {
                freeInterns.Push(i);
            }
            int[] currentInternChoices = new int[interns.Length];
            List<Dictionary<int, int>> teamDictionary =
                new List<Dictionary<int, int>>();
            foreach (var team in teams)
            {
                Dictionary<int, int> rank = new Dictionary<int, int>();
                for (int i = 0; i < team.Length; i++)
                {
                    rank[team[i]] = i;
                }
                teamDictionary.Add(rank);
            }
            while (freeInterns.Count != 0)
            {
                int internNum = freeInterns.Pop();

                int[] intern = interns[internNum];
                int teamPreference = intern[currentInternChoices[internNum]];
                currentInternChoices[internNum]++;

                if (!chosenInterns.ContainsKey(teamPreference))
                {
                    chosenInterns[teamPreference] = internNum;
                    continue;
                }

                int previousIntern = chosenInterns[teamPreference];
                int previousInternRank = teamDictionary[teamPreference][previousIntern];
                int currentInternRank = teamDictionary[teamPreference][internNum];

                if (currentInternRank < previousInternRank)
                {
                    freeInterns.Push(previousIntern);
                    chosenInterns[teamPreference] = internNum;
                }
                else
                {
                    freeInterns.Push(internNum);
                }
            }

            int[][] matches = new int[interns.Length][];
            int index = 0;
            foreach (var chosenIntern in chosenInterns)
            {
                matches[index] = new int[] { chosenIntern.Value, chosenIntern.Key };
                index++;
            }
            return matches;
        }
    }
}
/*
 using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    int[][] interns = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 } };
    int[][] teams = new int[][] { new int[] { 1, 0 }, new int[] { 1, 0 } };
    int[][] expected = new int[][] { new int[] { 0, 0 }, new int[] { 1, 1 } };
    var actual = new Program().StableInternships(interns, teams);

    Utils.AssertTrue(expected.Length == actual.Length);

    foreach (var match in expected) {
      bool containsMatch = false;
      foreach (var actualMatch in actual) {
        if (actualMatch[0] == match[0] && actualMatch[1] == match[1]) {
          containsMatch = true;
        }
      }
      Utils.AssertTrue(containsMatch);
    }
  }
}
 
 -------------------------------------------------------------------------------
13 / 13 test cases passed.

Test Case 1 passed!
Expected Output
[]
Your Code's Output
[]
View Outputs Side By Side
Input(s)
{
  "interns": [],
  "teams": []
}
Test Case 2 passed!
Expected Output
[
  [0, 0]
]
Your Code's Output
[
  [0, 0]
]
View Outputs Side By Side
Input(s)
{
  "interns": [
    [0]
  ],
  "teams": [
    [0]
  ]
}
Test Case 3 passed!
Expected Output
[
  [0, 0],
  [1, 1]
]
Your Code's Output
[
  [0, 0],
  [1, 1]
]
View Outputs Side By Side
Input(s)
{
  "interns": [
    [0, 1],
    [1, 0]
  ],
  "teams": [
    [0, 1],
    [1, 0]
  ]
}
Test Case 4 passed!
Expected Output
[
  [0, 0],
  [1, 1]
]
Your Code's Output
[
  [0, 0],
  [1, 1]
]
View Outputs Side By Side
Input(s)
{
  "interns": [
    [0, 1],
    [0, 1]
  ],
  "teams": [
    [0, 1],
    [0, 1]
  ]
}
Test Case 5 passed!
Expected Output
[
  [0, 0],
  [1, 1]
]
Your Code's Output
[
  [0, 0],
  [1, 1]
]
View Outputs Side By Side
Input(s)
{
  "interns": [
    [0, 1],
    [0, 1]
  ],
  "teams": [
    [0, 1],
    [1, 0]
  ]
}
Test Case 6 passed!
Expected Output
[
  [0, 0],
  [1, 1]
]
Your Code's Output
[
  [0, 0],
  [1, 1]
]
View Outputs Side By Side
Input(s)
{
  "interns": [
    [0, 1],
    [1, 0]
  ],
  "teams": [
    [0, 1],
    [0, 1]
  ]
}
Test Case 7 passed!
Expected Output
[
  [0, 1],
  [1, 0]
]
Your Code's Output
[
  [0, 1],
  [1, 0]
]
View Outputs Side By Side
Input(s)
{
  "interns": [
    [1, 0],
    [0, 1]
  ],
  "teams": [
    [0, 1],
    [1, 0]
  ]
}
Test Case 8 passed!
Expected Output
[
  [0, 0],
  [1, 2],
  [2, 1]
]
Your Code's Output
[
  [0, 0],
  [1, 2],
  [2, 1]
]
View Outputs Side By Side
Input(s)
{
  "interns": [
    [0, 1, 2],
    [2, 1, 0],
    [1, 2, 0]
  ],
  "teams": [
    [2, 1, 0],
    [0, 1, 2],
    [0, 2, 1]
  ]
}
Test Case 9 passed!
Expected Output
[
  [0, 1],
  [1, 0],
  [2, 2]
]
Your Code's Output
[
  [0, 1],
  [1, 0],
  [2, 2]
]
View Outputs Side By Side
Input(s)
{
  "interns": [
    [0, 1, 2],
    [0, 2, 1],
    [1, 2, 0]
  ],
  "teams": [
    [2, 1, 0],
    [0, 1, 2],
    [0, 2, 1]
  ]
}
Test Case 10 passed!
Expected Output
[
  [0, 2],
  [1, 1],
  [2, 0]
]
Your Code's Output
[
  [0, 2],
  [1, 1],
  [2, 0]
]
View Outputs Side By Side
Input(s)
{
  "interns": [
    [0, 1, 2],
    [0, 1, 2],
    [0, 1, 2]
  ],
  "teams": [
    [2, 1, 0],
    [2, 1, 0],
    [2, 1, 0]
  ]
}
Test Case 11 passed!
Expected Output
[
  [0, 1],
  [1, 2],
  [2, 0],
  [3, 3]
]
Your Code's Output
[
  [0, 1],
  [1, 2],
  [2, 0],
  [3, 3]
]
View Outputs Side By Side
Input(s)
{
  "interns": [
    [0, 1, 2, 3],
    [2, 1, 3, 0],
    [0, 2, 3, 1],
    [3, 1, 0, 2]
  ],
  "teams": [
    [1, 3, 2, 0],
    [0, 1, 2, 3],
    [1, 2, 3, 0],
    [3, 0, 2, 1]
  ]
}
Test Case 12 passed!
Expected Output
[
  [0, 1],
  [1, 0],
  [2, 2],
  [3, 3]
]
Your Code's Output
[
  [0, 1],
  [1, 0],
  [2, 2],
  [3, 3]
]
View Outputs Side By Side
Input(s)
{
  "interns": [
    [0, 1, 2, 3],
    [0, 1, 3, 2],
    [0, 2, 3, 1],
    [0, 2, 3, 1]
  ],
  "teams": [
    [1, 3, 2, 0],
    [0, 1, 2, 3],
    [1, 2, 3, 0],
    [3, 0, 2, 1]
  ]
}
Test Case 13 passed!
Expected Output
[
  [0, 1],
  [1, 0],
  [2, 3],
  [3, 2]
]
Your Code's Output
[
  [0, 1],
  [1, 0],
  [2, 3],
  [3, 2]
]
View Outputs Side By Side
Input(s)
{
  "interns": [
    [0, 1, 2, 3],
    [0, 1, 3, 2],
    [0, 2, 3, 1],
    [0, 2, 3, 1]
  ],
  "teams": [
    [1, 3, 2, 0],
    [0, 1, 2, 3],
    [1, 3, 2, 0],
    [3, 0, 2, 1]
  ]
}

 */