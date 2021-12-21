using System;

namespace Arrays
{
    public class ProductOfTwoArray
    {
        public static int[] ArrayOfProducts(int[] array)
        {
            // Write your code here.
            int[] left  = new int[array.Length];
            int[] output = new int[array.Length];
            int product = 1;
            for (int i = 0; i < array.Length; i++)
            {
                left[i] = product;
                product = array[i]*product;
            }
            product = 1;
            for (int j = array.Length -1; j >= 0; j--)
            {
                output[j] = product * left[j];
                product = array[j]*product;
            }

            foreach (int i in output)
            {
                Console.WriteLine(i);
            }

            return output;
        }

    }

}
