using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs._01_Medium
{
    class GetYoungestCommonAncestorProgram
    {
        public static AncestralTree GetYoungestCommonAncestor(
  AncestralTree topAncestor,
  AncestralTree descendantOne,
  AncestralTree descendantTwo
)
        {
            // Write your code here.
            int depthOne = getDescendantDepth(descendantOne, topAncestor);
            int depthTwo = getDescendantDepth(descendantTwo, topAncestor);
            if (depthOne > depthTwo)
            {
                return backtrackAncestralTree(
                    descendantOne, descendantTwo, depthOne - depthTwo
                );
            }
            else
            {
                return backtrackAncestralTree(descendantTwo, descendantOne, depthTwo - depthOne);
            }
        }

        public static int getDescendantDepth(
            AncestralTree descendant, AncestralTree topAncestor
        )
        {
            int depth = 0;
            while (descendant != topAncestor)
            {
                depth++;
                descendant = descendant.ancestor;
            }
            return depth;
        }
        public static AncestralTree backtrackAncestralTree(
            AncestralTree lowerDescendant, AncestralTree higherDescendant, int diff
        )
        {
            while (diff > 0)
            {
                lowerDescendant = lowerDescendant.ancestor;
                diff--;
            }
            while (lowerDescendant != higherDescendant)
            {
                lowerDescendant = lowerDescendant.ancestor;
                higherDescendant = higherDescendant.ancestor;
            }
            return lowerDescendant;
        }

        public class AncestralTree
        {
            public char name;
            public AncestralTree ancestor;

            public AncestralTree(char name)
            {
                this.name = name;
                this.ancestor = null;
            }

            // This method is for testing only.
            public void AddAsAncestor(AncestralTree[] descendants)
            {
                foreach (AncestralTree descendant in descendants)
                {
                    descendant.ancestor = this;
                }
            }
        }
    }
}
/*
 * 
 * using System.Collections.Generic;

public class ProgramTest {
  public Dictionary<char, Program.AncestralTree> getNewTrees() {
    var trees = new Dictionary<char, Program.AncestralTree>();
    var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    foreach (char a in alphabet) {
      trees.Add(a, new Program.AncestralTree(a));
    }

    trees['A'].AddAsAncestor(new Program.AncestralTree[] {
      trees['B'], trees['C'], trees['D'], trees['E'], trees['F']
    });
    return trees;
  }

  [Test]
  public void TestCase1() {
    var trees = getNewTrees();
    trees['A'].AddAsAncestor(
      new Program.AncestralTree[] { trees['B'], trees['C'] }
    );
    trees['B'].AddAsAncestor(
      new Program.AncestralTree[] { trees['D'], trees['E'] }
    );
    trees['D'].AddAsAncestor(
      new Program.AncestralTree[] { trees['H'], trees['I'] }
    );
    trees['C'].AddAsAncestor(
      new Program.AncestralTree[] { trees['F'], trees['G'] }
    );

    Program.AncestralTree yca =
      Program.GetYoungestCommonAncestor(trees['A'], trees['E'], trees['I']);
    Utils.AssertTrue(yca == trees['B']);
  }
}

14 / 14 test cases passed.

Test Case 1 passed!
Expected Output
{
  "nodeId": "B"
}
Your Code's Output
{
  "nodeId": "B"
}
View Outputs Side By Side
Input(s)
{
  "ancestralTree": {
    "nodes": [
      {"ancestor": null, "id": "A", "name": "A"},
      {"ancestor": "A", "id": "B", "name": "B"},
      {"ancestor": "A", "id": "C", "name": "C"},
      {"ancestor": "B", "id": "D", "name": "D"},
      {"ancestor": "B", "id": "E", "name": "E"},
      {"ancestor": "C", "id": "F", "name": "F"},
      {"ancestor": "C", "id": "G", "name": "G"},
      {"ancestor": "D", "id": "H", "name": "H"},
      {"ancestor": "D", "id": "I", "name": "I"}
    ]
  },
  "descendantOne": "E",
  "descendantTwo": "I",
  "topAncestor": "A"
}
Test Case 2 passed!
Expected Output
{
  "nodeId": "A"
}
Your Code's Output
{
  "nodeId": "A"
}
View Outputs Side By Side
Input(s)
{
  "ancestralTree": {
    "nodes": [
      {"ancestor": null, "id": "A", "name": "A"},
      {"ancestor": "A", "id": "B", "name": "B"},
      {"ancestor": "A", "id": "C", "name": "C"},
      {"ancestor": "A", "id": "D", "name": "D"},
      {"ancestor": "A", "id": "E", "name": "E"},
      {"ancestor": "A", "id": "F", "name": "F"},
      {"ancestor": "B", "id": "G", "name": "G"},
      {"ancestor": "B", "id": "H", "name": "H"},
      {"ancestor": "B", "id": "I", "name": "I"},
      {"ancestor": "C", "id": "J", "name": "J"},
      {"ancestor": "D", "id": "K", "name": "K"},
      {"ancestor": "D", "id": "L", "name": "L"},
      {"ancestor": "F", "id": "M", "name": "M"},
      {"ancestor": "F", "id": "N", "name": "N"},
      {"ancestor": "H", "id": "O", "name": "O"},
      {"ancestor": "H", "id": "P", "name": "P"},
      {"ancestor": "H", "id": "Q", "name": "Q"},
      {"ancestor": "H", "id": "R", "name": "R"},
      {"ancestor": "K", "id": "S", "name": "S"},
      {"ancestor": "P", "id": "T", "name": "T"},
      {"ancestor": "P", "id": "U", "name": "U"},
      {"ancestor": "R", "id": "V", "name": "V"},
      {"ancestor": "V", "id": "W", "name": "W"},
      {"ancestor": "V", "id": "X", "name": "X"},
      {"ancestor": "V", "id": "Y", "name": "Y"},
      {"ancestor": "X", "id": "Z", "name": "Z"}
    ]
  },
  "descendantOne": "A",
  "descendantTwo": "B",
  "topAncestor": "A"
}
Test Case 3 passed!
Expected Output
{
  "nodeId": "A"
}
Your Code's Output
{
  "nodeId": "A"
}
View Outputs Side By Side
Input(s)
{
  "ancestralTree": {
    "nodes": [
      {"ancestor": null, "id": "A", "name": "A"},
      {"ancestor": "A", "id": "B", "name": "B"},
      {"ancestor": "A", "id": "C", "name": "C"},
      {"ancestor": "A", "id": "D", "name": "D"},
      {"ancestor": "A", "id": "E", "name": "E"},
      {"ancestor": "A", "id": "F", "name": "F"},
      {"ancestor": "B", "id": "G", "name": "G"},
      {"ancestor": "B", "id": "H", "name": "H"},
      {"ancestor": "B", "id": "I", "name": "I"},
      {"ancestor": "C", "id": "J", "name": "J"},
      {"ancestor": "D", "id": "K", "name": "K"},
      {"ancestor": "D", "id": "L", "name": "L"},
      {"ancestor": "F", "id": "M", "name": "M"},
      {"ancestor": "F", "id": "N", "name": "N"},
      {"ancestor": "H", "id": "O", "name": "O"},
      {"ancestor": "H", "id": "P", "name": "P"},
      {"ancestor": "H", "id": "Q", "name": "Q"},
      {"ancestor": "H", "id": "R", "name": "R"},
      {"ancestor": "K", "id": "S", "name": "S"},
      {"ancestor": "P", "id": "T", "name": "T"},
      {"ancestor": "P", "id": "U", "name": "U"},
      {"ancestor": "R", "id": "V", "name": "V"},
      {"ancestor": "V", "id": "W", "name": "W"},
      {"ancestor": "V", "id": "X", "name": "X"},
      {"ancestor": "V", "id": "Y", "name": "Y"},
      {"ancestor": "X", "id": "Z", "name": "Z"}
    ]
  },
  "descendantOne": "B",
  "descendantTwo": "F",
  "topAncestor": "A"
}
Test Case 4 passed!
Expected Output
{
  "nodeId": "A"
}
Your Code's Output
{
  "nodeId": "A"
}
View Outputs Side By Side
Input(s)
{
  "ancestralTree": {
    "nodes": [
      {"ancestor": null, "id": "A", "name": "A"},
      {"ancestor": "A", "id": "B", "name": "B"},
      {"ancestor": "A", "id": "C", "name": "C"},
      {"ancestor": "A", "id": "D", "name": "D"},
      {"ancestor": "A", "id": "E", "name": "E"},
      {"ancestor": "A", "id": "F", "name": "F"},
      {"ancestor": "B", "id": "G", "name": "G"},
      {"ancestor": "B", "id": "H", "name": "H"},
      {"ancestor": "B", "id": "I", "name": "I"},
      {"ancestor": "C", "id": "J", "name": "J"},
      {"ancestor": "D", "id": "K", "name": "K"},
      {"ancestor": "D", "id": "L", "name": "L"},
      {"ancestor": "F", "id": "M", "name": "M"},
      {"ancestor": "F", "id": "N", "name": "N"},
      {"ancestor": "H", "id": "O", "name": "O"},
      {"ancestor": "H", "id": "P", "name": "P"},
      {"ancestor": "H", "id": "Q", "name": "Q"},
      {"ancestor": "H", "id": "R", "name": "R"},
      {"ancestor": "K", "id": "S", "name": "S"},
      {"ancestor": "P", "id": "T", "name": "T"},
      {"ancestor": "P", "id": "U", "name": "U"},
      {"ancestor": "R", "id": "V", "name": "V"},
      {"ancestor": "V", "id": "W", "name": "W"},
      {"ancestor": "V", "id": "X", "name": "X"},
      {"ancestor": "V", "id": "Y", "name": "Y"},
      {"ancestor": "X", "id": "Z", "name": "Z"}
    ]
  },
  "descendantOne": "G",
  "descendantTwo": "M",
  "topAncestor": "A"
}
Test Case 5 passed!
Expected Output
{
  "nodeId": "A"
}
Your Code's Output
{
  "nodeId": "A"
}
View Outputs Side By Side
Input(s)
{
  "ancestralTree": {
    "nodes": [
      {"ancestor": null, "id": "A", "name": "A"},
      {"ancestor": "A", "id": "B", "name": "B"},
      {"ancestor": "A", "id": "C", "name": "C"},
      {"ancestor": "A", "id": "D", "name": "D"},
      {"ancestor": "A", "id": "E", "name": "E"},
      {"ancestor": "A", "id": "F", "name": "F"},
      {"ancestor": "B", "id": "G", "name": "G"},
      {"ancestor": "B", "id": "H", "name": "H"},
      {"ancestor": "B", "id": "I", "name": "I"},
      {"ancestor": "C", "id": "J", "name": "J"},
      {"ancestor": "D", "id": "K", "name": "K"},
      {"ancestor": "D", "id": "L", "name": "L"},
      {"ancestor": "F", "id": "M", "name": "M"},
      {"ancestor": "F", "id": "N", "name": "N"},
      {"ancestor": "H", "id": "O", "name": "O"},
      {"ancestor": "H", "id": "P", "name": "P"},
      {"ancestor": "H", "id": "Q", "name": "Q"},
      {"ancestor": "H", "id": "R", "name": "R"},
      {"ancestor": "K", "id": "S", "name": "S"},
      {"ancestor": "P", "id": "T", "name": "T"},
      {"ancestor": "P", "id": "U", "name": "U"},
      {"ancestor": "R", "id": "V", "name": "V"},
      {"ancestor": "V", "id": "W", "name": "W"},
      {"ancestor": "V", "id": "X", "name": "X"},
      {"ancestor": "V", "id": "Y", "name": "Y"},
      {"ancestor": "X", "id": "Z", "name": "Z"}
    ]
  },
  "descendantOne": "U",
  "descendantTwo": "S",
  "topAncestor": "A"
}
Test Case 6 passed!
Expected Output
{
  "nodeId": "A"
}
Your Code's Output
{
  "nodeId": "A"
}
View Outputs Side By Side
Input(s)
{
  "ancestralTree": {
    "nodes": [
      {"ancestor": null, "id": "A", "name": "A"},
      {"ancestor": "A", "id": "B", "name": "B"},
      {"ancestor": "A", "id": "C", "name": "C"},
      {"ancestor": "A", "id": "D", "name": "D"},
      {"ancestor": "A", "id": "E", "name": "E"},
      {"ancestor": "A", "id": "F", "name": "F"},
      {"ancestor": "B", "id": "G", "name": "G"},
      {"ancestor": "B", "id": "H", "name": "H"},
      {"ancestor": "B", "id": "I", "name": "I"},
      {"ancestor": "C", "id": "J", "name": "J"},
      {"ancestor": "D", "id": "K", "name": "K"},
      {"ancestor": "D", "id": "L", "name": "L"},
      {"ancestor": "F", "id": "M", "name": "M"},
      {"ancestor": "F", "id": "N", "name": "N"},
      {"ancestor": "H", "id": "O", "name": "O"},
      {"ancestor": "H", "id": "P", "name": "P"},
      {"ancestor": "H", "id": "Q", "name": "Q"},
      {"ancestor": "H", "id": "R", "name": "R"},
      {"ancestor": "K", "id": "S", "name": "S"},
      {"ancestor": "P", "id": "T", "name": "T"},
      {"ancestor": "P", "id": "U", "name": "U"},
      {"ancestor": "R", "id": "V", "name": "V"},
      {"ancestor": "V", "id": "W", "name": "W"},
      {"ancestor": "V", "id": "X", "name": "X"},
      {"ancestor": "V", "id": "Y", "name": "Y"},
      {"ancestor": "X", "id": "Z", "name": "Z"}
    ]
  },
  "descendantOne": "Z",
  "descendantTwo": "M",
  "topAncestor": "A"
}
Test Case 7 passed!
Expected Output
{
  "nodeId": "B"
}
Your Code's Output
{
  "nodeId": "B"
}
View Outputs Side By Side
Input(s)
{
  "ancestralTree": {
    "nodes": [
      {"ancestor": null, "id": "A", "name": "A"},
      {"ancestor": "A", "id": "B", "name": "B"},
      {"ancestor": "A", "id": "C", "name": "C"},
      {"ancestor": "A", "id": "D", "name": "D"},
      {"ancestor": "A", "id": "E", "name": "E"},
      {"ancestor": "A", "id": "F", "name": "F"},
      {"ancestor": "B", "id": "G", "name": "G"},
      {"ancestor": "B", "id": "H", "name": "H"},
      {"ancestor": "B", "id": "I", "name": "I"},
      {"ancestor": "C", "id": "J", "name": "J"},
      {"ancestor": "D", "id": "K", "name": "K"},
      {"ancestor": "D", "id": "L", "name": "L"},
      {"ancestor": "F", "id": "M", "name": "M"},
      {"ancestor": "F", "id": "N", "name": "N"},
      {"ancestor": "H", "id": "O", "name": "O"},
      {"ancestor": "H", "id": "P", "name": "P"},
      {"ancestor": "H", "id": "Q", "name": "Q"},
      {"ancestor": "H", "id": "R", "name": "R"},
      {"ancestor": "K", "id": "S", "name": "S"},
      {"ancestor": "P", "id": "T", "name": "T"},
      {"ancestor": "P", "id": "U", "name": "U"},
      {"ancestor": "R", "id": "V", "name": "V"},
      {"ancestor": "V", "id": "W", "name": "W"},
      {"ancestor": "V", "id": "X", "name": "X"},
      {"ancestor": "V", "id": "Y", "name": "Y"},
      {"ancestor": "X", "id": "Z", "name": "Z"}
    ]
  },
  "descendantOne": "O",
  "descendantTwo": "I",
  "topAncestor": "A"
}
Test Case 8 passed!
Expected Output
{
  "nodeId": "H"
}
Your Code's Output
{
  "nodeId": "H"
}
View Outputs Side By Side
Input(s)
{
  "ancestralTree": {
    "nodes": [
      {"ancestor": null, "id": "A", "name": "A"},
      {"ancestor": "A", "id": "B", "name": "B"},
      {"ancestor": "A", "id": "C", "name": "C"},
      {"ancestor": "A", "id": "D", "name": "D"},
      {"ancestor": "A", "id": "E", "name": "E"},
      {"ancestor": "A", "id": "F", "name": "F"},
      {"ancestor": "B", "id": "G", "name": "G"},
      {"ancestor": "B", "id": "H", "name": "H"},
      {"ancestor": "B", "id": "I", "name": "I"},
      {"ancestor": "C", "id": "J", "name": "J"},
      {"ancestor": "D", "id": "K", "name": "K"},
      {"ancestor": "D", "id": "L", "name": "L"},
      {"ancestor": "F", "id": "M", "name": "M"},
      {"ancestor": "F", "id": "N", "name": "N"},
      {"ancestor": "H", "id": "O", "name": "O"},
      {"ancestor": "H", "id": "P", "name": "P"},
      {"ancestor": "H", "id": "Q", "name": "Q"},
      {"ancestor": "H", "id": "R", "name": "R"},
      {"ancestor": "K", "id": "S", "name": "S"},
      {"ancestor": "P", "id": "T", "name": "T"},
      {"ancestor": "P", "id": "U", "name": "U"},
      {"ancestor": "R", "id": "V", "name": "V"},
      {"ancestor": "V", "id": "W", "name": "W"},
      {"ancestor": "V", "id": "X", "name": "X"},
      {"ancestor": "V", "id": "Y", "name": "Y"},
      {"ancestor": "X", "id": "Z", "name": "Z"}
    ]
  },
  "descendantOne": "T",
  "descendantTwo": "Z",
  "topAncestor": "A"
}
Test Case 9 passed!
Expected Output
{
  "nodeId": "H"
}
Your Code's Output
{
  "nodeId": "H"
}
View Outputs Side By Side
Input(s)
{
  "ancestralTree": {
    "nodes": [
      {"ancestor": null, "id": "A", "name": "A"},
      {"ancestor": "A", "id": "B", "name": "B"},
      {"ancestor": "A", "id": "C", "name": "C"},
      {"ancestor": "A", "id": "D", "name": "D"},
      {"ancestor": "A", "id": "E", "name": "E"},
      {"ancestor": "A", "id": "F", "name": "F"},
      {"ancestor": "B", "id": "G", "name": "G"},
      {"ancestor": "B", "id": "H", "name": "H"},
      {"ancestor": "B", "id": "I", "name": "I"},
      {"ancestor": "C", "id": "J", "name": "J"},
      {"ancestor": "D", "id": "K", "name": "K"},
      {"ancestor": "D", "id": "L", "name": "L"},
      {"ancestor": "F", "id": "M", "name": "M"},
      {"ancestor": "F", "id": "N", "name": "N"},
      {"ancestor": "H", "id": "O", "name": "O"},
      {"ancestor": "H", "id": "P", "name": "P"},
      {"ancestor": "H", "id": "Q", "name": "Q"},
      {"ancestor": "H", "id": "R", "name": "R"},
      {"ancestor": "K", "id": "S", "name": "S"},
      {"ancestor": "P", "id": "T", "name": "T"},
      {"ancestor": "P", "id": "U", "name": "U"},
      {"ancestor": "R", "id": "V", "name": "V"},
      {"ancestor": "V", "id": "W", "name": "W"},
      {"ancestor": "V", "id": "X", "name": "X"},
      {"ancestor": "V", "id": "Y", "name": "Y"},
      {"ancestor": "X", "id": "Z", "name": "Z"}
    ]
  },
  "descendantOne": "T",
  "descendantTwo": "V",
  "topAncestor": "A"
}
Test Case 10 passed!
Expected Output
{
  "nodeId": "H"
}
Your Code's Output
{
  "nodeId": "H"
}
View Outputs Side By Side
Input(s)
{
  "ancestralTree": {
    "nodes": [
      {"ancestor": null, "id": "A", "name": "A"},
      {"ancestor": "A", "id": "B", "name": "B"},
      {"ancestor": "A", "id": "C", "name": "C"},
      {"ancestor": "A", "id": "D", "name": "D"},
      {"ancestor": "A", "id": "E", "name": "E"},
      {"ancestor": "A", "id": "F", "name": "F"},
      {"ancestor": "B", "id": "G", "name": "G"},
      {"ancestor": "B", "id": "H", "name": "H"},
      {"ancestor": "B", "id": "I", "name": "I"},
      {"ancestor": "C", "id": "J", "name": "J"},
      {"ancestor": "D", "id": "K", "name": "K"},
      {"ancestor": "D", "id": "L", "name": "L"},
      {"ancestor": "F", "id": "M", "name": "M"},
      {"ancestor": "F", "id": "N", "name": "N"},
      {"ancestor": "H", "id": "O", "name": "O"},
      {"ancestor": "H", "id": "P", "name": "P"},
      {"ancestor": "H", "id": "Q", "name": "Q"},
      {"ancestor": "H", "id": "R", "name": "R"},
      {"ancestor": "K", "id": "S", "name": "S"},
      {"ancestor": "P", "id": "T", "name": "T"},
      {"ancestor": "P", "id": "U", "name": "U"},
      {"ancestor": "R", "id": "V", "name": "V"},
      {"ancestor": "V", "id": "W", "name": "W"},
      {"ancestor": "V", "id": "X", "name": "X"},
      {"ancestor": "V", "id": "Y", "name": "Y"},
      {"ancestor": "X", "id": "Z", "name": "Z"}
    ]
  },
  "descendantOne": "T",
  "descendantTwo": "H",
  "topAncestor": "A"
}
Test Case 11 passed!
Expected Output
{
  "nodeId": "V"
}
Your Code's Output
{
  "nodeId": "V"
}
View Outputs Side By Side
Input(s)
{
  "ancestralTree": {
    "nodes": [
      {"ancestor": null, "id": "A", "name": "A"},
      {"ancestor": "A", "id": "B", "name": "B"},
      {"ancestor": "A", "id": "C", "name": "C"},
      {"ancestor": "A", "id": "D", "name": "D"},
      {"ancestor": "A", "id": "E", "name": "E"},
      {"ancestor": "A", "id": "F", "name": "F"},
      {"ancestor": "B", "id": "G", "name": "G"},
      {"ancestor": "B", "id": "H", "name": "H"},
      {"ancestor": "B", "id": "I", "name": "I"},
      {"ancestor": "C", "id": "J", "name": "J"},
      {"ancestor": "D", "id": "K", "name": "K"},
      {"ancestor": "D", "id": "L", "name": "L"},
      {"ancestor": "F", "id": "M", "name": "M"},
      {"ancestor": "F", "id": "N", "name": "N"},
      {"ancestor": "H", "id": "O", "name": "O"},
      {"ancestor": "H", "id": "P", "name": "P"},
      {"ancestor": "H", "id": "Q", "name": "Q"},
      {"ancestor": "H", "id": "R", "name": "R"},
      {"ancestor": "K", "id": "S", "name": "S"},
      {"ancestor": "P", "id": "T", "name": "T"},
      {"ancestor": "P", "id": "U", "name": "U"},
      {"ancestor": "R", "id": "V", "name": "V"},
      {"ancestor": "V", "id": "W", "name": "W"},
      {"ancestor": "V", "id": "X", "name": "X"},
      {"ancestor": "V", "id": "Y", "name": "Y"},
      {"ancestor": "X", "id": "Z", "name": "Z"}
    ]
  },
  "descendantOne": "W",
  "descendantTwo": "V",
  "topAncestor": "A"
}
Test Case 12 passed!
Expected Output
{
  "nodeId": "B"
}
Your Code's Output
{
  "nodeId": "B"
}
View Outputs Side By Side
Input(s)
{
  "ancestralTree": {
    "nodes": [
      {"ancestor": null, "id": "A", "name": "A"},
      {"ancestor": "A", "id": "B", "name": "B"},
      {"ancestor": "A", "id": "C", "name": "C"},
      {"ancestor": "A", "id": "D", "name": "D"},
      {"ancestor": "A", "id": "E", "name": "E"},
      {"ancestor": "A", "id": "F", "name": "F"},
      {"ancestor": "B", "id": "G", "name": "G"},
      {"ancestor": "B", "id": "H", "name": "H"},
      {"ancestor": "B", "id": "I", "name": "I"},
      {"ancestor": "C", "id": "J", "name": "J"},
      {"ancestor": "D", "id": "K", "name": "K"},
      {"ancestor": "D", "id": "L", "name": "L"},
      {"ancestor": "F", "id": "M", "name": "M"},
      {"ancestor": "F", "id": "N", "name": "N"},
      {"ancestor": "H", "id": "O", "name": "O"},
      {"ancestor": "H", "id": "P", "name": "P"},
      {"ancestor": "H", "id": "Q", "name": "Q"},
      {"ancestor": "H", "id": "R", "name": "R"},
      {"ancestor": "K", "id": "S", "name": "S"},
      {"ancestor": "P", "id": "T", "name": "T"},
      {"ancestor": "P", "id": "U", "name": "U"},
      {"ancestor": "R", "id": "V", "name": "V"},
      {"ancestor": "V", "id": "W", "name": "W"},
      {"ancestor": "V", "id": "X", "name": "X"},
      {"ancestor": "V", "id": "Y", "name": "Y"},
      {"ancestor": "X", "id": "Z", "name": "Z"}
    ]
  },
  "descendantOne": "Z",
  "descendantTwo": "B",
  "topAncestor": "A"
}
Test Case 13 passed!
Expected Output
{
  "nodeId": "H"
}
Your Code's Output
{
  "nodeId": "H"
}
View Outputs Side By Side
Input(s)
{
  "ancestralTree": {
    "nodes": [
      {"ancestor": null, "id": "A", "name": "A"},
      {"ancestor": "A", "id": "B", "name": "B"},
      {"ancestor": "A", "id": "C", "name": "C"},
      {"ancestor": "A", "id": "D", "name": "D"},
      {"ancestor": "A", "id": "E", "name": "E"},
      {"ancestor": "A", "id": "F", "name": "F"},
      {"ancestor": "B", "id": "G", "name": "G"},
      {"ancestor": "B", "id": "H", "name": "H"},
      {"ancestor": "B", "id": "I", "name": "I"},
      {"ancestor": "C", "id": "J", "name": "J"},
      {"ancestor": "D", "id": "K", "name": "K"},
      {"ancestor": "D", "id": "L", "name": "L"},
      {"ancestor": "F", "id": "M", "name": "M"},
      {"ancestor": "F", "id": "N", "name": "N"},
      {"ancestor": "H", "id": "O", "name": "O"},
      {"ancestor": "H", "id": "P", "name": "P"},
      {"ancestor": "H", "id": "Q", "name": "Q"},
      {"ancestor": "H", "id": "R", "name": "R"},
      {"ancestor": "K", "id": "S", "name": "S"},
      {"ancestor": "P", "id": "T", "name": "T"},
      {"ancestor": "P", "id": "U", "name": "U"},
      {"ancestor": "R", "id": "V", "name": "V"},
      {"ancestor": "V", "id": "W", "name": "W"},
      {"ancestor": "V", "id": "X", "name": "X"},
      {"ancestor": "V", "id": "Y", "name": "Y"},
      {"ancestor": "X", "id": "Z", "name": "Z"}
    ]
  },
  "descendantOne": "Q",
  "descendantTwo": "W",
  "topAncestor": "A"
}
Test Case 14 passed!
Expected Output
{
  "nodeId": "A"
}
Your Code's Output
{
  "nodeId": "A"
}
View Outputs Side By Side
Input(s)
{
  "ancestralTree": {
    "nodes": [
      {"ancestor": null, "id": "A", "name": "A"},
      {"ancestor": "A", "id": "B", "name": "B"},
      {"ancestor": "A", "id": "C", "name": "C"},
      {"ancestor": "A", "id": "D", "name": "D"},
      {"ancestor": "A", "id": "E", "name": "E"},
      {"ancestor": "A", "id": "F", "name": "F"},
      {"ancestor": "B", "id": "G", "name": "G"},
      {"ancestor": "B", "id": "H", "name": "H"},
      {"ancestor": "B", "id": "I", "name": "I"},
      {"ancestor": "C", "id": "J", "name": "J"},
      {"ancestor": "D", "id": "K", "name": "K"},
      {"ancestor": "D", "id": "L", "name": "L"},
      {"ancestor": "F", "id": "M", "name": "M"},
      {"ancestor": "F", "id": "N", "name": "N"},
      {"ancestor": "H", "id": "O", "name": "O"},
      {"ancestor": "H", "id": "P", "name": "P"},
      {"ancestor": "H", "id": "Q", "name": "Q"},
      {"ancestor": "H", "id": "R", "name": "R"},
      {"ancestor": "K", "id": "S", "name": "S"},
      {"ancestor": "P", "id": "T", "name": "T"},
      {"ancestor": "P", "id": "U", "name": "U"},
      {"ancestor": "R", "id": "V", "name": "V"},
      {"ancestor": "V", "id": "W", "name": "W"},
      {"ancestor": "V", "id": "X", "name": "X"},
      {"ancestor": "V", "id": "Y", "name": "Y"},
      {"ancestor": "X", "id": "Z", "name": "Z"}
    ]
  },
  "descendantOne": "A",
  "descendantTwo": "Z",
  "topAncestor": "A"
}

 __________________________________________________________________________________________


__________________________________________________________________________________________
 
__________________________________________________________________________________________
 */