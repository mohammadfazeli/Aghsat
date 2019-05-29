using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aghsat.ServiceLayer.Interface;
using Microsoft.AspNet.Identity;
using Aghsat.Domain;
using Aghsat.ServiceLayer.Services;
namespace Aghsat.ServiceLayer.Services
{
   public class RoleStore : IRoleStore
    {

        public readonly IRoleStore<Role, int> _roleStore;


        //public RoleStore() : base()
        //{

        //}
        public RoleStore(IRoleStore<Role, int> roleStore)
        {
            _roleStore = roleStore;
        }


    }
}
