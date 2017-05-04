// Mariam Ait Al
// Groupe : TDI204
//2017
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
    public class Expense:BaseEntity
    {
        public Expense()
        {
            this.Name = new LocalizedString();
            this.Description = new LocalizedString();
        }

        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString Name { get; set; }

        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString Description { get; set; }

        [EntryForm]
        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public ExpenseCategory ExpenseCategory { get; set; }
    }
}
