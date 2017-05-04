using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Mime;
using App.Gwin.Entities.Persons;
using App.Gwin.Attributes;
using App.Gwin.Entities.MultiLanguage;

namespace ClubManagement.Entities
{
    [GwinEntity(Localizable = true, DisplayMember = "Name")]
    [Menu(Group = "TraineeManagement")]
    public  class Trainee: Person
    {
        public Trainee()
        {
            this.Birthplace = new LocalizedString();
            this.FatherName = new LocalizedString();
            this.FatherProfession = new LocalizedString();
        }
        [EntryForm]
        [DataGrid]

        public LocalizedString Birthplace { get; set; }
        [EntryForm]
        [DataGrid]
        
        public LocalizedString FatherName { get; set; }
        [EntryForm]
        [DataGrid]
      
        public LocalizedString FatherProfession { get; set; }
        [EntryForm]
        [DataGrid]
        [Filter]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public GroupAge GroupAge { get; set; }
        [EntryForm]
        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public EducationLevel EducationLevel { get; set; }
        [EntryForm]
        [DataGrid]
       
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Selection)]

        public List< Subscription> Subscriptions { get; set; }
        [EntryForm]
        [DataGrid]
       
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Selection)]

        public List<Weight> Weights { get; set; }
        [EntryForm]
        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Selection)]

        public List<Insurances> Insurancess { get; set; }
        [EntryForm]
        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Selection)]


        public List<Tournament> Tournaments { get; set; }
        [EntryForm]
        [DataGrid]
       
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Selection)]

        public List<Belt> Belts { get; set; }
      



    }
}
