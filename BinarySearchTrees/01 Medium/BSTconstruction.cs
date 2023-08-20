using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTrees._01_Medium
{
    internal class BSTconstructionProgram
    {
        public class BST
        {
            public int value;
            public BST left;
            public BST right;

            public BST(int value)
            {
                this.value = value;
            }

            public BST Insert(int value)
            {
                // Write your code here.
                // Do not edit the return statement of this method.
                if (value < this.value)
                {
                    if (left == null)
                    {
                        BST newBST = new BST(value);
                        left = newBST;
                    }
                    else
                    {
                        left.Insert(value);
                    }
                }
                else
                {
                    if (right == null)
                    {
                        BST newBST = new BST(value);
                        right = newBST;
                    }
                    else
                    {
                        right.Insert(value);
                    }
                }
                return this;
            }

            public bool Contains(int value)
            {
                // Write your code here.
                if (value < this.value)
                {
                    if (left == null)
                    {
                        return false;
                    }
                    else
                    {
                        return left.Contains(value);
                    }
                }
                else if (value > this.value)
                {
                    if (right == null)
                    {
                        return false;
                    }
                    else
                    {
                        return right.Contains(value);
                    }
                }
                else
                {
                    return true;
                }
            }



            public BST Remove(int value)
            {
                // Write your code here.
                // Do not edit the return statement of this method.
                Remove(value, null);
                return this;
            }
            public void Remove(int value, BST parent)
            {
                if (value < this.value)
                {
                    if (left != null)
                    {
                        left.Remove(value, this);
                    }
                }
                else if (value > this.value)
                {
                    if (right != null)
                    {
                        right.Remove(value, this);
                    }
                }
                else
                {
                    if (left != null && right != null)
                    {
                        this.value = right.getMinValue();
                        right.Remove(this.value, this);
                    }
                    else if (parent == null)
                    {
                        if (left != null)
                        {
                            this.value = left.value;
                            right = left.right;
                            left = left.left;
                        }
                        else if (right != null)
                        {
                            this.value = right.value;
                            left = right.left;
                            right = right.right;
                        }
                        else
                        {

                        }
                    }
                    else if (parent.left == this)
                    {
                        parent.left = left != null ? left : right;
                    }
                    else if (parent.right == this)
                    {
                        parent.right = left != null ? left : right;
                    }
                }
            }

            public int getMinValue()
            {
                if (left == null)
                {
                    return this.value;
                }
                else
                {
                    return left.getMinValue();
                }
            }
        }
    }
}

