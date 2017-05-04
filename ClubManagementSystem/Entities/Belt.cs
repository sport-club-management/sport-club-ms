
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
    [Menu(Group = "Tournament & Exams Management")]
    public class Belt : BaseEntity
    {

        public Belt()
        {
            this.NameofTheBelt = new LocalizedString();
            this.DegreeBelt = new LocalizedString();
            this.Description = new LocalizedString();

        }
        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString NameofTheBelt { get; set; }



        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString Description { get; set; }


     
        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString DegreeBelt { get; set; }

        [EntryForm]
        [DataGrid]
        [Relationship(Relation =RelationshipAttribute.Relations.OneToOne)]
        public BeltExam BeltExam { get; set; }
        [EntryForm]
        [DataGrid]

        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Creation)]
        public List<Trainee> Trainees { set; get; }

    }
}