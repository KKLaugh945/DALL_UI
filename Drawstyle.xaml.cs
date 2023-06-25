using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace DALL_UI
{
    class Drawstyle
    {
        //用於綁定margin
        public static System.Windows.Thickness MarginSize 
        {
            get { return new System.Windows.Thickness(Properties.Settings.Default.MarginSet, Properties.Settings.Default.MarginSet, Properties.Settings.Default.MarginSet, Properties.Settings.Default.MarginSet); } 
        }

        public static System.Windows.Thickness VerticalMargin
        {
            get { return new System.Windows.Thickness(1.5, Properties.Settings.Default.MarginSet, 1.5, Properties.Settings.Default.MarginSet); }
        }

        public static System.Windows.Thickness HorizontalMargin
        {
            get { return new System.Windows.Thickness(Properties.Settings.Default.MarginSet, 1.5, Properties.Settings.Default.MarginSet, 1.5); }
        }

        //用於綁定BLOCK或是BOX的高度
        public static ushort SizeSet
        {
            get { return Properties.Settings.Default.SizeSet; }
        }

        //用於獲得字體大小設定
        public static ushort FontSize
        {
            set { Properties.Settings.Default.FontSize = value;  }
            get { return Properties.Settings.Default.FontSize; }
        }

        //獲得寬度
        public static ushort SpiltterWidth
        {
            get { return Properties.Settings.Default.SpilitterWidth; }
        }

        //獲得各類顏色
        public static System.Windows.Media.Brush BackgroundColor
        { 
            get { return HexStringToColor(Properties.Settings.Default.BackgroundColor); }
        }

        public static System.Windows.Media.Brush SecondaryBaseColor
        {
            get { return HexStringToColor(Properties.Settings.Default.SecondaryBaseColor); }
        }

        public static System.Windows.Media.Brush InteractiveColor
        {
            get { return HexStringToColor(Properties.Settings.Default.InteractiveColor); }
        }

        public static System.Windows.Media.Brush FontColor
        {
            get { return HexStringToColor(Properties.Settings.Default.FontColor); }
        }

        private static System.Windows.Media.SolidColorBrush HexStringToColor(string color)
        {
            return new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString(color));
        }
    }

    public class MultiplyConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType,
               object parameter, CultureInfo culture)
        {
            double result = 1.0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] is double)
                    result *= (double)values[i];
            }

            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes,
               object parameter, CultureInfo culture)
        {
            throw new Exception("Not implemented");
        }
    }
}
