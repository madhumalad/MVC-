using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication.Infrastructure
{
    public class NorthwindContext:System.Data.Entity.DbContext
    {
        //Define databse set property whose name shuld match with the physical table name
        //NOTE: the property name should be plural of the Conceptual class
        public System.Data.Entity.DbSet<MvcApplication.Models.Product> Products { get; set; }

    }
}