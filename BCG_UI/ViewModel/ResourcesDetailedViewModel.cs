using BCG_UI.Data;
using BCG_UI.Data.Lookups;
using BCG_UI.Data.Repositories;
using BCG_UI.Event;
using BCG_UI.View.Services;
using BCG_UI.ViewModel.Wrapper;
using Model;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private IMessageDialogService _messageDialogService;

        public ResourceWrapper _resource;
        public ResourcesDetailedViewModel(IResourceRepository resourceRepository, IEventAggregator eventAggregator, IMessageDialogService messageDialogService )
        {
            _resourceRepository = resourceRepository;
            _evantAggregator = eventAggregator;
            _messageDialogService = messageDialogService;

            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
            DeleteCommand = new DelegateCommand(OnDeleteExecute);

            AddBGroupCommand = new DelegateCommand(OnAddBGroupExecute);
            RemoveBGroupCommand = new DelegateCommand(OnRemoveBGroupExecute, OnRemoveBGoupCanExecute);

            BGroups = new ObservableCollection<ResourceBGroupWrapper>();
        }

        private void OnRemoveBGroupExecute()
        {
            throw new NotImplementedException();
        }

        private void OnAddBGroupExecute()
        {
            throw new NotImplementedException();
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
            return Resource != null && !Resource.HasErrors && HasChanges && BGroups.All(pn => !pn.HasErrors);
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



        public async Task LoadAsync(int? resourceId)
        {
            var resource = resourceId.HasValue
            ? await _resourceRepository.GetByIdAsync(resourceId.Value)
            : CreateNewResource();

            //InitializeResource
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
            if (Resource.ResourceID == 0)
            {
                Resource.ResourceName = "";
            }
          
           

            //initialize BGroups
            InitializeBGroups(Resource.BGroups);

        }

        private void InitializeBGroups(ICollection<BGroups> bGroups)
        {
            foreach (var wrapper in BGroups)
            {
                wrapper.PropertyChanged -= ResourceBGroupWrapper_PropertyChanged;
            }
            BGroups.Clear();
            foreach (var bGroup in bGroups)
            {
                var wrapper = new ResourceBGroupWrapper(bGroup);
                BGroups.Add(wrapper);
                wrapper.PropertyChanged += ResourceBGroupWrapper_PropertyChanged;
            }
        }

        private void ResourceBGroupWrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!HasChanges)
            {
                HasChanges = _resourceRepository.HasChanges();
            }
            if (e.PropertyName == nameof(ResourceBGroupWrapper.HasErrors))
            {
                ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            }
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

        private Resources CreateNewResource()
        {
            var resource = new Resources();
            _resourceRepository.Add(resource);
            return resource;

        }

        public ICommand DeleteCommand { get; }

        private async void OnDeleteExecute()
        {

            var result = _messageDialogService.ShowOkCancelDialog($"Do you really want to delete the Resource {Resource.ResourceName}?", "Question");
            if (result == MessageDialogResult.OK){
                _resourceRepository.Remove(Resource.Model);
                await _resourceRepository.SaveAsync();
                _evantAggregator.GetEvent<AfterResourceDeletedEvent>().Publish(Resource.ResourceID);
            }
        }

        public ObservableCollection<ResourceBGroupWrapper> BGroups { get; }

        public ICommand AddBGroupCommand { get; }
        public ICommand RemoveBGroupCommand { get; }

        private ResourceBGroupWrapper _selectedBGroup;
        public ResourceBGroupWrapper SelectedBGroup
        {
            get { return _selectedBGroup; }
            set
            {
                _selectedBGroup = value;
                OnPropertyChanged();
                ((DelegateCommand)RemoveBGroupCommand).RaiseCanExecuteChanged();
            }
        }

        private bool OnRemoveBGoupCanExecute()
        {
            return SelectedBGroup != null;
        }

    }
}
