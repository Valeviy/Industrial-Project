using Autofac;
using BCG_UI.Data;
using BCG_UI.ViewModel;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCG_UI.Sturtup
{
    class Bootstraper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Page1>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<SEICBalanceDBContext>().AsSelf();
            builder.RegisterType<ResourceDataService>().As<IResourceDataService>();

            return builder.Build();

        }
    }
}
