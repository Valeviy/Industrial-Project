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

		public ResourceItemViewModel(int id, string displayMember, IEventAggregator eventAggregator
			)
		{
			Id = id;
			DisplayMember = displayMember;
			_eventAggregator = eventAggregator;
			OpenResourceDetailViewCommand = new DelegateCommand(OpenResourceDetailView);
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

		public ICommand OpenResourceDetailViewCommand { get; }

		public void OpenResourceDetailView()
		{
			_eventAggregator.GetEvent<OpenResourceDetailViewEvent>().Publish(Id);

		}
	}

}
