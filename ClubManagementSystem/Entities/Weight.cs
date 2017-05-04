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
    [GwinEntity(Localizable = true, DisplayMember = "NameOfWeight")]
    [Menu(Group = "Tournament & Exams Management")]
    public class Weight:BaseEntity
    {
        public Weight()
        {
            this.NameOfWeight = new LocalizedString();
        
        }
        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString NameOfWeight { get; set; }
        [EntryForm]
        [DataGrid]
      
        public float Minimumvalue { get; set; }
        [EntryForm]
        [DataGrid]
        public float Maximumvalue { get; set; }
        [EntryForm]
        [DataGrid]

        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Creation)]
        public List<Trainee> Trainees { set; get; }



    }
}
