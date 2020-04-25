using BCG_UI.Data;
using BCG_UI.Data.Repositories;
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
        private IResourceRepository _resourceRepository;
        private IEventAggregator _evantAggregator;

        public ResourceWrapper _resource;
        public ResourcesDetailedViewModel(IResourceRepository resourceRepository, IEventAggregator eventAggregator)
        {
            _resourceRepository = resourceRepository;
            _evantAggregator = eventAggregator;

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private bool _hasChanges;

        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                if (_hasChanges != value)
                {
                    _hasChanges = value;
                    OnPropertyChanged();
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            }
        }

        private bool OnSaveCanExecute()
        {
            return Resource != null && !Resource.HasErrors && HasChanges;
        }

        private async void OnSaveExecute()
        {

            await _resourceRepository.SaveAsync();
            HasChanges = _resourceRepository.HasChanges();
            _evantAggregator.GetEvent<AfterResourceSavedEvent>().Publish(new AfterResourceSavedEventArgs
            {
                Id = Resource.ResourceID,
                DisplayMember = $"{Resource.ResourceName}"
            });
        }



        public async Task LoadAsync(int resourceId)
        {
            var resource = await _resourceRepository.GetByIdAsync(resourceId);
            Resource = new ResourceWrapper(resource);
            Resource.PropertyChanged += ((s, e) =>
            {
                if (!HasChanges)
                {
                    HasChanges = _resourceRepository.HasChanges();
                }
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
