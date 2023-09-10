using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace SpriteSheetBuilder
{
    public enum PaletteVisualization
    {
        Swatches = 0,
        Histogram = 1
    }

    public class Palette
    {
        public Dictionary<Color, ColorInfo> Colors
        {
            get { return _colors; }
        }

        public BindingList<PaletteMap> PaletteMaps
        {
            get { return _paletteMaps; }
        }
        private BindingList<PaletteMap> _paletteMaps = new BindingList<PaletteMap>();

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _name = string.Empty;

        public PaletteVisualization Visualization
        {
            get { return _visualization; }
            set { _visualization = value; }
        }
        private PaletteVisualization _visualization = PaletteVisualization.Swatches;

        private Dictionary<Color, ColorInfo> _colors = new Dictionary<Color, ColorInfo>();

        public override string ToString()
        {
            return Name;
        }

        public string SerializeToString()
        {
            // Write out each of the colors stored in the map, even if the count is 0.
            // Also write out each of the palette maps.

            // Format is {Color 1 R}-{Color 1 G}-{Color 1 B},...,{Color N R}-{Color N G}-{Color N B}ÿ{Mapping Count}ÿ{Map Name}ÿ{Comma Separated Color List or Blank For No Color Mapping}
            char delimiter = (char)(255);

            string serialized = string.Empty;

            string colorList = string.Empty;

            Dictionary<string, string> colorMappings = new Dictionary<string, string>();

            foreach (Color c in _colors.Keys)
            {
                if (string.IsNullOrEmpty(colorList) == false)
                {
                    colorList += ",";
                }

                colorList += (c.R.ToString("000") + "-" + c.G.ToString("000") + "-" + c.B.ToString("000"));

                // Add the mapping for this color in each palette map.
                foreach (PaletteMap mapping in _paletteMaps)
                {
                    string mappingName = mapping.Name;

                    if (colorMappings.ContainsKey(mappingName) == false)
                    {
                        colorMappings.Add(mappingName, string.Empty);
                    }

                    if (string.IsNullOrEmpty(colorMappings[mappingName]) == false)
                    {
                        colorMappings[mappingName] += ",";
                    }

                    if (mapping.Map.ContainsKey(c) == true)
                    {
                        Color mappedColor = mapping.Map[c];

                        colorMappings[mappingName] += (mappedColor.R.ToString("000") + "-" + mappedColor.G.ToString("000") + "-" + mappedColor.B.ToString("000"));
                    }
                }
            }

            serialized += colorList + delimiter + colorMappings.Keys.Count.ToString();

            foreach (KeyValuePair<string, string> kvp in colorMappings)
            {
                serialized += (delimiter + kvp.Key + "," + kvp.Value);
            }

            return serialized;
        }

        public void DeserializeFromString(string str)
        {
            char delimiter = (char)(255);

            string[] data = str.Split(delimiter);

            // Data should have at least 2 elements, the colors list, and the number of mappings.

            if (data.Length > 2)
            {
                string[] colors = data[0].Split(',');

                for (int i = 0; i < colors.Count(); i++)
                {
                    string[] colorRgb = colors[i].Split('-');

                    byte r = 0;
                    byte g = 0;
                    byte b = 0;

                    byte.TryParse(colorRgb[0], out r);

                    byte.TryParse(colorRgb[1], out g);

                    byte.TryParse(colorRgb[2], out b);

                    Color c = Color.FromArgb(255, r, g, b);

                    _colors.Add(c, new ColorInfo());
                }

                int mappingCount = 0;

                if (int.TryParse(data[1], out mappingCount) == false)
                {
                    // Got bad data. Fine to continue, it just won't have palette maps.
                    return;
                }

                // Verify the mapping count matches the data.
                if (mappingCount != data.Length - 2)
                {
                    // Got bad data. Fine to continue, it just won't have palette maps.
                    return;
                }

                for (int i = 0; i < mappingCount; i++)
                {
                    string[] mappings = data[2 + i].Split(',');

                    string paletteMapName = mappings[0];

                    PaletteMap newPaletteMap = new PaletteMap(paletteMapName);

                    Utilities.NameValidator.AddName(paletteMapName, "palette");

                    for (int j = 1; j < mappings.Length; j++)
                    {
                        // Colors and mapping are parallel arrays.
                        string[] mapFrom = colors[j].Split('-');

                        byte r = 0;
                        byte g = 0;
                        byte b = 0;

                        if (mapFrom.Length == 3)
                        {
                            bool ok = true;

                            ok &= byte.TryParse(mapFrom[0], out r);

                            ok &= byte.TryParse(mapFrom[1], out g);

                            ok &= byte.TryParse(mapFrom[2], out b);

                            if (ok == false)
                            {
                                // Got bad data. Fine to continue, it just won't have palette maps.
                                return;
                            }
                        }
                        else
                        {
                            // Got bad data. Fine to continue, it just won't have palette maps.
                            return;
                        }

                        Color fromColor = Color.FromArgb(255, r, g, b);

                        string[] mapTo = mappings[j].Split('-');

                        if (mapTo.Length == 3)
                        {
                            r = 0;
                            g = 0;
                            b = 0;

                            bool ok = true;

                            ok &= byte.TryParse(mapTo[0], out r);

                            ok &= byte.TryParse(mapTo[1], out g);

                            ok &= byte.TryParse(mapTo[2], out b);

                            if (ok == false)
                            {
                                // Got bad data. Fine to continue, it just won't have palette maps.
                                return;
                            }

                            Color toColor = Color.FromArgb(255, r, g, b);

                            newPaletteMap.Map.Add(fromColor, toColor);
                        }
                        else
                        {
                            // Got bad data. Fine to continue, it just won't have palette maps.
                        }
                    }

                    PaletteMaps.Add(newPaletteMap);
                }
            }
            else
            {
                // Got bad data, but it's fine to continue. It just won't have palette data stored.
            }

            return;
        }
    }

    public class ColorInfo
    {
        // The number of times the color is represented. Will either be the number of times
        // it's in the image, or the number of images it's in, for image palettes vs global
        // palette. 
        public int Count;

        public HashSet<string> PresentInFiles = new HashSet<string>();
    }
}
