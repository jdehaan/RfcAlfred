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

		public IRfcIndexEntry[] Entries
		{
			get
			{
				if (_entries == null)
				{
					var entries = new List<IRfcIndexEntry>();
					entries.AddRange(_index.RfcEntry);
					entries.AddRange(_index.StdEntry);
					entries.AddRange(_index.FyiEntry);
					entries.AddRange(_index.BcpEntry);
					entries.AddRange(_index.RfcNotIssuedEntry);
					_entries = entries.OrderBy(x => x.DocumentId).ToArray();
				}
				return _entries;
			}
		}

		private IRfcIndexEntry[] _entries;
		private Rfc.rfcindex _index;
	}
}
