using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.UnitTests
{
    public class FinderVerticalUpTests { 
        private FinderAbstract finderVerticalUp;
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
            finderVerticalUp = new FinderVerticalUp();
        }

        [Test]
        public void GivenAMatrix_WhenFindAWord_ThenReturnTheTotalCountForWordToUp()
        {
            var expected = 1;
            finderVerticalUp.CanUp = true;
            int actual = finderVerticalUp.Find(_matrix, "cold", 3, 4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenAMatrix_WhenCannotUp_ThenReturnZeroFoundsForWord()
        {
            var expected = 0;
            finderVerticalUp.CanUp = false;
            int actual = finderVerticalUp.Find(_matrix, "cold", 3, 4);

            Assert.AreEqual(expected, actual);
        }

    }
}
