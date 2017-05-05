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
    [GwinEntity(Localizable =true,DisplayMember ="Name")]
    [Menu(Group = "Configuration")]
   public class EducationLevel : BaseEntity
    {
        public EducationLevel()
        {
            this.Name = new LocalizedString();
            this.Description = new LocalizedString();
        }
        [EntryForm(WidthControl  = 400)]
        [DataGrid(WidthColonne = 200)]
        [Filter(WidthControl = 300)]
        public LocalizedString Name { get; set; }

        [EntryForm(MultiLine = true,NumberLine = 10,WidthControl = 600)]
        [DataGrid(WidthColonne = 200)]
        [Filter]
        public LocalizedString Description { get; set; }
    }
}
