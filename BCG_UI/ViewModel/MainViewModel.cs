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
        private IResourceDataService _resourceDataService;
        private Resources _selectedResource;

        public MainViewModel(IResourceDataService resourceDataService)
        {
            Resources = new ObservableCollection<Resources>();
            _resourceDataService = resourceDataService;
        }

        public void Load()
        {
            var resources = _resourceDataService.GetAll();
            Resources.Clear();

            foreach (var resource in resources)
            {
                Resources.Add(resource);
            }
        }

        public Resources SelectedResource
        {
            get { return _selectedResource; }
            set
            {
                _selectedResource = value;
                OnPropertyChanged();
            }
        }



        public ObservableCollection<Resources> Resources { get; set; }
    }
}
