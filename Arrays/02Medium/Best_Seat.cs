using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._02Medium
{
    public class Best_Seat
    {
        public int BestSeat(int[] seats)
        {
            // Write your code here.
            int bestSeat = -1;
            int maxSpace = 0;
            int left = 0;
            while (left < seats.Length)
            {
                int right = left + 1;
                while (right < seats.Length && seats[right] == 0)
                {
                    right++;
                }

                int availableSpace = right - left - 1;
                if (availableSpace > maxSpace)
                {
                    maxSpace = availableSpace;
                    bestSeat = (right + left) / 2;
                }
                left = right;
            }
            return bestSeat;
        }
    }

}

/*
 Test Case 1
{
  "seats": [1]
}
Test Case 2
{
  "seats": [1, 0, 1, 0, 0, 0, 1]
}
Test Case 3
{
  "seats": [1, 0, 1]
}
Test Case 4
{
  "seats": [1, 0, 0, 1]
}
Test Case 5
{
  "seats": [1, 1, 1]
}
Test Case 6
{
  "seats": [1, 0, 0, 1, 0, 0, 1]
}
Test Case 7
{
  "seats": [1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1]
}
Test Case 8
{
  "seats": [1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1]
}
Test Case 9
{
  "seats": [1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1]
}
Test Case 10
{
  "seats": [1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1]
}
Test Case 11
{
  "seats": [1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1]
}
Test Case 12
{
  "seats": [1, 0, 0, 0, 1, 0, 0, 0, 0, 1]
}
Test Case 13
{
  "seats": [1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1]
}
Test Case 14
{
  "seats": [1, 1, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0, 1]
}

 */