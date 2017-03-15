using App;
using ClubManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.BAL
{
    public class GroupAgeBLO : BaseBLO<GroupAge>
    {

        public override int Save(GroupAge item)
        {
            return base.Save(item); 
        }
    }
}
