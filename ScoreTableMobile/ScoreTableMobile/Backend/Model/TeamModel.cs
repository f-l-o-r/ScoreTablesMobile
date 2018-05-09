using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ScoreTableMobile.Backend.Model
{
    public class TeamModel
    {
        public string ID { get; set; }
        public string Team { get; set; }

        private string imageURL = string.Empty;

        public string ImageURL {
            get { return imageURL; }
            set
            {
                if (!imageURL.Equals(value))
                {
                    imageURL = value;
                    CachedImage = new UriImageSource
                    {
                        Uri = new Uri(imageURL),
                        CachingEnabled = true,
                        CacheValidity = new TimeSpan(5, 0, 0, 0)
                    };
                }
            }
        }

        [JsonIgnore]
        public UriImageSource CachedImage { get; set; }
    }
}

