namespace Model {
    public class WordSearchBox {
        public string Letters { get; private set; }
        public int BoxWidth { get; private set; }
        public int BoxHeight {
            get {
                return Letters.Length / BoxWidth;
            }
        }

        public WordSearchBox() {
            InitialiseFromResourceFile();
        }

        public WordSearchBox(string letters, int boxWidth) {
            Letters = letters;
            BoxWidth = boxWidth;
        }

        private void InitialiseFromResourceFile() {
            Letters = Resources.Letters;
            BoxWidth = int.Parse(Resources.BoxWidth);
        }
    }
}