using Newtonsoft.Json;
using Pogoda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pogoda
{
    public static class HttpPogoda
    {
        static HttpClient httpClient { get; } = new HttpClient() { BaseAddress = new Uri("https://api.openweathermap.org") };
        static string API_KEY { get; } = "986c5ece8479bfab6721d433f86bf665";

        public static async Task<List<City>> GetCities(string city) {
            using HttpResponseMessage response = await httpClient.GetAsync($"/geo/1.0/direct?q={city}&limit=5&appid={API_KEY}");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<List<City>>(content);

                if (res != null)
                {
                    return res;
                }
            }

            return [];
        }

        public static async Task<Models.Pogoda> GetForecast(City city)
        {
            using HttpResponseMessage response = await httpClient.GetAsync($"/data/3.0/onecall?lat={city.latitude}&lon={city.longitude}&appid={API_KEY}&units=metric&lang=PL"); 

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<Models.Pogoda>(content);

                if (res != null)
                {
                    return res;
                }
            }


            return null;
        }
    }
}
