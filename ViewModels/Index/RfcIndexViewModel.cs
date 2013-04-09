using System.Collections.Generic;
using System.Linq;
using Alfred.Models.Index;

namespace Alfred.ViewModels.Index
{
    public class RfcIndexViewModel
    {
        private readonly RfcIndex _model;

        public RfcIndexViewModel(RfcIndex index)
        {
            _model = index;
        }

        public IEnumerable<RfcIndexEntryViewModel> Entries
        {
            get { return _model.Entries.Select(x => new RfcIndexEntryViewModel(x)); }
        }
    }
}