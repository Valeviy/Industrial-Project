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
    public class ResourceViewModel : ViewModelBase, IResourceViewModel
    {

        private ILookupDataService _lookupDataService;
        private IEventAggregator _eventAggregator;

        public ResourceViewModel(ILookupDataService lookupDataService, IEventAggregator eventAggregator)
        {
            _lookupDataService = lookupDataService;
            _eventAggregator = eventAggregator;
            Resources = new ObservableCollection<ResourceItemViewModel>();
            _eventAggregator.GetEvent<AfterResourceSavedEvent>().Subscribe(AfterResourceSaved);
            _eventAggregator.GetEvent<AfterResourceDeletedEvent>().Subscribe(AfterResourceDeleted);
        }

        private void AfterResourceSaved(AfterResourceSavedEventArgs obj)
        {
            var lookupItem = Resources.SingleOrDefault(l => l.Id == obj.Id);
            if (lookupItem == null)
            {
                Resources.Add(new ResourceItemViewModel(obj.Id, obj.DisplayMember,_eventAggregator ));
            }
            else
            {

                lookupItem.DisplayMember = obj.DisplayMember;
            }
        }

        public async Task LoadAsync()
        {
            var lookup = await _lookupDataService.GetResourceLookupAsync();
            Resources.Clear();
            foreach (var item in lookup)
            {
                Resources.Add(new ResourceItemViewModel(item.Id, item.DisplayMember,_eventAggregator));
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
                if (_selectedResource != null)
                {
                }
            }
        }

        private void AfterResourceDeleted(int resourceId)
        {
            var resource = Resources.SingleOrDefault(f => f.Id == resourceId);
            if (resource != null)
            {
                Resources.Remove(resource);
            }
        }
    }
}
