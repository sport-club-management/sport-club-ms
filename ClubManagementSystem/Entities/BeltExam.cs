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
    [GwinEntity(Localizable = true, DisplayMember = "NameofTheBeltExam")]
    [Menu(Group = "Tournament & Exams Management")]
    public class BeltExam:BaseEntity
    {
        public BeltExam()
        {
            this.NameofTheBeltExam = new LocalizedString();
            this.Result = new LocalizedString();

        }
        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString NameofTheBeltExam { get; set; }
        [EntryForm]
        [DataGrid]
      
        public DateTime Date { get; set; }
        [EntryForm]
        [DataGrid]
        public LocalizedString Result { get; set; }
    }
}
