using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClubManagement.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubManagement.Entities;
using App.Gwin;
using App;
using GenericWinForm.Demo;
using App.Gwin.Entities.Secrurity.Authentication;

namespace ClubManagement.BAL.Tests
{
    [TestClass()]
    public class GroupAgeBLOTests
    {
        [TestMethod()]
        public void SaveTest()
        {
            // Application User
            User user = new User();
            user.Language = GwinApp.Languages.en;

            // Start Gwin Application
            GwinApp.Start(typeof(ModelContext), typeof(BaseBLO<>), new FormMenuApplication(), user);


            //GroupAgeBLO GroupAgeBLO = new GroupAgeBLO();
            //GroupAge groupe = new GroupAge();
            //int r =  GroupAgeBLO.Save(groupe);


            //Assert.AreEqual(r, 1);
        }
    }
}