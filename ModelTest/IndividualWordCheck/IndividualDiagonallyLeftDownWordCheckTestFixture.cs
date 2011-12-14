using Model.IndividualWords;
using NUnit.Framework;

namespace Model.Test.IndividualWordCheck {
    [TestFixture]
    public class IndividualDiagonallyLeftDownWordCheckTestFixture : IndividualWordCheckTestFixtureBase {
        [Test]
        [TestCase("zzzwzzozzrzzdzzz", 4, 3, 4, "word")]
        public void TestADiagonallyLeftDownWordIsFound(string wordSearchLetters, int boxWidth,
                                         int startLetter, int wordLength, string word) {
            TestAWordIsFound(wordSearchLetters, boxWidth, wordLength, word,
                searchBox => new DiagonallyLeftDownWordConstructor(startLetter, searchBox));
        }

        [Test]
        [TestCase("wordzzzzzzzzzzzz", 4, 3, 4)]
        public void TestADiagonallyLeftDownWordIsNotFoundIfDoesntExist(string wordSearchLetters, int boxWidth,
                                                         int startLetter, int wordLength) {
            TestAWordIsntFound(wordSearchLetters, boxWidth, wordLength,
                               searchBox => new DiagonallyLeftDownWordConstructor(startLetter, searchBox));
        }
    }
}
