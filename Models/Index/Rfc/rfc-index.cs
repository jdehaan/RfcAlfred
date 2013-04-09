using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Alfred.Models.Index.Rfc
{
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "http://www.rfc-editor.org/rfc-index", IsNullable = false)]
    public class RfcDate
    {
        [XmlElement("month")]
        public MonthName Month { get; set; }

        [XmlElement("day", DataType = "integer")]
        public string Day { get; set; }

        [XmlElement("year", DataType = "gYear")]
        public string Year { get; set; }

        public override string ToString()
        {
            return String.Format("{0}-{1}-{2}", Year, Month, Day);
        }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.rfc-editor.org/rfc-index")]
    public enum MonthName
    {
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December,
    }

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "http://www.rfc-editor.org/rfc-index", IsNullable = false)]
    public class Format
    {
        [XmlElement("file-format")]
        public FileFormat FileFormat { get; set; }

        [XmlElement("char-count", DataType = "nonNegativeInteger")]
        public string CharacterCount { get; set; }

        /// <remarks />
        [XmlElement("page-count", DataType = "nonNegativeInteger")]
        public string PageCount { get; set; }
    }

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "http://www.rfc-editor.org/rfc-index", IsNullable = false)]
    public class keywords
    {
        [XmlElement("kw")]
        public string[] kw { get; set; }
    }

    [Serializable]
    [XmlType(Namespace = "http://www.rfc-editor.org/rfc-index")]
    public enum stream
    {
        IETF,
        IAB,
        IRTF,
        INDEPENDENT,
        Legacy,
    }

    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlRoot("rfc-index", Namespace = "http://www.rfc-editor.org/rfc-index", IsNullable = false)]
    public class rfcindex
    {
        [XmlElement("std-entry")]
        public RfcStdEntry[] StdEntry { get; set; }

        [XmlElement("bcp-entry")]
        public RfcBcpEntry[] BcpEntry { get; set; }

        [XmlElement("fyi-entry")]
        public RfcFyiEntry[] FyiEntry { get; set; }

        [XmlElement("rfc-entry")]
        public RfcEntry[] RfcEntry { get; set; }

        [XmlElement("rfc-not-issued-entry")]
        public RfcNotIssuedEntry[] RfcNotIssuedEntry { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }
    }
}