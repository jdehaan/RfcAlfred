using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Alfred.Models.Index.Rfc
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlRoot("rfc-not-issued-entry", Namespace = "http://www.rfc-editor.org/rfc-index", IsNullable = false)]
    public class RfcNotIssuedEntry
    {
        [XmlElement("doc-id")]
        public string DocumentId { get; set; }

        public override string ToString()
        {
            return String.Format("{0}", DocumentId);
        }
    }
}