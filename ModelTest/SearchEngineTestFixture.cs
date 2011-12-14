using Model.Search;
using NUnit.Framework;

namespace Model.Test {
    [TestFixture]
    public class SearchEngineTestFixture {

        //[Test]
        public void RunWholeSearchEngineNoTesting() {
            // arrange
            var searchEngine = new SearchEngine();
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
