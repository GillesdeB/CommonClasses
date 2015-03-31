using System.Collections.Generic;

namespace Common_Classes.Model
{
    public class ValidicModel
    {
        /// <summary>
        /// RootObject
        /// </summary>
        public class ValidicRootObject
        {
            public Summary summary { get; set; }
            public List<Fitness> fitness { get; set; }
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
    }
}
