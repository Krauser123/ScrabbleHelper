using System;
using System.Collections.Generic;
using System.Linq;

namespace ScrabbleHelper
{
    class Program
    {
        readonly ScrabbleHelperCommon scrabbleHelperCommon = new ScrabbleHelperCommon();

        static void Main(string[] args)
        {
            var prg = new Program();
            prg.MainProcess();
        }

        public void MainProcess()
        {
            do
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(" Scrabble Gambler Helper --- v0.1");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("      Do not use to cheat!");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("What letters do you have?");
                string availableLetters = Console.ReadLine();

                var wordsToDraw = scrabbleHelperCommon.SearchWords(availableLetters);
                DrawTableInConsole(wordsToDraw);

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Press any key to search more words");
                Console.ReadLine();
                Console.Clear();
            }
            while (true);
        }

        

        private void DrawTableInConsole(Dictionary<int, string> wordsToDraw)
        {
            Console.WriteLine("__________________________________");
            Console.WriteLine("|      Puntos   |     Palabra    |");
            Console.WriteLine(" ************************************");


            //Draw table
            foreach (var item in wordsToDraw)
            {
                string formated = String.Format("|{0,15}|{1,16}|", item.Key, item.Value);
                Console.WriteLine(formated);
            }

            Console.WriteLine("|________________________________|");
        }

        
    }
}
