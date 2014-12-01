namespace Model.Test.SearchEngines
{
    using System.Linq;

    using Model.Data;
    using Model.Search;
    using NUnit.Framework;

    [TestFixture]
    public class SearchEngineTestFixture
    {
        [Test]
        public void SearchEngine()
        {
            // arrange
            var data = new SearchEngineData("", 1);
            var searchEngine = SearchEngineFactory.Get(data);

            // act
            searchEngine.CheckAllPossibleWords();
            var wordsNotFound = data.ExpectedWords.Where(expectedWord => !searchEngine.FoundWords.Contains(expectedWord)).ToList();

            // assert
            Assert.IsEmpty(wordsNotFound, "Expected words weren't found", wordsNotFound);
        }
    }
}