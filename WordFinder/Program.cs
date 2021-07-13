using System;
using System.Collections.Generic;

namespace WordFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type the words that will built the matrix, \ninsert blank when finish. \nInsert line by line the rows for matrix:");
            IEnumerable<string> matrix= SetupWords("Type row",64);
            Console.WriteLine();
            Console.WriteLine("Type the words to find in matrix, \ninsert blank when finish. \nInsert line by line the words to find:");
            IEnumerable<string> words = SetupWords("Type word to Find",255);
            Console.WriteLine();

            var wordFinder = new WordFinder(matrix);

            Console.WriteLine("Top 10 Words finded:");

            foreach (var word in wordFinder.Find(words))
            {
                Console.WriteLine(word);
            }
        }

        private static IEnumerable<string> SetupWords(string iterateMessage, byte MaxWords)
        {
            int i = 1;
            var result = new List<string>();
            do
            {
                Console.Write($"{iterateMessage} #{i}: ");
                var word = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(word))
                {
                    break;
                }
                result.Add(word);
                i++;
            } while (i <= MaxWords);

            return result;
        }
    }
}
