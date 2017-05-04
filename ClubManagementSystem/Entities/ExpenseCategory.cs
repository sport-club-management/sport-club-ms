//Mariam Ait Al
//Groupe : TDI204
//2017
using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Gwin.Entities.MultiLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClubManagement.Entities
{
    [GwinEntity(Localizable = true, DisplayMember = "Name")]
    [Menu(Group = "ExpenseManagement")]
    public class ExpenseCategory: BaseEntity
    {
        public ExpenseCategory()
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
    }
}
