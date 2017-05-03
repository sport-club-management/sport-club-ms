using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Entities
{
   public  class Incomes: BaseEntity
    {
      
        public float value { get; set; }
        public InComesCategory InComesCategory { get; set; }
    }
}
