using Model.IndividualWords;
using NUnit.Framework;

namespace Model.Test.IndividualWordCheck {
    [TestFixture]
    public class IndividualDiagonallyRightUpWordCheckTestFixture : IndividualWordCheckTestFixtureBase {
        [Test]
        [TestCase("zzzdzzrzzozzwzzz", 4, 12, 4, "word")]
        public void TestADiagonallyRightUpWordIsFound(string wordSearchLetters, int boxWidth,
                                         int startLetter, int wordLength, string word) {
            TestAWordIsFound(wordSearchLetters, boxWidth, wordLength, word,
                searchBox => new DiagonallyRightUpWordConstructor(startLetter, searchBox));
        }

        [Test]
        [TestCase("zzzzzzzzzzzzzzzz", 4, 12, 4)]
        public void TestADiagonallyRightUpDownWordIsNotFoundIfDoesntExist(string wordSearchLetters, int boxWidth,
                                                         int startLetter, int wordLength) {
            TestAWordIsntFound(wordSearchLetters, boxWidth, wordLength,
                               searchBox => new DiagonallyRightUpWordConstructor(startLetter, searchBox));
        }
    }
}
