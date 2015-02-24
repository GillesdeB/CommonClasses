using System;
using System.Collections.Generic;
using System.Text;

namespace Common_Classes.Model
{
    /// <summary>
    /// World continents class
    /// 
    /// Based on http://en.wikipedia.org/wiki/Continent
    /// 
    /// </summary>

    public class ContinentModel
    {
        // The number of continents is not universally recognized, so we let you choose
        public enum ContinentStandard { Four, Five, SixA, SixB, Seven }
        public enum Continents4 { Afro_Eurasia, America, Antarctica, Australia }
        public enum Continents5 { Africa, Eurasia, America, Antarctica, Australia }
        public enum Continents6a { Africa, Europe, Asia, America, Antarctica, Australia }
        public enum Continents6b { Africa, Eurasia, North_America, South_America, Antarctica, Australia }
        public enum Continents7 { Africa, Europe, Asia, North_America, South_America, Antarctica, Australia }
    }

    public class Continent
    {
        public string name { get; set; }
    }

}
