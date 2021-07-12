using System.Collections.Generic;

namespace WordFinder
{
    public interface IWordFinder
    {
        bool CanRight { get; set; }
        bool CanLeft { get; set; }
        bool CanUp { get; set; }
        bool CanDown { get; set; }

        byte Find(IEnumerable<string> matrix, string word, byte row, byte col);
    }
}
