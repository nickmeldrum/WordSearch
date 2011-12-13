using System;
using System.Linq;
using System.Collections.Generic;

namespace Model {
    public class BoxSearchingEventsArgs {
        public string Direction { get; set; }
        public List<int> Boxes { get; set; }
    }

    public class FoundWordEventsArgs {
        public string Word { get; set; }
        public string Direction { get; set; }
        public List<int> Boxes { get; set; }
    }

    public delegate void BoxSearchingEventHandler(object sender, BoxSearchingEventsArgs e);
    public delegate void FoundWordEventHandler(object sender, FoundWordEventsArgs e);

    public class SearchEngine {
        public event BoxSearchingEventHandler BoxesBeingSearched;
        public event FoundWordEventHandler FoundWord;

        private readonly int minimumLetters = 3;
        private readonly IList<string> foundWords = new List<string>();

        public IList<string> FoundWords {
            get { return foundWords; }
        }

        public bool Cancel { get; set; }

        private WordList wordList = new WordList();
        private WordSearchBox wordSearchBox = new WordSearchBox();

        public SearchEngine(WordSearchBox wordSearchBox) {
            this.wordSearchBox = wordSearchBox;
        }

        public SearchEngine() {
        }

        public void Search() {
            Cancel = false;

            for (var start = 0; start < wordSearchBox.Letters.Length; start++) {
                var maxLetters = new MaxLetters(start, wordSearchBox.BoxWidth, wordSearchBox.BoxHeight);

                SearchRight(start, maxLetters);
                SearchDiagonallyRightDown(start, maxLetters);
                SearchDown(start, maxLetters);
                SearchDiagonallyLeftDown(start, maxLetters);
                SearchLeft(start, maxLetters);
                SearchDiagonallyLeftUp(start, maxLetters);
                SearchUp(start, maxLetters);
                SearchDiagonallyRightUp(start, maxLetters);

                if (Cancel) break;
            }
        }

        private class MaxLetters {
            public int Left { get; private set; }
            public int Right { get; private set; }
            public int Up { get; private set; }
            public int Down { get; private set; }

            public MaxLetters(int startLetter, int boxWidth, int boxHeight) {
                var currentRow = startLetter / boxWidth;
                var currentColumn = startLetter % boxWidth;

                Left = currentColumn + 1;
                Right = boxWidth - currentColumn;
                Down = boxHeight - currentRow;
                Up = currentRow + 1;
            }
        }

        private void SearchLeft(int start, MaxLetters maxLetters) {
            SearchFromLetter(maxLetters.Left,
                length => {
                    var a = new int[length];
                    for (var i = 0; i < length; i++) {
                        a[i] = start - i;
                    }
                    return a;
                }, "left");
        }

        private void SearchRight(int start, MaxLetters maxLetters) {
            SearchFromLetter(maxLetters.Right,
                length => {
                    var a = new int[length];
                    for (var i = 0; i < length; i++) {
                        a[i] = start + i;
                    }
                    return a;
                }, "right");
        }

        private void SearchUp(int start, MaxLetters maxLetters) {
            SearchFromLetter(maxLetters.Up,
                length => {
                    var a = new int[length];
                    for (var i = 0; i < length; i++) {
                        a[i] = start - (wordSearchBox.BoxWidth * i);
                    }
                    return a;
                }, "up");
        }

        private void SearchDown(int start, MaxLetters maxLetters) {
            SearchFromLetter(maxLetters.Down,
                length => {
                    var a = new int[length];
                    for (var i = 0; i < length; i++) {
                        a[i] = start + (wordSearchBox.BoxWidth * i);
                    }
                    return a;
                }, "down");
        }

        private void SearchDiagonallyLeftDown(int start, MaxLetters maxLetters) {
            //var diagonalMaxLetters = (maxLetters.Left < maxLetters.Down) ? maxLetters.Left : maxLetters.Down;

            //SearchFromLetter(diagonalMaxLetters,
            //    length => {
            //        var a = new int[length];
            //        for (var i = length - 1; i >= 0; i--) {
            //            a[i] += start + (wordSearchBox.BoxWidth * i) + i;
            //        }
            //        return a;
            //    }, "left and down");
        }

        private void SearchDiagonallyRightDown(int start, MaxLetters maxLetters) {
            var diagonalMaxLetters = (maxLetters.Right < maxLetters.Down) ? maxLetters.Right : maxLetters.Down;

            SearchFromLetter(diagonalMaxLetters,
                length => {
                    var a = new int[length];
                    for (var i = length - 1; i >= 0; i--) {
                        a[i] += start + (wordSearchBox.BoxWidth * i) + i;
                    }
                    return a;
                }, "right and down");
        }

        private void SearchDiagonallyLeftUp(int start, MaxLetters maxLetters) {
            // TODO
        }

        private void SearchDiagonallyRightUp(int start, MaxLetters maxLetters) {
            // TODO
        }

        private void SearchFromLetter(int maxLetters, Func<int, int[]> calculateLetterBoxes, string direction) {
            if (maxLetters < minimumLetters) return;

            for (var wordLength = minimumLetters; wordLength < maxLetters + 1; wordLength++) {
                if (Cancel) break;

                var letterBoxes = calculateLetterBoxes(wordLength);

                if (BoxesBeingSearched != null) {
                    BoxesBeingSearched(this, new BoxSearchingEventsArgs { Boxes = letterBoxes.ToList(), Direction = direction });
                }

                var word = new string(letterBoxes.Select(index => wordSearchBox.Letters[index]).ToArray());

                if (wordList.IsInWordList(word)) {
                    FoundWords.Add(word);

                    if (FoundWord != null) {
                        FoundWord(this, new FoundWordEventsArgs { Boxes = letterBoxes.ToList(), Word = word, Direction = direction });
                    }
                }
            }
        }
    }
}
