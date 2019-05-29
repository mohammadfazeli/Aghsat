namespace Aghsat.DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public   sealed class Configuration : DbMigrationsConfiguration<Aghsat.DataLayer.AghsatContext.AghsatContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Aghsat.DataLayer.AghsatContext.AghsatContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            
        }
    }
}
