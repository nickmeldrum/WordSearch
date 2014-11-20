using Model.IndividualWords;
using NUnit.Framework;

namespace Model.Test.IndividualWordCheck {
    [TestFixture]
    public class IndividualDownWordCheckTestFixture : IndividualWordCheckTestFixtureBase {
        [TestCase("wzzzozzzrzzzdzzz", 4, 0, 4, "word")]
        public void TestADownWordIsFound(string wordSearchLetters, int boxWidth,
                                         int startLetter, int wordLength, string word) {
            TestAWordIsFound(wordSearchLetters, boxWidth, wordLength, word,
                searchBox => new DownWordConstructor(startLetter, searchBox));
        }

        [TestCase("wordzzzzzzzzzzzz", 4, 0, 4)]
        public void TestADownWordIsNotFoundIfDoesntExist(string wordSearchLetters, int boxWidth,
                                                         int startLetter, int wordLength) {
            TestAWordIsntFound(wordSearchLetters, boxWidth, wordLength,
                               searchBox => new DownWordConstructor(startLetter, searchBox));
        }
    }
}