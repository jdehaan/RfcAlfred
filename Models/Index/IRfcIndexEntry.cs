using System.Collections.Generic;
using Alfred.Models.Index.Rfc;

namespace Alfred.Models.Index
{
    public interface IRfcIndexEntry
    {
        string DocumentId { get; }

        string Date { get; }

        string Title { get; }

        ICollection<string> IsAlso { get; }

        ICollection<string> SeeAlso { get; }

        ICollection<string> Keywords { get; }

        string Abstract { get; }

        RfcStatus CurrentStatus { get; }

        RfcStatus PublicationStatus { get; }
    }
}