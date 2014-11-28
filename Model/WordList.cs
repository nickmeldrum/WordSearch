using System.Collections.Generic;
using System.IO;

namespace Model {
    public class WordList {
        public List<string> Words { get; private set; }

        public WordList() {
            InitialiseWordList(Resources.WordListFilename);
        }

        public WordList(string filename) {
            InitialiseWordList(filename);
        }

        public WordList(List<string> wordList) {
            Words = wordList;
        }

        private void InitialiseWordList(string filename) {
            Words = new List<string>();
            using (var reader = new StreamReader(filename)) {
                while (!reader.EndOfStream) {
                    Words.Add(reader.ReadLine());
                }
            }
        }

        public bool IsInWordList(string word) {
            return Words != null && Words.Contains(word);
        }

        public void AddWordsToList(IList<string> words)
        {
           Words.AddRange(words);
        }
    }
}
