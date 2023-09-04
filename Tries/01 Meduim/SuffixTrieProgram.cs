using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tries._01_Meduim
{
    class SuffixTrieProgram
    {
        public static void Main()
        {
            //Do Nothing
        }

        // Do not edit the class below except for the
        // PopulateSuffixTrieFrom and Contains methods.
        // Feel free to add new properties and methods
        // to the class.
        public class TrieNode
        {
            public Dictionary<char, TrieNode> Children =
              new Dictionary<char, TrieNode>();
        }

        public class SuffixTrie
        {
            public TrieNode root = new TrieNode();
            public char endSymbol = '*';

            public SuffixTrie(string str)
            {
                PopulateSuffixTrieFrom(str);
            }

            public void PopulateSuffixTrieFrom(string str)
            {
                //O(n^2) time | O(n^2) space
                for (int i = 0; i < str.Length; i++)
                {
                    insertSubstringStartingAt(i, str);
                }
            }

            public void insertSubstringStartingAt(int i, string str)
            {
                TrieNode node = root;
                for (int j = i; j < str.Length; j++)
                {
                    char letter = str[j];
                    if (!node.Children.ContainsKey(letter))
                    {
                        TrieNode newNode = new TrieNode();
                        node.Children.Add(letter, newNode);
                    }
                    node = node.Children[letter];
                }
                node.Children[endSymbol] = null;
            }

            public bool Contains(string str)
            {
                // Write your code here.
                TrieNode node = root;
                for (int i = 0; i < str.Length; i++)
                {
                    char letter = str[i];
                    if (!node.Children.ContainsKey(letter))
                    {
                        return false;
                    }
                    node = node.Children[letter];
                }
                return node.Children.ContainsKey(endSymbol);
            }
        }
    }
}
/*
 using System.Linq;
using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Program.SuffixTrie trie = new Program.SuffixTrie("babc");
    Utils.AssertTrue(trie.Contains("abc"));
  }
}

6 / 6 test cases passed.

Test Case 1 passed!
Expected Output
{
  "methodCallResults": [
    {
      "arguments": ["abc"],
      "method": "contains",
      "output": true
    }
  ],
  "trie": {
    "a": {
      "b": {
        "c": {
          "*": true
        }
      }
    },
    "b": {
      "a": {
        "b": {
          "c": {
            "*": true
          }
        }
      },
      "c": {
        "*": true
      }
    },
    "c": {
      "*": true
    }
  }
}
Your Code's Output
{
  "methodCallResults": [
    {
      "arguments": ["abc"],
      "method": "contains",
      "output": true
    }
  ],
  "trie": {
    "a": {
      "b": {
        "c": {
          "*": true
        }
      }
    },
    "b": {
      "a": {
        "b": {
          "c": {
            "*": true
          }
        }
      },
      "c": {
        "*": true
      }
    },
    "c": {
      "*": true
    }
  }
}
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["abc"],
      "method": "contains"
    }
  ],
  "string": "babc"
}
Test Case 2 passed!
Expected Output
{
  "methodCallResults": [
    {
      "arguments": ["t"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["st"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["est"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["test"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["tes"],
      "method": "contains",
      "output": false
    }
  ],
  "trie": {
    "e": {
      "s": {
        "t": {
          "*": true
        }
      }
    },
    "s": {
      "t": {
        "*": true
      }
    },
    "t": {
      "*": true,
      "e": {
        "s": {
          "t": {
            "*": true
          }
        }
      }
    }
  }
}
Your Code's Output
{
  "methodCallResults": [
    {
      "arguments": ["t"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["st"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["est"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["test"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["tes"],
      "method": "contains",
      "output": false
    }
  ],
  "trie": {
    "e": {
      "s": {
        "t": {
          "*": true
        }
      }
    },
    "s": {
      "t": {
        "*": true
      }
    },
    "t": {
      "*": true,
      "e": {
        "s": {
          "t": {
            "*": true
          }
        }
      }
    }
  }
}
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["t"],
      "method": "contains"
    },
    {
      "arguments": ["st"],
      "method": "contains"
    },
    {
      "arguments": ["est"],
      "method": "contains"
    },
    {
      "arguments": ["test"],
      "method": "contains"
    },
    {
      "arguments": ["tes"],
      "method": "contains"
    }
  ],
  "string": "test"
}
Test Case 3 passed!
Expected Output
{
  "methodCallResults": [
    {
      "arguments": ["e"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["le"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["ble"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["ible"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["sible"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["isible"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["visible"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["nvisible"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["invisible"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["nvisibl"],
      "method": "contains",
      "output": false
    }
  ],
  "trie": {
    "b": {
      "l": {
        "e... 
Your Code's Output
{
  "methodCallResults": [
    {
      "arguments": ["e"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["le"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["ble"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["ible"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["sible"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["isible"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["visible"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["nvisible"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["invisible"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["nvisibl"],
      "method": "contains",
      "output": false
    }
  ],
  "trie": {
    "b": {
      "l": {
        "e... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["e"],
      "method": "contains"
    },
    {
      "arguments": ["le"],
      "method": "contains"
    },
    {
      "arguments": ["ble"],
      "method": "contains"
    },
    {
      "arguments": ["ible"],
      "method": "contains"
    },
    {
      "arguments": ["sible"],
      "method": "contains"
    },
    {
      "arguments": ["isible"],
      "method": "contains"
    },
    {
      "arguments": ["visible"],
      "method": "contains"
    },
    {
      "arguments": ["nvisible"],
      "method": "contains"
    },
    {
      "arguments": ["invisible"],
      "method": "contains"
    },
    {
      "arguments": ["nvisibl"],
      "method": "contains"
    }
  ],
  "string": "invisible"
}
Test Case 4 passed!
Expected Output
{
  "methodCallResults": [
    {
      "arguments": ["9"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["89"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["789"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["6789"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["56789"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["456789"],
      "method": "contains",
      "output": false
    },
    {
      "arguments": ["3456789"],
      "method": "contains",
      "output": false
    },
    {
      "arguments": ["23456789"],
      "method": "contains",
      "output": false
    },
    {
      "arguments": ["123456789"],
      "method": "contains",
      "output": false
    },
    {
      "arguments": ["45567"],
      "method": "contains",
      "output": false
    }
  ],
  "trie": {
    "1": {
      "2": {
        ... 
Your Code's Output
{
  "methodCallResults": [
    {
      "arguments": ["9"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["89"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["789"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["6789"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["56789"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["456789"],
      "method": "contains",
      "output": false
    },
    {
      "arguments": ["3456789"],
      "method": "contains",
      "output": false
    },
    {
      "arguments": ["23456789"],
      "method": "contains",
      "output": false
    },
    {
      "arguments": ["123456789"],
      "method": "contains",
      "output": false
    },
    {
      "arguments": ["45567"],
      "method": "contains",
      "output": false
    }
  ],
  "trie": {
    "1": {
      "2": {
        ... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["9"],
      "method": "contains"
    },
    {
      "arguments": ["89"],
      "method": "contains"
    },
    {
      "arguments": ["789"],
      "method": "contains"
    },
    {
      "arguments": ["6789"],
      "method": "contains"
    },
    {
      "arguments": ["56789"],
      "method": "contains"
    },
    {
      "arguments": ["456789"],
      "method": "contains"
    },
    {
      "arguments": ["3456789"],
      "method": "contains"
    },
    {
      "arguments": ["23456789"],
      "method": "contains"
    },
    {
      "arguments": ["123456789"],
      "method": "contains"
    },
    {
      "arguments": ["45567"],
      "method": "contains"
    }
  ],
  "string": "1234556789"
}
Test Case 5 passed!
Expected Output
{
  "methodCallResults": [
    {
      "arguments": ["t"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["st"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["est"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["test"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["ttest"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["sttest"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["esttest"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["testtest"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["tt"],
      "method": "contains",
      "output": false
    }
  ],
  "trie": {
    "e": {
      "s": {
        "t": {
          "*": true,
          "t": {
            "e": {
              "s": {
                "t... 
Your Code's Output
{
  "methodCallResults": [
    {
      "arguments": ["t"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["st"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["est"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["test"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["ttest"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["sttest"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["esttest"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["testtest"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["tt"],
      "method": "contains",
      "output": false
    }
  ],
  "trie": {
    "e": {
      "s": {
        "t": {
          "*": true,
          "t": {
            "e": {
              "s": {
                "t... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["t"],
      "method": "contains"
    },
    {
      "arguments": ["st"],
      "method": "contains"
    },
    {
      "arguments": ["est"],
      "method": "contains"
    },
    {
      "arguments": ["test"],
      "method": "contains"
    },
    {
      "arguments": ["ttest"],
      "method": "contains"
    },
    {
      "arguments": ["sttest"],
      "method": "contains"
    },
    {
      "arguments": ["esttest"],
      "method": "contains"
    },
    {
      "arguments": ["testtest"],
      "method": "contains"
    },
    {
      "arguments": ["tt"],
      "method": "contains"
    }
  ],
  "string": "testtest"
}
Test Case 6 passed!
Expected Output
{
  "methodCallResults": [
    {
      "arguments": ["t"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["tt"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["ttt"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["tttt"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["ttttt"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["tttttt"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["ttttttt"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["tttttttt"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["ttttttttt"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["vvv"],
      "method": "contains",
      "output": false
    }
  ],
  "trie": {
    "t": {
      "*": true,
      "t":... 
Your Code's Output
{
  "methodCallResults": [
    {
      "arguments": ["t"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["tt"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["ttt"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["tttt"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["ttttt"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["tttttt"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["ttttttt"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["tttttttt"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["ttttttttt"],
      "method": "contains",
      "output": true
    },
    {
      "arguments": ["vvv"],
      "method": "contains",
      "output": false
    }
  ],
  "trie": {
    "t": {
      "*": true,
      "t":... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["t"],
      "method": "contains"
    },
    {
      "arguments": ["tt"],
      "method": "contains"
    },
    {
      "arguments": ["ttt"],
      "method": "contains"
    },
    {
      "arguments": ["tttt"],
      "method": "contains"
    },
    {
      "arguments": ["ttttt"],
      "method": "contains"
    },
    {
      "arguments": ["tttttt"],
      "method": "contains"
    },
    {
      "arguments": ["ttttttt"],
      "method": "contains"
    },
    {
      "arguments": ["tttttttt"],
      "method": "contains"
    },
    {
      "arguments": ["ttttttttt"],
      "method": "contains"
    },
    {
      "arguments": ["vvv"],
      "method": "contains"
    }
  ],
  "string": "ttttttttt"
}

 
 */