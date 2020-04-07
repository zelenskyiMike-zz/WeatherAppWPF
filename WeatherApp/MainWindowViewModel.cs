using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp
{
    public class MainWindowViewModel
    {
        IRequestJsonService requestJsonService;
        const string path = @"D:\WeatherAppWPF\WeatherApp\WeatherApp\city.list.min.json";
        public IList<City> Cities { get; private set; }

        public MainWindowViewModel()
        {
            requestJsonService = new RequestJsonService();
           
            var cities = requestJsonService.RequestLocalJson(path).Result;
            if (string.IsNullOrEmpty(cities))
            {
                Cities = new List<City>();
            }
            Cities = JsonConvert.DeserializeObject<IList<City>>(cities);
        }
    }
}
