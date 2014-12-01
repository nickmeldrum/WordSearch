namespace Model.Test {
    using Model.Search;
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class SearchEngineTestFixture
    {
        [TestCase("Wikipedia")]
        [TestCase("Computers")]
        public void SearchEngineFindsExpectedWordsInTestData(string testName)
        {
            // arrange
            var testData = new WordSearchResourceData(testName);
            var wordSearchBox = new WordSearchBox(testData.Letters, testData.Width);
            var expectedWords = testData.ExpectedWords;
            var wordList = new WordList();
            wordList.AddWordsToList(expectedWords);
            var searchEngine = new SearchEngine(wordSearchBox, wordList);

            // act
            searchEngine.CheckAllPossibleWords();
            var wordsNotFound = expectedWords.Where(expectedWord => !searchEngine.FoundWords.Contains(expectedWord)).ToList();

            // assert
            Assert.IsEmpty(wordsNotFound, "Expected words weren't found", wordsNotFound);
        }


        [TestCase("Test")]
        public void RunWholeSearchEngineUsingTestDataAndJustOutput(string testName)
        {
            // arrange
            var testData = new WordSearchResourceData(testName);
            var wordSearchBox = new WordSearchBox(testData.Letters, testData.Width);
            var wordList = new WordList();
            var searchEngine = new SearchEngine(wordSearchBox, wordList);
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
