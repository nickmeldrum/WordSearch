namespace Model.Test.SearchEngines
{
    using System.Linq;

    using Model.Data;
    using Model.Search;
    using NUnit.Framework;

    [TestFixture]
    public class SearchEngineTestFixture
    {
        [TestCase("aword", 5, new[] { "word" })]
        public void SearchEngineWordsAreFound(string letters, int width, string[] expectedWords)
        {
            // arrange
            var data = new SearchEngineData(letters, width, expectedWords);
            var searchEngine = SearchEngineFactory.Get(data);

            // act
            searchEngine.CheckAllPossibleWords();
            var wordsNotFound = data.ExpectedWords.Where(expectedWord => !searchEngine.FoundWords.Contains(expectedWord)).ToList();

            // assert
            Assert.IsEmpty(wordsNotFound, "Expected words weren't found", wordsNotFound);
        }

        [TestCase("award", 5, new[] { "word" })]
        public void SearchEngineWordsAreNotFound(string letters, int width, string[] expectedWords)
        {
            // arrange
            var data = new SearchEngineData(letters, width, expectedWords);
            var searchEngine = SearchEngineFactory.Get(data);

            // act
            searchEngine.CheckAllPossibleWords();
            var wordsNotFound = data.ExpectedWords.Where(expectedWord => !searchEngine.FoundWords.Contains(expectedWord)).ToList();

            // assert
            CollectionAssert.AreEquivalent(expectedWords, wordsNotFound, "Expected words were found");
        }
    }
}