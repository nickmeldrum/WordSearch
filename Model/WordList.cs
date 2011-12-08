using System.Collections.Generic;
using System.IO;

namespace Model {
    public class WordList {
        private IList<string> words;

        public IList<string> Words {
            get {
                if (words == null)
                    InitialiseWordList();
                return words;
            }
        }

        private void InitialiseWordList() {
            words = new List<string>();
            using (var reader = new StreamReader(Resources.WordListFilename)) {
                while (!reader.EndOfStream) {
                    words.Add(reader.ReadLine());
                }
            }
        }

        public bool IsInWordList(string word) {
            return Words != null && Words.Contains(word);
        }
    }
}
