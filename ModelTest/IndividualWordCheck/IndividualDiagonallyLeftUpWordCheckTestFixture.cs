using Model.IndividualWords;
using NUnit.Framework;

namespace Model.Test.IndividualWordCheck {
    [TestFixture]
    public class IndividualDiagonallyLeftUpWordCheckTestFixture : IndividualWordCheckTestFixtureBase {
        [Test]
        [TestCase("dzzzzrzzzzozzzzw", 4, 15, 4, "word")]
        public void TestADiagonallyLeftUpWordIsFound(string wordSearchLetters, int boxWidth,
                                         int startLetter, int wordLength, string word) {
            TestAWordIsFound(wordSearchLetters, boxWidth, wordLength, word,
                searchBox => new DiagonallyLeftUpWordConstructor(startLetter, searchBox));
        }

        [Test]
        [TestCase("zzzzzzzzzzzzword", 4, 15, 4)]
        public void TestADiagonallyLeftUpDownWordIsNotFoundIfDoesntExist(string wordSearchLetters, int boxWidth,
                                                         int startLetter, int wordLength) {
            TestAWordIsntFound(wordSearchLetters, boxWidth, wordLength,
                               searchBox => new DiagonallyLeftUpWordConstructor(startLetter, searchBox));
        }
    }
}
