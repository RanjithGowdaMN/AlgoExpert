using System.Collections.Generic;
using System.Linq;

namespace Arrays
{
    public class TraverseSpiralMatrix
    {

        public static List<int> SpiralTraverse(int[,] array)
        {
            // Write your code here.

            int[] result= new int[array.GetLength(0) * array.GetLength(1)];

            int startRow = 0;
            int endRow = array.GetLength(0)-1;
            int startCol = 0;
            int endCol = array.GetLength(1)-1;
            int index = 0;
            while (startRow<=endRow && startRow<=endCol)
            {

                //Right
                for (int i = startCol; i <= endCol; i++)
                {
                    result[index++] = array[startRow, i];
                }

                //Down
                for (int i = startRow + 1; i <= endRow ; i++)
                {
                    result[index++] = array[i, endCol];
                }
                for (int i = endCol-1; i >= startCol; i--)
                {
                    if (startRow == endRow)
                    {
                        break;
                    }
                    result[index++] = array[endRow, i];
                }
                for (int i = endRow - 1; i > startRow; i--)
                {
                    if (startCol == endCol)
                    {
                        break;
                    }
                    result[index++] = array[i, startCol];
                }

                startRow++;
                endRow--;
                startCol++;
                endCol--;
            }


            return result.ToList();
        }



    }


}
