using System;

namespace Model.IndividualWords {
    public class DiagonallyRightUpWordConstructor : BaseWordConstructor, IWordConstructor {
        public DiagonallyRightUpWordConstructor(int startLetter, WordSearchBox wordSearchBox)
            : base(startLetter, wordSearchBox) { }

        public int MaxLettersToSearch {
            get { return MaxLettersToSearchCalculator.DiagonallyRightUp; }
        }

        public string Direction {
            get { return "diagonally right and up"; }
        }

        public override int[] CharacterIndexes(int currentWordLength) {
            var a = new int[currentWordLength];

            throw new NotImplementedException();

            return a;
        }
    }
}