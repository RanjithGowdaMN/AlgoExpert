using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    internal class CaesarCypherEncriptor
    {
        public static string caesarCypherEncriptor(string  str, int key)
        {
            char[] newString = new char[str.Length];
            string alphabets = "abcdefghijklmnopqrstuvwxyz";
            
            for (int i = 0; i < newString.Length; i++)
            {
                newString[i] = GetCharecter(str[i], key, alphabets);
            }

            return new string (newString);
        }

        private static char GetCharecter(char v, int key, string alphabets)
        {
            return alphabets[(alphabets.IndexOf(v) + key)%26];
        }
    }
}
