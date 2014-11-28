namespace Model.Test.WordLists
{
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class WordListTestFixture
    {
        [Test]
        public void TestWhenWordsAddedTheFirstWordIsFound()
        {
            // arrange
            var newWords = new List<string> { "firstword", "middleword", "lastword" };
            var wordList = new WordList();

            // act
            wordList.AddWordsToList(newWords);

            // assert
            Assert.IsTrue(wordList.IsInWordList("firstword"));
        }

        [Test]
        public void TestWhenWordsAddedTheMiddleWordIsFound()
        {
            // arrange
            var newWords = new List<string> { "firstword", "middleword", "lastword" };
            var wordList = new WordList();

            // act
            wordList.AddWordsToList(newWords);

            // assert
            Assert.IsTrue(wordList.IsInWordList("middleword"));
        }
        [Test]

        public void TestWhenWordsAddedTheLastWordIsFound()
        {
            // arrange
            var newWords = new List<string> { "firstword", "middleword", "lastword" };
            var wordList = new WordList();

            // act
            wordList.AddWordsToList(newWords);

            // assert
            Assert.IsTrue(wordList.IsInWordList("lastword"));
        }
    }
}
