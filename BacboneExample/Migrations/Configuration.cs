using BacboneExample.Models;

namespace BacboneExample.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UsersContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UsersContext context)
        {
            for (int i = 1; i < 3; i++)
            {
                context.Users.Add(new User
                {
                    Id = i,
                    Fname = Faker.NameFaker.FirstName(),
                    LName = Faker.NameFaker.LastName(),
                    Age = i+20
                });
            }

            context.SaveChanges();
        }
    }
}
