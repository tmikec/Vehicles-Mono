using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class VehiclesContext : DbContext
    {
        public VehiclesContext() : base("name=MyDbConnection")
        {
        }

        public System.Data.Entity.DbSet<WebApplication2.Models.Desc> Descript { get; set; }
    }
}
