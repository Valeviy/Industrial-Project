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
    //implemented F1.7 requirement
    public class BGroupDetailedViewModel : DetailViewModelBase, IBGroupDetailedViewModel
    {
        private IBGroupRepository _bGroupRepository;
        private IMessageDialogService _messageDialogService;

        public BGroupDetailedViewModel(IBGroupRepository bGroupRepository, IEventAggregator eventAggregator, IMessageDialogService messageDialogService) : base(eventAggregator)
        {
            _bGroupRepository = bGroupRepository;
            _messageDialogService = messageDialogService;

            RemoveBGroupCommand = new DelegateCommand(OnRemoveBGoup, OnRemoveBGoupCanExecute);
            ChangeBGroupCommand = new DelegateCommand(OnChangeBGoup, OnChangeBGoupCanExecute);

            BGroups = new ObservableCollection<BGroupItemViewModel>();
        }

        
        private async void OnRemoveBGoup()
        {
            var message = "";

            if (SelectedBGroup.BGroupsChildren.Count > 0)
            {
                message = "Данная группа имеет наследников!";
            }
            
            var result = _messageDialogService.ShowOkCancelDialog(message + $"Вы действительно хотите удалить балансовую группу {SelectedBGroup.DisplayMember}? " , "Предупреждение");
            
            if (result == MessageDialogResult.OK)
            {
                _bGroupRepository.RemoveBGroup(SelectedBGroup.Id);
                await _bGroupRepository.SaveAsync();
                RaiseDetailDeletedEvent(ResourceID);            
            }
        }

        private void OnChangeBGoup()
        {

        }

        public override async Task LoadAsync(int? resourceId)
        {
            ResourceID = resourceId.Value;
            ICollection<BGroups> bGroups = await _bGroupRepository.GetRootsAsync(resourceId.Value);

            ObservableCollection<BGroupItemViewModel> groups = new ObservableCollection<BGroupItemViewModel>();

            foreach (var item in bGroups)
            {
                groups.Add(new BGroupItemViewModel(item.BGroupID, item.BGroupName, item.ValidDisbalance, ""));
            }

            foreach (var item in groups)
            {
                LoadSubGroups(item);
            }

            InitializeBGroups(groups);

        }

        private void LoadSubGroups(BGroupItemViewModel item)
        {

            ICollection<BGroups> result = _bGroupRepository.GetChildren(item.Id);
            ObservableCollection<BGroupItemViewModel> groups = new ObservableCollection<BGroupItemViewModel>();

            if (result != null)
            {
                foreach (var subitem in result)
                {
                    //todo: add viewmodel name 
                    groups.Add(new BGroupItemViewModel(subitem.BGroupID, subitem.BGroupName, subitem.ValidDisbalance, ""));
                }

                item.BGroupsChildren = groups;
                foreach (var subitem1 in item.BGroupsChildren)
                {
                    LoadSubGroups(subitem1);
                }
            }
        }

        private void InitializeBGroups(ICollection<BGroupItemViewModel> bGroups)
        {
            BGroups.Clear();
            foreach (var bGroup in bGroups)
            {
                BGroups.Add(bGroup);
            }
        }
        public ObservableCollection<BGroupItemViewModel> BGroups { get; }

        public ICommand RemoveBGroupCommand { get; }

        public ICommand ChangeBGroupCommand { get; }


        private BGroupItemViewModel _selectedBGroup;
        public BGroupItemViewModel SelectedBGroup
        {
            get { return _selectedBGroup; }
            set
            {
                _selectedBGroup = value;
                OnPropertyChanged();
                ((DelegateCommand)RemoveBGroupCommand).RaiseCanExecuteChanged();
                //todo: add OpenDetailedView 
            }
        }

        private bool OnRemoveBGoupCanExecute()
        {
            return SelectedBGroup != null;
        }

        private bool OnChangeBGoupCanExecute()
        {
            return SelectedBGroup != null;
        }

        private int _resourceID;
        public int ResourceID
        {
            get { return _resourceID; }
            set
            {
                _resourceID = value;
                OnPropertyChanged();
            }
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



        

        

        protected override async void OnDeleteExecute()
        {

            //var result = _messageDialogService.ShowOkCancelDialog($"Do you really want to delete the Resource {Resource.ResourceName}?", "Question");
            //if (result == MessageDialogResult.OK){
            //    _resourceRepository.Remove(Resource.Model);
            //    await _resourceRepository.SaveAsync();
            //    RaiseDetailDeletedEvent(Resource.ResourceID);            
            //}
        }

       
    }
}
