namespace Model.IndividualWords {
    public class DiagonallyLeftDownWordConstructor : BaseWordConstructor, IWordConstructor {
        public DiagonallyLeftDownWordConstructor(int startLetter, WordSearchBox wordSearchBox)
            : base(startLetter, wordSearchBox) { }

        public int MaxLettersToSearch {
            get { return MaxLettersToSearchCalculator.DiagonallyLeftDown; }
        }

        public string Direction {
            get { return "diagonally left and down"; }
        }

        public override int[] CharacterIndexes(int currentWordLength) {
            var a = new int[currentWordLength];
            for (var i = currentWordLength - 1; i >= 0; i--) {
                a[i] += StartLetter + (WordSearchBox.BoxWidth * i) + i;
            }
            return a;
        }
    }
}