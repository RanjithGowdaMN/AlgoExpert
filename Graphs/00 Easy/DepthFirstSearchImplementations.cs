using System.Collections.Generic;

namespace Graphs._00_Easy
{
    public static class DepthFirstSearchImplementations
    {
        public static void Main()
        {
            Node Graph = new Node("A");
            Graph.AddChild("B").AddChild("C").AddChild("D");
        }

        public class Node
        {
            public string Name;
            public List<Node> children = new List<Node>();

            public Node(string name)
            { 
                this.Name = name;
            }

            public List<string> DepthFirstSearchImplementation(List<string> array)
            {
                array.Add(this.Name);
                for (int i = 0; i < children.Count; i++)
                {
                    children[i].DepthFirstSearchImplementation(array);
                }
                return array;
            }

            public Node AddChild(string name)
            { 
                Node node = new Node(name);
                children.Add(node);
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
      "A", "B", "E", "F", "I", "J", "C", "D", "G", "K", "H"
    };
    List<string> inputArray = new List<string>();
    Utils.AssertTrue(compare(graph.DepthFirstSearch(inputArray), expected));
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
["A", "B", "E", "F", "I", "J", "C", "D", "G", "K", "H"]
Your Code's Output
["A", "B", "E", "F", "I", "J", "C", "D", "G", "K", "H"]
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
["A", "B", "D", "C"]
Your Code's Output
["A", "B", "D", "C"]
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
["A", "B", "C", "F", "D", "E"]
Your Code's Output
["A", "B", "C", "F", "D", "E"]
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
["A", "B", "C", "D", "F", "E"]
Your Code's Output
["A", "B", "C", "D", "F", "E"]
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
["A", "B", "G", "H", "O", "P", "T", "U", "Q", "R", "V", "W", "X", "Z", "Y", "I", "C", "J", "D", "K", "S", "L", "E", "F", "M", "N"]
Your Code's Output
["A", "B", "G", "H", "O", "P", "T", "U", "Q", "R", "V", "W", "X", "Z", "Y", "I", "C", "J", "D", "K", "S", "L", "E", "F", "M", "N"]
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