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
    /// Cars class
    /// </summary>
    class CarListDataFetcher
    {
        #region Data

        // Location of the list of car makers and models as Json data
        private string carDataUrl = "http://restcars/rest/v1/all";
        private string carDataLocalUrl = @"LocalData\carMakersAndModels.json";

        // Location of the country flags - use .png as .svg is not handled by Windows
        //private string carPictureUrl1 = "http://tinata.org/img/flags/{0}.svg";
        private string carPictureUrl2 = "http://flagpedia.net/data/flags/normal/{0}.png";

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

        #region Fetch Cars

        /// <summary>
        /// Return the list of countries
        /// </summary>
        /// <returns></returns>
        public async Task<List<CarModel.RootObject>> fetchCars()
        {
            List<CarModel.RootObject> carList = null;

            // Try to get the list online
            carList = await fetchCarsOnline(carDataUrl);

            // If online failed, use the local Json file
            if (carList == null)
            {
                carList = await fetchCarsLocally(carDataLocalUrl);
            }

            return (carList);
        }

        /// <summary>
        /// Get the list of countries online
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        private async Task<List<CarModel.RootObject>> fetchCarsOnline(string uri)
        {
            List<CarModel.RootObject> _carList = null;

            Uri _uri = new Uri(uri);
            HttpClient httpClient = new HttpClient();

            try
            {
                // Get the list in Json format
                string jsonReceived = await httpClient.GetStringAsync(_uri);
                _carList = await createListFromJson(jsonReceived);
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

            return (_carList);
        }

        /// <summary>
        /// Get the list of countries from a Json file in local storage
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        private async Task<List<CarModel.RootObject>> fetchCarsLocally(string uri)
        {
            List<CarModel.RootObject> _carList = null;
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

            _carList = await createListFromJson(_jsonData);

            return (_carList);
        }

        #endregion

        #region Create list from Json

        /// <summary>
        /// Create the list of countries from a Json string
        /// </summary>
        /// <param name="resultStr"></param>
        /// <returns></returns>
        private async Task<List<CarModel.RootObject>> createListFromJson(string resultStr)
        {
            List<CarModel.RootObject> resultObject = await Task.Factory.StartNew(
                () => JsonConvert.DeserializeObject<List<CarModel.RootObject>>(resultStr));
            return (resultObject);
        }

        #endregion

        #region Car picture

        /// <summary>
        /// Return the URL of the country flag
        /// </summary>
        /// <param name="isoCountryCode"></param>
        /// <returns></returns>
        public string fetchCarPicture(string carId)
        {
            //return (string.Format(carPictureUrl1, carId.ToLower()));
            return (string.Format(carPictureUrl2, carId.ToLower()));
        }

        #endregion

    }
}
