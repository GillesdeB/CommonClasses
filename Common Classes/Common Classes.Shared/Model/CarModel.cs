using System.Collections.Generic;

namespace Common_Classes.Model
{
    /// <summary>
    /// Used xx and the country list JSON file from "xx" to generate the class
    /// 
    /// See also:
    /// http://www.carqueryapi.com/
    /// https://github.com/VinceG/Auto-Cars-Makes-And-Models
    /// http://en.wikipedia.org/wiki/List_of_car_brands
    /// http://en.wikipedia.org/wiki/List_of_current_automobile_manufacturers_by_country
    ///    
    /// </summary>

    public class CarModel
    {

        public class Rootobject
        {
            public Class1[] class1 { get; set; }
        }

        /// <summary>
        /// Car makers
        /// </summary>
        public class Class1
        {
            public string value { get; set; }
            public string title { get; set; }
            public Model[] models { get; set; }
        }

        /// <summary>
        /// Car models
        /// </summary>
        public class Model
        {
            public string value { get; set; }
            public string title { get; set; }
        }

        //public class CarRootObject
        //{
        //    public string brand { get; set; }
        //    public string name { get; set; }
        //    public List<string> altSpellings { get; set; }
        //}
    }

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
