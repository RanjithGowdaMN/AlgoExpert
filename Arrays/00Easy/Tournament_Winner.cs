﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._00Easy
{
    public class Tournament_Winner
    {

        public string TournamentWinner(List<List<string>> competitions, List<int> results)
        {
            // Write your code here.
            string curWin = "";
            string curBest = "";
            Dictionary<string, int> scores = new Dictionary<string, int>();
            scores[curBest] = 0;
            for (int idx = 0; idx < competitions.Count; idx++)
            {
                if (results[idx] == 0)
                {
                    curWin = competitions[idx][1];
                }
                else
                {
                    curWin = competitions[idx][0];
                }

                if (scores.ContainsKey(curWin))
                {
                    scores[curWin] = scores[curWin] + 3;
                }
                else
                {
                    scores[curWin] = 3;
                }

                if (scores[curWin] > scores[curBest])
                {
                    curBest = curWin;
                }

            }

            return curBest;
        }
    }


}
/*
 using System.Collections.Generic;
using System;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    List<List<string> > competitions = new List<List<string> >();
    List<string> competition1 = new List<string> { "HTML", "C#" };
    List<string> competition2 = new List<string> { "C#", "Python" };
    List<string> competition3 = new List<string> { "Python", "HTML" };
    competitions.Add(competition1);
    competitions.Add(competition2);
    competitions.Add(competition3);
    List<int> results = new List<int> { 0, 0, 1 };
    string expected = "Python";
    var actual = new Program().TournamentWinner(competitions, results);
    Utils.AssertTrue(expected == actual);
  }
}
 
10 / 10 test cases passed.

Test Case 1 passed!
Expected Output
Python
Your Code's Output
Python
View Outputs Side By Side
Input(s)
{
  "competitions": [
    ["HTML", "C#"],
    ["C#", "Python"],
    ["Python", "HTML"]
  ],
  "results": [0, 0, 1]
}
Test Case 2 passed!
Expected Output
Java
Your Code's Output
Java
View Outputs Side By Side
Input(s)
{
  "competitions": [
    ["HTML", "Java"],
    ["Java", "Python"],
    ["Python", "HTML"]
  ],
  "results": [0, 1, 1]
}
Test Case 3 passed!
Expected Output
C#
Your Code's Output
C#
View Outputs Side By Side
Input(s)
{
  "competitions": [
    ["HTML", "Java"],
    ["Java", "Python"],
    ["Python", "HTML"],
    ["C#", "Python"],
    ["Java", "C#"],
    ["C#", "HTML"]
  ],
  "results": [0, 1, 1, 1, 0, 1]
}
Test Case 4 passed!
Expected Output
C#
Your Code's Output
C#
View Outputs Side By Side
Input(s)
{
  "competitions": [
    ["HTML", "Java"],
    ["Java", "Python"],
    ["Python", "HTML"],
    ["C#", "Python"],
    ["Java", "C#"],
    ["C#", "HTML"],
    ["SQL", "C#"],
    ["HTML", "SQL"],
    ["SQL", "Python"],
    ["SQL", "Java"]
  ],
  "results": [0, 1, 1, 1, 0, 1, 0, 1, 1, 0]
}
Test Case 5 passed!
Expected Output
Bulls
Your Code's Output
Bulls
View Outputs Side By Side
Input(s)
{
  "competitions": [
    ["Bulls", "Eagles"]
  ],
  "results": [1]
}
Test Case 6 passed!
Expected Output
Eagles
Your Code's Output
Eagles
View Outputs Side By Side
Input(s)
{
  "competitions": [
    ["Bulls", "Eagles"],
    ["Bulls", "Bears"],
    ["Bears", "Eagles"]
  ],
  "results": [0, 0, 0]
}
Test Case 7 passed!
Expected Output
Bulls
Your Code's Output
Bulls
View Outputs Side By Side
Input(s)
{
  "competitions": [
    ["Bulls", "Eagles"],
    ["Bulls", "Bears"],
    ["Bulls", "Monkeys"],
    ["Eagles", "Bears"],
    ["Eagles", "Monkeys"],
    ["Bears", "Monkeys"]
  ],
  "results": [1, 1, 1, 1, 1, 1]
}
Test Case 8 passed!
Expected Output
AlgoMasters
Your Code's Output
AlgoMasters
View Outputs Side By Side
Input(s)
{
  "competitions": [
    ["AlgoMasters", "FrontPage Freebirds"],
    ["Runtime Terror", "Static Startup"],
    ["WeC#", "Hypertext Assassins"],
    ["AlgoMasters", "WeC#"],
    ["Static Startup", "Hypertext Assassins"],
    ["Runtime Terror", "FrontPage Freebirds"],
    ["AlgoMasters", "Runtime Terror"],
    ["Hypertext Assassins", "FrontPage Freebirds"],
    ["Static Startup", "WeC#"],
    ["AlgoMasters", "Static Startup"],
    ["FrontPage Freebirds", "WeC#"],
    ["Hypertext Assassins", "Runtime Terror"],
    ["AlgoMasters", "Hypertext Assassins"],
    ["WeC#", "Runtime Terror"],
    ["FrontPage Freebirds", "Static Startup"]
  ],
  "results": [1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0]
}
Test Case 9 passed!
Expected Output
SQL
Your Code's Output
SQL
View Outputs Side By Side
Input(s)
{
  "competitions": [
    ["HTML", "Java"],
    ["Java", "Python"],
    ["Python", "HTML"],
    ["C#", "Python"],
    ["Java", "C#"],
    ["C#", "HTML"],
    ["SQL", "C#"],
    ["HTML", "SQL"],
    ["SQL", "Python"],
    ["SQL", "Java"]
  ],
  "results": [0, 0, 0, 0, 0, 0, 1, 0, 1, 1]
}
Test Case 10 passed!
Expected Output
B
Your Code's Output
B
View Outputs Side By Side
Input(s)
{
  "competitions": [
    ["A", "B"]
  ],
  "results": [0]
}

 */
