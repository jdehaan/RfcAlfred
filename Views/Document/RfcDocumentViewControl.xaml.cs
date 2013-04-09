using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Documents;
using Alfred.Models.Index;

namespace Alfred.Views.Document
{
    /// <summary>
    ///     Interaction logic for RfcDocumentViewControl.xaml
    /// </summary>
    public partial class RfcDocumentViewControl : UserControl, IRfcDocumentContainer
    {
        private String _filename;

        public RfcDocumentViewControl()
        {
            InitializeComponent();
        }

        private String Filename
        {
            get { return _filename; }
            set
            {
                _filename = value;
                LoadDocument();
            }
        }

        public void AddDocument(IRfcIndexEntry document)
        {
            FileInfo documentPath = Storage.Storage.GetDocumentPath(document.DocumentId);
            Filename = documentPath.FullName;
        }

        private void LoadDocument()
        {
            richTextBox.Document = new FlowDocument();
            String content = File.ReadAllText(Filename);
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(content)));
        }
    }
}