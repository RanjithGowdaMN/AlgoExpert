namespace Strings._02_Medium
{
    public class LongestPalindromicSubstrings
    {
        public static string LongestPalindromicSubstring(string str)
        {
            // Write your code here.
            int[] currentLogest = { 0, 1 };

            for (int i = 1; i < str.Length; i++)
            {
                int[] odd = getLogestPolindromeFrom(str, i - 1, i + 1);
                int[] even = getLogestPolindromeFrom(str, i - 1, i);

                int[] longest = odd[1] - odd[0] > even[1] - even[0] ? odd : even;

                currentLogest = currentLogest[1] - currentLogest[0] > longest[1] - longest[0] ? currentLogest : longest;
            }

            return str.Substring(currentLogest[0], currentLogest[1] - currentLogest[0]);
        }

        public static int[] getLogestPolindromeFrom(string str, int leftIdx, int rightIdx)
        {
            while (leftIdx >= 0 && rightIdx < str.Length)
            {
                if (str[leftIdx] != str[rightIdx])
                {
                    break;
                }
                leftIdx--;
                rightIdx++;
            }
            return new int[] { leftIdx + 1, rightIdx };
        }
    }
}
