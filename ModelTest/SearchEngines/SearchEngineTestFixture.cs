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
        [TestCase("adrow", 5, new[] { "word" })]
        [TestCase("czzazztzz", 3, new[] { "cat" })]
        [TestCase("tzzazzczz", 3, new[] { "cat" })]
        [TestCase("catozzwzz", 3, new[] { "cat", "cow" })]
        [TestCase("czzzazzzr", 3, new[] { "car" })]
        [TestCase("rzzzazzzc", 3, new[] { "car" })]
        [TestCase("ratzazczc", 3, new[] { "rat", "cat", "car" })]
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
        [TestCase("catozzwzz", 3, new[] { "cat", "cow", "dog" })]
        public void SearchEngineWordsAreNotFound(string letters, int width, string[] expectedWords)
        {
            // arrange
            var data = new SearchEngineData(letters, width, expectedWords);
            var searchEngine = SearchEngineFactory.Get(data);

            // act
            searchEngine.CheckAllPossibleWords();
            var wordsNotFound = data.ExpectedWords.Where(expectedWord => !searchEngine.FoundWords.Contains(expectedWord)).ToList();

            // assert
            Assert.IsNotEmpty(wordsNotFound, "All words were found");
        }
    }
}