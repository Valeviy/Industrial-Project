using BCG_UI.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Model;
using Prism.Events;
using BCG_UI.View.Services;
using BCG_UI.Event;
using Prism.Commands;
using System.Windows.Input;

namespace BCG_UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private IMessageDialogService _messageDialogService;
        private Func<IResourcesDetailedViewModel> _resourcesDetailedViewModelCreator;

        public MainViewModel(IResourceViewModel resourceViewModel, Func<IResourcesDetailedViewModel> resourcesDetailedViewModelCreator, IEventAggregator eventAggregator, IMessageDialogService messageDialogService)
        {
            _eventAggregator = eventAggregator;
            ResourceViewModel = resourceViewModel;
            _resourcesDetailedViewModelCreator = resourcesDetailedViewModelCreator;
            _eventAggregator.GetEvent<OpenResourceDetailViewEvent>().Subscribe(OpenResourceDetailView);
            _messageDialogService = messageDialogService;
            CreateNewResourceCommand = new DelegateCommand(OnCreateNewResourceExecute);
            _eventAggregator.GetEvent<AfterResourceDeletedEvent>().Subscribe(AfterResourceDeleted);

        }

        public async Task LoadAsync()
        {
            await ResourceViewModel.LoadAsync();
        }



        public IResourceViewModel ResourceViewModel { get; }
        private IResourcesDetailedViewModel _resourcesDetailedViewModel;
        public IResourcesDetailedViewModel ResourcesDetailedViewModel
        {
            get { return _resourcesDetailedViewModel; }
            private set
            {
                _resourcesDetailedViewModel = value;
                OnPropertyChanged();
            }
        }



        public async void OpenResourceDetailView(int? resourceId)
        {
            if (ResourcesDetailedViewModel != null && ResourcesDetailedViewModel.HasChanges)
            {
                var result = _messageDialogService.ShowOkCancelDialog("You've made changes. Navigate away?", "Question");
                if (result == MessageDialogResult.Cancel)
                {
                    return;
                }

            }
            ResourcesDetailedViewModel = _resourcesDetailedViewModelCreator();

            await ResourcesDetailedViewModel.LoadAsync(resourceId);
        }


        public ICommand CreateNewResourceCommand { get; }

        private void OnCreateNewResourceExecute()
        {
            OpenResourceDetailView(null);
        }

        private void AfterResourceDeleted(int resourceId)
        {
            ResourcesDetailedViewModel = null;
        }
    }
}
