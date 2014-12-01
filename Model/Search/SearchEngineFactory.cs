namespace Model.Search
{
    public static class SearchEngineFactory
    {
        public static SearchEngine Get(IEngineData searchEngineData)
        {
            var wordSearchBox = new WordSearchBox(searchEngineData.Letters, searchEngineData.Width);
            var expectedWords = searchEngineData.ExpectedWords;
            var wordList = new WordList();
            wordList.AddWordsToList(expectedWords);
            return new SearchEngine(wordSearchBox, wordList);
        }
    }
}
