using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Model.Test {
    public class SearchResultsOutput {
        public void OutputFoundWord(string direction, List<int> charIndexes, string word) {
            Debug.Write(String.Format("Found word: {0}, direction: {1} at: ", word, direction));
            WriteBoxesOut(charIndexes);
        }

        public void OutputBoxesBeingSearched(string direction, List<int> charIndexes) {
            Debug.Write(String.Format("Searching direction: {0}, ", direction));
            WriteBoxesOut(charIndexes);
        }

        public void OutputAllFoundWords(IEnumerable<string> foundWords) {
            Debug.WriteLine("Found Words:");
            foreach (var foundWord in foundWords) {
                Debug.Write(foundWord + ", ");
            }
            Debug.Write(Environment.NewLine);
        }

        private static void WriteBoxesOut(IList<int> boxes) {
            Debug.Write("[");
            for (var i = 0; i < boxes.Count; i++) {
                Debug.Write(boxes[i]);
                if (i < boxes.Count - 1)
                    Debug.Write(", ");
            }

            Debug.Write("]" + Environment.NewLine);
        }
    }
}
