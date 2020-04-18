using BCG_UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BCG_UI
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
 
        public partial class Page1 : Page
        {
            private MainViewModel _viewModel;
            public Page1(MainViewModel viewModel)
            {
                InitializeComponent();
                _viewModel = viewModel;
                DataContext = _viewModel;
                Loaded += Page1_Loaded;
            }

            private void Page1_Loaded(object sender, RoutedEventArgs e)
            {
                _viewModel.Load();
            }
        }
    
}
