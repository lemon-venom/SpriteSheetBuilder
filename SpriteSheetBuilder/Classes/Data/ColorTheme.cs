using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SpriteSheetBuilder
{
    public class ColorTheme
    {
        public ColorTheme(string name, Color color1, Color color2)
        {
            _color1 = color1;

            _color2 = color2;

            _name = name;
        }

        [BrowsableAttribute(false)]
        public Guid Id
        {
            get { return _id; }
        }
        private Guid _id = Guid.NewGuid();

        public string Name
        {
            get { return _name; }
            set
            {
                if (Utilities.NameValidator.IsNameInUse(value, "bgtheme") == true)
                {
                    MessageBox.Show("Name is already in use.");
                }
                else
                {
                    Utilities.NameValidator.ChangeName(_name, value, "bgtheme");

                    _name = value;
                }
            }
        }
        private string _name;

        public Color Color1
        {
            get { return _color1; }
            set { _color1 = value; }
        }
        private Color _color1;

        public Color Color2
        {
            get { return _color2; }
            set { _color2 = value; }
        }
        private Color _color2;


        public override string ToString()
        {
            return _name +
                _color1.A.ToString("000") + "," +
                _color1.R.ToString("000") + "," +
                _color1.G.ToString("000") + "," +
                _color1.B.ToString("000") + "," +
                _color2.A.ToString("000") + "," +
                _color2.R.ToString("000") + "," +
                _color2.G.ToString("000") + "," +
                _color2.B.ToString("000");
        }

        public static bool TryParse(string value, out ColorTheme result)
        {
            result = new ColorTheme("", Color.LightGray, Color.White);

            // value should store a name + eight 3 digit numbers separated by commas, i.e "###,###,###,###,###,###,###,###"

            if (value.Length < 31)
            {
                return false;
            }

            string namePart = value.Substring(0, value.Length - 31);

            string numberPart = value.Substring(value.Length - 31, 31);

            string[] numbers = numberPart.Split(',');

            if (numbers.Length != 8)
            {
                return false;
            }

            Byte a1;
            if (Byte.TryParse(numbers[0], out a1) == false)
            {
                return false;
            }

            Byte r1;
            if (Byte.TryParse(numbers[1], out r1) == false)
            {
                return false;
            }

            Byte g1;
            if (Byte.TryParse(numbers[2], out g1) == false)
            {
                return false;
            }

            Byte b1;
            if (Byte.TryParse(numbers[3], out b1) == false)
            {
                return false;
            }

            Color color1 = Color.FromArgb(a1, r1, g1, b1);


            Byte a2;
            if (Byte.TryParse(numbers[4], out a2) == false)
            {
                return false;
            }

            Byte r2;
            if (Byte.TryParse(numbers[5], out r2) == false)
            {
                return false;
            }

            Byte g2;
            if (Byte.TryParse(numbers[6], out g2) == false)
            {
                return false;
            }

            Byte b2;
            if (Byte.TryParse(numbers[7], out b2) == false)
            {
                return false;
            }

            Color color2 = Color.FromArgb(a2, r2, g2, b2);

            result.Name = namePart;

            result.Color1 = color1;

            result.Color2 = color2;

            return true;
        }
    }
}
