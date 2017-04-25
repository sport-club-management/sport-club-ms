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
    //Youssef Temsamani Nya
    /// <summary>
    /// الفئة العمرية
    /// </summary>
    [GwinEntity(Localizable = true, DisplayMember = "NameOfCategory")]
    [Menu(Group = "Configuration")]
    public class GroupAge : BaseEntity
    {

        public GroupAge()
        {
            this.NameOfCategory = new LocalizedString();
        }

        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString NameOfCategory { get; set; }

        [EntryForm]
        [DataGrid]
        public int SmallestYear { get; set; }

        [EntryForm]
        [DataGrid]
        public int LargestYear { get; set; }
    }
}
