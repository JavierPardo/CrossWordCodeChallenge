using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder
{
    public abstract class FinderAbstract : IWordFinder
    {
        private IEnumerable<string> _matrix;
        public bool CanRight { get; set; }
        public bool CanLeft { get; set; }
        public bool CanUp { get; set; }
        public bool CanDown { get; set; }
        public abstract bool CanContinue { get; set; }

        public abstract byte MoverRow(byte currentRow);
        public abstract byte MoverCol(byte currentCol);

        public byte Find(IEnumerable<string> matrix, string word, byte row, byte col)
        {
            if (CanContinue)
            {
                _matrix = matrix;
                return CountWords(word.Substring(1), MoverRow(row), MoverCol(col));
            }
            return 0;
        }
        private byte CountWords( string word, byte row, byte col)
        {
            if (string.IsNullOrEmpty(word))
                return 1;
            var firstChar = word[0];
            bool isSameChar = firstChar == _matrix.ElementAt(row)[col];
            return isSameChar ? CountWords(word.Substring(1), MoverRow(row), MoverCol(col)) : (byte)0;
        }
    }

    public class FinderHorizontalLeft : FinderAbstract
    {
        public override bool CanContinue { get => CanLeft; set => throw new NotImplementedException(); }

        public override byte MoverCol(byte currentCol)
        {
            return (byte)(currentCol - 1);
        }

        public override byte MoverRow(byte currentRow)
        {
            return currentRow;
        }
    }
    public class FinderHorizontalRight : FinderAbstract
    {
        public override bool CanContinue { get => CanRight; set => throw new NotImplementedException(); }

        public override byte MoverCol(byte currentCol)
        {
            return (byte)(currentCol + 1);
        }

        public override byte MoverRow(byte currentRow)
        {
            return currentRow;
        }
    }
    public class FinderDiagonalLeftUp : FinderAbstract
    {
        public override bool CanContinue { get => CanLeft && CanUp; set => throw new NotImplementedException(); }

        public override byte MoverCol(byte currentCol)
        {
            return (byte)(currentCol -1);
        }

        public override byte MoverRow(byte currentRow)
        {
            return (byte)(currentRow -1);
        }
    }
    public class FinderDiagonalLeftDown : FinderAbstract
    {
        public override bool CanContinue { get => CanLeft&&CanDown; set => throw new NotImplementedException(); }

        public override byte MoverCol(byte currentCol)
        {
            return (byte)(currentCol -1);
        }

        public override byte MoverRow(byte currentRow)
        {
            return (byte)(currentRow +1);
        }
    }
    public class FinderDiagonalRightUp : FinderAbstract
    {
        public override bool CanContinue { get => CanRight&&CanUp; set => throw new NotImplementedException(); }

        public override byte MoverCol(byte currentCol)
        {
            return (byte)(currentCol +1);
        }

        public override byte MoverRow(byte currentRow)
        {
            return (byte)(currentRow -1);
        }
    }
    public class FinderDiagonalRightDown : FinderAbstract
    {
        public override bool CanContinue { get => CanRight&&CanDown; set => throw new NotImplementedException(); }

        public override byte MoverCol(byte currentCol)
        {
            return (byte)(currentCol +1);
        }

        public override byte MoverRow(byte currentRow)
        {
            return (byte)(currentRow +1);
        }

    }
    public class FinderVerticalUp : FinderAbstract
    {
        public override bool CanContinue { get => CanUp; set => throw new NotImplementedException(); }

        public override byte MoverCol(byte currentCol)
        {
            return currentCol;
        }

        public override byte MoverRow(byte currentRow)
        {
            return (byte)(currentRow-1);
        }
    }
    public class FinderVerticalDown : FinderAbstract
    {
        public override bool CanContinue { get => CanDown; set => throw new NotImplementedException(); }

        public override byte MoverCol(byte currentCol)
        {
            return currentCol;
        }

        public override byte MoverRow(byte currentRow)
        {
            return (byte)(currentRow+1);
        }
    }
}