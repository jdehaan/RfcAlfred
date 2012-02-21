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
	[XmlRoot("rfc-entry", Namespace = "http://www.rfc-editor.org/rfc-index", IsNullable = false)]
	public class RfcEntry
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

		[XmlElement("author")]
		public Author[] Author
		{
			get;
			set;
		}

		[XmlElement("date")]
		public Date Date
		{
			get;
			set;
		}

		[XmlElement("format")]
		public Format[] Format
		{
			get;
			set;
		}

		[XmlArray("keywords")]
		[XmlArrayItem("kw", IsNullable = false)]
		public string[] Keywords
		{
			get;
			set;
		}

		[XmlArray("abstract")]
		[XmlArrayItem("p", IsNullable = false)]
		public string[] Abstract
		{
			get;
			set;
		}

		[XmlElement("draft")]
		public string Draft
		{
			get;
			set;
		}

		[XmlElement("notes")]
		public string Notes
		{
			get;
			set;
		}

		[XmlArray("obsoletes")]
		[XmlArrayItem("doc-id", IsNullable = false)]
		public string[] Obsoletes
		{
			get;
			set;
		}

		[XmlArray("obsoleted-by")]
		[XmlArrayItem("doc-id", IsNullable = false)]
		public string[] ObsoletedBy
		{
			get;
			set;
		}

		[XmlArray("updates")]
		[XmlArrayItem("doc-id", IsNullable = false)]
		public string[] Updates
		{
			get;
			set;
		}

		[XmlArray("updated-by")]
		[XmlArrayItem("doc-id", IsNullable = false)]
		public string[] UpdatedBy
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

		[XmlArray("see-also")]
		[XmlArrayItem("doc-id", IsNullable = false)]
		public string[] SeeAlso
		{
			get;
			set;
		}

		[XmlElement("current-status")]
		public RfcStatus CurrentStatus
		{
			get;
			set;
		}

		[XmlElement("publication-status")]
		public RfcStatus PublicationStatus
		{
			get;
			set;
		}

		[XmlElement("stream")]
		public stream Stream
		{
			get;
			set;
		}

		/// <remarks/>
		[XmlIgnore]
		public bool streamSpecified
		{
			get;
			set;
		}

		[XmlElement("area")]
		public string Area
		{
			get;
			set;
		}

		[XmlElement("wg_acronym")]
		public string WgAcronym
		{
			get;
			set;
		}

		[XmlElement("errata-url")]
		public string ErrataUrl
		{
			get;
			set;
		}
	}

}
