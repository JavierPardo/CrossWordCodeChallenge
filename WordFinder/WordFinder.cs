using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder
{
    public class WordFinder
    {
        private readonly IEnumerable<string> _matrix;
        private readonly IWordFinder[] _wordFinders;

        private IDictionary<string, int> _findings;

        public WordFinder(IEnumerable<String> matrix)
        {
            _matrix = matrix;
            _wordFinders = new FinderAbstract[]
            {
                new FinderDiagonalLeftDown(),
                new FinderDiagonalLeftUp(),
                new FinderDiagonalRightUp(),
                new FinderDiagonalRightDown(),

                new FinderHorizontalLeft(),
                new FinderHorizontalRight(),

                new FinderVerticalDown(),
                new FinderVerticalUp()
            };
        }


        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var groupedWords = GroupWords(wordstream);
            _findings = wordstream.ToDictionary(x => x, x => 0);

            for (byte row = 0; row < _matrix.Count(); row++)
            {
                var currentRow = _matrix.ElementAt(row);
                for (byte col = 0; col < currentRow.Length; col++)
                {
                    if (!groupedWords.ContainsKey(currentRow[col]))
                    {
                        continue;
                    }
                    var firstCharMatches = groupedWords[currentRow[col]];
                    CountWords(firstCharMatches, row, col);
                }
            }

            return _findings
                .Where(f=>f.Value>0)
                .OrderByDescending(f => f.Value)
                .Select(f => f.Key)
                .Take(10);
        }

        private void CountWords(string[] firstCharMatches, byte row,byte col)
        {
            foreach (var firstCharMatch in firstCharMatches)
            {
                var canRight = _matrix.ElementAt(row).Length >= col + firstCharMatch.Length;
                var canLeft = col+1>=firstCharMatch.Length;
                var canUp = row + 1 >= firstCharMatch.Length;
                var canDown = _matrix.Count() >= row + firstCharMatch.Length;

                foreach (var wordFinder in _wordFinders)
                {
                    wordFinder.CanRight = canRight;
                    wordFinder.CanLeft = canLeft;
                    wordFinder.CanUp = canUp;
                    wordFinder.CanDown = canDown;
                    _findings[firstCharMatch] += wordFinder.Find(_matrix,firstCharMatch, row, col);
                }
                
            }
        }

        public IDictionary<char,string[]> GroupWords(IEnumerable<string> words)
        {
            var groupedWords = new Dictionary<char, string[]>();

            foreach (var groupWord in words.GroupBy(x=>x[0]))
            {
                groupedWords.Add(groupWord.Key, groupWord.ToArray());
            }

            return groupedWords;
        }

    }
}
