using System;
using System.Collections.Generic;
using System.IO;
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

using Alfred.Models.Index;

namespace Alfred.Views.Document
{
	/// <summary>
	/// Interaction logic for RfcDocumentViewControl.xaml
	/// </summary>
	public partial class RfcDocumentViewControl : UserControl, IRfcDocumentContainer
	{
		public RfcDocumentViewControl()
		{
			InitializeComponent();
		}

        public void AddDocument(IRfcIndexEntry document)
        {
            FileInfo documentPath = Storage.GetDocumentPath(document.DocumentId);
            Filename = documentPath.FullName;
        }

        private String Filename 
        {
            get { return _filename; }
            set { _filename = value; LoadDocument();  }
        }

        private void LoadDocument()
        {
            richTextBox.Document = new FlowDocument();
            String content = File.ReadAllText(Filename);
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(content)));
        }

        private String _filename;
	}
}
