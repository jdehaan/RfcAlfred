using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Alfred.Models.Index.Rfc;

namespace Alfred.Models.Index
{
    public class RfcIndex
    {
        private readonly rfcindex _index;
        private IRfcIndexEntry[] _entries;

        private RfcIndex(rfcindex index)
        {
            _index = index;
        }

        public ICollection<IRfcIndexEntry> Entries
        {
            get
            {
                if (_entries == null)
                {
                    var entries = new List<IRfcIndexEntry>();
                    entries.AddRange(_index.RfcEntry.Select(x => new RfcIndexEntry(x)));
                    entries.AddRange(_index.StdEntry.Select(x => new RfcIndexEntry(x)));
                    entries.AddRange(_index.FyiEntry.Select(x => new RfcIndexEntry(x)));
                    entries.AddRange(_index.BcpEntry.Select(x => new RfcIndexEntry(x)));
                    entries.AddRange(_index.RfcNotIssuedEntry.Select(x => new RfcIndexEntry(x)));
                    _entries = entries.OrderBy(x => x.DocumentId).ToArray();
                }
                return _entries;
            }
        }

        public static RfcIndex FromFile(String fileName)
        {
            var s = new XmlSerializer(typeof (rfcindex));
            using (XmlReader reader = XmlReader.Create(fileName))
            {
                var index = s.Deserialize(reader) as rfcindex;
                return new RfcIndex(index);
            }
        }
    }
}