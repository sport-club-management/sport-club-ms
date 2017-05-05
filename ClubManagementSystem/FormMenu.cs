using System;
using System.Windows.Forms;
using App.WinFrom.Menu;
using System.Globalization;
using App.WinForm.Entities;
using App.WinForm.Forms;
using App.WinForm.Entities.Authentication;
using App.WinForm.Forms.FormMenu;
using App.WinForm.Entities.Application;
using App.WinForm.Application.Security;
using App.WinForm.Application.BAL;
using App;
using App.WinForm.Application;

namespace App
{
    public partial class FormMenu : BaseForm, IApplicationMenu
    {

        ShowEntityManagementForm showManagementForm { set; get; }

        /// <summary>
        /// AAA
        /// </summary>
        public FormMenu()
        {

            
            
            // Default User 
            User user = new User();
            user.Name = "ES-SARRAJ";
            user.FirstName = "Fouad";

            // Start Application Session
            GWinApp.Start(new Session(this, user, CultureInfo.CreateSpecificCulture("fr")));

            // Update Menu Table from ModelConfiguation
            InstallApplication installApplication = new InstallApplication(typeof(ModelContext));
            installApplication.Update();

            // Reload : to apply language configuration
            Reload();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Reload()
        {
            this.Controls.Clear();
            InitializeComponent();
            showManagementForm = new ShowEntityManagementForm(new BaseBAO<BaseEntity>(), this);
            new ConfigMenuApplication(new BaseBAO<MenuItemApplication>(), this);
        }

        #region Form Events
        private void FormMenu_Load(object sender, EventArgs e)
        {
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        /// <summary>
        /// Get the menu application instance
        /// </summary>
        public MenuStrip getMenuStrip()
        {
            return this.menuStrip1;
        }


        #region Menu Languague Click
        private void frenchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WinForm.Application.GWinApp.Session.ChangeLanguage(CultureInfo.CreateSpecificCulture("fr"));
            this.RightToLeftLayout = false;
            this.RightToLeft = RightToLeft.No;
        }

        private void anglaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WinForm.Application.GWinApp.Session.ChangeLanguage(CultureInfo.CreateSpecificCulture("en"));
            this.RightToLeftLayout = false;
            this.RightToLeft = RightToLeft.No;
        }

        private void arabeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WinForm.Application.GWinApp.Session.ChangeLanguage(new CultureInfo("ar"));
        }
        #endregion

    }
}
