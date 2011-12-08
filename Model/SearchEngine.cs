using System;
using System.Collections.Generic;
using Model.Extensions;

namespace Model {
    public class SearchEngine {
        private readonly int minimumLetters = 3;

        private readonly IList<string> foundWords = new List<string>();

        private WordList wordList = new WordList();
        private WordSearchBox wordSearchBox = new WordSearchBox();

        public void Search() {
            for (var start = 0; start < wordSearchBox.Letters.Length; start++) {
                // Search Right:
                SearchFromLetter(start,
                    () => wordSearchBox.BoxWidth - start,
                    length => wordSearchBox.Letters.Substring(start, length));

                // Search Diagonally Right Down:
                // TODO!

                // Search Down:
                var currentRow = start / wordSearchBox.BoxWidth;

                SearchFromLetter(start,
                    () => wordSearchBox.BoxHeight - currentRow,
                    length => {
                        var word = "";
                        for (var charIndex = 0; charIndex < length; charIndex++) {
                            word += wordSearchBox.Letters[start + (wordSearchBox.BoxWidth*charIndex)];
                        }
                        return word;
                    });

                // Search Diagonally Left Down:
                // TODO!

                // Search Left:
                SearchFromLetter(start,
                    () => start,
                    length => wordSearchBox.Letters.Substring(start - length, length).Reverse());

                // SearchDirection Diagonally Left Up:
                // TODO!

                // SearchDirection Up:
                // TODO!

                // SearchDirection Diagonally Right Up:
                // TODO!
            }
        }

        private void SearchFromLetter(int letterIndex, Func<int> calculateMaxLetters, Func<int, string> extractWord) {
            var maxLetters = calculateMaxLetters();
            if (maxLetters < minimumLetters) return;

            for (var wordLength = minimumLetters; wordLength < maxLetters + 1; wordLength++) {
                var word = extractWord(wordLength);

                if (wordList.IsInWordList(word))
                    foundWords.Add(word);
            }
        }
    }
}
