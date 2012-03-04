using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Alfred.Models.Index.Rfc
{

	[Serializable]
	[XmlType(Namespace = "http://www.rfc-editor.org/rfc-index")]
	public enum FileFormat
	{
		[XmlEnum("ASCII")]
		Ascii,
		[XmlEnum("PS")]
		Postscript,
		[XmlEnum("PDF")]
		Pdf,
	}

}
