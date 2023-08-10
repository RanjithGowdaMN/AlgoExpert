using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreadyAlgorithm._01_Medium
{
    public static class TaskAssignmentProgram
    {
        public static List<List<int>> TaskAssignment(int k, List<int> tasks)
        {
            // Write your code here.
            List<List<int>> pairedTasks = new List<List<int>>();
            Dictionary<int, List<int>> taskDurationToIndices =
                getTaskDurationsToIndices(tasks);
            List<int> sortedTasks = tasks;
            sortedTasks.Sort();

            for (int idx = 0; idx < k; idx++)
            {
                int task1Duration = sortedTasks[idx];
                List<int> indicesWithTask1Duration = taskDurationToIndices[task1Duration];
                int task1Index = indicesWithTask1Duration[indicesWithTask1Duration.Count - 1];
                indicesWithTask1Duration.RemoveAt(indicesWithTask1Duration.Count - 1);

                int task2SortedIndex = tasks.Count - 1 - idx;
                int task2Duration = sortedTasks[task2SortedIndex];
                List<int> indicesWithTask2Duration = taskDurationToIndices[task2Duration];
                int task2Index = indicesWithTask2Duration[indicesWithTask2Duration.Count - 1];
                indicesWithTask2Duration.RemoveAt(indicesWithTask2Duration.Count - 1);

                List<int> pairedTask = new List<int>();
                pairedTask.Add(task1Index);
                pairedTask.Add(task2Index);
                pairedTasks.Add(pairedTask);

            }
            return pairedTasks;
        }


        public static Dictionary<int, List<int>> getTaskDurationsToIndices(List<int> tasks)
        {
            Dictionary<int, List<int>> taskDurationToIndices = new Dictionary<int, List<int>>();

            for (int idx = 0; idx < tasks.Count; idx++)
            {
                int taskDuration = tasks[idx];
                if (taskDurationToIndices.ContainsKey(taskDuration))
                {
                    taskDurationToIndices[taskDuration].Add(idx);
                }
                else
                {
                    List<int> temp = new List<int>();
                    temp.Add(idx);
                    taskDurationToIndices[taskDuration] = temp;
                }
            }
            return taskDurationToIndices;
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
    var k = 3;
    var tasks = new List<int> { 1, 3, 5, 3, 1, 4 };
    var expected = new List<List<int> >();
    List<int> subarr = new List<int> { 4, 2 };
    List<int> subarr2 = new List<int> { 0, 5 };
    List<int> subarr3 = new List<int> { 3, 1 };
    expected.Add(subarr);
    expected.Add(subarr2);
    expected.Add(subarr3);
    var actual = new Program().TaskAssignment(k, tasks);
    for (var i = 0; i < expected.Count; i++) {
      Utils.AssertTrue(Enumerable.SequenceEqual(expected[i], actual[i]));
    }
  }
}


 12 / 12 test cases passed.

Test Case 1 passed!
Expected Output
[
  [4, 2],
  [0, 5],
  [3, 1]
]
Your Code's Output
[
  [4, 2],
  [0, 5],
  [3, 1]
]
View Outputs Side By Side
Input(s)
{
  "k": 3,
  "tasks": [1, 3, 5, 3, 1, 4]
}
Test Case 2 passed!
Expected Output
[
  [0, 7],
  [1, 6],
  [2, 5],
  [3, 4]
]
Your Code's Output
[
  [0, 7],
  [1, 6],
  [2, 5],
  [3, 4]
]
View Outputs Side By Side
Input(s)
{
  "k": 4,
  "tasks": [1, 2, 3, 4, 5, 6, 7, 8]
}
Test Case 3 passed!
Expected Output
[
  [9, 8],
  [7, 6],
  [5, 4],
  [3, 2],
  [1, 0]
]
Your Code's Output
[
  [9, 8],
  [7, 6],
  [5, 4],
  [3, 2],
  [1, 0]
]
View Outputs Side By Side
Input(s)
{
  "k": 5,
  "tasks": [1, 1, 1, 1, 1, 1, 1, 1, 1, 1]
}
Test Case 4 passed!
Expected Output
[
  [0, 1]
]
Your Code's Output
[
  [0, 1]
]
View Outputs Side By Side
Input(s)
{
  "k": 1,
  "tasks": [3, 5]
}
Test Case 5 passed!
Expected Output
[
  [1, 12],
  [0, 5],
  [2, 6],
  [3, 8],
  [4, 9],
  [10, 7],
  [11, 13]
]
Your Code's Output
[
  [1, 12],
  [0, 5],
  [2, 6],
  [3, 8],
  [4, 9],
  [10, 7],
  [11, 13]
]
View Outputs Side By Side
Input(s)
{
  "k": 7,
  "tasks": [2, 1, 3, 4, 5, 13, 12, 9, 11, 10, 6, 7, 14, 8]
}
Test Case 6 passed!
Expected Output
[
  [9, 7],
  [8, 1],
  [5, 6],
  [0, 2],
  [4, 3]
]
Your Code's Output
[
  [9, 7],
  [8, 1],
  [5, 6],
  [0, 2],
  [4, 3]
]
View Outputs Side By Side
Input(s)
{
  "k": 5,
  "tasks": [3, 7, 5, 4, 4, 3, 6, 8, 3, 3]
}
Test Case 7 passed!
Expected Output
[
  [15, 17],
  [19, 13],
  [8, 16],
  [2, 7],
  [12, 6],
  [11, 5],
  [3, 4],
  [0, 14],
  [1, 10],
  [18, 9]
]
Your Code's Output
[
  [15, 17],
  [19, 13],
  [8, 16],
  [2, 7],
  [12, 6],
  [11, 5],
  [3, 4],
  [0, 14],
  [1, 10],
  [18, 9]
]
View Outputs Side By Side
Input(s)
{
  "k": 10,
  "tasks": [5, 6, 2, 3, 15, 15, 16, 19, 2, 10, 10, 3, 3, 32, 12, 1, 23, 32, 9, 2]
}
Test Case 8 passed!
Expected Output
[
  [3, 7],
  [0, 6],
  [2, 5],
  [1, 4]
]
Your Code's Output
[
  [3, 7],
  [0, 6],
  [2, 5],
  [1, 4]
]
View Outputs Side By Side
Input(s)
{
  "k": 4,
  "tasks": [1, 2, 2, 1, 3, 4, 4, 4]
}
Test Case 9 passed!
Expected Output
[
  [4, 5],
  [3, 0],
  [2, 1]
]
Your Code's Output
[
  [4, 5],
  [3, 0],
  [2, 1]
]
View Outputs Side By Side
Input(s)
{
  "k": 3,
  "tasks": [87, 65, 43, 32, 31, 320]
}
Test Case 10 passed!
Expected Output
[
  [3, 2],
  [0, 1]
]
Your Code's Output
[
  [3, 2],
  [0, 1]
]
View Outputs Side By Side
Input(s)
{
  "k": 2,
  "tasks": [3, 4, 5, 3]
}
Test Case 11 passed!
Expected Output
[
  [2, 3],
  [1, 0],
  [5, 4]
]
Your Code's Output
[
  [2, 3],
  [1, 0],
  [5, 4]
]
View Outputs Side By Side
Input(s)
{
  "k": 3,
  "tasks": [5, 2, 1, 6, 4, 4]
}
Test Case 12 passed!
Expected Output
[
  [0, 3],
  [1, 2]
]
Your Code's Output
[
  [0, 3],
  [1, 2]
]
View Outputs Side By Side
Input(s)
{
  "k": 2,
  "tasks": [1, 8, 9, 10]
}
 */
