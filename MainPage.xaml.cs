using System;
using System.Collections.Generic;
using System.Net;
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

namespace Alfred
{
	/// <summary>
	/// Interaction logic for MainPage.xaml
	/// </summary>
	public partial class MainPage: Page
	{
		public MainPage()
		{
			InitializeComponent();
			InitializeOrUpdateIndex();
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			if (Storage.Index.Exists)
			{
				var index = Models.Index.RfcIndex.FromFile(Storage.Index.FullName);
				rfcIndexList.DataContext = new ViewModels.Index.RfcIndexViewModel(index);
				rfcIndexSearch.SearchCriteriaChanged += new EventHandler(rfcIndexSearch_SearchCriteriaChanged);
			}
		}

		private static void InitializeOrUpdateIndex()
		{
			if (!Storage.Index.Exists)
			{
				if (MessageBox.Show("The rfc index was not downloaded yet, download it now?",
					"Missing index!",
					MessageBoxButton.YesNo) == MessageBoxResult.Yes)
					DownloadIndex();
			}
			else
			{
				if ((DateTime.Now - Storage.Index.LastWriteTime).TotalDays > 30)
				{
					if (MessageBox.Show("The rfc index was not updated since more than 30 days, update it now?",
						"Update index?",
						MessageBoxButton.YesNo) == MessageBoxResult.Yes)
						DownloadIndex();
				}
			}
		}

		private static void DownloadIndex()
		{
			using (WebClient client = new WebClient())
			{
				client.DownloadFile(Remote.Index, Storage.Index.FullName);
			}
		}

		private void rfcIndexSearch_SearchCriteriaChanged(object sender, EventArgs e)
		{
			rfcIndexList.SearchText = rfcIndexSearch.SearchText;
		}

	}
}