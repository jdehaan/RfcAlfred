using System;
using System.Globalization;
using System.Windows.Data;
using Alfred.Models.Index.Rfc;

namespace Alfred.ViewModels.Index
{
    /// <summary>
    ///     Converter for XAML data binding that returns a Pack URI for the status.
    /// </summary>
    [ValueConversion(typeof (RfcStatus), typeof (string))]
    public class RfcStatusToIconFilenameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            const string basePath = "pack://application:,,,/Alfred;component/Images/Status/";
            return String.Format("{0}{1}.png", basePath, Enum.GetName(typeof (RfcStatus), value));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}