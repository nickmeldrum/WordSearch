using Model.Search;
using NUnit.Framework;

namespace Model.Test {
    using System.Collections.Generic;

    [TestFixture]
    public class SearchEngineTestFixture {

        [TestCaseSource("GetTestData")]
        public void RunWholeSearchEngineUsingTest1DataNoTesting(TestData testData) {
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
