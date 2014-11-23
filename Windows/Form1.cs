using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Model;
using Model.Search;

namespace Windows {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private WordSearchBox wordSearchBox;
        private SearchEngine searchEngine;
        private BackgroundWorker workerThread;

        private Graphics canvas;
        private Pen pen = new Pen(Color.Blue, 2F); 
        private Brush brush = new SolidBrush(Color.Blue);
        private Font font = new Font(FontFamily.GenericMonospace, 2);

        private Dictionary<int, Color> lastBoxesSearched = new Dictionary<int, Color>();

        private void Form1_Load(object sender, EventArgs e) {
            workerThread = new BackgroundWorker();
            workerThread.DoWork += workerThread_DoWork;
            workerThread.RunWorkerCompleted += workerThread_RunWorkerCompleted;
            workerThread.WorkerSupportsCancellation = true;

            wordSearchBox = new WordSearchBox(Resources.TestLetters, int.Parse(Resources.TestWidth));
            searchEngine = new SearchEngine(wordSearchBox);
            searchEngine.BoxesBeingSearched += SearchEngineBoxesBeingSearched;
            searchEngine.FoundWord += SearchEngineFoundWord;

            DrawBox();
        }

        void workerThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            searchButton.Enabled = true;
            cancelButton.Enabled = false;
            RevertBoxColor();
        }

        private void SearchEngineFoundWord(string direction, List<int> charIndexes, string word) {
            Action appendFoundWordToTextBox = () => foundWordsTextbox.AppendText(word + Environment.NewLine);
            Invoke(appendFoundWordToTextBox);

            foreach (var i in charIndexes) {
                lastBoxesSearched[i] = Color.DarkSeaGreen;
                //searchBoxPanel.Controls[i].BackColor = Color.DarkSeaGreen;
            }
        }

        private void SearchEngineBoxesBeingSearched(string direction, List<int> charIndexes) {
            RevertBoxColor();
            lastBoxesSearched = new Dictionary<int, Color>();

            foreach (var i in charIndexes) {
                //lastBoxesSearched.Add(i, searchBoxPanel.Controls[i].BackColor);
                //searchBoxPanel.Controls[i].BackColor = Color.Aqua;
            }
        }

        private void RevertBoxColor() {
            foreach (var box in lastBoxesSearched) {
                //searchBoxPanel.Controls[box.Key].BackColor = box.Value;
            }
        }

        private void DrawBox() {
            //searchBoxPanel.Controls.Clear();
            canvas = wordSearchPictureBox.CreateGraphics();
            var letterWidth = wordSearchPictureBox.Width / wordSearchBox.Width;

            for (var i = 0; i < wordSearchBox.Letters.Length; i++) {
                var currentRow = i / wordSearchBox.Width;
                var currentColumn = i % wordSearchBox.Width;

                canvas.DrawRectangle(pen,
                    letterWidth * currentColumn, letterWidth * currentRow,
                    letterWidth, letterWidth);
                canvas.DrawString(wordSearchBox.Letters[i].ToString(), font, brush, letterWidth * currentColumn, letterWidth * currentRow);

                //var label = new Label {
                //    Location = new Point(letterWidth * currentColumn, letterWidth * currentRow),
                //    Size = new Size(letterWidth, letterWidth),
                //    BorderStyle = BorderStyle.FixedSingle,
                //    Text = wordSearchBox.Letters[i].ToString(),
                //    BackColor = Color.Khaki
                //};
                //searchBoxPanel.Controls.Add(label);
            }

        }

        private void searchButton_Click(object sender, EventArgs e) {
            //for (var i = 0; i < searchBoxPanel.Controls.Count; i++) {
            //    searchBoxPanel.Controls[i].BackColor = Color.Khaki;
            //}

            foundWordsTextbox.Clear();
            cancelButton.Enabled = true;
            searchButton.Enabled = false;

            workerThread.RunWorkerAsync();
        }

        void workerThread_DoWork(object sender, DoWorkEventArgs e) {
            searchEngine.CheckAllPossibleWords();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            searchEngine.Cancel = true;
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            searchEngine.Cancel = true;
            searchButton.Enabled = true;
            RevertBoxColor();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e) {
            var letterWidth = wordSearchPictureBox.Width / wordSearchBox.Width;

            for (var i = 0; i < wordSearchBox.Letters.Length; i++) {
                var currentRow = i / wordSearchBox.Width;
                var currentColumn = i % wordSearchBox.Width;

                e.Graphics.DrawRectangle(pen,
                    letterWidth * currentColumn, letterWidth * currentRow,
                    letterWidth, letterWidth);
                e.Graphics.DrawString(wordSearchBox.Letters[i].ToString(), font, brush, letterWidth * currentColumn, letterWidth * currentRow);

                //var label = new Label {
                //    Location = new Point(letterWidth * currentColumn, letterWidth * currentRow),
                //    Size = new Size(letterWidth, letterWidth),
                //    BorderStyle = BorderStyle.FixedSingle,
                //    Text = wordSearchBox.Letters[i].ToString(),
                //    BackColor = Color.Khaki
                //};
                //searchBoxPanel.Controls.Add(label);
            }
        }
    }
}
