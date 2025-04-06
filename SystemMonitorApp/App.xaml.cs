using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using SystemMonitorApp.Repositories;
using SystemMonitorApp.Repositories.Contracts;
using SystemMonitorApp.Services;
using SystemMonitorApp.Services.Contracts;
using SystemMonitorApp.ViewModels;

namespace SystemMonitorApp
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Servicios (inyección de dependencias)
            services.AddSingleton<ISystemSampleRepository, JsonSystemSampleRepository>();
            services.AddSingleton<ISystemInfoProvider, RealSystemInfoProvider>();
            services.AddSingleton<MainViewModel>();

            // Vistas
            services.AddSingleton<MainWindow>();
        }
    }
}