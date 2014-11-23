namespace Model.IndividualWords {
    public class DiagonallyRightDownWordConstructor : BaseWordConstructor, IWordConstructor {
        public DiagonallyRightDownWordConstructor(int startLetter, WordSearchBox wordSearchBox)
            : base(startLetter, wordSearchBox) { }

        public int MaxLettersToSearch {
            get {
                return MaxLettersToSearchCalculator.DiagonallyRightDown;
            }
        }

        public string Direction {
            get { return "diagonally right and down"; }
        }

        public override int[] CharacterIndexes(int currentWordLength) {
            var a = new int[currentWordLength];
            for (var i = currentWordLength - 1; i >= 0; i--) {
                a[i] += StartLetter + (WordSearchBox.Width * i) + i;
            }
            return a;
        }
    }
}