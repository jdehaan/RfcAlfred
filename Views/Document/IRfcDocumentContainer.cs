using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Alfred.Models.Index;

namespace Alfred.Views.Document
{
    public interface IRfcDocumentContainer
    {
        void AddDocument(IRfcIndexEntry document);
    }
}
