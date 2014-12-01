namespace Model
{
    using System;

    public class WordSearchResourceData
    {
        private readonly string testName;

        public WordSearchResourceData(string testName)
        {
            this.testName = testName;
        }

        public string GetLetters()
        {
            return getResourceString(testName + "Letters");
        }

        public int GetWidth()
        {
            return int.Parse(getResourceString(testName + "Width"));
        }

        public string[] GetExpectedWords()
        {
            return getResourceString(testName + "Words").Split(';');
        }

        private string getResourceString(string name)
        {
            var resourceString = Resources.ResourceManager.GetString(name);
            if (string.IsNullOrWhiteSpace(resourceString)) throw new ArgumentException("Resource not found", name);
            return resourceString.ToLowerInvariant().Trim();
        }
    }
}
