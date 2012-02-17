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
    using ICSharpCode.AvalonEdit.Highlighting;

	/// <summary>
	/// Interaction logic for MainPage.xaml
	/// </summary>
	public partial class MainPage : Page
	{
		public MainPage()
		{
			InitializeComponent();
            textEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");
		}

        private void openIndex_Click(object sender, RoutedEventArgs e)
        {
            textEditor.Text = "test openIndex_Click";
        }
	}
}