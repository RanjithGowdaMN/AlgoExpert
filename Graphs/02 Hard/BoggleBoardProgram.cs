using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs._02_Hard
{
    class BoggleBoardProgram
    {
        public static List<string> BoggleBoard(char[,] board, string[] words)
        {
            // Write your code here.
            Trie trie = new Trie();
            foreach (string word in words)
            {
                trie.Add(word);
            }
            HashSet<string> finalWords = new HashSet<string>();
            bool[,] visited = new bool[board.GetLength(0), board.GetLength(1)];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    explore(i, j, board, trie.root, visited, finalWords);
                }
            }
            List<string> finalWordsArray = new List<string>();
            foreach (string key in finalWords)
            {
                finalWordsArray.Add(key);
            }
            return finalWordsArray;
        }
        public static void explore(
            int i,
            int j,
            char[,] board,
            TrieNode trieNode,
            bool[,] visited,
            HashSet<string> finalWords
        )
        {
            if (visited[i, j])
            {
                return;
            }
            char letter = board[i, j];
            if (!trieNode.children.ContainsKey(letter))
            {
                return;
            }
            visited[i, j] = true;
            trieNode = trieNode.children[letter];
            if (trieNode.children.ContainsKey('*'))
            {
                finalWords.Add(trieNode.word);
            }
            List<int[]> neighbors = getNeighbors(i, j, board);
            foreach (int[] neighbor in neighbors)
            {
                explore(neighbor[0], neighbor[1], board, trieNode, visited, finalWords);
            }
            visited[i, j] = false;
        }

        public static List<int[]> getNeighbors(
            int i, int j, char[,] board
        )
        {
            List<int[]> neighbors = new List<int[]>();
            if (i > 0 && j > 0)
            {
                neighbors.Add(new int[] { i - 1, j - 1 });
            }
            if (i > 0 && j < board.GetLength(1) - 1)
            {
                neighbors.Add(new int[] { i - 1, j + 1 });
            }
            if (i < board.GetLength(0) - 1 && j < board.GetLength(1) - 1)
            {
                neighbors.Add(new int[] { i + 1, j + 1 });
            }
            if (i < board.GetLength(0) - 1 && j > 0)
            {
                neighbors.Add(new int[] { i + 1, j - 1 });
            }
            if (i > 0)
            {
                neighbors.Add(new int[] { i - 1, j });
            }
            if (i < board.GetLength(0) - 1)
            {
                neighbors.Add(new int[] { i + 1, j });
            }
            if (j > 0)
            {
                neighbors.Add(new int[] { i, j - 1 });
            }
            if (j < board.GetLength(1) - 1)
            {
                neighbors.Add(new int[] { i, j + 1 });
            }
            return neighbors;
        }
        public class TrieNode
        {
            public Dictionary<char, TrieNode> children =
                new Dictionary<char, TrieNode>();
            public string word = "";
        }

        public class Trie
        {
            public TrieNode root;
            public char endSymbol;

            public Trie()
            {
                this.root = new TrieNode();
                this.endSymbol = '*';
            }

            public void Add(string str)
            {
                TrieNode node = this.root;
                for (int i = 0; i < str.Length; i++)
                {
                    char letter = str[i];
                    if (!node.children.ContainsKey(letter))
                    {
                        TrieNode newNode = new TrieNode();
                        node.children.Add(letter, newNode);
                    }
                    node = node.children[letter];
                }
                node.children[this.endSymbol] = null;
                node.word = str;
            }
        }
    }
}
/*
 using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    char[,] board = {
      { 't', 'h', 'i', 's', 'i', 's', 'a' },
      { 's', 'i', 'm', 'p', 'l', 'e', 'x' },
      { 'b', 'x', 'x', 'x', 'x', 'e', 'b' },
      { 'x', 'o', 'g', 'g', 'l', 'x', 'o' },
      { 'x', 'x', 'x', 'D', 'T', 'r', 'a' },
      { 'R', 'E', 'P', 'E', 'A', 'd', 'x' },
      { 'x', 'x', 'x', 'x', 'x', 'x', 'x' },
      { 'N', 'O', 'T', 'R', 'E', '-', 'P' },
      { 'x', 'x', 'D', 'E', 'T', 'A', 'E' },
    };
    string[] words = {
      "this",
      "is",
      "not",
      "a",
      "simple",
      "boggle",
      "board",
      "test",
      "REPEATED",
      "NOTRE-PEATED"
    };
    string[] expected = {
      "this", "is", "a", "simple", "boggle", "board", "NOTRE-PEATED"
    };
    List<string> actual = Program.BoggleBoard(board, words);
    Utils.AssertTrue(actual.Count == expected.Length);
    foreach (string word in actual) {
      Utils.AssertTrue(Contains(expected, word));
    }
  }

  public static bool Contains(string[] wordArray, string targetWord) {
    foreach (string word in wordArray) {
      if (targetWord.Equals(word)) {
        return true;
      }
    }
    return false;
  }
}


8 / 8 test cases passed.

Test Case 1 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["NOTRE-PEATED", "a", "board", "boggle", "is", "simple", "this"]
Your Code's Output
["this", "is", "simple", "a", "boggle", "board", "NOTRE-PEATED"]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["t", "h", "i", "s", "i", "s", "a"],
    ["s", "i", "m", "p", "l", "e", "x"],
    ["b", "x", "x", "x", "x", "e", "b"],
    ["x", "o", "g", "g", "l", "x", "o"],
    ["x", "x", "x", "D", "T", "r", "a"],
    ["R", "E", "P", "E", "A", "d", "x"],
    ["x", "x", "x", "x", "x", "x", "x"],
    ["N", "O", "T", "R", "E", "-", "P"],
    ["x", "x", "D", "E", "T", "A", "E"]
  ],
  "words": ["this", "is", "not", "a", "simple", "boggle", "board", "test", "REPEATED", "NOTRE-PEATED"]
}
Test Case 2 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["at", "danger", "help", "san", "yours"]
Your Code's Output
["yours", "help", "danger", "san", "at"]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["y", "g", "f", "y", "e", "i"],
    ["c", "o", "r", "p", "o", "u"],
    ["j", "u", "z", "s", "e", "l"],
    ["s", "y", "u", "r", "h", "p"],
    ["e", "a", "e", "g", "n", "d"],
    ["h", "e", "l", "s", "a", "t"]
  ],
  "words": ["san", "sana", "at", "vomit", "yours", "help", "end", "been", "bed", "danger", "calm", "ok", "chaos", "complete", "rear", "going", "storm", "face", "epual", "dangerous"]
}
Test Case 3 passed!
Expected Output
["agmsy", "agmsytojed", "agmsytojedinhcbfl"]
Your Code's Output
["agmsy", "agmsytojed", "agmsytojedinhcbfl"]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["a", "b", "c", "d", "e"],
    ["f", "g", "h", "i", "j"],
    ["k", "l", "m", "n", "o"],
    ["p", "q", "r", "s", "t"],
    ["u", "v", "w", "x", "y"]
  ],
  "words": ["agmsy", "agmsytojed", "agmsytojedinhcbgl", "agmsytojedinhcbfl"]
}
Test Case 4 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["abcd", "abdc", "acbd", "acdb", "adbc", "adcb"]
Your Code's Output
["adbc", "adcb", "acbd", "acdb", "abcd", "abdc"]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["a", "b"],
    ["c", "d"]
  ],
  "words": ["abcd", "abdc", "acbd", "acdb", "adbc", "adcb", "abca"]
}
Test Case 5 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["before", "frozen", "kappa", "obligate", "rope", "rotten", "teleport"]
Your Code's Output
["frozen", "rope", "kappa", "before", "obligate", "rotten", "teleport"]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["f", "t", "r", "o", "p", "i", "k", "b", "o"],
    ["r", "w", "l", "p", "e", "u", "e", "a", "b"],
    ["j", "o", "t", "s", "e", "l", "f", "l", "p"],
    ["s", "z", "u", "t", "h", "u", "o", "p", "i"],
    ["k", "a", "e", "g", "n", "d", "r", "g", "a"],
    ["h", "n", "l", "s", "a", "t", "e", "t", "x"]
  ],
  "words": ["frozen", "rotten", "teleport", "city", "zutgatz", "kappa", "before", "rope", "obligate", "annoying"]
}
Test Case 6 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["complicated", "foobar", "twisted", "zigzag"]
Your Code's Output
["complicated", "foobar", "zigzag", "twisted"]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["c", "o", "m"],
    ["r", "p", "l"],
    ["c", "i", "t"],
    ["o", "a", "e"],
    ["f", "o", "d"],
    ["z", "r", "b"],
    ["g", "i", "a"],
    ["o", "a", "g"],
    ["f", "s", "z"],
    ["t", "e", "i"],
    ["t", "w", "d"]
  ],
  "words": ["commerce", "complicated", "twisted", "zigzag", "comma", "foobar", "baz", "there"]
}
Test Case 7 passed!
This test case passed even though your code's output is different from the expected output. This means that this test case has at least 2 different acceptable answers.

Expected Output
["big", "cr", "fs", "iao", "ml", "oc", "twt", "zrb"]
Your Code's Output
["cr", "oc", "ml", "iao", "zrb", "big", "fs", "twt"]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["c", "o", "m"],
    ["r", "p", "l"],
    ["c", "i", "t"],
    ["o", "a", "e"],
    ["f", "o", "d"],
    ["z", "r", "b"],
    ["g", "i", "a"],
    ["o", "a", "g"],
    ["f", "s", "z"],
    ["t", "e", "i"],
    ["t", "w", "d"]
  ],
  "words": ["cr", "oc", "ml", "iao", "opo", "zrb", "big", "fs", "ogiagao", "dwd", "twt"]
}
Test Case 8 passed!
Expected Output
["comlpriteacoofziraagsizefttw"]
Your Code's Output
["comlpriteacoofziraagsizefttw"]
View Outputs Side By Side
Input(s)
{
  "board": [
    ["c", "o", "m"],
    ["r", "p", "l"],
    ["c", "i", "t"],
    ["o", "a", "e"],
    ["f", "o", "d"],
    ["z", "r", "b"],
    ["g", "i", "a"],
    ["o", "a", "g"],
    ["f", "s", "z"],
    ["t", "e", "i"],
    ["t", "w", "d"]
  ],
  "words": ["comlpriteacoofziraagsizefttw", "comlpriteacoofzirabagsizefottw", "comlpriteacoofziraagsizefottw", "comlpriteacoofzirabagsizeftttw"]
}
 
 
 */