using App;
using App.Migrations;
using GenericWinForm.Demo;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericWinFormApplication
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Update Seed
            //var configuration = new Configuration();
            //var migrator = new DbMigrator(configuration);
            //migrator.Update();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMenuApplication());

            
        }
    }
}
