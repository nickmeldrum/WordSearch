using System;
using Model.Search;
using NUnit.Framework;

namespace Model.Test {
    using System.Linq;

    [TestFixture]
    public class SearchEngineTestFixture
    {
        [TestCase("Wikipedia")]
        [TestCase("Computers")]
        public void SearchEngineFindsExpectedWordsInTestData(string testName)
        {
            // arrange
            var wordSearchBox = new WordSearchBox(getLetters(testName), getWidth(testName));
            var expectedWords = getExpectedWords(testName);
            var wordList = new WordList();
            wordList.AddWordsToList(expectedWords);
            var searchEngine = new SearchEngine(wordSearchBox, wordList);

            // act
            searchEngine.CheckAllPossibleWords();
            var wordsNotFound = expectedWords.Where(expectedWord => !searchEngine.FoundWords.Contains(expectedWord)).ToList();

            // assert
            Assert.IsEmpty(wordsNotFound, "Expected words weren't found", wordsNotFound);

        }

        private string getLetters(string testName)
        {
            return getResourceString(testName + "Letters");
        }

        private int getWidth(string testName)
        {
            return int.Parse(getResourceString(testName + "Width"));
        }

        private string[] getExpectedWords(string testName)
        {
            return getResourceString(testName + "Words").Split(';');
        }

        private string getResourceString(string name)
        {
            var resourceString = Resources.ResourceManager.GetString(name);
            if (string.IsNullOrWhiteSpace(resourceString)) throw new ArgumentException("Resource not found", name);
            return resourceString.ToLowerInvariant().Trim();
        }

        [TestCase("Test")]
        public void RunWholeSearchEngineUsingTestDataAndJustOutput(string testName)
        {
            // arrange
            var wordSearchBox = new WordSearchBox(getLetters(testName), getWidth(testName));
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
