using System;
using System.Collections.Generic;
using System.Text;

namespace Machinapp.Model
{
    public class Wallets
    {
        public string details { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
        public float cold_balance { get; set; }
        public string hostname { get; set; }
        public string blockchain { get; set; }
    }
}
