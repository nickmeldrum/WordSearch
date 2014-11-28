using System;
using Model.IndividualWords;
using Model.Search;
using NUnit.Framework;

namespace Model.Test.IndividualWordCheck {
    public abstract class IndividualWordCheckTestFixtureBase {
        private Tuple<string, bool> TestAWordCheck(WordSearchBox wordSearchBox, int length, IWordConstructor wordConstructor) {
            var searchEngine = new SearchEngine(wordSearchBox, new WordList());

            return searchEngine.CheckWordOfOneLengthInOneDirection(length, wordConstructor);
        }

        protected void TestAWordIsFound(string wordSearchLetters, int boxWidth, int wordLength, string word, Func<WordSearchBox, IWordConstructor> createWordConstructor) {
            var searchBox = new WordSearchBox(wordSearchLetters, boxWidth);
            var wordConstructor = createWordConstructor(searchBox);
            var result = TestAWordCheck(searchBox, wordLength, wordConstructor);

            Assert.IsTrue(result.Item2);
            Assert.AreEqual(word, result.Item1);
        }

        protected void TestAWordIsntFound(string wordSearchLetters, int boxWidth, int wordLength, Func<WordSearchBox, IWordConstructor> createWordConstructor) {
            var searchBox = new WordSearchBox(wordSearchLetters, boxWidth);
            var wordConstructor = createWordConstructor(searchBox);
            var result = TestAWordCheck(searchBox, wordLength, wordConstructor);

            Assert.IsFalse(result.Item2);
        }
    }
}