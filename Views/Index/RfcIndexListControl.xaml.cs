﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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

using Alfred.ViewModels.Index;

namespace Alfred.Views.Index
{
	/// <summary>
	/// Interaction logic for RfcIndexListControl.xaml
	/// </summary>
	public partial class RfcIndexListControl : UserControl
	{
		public RfcIndexListControl()
		{
			InitializeComponent();
		}

        public Alfred.Views.Document.IRfcDocumentContainer DocumentContainer { get; set; }

		private String _searchText;
		public String SearchText
		{
			get
			{
				return _searchText;
			}
			set
			{
				_searchText = value;
				ICollectionView view = CollectionViewSource.GetDefaultView(list.ItemsSource);
				if (view != null)
				{
					if (String.IsNullOrWhiteSpace(_searchText))
					{
						view.Filter = null;
					}
					else
					{
						view.Filter = o =>
						{
							var entry = o as RfcIndexEntryViewModel;
							if (entry.Title != null)
							{
								var result = entry.Title.Contains(_searchText);
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
		}

		public event SelectionChangedEventHandler SelectionChanged;

		public RfcIndexEntryViewModel SelectedEntry
		{
			get
			{
				return list.SelectedItem as RfcIndexEntryViewModel;
			}
		}

		private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var ev = SelectionChanged;
			if (ev != null)
				ev(this, e);
		}

		private void list_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
            RfcIndexEntryViewModel selected = SelectedEntry;
            if (selected != null)
            {
                selected.Download();
                DocumentContainer.AddDocument(selected);
            }
		}

	}
}
