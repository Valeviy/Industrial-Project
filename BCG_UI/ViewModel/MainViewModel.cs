using BCG_UI.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Model;

namespace BCG_UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        

        public MainViewModel(IResourceViewModel resourceViewModel, IResourcesDetailedViewModel resourcesDetailedViewModel)
        {
            ResourceViewModel = resourceViewModel;
            ResourcesDetailedViewModel = resourcesDetailedViewModel;
        }

        public async Task LoadAsync()
        {
            await ResourceViewModel.LoadAsync();
        }



        public IResourceViewModel ResourceViewModel { get; }
        public IResourcesDetailedViewModel ResourcesDetailedViewModel { get; }
    }
}
