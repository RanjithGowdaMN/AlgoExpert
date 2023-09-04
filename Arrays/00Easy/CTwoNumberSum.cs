using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays._01_Easy
{
    public static class CTwoNumberSum
    {
        public static void Main()
        {
            //Do Nothing
        }
        public static int[] TwoNumberSum(int[] array, int targetsum)
        {
            HashSet<int> visited = new HashSet<int>();

            for (int count = 0; count < array.Length; count++)
            {
                if (visited.Contains(targetsum - array[count]))
                {
                    return new int[] { targetsum - array[count], array[count] };
                }
                else
                {
                    visited.Add(array[count]);
                }
            }

            return new int[0];
        }
    }
}