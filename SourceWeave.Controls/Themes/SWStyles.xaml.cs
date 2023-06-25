using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SourceWeave.Controls
{
    class SWStyles
    {
        private static System.Windows.Media.SolidColorBrush HexStringToColor(string color)
        {
            return new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
        }

        //獲得各類顏色
        public static System.Windows.Media.SolidColorBrush InteractiveColor
        {
            get { return HexStringToColor(Properties.Settings.Default.InteractiveColor); }
        }

        public static System.Windows.Media.SolidColorBrush FontColor
        {
            get { return HexStringToColor(Properties.Settings.Default.FontColor); }
        }
    }
}
