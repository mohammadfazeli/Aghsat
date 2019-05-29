using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aghsat.ServiceLayer.Interface;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Aghsat.Domain;
using Aghsat.DataLayer.AghsatContext;
using Aghsat.DataLayer;
using System.Data.Entity;
namespace Aghsat.ServiceLayer.Services
{
    //public  class ApplicationRoleManagerService : RoleManager<Role, int>, IApplicationRoleManagerService
    //  {

    //      #region Fielde
    //       readonly IUnitWork _uow;
    //       readonly IDbSet<Role> _Role;
    //       readonly IDbSet<User> _User;
    //       readonly IRoleStore<Role, int> _RoleStore;


    //      #endregion

    //      #region constructor
    //      public ApplicationRoleManagerService(IUnitWork uow,IRoleStore<Role, int>  RoleStore) : base(RoleStore)
    //      {
    //          _uow = uow;
    //          _Role = _uow.set<Role>();
    //          _User = _uow.set<User>();
    //          _RoleStore = RoleStore;

    //      }


    //      #endregion

    //      #region Methode

    //      #region Get & GetAll

    //      public Role GetModel(int Id)
    //      {
    //          return _Role.SingleOrDefault(row => row.Id == Id);
    //      }
    //      public IEnumerable<Role> GetAllRole()
    //      {
    //          return Roles.ToList();
    //      }
    //      public int GetCount()
    //      {
    //          return _Role.Count();
    //      }

    //      public Role FindRoleByName(string roleName)
    //      {
    //          return this.FindByName(roleName);
    //      }
    //      public Role FindRoleByFarsiName(string roleFarsiName)
    //      {
    //          return Roles.FirstOrDefault(p => p.Name == roleFarsiName);
    //      }
    //      #endregion

    //      #region CUD

    //      public IdentityResult Add(Role role)
    //      {
    //          return this.Create(role);
    //      }
    //      #endregion

    //      #region Check Delete

    //      public bool CanDelete(Role role)
    //      {
    //          return !role.Users.Any();
    //      }

    //      #endregion

    //      #endregion
    //  }

    public class ApplicationRoleManagerService :
       RoleManager<Role, int>,
       IApplicationRoleManagerService
    {
         readonly IUnitOfWork _uow;
         readonly IRoleStore<Role,int> _roleStore;
         readonly IDbSet<User> _users;
        public ApplicationRoleManagerService(
            IUnitOfWork uow,
             IRoleStore<Role, int> RoleStore)
            : base(RoleStore)
        {
            _uow = uow;
            _roleStore = RoleStore;
            _users = _uow.Set<User>();
        }

        public Role FindRoleByName(string roleName)
        {
            return this.FindByName(roleName); // RoleManagerExtensions
        }

        public IdentityResult CreateRole(Role role)
        {
            return this.Create(role); // RoleManagerExtensions
        }

        public  IList<UserRole> GetCustomUsersInRole(string roleName)
        {
            return this.Roles.Where(role => role.Name == roleName)
                             .SelectMany(role => role.Users)
                             .ToList();
            // = this.FindByName(roleName).Users
        }

        public IList<User> GetusersInRole(string roleName)
        {
            var roleUserIdsQuery = from role in this.Roles
                                   where role.Name == roleName
                                   from user in role.Users
                                   select user.UserId;
            return _users.Where(User => roleUserIdsQuery.Contains(User.Id))
                         .ToList();
        }

        public IList<Role> FindUserRoles(int userId)
        {
            var userRolesQuery = from role in this.Roles
                                 from user in role.Users
                                 where user.UserId == userId
                                 select role;

            return userRolesQuery.OrderBy(x => x.Name).ToList();
        }

        public string[] GetRolesForUser(int userId)
        {
            var roles = FindUserRoles(userId);
            if (roles == null || !roles.Any())
            {
                return new string[] { };
            }

            return roles.Select(x => x.Name).ToArray();
        }

        public bool IsUserInRole(int userId, string roleName)
        {
            var userRolesQuery = from role in this.Roles
                                 where role.Name == roleName
                                 from user in role.Users
                                 where user.UserId == userId
                                 select role;
            var userRole = userRolesQuery.FirstOrDefault();
            return userRole != null;
        }

        public Task<List<Role>> GetAllRolesAsync()
        {
            return this.Roles.ToListAsync();
        }

        IList<Role> IApplicationRoleManagerService.GetCustomUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

     
    }
}
