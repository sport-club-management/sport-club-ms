using App.Gwin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.Entities
{
    public class Tournament : BaseEntity
    {
        public string Name { get; set; }

        public DateTime DateTournament{get;set;}
        public TournamentCategory TournamentCategory { get; set; }
        public ChampionshipRanking ChampionshipRanking { get; set; }
        public GroupAge GroupAge { get; set; }

    }
}
