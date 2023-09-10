using System.Collections.Generic;

namespace SpriteSheetBuilder
{
    internal class MissingFiles
    {
        public MissingFiles(string searchDirectory) 
        {
            SearchDirectory = searchDirectory;
        }

        public bool Cancel = false;

        public string SearchDirectory = string.Empty;

        public Dictionary<string, string> OldFileToNewFileMap = new Dictionary<string, string>();
    }
}
