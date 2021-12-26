using System;

namespace Strings
{
    internal class CheckPolindrome
	{

        private static bool checkPolindrome(string str)
        {
			int left = 0;
			int right = str.Length - 1;

			while (left < right)
			{
				if (str[left] != str[right])
				{
					return false;
				}
				else
				{
					left++;
					right--;
				}

			}
		return true;
		}
    }
}
