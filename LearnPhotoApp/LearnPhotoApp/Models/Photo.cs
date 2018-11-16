using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LearnPhotoApp.Models
{
    public class Photo
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "PhotoName")]
        public string PhotoName { get; set; }
    }
}
