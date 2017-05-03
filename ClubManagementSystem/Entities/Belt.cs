
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


    [GwinEntity(Localizable = true, DisplayMember = "NameofTheBelt")]
    [Menu(Group = "Configuration")]
    public class Belt : BaseEntity
    {

        public Belt()
        {
            this.NameofTheBelt = new LocalizedString();

        }
        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString NameofTheBelt { get; set; }



        [EntryForm]
        [DataGrid]
        [Filter]
        public String Description { get; set; }


     
        [EntryForm]
        [DataGrid]
        [Filter]
        public string DegreeBelt { get; set; }

        public BeltExam BeltExam { get; set; }

    }
}