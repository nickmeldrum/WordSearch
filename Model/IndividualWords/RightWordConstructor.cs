namespace Model.IndividualWords {
    public class RightWordConstructor : BaseWordConstructor, IWordConstructor {
        public RightWordConstructor(int startLetter, WordSearchBox wordSearchBox)
            : base(startLetter, wordSearchBox) { }

        public int MaxLettersToSearch {
            get { return MaxLettersToSearchCalculator.Right; }
        }

        public string Direction {
            get { return "right"; }
        }

        public override int[] CharacterIndexes(int currentWordLength) {
            var a = new int[currentWordLength];
            for (var i = 0; i < currentWordLength; i++) {
                a[i] = StartLetter + i;
            }
            return a;
        }
    }
}