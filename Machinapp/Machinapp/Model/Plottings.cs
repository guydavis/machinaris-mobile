using System;
using System.Collections.Generic;
using System.Text;

namespace Machinapp.Model
{
    public class Plottings
    {
        public string wall { get; set; }
        public string phase { get; set; }
        public int pid { get; set; }
        public string io { get; set; }
        public DateTime updated_at { get; set; }
        public string mem { get; set; }
        public int k { get; set; }
        public string dst { get; set; }
        public string size { get; set; }
        public string hostname { get; set; }
        public string stat { get; set; }
        public DateTime created_at { get; set; }
        public string user { get; set; }
        public string sys { get; set; }
        public string plot_id { get; set; }
        public string tmp { get; set; }
        public string plotter { get; set; }
        public string blockchain { get; set; }
    }
}
