using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Alfred.Views.Index
{
    /// <summary>
    ///     Interaction logic for RfcIndexSearchControl.xaml
    /// </summary>
    public partial class RfcIndexSearchControl : UserControl
    {
        public RfcIndexSearchControl()
        {
            InitializeComponent();
        }

        public String SearchText { get; private set; }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchText = textBoxSearch.Text;
            EventHandler ev = SearchCriteriaChanged;
            if (ev != null)
                ev(this, null);
        }

        public event EventHandler SearchCriteriaChanged;

        private void textBoxSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                buttonSearch_Click(null, null);
        }
    }
}