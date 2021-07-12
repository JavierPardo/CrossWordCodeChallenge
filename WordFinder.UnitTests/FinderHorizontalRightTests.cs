using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.UnitTests
{
    public class FinderHorizontalRightTests
    {
        private FinderAbstract finderHorizontalRight;
        private readonly IEnumerable<string> _matrix = new string[] {
        "acold",
        "fgwio",
        "llihc",
        "chill",
        "uvdxy",
        };
        [SetUp]
        public void Setup()
        {
            finderHorizontalRight = new FinderHorizontalRight();
        }

        [Test]
        public void GivenAMatrix_WhenFindAWord_ThenReturnTheTotalCountForWordToRight()
        {
            var expected = 1;
            finderHorizontalRight.CanRight = true;
            int actual = finderHorizontalRight.Find(_matrix, "chill", 3, 0);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenAMatrix_WhenCannotRight_ThenReturnZeroFoundsForWord()
        {
            var expected = 0;
            finderHorizontalRight.CanRight = false;
            int actual = finderHorizontalRight.Find(_matrix, "chill", 3, 0);

            Assert.AreEqual(expected, actual);
        }
    }
}
