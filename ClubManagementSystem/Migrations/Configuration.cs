namespace App.Migrations
{
    using Gwin;
    using Gwin.Application.BAL;
    using Gwin.Entities.Security;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ClubManagementSystem";
        }

        protected override void Seed(App.ModelContext context)
        {
     
            context.Roles.AddOrUpdate(
                 r => r.Id
              ,
              new Role { Id = 1, Name = "Root",Hidden= true },
              new Role { Id = 2, Name = "Admin" },
              new Role { Id = 3, Name = "User" },
              new Role { Id = 4, Name = "Project Management system" }
            );
        }
    }
}
