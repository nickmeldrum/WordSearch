using Model.Search;
using NUnit.Framework;

namespace Model.Test {
    using System.Collections.Generic;

    [TestFixture]
    public class SearchEngineTestFixture {
        [Test]
        public void SearchEngineFindsExpectedWordsInTestData()
        {
            // arrange
            var wordSearchBox = new WordSearchBox(Resources.Test2Letters, int.Parse(Resources.Test2Width));
            var searchEngine = new SearchEngine(wordSearchBox);
            var expectedWords = Resources.Test2Words.ToLowerInvariant().Split(';');

            // act
            searchEngine.CheckAllPossibleWords();

            // assert
            foreach (var expectedWord in expectedWords)
            {
                if (!searchEngine.FoundWords.Contains(expectedWord))
                    Assert.Fail("Expected word {0} wasn't found", expectedWord);
            }
        }

        [TestCaseSource("GetTestData")]
        public void RunWholeSearchEngineUsingTestDataAndJustOutput(TestData testData) {
            // arrange
            var wordSearchBox = new WordSearchBox(testData.Letters, testData.Width);
            var searchEngine = new SearchEngine(wordSearchBox);
            var resultsOutput = new SearchResultsOutput();

            searchEngine.BoxesBeingSearched += resultsOutput.OutputBoxesBeingSearched;
            searchEngine.FoundWord += resultsOutput.OutputFoundWord;

            // act
            searchEngine.CheckAllPossibleWords();

            // assert
            resultsOutput.OutputAllFoundWords(searchEngine.FoundWords);
        }

        public IEnumerable<TestData> GetTestData()
        {
            yield return new TestData { Letters = Resources.Test1Letters, Width = int.Parse(Resources.Test1Width) };
            yield return new TestData { Letters = Resources.Test2Letters, Width = int.Parse(Resources.Test2Width) };
        }
    }

    public class TestData
    {
        public string Letters { get; set; }
        public int Width { get; set; }
    }
}
