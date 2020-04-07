using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InnerCanvas.Visibility = Visibility.Hidden;
            MainWindowViewModel viewModel = new MainWindowViewModel();
            comboboxCities.ItemsSource = viewModel.Cities.AsParallel();
            comboboxCities.SelectedIndex = 0;
        }

        private void GetWeather_Clicked(object sender, RoutedEventArgs e)
        {
            var weatherService = new WeatherService();
            var selectedValue = (City)comboboxCities.SelectedItem;

            InnerCanvas.Visibility = Visibility.Visible;

            var weatherResponse = weatherService.GetWeatherResponse(selectedValue.Name).Result;

            icon.Source = weatherResponse.ImageDownloaded;

            WeatherDescriptionLabel.Content = weatherResponse.Weather.First().Description;
            TemperatureLabel.Content = weatherResponse.Main.Temp + "°";
            FeelsLikeLabel.Content = weatherResponse.Main.Feels_Like+"°";
            HumidityLabel.Content = weatherResponse.Main.Humidity + "%";
            WindSpeedLabel.Content = weatherResponse.Wind.Speed + " meter/sec";
            SunriseLabel.Content = weatherResponse.Sys.Sunrise.FromMsToTime() + " in UTC";
            SunsetLabel.Content = weatherResponse.Sys.Sunset.FromMsToTime() + " in UTC";
            CountryLabel.Content = weatherResponse.Sys.Country;

        }
    }
}
