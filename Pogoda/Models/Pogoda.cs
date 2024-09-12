using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pogoda.Models
{
    public class Pogoda
    {
        public Current current;
        public class Current
        {
            public string temp;
            public string wind_speed;
            public string feels_like;
            public Weather[] weather;

            public class Weather
            {
                public int id;
                public string main;
                public string description;
                public string icon;
            }

        }
    }

    
}
