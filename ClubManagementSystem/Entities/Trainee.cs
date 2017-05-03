using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Mime;
using App.Gwin.Entities.Persons;

namespace ClubManagement.Entities
{
   public  class Trainee: Person
    {
       

        public string Birthplace { get; set; }
        public string FatherName { get; set; }
        public string FatherProfession { get; set; }
        public EducationLevel EducationLevel { get; set; }

        public List< Subscription> Subscriptions { get; set; }
        public List<Weight> Weights { get; set; }
        public List<Insurances> Insurancess { get; set; }

        public List<Tournament> Tournaments { get; set; }
        public List<Belt> Belts { get; set; }
      



    }
}
