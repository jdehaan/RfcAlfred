using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alfred.Models.Index
{
	public interface IRfcIndexEntry
	{
		string DocumentId { get; }

		string Date { get; }

		string Title { get; }

		string IsAlso { get; }

		string Keywords { get; }

		Rfc.RfcStatus CurrentStatus { get; }

		Rfc.RfcStatus PublicationStatus { get; }
	}
}
