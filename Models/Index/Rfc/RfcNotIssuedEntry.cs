﻿using System;
using System.CodeDom.Compiler;
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
}