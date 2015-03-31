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
        List<ValidicModel.Fitness> fitnessList;

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
                foreach (ValidicModel.Fitness f in fitnessList)
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

        #region Cars

        /// <summary>
        /// Car makers and car models
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        CarListDataFetcher carListFetcher;
        List<CarModel.RootObject> carList;

        private async void CarsButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await LoadCars();
        }

        private async Task LoadCars()
        {
            // Instantiate the class
            carListFetcher = new CarListDataFetcher();

            // Set the network access timeout (milliseconds)
            carListFetcher.networkTimeout = 3000;
            // Get the list of Cars
            carList = await carListFetcher.fetchCars();

            // Process the list of countries found
            if (carList != null)
            {
                // Bind the list to the UI
                comboboxCarBrands.ItemsSource = carList;
                comboboxCarBrands.SelectedIndex = 0;

                // ISSUE - DOES NOT DISPLAY THE BRAND OF THE CAR THE FIRST TIME
                carBrand.DataContext = carList;

                // Display the number of coutries
                totalBrands.Text = carList.Count.ToString();
            }
        }

        private void comboboxCarBrands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((carList != null) && (comboboxCarBrands.SelectedIndex > -1))
            {
                // Update the image of the car brand
                string uri = carListFetcher.fetchCarPicture(carList.ElementAt(comboboxCarBrands.SelectedIndex).value);
                carBrandPicture.Source = new BitmapImage(new Uri(uri));

                // Show the name of the car brand
                carBrand.DataContext = carList[comboboxCarBrands.SelectedIndex];

                // Update the dropdow list containing car models
                comboboxCarModels.ItemsSource = carList[comboboxCarBrands.SelectedIndex].models;
                comboboxCarModels.SelectedIndex = 0;
            }
            else
            {
                carBrandPicture.Source = null;
                carBrand.DataContext = null;
            }
        }

        private void comboboxCarModels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((carList != null) && (comboboxCarModels.SelectedIndex > -1))
            {
                // Update the image of the car model
                string uri = carListFetcher.fetchCarPicture(carList.ElementAt(comboboxCarModels.SelectedIndex).value);
                carModelPicture.Source = new BitmapImage(new Uri(uri));

                // Show the name of the car model
                carModel.DataContext = carList[comboboxCarBrands.SelectedIndex].models;
            }
            else
            {
                carModelPicture.Source = null;
                carModel.DataContext = null;
            }
        }

        private async Task ClearCars()
        {
            carBrand.DataContext = null;

            carList = null;
            comboboxCarBrands.ItemsSource = null;
            comboboxCarModels.ItemsSource = null;
            carListFetcher = null;
            totalBrands.Text = string.Empty;

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
            await ClearCars();
        }

        #endregion
    }
}
