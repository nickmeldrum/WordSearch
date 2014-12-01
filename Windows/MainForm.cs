namespace Windows
{
    using Model.Data;
    using Model.Search;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private IEngineData searchEngineData;
        private SearchEngine searchEngine;
        private BackgroundWorker workerThread;

        private Pen pen = new Pen(Color.Blue, 4F);
        private Brush brush = new SolidBrush(Color.Blue);

        private Dictionary<int, Color> lastBoxesSearched = new Dictionary<int, Color>();

        private void Form1_Load(object sender, EventArgs e)
        {
            workerThread = new BackgroundWorker();
            workerThread.DoWork += workerThread_DoWork;
            workerThread.RunWorkerCompleted += workerThread_RunWorkerCompleted;
            workerThread.WorkerSupportsCancellation = true;

            this.searchEngineData = new WordSearchResourceData("Wikipedia");
            //this.searchEngineData = new SearchEngineData("catzzzzzz", 3, new[] { "cat" });
            searchEngine = SearchEngineFactory.Get(this.searchEngineData);
            searchEngine.BoxesBeingSearched += SearchEngineBoxesBeingSearched;
            searchEngine.FoundWord += SearchEngineFoundWord;
        }

        void workerThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            searchButton.Enabled = true;
            cancelButton.Enabled = false;
        }

        private void SearchEngineFoundWord(string direction, List<int> charIndexes, string word)
        {
            Action appendFoundWordToTextBox = () => foundWordsTextbox.AppendText(word + Environment.NewLine);
            Invoke(appendFoundWordToTextBox);

            foreach (var i in charIndexes)
            {
                lastBoxesSearched[i] = Color.DarkSeaGreen;
                //searchBoxPanel.Controls[i].BackColor = Color.DarkSeaGreen;
            }
        }

        private void SearchEngineBoxesBeingSearched(string direction, List<int> charIndexes)
        {
            lastBoxesSearched = new Dictionary<int, Color>();

            foreach (var i in charIndexes)
            {
                //lastBoxesSearched.Add(i, searchBoxPanel.Controls[i].BackColor);
                //searchBoxPanel.Controls[i].BackColor = Color.Aqua;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            foundWordsTextbox.Clear();
            cancelButton.Enabled = true;
            searchButton.Enabled = false;

            workerThread.RunWorkerAsync();
        }

        void workerThread_DoWork(object sender, DoWorkEventArgs e)
        {
            searchEngine.CheckAllPossibleWords();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            searchEngine.Cancel = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            searchEngine.Cancel = true;
            searchButton.Enabled = true;
        }

        private void wordSearchPictureBox_Paint(object sender, PaintEventArgs e)
        {
            var letterWidth = wordSearchPictureBox.Width / this.searchEngineData.Width;
            var font = new Font("consolas", 32);

            for (var i = 0; i < this.searchEngineData.Letters.Length; i++)
            {
                var currentRow = i / this.searchEngineData.Width;
                var currentColumn = i % this.searchEngineData.Width;

                e.Graphics.DrawRectangle(pen,
                    letterWidth * currentColumn, letterWidth * currentRow,
                    letterWidth, letterWidth);

                e.Graphics.DrawString(
                    this.searchEngineData.Letters[i].ToString(CultureInfo.InvariantCulture),
                    font, brush,
                    (letterWidth * currentColumn), // + (letterWidth / 2),
                    (letterWidth * currentRow)// + (letterWidth / 2)
                );
            }
        }
    }
}
