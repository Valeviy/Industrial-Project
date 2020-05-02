using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCG_UI.ViewModel
{
	public class BGroupItemViewModel : ViewModelBase
	{
		private string _displayMember;

		public BGroupItemViewModel(int id, string displayMember, float? validDisbalance,
			string detailedViewModelName)
		{
			Id = id;
			DisplayMember = displayMember;
			ValidDisbalance = validDisbalance;
			DetailedViewModelName = detailedViewModelName;

		}

		public int Id { get; }

		public string DisplayMember
		{
			get { return _displayMember; }
			set
			{
				_displayMember = value;
				OnPropertyChanged();
			}
		}

		private float? _validDisbalance;

		public float? ValidDisbalance
		{
			get { return _validDisbalance; }
			set
			{
				_validDisbalance = value;
				OnPropertyChanged();
			}
		}

		private ICollection<BGroupItemViewModel> _bGroupsChildren;
		public ICollection<BGroupItemViewModel> BGroupsChildren
		{
			get { return _bGroupsChildren; }
			set
			{
				_bGroupsChildren = value;
				OnPropertyChanged();
			}
		}

		public string DetailedViewModelName { get; }

	}
}
