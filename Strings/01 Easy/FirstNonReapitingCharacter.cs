using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings._01_Easy
{
    public class FirstNonReapitingCharacter
    {
        public static void Main()
        {
            Console.WriteLine(FirstNonReapitingCharacterT("AAAAAAAAAAAAABBCCCCDD"));
        }

        private static int FirstNonReapitingCharacterT(string str)
        {
            Dictionary<char, int> CharFrequency = new Dictionary<char, int>();
            //Alternativly below line can be used
            //CharFrequency.GetValueOrDefault(str, 0);
            foreach (char s in str)
            {
                if (CharFrequency.ContainsKey(s))
                {
                    CharFrequency[s] += 1;
                }
                else 
                {
                    CharFrequency[s] = 1;
                }
            }

            foreach (char s in str)
            {
                if (CharFrequency[s] == 1)
                {
                    return str.IndexOf(s);
                }
            }
            return -1;

        }
    }
}
