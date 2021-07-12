using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.UnitTests
{
    public class FinderDiagonalRightDownTests
    {
        private FinderAbstract finderDiagonalRightDown;
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
            finderDiagonalRightDown = new FinderDiagonalRightDown();
        }


        [Test]
        public void GivenAMatrix_WhenFindAWord_ThenReturnTheTotalCountForWordToRightDown()
        {
            byte expected = 1;
            finderDiagonalRightDown.CanDown = true;
            finderDiagonalRightDown.CanRight = true;
            byte actual = finderDiagonalRightDown.Find(_matrix, "chill", 0, 0);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenAMatrix_WhenCannotRight_ThenReturnZeroFoundsForWord()
        {
            byte expected = 0;
            finderDiagonalRightDown.CanDown = true;
            finderDiagonalRightDown.CanRight = false;
            byte actual = finderDiagonalRightDown.Find(_matrix, "chill", 0, 0);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenAMatrix_WhenCannotDown_ThenReturnZeroFoundsForWord()
        {
            byte expected = 0;
            finderDiagonalRightDown.CanDown = false;
            finderDiagonalRightDown.CanRight = true;
            byte actual = finderDiagonalRightDown.Find(_matrix, "chill", 0, 0);

            Assert.AreEqual(expected, actual);
        }

    }
}
