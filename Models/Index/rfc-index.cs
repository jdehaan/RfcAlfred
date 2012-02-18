using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Rfc
{

	[Serializable]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlRoot(Namespace = "http://www.rfc-editor.org/rfc-index", IsNullable = false)]
	public class Author
	{
		[XmlElement("name")]
		public string Name
		{
			get;
			set;
		}

		[XmlElement("title")]
		public string Title
		{
			get;
			set;
		}

		[XmlElement("organization")]
		public string Organization
		{
			get;
			set;
		}

		[XmlElement("org-abbrev")]
		public string OrganisationAbbreviation
		{
			get;
			set;
		}
	}

	[Serializable]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlRoot(Namespace = "http://www.rfc-editor.org/rfc-index", IsNullable = false)]
	public class Date
	{
		[XmlElement("month")]
		public MonthName Month
		{
			get;
			set;
		}

		[XmlElement("day", DataType = "integer")]
		public string Day
		{
			get;
			set;
		}

		[XmlElement("year", DataType = "gYear")]
		public string Year
		{
			get;
			set;
		}

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
		public FileFormat FileFormat
		{
			get;
			set;
		}

		[XmlElement("char-count", DataType = "nonNegativeInteger")]
		public string CharacterCount
		{
			get;
			set;
		}

		/// <remarks/>
		[XmlElement("page-count", DataType = "nonNegativeInteger")]
		public string PageCount
		{
			get;
			set;
		}
	}

	[Serializable]
	[XmlType(Namespace = "http://www.rfc-editor.org/rfc-index")]
	public enum FileFormat
	{
		ASCII,
		PS,
		PDF,
	}

	[Serializable]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlRoot(Namespace = "http://www.rfc-editor.org/rfc-index", IsNullable = false)]
	public partial class keywords
	{
		[XmlElement("kw")]
		public string[] kw
		{
			get;
			set;
		}
	}

	[Serializable]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlRoot("std-entry", Namespace = "http://www.rfc-editor.org/rfc-index", IsNullable = false)]
	public partial class stdentry
	{
		public override string ToString()
		{
			return String.Format("{0} - {1}", DocumentId, Title);
		}

		[XmlElement("doc-id")]
		public string DocumentId
		{
			get;
			set;
		}

		[XmlElement("title")]
		public string Title
		{
			get;
			set;
		}

		[XmlArray("is-also")]
		[XmlArrayItem("doc-id", IsNullable = false)]
		public string[] IsAlso
		{
			get;
			set;
		}
	}

	[Serializable]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(AnonymousType = true, Namespace = "http://www.rfc-editor.org/rfc-index")]
	[XmlRoot("bcp-entry", Namespace = "http://www.rfc-editor.org/rfc-index", IsNullable = false)]
	public partial class bcpentry
	{
		public override string ToString()
		{
			return String.Format("{0} - {1}", DocumentId, Title);
		}

		[XmlElement("doc-id")]
		public string DocumentId
		{
			get;
			set;
		}

		[XmlElement("title")]
		public string Title
		{
			get;
			set;
		}

		[XmlArray("is-also")]
		[XmlArrayItem("doc-id", IsNullable = false)]
		public string[] IsAlso
		{
			get;
			set;
		}
	}

	[Serializable]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlRoot("fyi-entry", Namespace = "http://www.rfc-editor.org/rfc-index", IsNullable = false)]
	public partial class fyientry
	{
		public override string ToString()
		{
			return String.Format("{0} - {1}", DocumentId, Title);
		}

		[XmlElement("doc-id")]
		public string DocumentId
		{
			get;
			set;
		}

		[XmlElement("title")]
		public string Title
		{
			get;
			set;
		}

		[XmlArray("is-also")]
		[XmlArrayItem("doc-id", IsNullable = false)]
		public string[] IsAlso
		{
			get;
			set;
		}
	}

	[Serializable]
	[XmlType(Namespace = "http://www.rfc-editor.org/rfc-index")]
	public enum status
	{
		[XmlEnum("STANDARD")]
		Standard,

		[XmlEnum("DRAFT STANDARD")]
		Draft,

		[XmlEnum("PROPOSED STANDARD")]
		Proposed,

		[XmlEnum("UNKNOWN")]
		Unknown,

		[XmlEnum("BEST CURRENT PRACTICE")]
		BCP,

		[XmlEnum("FOR YOUR INFORMATION")]
		FYI,

		[XmlEnum("EXPERIMENTAL")]
		Experimental,

		[XmlEnum("HISTORIC")]
		Historic,

		[XmlEnum("INFORMATIONAL")]
		Informational,
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
	[XmlRoot("rfc-not-issued-entry", Namespace = "http://www.rfc-editor.org/rfc-index", IsNullable = false)]
	public partial class rfcnotissuedentry
	{
		public override string ToString()
		{
			return String.Format("{0}", DocumentId);
		}

		[XmlElement("doc-id")]
		public string DocumentId
		{
			get;
			set;
		}
	}

	[Serializable]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlRoot("rfc-index", Namespace = "http://www.rfc-editor.org/rfc-index", IsNullable = false)]
	public class rfcindex
	{
		[XmlElement("std-entry")]
		public stdentry[] StdEntry
		{
			get;
			set;
		}

		[XmlElement("bcp-entry")]
		public bcpentry[] BcpEntry
		{
			get;
			set;
		}

		[XmlElement("fyi-entry")]
		public fyientry[] FyiEntry
		{
			get;
			set;
		}

		[XmlElement("rfc-entry")]
		public RfcEntry[] RfcEntry
		{
			get;
			set;
		}

		[XmlElement("rfc-not-issued-entry")]
		public rfcnotissuedentry[] RfcNotIssuedEntry
		{
			get;
			set;
		}

		[XmlAttribute("title")]
		public string Title
		{
			get;
			set;
		}
	}
}
