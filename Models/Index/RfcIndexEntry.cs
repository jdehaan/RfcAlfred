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
			Date = entry.Date.ToString();
			Title = entry.Title;
			if (entry.Keywords == null || entry.Keywords.Length == 0)
				Keywords = String.Empty;
			else 
				Keywords = String.Join(";", entry.Keywords);
			CurrentStatus = entry.CurrentStatus;
			PublicationStatus = entry.PublicationStatus;
		}
		public RfcIndexEntry(Rfc.RfcBcpEntry entry)
		{
			DocumentId = entry.DocumentId;
			if (entry.IsAlso == null || entry.IsAlso.Length == 0)
				Title = String.Empty;
			else
				Title = String.Join(";", entry.IsAlso);
			CurrentStatus = Rfc.RfcStatus.BCP;
			PublicationStatus = Rfc.RfcStatus.BCP;
		}
		public RfcIndexEntry(Rfc.RfcFyiEntry entry)
		{
			DocumentId = entry.DocumentId;
			if (entry.IsAlso == null || entry.IsAlso.Length == 0)
				Title = String.Empty;
			else
				Title = String.Join(";", entry.IsAlso);
			CurrentStatus = Rfc.RfcStatus.FYI;
			PublicationStatus = Rfc.RfcStatus.FYI;
		}
		public RfcIndexEntry(Rfc.RfcStdEntry entry)
		{
			DocumentId = entry.DocumentId;
			if (entry.IsAlso == null || entry.IsAlso.Length == 0)
				Title = String.Empty;
			else
				Title = String.Join(";", entry.IsAlso);
			CurrentStatus = Rfc.RfcStatus.Standard;
			PublicationStatus = Rfc.RfcStatus.Standard;
		}
		public RfcIndexEntry(Rfc.RfcNotIssuedEntry entry)
		{
			DocumentId = entry.DocumentId;
			Title = "- NOT ISSUED -";
			CurrentStatus = Rfc.RfcStatus.Unknown;
			PublicationStatus = Rfc.RfcStatus.Unknown;
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

		public string IsAlso
		{
			get;
			private set;
		}

		public string Date
		{
			get;
			private set;
		}

		public string Keywords
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
