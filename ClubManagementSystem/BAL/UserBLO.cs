using App.Gwin;
using App.Gwin.Entities.Secrurity.Authentication;
using App.Gwin.Entities.Secrurity.Autorizations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubManagement.BAL
{
    /// <summary>
    /// Version 0.09
    /// </summary>
    public class UserBLO : BaseBLO<User>
    {
        public UserBLO() : base()
        {

        }
        public UserBLO(DbContext context) : base(context)
        {

        }
        public UserBLO(Type TypeDbContext) : base(TypeDbContext)
        {

        }
        public override List<object> Recherche(Dictionary<string, object> rechercheInfos, int startPage = 0, int itemsPerPage = 0)
        {
            // Get Role root
            BaseBLO<Role> RoleBLO = new BaseBLO<Role>();
            Role rootRole = (Role)RoleBLO.GetBaseEntityByReference(nameof(Role.Roles.Root));
            Role guestRole = (Role)RoleBLO.GetBaseEntityByReference(nameof(Role.Roles.Guest));

            // Check if User has Root access
            if (GwinApp.Instance.user.HasOneOfRoles(new List<Role> { rootRole, guestRole })   )
            {
                return base.Recherche(rechercheInfos, startPage, itemsPerPage);
            }
            else
            {
                // if User don't have root access : we remove root user from resulte
                List<User> ls_user = base.Recherche(rechercheInfos, startPage, itemsPerPage).Cast<User>().ToList<User>();
                ls_user.Remove(ls_user.Where(u => u.Reference == nameof(Role.Roles.Root)).SingleOrDefault());
                return ls_user.Cast<object>().ToList<object>();
            }
               
        }
    }
}