/*
 Test Case 1
{
  "competitions": [
    ["HTML", "C#"],
    ["C#", "Python"],
    ["Python", "HTML"]
  ],
  "results": [0, 0, 1]
}
Test Case 2
{
  "competitions": [
    ["HTML", "Java"],
    ["Java", "Python"],
    ["Python", "HTML"]
  ],
  "results": [0, 1, 1]
}
Test Case 3
{
  "competitions": [
    ["HTML", "Java"],
    ["Java", "Python"],
    ["Python", "HTML"],
    ["C#", "Python"],
    ["Java", "C#"],
    ["C#", "HTML"]
  ],
  "results": [0, 1, 1, 1, 0, 1]
}
Test Case 4
{
  "competitions": [
    ["HTML", "Java"],
    ["Java", "Python"],
    ["Python", "HTML"],
    ["C#", "Python"],
    ["Java", "C#"],
    ["C#", "HTML"],
    ["SQL", "C#"],
    ["HTML", "SQL"],
    ["SQL", "Python"],
    ["SQL", "Java"]
  ],
  "results": [0, 1, 1, 1, 0, 1, 0, 1, 1, 0]
}
Test Case 5
{
  "competitions": [
    ["Bulls", "Eagles"]
  ],
  "results": [1]
}
Test Case 6
{
  "competitions": [
    ["Bulls", "Eagles"],
    ["Bulls", "Bears"],
    ["Bears", "Eagles"]
  ],
  "results": [0, 0, 0]
}
Test Case 7
{
  "competitions": [
    ["Bulls", "Eagles"],
    ["Bulls", "Bears"],
    ["Bulls", "Monkeys"],
    ["Eagles", "Bears"],
    ["Eagles", "Monkeys"],
    ["Bears", "Monkeys"]
  ],
  "results": [1, 1, 1, 1, 1, 1]
}
Test Case 8
{
  "competitions": [
    ["AlgoMasters", "FrontPage Freebirds"],
    ["Runtime Terror", "Static Startup"],
    ["WeC#", "Hypertext Assassins"],
    ["AlgoMasters", "WeC#"],
    ["Static Startup", "Hypertext Assassins"],
    ["Runtime Terror", "FrontPage Freebirds"],
    ["AlgoMasters", "Runtime Terror"],
    ["Hypertext Assassins", "FrontPage Freebirds"],
    ["Static Startup", "WeC#"],
    ["AlgoMasters", "Static Startup"],
    ["FrontPage Freebirds", "WeC#"],
    ["Hypertext Assassins", "Runtime Terror"],
    ["AlgoMasters", "Hypertext Assassins"],
    ["WeC#", "Runtime Terror"],
    ["FrontPage Freebirds", "Static Startup"]
  ],
  "results": [1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0]
}
Test Case 9
{
  "competitions": [
    ["HTML", "Java"],
    ["Java", "Python"],
    ["Python", "HTML"],
    ["C#", "Python"],
    ["Java", "C#"],
    ["C#", "HTML"],
    ["SQL", "C#"],
    ["HTML", "SQL"],
    ["SQL", "Python"],
    ["SQL", "Java"]
  ],
  "results": [0, 0, 0, 0, 0, 0, 1, 0, 1, 1]
}
Test Case 10
{
  "competitions": [
    ["A", "B"]
  ],
  "results": [0]
}
 */