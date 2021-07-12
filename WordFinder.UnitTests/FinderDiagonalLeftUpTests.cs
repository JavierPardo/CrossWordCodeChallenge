using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.UnitTests
{
    public class FinderDiagonalLeftUpTests
    {
        private FinderAbstract finderDiagonalLeftUp;
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
            finderDiagonalLeftUp = new FinderDiagonalLeftUp();
        }

        [Test]
        public void GivenAMatrix_WhenFindAWord_ThenReturnTheTotalCountForWordToLeftUp()
        {
            byte expected = 1;
            finderDiagonalLeftUp.CanLeft = true;
            finderDiagonalLeftUp.CanUp = true;
            byte actual = finderDiagonalLeftUp.Find(_matrix, "llihc", 4, 4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenAMatrix_WhenCannotLeft_ThenReturnZeroFoundsForWord()
        {
            byte expected = 0;
            finderDiagonalLeftUp.CanLeft = false;
            finderDiagonalLeftUp.CanUp = true;
            byte actual = finderDiagonalLeftUp.Find(_matrix, "llihc", 4, 4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenAMatrix_WhenCannotUp_ThenReturnZeroFoundsForWord()
        {
            byte expected = 0;
            finderDiagonalLeftUp.CanLeft = true;
            finderDiagonalLeftUp.CanUp = false;
            byte actual = finderDiagonalLeftUp.Find(_matrix, "llihc", 4, 4);

            Assert.AreEqual(expected, actual);
        }
    }
}
