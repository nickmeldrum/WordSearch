using Model.IndividualWords;
using NUnit.Framework;

namespace Model.Test.IndividualWordCheck {
    [TestFixture]
    public class IndividualDiagonallyRightDownWordCheckTestFixture : IndividualWordCheckTestFixtureBase {
        [TestCase("wzzzzozzzzrzzzzd", 4, 0, 4, "word")]
        public void TestADiagonallyRightDownWordIsFound(string wordSearchLetters, int boxWidth,
                                         int startLetter, int wordLength, string word) {
            TestAWordIsFound(wordSearchLetters, boxWidth, wordLength, word,
                searchBox => new DiagonallyRightDownWordConstructor(startLetter, searchBox));
        }

        [TestCase("zzzzzzzzzzzzzzzz", 4, 0, 4)]
        public void TestADiagonallyRightDownDownWordIsNotFoundIfDoesntExist(string wordSearchLetters, int boxWidth,
                                                         int startLetter, int wordLength) {
            TestAWordIsntFound(wordSearchLetters, boxWidth, wordLength,
                               searchBox => new DiagonallyRightDownWordConstructor(startLetter, searchBox));
        }
    }
}
