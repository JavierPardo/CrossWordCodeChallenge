using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WordFinder.UnitTests
{
    public class Tests
    {
        private WordFinder wordFinder;
        private readonly IEnumerable<string> matrix = new string[] { 
        "izixi",
        "waaar",
        "iacai",
        "taaax",
        "iyiyi",
        };

        [SetUp]
        public void Setup()
        {
            wordFinder = new WordFinder(matrix);
        }

        [Test]
        public void GivenAMatrix_WhenWordsHaveBeenFound_ThenShouldReturnOnlyAppeared()
        {
            IEnumerable<string> words = new string[]{
                "snow",
                "acai",
                "xaaa",
                "waaa",
                };

            var expected = new string[] { "acai",
                "xaaa",
                "waaa"
            };

            var actual = wordFinder.Find(words);

            Assert.AreEqual(expected.Count(), actual.Count());
            for (int i = 0; i < actual.Count(); i++)
            {
                Assert.AreEqual(expected[i], actual.ElementAt(i));
            }
        }

        [Test]
        public void GivenAMatrix_WhenIsMoreThanTenWords_ThenReturnOnlyTenMostAppeared()
        {
            var moreThanTenWordsToFind = new string[] { "acai",
                "waaa",
                "xaaa",
                "snow",
                "xxxx",
                "yyyy",
                "zzzz",
                "aaaa",
                "bbbb",
                "cccc",
                "dddd",
                "eeee",
            };
            var expected = new string[] { 
                "acai",
                "xaaa",
                "waaa"              
            };

            var actual = wordFinder.Find(moreThanTenWordsToFind);

            Assert.AreEqual(expected.Count(), actual.Count());
            for (int i = 0; i < actual.Count(); i++)
            {
                Assert.AreEqual(expected[i], actual.ElementAt(i));
            }
        }
    }
}