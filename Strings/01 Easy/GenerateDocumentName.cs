using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings._01_Easy
{
    public class GenerateDocumentName
    {
        private static bool GenerateDocument(string characters, string document)
        {
            Dictionary<char, int> character = new Dictionary<char, int>();

            for (int i = 0; i < characters.Length; i++)
            {
                if (character.ContainsKey(characters[i]))
                {
                    character[characters[i]] +=1;
                }
                else
                {
                    character[characters[i]] = 1;
                }
            }

            for (int j = 0; j < document.Length; j++)
            {
                if (character.ContainsKey(document[j]) )
                {
                    if (character[document[j]] > 0)
                    {
                        character[document[j]] -= 1;
                    }
                    else
                    { 
                    return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
