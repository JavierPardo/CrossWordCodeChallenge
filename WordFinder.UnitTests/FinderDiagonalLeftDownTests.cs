using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.UnitTests
{
    public class FinderDiagonalLeftDownTests
    {
        private FinderAbstract finderDiagonalLeftDown;
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
            finderDiagonalLeftDown = new FinderDiagonalLeftDown();
        }

        [Test]
        public void GivenAMatrix_WhenFindAWord_ThenReturnTheTotalCountForWordToLeftDown()
        {
            byte expected = 1;
            finderDiagonalLeftDown.CanLeft = true;
            finderDiagonalLeftDown.CanDown = true;
            byte actual = finderDiagonalLeftDown.Find(_matrix, "chiol", 0, 4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenAMatrix_WhenCannotLeft_ThenReturnZeroFoundsForWord()
        {
            byte expected = 0;
            finderDiagonalLeftDown.CanLeft = false;
            finderDiagonalLeftDown.CanDown = true;
            byte actual = finderDiagonalLeftDown.Find(_matrix, "chiol", 0, 4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenAMatrix_WhenCannotDown_ThenReturnZeroFoundsForWord()
        {
            byte expected = 0;
            finderDiagonalLeftDown.CanLeft = true;
            finderDiagonalLeftDown.CanDown = false;
            byte actual = finderDiagonalLeftDown.Find(_matrix, "chiol", 0, 4);

            Assert.AreEqual(expected, actual);
        }

    }
}
