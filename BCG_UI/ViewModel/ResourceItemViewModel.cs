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
	public class ResourceItemViewModel : ViewModelBase
	{
		private readonly IEventAggregator _eventAggregator;
		private string _displayMember;

		public ResourceItemViewModel(int id, string displayMember, IEventAggregator eventAggregator,
			string detailedViewModelName)
		{
			Id = id;
			DisplayMember = displayMember;
			_eventAggregator = eventAggregator;
			OpenDetailViewCommand = new DelegateCommand(OpenDetailView);
		    _detailedViewModelName = detailedViewModelName;
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

		public ICommand OpenDetailViewCommand { get; }

		private string _detailedViewModelName;

		public void OpenDetailView()
		{
			_eventAggregator.GetEvent<OpenDetailViewEvent>().Publish(new OpenDetailViewEventArgs
			{
				Id = Id,
				ViewModelName = _detailedViewModelName
			}
		);

		}
	}

}
