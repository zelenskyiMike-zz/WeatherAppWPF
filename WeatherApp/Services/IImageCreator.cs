using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace WeatherApp.Services
{
    public interface IImageCreator
    {
        BitmapSource CreteBitmapImage(byte[] byteArray);
    }
}
