using Common_Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Common_Classes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region Constructor

        public MainPage()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Validic

        /// <summary>
        /// Validic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ValidicFitnnessDataFetcher fitnessListFetcher;
        List<Fitness> fitnessList;

        private async void ValidicButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await LoadValidic();
        }

        private async Task LoadValidic()
        {
            // Sum of calories
            double total = 0;

            fitnessListFetcher = new ValidicFitnnessDataFetcher();
            fitnessList = await fitnessListFetcher.fetchFitness();

            if (fitnessList != null)
            {
                foreach (Fitness f in fitnessList)
                {
                    total += (int)f.calories;
                }
            }
            // Display the result
            totalValidic.Text = total.ToString();
        }

        private async Task ClearValidic()
        {
            fitnessListFetcher = null;
            totalValidic.Text = string.Empty;

            await Task.Delay(10);
        }

        #endregion

        #region Countries

        /// <summary>
        /// Countries
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        CountryListDataFetcher countryListFetcher;
        List<CountryModel> countryList;

        private async void CountriesButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await LoadCountries();
        }

        private async Task LoadCountries()
        {
            // Instantiate the class
            countryListFetcher = new CountryListDataFetcher();

            // Set the network access timeout (milliseconds)
            countryListFetcher.networkTimeout = 3000;
            // Get the list of continents
            countryList = await countryListFetcher.fetchCountries();

            // Process the list of countries found
            if (countryList != null)
            {
                // Bind the list to the UI
                comboboxCountries.ItemsSource = countryList;
                comboboxCountries.SelectedIndex = 0;

                // ISSUE - DOES NOT DISPLAY THE CAPITAL OF THE COUNTRY THE FIRST TIME
                capitalOfCountry.DataContext = countryList;

                // Display the number of coutries
                totalCountries.Text = countryList.Count.ToString();
            }
        }

        private void comboboxCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((countryList != null) && (comboboxCountries.SelectedIndex > -1))
            {
                // Update the flag
                string country = countryList.ElementAt(comboboxCountries.SelectedIndex).alpha2Code;
                string uri = countryListFetcher.fetchCountryFlag(country);
                flagOfCountry.Source = new BitmapImage(new Uri(uri));

                // Show the capital
                capitalOfCountry.DataContext = countryList[comboboxCountries.SelectedIndex];
            }
            else
            {
                flagOfCountry.Source = null;
                capitalOfCountry.DataContext = null;
            }
        }

        private async Task ClearCountries()
        {
            capitalOfCountry.DataContext = null;

            countryList = null;
            comboboxCountries.ItemsSource = null;
            countryListFetcher = null;
            totalCountries.Text = string.Empty;

            await Task.Delay(10);
        }

        #endregion

        #region Continents

        /// <summary>
        /// Continents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        ContinentListDataFetcher continentListFetcher;
        List<Continent> continentList;

        private async void ContinentsButton_Tapped(object sender, TappedRoutedEventArgs e)
        {

            await LoadContinents();
        }

        private async Task LoadContinents()
        {
            // Instantiate the class
            continentListFetcher = new ContinentListDataFetcher();
            // Select the standard to use
            continentListFetcher.continentStandard = ContinentModel.ContinentStandard.SixB;
            // Get the list of continents
            continentList = await continentListFetcher.fetchContinents();
            // Count the number of continents found
            if (continentList != null)
            {
                // Bind the list to the UI
                comboboxContinents.ItemsSource = continentList;
                comboboxContinents.SelectedIndex = 0;
            }
            // Display the number of continents
            totalContinents.Text = continentList.Count.ToString();
        }

        private async Task ClearContinents()
        {
            capitalOfCountry.DataContext = null;

            continentList = null;
            comboboxContinents.ItemsSource = null;
            continentListFetcher = null;
            totalContinents.Text = string.Empty;

            await Task.Delay(10);
        }

        #endregion

        #region Reset

        /// <summary>
        /// Reset all data sets and results displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ResetButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await ClearValidic();
            await ClearCountries();
            await ClearContinents();
        }

        #endregion

    }
}
