using BCG_UI.Data;
using BCG_UI.Event;
using Model;
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
    public class ResourcesDetailedViewModel : ViewModelBase, IResourcesDetailedViewModel
    {
        private IResourceDataService _dataService;
        private IEventAggregator _evantAggregator;

        public ResourceWrapper _resource;
        public ResourcesDetailedViewModel(IResourceDataService dataService, IEventAggregator eventAggregator)
        {
            _dataService = dataService;
            _evantAggregator = eventAggregator;
            _evantAggregator.GetEvent<OpenResourceDetailViewEvent>().Subscribe(OpenResourceDetailView);

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private bool OnSaveCanExecute()
        {
            return Resource != null && !Resource.HasErrors;
        }

        private async void OnSaveExecute()
        {
           await _dataService.SaveAsync(Resource.Model);
            _evantAggregator.GetEvent<AfterResourceSavedEvent>().Publish(new AfterResourceSavedEventArgs
            {
                Id = Resource.ResourceID,
                DisplayMember = $"{Resource.ResourceName}"
            });
        }

        public async void OpenResourceDetailView (int resourceId)
        {
            await LoadAsync(resourceId);
        }

        public async Task LoadAsync(int resourceId)
        {
            var resource = await _dataService.GetByIdAsync(resourceId);
            Resource = new ResourceWrapper(resource);
            Resource.PropertyChanged += ((s, e) =>
            {
                if (e.PropertyName == nameof(Resource.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();

                }
            });
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
       
    }


        public ResourceWrapper Resource
        {
            get { return _resource; }
            private set
            {
                _resource = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; set; }
    }
}
