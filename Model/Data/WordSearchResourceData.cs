namespace Model.Data
{
    using System;
    using System.Collections.Generic;

    public class WordSearchResourceData : IEngineData
    {
        private readonly string testName;

        public WordSearchResourceData(string testName)
        {
            this.testName = testName;
        }

        public string Letters
        {
            get
            {
                return this.getResourceString(this.testName + "Letters");
            }
        }

        public int Width
        {
            get
            {
                return int.Parse(this.getResourceString(this.testName + "Width"));
            }
        }

        public IList<string> ExpectedWords
        {
            get
            {
                return this.getResourceString(this.testName + "Words").Split(';');
            }
        }

        private string getResourceString(string name)
        {
            var resourceString = Resources.ResourceManager.GetString(name);
            if (resourceString == null) throw new ArgumentException("Resource not found", name);
            return resourceString.ToLowerInvariant().Trim();
        }
    }
}
