using Autofac;
using BCG_UI.Sturtup;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace BCG_UI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrap = new Bootstraper();
            var container = bootstrap.Bootstrap();
            var page1 = container.Resolve<Page1>();
            //NavigationWindow win = new NavigationWindow();
            //win.Content = ;
            //win.Show();
            this.MainWindow.Content = page1;
            this.MainWindow.Show();


        }
    }
}
