namespace Model.IndividualWords {
    public class LeftWordConstructor : BaseWordConstructor, IWordConstructor {
        public LeftWordConstructor(int startLetter, WordSearchBox wordSearchBox)
            : base(startLetter, wordSearchBox) { }

        public int MaxLettersToSearch {
            get { return MaxLettersToSearchCalculator.Left; }
        }

        public string Direction {
            get { return "left"; }
        }

        public override int[] CharacterIndexes(int currentWordLength) {
            var a = new int[currentWordLength];
            for (var i = 0; i < currentWordLength; i++) {
                a[i] = StartLetter - i;
            }
            return a;
        }
    }
}