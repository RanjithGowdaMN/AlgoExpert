using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks._02_Hard
{
    public class ShortenPathProgram
    {
        public static string ShortenPath(string path)
        {
            // Write your code here;
            bool startsWithPath = path[0] == '/';
            string[] tokenArr = path.Split("/");
            List<string> tokensList = new List<string>(tokenArr);
            List<string> filteredTokens =
                tokensList.FindAll(token => isImportantToken(token));
            Stack<string> stack = new Stack<string>();
            if (startsWithPath) stack.Push("");
            foreach (string token in filteredTokens)
            {
                if (token.Equals(".."))
                {
                    if (stack.Count == 0 || stack.Peek().Equals(".."))
                    {
                        stack.Push(token);
                    }
                    else if (!stack.Peek().Equals(""))
                    {
                        stack.Pop();
                    }
                }
                else
                {
                    stack.Push(token);
                }
            }

            if (stack.Count == 1 && stack.Peek().Equals("")) return "/";
            var arr = stack.ToArray();
            Array.Reverse(arr);
            return String.Join("/", arr);
        }
        public static bool isImportantToken(string token)
        {
            return token.Length > 0 && !token.Equals(".");
        }
    }
}

/*
 public class ProgramTest {
  [Test]
  public void TestCase1() {
    var expected = "/foo/bar/baz";
    var actual = Program.ShortenPath("/foo/../test/../test/../foo//bar/./baz");
    Utils.AssertEquals(expected, actual);
  }
}


 17 / 17 test cases passed.

Test Case 1 passed!
Expected Output
/foo/bar/baz
Your Code's Output
/foo/bar/baz
View Outputs Side By Side
Input(s)
{
  "path": "/foo/../test/../test/../foo//bar/./baz"
}
Test Case 2 passed!
Expected Output
/foo/bar/baz
Your Code's Output
/foo/bar/baz
View Outputs Side By Side
Input(s)
{
  "path": "/foo/bar/baz"
}
Test Case 3 passed!
Expected Output
foo/bar/baz
Your Code's Output
foo/bar/baz
View Outputs Side By Side
Input(s)
{
  "path": "foo/bar/baz"
}
Test Case 4 passed!
Expected Output
/foo/bar/baz
Your Code's Output
/foo/bar/baz
View Outputs Side By Side
Input(s)
{
  "path": "/../../foo/bar/baz"
}
Test Case 5 passed!
Expected Output
../../foo/bar/baz
Your Code's Output
../../foo/bar/baz
View Outputs Side By Side
Input(s)
{
  "path": "../../foo/bar/baz"
}
Test Case 6 passed!
Expected Output
/bar/baz
Your Code's Output
/bar/baz
View Outputs Side By Side
Input(s)
{
  "path": "/../../foo/../../bar/baz"
}
Test Case 7 passed!
Expected Output
../../../bar/baz
Your Code's Output
../../../bar/baz
View Outputs Side By Side
Input(s)
{
  "path": "../../foo/../../bar/baz"
}
Test Case 8 passed!
Expected Output
/foo/kappa
Your Code's Output
/foo/kappa
View Outputs Side By Side
Input(s)
{
  "path": "/foo/./././bar/./baz///////////test/../../../kappa"
}
Test Case 9 passed!
Expected Output
../../../../../../../..
Your Code's Output
../../../../../../../..
View Outputs Side By Side
Input(s)
{
  "path": "../../../this////one/./../../is/../../going/../../to/be/./././../../../just/eight/double/dots/../../../../../.."
}
Test Case 10 passed!
Expected Output
/
Your Code's Output
/
View Outputs Side By Side
Input(s)
{
  "path": "/../../../this////one/./../../is/../../going/../../to/be/./././../../../just/a/forward/slash/../../../../../.."
}
Test Case 11 passed!
Expected Output
../../../../../../../../foo
Your Code's Output
../../../../../../../../foo
View Outputs Side By Side
Input(s)
{
  "path": "../../../this////one/./../../is/../../going/../../to/be/./././../../../just/eight/double/dots/../../../../../../foo"
}
Test Case 12 passed!
Expected Output
/foo
Your Code's Output
/foo
View Outputs Side By Side
Input(s)
{
  "path": "/../../../this////one/./../../is/../../going/../../to/be/./././../../../just/a/forward/slash/../../../../../../foo"
}
Test Case 13 passed!
Expected Output
foo
Your Code's Output
foo
View Outputs Side By Side
Input(s)
{
  "path": "foo/bar/.."
}
Test Case 14 passed!
Expected Output
foo/bar
Your Code's Output
foo/bar
View Outputs Side By Side
Input(s)
{
  "path": "./foo/bar"
}
Test Case 15 passed!
Expected Output
..
Your Code's Output
..
View Outputs Side By Side
Input(s)
{
  "path": "foo/../.."
}
Test Case 16 passed!
Expected Output
/
Your Code's Output
/
View Outputs Side By Side
Input(s)
{
  "path": "/"
}
Test Case 17 passed!
Expected Output
..
Your Code's Output
..
View Outputs Side By Side
Input(s)
{
  "path": "./.."
}
 */