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
        private Func<IBGroupDetailedViewModel> _bGroupsDetailedViewModelCreator;

        public MainViewModel(IResourceViewModel resourceViewModel, Func<IBGroupDetailedViewModel> bGroupsDetailedViewModelCreator, IEventAggregator eventAggregator, IMessageDialogService messageDialogService)
        {
            _eventAggregator = eventAggregator;
            ResourceViewModel = resourceViewModel;
            _bGroupsDetailedViewModelCreator = bGroupsDetailedViewModelCreator;
            _messageDialogService = messageDialogService;
            CreateNewDetailCommand = new DelegateCommand<Type>(OnCreateNewDetailExecute);
            _eventAggregator.GetEvent<OpenDetailViewEvent>().Subscribe(OnOpenDetailView);
            _eventAggregator.GetEvent<AfterDetailDeletedEvent>().Subscribe(AfterDetailDeleted);

        }

        public async Task LoadAsync()
        {
            await ResourceViewModel.LoadAsync();
        }


        public IResourceViewModel ResourceViewModel { get; }
        
        private IDetailedViewModel _detailViewModel;
        public IDetailedViewModel DetailViewModel
        {
            get { return _detailViewModel; }
            private set
            {
                _detailViewModel = value;
                OnPropertyChanged();
            }
        }



        public async void OnOpenDetailView(OpenDetailViewEventArgs args)
        {
            
            switch (args.ViewModelName)
            {
                case nameof(BGroupDetailedViewModel):
                    if (DetailViewModel != null && DetailViewModel.HasChanges)
                    {
                        var result = _messageDialogService.ShowOkCancelDialog("You've made changes. Navigate away?", "Question");
                        if (result == MessageDialogResult.Cancel)
                        {
                            return;
                        }

                    }
                    DetailViewModel = _bGroupsDetailedViewModelCreator();
                    break;

            }

            await DetailViewModel.LoadAsync(args.Id);
        }


        public ICommand CreateNewDetailCommand { get; }

        private void OnCreateNewDetailExecute(Type viewModelType)
        {
            OnOpenDetailView(new OpenDetailViewEventArgs { ViewModelName = viewModelType.Name });
        }

        private async void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            await DetailViewModel.LoadAsync(args.Id);
        }
    }
}
