using System;
using System.Collections.Generic;

namespace P6Shop_EdisonChavarriaVasquez.Models
{
    public partial class Country
    {
        public Country()
        {
            Stores = new HashSet<Store>();
            Users = new HashSet<User>();
        }

        public int Idcountry { get; set; }
        public int CountryCode { get; set; }
        public string CountryName { get; set; } = null!;
        public bool? Active { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
