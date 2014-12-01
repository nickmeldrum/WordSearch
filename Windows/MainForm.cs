namespace Windows
{
    using System.Linq;

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

        private Pen gridPen = new Pen(Color.IndianRed, 4F);
        private Brush foundWordBackgroundBrush = new SolidBrush(Color.Khaki);
        private Brush searchIndexesBackgroundBrush = new SolidBrush(Color.SlateBlue);
        private Brush letterBrush = new SolidBrush(Color.Indigo);

        private Dictionary<int, Color> lastBoxesSearched = new Dictionary<int, Color>();
        private int letterWidth;
        private IList<int> indexesFound = new List<int>();
        private IList<int> indexesBeingSearched = new List<int>();

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
            letterWidth = wordSearchPictureBox.Width / this.searchEngineData.Width;
        }

        void workerThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            searchButton.Enabled = true;
            cancelButton.Enabled = false;
            indexesBeingSearched.Clear();
            wordSearchPictureBox.Invalidate(false);
        }

        private void SearchEngineFoundWord(string direction, List<int> charIndexes, string word)
        {
            foreach (var i in charIndexes.Where(i => !this.indexesFound.Contains(i)))
                this.indexesFound.Add(i);

            Action appendFoundWordToTextBox = () => foundWordsTextbox.AppendText(word + Environment.NewLine);
            Invoke(appendFoundWordToTextBox);

            Action redraw = () => wordSearchPictureBox.Invalidate(false);
            Invoke(redraw);
        }

        private void SearchEngineBoxesBeingSearched(string direction, List<int> charIndexes)
        {
            indexesBeingSearched = charIndexes;

            Action redraw = () => wordSearchPictureBox.Invalidate(false);
            Invoke(redraw);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            foundWordsTextbox.Clear();
            indexesBeingSearched.Clear();
            indexesFound.Clear();
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
            var font = new Font("consolas", 32);

            for (var i = 0; i < this.searchEngineData.Letters.Length; i++)
            {
                var point = new Point(letterWidth * (i % this.searchEngineData.Width), letterWidth * (i / this.searchEngineData.Width));
                var rect = new Rectangle(point, new Size(letterWidth, letterWidth));

                if (indexesFound.Contains(i) && !indexesBeingSearched.Contains(i))
                    e.Graphics.FillRectangle(foundWordBackgroundBrush, rect);

                if (indexesBeingSearched.Contains(i))
                    e.Graphics.FillRectangle(searchIndexesBackgroundBrush, rect);

                e.Graphics.DrawRectangle(gridPen, rect);

                e.Graphics.DrawString(
                    this.searchEngineData.Letters[i].ToString(CultureInfo.InvariantCulture),
                    font, letterBrush, point
                );
            }
        }
    }
}
