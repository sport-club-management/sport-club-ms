using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Entities
{
    public class BeltExam:BaseEntity
    {
        public DateTime Date { get; set; }

        public string Result { get; set; }
    }
}
