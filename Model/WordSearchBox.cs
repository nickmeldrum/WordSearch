namespace Model {
    public class WordSearchBox {
        public string Letters { get; private set; }
        public int Width { get; private set; }
        public int Height {
            get {
                return Letters.Length / Width;
            }
        }

        public WordSearchBox(string letters, int width)
        {
            Letters = letters;
            Width = width;
        }
    }
}