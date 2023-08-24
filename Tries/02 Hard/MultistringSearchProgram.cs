using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tries._02_Hard
{
    class MultistringSearchProgram
    {
        public static List<bool> MultistringSearch(
   string bigstring, string[] smallstrings
 )
        {
            // O(bns) time | O(n) space
            List<bool> solution = new List<bool>();
            foreach (string smallstring in smallstrings)
            {
                solution.Add(isInBigstring(bigstring, smallstring));
            }
            return solution;
        }
        public static bool isInBigstring(string bigstring, string smallstring)
        {
            for (int i = 0; i < bigstring.Length; i++)
            {
                if (i + smallstring.Length > bigstring.Length)
                {
                    break;
                }
                if (isInBigstring(bigstring, smallstring, i))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool isInBigstring(
            string bigstring, string smallstring, int startIdx
        )
        {
            int leftBigIdx = startIdx;
            int rightBigIdx = startIdx + smallstring.Length - 1;
            int leftSmallIdx = 0;
            int rightSmallIdx = smallstring.Length - 1;
            while (leftBigIdx <= rightBigIdx)
            {
                if (bigstring[leftBigIdx] != smallstring[leftSmallIdx] || bigstring[rightBigIdx] != smallstring[rightSmallIdx])
                {
                    return false;
                }
                leftBigIdx++;
                rightBigIdx--;
                leftSmallIdx++;
                rightSmallIdx--;
            }
            return true;
        }
    }
}
/*
_________________________________________________________________________________________

  public static List<bool> MultistringSearch(
    string bigstring, string[] smallstrings
  ) {
    // O(b^2 + ns) time | O(b^2 + n) space
      ModifiedSuffixTrie modifiedSuffixTrie = new ModifiedSuffixTrie(bigstring);
      List<bool> solution = new List<bool>();
      foreach(string smallstring in smallstrings){
          solution.Add(modifiedSuffixTrie.Contains(smallstring));
      }
    return solution;
  }
    public class TrieNode{
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
    }
    public class ModifiedSuffixTrie{
        TrieNode root = new TrieNode();
        public ModifiedSuffixTrie(string str){
            populatedModifiedSuffixTrieFrom(str);
        }

        public void populatedModifiedSuffixTrieFrom(string str){
            for(int i = 0; i < str.Length; i++){
                insertSubstringStartingAt(i, str);
            }
        }
        public void insertSubstringStartingAt(int i, string str){
            TrieNode node = root;
            for(int j = i; j < str.Length; j++){
                char letter = str[j];
                if(!node.children.ContainsKey(letter)){
                    TrieNode newNode = new TrieNode();
                    node.children.Add(letter, newNode);
                }
                node = node.children[letter];
            }
        }
        public bool Contains(string str){
            TrieNode node = root;
            for(int i = 0; i < str.Length; i++){
                char letter = str[i];
                if(!node.children.ContainsKey(letter)){
                    return false;
                }
                node = node.children[letter];
            }
            return true;
        }
    }
_________________________________________________________________________________________

 public static List<bool> MultistringSearch(
    string bigstring, string[] smallstrings
  ) {
    // O(ns + bs) time | O(ns) space
      Trie trie = new Trie();
      foreach(string smallstring in smallstrings){
          trie.insert(smallstring);
      }
      HashSet<string> containedstrings = new HashSet<string>();
      for(int i=0; i < bigstring.Length; i++){
          findSmallstringsIn(bigstring, i, trie, containedstrings);
      }
      List<bool> solution = new List<bool>();
      foreach(string str in smallstrings){
          solution.Add(containedstrings.Contains(str));
      }
    return solution;
  }

public static void findSmallstringsIn(
    string str, int startIdx, Trie trie, HashSet<string> containedstrings
){
    TrieNode currentNode = trie.root;
    for(int i=startIdx; i < str.Length; i++){
        char currentChar = str[i];
        if(!currentNode.children.ContainsKey(currentChar)){
            break;
        }
        currentNode = currentNode.children[currentChar];
        if(currentNode.children.ContainsKey(trie.endSymbol)){
            containedstrings.Add(currentNode.word);
        }
    }
}
    
    public class TrieNode{
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        public string word;
    }
    public class Trie{
        public TrieNode root = new TrieNode();
        public char endSymbol = '*';

        public void insert(string str){
            TrieNode node = root;
            for(int i=0; i< str.Length; i++){
                char letter = str[i];
                if(!node.children.ContainsKey(letter)){
                    TrieNode newNode = new TrieNode();
                    node.children.Add(letter, newNode);
                }
                node = node.children[letter];
            }
            node.children[endSymbol] = null;
            node.word = str;
        }
    }
______________________________________________________________________

using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    bool[] expected = { true, false, true, true, false, true, false };
    List<bool> output = Program.MultistringSearch(
      "this is a big string",
      new string[] { "this", "yo", "is", "a", "bigger", "string", "kappa" }
    );
    Utils.AssertTrue(compare(output, expected));
  }

  public bool compare(List<bool> arr1, bool[] arr2) {
    if (arr1.Count != arr2.Length) {
      return false;
    }
    for (int i = 0; i < arr1.Count; i++) {
      if (arr1[i] != arr2[i]) {
        return false;
      }
    }
    return true;
  }
}


12 / 12 test cases passed.

Test Case 1 passed!
Expected Output
[true, false, true, true, false, true, false]
Your Code's Output
[true, false, true, true, false, true, false]
View Outputs Side By Side
Input(s)
{
  "bigString": "this is a big string",
  "smallStrings": ["this", "yo", "is", "a", "bigger", "string", "kappa"]
}
Test Case 2 passed!
Expected Output
[true, true, false, true, true, false]
Your Code's Output
[true, true, false, true, true, false]
View Outputs Side By Side
Input(s)
{
  "bigString": "abcdefghijklmnopqrstuvwxyz",
  "smallStrings": ["abc", "mnopqr", "wyz", "no", "e", "tuuv"]
}
Test Case 3 passed!
Expected Output
[true, true, true, true, true, false, false]
Your Code's Output
[true, true, true, true, true, false, false]
View Outputs Side By Side
Input(s)
{
  "bigString": "abcdefghijklmnopqrstuvwxyz",
  "smallStrings": ["abcdefghijklmnopqrstuvwxyz", "abc", "j", "mnopqr", "pqrstuvwxyz", "xyzz", "defh"]
}
Test Case 4 passed!
Expected Output
[false, true, true, true, false, false, false]
Your Code's Output
[false, true, true, true, false, false, false]
View Outputs Side By Side
Input(s)
{
  "bigString": "hj!)!%Hj1jh8f1985n!)51",
  "smallStrings": ["%Hj7", "8f198", "!)5", "!)!", "!!", "jh81", "j181hf"]
}
Test Case 5 passed!
Expected Output
[true, true, false, true, true, false, false]
Your Code's Output
[true, true, false, true, true, false, false]
View Outputs Side By Side
Input(s)
{
  "bigString": "Mary goes to the shopping center every week.",
  "smallStrings": ["to", "Mary", "centers", "shop", "shopping", "string", "kappa"]
}
Test Case 6 passed!
Expected Output
[false, false, false, false, true, false, false]
Your Code's Output
[false, false, false, false, true, false, false]
View Outputs Side By Side
Input(s)
{
  "bigString": "adcb akfkw afnmc fkadn vkaca jdaf dacb cdba cbda",
  "smallStrings": ["abcd", "acbd", "adbc", "dabc", "cbda", "cabd", "cdab"]
}
Test Case 7 passed!
Expected Output
[true, false, false, false, true, true]
Your Code's Output
[true, false, false, false, true, true]
View Outputs Side By Side
Input(s)
{
  "bigString": "test testing testings tests testers test-takers",
  "smallStrings": ["tests", "testatk", "testiing", "trsatii", "test-taker", "test"]
}
Test Case 8 passed!
Expected Output
[false, false, false, false, false, false, true]
Your Code's Output
[false, false, false, false, false, false, true]
View Outputs Side By Side
Input(s)
{
  "bigString": "ndbajwhfawkjljkfaopwdlaawjk dawkj awjkawkfjhkawk ahjwkjad jadfljawd",
  "smallStrings": ["abc", "akwbc", "awbc", "abafac", "ajjfbc", "abac", "jadfl"]
}
Test Case 9 passed!
Expected Output
[false, true, false, false, false, false, false, true, true]
Your Code's Output
[false, true, false, false, false, false, false, true, true]
View Outputs Side By Side
Input(s)
{
  "bigString": "Is this particular test going to pass or is it going to fail? That is the question.",
  "smallStrings": ["that", "the", "questions", "goes", "mountain", "passes", "passed", "going", "is"]
}
Test Case 10 passed!
Expected Output
[false, false, false, false, false, false]
Your Code's Output
[false, false, false, false, false, false]
View Outputs Side By Side
Input(s)
{
  "bigString": "Everything in this test should fail.",
  "smallStrings": ["everything", "inn", "that", "testers", "shall", "failure"]
}
Test Case 11 passed!
Expected Output
[true, true, false, true, false]
Your Code's Output
[true, true, false, true, false]
View Outputs Side By Side
Input(s)
{
  "bigString": "this ain't a big string",
  "smallStrings": ["this", "is", "yo", "a", "bigger"]
}
Test Case 12 passed!
Expected Output
[true]
Your Code's Output
[true]
View Outputs Side By Side
Input(s)
{
  "bigString": "bbbabb",
  "smallStrings": ["bbabb"]
}

 */