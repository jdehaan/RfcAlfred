using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Alfred.Models.Index.Rfc
{
	[Serializable]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(AnonymousType = true, Namespace = "http://www.rfc-editor.org/rfc-index")]
	[XmlRoot("bcp-entry", Namespace = "http://www.rfc-editor.org/rfc-index", IsNullable = false)]
	public class RfcBcpEntry
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
}
