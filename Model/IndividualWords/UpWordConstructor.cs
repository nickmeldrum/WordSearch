namespace Model.IndividualWords {
    public class UpWordConstructor : BaseWordConstructor, IWordConstructor {
        public UpWordConstructor(int startLetter, WordSearchBox wordSearchBox)
            : base(startLetter, wordSearchBox) { }

        public int MaxLettersToSearch {
            get { return MaxLettersToSearchCalculator.Up; }
        }

        public string Direction {
            get { return "up"; }
        }

        public override int[] CharacterIndexes(int currentWordLength) {
            var a = new int[currentWordLength];
            for (var i = 0; i < currentWordLength; i++) {
                a[i] = StartLetter - (WordSearchBox.Width * i);
            }
            return a;
        }
    }
}