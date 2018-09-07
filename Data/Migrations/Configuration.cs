using System.Configuration;

namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["AutomaticMigrationsEnabled"]);
            AutomaticMigrationDataLossAllowed = Convert.ToBoolean(ConfigurationManager.AppSettings["AutomaticMigrationDataLossAllowed"]);
        }

        protected override void Seed(WebAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
