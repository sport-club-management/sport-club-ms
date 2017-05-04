using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Gwin.Entities.Application;
using App.Gwin.Entities.MultiLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Entities
{
    /// <summary>
    /// Fahsi Ben Sellam Mouad
    /// صنف البطولة
    /// </summary>
    [GwinEntity(Localizable = true, DisplayMember = "CategoryName")]
    [Menu(Group = "Tournament & Exams Management")]
    public class TournamentCategory : BaseEntity
    {
        public TournamentCategory() {
            this.CategoryName = new LocalizedString();
        }



        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString CategoryName { get; set; }
    }
}
