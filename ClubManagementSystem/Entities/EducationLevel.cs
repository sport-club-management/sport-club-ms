using App.Gwin.Attributes;
using App.Gwin.Entities;
using App.Gwin.Entities.MultiLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Entities
{
    //Youssef Temsamani Nya
    [GwinEntity(Localizable =true,DisplayMember ="Name")]
    [Menu(Group = "Configuration")]
   public class EducationLevel : BaseEntity
    {
        public EducationLevel()
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
        public LocalizedString Description { get; set; }
    }
}
