namespace Model.Test.SearchEngines
{
    using System.Linq;
    using Model.Search;
    using NUnit.Framework;

    [TestFixture]
    public class SearchEngineTestFixture
    {
        public void SearchEngine(string testName)
        {
            // arrange
            var data = new WordSearchResourceData(testName);
            var searchEngine = SearchEngineFactory.Get(data);

            // act
            searchEngine.CheckAllPossibleWords();
            var wordsNotFound = data.ExpectedWords.Where(expectedWord => !searchEngine.FoundWords.Contains(expectedWord)).ToList();

            // assert
            Assert.IsEmpty(wordsNotFound, "Expected words weren't found", wordsNotFound);
        }
    }
}
