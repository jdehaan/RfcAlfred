using System;
using System.Xml.Serialization;

namespace Alfred.Models.Index.Rfc
{
    [Serializable]
    [XmlType(Namespace = "http://www.rfc-editor.org/rfc-index")]
    public enum RfcStatus
    {
        [XmlEnum("INTERNET STANDARD")] Standard,

        [XmlEnum("DRAFT STANDARD")] Draft,

        [XmlEnum("PROPOSED STANDARD")] Proposed,

        [XmlEnum("UNKNOWN")] Unknown,

        [XmlEnum("BEST CURRENT PRACTICE")] BCP,

        [XmlEnum("FOR YOUR INFORMATION")] FYI,

        [XmlEnum("EXPERIMENTAL")] Experimental,

        [XmlEnum("HISTORIC")] Historic,

        [XmlEnum("INFORMATIONAL")] Informational,

        [XmlIgnore] NotIssued
    }
}