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
        /// <summary>
        /// Configuration
        /// </summary>
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


           //ChampionshipRanking

            Authorization ChampionshipRankingAutorization = new Authorization();
            ChampionshipRankingAutorization.BusinessEntity = typeof(TournamentRanking).FullName;
            RoleAdmin.Authorizations.Add(ChampionshipRankingAutorization);
            //

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

            // 
            // Admin Autorization
            //
            Authorization GroupAgeAutorization = new Authorization();
            GroupAgeAutorization.BusinessEntity = typeof(GroupAge).FullName;
            RoleAdmin.Authorizations.Add(GroupAgeAutorization);
            context.SaveChanges();
            
            //Belt Exam Autorization
            Authorization BeltExamAutorization = new Authorization();
            BeltExamAutorization.BusinessEntity = typeof(BeltExam).FullName;
            RoleAdmin.Authorizations.Add(BeltExamAutorization);
            context.SaveChanges();

            //Incomes Autorization
            Authorization IncomesAutorization = new Authorization();
            IncomesAutorization.BusinessEntity = typeof(Incomes).FullName;
            RoleAdmin.Authorizations.Add(IncomesAutorization);
            context.SaveChanges();

            //IncomesCategory Autorization
            Authorization IncomesCategoryAutorization = new Authorization();
            IncomesCategoryAutorization.BusinessEntity = typeof(InComesCategory).FullName;
            RoleAdmin.Authorizations.Add(IncomesCategoryAutorization);
            context.SaveChanges();

            //Insurance Autorization
            Authorization InsurancesAutorization = new Authorization();
            InsurancesAutorization.BusinessEntity = typeof(Insurances).FullName;
            RoleAdmin.Authorizations.Add(InsurancesAutorization);
            context.SaveChanges();

            //Subscription Autorization 
            Authorization SubscriptionAutorization = new Authorization();
            SubscriptionAutorization.BusinessEntity = typeof(Subscription).FullName;
            RoleAdmin.Authorizations.Add(SubscriptionAutorization);
            context.SaveChanges();

            //Tournament Autorization
            Authorization TournamentAutorization = new Authorization();
            TournamentAutorization.BusinessEntity = typeof(Tournament).FullName;
            RoleAdmin.Authorizations.Add(TournamentAutorization);
            context.SaveChanges();
            //Tournament ranking autorization
            Authorization TournamentRankingAutorization = new Authorization();
            TournamentRankingAutorization.BusinessEntity = typeof(TournamentRanking).FullName;
            RoleAdmin.Authorizations.Add(TournamentRankingAutorization);
            context.SaveChanges();

            //Trainee Autorization
            Authorization TraineeAutorization = new Authorization();
            TraineeAutorization.BusinessEntity = typeof(Trainee).FullName;
            RoleAdmin.Authorizations.Add(TraineeAutorization);

            //Weigth Autorization
            Authorization WeigthAutorization = new Authorization();
            WeigthAutorization.BusinessEntity = typeof(Weight).FullName;
            RoleAdmin.Authorizations.Add(WeigthAutorization);
            context.SaveChanges();


            // Belt Data
            context.Belts.AddOrUpdate(
                           r => r.Reference
                        ,
            new Belt()
            {
               
                NameofTheBelt = new LocalizedString() { English = "Name", French = "Nom" ,Arab= "إسم الحزام" },
                //  Description = new LocalizedString() { English = "Description", French = "Description" },
                //levelofThebelt = new LocalizedString() { English = "Name", French = "Nom" }
            });


            Authorization EducationLevelAutorization = new Authorization();
            EducationLevelAutorization.BusinessEntity = typeof(EducationLevel).FullName;
            RoleAdmin.Authorizations.Add(EducationLevelAutorization);

            Authorization TournamentCategoryAuthorisation = new Authorization();
            TournamentCategoryAuthorisation.BusinessEntity = typeof(TournamentCategory).FullName;
            RoleAdmin.Authorizations.Add(TournamentCategoryAuthorisation);

            context.SaveChanges();



            //
            Authorization ExpensesAuthorization = new Authorization();
            ExpensesAuthorization.BusinessEntity = typeof(Expense).FullName;
            RoleAdmin.Authorizations.Add(ExpensesAuthorization);
            context.SaveChanges();
            //
            Authorization ExpensesCategoryAuthorization = new Authorization();
            ExpensesCategoryAuthorization.BusinessEntity = typeof(ExpenseCategory).FullName;
            RoleAdmin.Authorizations.Add(ExpensesCategoryAuthorization);

            context.SaveChanges();

            // GroupeAge Data
            context.GroupAges.AddOrUpdate(
                            r => r.Reference
                         ,
             new GroupAge()
             {
                 Reference = "Small",
                 SmallestYear = 7,
                 LargestYear = 11,
                 NameOfCategory = new LocalizedString() { Arab = "صغار", English = "Small", French = "Petit" }
             },
            
              new GroupAge()
              {
                  Reference = "Boys",
                  SmallestYear = 12,
                  LargestYear = 14,
                  NameOfCategory = new LocalizedString() { Arab = "فتيان", English = "Boys", French = "Garçons" }
              },
               new GroupAge()
               {
                   Reference = "Young",
                   SmallestYear = 15,
                   LargestYear = 17,
                   NameOfCategory = new LocalizedString() { Arab = "شباب", English = "Young", French = "Jeunes" }
               },
               new GroupAge()
               {
                   Reference = "Senior",
                   SmallestYear = 18,
                   LargestYear = 100,
                   NameOfCategory = new LocalizedString() { Arab = "كبار", English = "Senior", French = "Supérieur" }
               }
              

             );
            //Education Level data
            context.EducationLevels.AddOrUpdate(
                         r => r.Reference,
                         new EducationLevel()
                         {
                             Reference = "Primary",
                             Name = new LocalizedString() { Arab = "التعليم الإبتدائي",English= "Primary education",French= "Education primaire" },
                             

                         },
                           new EducationLevel()
                           {
                              Reference = "Secondary",
                              Name = new LocalizedString() { Arab = "التعليم الإعدادي", English = "Secondary education", French = "Education préparatoire" },
                            

                         },
                            new EducationLevel()
                            {
                                Reference = "high school",
                                Name = new LocalizedString() { Arab = "التعليمالثانوي", English = "High school", French = "Lycée" },
                                
                            },
                                  new EducationLevel()
                                  {
                                      Reference = "University",
                                      Name = new LocalizedString() { Arab = "التعليم الجامعي", English = "University", French = "Université" },
                                    

                                  }
                         );

        }
    }
}
