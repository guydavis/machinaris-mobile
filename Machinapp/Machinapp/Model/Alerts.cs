using System;
using System.Collections.Generic;
using System.Text;

namespace Machinapp.Model
{
    public class Alerts
    {
        public string unique_id { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
        public string hostname { get; set; }
        public string priority { get; set; }
        public string message { get; set; }
        public string service { get; set; }
        public string blockchain { get; set; }
    }

}
