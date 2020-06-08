using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace lab14
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new ContainerBuilder();
            builder.RegisterType<PanelFiller>().As<IPanelFiller>();
            builder.RegisterType<ButtonGenerator>().As<IcontrolGenerator>();
            builder.RegisterType<FileDataProvider>().As<IDataProvider>();
            builder.RegisterType<MainWindow>().AsSelf();

            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var window = scope.Resolve<MainWindow>();
                    window.Show();
            }
        }
    }
}
