using Model.IndividualWords;
using NUnit.Framework;

namespace Model.Test.IndividualWordCheck {
    [TestFixture]
    public class IndividualUpWordCheckTestFixture : IndividualWordCheckTestFixtureBase {
        [TestCase("dzzzrzzzozzzwzzz", 4, 12, 4, "word")]
        public void TestAnUpWordIsFound(string wordSearchLetters, int boxWidth,
                                         int startLetter, int wordLength, string word) {
            TestAWordIsFound(wordSearchLetters, boxWidth, wordLength, word,
                searchBox => new UpWordConstructor(startLetter, searchBox));
        }

        [TestCase("zzzzzzzzzzzzzzzz", 4, 12, 4)]
        public void TestAnUpWordIsNotFoundIfDoesntExist(string wordSearchLetters, int boxWidth,
                                                         int startLetter, int wordLength) {
            TestAWordIsntFound(wordSearchLetters, boxWidth, wordLength,
                               searchBox => new UpWordConstructor(startLetter, searchBox));
        }
    }
}