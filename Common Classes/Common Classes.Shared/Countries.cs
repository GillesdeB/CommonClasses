﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Common_Classes
{
    public enum Continent { Africa, Asia, Europe, MiddleEast, East }

    public class CountryListDataFetcher
    {
        /// <summary>
        /// Generic class to create a list of all countries in the world
        /// </summary>
        private string countriesDataUrl = "https://api.validic.com/v1/fitness.json?authentication_token=DEMO_KEY&start_date=2014-11-02&end_date=2014-11-09";

        public async Task<List<Country>> fetchCountries()
        {
            List<Country> countryList = null;

            var uri = new Uri(countriesDataUrl);
            var httpClient = new HttpClient();

            try
            {
                string jsonReceived = await httpClient.GetStringAsync(uri);
                countryList = await createListFromJson(jsonReceived);
            }
            catch (Exception ex)
            {
                // Details in ex.Message and ex.HResult.       
            }
            finally
            {
                // Once done with HttpClient object, free up system resources (socket and memory used for the object)
                httpClient.Dispose();
            }

            return (countryList);
        }

        private async Task<List<Country>> createListFromJson(string resultStr)
        {
            CountryRootObject resultObject = JsonConvert.DeserializeObject<CountryRootObject>(resultStr);
            return (resultObject.country);
        }
    }

    //-----------------------------
    // http://json2csharp.com/


    //-- Full country list ---------------------------

    public class Native
    {
        public string common { get; set; }
        public string official { get; set; }
    }

    public class Name
    {
        public string common { get; set; }
        public string official { get; set; }
        public Native native { get; set; }
    }

    public class Translations
    {
        public string cym { get; set; }
        public string deu { get; set; }
        public string fra { get; set; }
        public string hrv { get; set; }
        public string ita { get; set; }
        public string jpn { get; set; }
        public string nld { get; set; }
        public string rus { get; set; }
        public string spa { get; set; }
    }

    public class Languages
    {
        public string prs { get; set; }
        public string pus { get; set; }
        public string tuk { get; set; }
        public string swe { get; set; }
        public string sqi { get; set; }
        public string ara { get; set; }
        public string eng { get; set; }
        public string smo { get; set; }
        public string cat { get; set; }
        public string por { get; set; }
        public string grn { get; set; }
        public string spa { get; set; }
        public string hye { get; set; }
        public string rus { get; set; }
        public string nld { get; set; }
        public string pap { get; set; }
        public string deu { get; set; }
        public string aze { get; set; }
        public string ben { get; set; }
        public string bel { get; set; }
        public string fra { get; set; }
        public string dzo { get; set; }
        public string aym { get; set; }
        public string que { get; set; }
        public string bos { get; set; }
        public string hrv { get; set; }
        public string srp { get; set; }
        public string tsn { get; set; }
        public string nor { get; set; }
        public string msa { get; set; }
        public string bul { get; set; }
        public string run { get; set; }
        public string khm { get; set; }
        public string sag { get; set; }
        public string cmn { get; set; }
        public string zdj { get; set; }
        public string lin { get; set; }
        public string kon { get; set; }
        public string lua { get; set; }
        public string swa { get; set; }
        public string rar { get; set; }
        public string ell { get; set; }
        public string tur { get; set; }
        public string ces { get; set; }
        public string slk { get; set; }
        public string dan { get; set; }
        public string tir { get; set; }
        public string est { get; set; }
        public string amh { get; set; }
        public string fao { get; set; }
        public string fij { get; set; }
        public string hif { get; set; }
        public string fin { get; set; }
        public string kat { get; set; }
        public string kal { get; set; }
        public string cha { get; set; }
        public string hat { get; set; }
        public string ita { get; set; }
        public string lat { get; set; }
        public string zho { get; set; }
        public string hun { get; set; }
        public string isl { get; set; }
        public string hin { get; set; }
        public string ind { get; set; }
        public string fas { get; set; }
        public string arc { get; set; }
        public string kur { get; set; }
        public string gle { get; set; }
        public string glv { get; set; }
        public string heb { get; set; }
        public string jam { get; set; }
        public string jpn { get; set; }
        public string kaz { get; set; }
        public string gil { get; set; }
        public string kir { get; set; }
        public string lao { get; set; }
        public string lav { get; set; }
        public string sot { get; set; }
        public string lit { get; set; }
        public string ltz { get; set; }
        public string mkd { get; set; }
        public string mlg { get; set; }
        public string nya { get; set; }
        public string div { get; set; }
        public string mlt { get; set; }
        public string mah { get; set; }
        public string mfe { get; set; }
        public string ron { get; set; }
        public string mon { get; set; }
        public string ber { get; set; }
        public string mya { get; set; }
        public string afr { get; set; }
        public string her { get; set; }
        public string hgm { get; set; }
        public string kwn { get; set; }
        public string loz { get; set; }
        public string ndo { get; set; }
        public string nau { get; set; }
        public string nep { get; set; }
        public string mri { get; set; }
        public string nzs { get; set; }
        public string niu { get; set; }
        public string pih { get; set; }
        public string kor { get; set; }
        public string cal { get; set; }
        public string nno { get; set; }
        public string nob { get; set; }
        public string urd { get; set; }
        public string pau { get; set; }
        public string hmo { get; set; }
        public string tpi { get; set; }
        public string fil { get; set; }
        public string pol { get; set; }
        public string kin { get; set; }
        public string crs { get; set; }
        public string tam { get; set; }
        public string slv { get; set; }
        public string som { get; set; }
        public string nbl { get; set; }
        public string nso { get; set; }
        public string ssw { get; set; }
        public string tso { get; set; }
        public string ven { get; set; }
        public string xho { get; set; }
        public string zul { get; set; }
        public string eus { get; set; }
        public string glg { get; set; }
        public string oci { get; set; }
        public string sin { get; set; }
        public string roh { get; set; }
        public string tgk { get; set; }
        public string tha { get; set; }
        public string tet { get; set; }
        public string tkl { get; set; }
        public string ton { get; set; }
        public string tvl { get; set; }
        public string ukr { get; set; }
        public string uzb { get; set; }
        public string bis { get; set; }
        public string vie { get; set; }
        public string mey { get; set; }
        public string bwg { get; set; }
        public string kck { get; set; }
        public string khi { get; set; }
        public string ndc { get; set; }
        public string nde { get; set; }
        public string sna { get; set; }
        public string toi { get; set; }
        public string zib { get; set; }
    }

    public class Country
    {
        public Name name { get; set; }
        public List<object> tld { get; set; }
        public string cca2 { get; set; }
        public string ccn3 { get; set; }
        public string cca3 { get; set; }
        public List<object> currency { get; set; }
        public List<object> callingCode { get; set; }
        public string capital { get; set; }
        public List<string> altSpellings { get; set; }
        public string relevance { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public string nativeLanguage { get; set; }
        public Languages languages { get; set; }
        public Translations translations { get; set; }
        public List<object> latlng { get; set; }
        public string demonym { get; set; }
        public List<object> borders { get; set; }
        public double area { get; set; }
    }

    public class CountryRootObject
    {
        public List<Country> country { get; set; }
    }

    ////-- Short country list ---------------------------
    //public class ShortCountryRootObject
    //{
    //    public string name { get; set; }
    //    public string code { get; set; }
    //}

    ////-- Medium country list ---------------------------

    //public class CountryOtherRootObject
    //{
    //    public CountryOtherSummary summary { get; set; }
    //    public List<CountryOther> countryList { get; set; }
    //}

    //public class CountryOtherSummary
    //{
    //    public int status { get; set; }
    //    public string message { get; set; }
    //    public int results { get; set; }
    //}

    //public class CountryOther
    //{
    //    public int CountryCode { get; set; }
    //    public Continent Continent { get; set; }
    //    public bool MemberOfOtan { get; set; }
    //    public int PhoneCode { get; set; }
    //    public Flag[] Flag { get; set; }
    //}
    //public class Flag
    //{
    //    public bool Active { get; set; }
    //    public DateTime ActiveSince { get; set; }
    //    public DateTime ActiveUntil { get; set; }
    //    public BitmapImage Image { get; set; }
    //}

    //-----------------------------

}