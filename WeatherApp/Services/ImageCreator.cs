using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WeatherApp.Services
{
    public class ImageCreator : IImageCreator
    {
        public BitmapSource CreteBitmapImage(byte[] byteArray)
        {
            using (MemoryStream memory = new MemoryStream(byteArray))
            {
                BitmapImage bitmapImage = new BitmapImage();

                // bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }
    }
}
