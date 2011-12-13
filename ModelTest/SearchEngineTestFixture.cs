using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace Model.Test {
    [TestFixture]
    public class SearchEngineTestFixture {

        [Test]
        public void TestSearchEngine() {
            var searchEngine = new SearchEngine();
            searchEngine.BoxesBeingSearched += SearchEngineBoxesBeingSearched;
            searchEngine.FoundWord += SearchEngineFoundWord;
            searchEngine.Search();

            WriteOutFoundWords(searchEngine.FoundWords);
        }

        private static void SearchEngineFoundWord(object sender, FoundWordEventsArgs e) {
            Debug.Write(string.Format("Found word: {0}, direction: {1} at: ", e.Word, e.Direction));
            WriteBoxesOut(e.Boxes);
        }

        private static void SearchEngineBoxesBeingSearched(object sender, BoxSearchingEventsArgs e) {
            Debug.Write(string.Format("Searching direction: {0}, ", e.Direction));
            WriteBoxesOut(e.Boxes);
        }

        private static void WriteOutFoundWords(IEnumerable<string> foundWords) {
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
