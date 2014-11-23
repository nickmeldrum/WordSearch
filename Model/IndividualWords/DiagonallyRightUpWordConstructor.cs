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
            for (var i = currentWordLength - 1; i >= 0; i--)
            {
                a[i] += StartLetter - (WordSearchBox.Width * i) + i;
            }
            return a;
        }
    }
}