using Common_Classes.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common_Classes
{
    /// <summary>
    /// World continents class
    /// </summary>
    class ContinentListDataFetcher
    {
        #region Data

        /// <summary>
        /// Continent standard used.
        /// </summary>
        private ContinentModel.ContinentStandard _continentStandard = ContinentModel.ContinentStandard.SixB;
        public ContinentModel.ContinentStandard continentStandard
        {
            get
            {
                return _continentStandard;
            }
            set
            {
                _continentStandard = value;
            }
        }

        #endregion

        #region Fetch Continents

        public async Task<List<Continent>> fetchContinentStandards()
        {
            List<Continent> ContinentStandardsList = new List<Continent>();
            var listOfValues = Enum.GetValues(typeof(ContinentModel.ContinentStandard));

            foreach (var value in listOfValues)
            {
                ContinentStandardsList.Add(new Continent() { name = value.ToString() });
            }

            return (ContinentStandardsList);
        }

        /// <summary>
        /// Return the list of continents corresponding to the continent standard selected.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Continent>> fetchContinents()
        {
            List<Continent> continentList = new List<Continent>();

            var listOfValues = Enum.GetValues(typeof(ContinentModel.Continents4));

            switch (continentStandard)
            {
                case ContinentModel.ContinentStandard.Four:
                    listOfValues = Enum.GetValues(typeof(ContinentModel.Continents4));
                    break;
                case ContinentModel.ContinentStandard.Five:
                    listOfValues = Enum.GetValues(typeof(ContinentModel.Continents5));
                    break;
                case ContinentModel.ContinentStandard.SixA:
                    listOfValues = Enum.GetValues(typeof(ContinentModel.Continents6a));
                    break;
                case ContinentModel.ContinentStandard.SixB:
                    listOfValues = Enum.GetValues(typeof(ContinentModel.Continents6b));
                    break;
                case ContinentModel.ContinentStandard.Seven:
                    listOfValues = Enum.GetValues(typeof(ContinentModel.Continents7));
                    break;
                default:
                    listOfValues = Enum.GetValues(typeof(ContinentModel.Continents6b));
                    break;
            }

            foreach (var value in listOfValues)
            {
                continentList.Add(new Continent() { name = value.ToString() });
            }

            return (continentList);
        }

        #endregion

        #region Create list from Enum

        /// <summary>
        /// Gets list of all enum values for the type specified as a list of strings.  
        /// </summary>
        /// <param name="enumType">The type of enum to iterate values from.</param>
        public static List<string> GetEnumValues(Type enumType)
        {
            List<string> itemList = new List<string>();

            var listOfValues = Enum.GetValues(enumType);
            foreach (var value in listOfValues)
            {
                itemList.Add(value.ToString());
            }

            return itemList;
        }

        #endregion

    }

}
