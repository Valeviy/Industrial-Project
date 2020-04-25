using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCG_UI.ViewModel
{
	public class ResourceItemViewModel : ViewModelBase
	{
		private string _displayMember;

		public ResourceItemViewModel(int id, string displayMember)
		{
			Id = id;
			DisplayMember = displayMember;
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
	}

}