/*
 //Solution TWO
----------------------------------------------------------------------------------

  public class BST {
    public int value;
    public BST left;
    public BST right;

    public BST(int value) {
      this.value = value;
    }

      //Avg O()long(n)
      //worst: O(n)
    public BST Insert(int value) {
      BST currentNode = this;
        while(true){
            if(value < currentNode.value){
                if(currentNode.left == null){
                    BST newNode = new BST(value);
                    currentNode.left = newNode;
                    break;
                } else {
                    currentNode = currentNode.left;
                }
            } else {
                if(currentNode.right == null){
                    BST newNode = new BST(value);
                    currentNode.right = newNode;
                    break;
                } else {
                    currentNode = currentNode.right;
                }
            }
        }
        return this;
    }

    public bool Contains(int value) {
      // Write your code here.
        BST currentNode = this;
        while(currentNode!=null){
            if(value < currentNode.value){
                currentNode = currentNode.left;
            } else if(value > currentNode.value){
                currentNode = currentNode.right;
            } else {
                return true;
            }
        }
      return false;
    }

    public BST Remove(int value) {
      // Write your code here.
      // Do not edit the return statement of this method.
        Remove(value, null);
      return this;
    }
      public void Remove(int value, BST parentNode){
          BST currentNode = this;
          while(currentNode != null){
              if(value < currentNode.value){
                  parentNode = currentNode;
                  currentNode = currentNode.left;
              } else if(value > currentNode.value){
                  parentNode = currentNode;
                  currentNode = currentNode.right;
              } else {
                  if(currentNode.left != null && currentNode.right != null){
                      currentNode.value = currentNode.right.getMinValue();
                      currentNode.right.Remove(currentNode.value, currentNode);
                  } else if(parentNode == null){
                      if(currentNode.left != null){
                          currentNode.value = currentNode.left.value;
                          currentNode.right = currentNode.left.right;
                          currentNode.left = currentNode.left.left;
                      } else if(currentNode.right != null){
                          currentNode.value = currentNode.right.value;
                          currentNode.left = currentNode.right.left;
                          currentNode.right = currentNode.right.right;
                      } else {
                          //do nothing
                      }
                  } else if(parentNode.left == currentNode){
                      parentNode.left = 
                          currentNode.left != null ? currentNode.left : currentNode.right;
                  } else if(parentNode.right == currentNode){
                      parentNode.right = 
                          currentNode.left != null ? currentNode.left : currentNode.right;
                  }
                  break;
              }
          }
      }
      
      public int getMinValue(){
          if(left == null){
              return value;
          } else {
              return left.getMinValue();
          }
      }
  }

----------------------------------------------------------------------------------
 
 using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    var root = new Program.BST(10);
    root.left = new Program.BST(5);
    root.left.left = new Program.BST(2);
    root.left.left.left = new Program.BST(1);
    root.left.right = new Program.BST(5);
    root.right = new Program.BST(15);
    root.right.left = new Program.BST(13);
    root.right.left.right = new Program.BST(14);
    root.right.right = new Program.BST(22);

    root.Insert(12);
    Utils.AssertTrue(root.right.left.left.value == 12);

    root.Remove(10);
    Utils.AssertTrue(root.Contains(10) == false);
    Utils.AssertTrue(root.value == 12);

    Utils.AssertTrue(root.Contains(15));
  }
}

 10 / 10 test cases passed.

Test Case 1 passed!
Expected Output
[
  {
    "arguments": [5],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": null, "value": 10},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [15],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [2],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": "2", "right": null, "value": 5},
        {"id": "2", "left": null, "right": null, "value": 2}
      ],
      "root": "10"
    }
  },
  {
    "argumen... 
Your Code's Output
[
  {
    "arguments": [5],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": null, "value": 10},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [15],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [2],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": "2", "right": null, "value": 5},
        {"id": "2", "left": null, "right": null, "value": 2}
      ],
      "root": "10"
    }
  },
  {
    "argumen... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [5],
      "method": "insert"
    },
    {
      "arguments": [15],
      "method": "insert"
    },
    {
      "arguments": [2],
      "method": "insert"
    },
    {
      "arguments": [5],
      "method": "insert"
    },
    {
      "arguments": [13],
      "method": "insert"
    },
    {
      "arguments": [22],
      "method": "insert"
    },
    {
      "arguments": [1],
      "method": "insert"
    },
    {
      "arguments": [14],
      "method": "insert"
    },
    {
      "arguments": [12],
      "method": "insert"
    },
    {
      "arguments": [10],
      "method": "remove"
    },
    {
      "arguments": [15],
      "method": "contains"
    }
  ],
  "rootValue": 10
}
Test Case 2 passed!
Expected Output
[
  {
    "arguments": [5],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": null, "value": 10},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [15],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  }
]
Your Code's Output
[
  {
    "arguments": [5],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": null, "value": 10},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [15],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [5],
      "method": "insert"
    },
    {
      "arguments": [15],
      "method": "insert"
    }
  ],
  "rootValue": 10
}
Test Case 3 passed!
Expected Output
[
  {
    "arguments": [5],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": null, "value": 10},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [15],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [10],
    "method": "contains",
    "output": true,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [5],
    "method": "contains",
    "output": true,
  ... 
Your Code's Output
[
  {
    "arguments": [5],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": null, "value": 10},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [15],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [10],
    "method": "contains",
    "output": true,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [5],
    "method": "contains",
    "output": true,
  ... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [5],
      "method": "insert"
    },
    {
      "arguments": [15],
      "method": "insert"
    },
    {
      "arguments": [10],
      "method": "contains"
    },
    {
      "arguments": [5],
      "method": "contains"
    },
    {
      "arguments": [15],
      "method": "contains"
    },
    {
      "arguments": [1],
      "method": "contains"
    },
    {
      "arguments": [6],
      "method": "contains"
    },
    {
      "arguments": [11],
      "method": "contains"
    },
    {
      "arguments": [16],
      "method": "contains"
    }
  ],
  "rootValue": 10
}
Test Case 4 passed!
Expected Output
[
  {
    "arguments": [5],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": null, "value": 10},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [15],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [5],
    "method": "remove",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": null, "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [15],
    "method": "remove",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": null, "... 
Your Code's Output
[
  {
    "arguments": [5],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": null, "value": 10},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [15],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [5],
    "method": "remove",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": null, "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [15],
    "method": "remove",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": null, "... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [5],
      "method": "insert"
    },
    {
      "arguments": [15],
      "method": "insert"
    },
    {
      "arguments": [5],
      "method": "remove"
    },
    {
      "arguments": [15],
      "method": "remove"
    },
    {
      "arguments": [10],
      "method": "remove"
    }
  ],
  "rootValue": 10
}
Test Case 5 passed!
Expected Output
[
  {
    "arguments": [5],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": null, "value": 10},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [15],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [10],
    "method": "contains",
    "output": true,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [5],
    "method": "contains",
    "output": true,
  ... 
Your Code's Output
[
  {
    "arguments": [5],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": null, "value": 10},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [15],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [10],
    "method": "contains",
    "output": true,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [5],
    "method": "contains",
    "output": true,
  ... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [5],
      "method": "insert"
    },
    {
      "arguments": [15],
      "method": "insert"
    },
    {
      "arguments": [10],
      "method": "contains"
    },
    {
      "arguments": [5],
      "method": "contains"
    },
    {
      "arguments": [15],
      "method": "contains"
    },
    {
      "arguments": [10],
      "method": "remove"
    },
    {
      "arguments": [5],
      "method": "remove"
    },
    {
      "arguments": [15],
      "method": "remove"
    },
    {
      "arguments": [10],
      "method": "contains"
    },
    {
      "arguments": [5],
      "method": "contains"
    },
    {
      "arguments": [15],
      "method": "contains"
    }
  ],
  "rootValue": 10
}
Test Case 6 passed!
Expected Output
[
  {
    "arguments": [2],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "1", "left": null, "right": "2", "value": 1},
        {"id": "2", "left": null, "right": null, "value": 2}
      ],
      "root": "1"
    }
  },
  {
    "arguments": [3],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "1", "left": null, "right": "2", "value": 1},
        {"id": "2", "left": null, "right": "3", "value": 2},
        {"id": "3", "left": null, "right": null, "value": 3}
      ],
      "root": "1"
    }
  },
  {
    "arguments": [4],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "1", "left": null, "right": "2", "value": 1},
        {"id": "2", "left": null, "right": "3", "value": 2},
        {"id": "3", "left": null, "right": "4", "value": 3},
        {"id": "4", "left": null, "right": null, "value": 4}
      ],
      "root": "1"
    }
  },
  {
    "arguments": [5],
    "m... 
Your Code's Output
[
  {
    "arguments": [2],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "1", "left": null, "right": "2", "value": 1},
        {"id": "2", "left": null, "right": null, "value": 2}
      ],
      "root": "1"
    }
  },
  {
    "arguments": [3],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "1", "left": null, "right": "2", "value": 1},
        {"id": "2", "left": null, "right": "3", "value": 2},
        {"id": "3", "left": null, "right": null, "value": 3}
      ],
      "root": "1"
    }
  },
  {
    "arguments": [4],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "1", "left": null, "right": "2", "value": 1},
        {"id": "2", "left": null, "right": "3", "value": 2},
        {"id": "3", "left": null, "right": "4", "value": 3},
        {"id": "4", "left": null, "right": null, "value": 4}
      ],
      "root": "1"
    }
  },
  {
    "arguments": [5],
    "m... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [2],
      "method": "insert"
    },
    {
      "arguments": [3],
      "method": "insert"
    },
    {
      "arguments": [4],
      "method": "insert"
    },
    {
      "arguments": [5],
      "method": "insert"
    },
    {
      "arguments": [6],
      "method": "insert"
    },
    {
      "arguments": [7],
      "method": "insert"
    },
    {
      "arguments": [8],
      "method": "insert"
    },
    {
      "arguments": [9],
      "method": "insert"
    },
    {
      "arguments": [10],
      "method": "insert"
    },
    {
      "arguments": [11],
      "method": "insert"
    },
    {
      "arguments": [12],
      "method": "insert"
    },
    {
      "arguments": [13],
      "method": "insert"
    },
    {
      "arguments": [14],
      "method": "insert"
    },
    {
      "arguments": [15],
      "method": "insert"
    },
    {
      "arguments": [16],
      "method": "insert"
    },
    {
      "arguments": [17],
      "method": "insert"
    },
    {
      "arguments": [18],
      "method": "insert"
    },
    {
      "arguments": [19],
      "method": "insert"
    },
    {
      "arguments": [20],
      "method": "insert"
    },
    {
      "arguments": [2],
      "method": "remove"
    },
    {
      "arguments": [4],
      "method": "remove"
    },
    {
      "arguments": [6],
      "method": "remove"
    },
    {
      "arguments": [8],
      "method": "remove"
    },
    {
      "arguments": [11],
      "method": "remove"
    },
    {
      "arguments": [13],
      "method": "remove"
    },
    {
      "arguments": [15],
      "method": "remove"
    },
    {
      "arguments": [17],
      "method": "remove"
    },
    {
      "arguments": [19],
      "method": "remove"
    },
    {
      "arguments": [1],
      "method": "insert"
    },
    {
      "arguments": [2],
      "method": "insert"
    },
    {
      "arguments": [3],
      "method": "insert"
    },
    {
      "arguments": [4],
      "method": "insert"
    },
    {
      "arguments": [5],
      "method": "insert"
    },
    {
      "arguments": [6],
      "method": "insert"
    },
    {
      "arguments": [7],
      "method": "insert"
    },
    {
      "arguments": [8],
      "method": "insert"
    },
    {
      "arguments": [9],
      "method": "insert"
    },
    {
      "arguments": [10],
      "method": "insert"
    },
    {
      "arguments": [9000],
      "method": "contains"
    }
  ],
  "rootValue": 1
}
Test Case 7 passed!
Expected Output
[
  {
    "arguments": [2],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "1", "left": null, "right": "2", "value": 1},
        {"id": "2", "left": null, "right": null, "value": 2}
      ],
      "root": "1"
    }
  },
  {
    "arguments": [3],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "1", "left": null, "right": "2", "value": 1},
        {"id": "2", "left": null, "right": "3", "value": 2},
        {"id": "3", "left": null, "right": null, "value": 3}
      ],
      "root": "1"
    }
  },
  {
    "arguments": [4],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "1", "left": null, "right": "2", "value": 1},
        {"id": "2", "left": null, "right": "3", "value": 2},
        {"id": "3", "left": null, "right": "4", "value": 3},
        {"id": "4", "left": null, "right": null, "value": 4}
      ],
      "root": "1"
    }
  },
  {
    "arguments": [1],
    "m... 
Your Code's Output
[
  {
    "arguments": [2],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "1", "left": null, "right": "2", "value": 1},
        {"id": "2", "left": null, "right": null, "value": 2}
      ],
      "root": "1"
    }
  },
  {
    "arguments": [3],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "1", "left": null, "right": "2", "value": 1},
        {"id": "2", "left": null, "right": "3", "value": 2},
        {"id": "3", "left": null, "right": null, "value": 3}
      ],
      "root": "1"
    }
  },
  {
    "arguments": [4],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "1", "left": null, "right": "2", "value": 1},
        {"id": "2", "left": null, "right": "3", "value": 2},
        {"id": "3", "left": null, "right": "4", "value": 3},
        {"id": "4", "left": null, "right": null, "value": 4}
      ],
      "root": "1"
    }
  },
  {
    "arguments": [1],
    "m... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [2],
      "method": "insert"
    },
    {
      "arguments": [3],
      "method": "insert"
    },
    {
      "arguments": [4],
      "method": "insert"
    },
    {
      "arguments": [1],
      "method": "remove"
    }
  ],
  "rootValue": 1
}
Test Case 8 passed!
Expected Output
[
  {
    "arguments": [-2],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "1", "left": "-2", "right": null, "value": 1},
        {"id": "-2", "left": null, "right": null, "value": -2}
      ],
      "root": "1"
    }
  },
  {
    "arguments": [-3],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "1", "left": "-2", "right": null, "value": 1},
        {"id": "-2", "left": "-3", "right": null, "value": -2},
        {"id": "-3", "left": null, "right": null, "value": -3}
      ],
      "root": "1"
    }
  },
  {
    "arguments": [-4],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "1", "left": "-2", "right": null, "value": 1},
        {"id": "-2", "left": "-3", "right": null, "value": -2},
        {"id": "-3", "left": "-4", "right": null, "value": -3},
        {"id": "-4", "left": null, "right": null, "value": -4}
      ],
      "root": "1"
    }
  },
  {
    "ar... 
Your Code's Output
[
  {
    "arguments": [-2],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "1", "left": "-2", "right": null, "value": 1},
        {"id": "-2", "left": null, "right": null, "value": -2}
      ],
      "root": "1"
    }
  },
  {
    "arguments": [-3],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "1", "left": "-2", "right": null, "value": 1},
        {"id": "-2", "left": "-3", "right": null, "value": -2},
        {"id": "-3", "left": null, "right": null, "value": -3}
      ],
      "root": "1"
    }
  },
  {
    "arguments": [-4],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "1", "left": "-2", "right": null, "value": 1},
        {"id": "-2", "left": "-3", "right": null, "value": -2},
        {"id": "-3", "left": "-4", "right": null, "value": -3},
        {"id": "-4", "left": null, "right": null, "value": -4}
      ],
      "root": "1"
    }
  },
  {
    "ar... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [-2],
      "method": "insert"
    },
    {
      "arguments": [-3],
      "method": "insert"
    },
    {
      "arguments": [-4],
      "method": "insert"
    },
    {
      "arguments": [1],
      "method": "remove"
    }
  ],
  "rootValue": 1
}
Test Case 9 passed!
Expected Output
[
  {
    "arguments": [5],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": null, "value": 10},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [10],
    "method": "remove",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "5"
    }
  },
  {
    "arguments": [15],
    "method": "contains",
    "output": false,
    "tree": {
      "nodes": [
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "5"
    }
  }
]
Your Code's Output
[
  {
    "arguments": [5],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": null, "value": 10},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [10],
    "method": "remove",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "5"
    }
  },
  {
    "arguments": [15],
    "method": "contains",
    "output": false,
    "tree": {
      "nodes": [
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "5"
    }
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [5],
      "method": "insert"
    },
    {
      "arguments": [10],
      "method": "remove"
    },
    {
      "arguments": [15],
      "method": "contains"
    }
  ],
  "rootValue": 10
}
Test Case 10 passed!
Expected Output
[
  {
    "arguments": [5],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": null, "value": 10},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [15],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [2],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": "2", "right": null, "value": 5},
        {"id": "2", "left": null, "right": null, "value": 2}
      ],
      "root": "10"
    }
  },
  {
    "argumen... 
Your Code's Output
[
  {
    "arguments": [5],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": null, "value": 10},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [15],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": null, "right": null, "value": 5}
      ],
      "root": "10"
    }
  },
  {
    "arguments": [2],
    "method": "insert",
    "output": null,
    "tree": {
      "nodes": [
        {"id": "10", "left": "5", "right": "15", "value": 10},
        {"id": "15", "left": null, "right": null, "value": 15},
        {"id": "5", "left": "2", "right": null, "value": 5},
        {"id": "2", "left": null, "right": null, "value": 2}
      ],
      "root": "10"
    }
  },
  {
    "argumen... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": [5],
      "method": "insert"
    },
    {
      "arguments": [15],
      "method": "insert"
    },
    {
      "arguments": [2],
      "method": "insert"
    },
    {
      "arguments": [5],
      "method": "insert"
    },
    {
      "arguments": [13],
      "method": "insert"
    },
    {
      "arguments": [22],
      "method": "insert"
    },
    {
      "arguments": [1],
      "method": "insert"
    },
    {
      "arguments": [14],
      "method": "insert"
    },
    {
      "arguments": [12],
      "method": "insert"
    },
    {
      "arguments": [5],
      "method": "remove"
    },
    {
      "arguments": [5],
      "method": "remove"
    },
    {
      "arguments": [12],
      "method": "remove"
    },
    {
      "arguments": [13],
      "method": "remove"
    },
    {
      "arguments": [14],
      "method": "remove"
    },
    {
      "arguments": [22],
      "method": "remove"
    },
    {
      "arguments": [2],
      "method": "remove"
    },
    {
      "arguments": [1],
      "method": "remove"
    },
    {
      "arguments": [15],
      "method": "contains"
    }
  ],
  "rootValue": 10
}
 
 */