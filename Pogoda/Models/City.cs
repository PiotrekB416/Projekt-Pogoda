using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pogoda.Models
{
    public class City
    {
        public string name {  get; set; }
        public string country { get; set; }
        public string? state { get; set; }
        [JsonProperty("lat")]
        public double latitude { get; set; }
        [JsonProperty("lon")]
        public double longitude { get; set; }
    }
}
