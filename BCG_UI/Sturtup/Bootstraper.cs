using Autofac;
using BCG_UI.Data;
using BCG_UI.Data.Lookups;
using BCG_UI.Data.Repositories;
using BCG_UI.View.Services;
using BCG_UI.ViewModel;
using DataAccess;
using Prism.Events;
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
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
            builder.RegisterType<Page1>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<MessageDialogService>().As<IMessageDialogService>();
            builder.RegisterType<BGroupRepository>().As<IBGroupRepository>();

            builder.RegisterType<BGroupDetailedViewModel>().As<IBGroupDetailedViewModel>();

            builder.RegisterType<SEICBalanceDBContext>().AsSelf();
            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<ResourceViewModel>().As<IResourceViewModel>();
            builder.RegisterType<ResourceRepository>().As<IResourceRepository>();


            return builder.Build();

        }
    }
}
