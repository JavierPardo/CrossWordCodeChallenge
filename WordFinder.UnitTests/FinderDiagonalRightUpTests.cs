using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.UnitTests
{
    public class FinderDiagonalRightUpTests
    {
        private FinderAbstract finderDiagonalRightUp;
        private readonly IEnumerable<string> _matrix = new string[] {
        "ccolc",
        "fhwho",
        "llihc",
        "coill",
        "lvdxl",
        };
        [SetUp]
        public void Setup()
        {
            finderDiagonalRightUp = new FinderDiagonalRightUp();
        }

        [Test]
        public void GivenAMatrix_WhenFindAWord_ThenReturnTheTotalCountForWordToRightUp()
        {
            byte expected = 1;
            finderDiagonalRightUp.CanRight = true;
            finderDiagonalRightUp.CanUp = true;
            byte actual = finderDiagonalRightUp.Find(_matrix, "loihc", 4, 0);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GivenAMatrix_WhenCannotRight_ThenReturnZeroFoundsForWord()
        {
            byte expected = 0;
            finderDiagonalRightUp.CanRight = false;
            finderDiagonalRightUp.CanUp = true;
            byte actual = finderDiagonalRightUp.Find(_matrix, "loihc", 4, 0);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GivenAMatrix_WhenCannotUp_ThenReturnZeroFoundsForWord()
        {
            byte expected = 0;
            finderDiagonalRightUp.CanRight = true;
            finderDiagonalRightUp.CanUp = false;
            byte actual = finderDiagonalRightUp.Find(_matrix, "loihc", 4, 0);

            Assert.AreEqual(expected, actual);
        }

    }
}
