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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BCG_UI.ViewModel
{

    public class BGroupDetailedViewModel : DetailViewModelBase, IBGroupDetailedViewModel
    {
        private IBGroupRepository _bGroupRepository;
        private IMessageDialogService _messageDialogService;

        public BGroupDetailedViewModel(IBGroupRepository bGroupRepository, IEventAggregator eventAggregator, IMessageDialogService messageDialogService ): base(eventAggregator)
        {
            _bGroupRepository = bGroupRepository;
            _messageDialogService = messageDialogService;

            AddBGroupCommand = new DelegateCommand(OnAddBGroupExecute);
            RemoveBGroupCommand = new DelegateCommand(OnRemoveBGroupExecute, OnRemoveBGoupCanExecute);

            BGroups = new ObservableCollection<BGroupWrapper>();
        }

        private void OnRemoveBGroupExecute()
        {
         //   SelectedBGroup.PropertyChanged -= BGroupWrapper_PropertyChanged;
	        //_resourceRepository.RemoveBGroup(SelectedBGroup.Model);
	        //BGroups.Remove(SelectedBGroup);
	        //SelectedBGroup = null;
	        //HasChanges = _resourceRepository.HasChanges();
	        //((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        private void OnAddBGroupExecute()
        {
            //var newBGroup = new BGroupWrapper(new BGroups());
            //newBGroup.PropertyChanged += BGroupWrapper_PropertyChanged;
            //BGroups.Add(newBGroup);
            //Resource.Model.BGroups.Add(newBGroup.Model);
            //newBGroup.BGroupName = "";
        }


        protected override bool OnSaveCanExecute()
        {
            return true;
            // return Resource != null && !Resource.HasErrors && HasChanges && BGroups.All(pn => !pn.HasErrors);
        }

        protected override async void OnSaveExecute()
        {

            //await _resourceRepository.SaveAsync();
            //HasChanges = _resourceRepository.HasChanges();
            //RaiseDetailSavedEvent(Resource.ResourceID, $"");
        }



        public override async Task LoadAsync(int? resourceId)
        {
            ICollection <BGroups> bGroups = await _bGroupRepository.GetRootsAsync(resourceId.Value);

            ObservableCollection<BGroupWrapper> groups = new ObservableCollection<BGroupWrapper>();

            foreach (var item in bGroups)
            {
                groups.Add(new BGroupWrapper(item));
            }

            foreach (var item in groups)
            {
                LoadSubGroups(item);
            }

           InitializeBGroups(groups);

        }


        private void LoadSubGroups(BGroupWrapper item)
        {

            ICollection<BGroups> result =  _bGroupRepository.GetChildrenAsync(item.Model.BGroupID);
            ObservableCollection<BGroupWrapper> groups = new ObservableCollection<BGroupWrapper>();

            if (result != null)
            {
                foreach (var subitem in result)
                {
                    groups.Add(new BGroupWrapper(subitem));
                }

                item.BGroupsChildren = groups;
                foreach (var subitem1 in item.BGroupsChildren)
                {
                    LoadSubGroups(subitem1);
                }
            }
        }


        private void InitializeBGroups(ICollection<BGroupWrapper> bGroups)
        {
            foreach (var wrapper in BGroups)
            {
                wrapper.PropertyChanged -= BGroupWrapper_PropertyChanged;
            }
            BGroups.Clear();

            foreach (var bGroup in bGroups)
            {
                BGroups.Add(bGroup);
                bGroup.PropertyChanged += BGroupWrapper_PropertyChanged;
            }

        }
       

        private void BGroupWrapper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!HasChanges)
            {
                HasChanges = _bGroupRepository.HasChanges();
            }
            if (e.PropertyName == nameof(BGroupWrapper.HasErrors))
            {
                ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
            }
        }


        protected override async void OnDeleteExecute()
        {

        //    var result = _messageDialogService.ShowOkCancelDialog($"Do you really want to delete the Resource {Resource.ResourceName}?", "Question");
        //    if (result == MessageDialogResult.OK){
        //        _resourceRepository.Remove(Resource.Model);
        //        await _resourceRepository.SaveAsync();
        //        RaiseDetailDeletedEvent(Resource.ResourceID);            
        //    }
        }

        public ObservableCollection<BGroupWrapper> BGroups { get; }

     

        public ICommand AddBGroupCommand { get; }
        public ICommand RemoveBGroupCommand { get; }

    

        private BGroupWrapper _selectedBGroup;
        public BGroupWrapper SelectedBGroup
        {
            get { return _selectedBGroup; }
            set
            {
                _selectedBGroup = value;
                OnPropertyChanged();
            }
        }

        private bool OnRemoveBGoupCanExecute()
        {
            return SelectedBGroup != null;
        }

    }
}
