using System.Collections.Generic;
using System.IO;
using System.Net;
using Alfred.Models.Index;
using Alfred.Models.Index.Rfc;
using Alfred.Storage;

namespace Alfred.ViewModels.Index
{
    public class RfcIndexEntryViewModel : IRfcIndexEntry
    {
        private readonly IRfcIndexEntry _model;

        public RfcIndexEntryViewModel(IRfcIndexEntry entry)
        {
            _model = entry;
        }

        public string DocumentId
        {
            get { return _model.DocumentId; }
        }

        public string Date
        {
            get { return _model.Date; }
        }

        public string Title
        {
            get { return _model.Title; }
        }

        public ICollection<string> IsAlso
        {
            get { return _model.IsAlso; }
        }

        public ICollection<string> SeeAlso
        {
            get { return _model.SeeAlso; }
        }

        public ICollection<string> Keywords
        {
            get { return _model.Keywords; }
        }

        public string Abstract
        {
            get { return _model.Abstract; }
        }

        public RfcStatus CurrentStatus
        {
            get { return _model.CurrentStatus; }
        }

        public RfcStatus PublicationStatus
        {
            get { return _model.PublicationStatus; }
        }

        public void Download()
        {
            FileInfo documentPath = Storage.Storage.GetDocumentPath(DocumentId);
            if (documentPath.Exists) return;
            using (var client = new WebClient())
            {
                client.DownloadFile(Remote.GetDocumentUri(DocumentId), documentPath.FullName);
            }
        }
    }
}