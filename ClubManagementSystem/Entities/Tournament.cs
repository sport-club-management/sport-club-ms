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
    [GwinEntity(Localizable = true, DisplayMember = "NameofTournament")]
    [Menu(Group = "Tournament & Exams Management")]
    public class Tournament : BaseEntity
    {
        public Tournament()
        {
            this.NameofTournament = new LocalizedString();

        }
        [EntryForm]
        [DataGrid]
        [Filter]
        public LocalizedString NameofTournament { get; set; }
        [EntryForm]
        [DataGrid]
       
        public DateTime DateTournament{get;set;}
        [EntryForm]
        [DataGrid]
        [Filter]
        [Relationship(Relation =RelationshipAttribute.Relations.ManyToOne)]
        public TournamentCategory TournamentCategory { get; set; }
        [EntryForm]
        [DataGrid]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]

        public TournamentRanking ChampionshipRanking { get; set; }
        [EntryForm]
        [DataGrid]
        [Filter]
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToOne)]
        public GroupAge GroupAge { get; set; }

        [EntryForm]
        [DataGrid]
       
        [Relationship(Relation = RelationshipAttribute.Relations.ManyToMany_Creation)]
        public List<Trainee> Trainees { set; get; }

    }
}
