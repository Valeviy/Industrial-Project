using BCG_UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BCG_UI.ViewModel
{
	//implemented F1.6 requirement
	public class ResourceItemViewModel : ViewModelBase
	{
		private string _displayMember;

		public ResourceItemViewModel(int id, string displayMember,
			string detailedViewModelName)
		{
			Id = id;
			DisplayMember = displayMember;
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

		public string DetailedViewModelName { get; }

	}

}
