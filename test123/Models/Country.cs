using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test123.Models
{
    public class Country
    {
        public int updated;
        public string country;
        public CountryInfo countryInfo;
        public int cases;
        public int todayCases;
        public int deaths;
        public int todayDeaths;
        public int recovered;
        public int todayRecovered;
        public int active;
        public int critical;
        public int casesPerOneMillion;
        public int deathsPerOneMillion;
        public int tests;
        public int testsPerOneMillion;
        public int population;
        public int continent;
        public int oneCasePerPeople;
        public int oneDeathPerPeople;
        public int oneTestPerPeople;
    }

    public class CountryInfo
    {
        public int _id;
        public string iso2;
        public string iso3;
        public int lat;
        public int longtitude;
        public string flag;
    }

}
