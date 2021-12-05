using System;
using System.Collections.Generic;
using System.Text;

namespace Machinapp.Model
{
    public class Farms
    {
        public string mode { get; set; }
        public float netspace_size { get; set; }
        public DateTime updated_at { get; set; }
        public string expected_time_to_win { get; set; }
        public DateTime created_at { get; set; }
        public float plots_size { get; set; }
        public string hostname { get; set; }
        public string status { get; set; }
        public int plot_count { get; set; }
        public float total_coins { get; set; }
        public string blockchain { get; set; }
    }


}
