namespace App.Migrations
{
    using App.Gwin.Entities.Application;
    using App.Gwin.Entities.ContactInformations;
    using App.Gwin.Entities.MultiLanguage;
    using App.Gwin.Entities.Secrurity.Authentication;
    using App.Gwin.Entities.Secrurity.Autorizations;
    using ClubManagement.Entities;
    using Gwin;
    using Gwin.Application.BAL;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "SportClubManagement";
        }

        protected override void Seed(App.ModelContext context)
        {
            // -------------------------------------
            // Giwn App V 0.08
            // -------------------------------------
            //-- Gwin Application Name
            context.ApplicationNames.AddOrUpdate(
                           r => r.Reference
                        ,
                        new App.Gwin.Entities.Application.ApplicationName
                        {
                            Reference = "ClubManagementSystem",
                            Name = new Gwin.Entities.MultiLanguage.LocalizedString { Arab = "برنامج تدبير نادي رياضي", English = "Club Management System", French = "Application de gestion d'un club de sport" }
                        }

                      );


            //
            // Gwin Roles
            //
            Role RoleGuest = null;
            Role RoleRoot = null;
            Role RoleAdmin = null;
            context.Roles.AddOrUpdate(
                 r => r.Reference
                        ,
              new Role { Reference = nameof(Role.Roles.Guest), Name = new Gwin.Entities.MultiLanguage.LocalizedString() { Current = nameof(Role.Roles.Guest) } },
              new Role { Reference = nameof(Role.Roles.User), Name = new Gwin.Entities.MultiLanguage.LocalizedString() { Current = nameof(Role.Roles.User) } },
              new Role { Reference = nameof(Role.Roles.Admin), Name = new Gwin.Entities.MultiLanguage.LocalizedString() { Current = nameof(Role.Roles.Admin) } },
              new Role { Reference = nameof(Role.Roles.Root), Name = new Gwin.Entities.MultiLanguage.LocalizedString() { Current = nameof(Role.Roles.Root) }, Hidden = true }
            );
            // Save Change to Select RoleRoot and RoleGuest
            context.SaveChanges();
            RoleRoot = context.Roles.Where(r => r.Reference == nameof(Role.Roles.Root)).SingleOrDefault();
            RoleGuest = context.Roles.Where(r => r.Reference == nameof(Role.Roles.Guest)).SingleOrDefault();
            RoleAdmin = context.Roles.Where(r => r.Reference == nameof(Role.Roles.Admin)).SingleOrDefault();

            // 
            // Giwn Autorizations
            //
            // Guest Autorization
            Authorization FindUserAutorization = new Authorization();
            FindUserAutorization.BusinessEntity = typeof(User).FullName;
            FindUserAutorization.ActionsNames = new List<string>();
            FindUserAutorization.ActionsNames.Add(nameof(IGwinBaseBLO.Recherche));

            RoleGuest.Authorizations = new List<Authorization>();
            RoleGuest.Authorizations.Add(FindUserAutorization);

            // Admin Autorization
            RoleAdmin.Authorizations = new List<Authorization>();

            Authorization UserAutorization = new Authorization();
            UserAutorization.BusinessEntity = typeof(User).FullName;
            RoleAdmin.Authorizations.Add(UserAutorization);


            Authorization CityAutorization = new Authorization();
            CityAutorization.BusinessEntity = typeof(City).FullName;
            RoleAdmin.Authorizations.Add(CityAutorization);


            Authorization CountryAutorization = new Authorization();
            CountryAutorization.BusinessEntity = typeof(Country).FullName;
            RoleAdmin.Authorizations.Add(CountryAutorization);

            context.SaveChanges();

            //-- Giwn Users
            context.Users.AddOrUpdate(
                u => u.Reference,
                new User() { Reference = nameof(User.Users.Root), Login = nameof(User.Users.Root), Password = nameof(User.Users.Root), LastName = new LocalizedString() { Current = nameof(User.Users.Root) }, Roles = new List<Role>() { RoleRoot } },
                new User() { Reference = nameof(User.Users.Admin), Login = nameof(User.Users.Admin), Password = nameof(User.Users.Admin), LastName = new LocalizedString() { Current = nameof(User.Users.Admin) }, Roles = new List<Role>() { RoleAdmin } },
                new User() { Reference = nameof(User.Users.Guest), Login = nameof(User.Users.Guest), Password = nameof(User.Users.Guest), LastName = new LocalizedString() { Current = nameof(User.Users.Guest) }, Roles = new List<Role>() { RoleGuest } }
                );
            //-- Gwin  Menu
            context.MenuItemApplications.AddOrUpdate(
                            r => r.Code
                         ,
                         new MenuItemApplication { Id = 1, Code = "Configuration", Title = new Gwin.Entities.MultiLanguage.LocalizedString { Arab = "إعدادات", English = "Configuration", French = "Configuration" } },
                         new MenuItemApplication { Id = 2, Code = "Admin", Title = new Gwin.Entities.MultiLanguage.LocalizedString { Arab = "تدبير البرنامج", English = "Admin", French = "Administration" } },
                         new MenuItemApplication { Id = 3, Code = "Root", Title = new Gwin.Entities.MultiLanguage.LocalizedString { Arab = "مصمم اليرنامج", English = "Application Constructor", French = "Rélisateur de l'application" } }
                       );
            //-- Tournament Categories Data
            context.TournamentCategories.AddOrUpdate(
                            r => r.Reference,
                            new TournamentCategory { Reference="Local", CategoryName=new LocalizedString { Arab=" محلي",French="Local",English="Local"} },
                            new TournamentCategory { Reference="Regional", CategoryName=new LocalizedString { Arab=" جهوي",French="Régional",English="Regional"} },
                            new TournamentCategory { Reference="National", CategoryName=new LocalizedString { Arab=" وطني",French="National",English="National"} },
                            new TournamentCategory { Reference="International", CategoryName=new LocalizedString { Arab=" دولي",French="International",English="International"} }
                );

            //---------------------------------------------------------
            // Sport Club Management System
            //---------------------------------------------------------

            // Admin Autorization
            Authorization GroupAgeAutorization = new Authorization();
            GroupAgeAutorization.BusinessEntity = typeof(GroupAge).FullName;
            RoleAdmin.Authorizations.Add(GroupAgeAutorization);

            Authorization TournamentCategoryAuthorisation = new Authorization();
            TournamentCategoryAuthorisation.BusinessEntity = typeof(TournamentCategory).FullName;
            RoleAdmin.Authorizations.Add(TournamentCategoryAuthorisation);

            context.SaveChanges();
        }
    }
}
