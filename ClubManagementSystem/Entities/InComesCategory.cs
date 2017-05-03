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
    public class InComesCategory:BaseEntity
    {
        public InComesCategory()
        {
            this.NameofInComesCategory = new LocalizedString();

        }
        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString NameofInComesCategory { get; set; }
        public string Description { get; set; }
    }
}
