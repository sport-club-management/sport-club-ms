using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Gwin.Entities.MultiLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Entities
{

    [GwinEntity(Localizable = true, DisplayMember = "Name")]
    [Menu(Group = "ExpenseManagement")]
    public  class Incomes: BaseEntity
    {
        public Incomes()
        {
            this.Name = new LocalizedString();

        }
        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString Name { get; set; }

        [EntryForm]
        [DataGrid]
        public float value { get; set; }
        [EntryForm]
        [DataGrid]
        [Relationship(Relation =RelationshipAttribute.Relations.ManyToOne)]
        public InComesCategory InComesCategory { get; set; }
    }
}
