using Model.IndividualWords;
using NUnit.Framework;

namespace Model.Test.IndividualWordCheck {
    [TestFixture]
    public class IndividualLeftWordCheckTestFixture : IndividualWordCheckTestFixtureBase {
        [Test]
        [TestCase("drowabcdabcdabcd", 4, 3, 4, "word")]
        public void TestALeftWordIsFound(string wordSearchLetters, int boxWidth,
                                         int startLetter, int wordLength, string word) {
            TestAWordIsFound(wordSearchLetters, boxWidth, wordLength, word,
                searchBox => new LeftWordConstructor(startLetter, searchBox));
        }

        [Test]
        [TestCase("wordabcdabcdabcd", 4, 3, 4)]
        public void TestALeftWordIsNotFoundIfDoesntExist(string wordSearchLetters, int boxWidth,
                                                         int startLetter, int wordLength) {
            TestAWordIsntFound(wordSearchLetters, boxWidth, wordLength,
                               searchBox => new LeftWordConstructor(startLetter, searchBox));
        }
    }
}