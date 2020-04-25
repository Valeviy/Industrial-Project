using BCG_UI.Data;
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
   public class ResourceViewModel : ViewModelBase, IResourceViewModel
    {
        
        private IResourceLookupDataService _resourceLookupDataService;
        private IEventAggregator _eventAggregator;

        public ResourceViewModel (IResourceLookupDataService resourceLookupDataService, IEventAggregator eventAggregator)
        {
            _resourceLookupDataService = resourceLookupDataService;
            _eventAggregator = eventAggregator;
            Resources = new ObservableCollection<ResourceItemViewModel>();
            _eventAggregator.GetEvent<AfterResourceSavedEvent>().Subscribe(AfterResourceSaved);
        }

        private void AfterResourceSaved(AfterResourceSavedEventArgs obj)
        {
            var lookupItem = Resources.Single(l => l.Id == obj.Id);
            lookupItem.DisplayMember = obj.DisplayMember;

        }

        public async Task LoadAsync()
        {
            var lookup = await _resourceLookupDataService.GetResourceLookupAsync();
            Resources.Clear();
            foreach (var item in lookup)
            {
                Resources.Add(new ResourceItemViewModel(item.Id, item.DisplayMember));
            }
        }


        public ObservableCollection<ResourceItemViewModel> Resources { get; }

        public ResourceItemViewModel _selectedResource;

  

         public ResourceItemViewModel SelectedResource
        {
            get { return _selectedResource; }
            set 
            { 
                _selectedResource = value;
                OnPropertyChanged();
                if(_selectedResource != null)
                {
                    _eventAggregator.GetEvent<OpenResourceDetailViewEvent>().Publish(_selectedResource.Id);
                }
            }
        }
    }
}
