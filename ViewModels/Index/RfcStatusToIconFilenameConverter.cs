using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Alfred.Models.Index.Rfc;

namespace Alfred.ViewModels.Index
{
	/// <summary>
	/// Converter for XAML data binding that returns a Pack URI for the status.
	/// </summary>
	[ValueConversion(typeof(RfcStatus), typeof(string))]
	public class RfcStatusToIconFilenameConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			String basePath = "pack://application:,,,/Alfred;component/Images/Status/";
			return String.Format("{0}{1}.png", basePath, Enum.GetName(typeof(RfcStatus), value));
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
