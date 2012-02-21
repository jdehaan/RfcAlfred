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
}
