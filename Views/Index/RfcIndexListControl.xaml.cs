using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Alfred.ViewModels.Index;
using Alfred.Views.Document;

namespace Alfred.Views.Index
{
    /// <summary>
    ///     Interaction logic for RfcIndexListControl.xaml
    /// </summary>
    public partial class RfcIndexListControl : UserControl
    {
        private String _searchText;

        public RfcIndexListControl()
        {
            InitializeComponent();
        }

        public IRfcDocumentContainer DocumentContainer { get; set; }

        public String SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                ICollectionView view = CollectionViewSource.GetDefaultView(list.ItemsSource);
                if (view == null) return;
                if (String.IsNullOrWhiteSpace(_searchText))
                {
                    view.Filter = null;
                }
                else
                {
                    view.Filter = o =>
                        {
                            var entry = o as RfcIndexEntryViewModel;
                            Debug.Assert(entry != null, "entry != null");
                            if (entry.Title != null)
                            {
                                bool result = entry.Title.Contains(_searchText);
                                if (result)
                                    return true;
                            }
                            if (entry.Keywords != null)
                            {
                                return entry.Keywords.Contains(_searchText);
                            }
                            return false;
                        };
                }
            }
        }

        public RfcIndexEntryViewModel SelectedEntry
        {
            get { return list.SelectedItem as RfcIndexEntryViewModel; }
        }

        public event SelectionChangedEventHandler SelectionChanged;

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionChangedEventHandler ev = SelectionChanged;
            if (ev != null)
                ev(this, e);
        }

        private void list_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RfcIndexEntryViewModel selected = SelectedEntry;
            if (selected == null) return;
            selected.Download();
            DocumentContainer.AddDocument(selected);
        }
    }
}