using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Alfred.Models.Index;

namespace Alfred.ViewModels.Index
{
	public class RfcIndexEntryViewModel : IRfcIndexEntry
	{
		public RfcIndexEntryViewModel(IRfcIndexEntry entry)
		{
			_model = entry;
		}

		public string DocumentId
		{
			get
			{
				return _model.DocumentId;
			}
		}

		public string Date
		{
			get
			{
				return _model.Date;
			}
		}

		public string Title
		{
			get
			{
				return _model.Title;
			}
		}

		public ICollection<string> IsAlso
		{
			get
			{
				return _model.IsAlso;
			}
		}

		public ICollection<string> SeeAlso
		{
			get
			{
				return _model.SeeAlso;
			}
		}

		public ICollection<string> Keywords
		{
			get
			{
				return _model.Keywords;
			}
		}

		public string Abstract
		{
			get
			{
				return _model.Abstract;
			}
		}

		public Models.Index.Rfc.RfcStatus CurrentStatus
		{
			get
			{
				return _model.CurrentStatus;
			}
		}

		public Models.Index.Rfc.RfcStatus PublicationStatus
		{
			get
			{
				return _model.PublicationStatus;
			}
		}

        public void Download()
        {
            FileInfo documentPath = Storage.GetDocumentPath(DocumentId);
            if (!documentPath.Exists)
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(Remote.GetDocumentUri(DocumentId), documentPath.FullName);
                }
            }
        }

		private IRfcIndexEntry _model;
	}
}
