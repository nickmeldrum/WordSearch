namespace Model.Test.SearchEngines {
    using System.Linq;
    using Model.Search;
    using NUnit.Framework;

    [TestFixture]
    public class SearchEngineWholeWordSearchesTestFixture
    {
        [TestCase("Wikipedia")]
        [TestCase("Computers")]
        [Ignore]
        public void SearchEngineFindsExpectedWordsInTestData(string testName)
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


        [TestCase("Test")]
        [Ignore]
        public void RunWholeSearchEngineUsingTestDataAndJustOutput(string testName)
        {
            // arrange
            var data = new WordSearchResourceData(testName);
            var searchEngine = SearchEngineFactory.Get(data);
            var resultsOutput = new SearchResultsOutput();

            searchEngine.BoxesBeingSearched += resultsOutput.OutputBoxesBeingSearched;
            searchEngine.FoundWord += resultsOutput.OutputFoundWord;

            // act
            searchEngine.CheckAllPossibleWords();

            // assert
            resultsOutput.OutputAllFoundWords(searchEngine.FoundWords);
        }
    }
}
