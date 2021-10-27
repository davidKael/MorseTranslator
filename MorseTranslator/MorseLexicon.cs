using System;
using System.Collections.Generic;
using System.Linq;

namespace MorseTranslator
{
    class MorseLexicon
    {
        private static Dictionary<char, string> morseTranslations = new Dictionary<char, string>()
        {
            {'a', "*-"},
            {'b', "-***"},
            {'c', "-*-*"},
            {'d', "-**"},
            {'e', "*"},
            {'f', "**-*"},
            {'g', "--*"},
            {'h', "****"},
            {'i', "**"},
            {'j', "*---"},
            {'k', "-*-"},
            {'l', "*-**"},
            {'m', "--"},
            {'n', "-*"},
            {'o', "---"},
            {'p', "*--*"},
            {'q', "--*-"},
            {'r', "*-*"},
            {'s', "***"},
            {'t', "-"},
            {'u', "**-"},
            {'v', "***-"},
            {'w', "*--"},
            {'x', "-**-"},
            {'y', "-*--"},
            {'z', "--**"},
            {'å', "*--*-"},
            {'ä', "*-*-"},
            {'ö', "---*"},

            {'0', "-----"},
            {'1', "*----"},
            {'2', "**---"},
            {'3', "***--"},
            {'4', "****-"},
            {'5', "*****"},
            {'6', "-****"},
            {'7', "--***"},
            {'8', "---**"},
            {'9', "----*"},


            {',', "--**--" },
            {':', "---***" },
            {'?', "**--**" },
            {'\'', "*----*" },
            {'-', "-****-" },
            {'/', "-**-*" },
            {'(', "-*--*" },
            {')', "-*--*-" },
            {'"', "*-**-*" },
            {'.', "*-*-*-" },
            {'!', "-*-*--" },
            {'@', "*--*-*" },
            {'&', "*-***" },
            {'%', "*--**" }
        };


        internal static string FromStringToMorse(string _input)
        {
            _input = _input.ToLower();
            string output = "";

            for(int i = 0; i < _input.Length; i++)
            {
                if(morseTranslations.TryGetValue(_input[i], out string value))
                {

                    output += ($"{value} ");
                }
                else
                {
                    if(_input[i] == ' ')
                    {

                        output += "  ";

                    }
                    else
                    {
                        output += "?????? ";

                    }                    
                }                
            }

            return output;
        }


        internal static string FromMorseToString(string _input)
        {
            _input = _input.ToLower();
            string output = "";
            string morseLetter = "";
            int morseStart = 0;
            int spaceCount = 0;
            bool isMorseLetterComplete = false;
            int morseLettersFound = 0;

            for (int i = 0; i < _input.Length; i++)
            {
                if(_input[i] != ' ')
                {
                    if(morseLetter.Length < 1)
                    {

                        morseStart = i;
                    }

                    morseLetter += _input[i];
                    spaceCount = 0;
                    isMorseLetterComplete = false;
                }
                else
                {
                    spaceCount++;
                    isMorseLetterComplete = true;

                    if (spaceCount >= 3)
                    {

                        output += ' ';
                        spaceCount = 0;
                    }
                }

                if(i == _input.Length - 1)
                {
                    isMorseLetterComplete = true;
                }

                if (isMorseLetterComplete)
                {
                    if (morseTranslations.ContainsValue(morseLetter))
                    {
                        output += morseTranslations.FirstOrDefault(key => key.Value == morseLetter).Key;
                        morseLettersFound++;

                    }

                    morseLetter = "";                 
                }
            }

            return morseLettersFound < 1 ? "No valid morse code found in input" : output;
        }


        internal static void DisplayLexicon()
        {
            foreach(KeyValuePair<char, string> item in morseTranslations)
            {           
                Console.WriteLine($"  {item.Key}   {item.Value}");
            }
        }


        internal static void CheckIfValuesAreSame()
        {
            bool foundTwoOfSame = false;
            
            foreach(KeyValuePair<char,string> s in morseTranslations)
            {
                foreach (KeyValuePair<char, string> s2 in morseTranslations)
                {
                    if(s.Key != s2.Key)
                    {
                        if (s.Value == s2.Value)
                        {
                            foundTwoOfSame = true;

                            Console.WriteLine($"{s.Key} och {s2.Key} are the same");
                        }
                    }
                }
            }

            if (!foundTwoOfSame)
            {
                Console.WriteLine("All values are unique");
            }           
        }
    }
}
