namespace Model.Search {
    public class MaxLettersToSearchCalculator {
        private readonly int startLetter;
        private readonly int boxWidth;
        private readonly int boxHeight;

        public int Left { get { return CurrentColumn + 1; } }
        public int Right { get { return boxWidth - CurrentColumn; } }
        public int Up { get { return CurrentRow + 1; } }
        public int Down { get { return boxHeight - CurrentRow; } }
        public int DiagonallyLeftUp { get { return (Left < Up) ? Left : Up; } }
        public int DiagonallyRightUp { get { return (Right < Up) ? Right : Up; } }
        public int DiagonallyLeftDown { get { return (Left < Down) ? Left : Down; } }
        public int DiagonallyRightDown { get { return (Right < Down) ? Right : Down; } }

        public int CurrentRow { get { return startLetter / boxWidth; } }
        public int CurrentColumn { get { return startLetter % boxWidth; } }

        public MaxLettersToSearchCalculator(int startLetter, int boxWidth, int boxHeight) {
            this.startLetter = startLetter;
            this.boxWidth = boxWidth;
            this.boxHeight = boxHeight;
        }
    }
}