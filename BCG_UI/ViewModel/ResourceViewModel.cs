using BCG_UI.Data;
using BCG_UI.Data.Lookups;
using BCG_UI.Event;
using Model;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCG_UI.ViewModel
{
    //implemented F1.6 requirement
    public class ResourceViewModel : ViewModelBase, IResourceViewModel
    {

        private ILookupDataService _lookupDataService;
        private IEventAggregator _eventAggregator;

        public ResourceViewModel(ILookupDataService lookupDataService, IEventAggregator eventAggregator)
        {
            _lookupDataService = lookupDataService;
            _eventAggregator = eventAggregator;
            Resources = new ObservableCollection<ResourceItemViewModel>();
        }


        public async Task LoadAsync()
        {
            var lookup = await _lookupDataService.GetResourceLookupAsync();
            Resources.Clear();
            foreach (var item in lookup)
            {
                Resources.Add(new ResourceItemViewModel(item.Id, item.DisplayMember, nameof(BGroupDetailedViewModel)));
            }
        }


        public ObservableCollection<ResourceItemViewModel> Resources { get; }

        public ResourceItemViewModel _selectedResource;

        public void OpenDetailView(ResourceItemViewModel var)
        {
            _eventAggregator.GetEvent<OpenDetailViewEvent>().Publish(new OpenDetailViewEventArgs
            {
                Id = var.Id,
                ViewModelName = var.DetailedViewModelName
            });
     
        }
        
        public ResourceItemViewModel SelectedResource
        {
            get { return _selectedResource; }
            set
            {
                _selectedResource = value;
                OnPropertyChanged();
                if (_selectedResource != null)
                {
                    OpenDetailView(_selectedResource);
                }
            }
        }
    }
}
