using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;

namespace WeatherApp.Models
{
    [DataContract]
    public class WeatherResponse
    {
        [DataMember]
        public IList<Weather> Weather { get; set; }
        [DataMember]
        public Main Main { get; set; }
        [DataMember]
        public Wind Wind { get; set; }
        [DataMember]
        public Sys Sys { get; set; }
        public BitmapSource ImageDownloaded { get; set; }
    }
}
