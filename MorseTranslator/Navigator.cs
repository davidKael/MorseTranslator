using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseTranslator
{
    class Navigator
    {
        internal static void StartPage()
        {
            string input = "", output = "";

            bool isAppRunning = true;
            while (isAppRunning)
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("Press 'A' to convert morse to text");
                Console.WriteLine("Press 'B' to convert text to morse");
                Console.WriteLine("Press 'C' to show morse alphabet");
                Console.WriteLine("Press 'Esc' to quit");
                Console.WriteLine("----------------------------------------------------------------------");
                ConsoleKeyInfo inputKey = Console.ReadKey();

                Console.Clear();
                switch (inputKey.Key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine("Write something in morse code:  ");
                        input = Console.ReadLine();

                        Console.Clear();
                        output = MorseLexicon.FromMorseToString(input);
                        Console.WriteLine(output);
                        break;

                    case ConsoleKey.B:
                        Console.WriteLine("Write something:  ");
                        input = Console.ReadLine();

                        Console.Clear();
                        output = MorseLexicon.FromStringToMorse(input);
                        Console.WriteLine(output);
                        break;

                    case ConsoleKey.C:
                        Console.WriteLine("----------------------------------------------------------------------");
                        MorseLexicon.DisplayLexicon();
                        break;

                    case ConsoleKey.Escape:
                        Console.WriteLine("_Ok, bye!!");
                        isAppRunning = false;
                        break;

                    default:
                        Console.WriteLine("Invalid key, try again..");
                        break;
                }
            }
        }
    }
}
