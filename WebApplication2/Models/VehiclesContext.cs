using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class VehiclesContext : DbContext // VehiclesContext class za databazu
    {
        public VehiclesContext() : base("name=VehiclesContext") // Ime databaze u local serveru
        {
        }

        public System.Data.Entity.DbSet<WebApplication2.Models.Desc> Description { get; set; } // Kreira primjer DbSet
    }
}
