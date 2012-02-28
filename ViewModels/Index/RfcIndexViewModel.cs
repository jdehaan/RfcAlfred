using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Alfred.Models.Index;

namespace Alfred.ViewModels.Index
{
	public class RfcIndexViewModel
	{
		public RfcIndexViewModel(RfcIndex index)
		{
			_model = index;
		}

		public IEnumerable<RfcIndexEntryViewModel> Entries
		{
			get
			{
				return _model.Entries.Select(x => new RfcIndexEntryViewModel(x));
			}
		}

		private RfcIndex _model;
	}
}
