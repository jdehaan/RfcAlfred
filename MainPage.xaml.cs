using System;
using System.Collections.Generic;
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
		}

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			var index = Models.Index.RfcIndex.FromFile("rfc-index.xml");
			rfcIndexList.DataContext = new ViewModels.Index.RfcIndexViewModel(index);
			rfcIndexSearch.SearchCriteriaChanged += new EventHandler(rfcIndexSearch_SearchCriteriaChanged);
		}

		private void rfcIndexSearch_SearchCriteriaChanged(object sender, EventArgs e)
		{
			rfcIndexList.SearchText = rfcIndexSearch.SearchText;
		}

	}
}