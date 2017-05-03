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
        public DateTime DateTournament{get;set;}
        public TournamentCategory TournamentCategory { get; set; }
        public TournamentRanking ChampionshipRanking { get; set; }
        public GroupAge GroupAge { get; set; }

    }
}
