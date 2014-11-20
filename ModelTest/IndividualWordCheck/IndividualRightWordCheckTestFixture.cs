using Model.IndividualWords;
using NUnit.Framework;

namespace Model.Test.IndividualWordCheck {
    [TestFixture]
    public class IndividualRightWordCheckTestFixture : IndividualWordCheckTestFixtureBase {
        [TestCase("wordabcdabcdabcd", 4, 0, 4, "word")]
        public void TestARightWordIsFound(string wordSearchLetters, int boxWidth,
                                         int startLetter, int wordLength, string word) {
            TestAWordIsFound(wordSearchLetters, boxWidth, wordLength, word,
                searchBox => new RightWordConstructor(startLetter, searchBox));
        }

        [TestCase("abcdabcdabcdabcd", 4, 0, 4)]
        public void TestARightWordIsNotFoundIfDoesntExist(string wordSearchLetters, int boxWidth,
                                                         int startLetter, int wordLength) {
            TestAWordIsntFound(wordSearchLetters, boxWidth, wordLength,
                               searchBox => new RightWordConstructor(startLetter, searchBox));
        }
    }
}