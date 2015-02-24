using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Common_Classes
{
    /// <summary>
    /// Validic fitness class
    /// </summary>
    public class ValidicFitnnessDataFetcher
    {
        private string _validicFitnessSampleDataUrl = "https://api.validic.com/v1/fitness.json?authentication_token=DEMO_KEY&start_date=2014-11-02&end_date=2014-11-09";

        public async Task<List<Fitness>> fetchFitness()
        {
            List<Fitness> fitnessList = null;

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

        private async Task<List<Fitness>> createListFromJson(string resultStr)
        {
            ValidicRootObject resultObject = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ValidicRootObject>(resultStr));
            return (resultObject.fitness);
        }
    }

    public class Params
    {
        public string start_date { get; set; }
        public object end_date { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
    }

    public class Summary
    {
        public int status { get; set; }
        public string message { get; set; }
        public int results { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
        public object previous { get; set; }
        public string next { get; set; }
        public Params @params { get; set; }
    }

    public class Fitness
    {
        public string _id { get; set; }
        public string timestamp { get; set; }
        public string utc_offset { get; set; }
        public string type { get; set; }
        public string intensity { get; set; }
        public string start_time { get; set; }
        public double distance { get; set; }
        public double duration { get; set; }
        public double calories { get; set; }
        public string source { get; set; }
        public string source_name { get; set; }
        public string last_updated { get; set; }
        public string user_id { get; set; }
    }

    public class ValidicRootObject
    {
        public Summary summary { get; set; }
        public List<Fitness> fitness { get; set; }
    }

    ////-------------------------------------------------------------------------------------------------------
    //public enum VehicleType { Bicycle, Motorcycle, Car, Truck, Tank, Other }
    //public enum MotorizationType { None, Petrol, Diesel, Gas, Electric, Hybrid, Hydrogene, Human, Animal, Other }
    //public class Vehicles
    //{
    //    public VehicleType VehicleType { get; set; }
    //    public bool CanBeDriven { get; set; }
    //    public bool RoadLegal { get; set; }
    //    public bool HighwayLegal { get; set; }
    //    public VehicleDetails[] VehicleDetails { get; set; }
    //}

    //public class VehicleDetails
    //{
    //    public string LicensePlate { get; set; }
    //    public int NumberOfSeating { get; set; }
    //    public int NumberOfDoors { get; set; }
    //    public Motorization[] Motorization { get; set; }
    //    public int NumberOfWheels { get; set; }
    //    public Wheel[] Wheel { get; set; }
    //    public int NumberOfWindows { get; set; }
    //    public Window[] Window { get; set; }
    //}
    //public class Motorization
    //{
    //    public MotorizationType MotorizationType { get; set; }
    //    public float Size { get; set; }
    //    public string Material { get; set; }
    //}
    //public class Wheel
    //{
    //    public DateTime Date { get; set; }
    //    public string Name { get; set; }
    //    public int Size { get; set; }
    //    public string Color { get; set; }
    //    public string Material { get; set; }
    //}
    //public class Window
    //{
    //    public DateTime Date { get; set; }
    //    public string Surface { get; set; }
    //    public string Color { get; set; }
    //}

}
