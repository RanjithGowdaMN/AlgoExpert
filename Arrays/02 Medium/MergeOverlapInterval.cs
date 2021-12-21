using System;
using System.Collections.Generic;

namespace Arrays
{
    public class MergeOverlapInterval
    { 

        public static int[][]  MergeOverlapIntervals(int[,] intervals)
        {
            int[][] sortedIntervals = intervals.Clone() as int[][];
            Array.Sort(sortedIntervals, (a, b) => a[0].CompareTo(b[0]) );

            List<int[]> result = new List<int[]>();
            int[] currentInterval = sortedIntervals[0];
            result.Add(currentInterval);

            foreach (int[] nextInterval in sortedIntervals)
            {
                int currentIntervalEnd = currentInterval[1];
                int nextIntervalStart = nextInterval[0];
                int nextIntervalEnd = nextInterval[1];

                if (currentIntervalEnd >= nextIntervalStart)
                {
                    currentInterval[1] = Math.Max(currentIntervalEnd, nextIntervalEnd);
                }
                else
                {
                    currentInterval = nextInterval;
                    result.Add(currentInterval);
                }

            }
            return result.ToArray();
        }
    }

}
