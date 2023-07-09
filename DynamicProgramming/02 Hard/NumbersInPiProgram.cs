using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming._02_Hard
{
    class NumbersInPiProgram
    {
        public static int NumbersInPi(string pi, string[] numbers)
        {
            // Write your code here.
            HashSet<string> numbersTable = new HashSet<string>();
            foreach (string number in numbers)
            {
                numbersTable.Add(number);
            }
            Dictionary<int, int> cache = new Dictionary<int, int>();
            int minSpaces = getMinSpaces(pi, numbersTable, cache, 0);
            return minSpaces == Int32.MaxValue ? -1 : minSpaces;
        }

        public static int getMinSpaces(
            string pi,
            HashSet<string> numbersTable,
            Dictionary<int, int> cache,
            int idx)
        {
            if (idx == pi.Length) return -1;
            if (cache.ContainsKey(idx)) return cache[idx];
            int minSpaces = Int32.MaxValue;
            for (int i = idx; i < pi.Length; i++)
            {
                string prefix = pi.Substring(idx, i + 1 - idx);
                if (numbersTable.Contains(prefix))
                {
                    int minSpacesInSuffix =
                        getMinSpaces(pi, numbersTable, cache, i + 1);
                    if (minSpacesInSuffix == Int32.MaxValue)
                    {
                        minSpaces = Math.Min(minSpaces, minSpacesInSuffix);
                    }
                    else
                    {
                        minSpaces = Math.Min(minSpaces, minSpacesInSuffix + 1);
                    }
                }
            }
            cache[idx] = minSpaces;
            return cache[idx];
        }
    }
}

/*
 Test Case 1 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "numbers": ["314159265358979323846", "26433", "8", "3279", "314159265", "35897932384626433832", "79"],
  "pi": "3141592653589793238462643383279"
}
Test Case 2 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "numbers": ["314159265358979323846264338327", "9"],
  "pi": "3141592653589793238462643383279"
}
Test Case 3 passed!
Expected Output
3
Your Code's Output
3
View Outputs Side By Side
Input(s)
{
  "numbers": ["3", "314", "49", "9001", "15926535897", "14", "9323", "8462643383279", "4", "793"],
  "pi": "3141592653589793238462643383279"
}
Test Case 4 passed!
Expected Output
0
Your Code's Output
0
View Outputs Side By Side
Input(s)
{
  "numbers": ["3141592653589793238462643383279"],
  "pi": "3141592653589793238462643383279"
}
Test Case 5 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "numbers": ["3141", "1512", "159", "793", "12412451", "8462643383279"],
  "pi": "3141592653589793238462643383279"
}
Test Case 6 passed!
Expected Output
2
Your Code's Output
2
View Outputs Side By Side
Input(s)
{
  "numbers": ["314159265358979323846", "327", "26433", "8", "3279", "9", "314159265", "35897932384626433832", "79"],
  "pi": "3141592653589793238462643383279"
}
Test Case 7 passed!
Expected Output
1
Your Code's Output
1
View Outputs Side By Side
Input(s)
{
  "numbers": ["141592653589793238462643383279", "314159265358979323846", "327", "26433", "8", "3279", "9", "314159265", "35897932384626433832", "79", "3"],
  "pi": "3141592653589793238462643383279"
}
Test Case 8 passed!
Expected Output
13
Your Code's Output
13
View Outputs Side By Side
Input(s)
{
  "numbers": ["3", "1", "4", "592", "65", "55", "35", "8", "9793", "2384626", "83279"],
  "pi": "3141592653589793238462643383279"
}
Test Case 9 passed!
Expected Output
12
Your Code's Output
12
View Outputs Side By Side
Input(s)
{
  "numbers": ["3", "1", "4", "592", "65", "55", "35", "8", "9793", "2384626", "383279"],
  "pi": "3141592653589793238462643383279"
}
Test Case 10 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "numbers": ["3", "141", "592", "65", "55", "35", "8", "9793", "2384626", "383279"],
  "pi": "3141592653589793238462643383279"
}
Test Case 11 passed!
Expected Output
9
Your Code's Output
9
View Outputs Side By Side
Input(s)
{
  "numbers": ["3", "141", "592", "65", "55", "35", "8", "9793", "23846264", "383279"],
  "pi": "3141592653589793238462643383279"
}
Test Case 12 passed!
Expected Output
-1
Your Code's Output
-1
View Outputs Side By Side
Input(s)
{
  "numbers": ["3", "141", "592", "65", "55", "35", "8", "9793", "23846264", "3832798"],
  "pi": "3141592653589793238462643383279"
}
 */