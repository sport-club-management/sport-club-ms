using App.Gwin.Attributes;
using App.Gwin.Entities;
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
    [GwinEntity(Localizable = true,DisplayMember = "Type_Name")]
    [Menu]
    public class GroupAge : BaseEntity
    {
        [DisplayProperty(Titre ="Type_Name")]
        [EntryForm]
        [DataGrid]
        [Filter]
        public string Type_Name { get; set; }
        [DisplayProperty(Titre ="YoungestAge")]
        [EntryForm]
        [DataGrid]
        public string Youngest_Age { get; set; }
        [DisplayProperty(Titre ="OldestAge")]
        [EntryForm]
        [DataGrid]
        public string Oldest_Age { get; set; }
    }
}
