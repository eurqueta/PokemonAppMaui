using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAppMaui.Converter
{
    public class NameToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string name)
            {
                switch (name.ToLower())
                {
                    case "normal":
                        return "LightGray";
                    case "fire":
                        return "Salmon";
                    case "water":
                        return "LightSkyBlue";
                    case "electric":
                        return "LightYellow";
                    case "grass":
                        return "LightGreen";
                    case "ice":
                        return "PowderBlue";
                    case "fighting":
                        return "RosyBrown";
                    case "poison":
                        return "Plum";
                    case "ground":
                        return "BurlyWood";
                    case "flying":
                        return "SkyBlue";
                    case "psychic":
                        return "Pink";
                    case "bug":
                        return "PaleGreen";
                    case "rock":
                        return "Tan";
                    case "ghost":
                        return "Lavender";
                    case "dragon":
                        return "CornflowerBlue";
                    case "dark":
                        return "DarkGray";
                    case "steel":
                        return "LightSteelBlue";
                    case "fairy":
                        return "Thistle";
                    default:
                        return "Gainsboro";
                }


            }
            return "Gray";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
