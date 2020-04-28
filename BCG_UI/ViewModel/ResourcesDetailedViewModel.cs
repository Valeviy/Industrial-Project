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

    public class ResourcesDetailedViewModel : DetailViewModelBase, IResourcesDetailedViewModel
    {
        private IResourceRepository _resourceRepository;
        private IMessageDialogService _messageDialogService;

        public ResourceWrapper _resource;
        public ResourcesDetailedViewModel(IResourceRepository resourceRepository, IEventAggregator eventAggregator, IMessageDialogService messageDialogService ): base(eventAggregator)
        {
            _resourceRepository = resourceRepository;
            _messageDialogService = messageDialogService;

            AddBGroupCommand = new DelegateCommand(OnAddBGroupExecute);
            RemoveBGroupCommand = new DelegateCommand(OnRemoveBGroupExecute, OnRemoveBGoupCanExecute);

            BGroups = new ObservableCollection<ResourceBGroupWrapper>();
        }

        private void OnRemoveBGroupExecute()
        {
            SelectedBGroup.PropertyChanged -= ResourceBGroupWrapper_PropertyChanged;
	        _resourceRepository.RemoveBGroup(SelectedBGroup.Model);
	        BGroups.Remove(SelectedBGroup);
	        SelectedBGroup = null;
	        HasChanges = _resourceRepository.HasChanges();
	        ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        private void OnAddBGroupExecute()
        {
            var newBGroup = new ResourceBGroupWrapper(new BGroups());
            newBGroup.PropertyChanged += ResourceBGroupWrapper_PropertyChanged;
            BGroups.Add(newBGroup);
            Resource.Model.BGroups.Add(newBGroup.Model);
            newBGroup.BGroupName = "";
        }


        protected override bool OnSaveCanExecute()
        {
            return Resource != null && !Resource.HasErrors && HasChanges && BGroups.All(pn => !pn.HasErrors);
        }

        protected override async void OnSaveExecute()
        {

            await _resourceRepository.SaveAsync();
            HasChanges = _resourceRepository.HasChanges();
            RaiseDetailSavedEvent(Resource.ResourceID, $"");
        }



        public override async Task LoadAsync(int? resourceId)
        {
            var resource = resourceId.HasValue
            ? await _resourceRepository.GetByIdAsync(resourceId.Value)
            : CreateNewResource();

            //InitializeResource
            InitializeResource(resource);



            //initialize BGroups
            InitializeBGroups(Resource.BGroups);

        }

        private void InitializeResource(Resources resource)
        {
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


        private Resources CreateNewResource()
        {
            var resource = new Resources();
            _resourceRepository.Add(resource);
            return resource;

        }

        protected override async void OnDeleteExecute()
        {

            var result = _messageDialogService.ShowOkCancelDialog($"Do you really want to delete the Resource {Resource.ResourceName}?", "Question");
            if (result == MessageDialogResult.OK){
                _resourceRepository.Remove(Resource.Model);
                await _resourceRepository.SaveAsync();
                RaiseDetailDeletedEvent(Resource.ResourceID);            
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
