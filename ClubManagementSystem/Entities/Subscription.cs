using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Entities
{
   public  class Subscription:Incomes
    {
         public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
    }
}
