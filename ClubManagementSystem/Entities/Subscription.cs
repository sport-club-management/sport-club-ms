using App.Gwin.Attributes;
using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Entities
{
    [GwinEntity(Localizable = true, DisplayMember = "NameofInComesCategory")]
    [Menu(Group = "ExpenseManagement")]
    public  class Subscription:Incomes
    {

        [EntryForm]
        [DataGrid]
     
        public DateTime StartDate { get; set; }

        [EntryForm]
        [DataGrid]
       
        public DateTime EndDate { get; set; }
        [EntryForm]
        [DataGrid]

        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Creation)]
        public List<Trainee> Trainees { set; get; }
    }
}
