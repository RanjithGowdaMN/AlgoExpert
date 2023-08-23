using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs._01_Medium
{
    class BreadthFirstSearchProgram
    {
        public class Node
        {
            public string name;
            public List<Node> children = new List<Node>();

            public Node(string name)
            {
                this.name = name;
            }

            public List<string> BreadthFirstSearch(List<string> array)
            {
                // O(v+e) time | O(v) space
                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(this);
                while (queue.Count > 0)
                {
                    Node current = queue.Dequeue();
                    array.Add(current.name);
                    current.children.ForEach(o => queue.Enqueue(o));
                }
                return array;
            }

            public Node AddChild(string name)
            {
                Node child = new Node(name);
                children.Add(child);
                return this;
            }
        }
    }
}
/*
 
 using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Program.Node graph = new Program.Node("A");
    graph.AddChild("B").AddChild("C").AddChild("D");
    graph.children[0].AddChild("E").AddChild("F");
    graph.children[2].AddChild("G").AddChild("H");
    graph.children[0].children[1].AddChild("I").AddChild("J");
    graph.children[2].children[0].AddChild("K");
    string[] expected = {
      "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K"
    };
    List<string> inputArray = new List<string>();
    Utils.AssertTrue(compare(graph.BreadthFirstSearch(inputArray), expected));
  }

  public static bool compare(List<string> arr1, string[] arr2) {
    if (arr1.Count != arr2.Length) {
      return false;
    }
    for (int i = 0; i < arr1.Count; i++) {
      if (!arr1[i].Equals(arr2[i])) {
        return false;
      }
    }
    return true;
  }
}

5 / 5 test cases passed.

Test Case 1 passed!
Expected Output
["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K"]
Your Code's Output
["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K"]
View Outputs Side By Side
Input(s)
{
  "graph": {
    "nodes": [
      {"children": ["B", "C", "D"], "id": "A", "value": "A"},
      {"children": ["E", "F"], "id": "B", "value": "B"},
      {"children": [], "id": "C", "value": "C"},
      {"children": ["G", "H"], "id": "D", "value": "D"},
      {"children": [], "id": "E", "value": "E"},
      {"children": ["I", "J"], "id": "F", "value": "F"},
      {"children": ["K"], "id": "G", "value": "G"},
      {"children": [], "id": "H", "value": "H"},
      {"children": [], "id": "I", "value": "I"},
      {"children": [], "id": "J", "value": "J"},
      {"children": [], "id": "K", "value": "K"}
    ],
    "startNode": "A"
  }
}
Test Case 2 passed!
Expected Output
["A", "B", "C", "D"]
Your Code's Output
["A", "B", "C", "D"]
View Outputs Side By Side
Input(s)
{
  "graph": {
    "nodes": [
      {"children": ["B", "C"], "id": "A", "value": "A"},
      {"children": ["D"], "id": "B", "value": "B"},
      {"children": [], "id": "C", "value": "C"},
      {"children": [], "id": "D", "value": "D"}
    ],
    "startNode": "A"
  }
}
Test Case 3 passed!
Expected Output
["A", "B", "C", "D", "E", "F"]
Your Code's Output
["A", "B", "C", "D", "E", "F"]
View Outputs Side By Side
Input(s)
{
  "graph": {
    "nodes": [
      {"children": ["B", "C", "D", "E"], "id": "A", "value": "A"},
      {"children": [], "id": "B", "value": "B"},
      {"children": ["F"], "id": "C", "value": "C"},
      {"children": [], "id": "D", "value": "D"},
      {"children": [], "id": "E", "value": "E"},
      {"children": [], "id": "F", "value": "F"}
    ],
    "startNode": "A"
  }
}
Test Case 4 passed!
Expected Output
["A", "B", "C", "D", "E", "F"]
Your Code's Output
["A", "B", "C", "D", "E", "F"]
View Outputs Side By Side
Input(s)
{
  "graph": {
    "nodes": [
      {"children": ["B"], "id": "A", "value": "A"},
      {"children": ["C"], "id": "B", "value": "B"},
      {"children": ["D", "E"], "id": "C", "value": "C"},
      {"children": ["F"], "id": "D", "value": "D"},
      {"children": [], "id": "E", "value": "E"},
      {"children": [], "id": "F", "value": "F"}
    ],
    "startNode": "A"
  }
}
Test Case 5 passed!
Expected Output
["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"]
Your Code's Output
["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"]
View Outputs Side By Side
Input(s)
{
  "graph": {
    "nodes": [
      {"children": ["B", "C", "D", "E", "F"], "id": "A", "value": "A"},
      {"children": ["G", "H", "I"], "id": "B", "value": "B"},
      {"children": ["J"], "id": "C", "value": "C"},
      {"children": ["K", "L"], "id": "D", "value": "D"},
      {"children": [], "id": "E", "value": "E"},
      {"children": ["M", "N"], "id": "F", "value": "F"},
      {"children": [], "id": "G", "value": "G"},
      {"children": ["O", "P", "Q", "R"], "id": "H", "value": "H"},
      {"children": [], "id": "I", "value": "I"},
      {"children": [], "id": "J", "value": "J"},
      {"children": ["S"], "id": "K", "value": "K"},
      {"children": [], "id": "L", "value": "L"},
      {"children": [], "id": "M", "value": "M"},
      {"children": [], "id": "N", "value": "N"},
      {"children": [], "id": "O", "value": "O"},
      {"children": ["T", "U"], "id": "P", "value": "P"},
      {"children": [], "id": "Q", "value": "Q"},
      {"children": ["V"], "id": "R", "value": "R"},
      {"children": [], "id": "S", "value": "S"},
      {"children": [], "id": "T", "value": "T"},
      {"children": [], "id": "U", "value": "U"},
      {"children": ["W", "X", "Y"], "id": "V", "value": "V"},
      {"children": [], "id": "W", "value": "W"},
      {"children": ["Z"], "id": "X", "value": "X"},
      {"children": [], "id": "Y", "value": "Y"},
      {"children": [], "id": "Z", "value": "Z"}
    ],
    "startNode": "A"
  }
}

 
 */