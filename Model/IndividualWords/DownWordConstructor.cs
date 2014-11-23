namespace Model.IndividualWords {
    public class DownWordConstructor : BaseWordConstructor, IWordConstructor {
        public DownWordConstructor(int startLetter, WordSearchBox wordSearchBox)
            : base(startLetter, wordSearchBox) { }

        public int MaxLettersToSearch {
            get { return MaxLettersToSearchCalculator.Down; }
        }

        public string Direction {
            get { return "down"; }
        }

        public override int[] CharacterIndexes(int currentWordLength) {
            var a = new int[currentWordLength];
            for (var i = 0; i < currentWordLength; i++) {
                a[i] = StartLetter + (WordSearchBox.Width * i);
            }
            return a;
        }
    }
}