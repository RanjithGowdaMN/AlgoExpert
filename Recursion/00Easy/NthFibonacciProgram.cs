using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion._00Easy
{
    class NthFibonacciProgram
    {
        public static void Main()
        {
            //Do Nothing
        }

        public static int GetNthFibSol1(int n)
        {
            // Write your code here.
            if (n == 0)
            { return 0; }
            int[] fib = new int[2] { 0, 1 };
            int count = 3;
            while (count <= n)
            {
                int newFib = fib[0] + fib[1];
                fib[0] = fib[1];
                fib[1] = newFib;
                count++;
            }

            return n > 1 ? fib[1] : fib[0];
        }

        public static int GetNthFibSol2(int n)
        {
            // Write your code here.

            Dictionary<int, int> mem = new Dictionary<int, int>();
            mem.Add(1, 0);
            mem.Add(2, 1);
            return getFib(n, mem);

        }

        public static int getFib(int n, Dictionary<int, int> mem)
        {
            if (mem.ContainsKey(n))
            {
                return mem[n];
            }
            else
            {
                mem.Add(n, getFib(n - 1, mem) + getFib(n - 2, mem));
                return mem[n];
            }
        }
    }

}

/*
 public class ProgramTest {
  [Test]
  public void TestCase1() {
    Utils.AssertEquals(5, Program.GetNthFib(6));
  }
}
 18 / 18 test cases passed.

Test Case 1 passed!
Expected Output
5
Your Code's Output
5
View Outputs Side By Side
Input(s)
{
  "n": 6
}
Test Case 2 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "n": 1
}
Test Case 3 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "n": 2
}
Test Case 4 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "n": 3
}
Test Case 5 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "n": 4
}
Test Case 6 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "n": 5
}
Test Case 7 passed!
Expected Output
8
Your Code's Output
8
View Outputs Side By Side
Input(s)
{
  "n": 7
}
Test Case 8 passed!
Expected Output
13
Your Code's Output
13
View Outputs Side By Side
Input(s)
{
  "n": 8
}
Test Case 9 passed!
Expected Output
21
Your Code's Output
21
View Outputs Side By Side
Input(s)
{
  "n": 9
}
Test Case 10 passed!
Expected Output
34
Your Code's Output
34
View Outputs Side By Side
Input(s)
{
  "n": 10
}
Test Case 11 passed!
Expected Output
55
Your Code's Output
55
View Outputs Side By Side
Input(s)
{
  "n": 11
}
Test Case 12 passed!
Test Case 13 passed!
Expected Output
144
Your Code's Output
144
View Outputs Side By Side
Input(s)
{
  "n": 13
}
Test Case 14 passed!
Expected Output
233
Your Code's Output
233
View Outputs Side By Side
Input(s)
{
  "n": 14
}
Test Case 15 passed!
Test Case 16 passed!
Expected Output
610
Your Code's Output
610
View Outputs Side By Side
Input(s)
{
  "n": 16
}
Test Case 17 passed!
Expected Output
987
Your Code's Output
987
View Outputs Side By Side
Input(s)
{
  "n": 17
}
Test Case 18 passed!
Expected Output
1597
Your Code's Output
1597
View Outputs Side By Side
Input(s)
{
  "n": 18
}
 */