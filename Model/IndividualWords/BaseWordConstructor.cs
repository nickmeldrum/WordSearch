using System.Linq;
using Model.Search;

namespace Model.IndividualWords {
    public abstract class BaseWordConstructor {
        private readonly MaxLettersToSearchCalculator maxLettersToSearchCalculator;

        protected BaseWordConstructor(int startLetter, WordSearchBox wordSearchBox) {
            StartLetter = startLetter;
            WordSearchBox = wordSearchBox;
            maxLettersToSearchCalculator = new MaxLettersToSearchCalculator(
                StartLetter, WordSearchBox.BoxWidth, WordSearchBox.BoxHeight);
        }

        protected readonly int StartLetter;
        protected readonly WordSearchBox WordSearchBox;

        protected int CurrentRow {
            get { return StartLetter / WordSearchBox.BoxWidth; }
        }

        protected int CurrentColumn {
            get { return StartLetter % WordSearchBox.BoxWidth; }
        }

        protected MaxLettersToSearchCalculator MaxLettersToSearchCalculator {
            get { return maxLettersToSearchCalculator; }
        }

        public abstract int[] CharacterIndexes(int currentWordLength);

        public string StringFromIndexes(int currentWordLength) {
            return StringFromIndexes(CharacterIndexes(currentWordLength));
        }

        public string StringFromIndexes(int[] characterIndexes) {
            return new string(characterIndexes.Select(index => WordSearchBox.Letters[index]).ToArray());
        }
    }
}