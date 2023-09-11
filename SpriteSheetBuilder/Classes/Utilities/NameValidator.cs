
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using static SpriteSheetBuilder.PaletteMapConverter;

namespace SpriteSheetBuilder
{
    public class NameValidator : INameValidator
    {
        #region Private Classes

        private class NameTrackers
        {
            public List<string> NamesList = new List<string>();

            public HashSet<string> Names = new HashSet<string>();
        }
        
        #endregion

        #region Constructors

        public NameValidator() { }

        #endregion

        #region Private Variables

        private Dictionary<string, NameTrackers> _nameTrackers = new Dictionary<string, NameTrackers>();

        #endregion


        #region Public Functions

        public void AddName(string name, string group) 
        { 
            if (_nameTrackers.ContainsKey(group) == false)
            {
                _nameTrackers.Add(group, new NameTrackers());
            }

            if (_nameTrackers[group].Names.Contains(name) == false)
            {
                _nameTrackers[group].Names.Add(name);

                _nameTrackers[group].NamesList.Add(name);

                _nameTrackers[group].NamesList.Sort();

                namesChanged(group);
            }
        }

        public void ChangeName(string oldName, string newName, string group)
        {
            if (_nameTrackers.ContainsKey(group) == true)
            {
                _nameTrackers[group].Names.Remove(oldName);

                _nameTrackers[group].Names.Add(newName);


                _nameTrackers[group].NamesList.Remove(oldName);

                _nameTrackers[group].NamesList.Add(newName);

                _nameTrackers[group].NamesList.Sort();

                namesChanged(group);
            }
        }

        public void ClearAllNames(string group)
        {
            if (_nameTrackers.ContainsKey(group) == true)
            {
                _nameTrackers[group].Names.Clear();

                _nameTrackers[group].NamesList.Clear();

                namesChanged(group);
            }
        }

        public void DeleteName(string name, string group)
        {
            if (_nameTrackers.ContainsKey(group) == true)
            {
                _nameTrackers[group].Names.Remove(name);

                _nameTrackers[group].NamesList.Remove(name);

                namesChanged(group);
            }
        }

        public bool IsNameInUse(string name, string group)
        {
            if (_nameTrackers.ContainsKey(group) == true)
            {
                return _nameTrackers[group].Names.Contains(name);
            }

            return false;
        }

        #endregion

        #region Private Functions

        private void namesChanged(string group)
        {
            // Some dropdown menus are populated with names.
            // If the names change, the data source list needs to be updated.
            if (_nameTrackers.ContainsKey(group) == true)
            {
                // This is an awful solution, but it's fine for now that I only have one list.
                switch (group)
                {
                    case "palette":

                        GlobalVars._listOfPaletteMaps = _nameTrackers[group].NamesList.ToArray();

                        break;
                }
            }
        }

        #endregion
    }

    public interface INameValidator
    {
        void AddName(string name, string group);

        void ChangeName(string oldName, string newName, string group);

        void ClearAllNames(string group);

        void DeleteName(string name, string group);

        bool IsNameInUse(string name, string group);
    }
}
