using Alfred.Models.Index;

namespace Alfred.Views.Document
{
    public interface IRfcDocumentContainer
    {
        void AddDocument(IRfcIndexEntry document);
    }
}