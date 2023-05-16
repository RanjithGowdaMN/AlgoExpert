using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList._01_Medium
{
    public class MergingLinkedList
    {
        // This is an input class. Do not edit.
        public class LinkedList
        {
            public int value;
            public LinkedList next;

            public LinkedList(int value)
            {
                this.value = value;
                this.next = null;
            }
        }

        public LinkedList MergingLinkedLists(LinkedList linkedListOne, LinkedList linkedListTwo)
        {
            // Write your code here.
            LinkedList point1 = linkedListOne;
            LinkedList point2 = linkedListTwo;

            while (point1 != point2)
            {
                if (point1 == null)
                {
                    point1 = linkedListTwo;
                }
                else
                {
                    point1 = point1.next;

                }
                if (point2 == null)
                {
                    point2 = linkedListOne;
                }
                else
                {
                    point2 = point2.next;

                }
            }

            return point1;
        }
    }
}

/* 
 
 
 
 */