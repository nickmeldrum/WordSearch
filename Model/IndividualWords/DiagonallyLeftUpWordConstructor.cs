using System;

namespace Model.IndividualWords {
    public class DiagonallyLeftUpWordConstructor : BaseWordConstructor, IWordConstructor {
        public DiagonallyLeftUpWordConstructor(int startLetter, WordSearchBox wordSearchBox)
            : base(startLetter, wordSearchBox) { }

        public int MaxLettersToSearch {
            get { return MaxLettersToSearchCalculator.DiagonallyLeftUp; }
        }

        public string Direction {
            get { return "diagonally left and up"; }
        }

        public override int[] CharacterIndexes(int currentWordLength) {
            var a = new int[currentWordLength];

            throw new NotImplementedException();

            return a;
        }
    }
}