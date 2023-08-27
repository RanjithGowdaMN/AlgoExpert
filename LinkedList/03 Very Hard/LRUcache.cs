using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList._03_Very_Hard
{
    public class LRUcachePrgram
    {
        public class LRUCache
        {
            public Dictionary<string, DoublyLinkedListNode> cache =
            new Dictionary<string, DoublyLinkedListNode>();
            public int maxSize;
            public int currentSize;
            public DoublyLinkedList listOfMostRecent = new DoublyLinkedList();
            public LRUCache(int maxSize)
            {

                this.maxSize = maxSize > 1 ? maxSize : 1;
            }

            public void InsertKeyValuePair(string key, int value)
            {
                //O(1) | O(1) space
                if (!cache.ContainsKey(key))
                {
                    if (currentSize == maxSize)
                    {
                        evictLeastRecent();
                    }
                    else
                    {
                        currentSize++;
                    }
                    cache.Add(key, new DoublyLinkedListNode(key, value));
                }
                else
                {
                    replaceKey(key, value);
                }
                updateMostRecent(cache[key]);
            }

            public LRUResult GetValueFromKey(string key)
            {
                // Write your code here.
                if (!cache.ContainsKey(key))
                {
                    return new LRUResult(false, -1);
                }
                updateMostRecent(cache[key]);
                return new LRUResult(true, cache[key].value);
            }

            public string GetMostRecentKey()
            {
                // Write your code here.
                if (listOfMostRecent.head == null)
                {
                    return "";
                }
                return listOfMostRecent.head.key;
            }
            public void evictLeastRecent()
            {
                string keyToRemove = listOfMostRecent.tail.key;
                listOfMostRecent.removeTail();
                cache.Remove(keyToRemove);
            }

            public void updateMostRecent(DoublyLinkedListNode node)
            {
                listOfMostRecent.setHeadTo(node);
            }
            public void replaceKey(string key, int value)
            {
                if (!cache.ContainsKey(key))
                {
                    return;
                }
                cache[key].value = value;
            }
        }

        public class DoublyLinkedList
        {
            public DoublyLinkedListNode head = null;
            public DoublyLinkedListNode tail = null;
            public void setHeadTo(DoublyLinkedListNode node)
            {
                if (head == node)
                {
                    return;
                }
                else if (head == null)
                {
                    head = node;
                    tail = node;
                }
                else if (head == tail)
                {
                    tail.prev = node;
                    head = node;
                    head.next = tail;
                }
                else
                {
                    if (tail == node)
                    {
                        removeTail();
                    }
                    node.removeBindings();
                    head.prev = node;
                    node.next = head;
                    head = node;
                }
            }
            public void removeTail()
            {
                if (tail == null)
                {
                    return;
                }
                if (tail == head)
                {
                    head = null;
                    tail = null;
                    return;
                }
                tail = tail.prev;
                tail.next = null;
            }
        }

        public class DoublyLinkedListNode
        {
            public string key;
            public int value;
            public DoublyLinkedListNode prev = null;
            public DoublyLinkedListNode next = null;

            public DoublyLinkedListNode(string key, int value)
            {
                this.key = key;
                this.value = value;
            }

            public void removeBindings()
            {
                if (prev != null)
                {
                    prev.next = next;
                }
                if (next != null)
                {
                    next.prev = prev;
                }
                prev = null;
                next = null;
            }
        }

        public class LRUResult
        {
            public bool found;
            public int value;

            public LRUResult(bool found, int value)
            {
                this.found = found;
                this.value = value;
            }
        }

    }
}
/*
 using System.Collections.Generic;

public class ProgramTest {
  [Test]
  public void TestCase1() {
    Program.LRUCache lruCache = new Program.LRUCache(3);
    lruCache.InsertKeyValuePair("b", 2);
    lruCache.InsertKeyValuePair("a", 1);
    lruCache.InsertKeyValuePair("c", 3);
    Utils.AssertTrue(lruCache.GetMostRecentKey() == "c");
    Utils.AssertTrue(lruCache.GetValueFromKey("a").value == 1);
    Utils.AssertTrue(lruCache.GetMostRecentKey() == "a");
    lruCache.InsertKeyValuePair("d", 4);
    var evictedValue = lruCache.GetValueFromKey("b");
    Utils.AssertTrue(evictedValue == null || evictedValue.found == false);
    lruCache.InsertKeyValuePair("a", 5);
    Utils.AssertTrue(lruCache.GetValueFromKey("a").value == 5);
  }
}


5 / 5 test cases passed.

Test Case 1 passed!
Expected Output
[
  {
    "arguments": ["b", 2],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a", 1],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["c", 3],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMostRecentKey",
    "output": "c"
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": 1
  },
  {
    "arguments": [],
    "method": "getMostRecentKey",
    "output": "a"
  },
  {
    "arguments": ["d", 4],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["b"],
    "method": "getValueFromKey",
    "output": null
  },
  {
    "arguments": ["a", 5],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": 5
  }
]
Our Code's Output
[
  {
    "arguments": ["b", 2],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a", 1],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["c", 3],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMostRecentKey",
    "output": "c"
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": 1
  },
  {
    "arguments": [],
    "method": "getMostRecentKey",
    "output": "a"
  },
  {
    "arguments": ["d", 4],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["b"],
    "method": "getValueFromKey",
    "output": null
  },
  {
    "arguments": ["a", 5],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": 5
  }
]
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["b", 2],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["a", 1],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["c", 3],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": [],
      "method": "getMostRecentKey"
    },
    {
      "arguments": ["a"],
      "method": "getValueFromKey"
    },
    {
      "arguments": [],
      "method": "getMostRecentKey"
    },
    {
      "arguments": ["d", 4],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["b"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["a", 5],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["a"],
      "method": "getValueFromKey"
    }
  ],
  "maxSize": 3
}
Test Case 2 passed!
Expected Output
[
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": null
  },
  {
    "arguments": ["a", 1],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": 1
  },
  {
    "arguments": ["a", 9001],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": 9001
  },
  {
    "arguments": ["b", 2],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": null
  },
  {
    "arguments": ["b"],
    "method": "getValueFromKey",
    "output": 2
  },
  {
    "arguments": ["c", 3],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": null
  },
  {
    "arguments": ["b"],
    "method": "getValueFromKey",
    "output": null
  },
  {
    "arguments": ["c"],
    "method": ... 
Our Code's Output
[
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": null
  },
  {
    "arguments": ["a", 1],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": 1
  },
  {
    "arguments": ["a", 9001],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": 9001
  },
  {
    "arguments": ["b", 2],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": null
  },
  {
    "arguments": ["b"],
    "method": "getValueFromKey",
    "output": 2
  },
  {
    "arguments": ["c", 3],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": null
  },
  {
    "arguments": ["b"],
    "method": "getValueFromKey",
    "output": null
  },
  {
    "arguments": ["c"],
    "method": ... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["a"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["a", 1],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["a"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["a", 9001],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["a"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["b", 2],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["a"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["b"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["c", 3],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["a"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["b"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["c"],
      "method": "getValueFromKey"
    }
  ],
  "maxSize": 1
}
Test Case 3 passed!
Expected Output
[
  {
    "arguments": ["a", 1],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["b", 2],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["c", 3],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["d", 4],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": 1
  },
  {
    "arguments": ["b"],
    "method": "getValueFromKey",
    "output": 2
  },
  {
    "arguments": ["c"],
    "method": "getValueFromKey",
    "output": 3
  },
  {
    "arguments": ["d"],
    "method": "getValueFromKey",
    "output": 4
  },
  {
    "arguments": ["e", 5],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": null
  },
  {
    "arguments": ["b"],
    "method": "getValueFromKey",
    "output": 2
  },
  {
    "arguments": ["c"],
    "method": "getVa... 
Our Code's Output
[
  {
    "arguments": ["a", 1],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["b", 2],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["c", 3],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["d", 4],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": 1
  },
  {
    "arguments": ["b"],
    "method": "getValueFromKey",
    "output": 2
  },
  {
    "arguments": ["c"],
    "method": "getValueFromKey",
    "output": 3
  },
  {
    "arguments": ["d"],
    "method": "getValueFromKey",
    "output": 4
  },
  {
    "arguments": ["e", 5],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": null
  },
  {
    "arguments": ["b"],
    "method": "getValueFromKey",
    "output": 2
  },
  {
    "arguments": ["c"],
    "method": "getVa... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["a", 1],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["b", 2],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["c", 3],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["d", 4],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["a"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["b"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["c"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["d"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["e", 5],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["a"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["b"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["c"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["d"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["e"],
      "method": "getValueFromKey"
    }
  ],
  "maxSize": 4
}
Test Case 4 passed!
Expected Output
[
  {
    "arguments": ["a", 1],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMostRecentKey",
    "output": "a"
  },
  {
    "arguments": ["b", 2],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMostRecentKey",
    "output": "b"
  },
  {
    "arguments": ["c", 3],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMostRecentKey",
    "output": "c"
  },
  {
    "arguments": ["d", 4],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMostRecentKey",
    "output": "d"
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": 1
  },
  {
    "arguments": [],
    "method": "getMostRecentKey",
    "output": "a"
  },
  {
    "arguments": ["b"],
    "method": "getValueFromKey",
    "output": 2
  },
  {
    "arguments": [],
    "method": "getMostRecentKey",
 ... 
Our Code's Output
[
  {
    "arguments": ["a", 1],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMostRecentKey",
    "output": "a"
  },
  {
    "arguments": ["b", 2],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMostRecentKey",
    "output": "b"
  },
  {
    "arguments": ["c", 3],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMostRecentKey",
    "output": "c"
  },
  {
    "arguments": ["d", 4],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": [],
    "method": "getMostRecentKey",
    "output": "d"
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": 1
  },
  {
    "arguments": [],
    "method": "getMostRecentKey",
    "output": "a"
  },
  {
    "arguments": ["b"],
    "method": "getValueFromKey",
    "output": 2
  },
  {
    "arguments": [],
    "method": "getMostRecentKey",
 ... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["a", 1],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": [],
      "method": "getMostRecentKey"
    },
    {
      "arguments": ["b", 2],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": [],
      "method": "getMostRecentKey"
    },
    {
      "arguments": ["c", 3],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": [],
      "method": "getMostRecentKey"
    },
    {
      "arguments": ["d", 4],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": [],
      "method": "getMostRecentKey"
    },
    {
      "arguments": ["a"],
      "method": "getValueFromKey"
    },
    {
      "arguments": [],
      "method": "getMostRecentKey"
    },
    {
      "arguments": ["b"],
      "method": "getValueFromKey"
    },
    {
      "arguments": [],
      "method": "getMostRecentKey"
    },
    {
      "arguments": ["c"],
      "method": "getValueFromKey"
    },
    {
      "arguments": [],
      "method": "getMostRecentKey"
    },
    {
      "arguments": ["d"],
      "method": "getValueFromKey"
    },
    {
      "arguments": [],
      "method": "getMostRecentKey"
    },
    {
      "arguments": ["e", 5],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": [],
      "method": "getMostRecentKey"
    }
  ],
  "maxSize": 4
}
Test Case 5 passed!
Expected Output
[
  {
    "arguments": ["a", 1],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["b", 2],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["c", 3],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["d", 4],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": 1
  },
  {
    "arguments": ["e", 5],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": 1
  },
  {
    "arguments": ["b"],
    "method": "getValueFromKey",
    "output": null
  },
  {
    "arguments": ["c"],
    "method": "getValueFromKey",
    "output": 3
  },
  {
    "arguments": ["f", 5],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["c"],
    "method": "getValueFromKey",
    "output": 3
  },
  {
    "arguments": ["d"],
    "method... 
Our Code's Output
[
  {
    "arguments": ["a", 1],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["b", 2],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["c", 3],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["d", 4],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": 1
  },
  {
    "arguments": ["e", 5],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["a"],
    "method": "getValueFromKey",
    "output": 1
  },
  {
    "arguments": ["b"],
    "method": "getValueFromKey",
    "output": null
  },
  {
    "arguments": ["c"],
    "method": "getValueFromKey",
    "output": 3
  },
  {
    "arguments": ["f", 5],
    "method": "insertKeyValuePair",
    "output": null
  },
  {
    "arguments": ["c"],
    "method": "getValueFromKey",
    "output": 3
  },
  {
    "arguments": ["d"],
    "method... 
View Outputs Side By Side
Input(s)
{
  "classMethodsToCall": [
    {
      "arguments": ["a", 1],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["b", 2],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["c", 3],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["d", 4],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["a"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["e", 5],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["a"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["b"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["c"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["f", 5],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["c"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["d"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["g", 5],
      "method": "insertKeyValuePair"
    },
    {
      "arguments": ["e"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["a"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["c"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["f"],
      "method": "getValueFromKey"
    },
    {
      "arguments": ["g"],
      "method": "getValueFromKey"
    }
  ],
  "maxSize": 4
}


 
 */