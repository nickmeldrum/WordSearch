namespace Model.Data
{
    using System.Collections.Generic;

    public class SearchEngineData : IEngineData
    {
        public SearchEngineData(string letters, int width) : this(letters, width, new string[]{})
        {
        }

        public SearchEngineData(string letters, int width, IList<string> expectedWords)
        {
            this.ExpectedWords = expectedWords;
            this.Width = width;
            this.Letters = letters;
        }

        public string Letters { get; private set; }
        public int Width { get; private set; }
        public IList<string> ExpectedWords { get; private set; }
    }
}