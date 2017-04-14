namespace App.Migrations
{
    using App.Gwin.Entities.Application;
    using App.Gwin.Entities.MultiLanguage;
    using App.Gwin.Entities.Secrurity.Authentication;
    using App.Gwin.Entities.Secrurity.Autorizations;
    using Gwin;
    using Gwin.Application.BAL;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ClubManagementSystem";
        }

        protected override void Seed(App.ModelContext context)
        {

            //Gwin Application Name
            context.ApplicationNames.AddOrUpdate(
                           r => r.Reference
                        ,
                        new App.Gwin.Entities.Application.ApplicationName
                        {
                            Reference = "ClubManagementSystem",
                            Name = new Gwin.Entities.MultiLanguage.LocalizedString { Arab = "برنامج تدبير نادي رياضي", English = "Club Management System", French = "Application de gestion d'un club de sport" }
                        }

                      );

            // Gwin  Roles
            Role RoleGuest = null;
            Role RoleRoot = null;
            context.Roles.AddOrUpdate(
                 r => r.Reference
                        ,
              new Role { Reference = nameof(Role.Roles.Guest), Name = new Gwin.Entities.MultiLanguage.LocalizedString() { Current = nameof(Role.Roles.Guest) } },
              new Role { Reference = nameof(Role.Roles.User), Name = new Gwin.Entities.MultiLanguage.LocalizedString() { Current = nameof(Role.Roles.User) } },
              new Role { Reference = nameof(Role.Roles.Admin), Name = new Gwin.Entities.MultiLanguage.LocalizedString() { Current = nameof(Role.Roles.Admin) } },
              new Role { Reference = nameof(Role.Roles.Root), Name = new Gwin.Entities.MultiLanguage.LocalizedString() { Current = nameof(Role.Roles.Root) }, Hidden = true }
            );

            // in First Update-DataBase Root user dont take root Role
            // When I remove Root user, after Update-DataBase the user root take root role
            RoleRoot = context.Set<Role>().Where(r => r.Reference == nameof(Role.Roles.Root)).SingleOrDefault();
            RoleGuest = context.Set<Role>().Where(r => r.Reference == nameof(Role.Roles.Guest)).SingleOrDefault();
            // Giwn Users
            context.Users.AddOrUpdate(
                u => u.Reference,
                new User() { Reference = nameof(User.Users.Root), Login = "root", Password = "root", LastName = new LocalizedString() { Current = nameof(User.Users.Root) }, Roles = new List<Role>() { RoleRoot } },
                  new User() { Reference = nameof(User.Users.Guest), Login = nameof(User.Users.Guest), Password = nameof(User.Users.Guest), LastName = new LocalizedString() { Current = nameof(User.Users.Guest) }, Roles = new List<Role>() { RoleGuest } }
                );



            // Gwin  Menu
            context.MenuItemApplications.AddOrUpdate(
                            r => r.Code
                         ,
                         new MenuItemApplication { Id = 1, Code = "Configuration", Title = new Gwin.Entities.MultiLanguage.LocalizedString { Arab = "إعدادات", English = "Configuration", French = "Configuration" } },
                         new MenuItemApplication { Id = 2, Code = "Admin", Title = new Gwin.Entities.MultiLanguage.LocalizedString { Arab = "تدبير البرنامج", English = "Admin", French = "Administration" } },
                         new MenuItemApplication { Id = 3, Code = "Root", Title = new Gwin.Entities.MultiLanguage.LocalizedString { Arab = "مصمم اليرنامج", English = "Application Constructor", French = "Rélisateur de l'application" } }
                       );

        }
    }
}
