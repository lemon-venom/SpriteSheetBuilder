using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SpriteSheetBuilder
{
    public class PaletteMap
    {
        #region Constructors

        public PaletteMap(string name)
        {
            _name = name;
        }

        #endregion

        #region Properties

        [Browsable(false)]
        public Guid Id
        {
            get { return _id; }
        }
        private Guid _id = Guid.NewGuid();


        [Browsable(false)]
        public Dictionary<Color, Color> Map
        {
            get { return _paletteMap; }
        }
        private Dictionary<Color, Color> _paletteMap = new Dictionary<Color, Color>();

        public string Name
        {
            get { return _name; }
            set
            {
                if (Utilities.NameValidator.IsNameInUse(value, "palette") == true)
                {
                    MessageBox.Show("Name is already in use.");
                }
                else
                {
                    Utilities.NameValidator.ChangeName(_name, value, "palette");

                    _name = value;
                }
            }
        }
        private string _name = string.Empty;

    #endregion

        #region Public Functions

        public override string ToString()
        {
            return _name;
        }

        #endregion
    }
}
