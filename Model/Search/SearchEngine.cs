using System;
using System.Collections.Generic;
using System.Linq;
using Model.IndividualWords;

namespace Model.Search {
    public class SearchEngine {
        public event Action<string, List<int>> BoxesBeingSearched;
        public event Action<string, List<int>, string> FoundWord;

        private readonly int minimumLetters = 3;
        private readonly IList<string> foundWords = new List<string>();

        public IList<string> FoundWords {
            get { return foundWords; }
        }

        public bool Cancel { get; set; }

        private readonly WordList wordList;
        private readonly WordSearchBox wordSearchBox;

        public SearchEngine(WordSearchBox wordSearchBox, WordList wordList)
        {
            this.wordSearchBox = wordSearchBox;
            this.wordList = wordList;
        }

        public void CheckAllPossibleWords() {
            Cancel = false;

            for (var start = 0; start < wordSearchBox.Letters.Length; start++) {
                CheckWordsFromMinLettersToMaxLettersInOneDirection(new RightWordConstructor(start, wordSearchBox));
                CheckWordsFromMinLettersToMaxLettersInOneDirection(new DiagonallyRightDownWordConstructor(start, wordSearchBox));
                CheckWordsFromMinLettersToMaxLettersInOneDirection(new DownWordConstructor(start, wordSearchBox));
                CheckWordsFromMinLettersToMaxLettersInOneDirection(new DiagonallyLeftDownWordConstructor(start, wordSearchBox));
                CheckWordsFromMinLettersToMaxLettersInOneDirection(new LeftWordConstructor(start, wordSearchBox));
                CheckWordsFromMinLettersToMaxLettersInOneDirection(new DiagonallyLeftUpWordConstructor(start, wordSearchBox));
                CheckWordsFromMinLettersToMaxLettersInOneDirection(new UpWordConstructor(start, wordSearchBox));
                CheckWordsFromMinLettersToMaxLettersInOneDirection(new DiagonallyRightUpWordConstructor(start, wordSearchBox));

                if (Cancel) break;
            }
        }

        public void CheckWordsFromMinLettersToMaxLettersInOneDirection(IWordConstructor wordConstructor) {
            if (wordConstructor.MaxLettersToSearch < minimumLetters) return;

            for (var wordLength = minimumLetters; wordLength < wordConstructor.MaxLettersToSearch + 1; wordLength++) {
                if (Cancel) break;

                CheckWordOfOneLengthInOneDirection(wordLength, wordConstructor);
            }
        }

        public Tuple<string, bool> CheckWordOfOneLengthInOneDirection(int wordLength, IWordConstructor wordConstructor) {
            var charIndexes = wordConstructor.CharacterIndexes(wordLength);

            FireBeingSearchedEvent(charIndexes, wordConstructor.Direction);

            var wordString = wordConstructor.StringFromIndexes(charIndexes);

            var wasInWord = AddWordIfInWordList(wordConstructor.Direction, charIndexes, wordString);

            return new Tuple<string, bool>(wordString, wasInWord);
        }

        private bool AddWordIfInWordList(string direction, IEnumerable<int> charIndexes, string wordString) {
            if (!wordList.IsInWordList(wordString)) return false;

            // else we have a word!
            FoundWords.Add(wordString);

            FireFoundWordEvent(direction, charIndexes, wordString);

            return true;
        }

        private void FireFoundWordEvent(string direction, IEnumerable<int> charIndexes, string wordString) {
            if (FoundWord != null) {
                FoundWord(direction, charIndexes.ToList(), wordString);
            }
        }

        private void FireBeingSearchedEvent(IEnumerable<int> charIndexes, string direction) {
            if (BoxesBeingSearched != null) {
                BoxesBeingSearched(direction, charIndexes.ToList());
            }
        }
    }
}
