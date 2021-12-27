using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings._01_Easy
{
    public class RunLengthEncoding
    {
        public static string RunLengthEncodingT(string str)
        {
			StringBuilder sb = new StringBuilder();
			char PreviousChar = str[0];
			int count = 1;
			for (int i = 1; i < str.Length; i++)
			{
				PreviousChar = str[i - 1];
				if (str[i] != PreviousChar || count == 9)
				{
					sb.Append(count.ToString() + PreviousChar);
					count = 0;
				}
				count++;
			}

			sb.Append(count.ToString());
			sb.Append(str[str.Length - 1]);
			return sb.ToString();
		}
    }
}
