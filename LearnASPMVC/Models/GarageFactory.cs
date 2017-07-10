using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LearnASPNETMVC.Models
{
    public class GarageFactory : DbContext
    {
        public GarageFactory()
        {
            Database.SetInitializer(new GarageInitializer());
        }
        public DbSet<Car> Cars { get; set; }
        // add any other table here
    }

    public class GarageInitializer : DropCreateDatabaseIfModelChanges<GarageFactory>
    {
        protected override void Seed(GarageFactory context)
        {
            context.Cars.Add(new Car()
            {
                Model = "Rabbit", MaxSpeed = 300
            });
            context.Cars.Add(new Car()
            {
                Model = "Turtle" , MaxSpeed = 150
            });
        }
    }
}