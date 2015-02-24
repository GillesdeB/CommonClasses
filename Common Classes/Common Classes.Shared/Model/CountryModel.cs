using System.Collections.Generic;

namespace Common_Classes.Model
{
    /// <summary>
    /// Used http://json2csharp.com/ and the country list JSON file from "http://restcountries.eu/rest/v1/all" to generate the class
    /// REST Countries http://restcountries.eu/ with usage examples
    /// World countries in JSON, CSV and XML https://github.com/mledoze/countries
    /// 
    /// See also:
    ///    https://www.mashape.com/fayder/rest-countries-v1
    ///    Free, open access to information about countries: https://github.com/tinata/tinata-www
    ///      use http://tinata.org/countries/USA.json - Get information about the United States
    ///      use http://tinata.org/img/flags/fr.svg - Get the French flag
    ///    https://github.com/tellnes/country-flags
    ///    
    /// </summary>

    // RootObject
    public class CountryModel
    {
        public string name { get; set; }
        public string capital { get; set; }
        public List<string> altSpellings { get; set; }
        public string relevance { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public Translations translations { get; set; }
        public int population { get; set; }
        public List<double> latlng { get; set; }
        public string demonym { get; set; }
        public double? area { get; set; }
        public double? gini { get; set; }
        public List<string> timezones { get; set; }
        public List<object> borders { get; set; }
        public string nativeName { get; set; }
        public List<string> callingCodes { get; set; }
        public List<string> topLevelDomain { get; set; }
        public string alpha2Code { get; set; }
        public string alpha3Code { get; set; }
        public List<string> currencies { get; set; }
        public List<object> languages { get; set; }
    }

    /// <summary>
    /// Translation of the country name in other languages
    /// </summary>
    public class Translations
    {
        public string de { get; set; }
        public string es { get; set; }
        public string fr { get; set; }
        public string ja { get; set; }
        public string it { get; set; }
    }

}
