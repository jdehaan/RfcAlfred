using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alfred.Models.Index
{
	public class RfcIndexEntry : IRfcIndexEntry
	{
		public RfcIndexEntry(Rfc.RfcEntry entry)
		{
			DocumentId = entry.DocumentId;
			IsAlso = entry.IsAlso;
			SeeAlso = entry.SeeAlso;
			Date = entry.Date.ToString();
			Title = entry.Title;
			Keywords = entry.Keywords;
			CurrentStatus = entry.CurrentStatus;
			PublicationStatus = entry.PublicationStatus;
		}
		public RfcIndexEntry(Rfc.RfcBcpEntry entry)
		{
			DocumentId = entry.DocumentId;
			IsAlso = entry.IsAlso;
			Title = entry.Title ?? String.Empty;
			CurrentStatus = Rfc.RfcStatus.BCP;
			PublicationStatus = Rfc.RfcStatus.BCP;
		}
		public RfcIndexEntry(Rfc.RfcFyiEntry entry)
		{
			DocumentId = entry.DocumentId;
			IsAlso = entry.IsAlso;
			Title = entry.Title ?? String.Empty;
			CurrentStatus = Rfc.RfcStatus.FYI;
			PublicationStatus = Rfc.RfcStatus.FYI;
		}
		public RfcIndexEntry(Rfc.RfcStdEntry entry)
		{
			DocumentId = entry.DocumentId;
			IsAlso = entry.IsAlso;
			Title = entry.Title ?? String.Empty;
			CurrentStatus = Rfc.RfcStatus.Standard;
			PublicationStatus = Rfc.RfcStatus.Standard;
		}
		public RfcIndexEntry(Rfc.RfcNotIssuedEntry entry)
		{
			DocumentId = entry.DocumentId;
			Title = "- NOT ISSUED -";
			CurrentStatus = Rfc.RfcStatus.NotIssued;
			PublicationStatus = Rfc.RfcStatus.NotIssued;
		}

		public string DocumentId
		{
			get;
			private set;
		}

		public string Title
		{
			get;
			private set;
		}

		public ICollection<string> IsAlso
		{
			get;
			private set;
		}

		public ICollection<string> SeeAlso
		{
			get;
			private set;
		}

		public string Date
		{
			get;
			private set;
		}

		public ICollection<string> Keywords
		{
			get;
			private set;
		}

		public Rfc.RfcStatus CurrentStatus
		{
			get;
			private set;
		}

		public Rfc.RfcStatus PublicationStatus
		{
			get;
			private set;
		}

	}
}
