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

		public Rfc.RfcEntry[] Entries
		{
			get
			{
				return _index.RfcEntry;
			}
		}

		private Rfc.rfcindex _index;
	}
}
