using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.UnitTests
{
    public class FinderVerticalDownTests { 
        private FinderAbstract finderVerticalDown;
        private readonly IEnumerable<string> _matrix = new string[] {
        "ccold",
        "ogwil",
        "lliho",
        "dhilc",
        "uvdxy",
        };
        [SetUp]
        public void Setup()
        {
            finderVerticalDown = new FinderVerticalDown();

        }

        [Test]
        public void GivenAMatrix_WhenFindAWord_ThenReturnTheTotalCountForWordToDown()
        {
            var expected = 1;
            finderVerticalDown.CanDown = true;
            int actual = finderVerticalDown.Find(_matrix, "cold", 0, 0);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenAMatrix_WhenCannotDown_ThenReturnZeroFoundsForWord()
        {
            var expected = 0;
            finderVerticalDown.CanDown = false;
            int actual = finderVerticalDown.Find(_matrix, "cold", 0, 0);

            Assert.AreEqual(expected, actual);
        }
    }
}
