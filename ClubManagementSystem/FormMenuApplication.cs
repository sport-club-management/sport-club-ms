using App;
using App.Gwin;
using App.Gwin.Application.BAL.GwinApplication;
using App.Gwin.Application.Presentation.EntityManagement;
using App.Gwin.Application.Presentation.MainForm;
using App.Gwin.Entities;
using App.Gwin.Entities.Application;
using App.Gwin.Entities.Authentication;
using SplashScreen;
using System;
using System.Windows.Forms;

namespace GenericWinForm.Demo
{
    public partial class FormMenuApplication : FormApplication
    {
        public FormMenuApplication()
        {
            InitializeComponent();
        }

        private void FormMenuApplication_Load(object sender, EventArgs e)
        {
            // Application User
            User user = new User();
            user.Language = GwinApp.Languages.en;

            // Start Gwin Application
            GwinApp.Start(typeof(ModelContext), typeof(BaseBLO<>),this, user);
            
        }

    }
}
