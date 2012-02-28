﻿using System;
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

namespace Alfred.Views.Index
{
	/// <summary>
	/// Interaction logic for RfcIndexSearchControl.xaml
	/// </summary>
	public partial class RfcIndexSearchControl: UserControl
	{
		public RfcIndexSearchControl()
		{
			InitializeComponent();
		}

		public String SearchText
		{
			get;
			private set;
		}

		private void buttonSearch_Click(object sender, RoutedEventArgs e)
		{
			SearchText = textBoxSearch.Text;
			var ev = SearchCriteriaChanged;
			if (ev != null)
				ev(this, null);
		}

		public event EventHandler SearchCriteriaChanged;
	}
}
