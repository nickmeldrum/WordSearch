using NUnit.Framework;

namespace Model.Test {
    [TestFixture]
    public class SearchEngineTestFixture {

        [Test]
        public void TestSearchEngine()
        {
            var searchEngine = new SearchEngine();

            searchEngine.Search();
        }
    }
}
