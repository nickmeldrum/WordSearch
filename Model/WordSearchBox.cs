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
            InitialiseBox();
        }

        private void InitialiseBox() {
            Letters = Resources.Letters;
            BoxWidth = int.Parse(Resources.BoxWidth);
        }
    }
}