using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.UnitTests
{
    public class FinderHorizontalLeftTests
    {
        private FinderAbstract finderHorizontalLeft;
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
            finderHorizontalLeft = new FinderHorizontalLeft();
        }

        [Test]
        public void GivenAMatrix_WhenFindAWord_ThenReturnTheTotalCountForWordToLeft()
        {
            var expected = 1;
            finderHorizontalLeft.CanLeft = true;
            int actual = finderHorizontalLeft.Find(_matrix, "chill", 2, 4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenAMatrix_WhenCannotLeft_ThenReturnZeroFoundsForWord()
        {
            var expected = 0;
            finderHorizontalLeft.CanLeft = false;
            int actual = finderHorizontalLeft.Find(_matrix, "chill", 2, 4);

            Assert.AreEqual(expected, actual);
        }
    }
}
