using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class FourNumberSums
    {
        //public static void Main()
        //{
        //    FourNumberSum(new int[] { 7, 6, 4, -1, 1, 2 }, 16);
        //}

        public static List<int[]> FourNumberSum(int[] array, int targetSum)
        {
            // Write your code here.
            Dictionary<int, List<int[]>> HashDict = new Dictionary<int, List<int[]>>();
            List<int[]> result = new List<int[]>();

            for (int i = 1; i < array.Length - 1; i++)
            {

                for (int j = i + 1; j < array.Length; j++)
                {
                    int currentSum = array[i] + array[j];
                    int difference = targetSum - currentSum;
                    if (HashDict.ContainsKey(difference))
                    {
                        foreach (int[] pair in HashDict[difference])
                        {
                            result.Add(new int[] { pair[0], pair[1], array[i], array[j] });
                        }
                    }
                }

                for (int k = 0; k < i; k++)
                {
                    int currentSum = array[i] + array[k];
                    int[] newPair = { array[i], array[k] };
                    int difference = targetSum - currentSum;
                    if (!HashDict.ContainsKey(currentSum))
                    {
                        List<int[]> TempList = new List<int[]>();

                        TempList.Add(newPair);
                        HashDict.Add(currentSum, TempList);
                    }
                    else
                    {
                        HashDict[currentSum].Add(newPair);
                    }
                }

            }

            return result;
        }

    }
}
