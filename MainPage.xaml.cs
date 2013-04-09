using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using Alfred.Models.Index;
using Alfred.Storage;
using Alfred.ViewModels.Index;

namespace Alfred
{
    /// <summary>
    ///     Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            InitializeOrUpdateIndex();
            rfcIndexList.DocumentContainer = rfcDocuments;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!Storage.Storage.IndexPath.Exists) return;
            RfcIndex index = RfcIndex.FromFile(Storage.Storage.IndexPath.FullName);
            rfcIndexList.DataContext = new RfcIndexViewModel(index);
            rfcIndexSearch.SearchCriteriaChanged += rfcIndexSearch_SearchCriteriaChanged;
        }

        private static void InitializeOrUpdateIndex()
        {
            if (!Storage.Storage.IndexPath.Exists)
            {
                if (MessageBox.Show("The rfc index was not downloaded yet, download it now?",
                                    "Missing index!",
                                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    DownloadIndex();
            }
            else
            {
                if ((DateTime.Now - Storage.Storage.IndexPath.LastWriteTime).TotalDays > 30)
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
            using (var client = new WebClient())
            {
                client.DownloadFile(Remote.IndexUri, Storage.Storage.IndexPath.FullName);
            }
        }

        private void rfcIndexSearch_SearchCriteriaChanged(object sender, EventArgs e)
        {
            rfcIndexList.SearchText = rfcIndexSearch.SearchText;
        }

        private void rfcIndexList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rfcIndexEntry.DataContext = rfcIndexList.SelectedEntry;
        }
    }
}