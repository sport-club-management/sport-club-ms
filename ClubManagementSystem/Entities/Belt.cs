using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Entities
{
   public  class Belt:BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string DegreeBelt { get; set; }

        public BeltExam BeltExam { get; set; }

    }
}
