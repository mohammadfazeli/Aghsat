using Aghsat.DataLayer.AghsatContext;
using Aghsat.Domain;
using Aghsat.ServiceLayer.Interface;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aghsat.ServiceLayer.Services
{
   public class UserStore : UserStore<User,Role,int,UserLogin,UserRole,UserClaim>, IUserStore
    {
        public UserStore(AghsatContext Context) :base(Context)
        {

        }
    }
}
