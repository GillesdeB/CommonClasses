using Common_Classes.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.Web.Http;

namespace Common_Classes
{
    /// <summary>
    /// World countries class
    /// 
    /// TODO:
    /// - Include a network access time limit - http://stackoverflow.com/questions/5750600/await-taskex-delay
    /// 
    /// </summary>
    class CountryListDataFetcher
    {
        #region Data

        // Location of the list of countries as Json data
        private string countryDataUrl = "http://restcountries.eu/rest/v1/all";
        private string countryDataLocalUrl = @"LocalData\countries.json";

        // Location of the country flags - use .png as .svg is not handled by Windows
        //private string countryFlagUrl1 = "http://tinata.org/img/flags/{0}.svg";
        private string countryFlagUrl2 = "http://flagpedia.net/data/flags/normal/{0}.png";

        // Network response timeout in milliseconds
        private int _networkTimeout = 5000;
        public int networkTimeout
        {
            get
            {
                return _networkTimeout;
            }
            set
            {
                _networkTimeout = value;
            }
        }

        #endregion

        #region Fetch Countries

        /// <summary>
        /// Return the list of countries
        /// </summary>
        /// <returns></returns>
        public async Task<List<CountryModel>> fetchCountries()
        {
            List<CountryModel> countryList = null;

            // Try to get the list online
            countryList = await fetchCountriesOnline(countryDataUrl);

            // If online failed, use the local Json file
            if (countryList == null)
            {
                countryList = await fetchCountriesLocally(countryDataLocalUrl);
            }

            return (countryList);
        }

        /// <summary>
        /// Get the list of countries online
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        private async Task<List<CountryModel>> fetchCountriesOnline(string uri)
        {
            List<CountryModel> _countryList = null;

            Uri _uri = new Uri(uri);
            HttpClient httpClient = new HttpClient();

            try
            {
                // Get the list in Json format
                string jsonReceived = await httpClient.GetStringAsync(_uri);
                _countryList = await createListFromJson(jsonReceived);
            }
            catch (Exception ex)
            {
                // Display exception details
                UserMessages.messageBox(ex.Message + " - " + ex.HResult);
            }
            finally
            {
                // Once done free up system resources
                httpClient.Dispose();
            }

            return (_countryList);
        }

        /// <summary>
        /// Get the list of countries from a Json file in local storage
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        private async Task<List<CountryModel>> fetchCountriesLocally(string uri)
        {
            List<CountryModel> _countryList = null;
            string _jsonData = string.Empty;

            try
            {
                StorageFolder storageFolder = Package.Current.InstalledLocation;
                StorageFile storageFile = await storageFolder.GetFileAsync(uri);

                _jsonData = await FileIO.ReadTextAsync(storageFile);

            }
            catch (Exception ex)
            {
                // Display exception details
                UserMessages.messageBox(ex.Message + " - " + ex.HResult);
            }

            _countryList = await createListFromJson(_jsonData);

            return (_countryList);
        }

        #endregion

        #region Create list from Json

        /// <summary>
        /// Create the list of countries from a Json string
        /// </summary>
        /// <param name="resultStr"></param>
        /// <returns></returns>
        private async Task<List<CountryModel>> createListFromJson(string resultStr)
        {
            List<CountryModel> resultObject = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<CountryModel>>(resultStr));
            return (resultObject);
        }

        #endregion

        #region Coountry flag

        /// <summary>
        /// Return the URL of the country flag
        /// </summary>
        /// <param name="isoCountryCode"></param>
        /// <returns></returns>
        public string fetchCountryFlag(string isoCountryCode)
        {
            //return (string.Format(countryFlagUrl1, isoCountryCode.ToLower()));
            return (string.Format(countryFlagUrl2, isoCountryCode.ToLower()));
        }

        #endregion

    }
}
