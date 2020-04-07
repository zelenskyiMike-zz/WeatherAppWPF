using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using WeatherApp.Services;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    IUnityContainer container = new UnityContainer();

        //    container.RegisterType<IRequestJsonService, RequestJsonService>();
        //    container.RegisterType<IRequestImageService, RequestImageService>();
        //    container.RegisterType<IWeatherService, WeatherService>();

        //    MainWindow mainWindow = container.Resolve<MainWindow>();
        //   // mainWindow.Show();

        //}
    }
}
