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

		public static Uri IndexUri
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

        public static Uri GetDocumentUri(String documentId)
        {
            String type = documentId.Substring(0, 3).ToLowerInvariant();
            int id = Convert.ToInt32(documentId.Substring(3));
            String filepath;
            if (type != "rfc")
                filepath = String.Format("{0}/{0}{1}.txt", type, id);
            else
                filepath = String.Format("{0}{1}.txt", type, id);

            return new Uri(BaseUri, filepath);
        }
        
        private static Uri _indexUri;
		private static Uri _baseUri;
	}
}
