using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Common_Classes.Model;

namespace Common_Classes
{
    /// <summary>
    /// Validic fitness class
    /// </summary>
    public class ValidicFitnnessDataFetcher
    {
        #region Data
        /// <summary>
        /// URI used for testing
        /// </summary>
        private string _validicFitnessSampleDataUrl = "https://api.validic.com/v1/fitness.json?authentication_token=DEMO_KEY&start_date=2014-11-02&end_date=2014-11-09";

        #endregion

        #region Fetch Validic Records

        public async Task<List<ValidicModel.Fitness>> fetchFitness()
        {
            List<ValidicModel.Fitness> fitnessList = null;

            Uri uri = new Uri(_validicFitnessSampleDataUrl);
            HttpClient httpClient = new HttpClient();

            // Always catch network exceptions for async methods
            try
            {
                string jsonReceived = await httpClient.GetStringAsync(uri);
                fitnessList = await createListFromJson(jsonReceived);
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

            return (fitnessList);
        }

        private async Task<List<ValidicModel.Fitness>> createListFromJson(string resultStr)
        {
            ValidicModel.ValidicRootObject resultObject = await Task.Factory.StartNew(
                () => JsonConvert.DeserializeObject<ValidicModel.ValidicRootObject>(resultStr));
            return (resultObject.fitness);
        }

        #endregion
    }

}
