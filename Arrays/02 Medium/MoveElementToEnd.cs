using System;
using System.Collections.Generic;

namespace Arrays
{
    public class MoveElementToEnd
    {

        public static List<int> MoveElementToEndT(List<int> array, int toMove)
        {
            // Write your code here.

            if (array.Count == 1 || array.Count == 0)
            {
                return array;
            }

            int right = array.Count -1;
            int left = 0;
            while (left<right)
            {

                while (left <= right)
                {
                    if (array[left] != toMove)
                    {
                        left++;
                    }
                    else
                    {
                        break;
                    }
                }
                while (left <= right)
                {
                    if (array[right] == toMove)
                    {
                        right--;
                    }
                    else
                    {
                        break;
                    }
                }
                if (left<right)
                {
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                }
                
            }

            foreach (int i in array)
            { Console.WriteLine(i); }


            return array;
        }



    }
}
