using System;
using System.Collections.Generic;
using Alfred.Models.Index.Rfc;

namespace Alfred.Models.Index
{
    public class RfcIndexEntry : IRfcIndexEntry
    {
        public RfcIndexEntry(RfcEntry entry)
        {
            DocumentId = entry.DocumentId;
            IsAlso = entry.IsAlso;
            SeeAlso = entry.SeeAlso;
            Date = entry.Date.ToString();
            Title = entry.Title;
            Keywords = entry.Keywords;
            CurrentStatus = entry.CurrentStatus;
            PublicationStatus = entry.PublicationStatus;
            if (entry.Abstract != null)
                Abstract = String.Join(Environment.NewLine, entry.Abstract);
        }

        public RfcIndexEntry(RfcBcpEntry entry)
        {
            DocumentId = entry.DocumentId;
            IsAlso = entry.IsAlso;
            Title = entry.Title ?? String.Empty;
            CurrentStatus = RfcStatus.BCP;
            PublicationStatus = RfcStatus.BCP;
        }

        public RfcIndexEntry(RfcFyiEntry entry)
        {
            DocumentId = entry.DocumentId;
            IsAlso = entry.IsAlso;
            Title = entry.Title ?? String.Empty;
            CurrentStatus = RfcStatus.FYI;
            PublicationStatus = RfcStatus.FYI;
        }

        public RfcIndexEntry(RfcStdEntry entry)
        {
            DocumentId = entry.DocumentId;
            IsAlso = entry.IsAlso;
            Title = entry.Title ?? String.Empty;
            CurrentStatus = RfcStatus.Standard;
            PublicationStatus = RfcStatus.Standard;
        }

        public RfcIndexEntry(RfcNotIssuedEntry entry)
        {
            DocumentId = entry.DocumentId;
            Title = "- NOT ISSUED -";
            CurrentStatus = RfcStatus.NotIssued;
            PublicationStatus = RfcStatus.NotIssued;
        }

        public string DocumentId { get; private set; }

        public string Title { get; private set; }

        public ICollection<string> IsAlso { get; private set; }

        public ICollection<string> SeeAlso { get; private set; }

        public string Abstract { get; private set; }

        public string Date { get; private set; }

        public ICollection<string> Keywords { get; private set; }

        public RfcStatus CurrentStatus { get; private set; }

        public RfcStatus PublicationStatus { get; private set; }
    }
}