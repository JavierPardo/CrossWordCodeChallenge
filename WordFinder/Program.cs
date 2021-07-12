using System;
using System.Collections.Generic;

namespace WordFinder
{
    class Program
    {
        private IEnumerable<string> matrixWords;
        static void Main(string[] args)
        {
            Console.WriteLine("Type the words that will built the matrix, insert blank when words are done consideer the lines will filled by rows:");
            int maxSize = 64;
            int i = 1;
            do
            {
                Console.Write($"Type row #{i}: ");
                var word = Console.ReadLine();
                i++;
            } while (i<64);

        }
    }
}
