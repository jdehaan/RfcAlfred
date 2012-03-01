using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Alfred
{
	static class Remote
	{
		public static Uri BaseUri
		{
			get
			{
				if (_baseUri == null)
				{
					_baseUri = new Uri("ftp://ftp.rfc-editor.org/in-notes/");
				}
				return _baseUri;
			}
		}

		public static Uri Index
		{
			get
			{
				if (_indexUri == null)
				{
					_indexUri = new Uri(BaseUri, "rfc-index.xml");
				}
				return _indexUri;
			}
		}

		private static Uri _indexUri;
		private static Uri _baseUri;
	}
}
