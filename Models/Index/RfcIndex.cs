using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Alfred.Models.Index
{
	public class RfcIndex
	{
		private RfcIndex(Rfc.rfcindex index)
		{
			_index = index;
		}

		public static RfcIndex FromFile(String fileName)
		{
			var s = new XmlSerializer(typeof(Rfc.rfcindex));
			using (var reader = XmlReader.Create(fileName))
			{
				var index = s.Deserialize(reader) as Rfc.rfcindex;
				return new RfcIndex(index);
			}
		}

		public ICollection<IRfcIndexEntry> Entries
		{
			get
			{
				if (_entries == null)
				{
					var entries = new List<IRfcIndexEntry>();
					entries.AddRange(_index.RfcEntry.Select( x => new RfcIndexEntry(x)));
					entries.AddRange(_index.StdEntry.Select( x => new RfcIndexEntry(x)));
					entries.AddRange(_index.FyiEntry.Select( x => new RfcIndexEntry(x)));
					entries.AddRange(_index.BcpEntry.Select(x => new RfcIndexEntry(x)));
					entries.AddRange(_index.RfcNotIssuedEntry.Select(x => new RfcIndexEntry(x)));
					_entries = entries.OrderBy(x => x.DocumentId).ToArray();
				}
				return _entries;
			}
		}

		private IRfcIndexEntry[] _entries;
		private Rfc.rfcindex _index;
	}
}
