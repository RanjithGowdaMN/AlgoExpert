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
 
 */