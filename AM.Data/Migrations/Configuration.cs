using System.Collections.Generic;
using System.Globalization;
using AM.Data.Entities;

namespace AM.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AM.Data.AMDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AM.Data.AMDbContext";
        }

        protected override void Seed(AM.Data.AMDbContext context)
        {
            context.Employees.AddOrUpdate(
                p => p.Name,
                new Employee()
                {
                    Name = "Franta",
                    Age = 55,
                    Passes = new List<Pass>()
                    {
                        new Pass()
                        {
                            Time = DateTime.Parse("2015-04-20 08:00:00", CultureInfo.InvariantCulture),
                            Type = PassTypeEnum.Arrive,
                        },
                        new Pass()
                        {
                            Time = DateTime.Parse("2015-04-20 13:00:00", CultureInfo.InvariantCulture),
                            Type = PassTypeEnum.Leave,
                        },
                        new Pass()
                        {
                            Time = DateTime.Parse("2015-04-21 08:20:00", CultureInfo.InvariantCulture),
                            Type = PassTypeEnum.Arrive,
                        },
                        new Pass()
                        {
                            Time = DateTime.Parse("2015-04-21 16:00:00", CultureInfo.InvariantCulture),
                            Type = PassTypeEnum.Arrive,
                        },
                    }
                },
                new Employee()
                {
                    Name = "Josef",
                    Age = 22,
                },
                new Employee()
                {
                    Name = "Tomas",
                    Age = 68,
                }
                );
        }
    }
}